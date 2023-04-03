using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportClubRegistrationAPI.Models;
using SportClubRegistrationAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubRegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubAPIController : ControllerBase
    {
        private readonly ISportClubServices _sportClubServices;
        public ClubAPIController(ISportClubServices sportClubServices)
        {
            _sportClubServices = sportClubServices;
        }
        [HttpGet]
        public async Task<ActionResult<List<SportsClubEntity>>> GetClub()
        {
            return await _sportClubServices.GetClub();
        }
    }
}
