using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace SegaetshoResources.Services.TourManagement.Profiles
{
    public class BandProfile:Profile
    {
        public BandProfile()
        {
            CreateMap<Entities.Band, Models.BandDto>();

        }
    }
}
