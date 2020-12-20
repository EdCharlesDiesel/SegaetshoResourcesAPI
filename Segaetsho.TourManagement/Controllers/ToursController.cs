using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SegaetshoResources.Services.TourManagement.Services.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SegaetshoResources.Services.Controllers
{
    [Route("api/tours")]
    public class ToursController : ControllerBase
    {
        private readonly ISegaetshoResourcesRepository _segaetshoDynastyRepository;
        private readonly IMapper _mapper;

        public ToursController(ISegaetshoResourcesRepository segaetshoDynastyRepository, IMapper mapper)
        {
            _segaetshoDynastyRepository = segaetshoDynastyRepository ?? throw new ArgumentNullException(nameof(segaetshoDynastyRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetTours()
        {
            var toursFromRepo = await _segaetshoDynastyRepository.GetTours();

            var tours = _mapper.Map<IEnumerable<TourDto>>(toursFromRepo);
            return Ok(tours);
        }

        [HttpGet("{tourId}", Name = "GetTour")]
        public async Task<IActionResult> GetTour(Guid tourId)
        {
            var tourFromRepo = await _segaetshoDynastyRepository.GetTour(tourId);

            if (tourFromRepo == null)
            {
                return BadRequest();
            }

            var tour = _mapper.Map<TourDto>(tourFromRepo);

            return Ok(tour);
        }
    }
}