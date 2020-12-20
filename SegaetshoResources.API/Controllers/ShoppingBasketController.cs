using System;
using System.Linq;
using System.Threading.Tasks;
using Segaetsho.API.Controllers.Messages;
using Segaetsho.API.Controllers.Web.Extensions;
using Segaetsho.API.Controllers.Web.Models.View;
using Microsoft.AspNetCore.Mvc;
using Rebus.Bus;
using Segaetsho.API.Controllers.Web.Models;
using Segaetsho.API.Controllers.Web.Models.Api;
using Segaetsho.API.Controllers.Web.Services;

namespace SegaetshoResources.API.Controllers
{
    public class ShoppingBasketController : Controller
    {
        private readonly IShoppingBasketService basketService;
        private readonly IBus bus;
        private readonly Settings settings;

        public ShoppingBasketController(IShoppingBasketService basketService, IBus bus, Settings settings)
        {
            this.basketService = basketService;
            this.bus = bus;
            this.settings = settings;
        }

        public async Task<IActionResult> Index()
        {
            var basketLines = await basketService.GetLinesForBasket(Request.Cookies.GetCurrentBasketId(settings));
            var lineViewModels = basketLines.Select(bl => new BasketLineViewModel
            {
                LineId = bl.BasketLineId,
                EventId = bl.EventId,
                EventName = bl.Event.Name,
                Date = bl.Event.Date,
                Price = bl.Price,
                Quantity = bl.TicketAmount
            }
            );
            return View(lineViewModels);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddLine(BasketLineForCreation basketLine)
        {
            var basketId = Request.Cookies.GetCurrentBasketId(settings);
            var newLine = await basketService.AddToBasket(basketId, basketLine);
            Response.Cookies.Append(settings.BasketIdCookieName, newLine.BasketId.ToString());

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateLine(BasketLineForUpdate basketLineUpdate)
        {
            var basketId = Request.Cookies.GetCurrentBasketId(settings);
            await basketService.UpdateLine(basketId, basketLineUpdate);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveLine(Guid lineId)
        {
            var basketId = Request.Cookies.GetCurrentBasketId(settings);
            await basketService.RemoveLine(basketId, lineId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Pay()
        {
            var basketId = Request.Cookies.GetCurrentBasketId(settings);
            await bus.Send(new PaymentRequestMessage { BasketId = basketId });
            return View("Thanks");
        }
    }
}
