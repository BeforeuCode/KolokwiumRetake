using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public class FirefighterAction
    {
        public int IdFireFighter { get; set; }
        public int IdAction { get; set; }

        public virtual Action Action { get; set; }
        public virtual Firefighter Firefighter { get; set; }
    }
}
