using Kolokwium.Models;
using System.Collections.Generic;

namespace Kolokwium.Services
{
   public interface IRemizaDbService
    {
        public Firefighter GetFirefighter(int IdFirefighter);

        public FireTruck GetFireTruck(int IdFireTruck);

        public Action GetAction(int IdAction);
        public IEnumerable<FirefighterAction> GetfireFighterActions(int IdFirefighter);
    }
}
