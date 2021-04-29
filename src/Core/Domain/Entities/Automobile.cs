using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Domain.Entities
{
    public class Automobile
    {
        public string AutomobileId { get; set; }
        public string ClientId { get; set; }
        public string CarExpertId { get; set; }
        public string PlateNumber { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
    }
}
