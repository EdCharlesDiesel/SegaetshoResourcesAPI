using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using SegaetshoResources.API.Services;
using System;

namespace SegaetshoResources.API
{
    public class Startup
    {
        private readonly IHostEnvironment environment;
        private readonly IConfiguration config;

        public Startup(IConfiguration configuration, IHostEnvironment environment)
        {
            config = configuration;
            this.environment = environment;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = services.AddControllersWithViews();



            services.AddHttpClient<IEventCatalogService, EventCatalogService>(c =>
                c.BaseAddress = new Uri(config["ApiConfigs:EventCatalog:Uri"]));
            services.AddHttpClient<IShoppingBasketService, ShoppingBasketService>(c =>
                c.BaseAddress = new Uri(config["ApiConfigs:ShoppingBasket:Uri"]));

            services.AddSingleton<Settings>();



            services.AddControllers(setupAction =>
            {

                setupAction.ReturnHttpNotAcceptable = true;
            }).AddNewtonsoftJson(setupAction =>
                {
                    setupAction.SerializerSettings.ContractResolver =
                       new CamelCasePropertyNamesContractResolver();
                })
             .AddXmlDataContractSerializerFormatters()
             .ConfigureApiBehaviorOptions(setupAction =>
             {
                 setupAction.InvalidModelStateResponseFactory = context =>
                 {
                     // create a problem details object
                     var problemDetailsFactory = context.HttpContext.RequestServices
                             .GetRequiredService<ProblemDetailsFactory>();
                     var problemDetails = problemDetailsFactory.CreateValidationProblemDetails(
                             context.HttpContext,
                             context.ModelState);

                     // add additional info not added by default
                     problemDetails.Detail = "See the errors field for details.";
                     problemDetails.Instance = context.HttpContext.Request.Path;

                     // find out which status code to use
                     var actionExecutingContext =
                               context as Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext;

                     // if there are modelstate errors & all arguments were correctly
                     // found/parsed we're dealing with validation errors
                     if (context.ModelState.ErrorCount > 0 &&
                             actionExecutingContext?.ActionArguments.Count == context.ActionDescriptor.Parameters.Count)
                     {
                         problemDetails.Type = "https://Segaetsho.com/modelvalidationproblem";
                         problemDetails.Status = StatusCodes.Status422UnprocessableEntity;
                         problemDetails.Title = "One or more validation errors occurred.";

                         return new UnprocessableEntityObjectResult(problemDetails)
                         {
                             ContentTypes = { "application/problem+json" }
                         };
                     }

                     // if one of the arguments wasn't correctly found / couldn't be parsed
                     // we're dealing with null/unparseable input
                     problemDetails.Status = StatusCodes.Status400BadRequest;
                     problemDetails.Title = "One or more errors on input occurred.";
                     return new BadRequestObjectResult(problemDetails)
                     {
                         ContentTypes = { "application/problem+json" }
                     };
                 };
             });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            services.AddScoped<IUserInfoService, UserInfoService>();

            services.AddCors(options =>
            {
                options.AddPolicy(
                   name: "AllowOrigin",
                   builder =>
                   {
                       builder.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
                   });
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            services.AddScoped<ISegaetshoResourcesRepository, SegaetshoResourcesRepository>();


            services.AddDbContext<SegaetshoResourcesContext>(options =>
            {
                options.UseSqlServer(
                    @"Server=(localdb)\mssqllocaldb;Database=SegaetshoResourcesDB;Trusted_Connection=True;");
            });


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SegaetshoResources.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SegaetshoResources.API v1"));
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected fault happened. Try again later.");
                    });
                });

            }
            app.UseCors("AllowOrigin");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
