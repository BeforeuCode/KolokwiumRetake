using Kolokwium.DTOs.Requests;
using Kolokwium.Models;
using Kolokwium.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Kolokwium.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionController : ControllerBase
    {
        private readonly IRemizaDbService _dbService;

        public ActionController(IRemizaDbService dbService)
        {
            _dbService = dbService;
        }

        // [HttpPost("{id}/fire-trucks")]  <--- i tak mamy w dto id
        [HttpPost("fire-trucks")]
        public IActionResult AssignTruckToAction(AssignFireTruckToActionDTO assignFireTruckToActionDTO)
        {
     
            var action = _dbService.GetfireFighterActions(assignFireTruckToActionDTO.idAction);
            if (action == null)
            {
                return NotFound("Action dosen't exists");
            }

            var firetruck = _dbService.GetFireTruck(assignFireTruckToActionDTO.idAction);
            if (firetruck == null)
            {
                return NotFound("FireTruck dosen't exists");
            }

            if((firetruck as FireTruck).FireTruckActions.Count > 0)
            {
                return BadRequest("FireTruck arealdy in action exists");

            }
            if((action as Action).NeedForSpecialEquipment == true && firetruck.SpecialEquipement == false)
            {
                return BadRequest("FireTruck does not have special equipement");
            }


            return Ok("Added Truck with Id:" + assignFireTruckToActionDTO.idFireTruck + "to action:" + assignFireTruckToActionDTO.idAction);
          

        }

    }
}
