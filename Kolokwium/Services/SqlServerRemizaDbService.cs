using Kolokwium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Services
{
    public class SqlServerRemizaDbService : IRemizaDbService
    {
        private readonly RemizaDbContext _dbContext;

        public SqlServerRemizaDbService(RemizaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
