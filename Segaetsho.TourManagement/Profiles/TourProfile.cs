using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegaetshoResources.Services.TourManagement.Models
{
    public class TourProfile: Profile
    {
        public TourProfile()
        {
            CreateMap<Entities.Tour, Models.TourDto>()
                    .ForMember(d => d.Band, o => o.MapFrom(s => s.Band.Name));
        }
    }
}
