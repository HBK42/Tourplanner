using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourplanner.Model
{
    internal class Tour
    {
        //public int Id { get; set; } // Consider using a unique identifier
        //public string Name { get; set; }
        //public string Description { get; set; }
        //public string From { get; set; }
        //public string To { get; set; }
        //public string TransportType { get; set; }
        //public double Distance { get; set; }
        //public TimeSpan EstimatedTime { get; set; }
        //public byte[] RouteMapImage { get; set; } // Byte array for storing image data
        public string Name { get; set; } = "";
        public DateTime DueDate { get; set; }
        public bool IsComplete { get; set; }
    }
}
