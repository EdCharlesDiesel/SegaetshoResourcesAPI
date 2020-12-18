using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SegaetshoResources.API.Models;
using SegaetshoResources.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegaetshoResources.API.Controllers
{
    [Route("api/bookings")]
    public class BookingsController:ControllerBase
    {
        private readonly IMapper _mapper;
       
        private readonly ISegaetshoResourcesRepository _segaetshoDynastyRepository;
        public BookingsController(ISegaetshoResourcesRepository segaetshoDynastyRepository, IMapper mapper)
        {
            _segaetshoDynastyRepository = segaetshoDynastyRepository ?? throw new ArgumentNullException(nameof(segaetshoDynastyRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetBookings()
        {
            var bookingsFromRepo = await _segaetshoDynastyRepository.GetBookings();

            var bookings = _mapper.Map<IEnumerable<BookingDto>>(bookingsFromRepo);
            return Ok(bookings);
        }


        [HttpGet("{bookingId}", Name = "GetBooking")]
        public async Task<IActionResult> GetBooking(Guid bookingId)
        {
            var bookingFromRepo = await _segaetshoDynastyRepository.GetBooking(bookingId);

            if (bookingFromRepo == null)
            {
                return BadRequest();
            }

            var booking = _mapper.Map<BookingDto>(bookingFromRepo);

            return Ok(booking);
        }
    }
}
