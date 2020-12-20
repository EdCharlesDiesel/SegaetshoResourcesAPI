using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegaetshoResources.Services.TourManagement.Profiles
{
    public class BookingProfile: Profile
    {
        public BookingProfile()
        {
            CreateMap<Entities.Booking, Models.BookingDto>();
        }
    }
}
