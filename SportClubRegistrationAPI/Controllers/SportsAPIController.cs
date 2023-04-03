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
    public class SportsAPIController : ControllerBase
    {
        private readonly ISportClubServices _sportClubServices;
        public SportsAPIController(ISportClubServices sportClubServices)
        {
            _sportClubServices = sportClubServices;
        }
        [HttpGet("{club_id}")]
        public async Task<ActionResult<List<SportsClubEntity>>> GetSports(int club_id)
        {
            return await _sportClubServices.GetSports(club_id);
        }
    }
}
