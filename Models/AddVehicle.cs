using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationNefc.Models
{
    public class AddVehicle
    {
        public int RegNo { get; set; }
        public string ModelName { get; set; }
        public int NumberOfSeats { get; set; }
        public string Colors { get; set; }
    }
}
