using Kolokwium.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirefighterController
    {
        private readonly IRemizaDbService _dbService;

        public FirefighterController(IRemizaDbService dbService)
        {
            _dbService = dbService;
        }

    }
}
