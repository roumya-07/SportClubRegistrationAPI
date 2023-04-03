using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportClubRegistrationAPI.Models;
using SportClubRegistrationAPI.Services;

namespace SportClubRegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportsClubAPIController : ControllerBase
    {
        private readonly ISportClubServices _sportClubServices;
        public SportsClubAPIController(ISportClubServices sportClubServices)
        {
            _sportClubServices = sportClubServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<SportsClubEntity>>> View()
        {
            return await _sportClubServices.View();
        }

        [HttpGet("{registration_id}")]
        public async Task<ActionResult<SportsClubEntity>> ViewOne(int registration_id)
        {
            return await _sportClubServices.ViewOne(registration_id);
        }
        [HttpPut("{registration_id}")]
        public async Task<ActionResult<SportsClubEntity>> InsertOrUpdate(int registration_id, SportsClubEntity CE)
        {
            if (registration_id != CE.registration_id)
            {
                return BadRequest();
            }
            try
            {
                await _sportClubServices.InsertOrUpdate(CE);

                return CreatedAtAction("View", new { id = CE.registration_id }, CE);
            }

            catch (Exception ex)
            {
                if (ViewOne(registration_id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
