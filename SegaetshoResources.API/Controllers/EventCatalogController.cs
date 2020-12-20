using System;
using System.Threading.Tasks;
using Segaetsho.API.Controllers.Web.Extensions;
using Segaetsho.API.Controllers.Web.Models.View;
using Microsoft.AspNetCore.Mvc;
using Segaetsho.API.Controllers.Web.Models;
using Segaetsho.API.Controllers.Web.Models.Api;
using Segaetsho.API.Controllers.Web.Services;

namespace SegaetshoResources.API.Controllers
{
    public class EventCatalogController : Controller
    {
        private readonly IEventCatalogService eventCatalogService;
        private readonly IShoppingBasketService shoppingBasketService;
        private readonly Settings settings;

        public EventCatalogController(IEventCatalogService eventCatalogService, IShoppingBasketService shoppingBasketService, Settings settings)
        {
            this.eventCatalogService = eventCatalogService;
            this.shoppingBasketService = shoppingBasketService;
            this.settings = settings;
        }

        public async Task<IActionResult> Index(Guid categoryId)
        {
            var currentBasketId = Request.Cookies.GetCurrentBasketId(settings);

            var getBasket = currentBasketId == Guid.Empty ? Task.FromResult<Basket>(null) :
                shoppingBasketService.GetBasket(currentBasketId);
            var getCategories = eventCatalogService.GetCategories();
            var getEvents = categoryId == Guid.Empty ? eventCatalogService.GetAll() :
                eventCatalogService.GetByCategoryId(categoryId);
            await Task.WhenAll(new Task[] { getBasket, getCategories, getEvents });

            var numberOfItems = getBasket.Result == null ? 0 : getBasket.Result.NumberOfItems;

            return View(
                new EventListModel
                {
                    Events = getEvents.Result,
                    Categories = getCategories.Result,
                    NumberOfItems = numberOfItems,
                    SelectedCategory = categoryId
                }
            );
        }

        [HttpPost]
        public IActionResult SelectCategory([FromForm]Guid selectedCategory)
        {
            return RedirectToAction("Index", new { categoryId = selectedCategory });
        }

        public async Task<IActionResult> Detail(Guid eventId)
        {
            var ev = await eventCatalogService.GetEvent(eventId);
            return View(ev);
        }
    }
}
