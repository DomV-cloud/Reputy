using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reputy.Api.Filters;
using Reputy.Application.Common.Interfaces.Persistance;
using Reputy.Application.PaginationFilter;
using Reputy.Contracts.Advertisement;

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

                var response = _mapper.Map<List<AdvertisementResponse>>(advertisements.Data);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
