using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public class Firefighter
    {
        public int IdFirefighter { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }

        public virtual ICollection<FirefighterAction> FirefighterActions { get; set; }
    }
}
