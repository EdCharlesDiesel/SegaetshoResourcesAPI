using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegaetshoResources.API.Profiles
{
    public class TourProfile: Profile
    {
        public TourProfile()
        {
            CreateMap<Entities.Tour, Dtos.TourDto>()
                    .ForMember(d => d.Band, o => o.MapFrom(s => s.Band.Name));
        }
    }
}
