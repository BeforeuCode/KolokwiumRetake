using Kolokwium.DTOs.Responses;
using Kolokwium.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Kolokwium.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirefighterController : ControllerBase
    {
        private readonly IRemizaDbService _dbService;

        public FirefighterController(IRemizaDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("{id}/actions")]
        public IActionResult GetFirefighterActions(int id)
        {
            if (_dbService.GetFirefighter(id) == null)
                return NotFound("Firefighter dosen't exists");

            var firefighterActions = _dbService.GetfireFighterActions(id);

            return Ok(firefighterActions.Select(ct => new FirefighterActionsResposne
            {
                IdAction = ct.IdAction,
                StartTime = ct.Action.StartTime,
                EndTime = ct.Action.EndTime
            }).ToList());

        }

    }
}
