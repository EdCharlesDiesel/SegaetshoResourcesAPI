using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using SegaetshoResources.API.Models;
using System.Threading.Tasks;

namespace SegaetshoResources.API.Profiles
{
    public class BandProfile:Profile
    {
        public BandProfile()
        {
            CreateMap<Entities.Band, Models.BandDto>();

        }
    }
}
