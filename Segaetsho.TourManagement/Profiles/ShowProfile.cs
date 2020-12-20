using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegaetshoResources.Services.TourManagement.Profiles
{
    public class ShowProfile: Profile
    {
        public ShowProfile()
        {
            CreateMap<Entities.Show, Models.ShowDto>();
        }
    }
}
