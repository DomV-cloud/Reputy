using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reputy.Api.Filters;
using Reputy.Application.Common.Interfaces.Persistance;
using Reputy.Application.Pagination;
using Reputy.Application.PaginationFilter;
using Reputy.Contracts.Advertisement;
using Reputy.Contracts.Filter;

namespace Reputy.Api.Controllers.Advertisement
{
    [ApiController]
    [Route("advertisement")]
    [ErrorHandlingFilter]
    [Authorize]
    public class AdvertisementController : Controller
    {
        private readonly IAdvertisementRepository _advertisementRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AdvertisementController> _logger;

        public AdvertisementController(IAdvertisementRepository advertisementRepository, IMapper mapper, ILogger<AdvertisementController> logger)
        {
            _advertisementRepository = advertisementRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAdvertisements()
        {
            try
            {
                var allAdvertisement = await _advertisementRepository.GetAllAdvertisementsAsync();
                if (allAdvertisement == null)
                {
                    return NotFound("No advertisements found.");
                }

                var response = _mapper.Map<List<AdvertisementResponse>>(allAdvertisement);
               
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetSearchedAdvertisements([FromQuery] AdvertisementFilter filter)
        {
            try
            {
                if (filter == null)
                {
                    return BadRequest("Filter cannot be null");
                }

                var advertisements = await _advertisementRepository.GetAdvertisementsByFilter(filter);
                if (advertisements == null)
                {
                    return NotFound("No advertisements found matching the filter criteria.");
                }

                var response = _mapper.Map<PagedResponse<List<AdvertisementResponse>>>(advertisements);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetSearchedAdvertisementsFilters()
        {
            try
            {
                var cities = await _advertisementRepository.GetAllCities();

                if (cities == null || cities.Count == 0)
                {
                    throw new Exception("Failed to get locations");
                }

                var dispositions = await _advertisementRepository.GetAllDispositions();

                if (dispositions == null || dispositions.Count == 0)
                {
                    throw new Exception("Failed to get dispositions");
                }

                int maxPrice = await _advertisementRepository.GetMaxPrices();
                int minPrice = await _advertisementRepository.GetMinPrices();

                var response = new FilterResponse(cities, dispositions, minPrice, maxPrice);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
