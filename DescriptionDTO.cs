using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{
    public  class DescriptionDTO
    {
        public int GroundwaterLevel { get; set; }
        public string SoilType { get; set; }
        public List<(double, double)> GeodeticReference { get; set; }

    }
}
