using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SegaetshoResources.API.Entities;

namespace SegaetshoResources.API.Services
{
    public interface ISegaetshoResourcesRepository
    {
        Task AddTour(Tour tour);
        Task DeleteTour(Tour tour);
        Task<Tour> GetTour(Guid tourId, bool includeShows = false);
        Task<IEnumerable<Tour>> GetTours(bool includeShows = false);
        Task<IEnumerable<Tour>> GetToursForManager(Guid managerId, bool includeShows = false);
        Task<bool> IsTourManager(Guid tourId, Guid managerId);
        Task<bool> SaveAsync();
        Task<bool> TourExists(Guid tourId);
        Task UpdateTour(Tour tour);
        Task<IEnumerable<Show>> GetShows(Guid tourId);
        Task<IEnumerable<Show>> GetShows(Guid tourId, IEnumerable<Guid> showIds);
        Task AddShow(Guid tourId, Show show);
        Task<IEnumerable<Band>> GetBands();
        Task<IEnumerable<Manager>> GetManagers();




       
        Task AddBooking(Booking booking);
        Task DeleteBooking(Booking booking);
        Task<Booking> GetBooking(Guid bookingId, bool includeShows = false);
        Task<IEnumerable<Booking>> GetBookings(bool includeShows = false);
        Task<IEnumerable<Tour>> GetBookingsForManager(Guid managerId, bool includeShows = false);
    }
}