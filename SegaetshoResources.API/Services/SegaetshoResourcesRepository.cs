﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SegaetshoResources.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace SegaetshoResources.API.Services
{
    public class SegaetshoResourcesRepository : ISegaetshoResourcesRepository
    {
        private SegaetshoResourcesContext _context;

        public SegaetshoResourcesRepository(SegaetshoResourcesContext context)
        {
            _context = context;
        }

        public async Task<bool> TourExists(Guid tourId)
        {
            return await _context.Tours.AnyAsync(t => t.TourId == tourId);
        }

        public async Task<IEnumerable<Tour>> GetTours(bool includeShows = false)
        {
            if (includeShows)
            {
                return await _context.Tours.Include(t => t.Band).Include(t => t.Shows).ToListAsync();
            }
            else
            {
                return await _context.Tours.Include(t => t.Band).ToListAsync();
            }
        }

        public async Task<IEnumerable<Tour>> GetToursForManager(Guid managerId, bool includeShows = false)
        {
            if (includeShows)
            {
                return await _context.Tours.Where(t => t.ManagerId == managerId)
                    .Include(t => t.Band).Include(t => t.Shows).ToListAsync();
            }
            else
            {
                return await _context.Tours.Where(t => t.ManagerId == managerId)
                    .Include(t => t.Band).ToListAsync();
            }
        }

        public async Task<Tour> GetTour(Guid tourId, bool includeShows = false)
        {
            if (includeShows)
            {
                return await _context.Tours.Include(t => t.Band).Include(t => t.Shows)
                    .Where(t => t.TourId == tourId).FirstOrDefaultAsync();
            }
            else
            {
                return await _context.Tours.Include(t => t.Band)
                    .Where(t => t.TourId == tourId).FirstOrDefaultAsync();
            }
        }

        public async Task<bool> IsTourManager(Guid tourId, Guid managerId)
        {
            return await _context.Tours.AnyAsync(t => t.TourId == tourId && t.ManagerId == managerId);
        }

        public async Task AddTour(Tour tour)
        {
            await _context.Tours.AddAsync(tour);
        }

#pragma warning disable 1998
        // disable async warning - no code 
        public async Task UpdateTour(Tour tour)
        {
            // no code in this implementation
        }
#pragma warning restore 1998

#pragma warning disable 1998
        // disable async warning - no RemoveAsync available
        public async Task DeleteTour(Tour tour)
        {
            _context.Tours.Remove(tour);
        }
#pragma warning restore 1998

        public async Task<IEnumerable<Show>> GetShows(Guid tourId)
        {
            return await _context.Shows.Where(s => s.TourId == tourId).ToListAsync();
        }

        public async Task<IEnumerable<Show>> GetShows(Guid tourId, IEnumerable<Guid> showIds)
        {
           return await _context.Shows
                .Where(s => s.TourId == tourId && showIds.Contains(s.ShowId)).ToListAsync();
        }


        public async Task AddShow(Guid tourId, Show show)
        {
            var tour = await GetTour(tourId);
            if (tour == null)
            {
                // throw an exception - this is a race condition
                // that's mostly caught by checking if the tour exists
                // right before calling into this method - if that method is not
                // called the condition can happen, otherwise the tour
                // will already be loaded on the context
                throw new Exception($"Cannot add show to tour with id {tourId}: tour not found.");
            }
            tour.Shows.Add(show);
        }

        public async Task<IEnumerable<Band>> GetBands()
        {
            return await _context.Bands.ToListAsync();
        }

        public async Task<IEnumerable<Manager>> GetManagers()
        {
            return await _context.Managers.ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public async Task AddBooking(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
        }

#pragma warning disable 1998
        public async  Task DeleteBooking(Booking booking)
        {
             _context.Bookings.Remove(booking);
        }

#pragma warning restore 1998


        public async  Task<Booking> GetBooking(Guid bookingId, bool includeShows = false)
        {
            return await _context.Bookings.FirstAsync(t => t.Id == bookingId);           
        }

        public async Task<IEnumerable<Booking>> GetBookings(bool includeShows = false)
        {
        
                return await _context.Bookings.ToListAsync();            
        }

        public Task<IEnumerable<Tour>> GetBookingsForManager(Guid managerId, bool includeShows = false)
        {
            throw new NotImplementedException();
        }
    }
}
