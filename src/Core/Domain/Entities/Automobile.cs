using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Domain.Entities
{
    public class Automobile
    {
        public int AutomobileId { get; set; }
        public int ClientId { get; set; }
        public int CarExpertId { get; set; }
        public string PlateNumber { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
    }
}
