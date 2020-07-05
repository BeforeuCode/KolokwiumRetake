using Kolokwium.Models;
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

        public Action GetAction(int IdAction)
        {
            return _dbContext.Actions
                 .Where(a => a.IdAction == IdAction)
                 .FirstOrDefault();
        }

        public Firefighter GetFirefighter(int IdFirefighter)
        {
            return _dbContext.FireFigthers
                  .Where(f => f.IdFirefighter == IdFirefighter)
                  .FirstOrDefault();
        }

        public IEnumerable<FirefighterAction> GetfireFighterActions(int IdFirefighter)
        {
            return _dbContext.FirefighterActions
              .Where(ffa => ffa.IdFireFighter == IdFirefighter)
              .OrderByDescending(cp => cp.Action.EndTime)
              .Select(ffa => ffa);
        }

        public FireTruck GetFireTruck(int IdFireTruck)
        {
            return _dbContext.FireTrucks
                  .Where(ft => ft.IdFireTruck == IdFireTruck)
                  .FirstOrDefault();
        }
    }
}
