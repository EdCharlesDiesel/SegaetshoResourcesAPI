﻿using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SegaetshoResources.Services.ShoppingBasket.DbContexts;
using SegaetshoResources.Services.ShoppingBasket.Entities;

namespace SegaetshoResources.Services.ShoppingBasket.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly ShoppingBasketDbContext _shoppingBasketDbContext;

        public EventRepository(ShoppingBasketDbContext shoppingBasketDbContext)
        {
            _shoppingBasketDbContext = shoppingBasketDbContext;
        }

        public async Task<bool> EventExists(Guid eventId)
        {
            return await _shoppingBasketDbContext.Events.AnyAsync(e => e.EventId == eventId);
        }

        public void AddEvent(Event theEvent)
        {
            _shoppingBasketDbContext.Events.Add(theEvent);

        }

        public async Task<bool> SaveChanges()
        {
            return (await _shoppingBasketDbContext.SaveChangesAsync() > 0);
        }
    }
}
