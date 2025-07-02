using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reputy.Api.Controllers.Authentication;
using Reputy.Api.Filters;
using Reputy.Application.Common.Interfaces.Persistance;
using Reputy.Contracts.Advertisement;
using Reputy.Infrastructure.Extensions;

namespace Reputy.Api.Controllers.User
{
    [ApiController]
    [Route("user")]
    [ErrorHandlingFilter]
    [Authorize]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IAdvertisementRepository _advertisementRepository;
        private readonly IMapper _mapper;

        public UserController(ILogger<UserController> logger, IAdvertisementRepository advertisementRepository, IMapper mapper)
        {
            _logger = logger;
            _advertisementRepository = advertisementRepository;
            _mapper = mapper;
        }

        [HttpGet("advertisement")]
        public async Task<IActionResult> GetUserAdvertisementList()
        {
            try
            {
                var userID = User.GetUserId();
                if (userID == Guid.Empty)
                {
                    return BadRequest($"Invalid user ID:{userID}");
                }

                var userAdvertisements = await _advertisementRepository.GetUserAdvertisementsAsync(userID);

                if (userAdvertisements == null)
                {
                    return BadRequest($"Get User adverstisements with ID: {userID} failed");
                }

                var response = _mapper.Map<List<AdvertisementResponse>>(userAdvertisements);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
