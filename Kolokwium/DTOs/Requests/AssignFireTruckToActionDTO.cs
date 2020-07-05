using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.DTOs.Requests
{
    public class AssignFireTruckToActionDTO
    {
        public int idAction { get; set; }
        public int idFireTruck { get; set; }
    }
}
