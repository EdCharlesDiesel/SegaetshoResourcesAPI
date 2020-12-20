using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SegaetshoResources.Services.Controllers
{
    [Route("api/tours/{tourId}/shows")]
    public class ShowsController : ControllerBase
    {
        private readonly ISegaetshoResourcesRepository _segaetshoDynastyRepository;
        private readonly IMapper _mapper;

        public ShowsController(ISegaetshoResourcesRepository segaetshoDynastyRepository, IMapper mapper)
        {
            _segaetshoDynastyRepository = segaetshoDynastyRepository ?? throw new ArgumentNullException(nameof(segaetshoDynastyRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetShows(Guid tourId)
        {
            var tourFromRepo = await _segaetshoDynastyRepository.GetTour(tourId, true);

            if (!(await _segaetshoDynastyRepository.TourExists(tourId)))
            {
                return NotFound();
            }

            var showsFromRepo = await _segaetshoDynastyRepository.GetShows(tourId);

            var shows = _mapper.Map<IEnumerable<ShowDto>>(showsFromRepo);
            return Ok(shows);
        }
    }
}