using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public class FireTruck
    {
        public int IdFireTruck { get; set; }
        public String OperationalNumber { get; set; }
        public bool SpecialEquipement { get; set; }

        public virtual ICollection<FireTruckAction> FireTruckActions { get; set; }
    }
}

