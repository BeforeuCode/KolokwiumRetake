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
    public class ActionController
    {
        private readonly IRemizaDbService _dbService;

        public ActionController(IRemizaDbService dbService)
        {
            _dbService = dbService;
        }

    }
}
