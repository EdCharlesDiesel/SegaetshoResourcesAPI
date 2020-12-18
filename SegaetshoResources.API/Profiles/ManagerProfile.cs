using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegaetshoResources.API.Profiles
{
    public class ManagerProfile:Profile
    {
        public ManagerProfile()
        {
            CreateMap<Entities.Manager, Models.ManagerDto>();
        }
    }
}
