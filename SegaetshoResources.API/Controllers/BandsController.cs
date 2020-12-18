using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using SegaetshoResources.API.Models;
using SegaetshoResources.API.Services;
using System;

namespace SegaetshoResources.API.Controllers
{
    [Route("api/bands")]
    public class BandsController : ControllerBase
    {
        private readonly ISegaetshoResourcesRepository _segaetshoDynastyRepository;
        private readonly IMapper _mapper;

        public BandsController(ISegaetshoResourcesRepository segaetshoDynastyRepository, IMapper mapper)
        {
            _segaetshoDynastyRepository = segaetshoDynastyRepository ?? throw new ArgumentNullException(nameof(segaetshoDynastyRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetBands()
        {
            var bandsFromRepo = await _segaetshoDynastyRepository.GetBands();

            var bands = _mapper.Map<IEnumerable<BandDto>>(bandsFromRepo);

            return Ok(bands);
        }
    }
}
