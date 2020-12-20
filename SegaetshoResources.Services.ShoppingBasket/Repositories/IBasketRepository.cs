
using SegaetshoResources.Services.ShoppingBasket.Entities;
using System;
using System.Threading.Tasks;

namespace SegaetshoResources.Services.ShoppingBasket.Repositories
{
    public interface IBasketRepository
    {
        Task<bool> BasketExists(Guid basketId);

        Task<Basket> GetBasketById(Guid basketId);

        void AddBasket(Basket basket);

        Task<bool> SaveChanges();
    }
}