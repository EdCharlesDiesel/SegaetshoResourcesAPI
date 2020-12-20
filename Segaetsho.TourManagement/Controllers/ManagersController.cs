using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SegaetshoResources.Services.TourManagement.Services.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SegaetshoResources.Services.Controllers
{
    [Route("api/managers")]
    public class ManagersController : ControllerBase
    {
        private readonly ISegaetshoResourcesRepository _segaetshoDynastyRepository;
        private readonly IMapper _mapper;

        public ManagersController(ISegaetshoResourcesRepository segaetshoDynastyRepository, IMapper mapper)
        {
            _segaetshoDynastyRepository = segaetshoDynastyRepository ?? throw new ArgumentNullException(nameof(segaetshoDynastyRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetManagers()
        {
            var managersFromRepo = await _segaetshoDynastyRepository.GetManagers();

            var managers = _mapper.Map<IEnumerable<ManagerDto>>(managersFromRepo);

            return Ok(managers);
        }
    }
}