using System;
using Microsoft.AspNetCore.Http;
using Segaetsho.API.Controllers.Web.Models;

namespace SegaetshoResources.API.Extensions
{
    public static  class RequestCookieCollection
    {
        public static Guid GetCurrentBasketId(this IRequestCookieCollection cookies, Settings settings)
        {
            Guid.TryParse(cookies[settings.BasketIdCookieName], out Guid basketId);
            return basketId;
        }
    }
}
