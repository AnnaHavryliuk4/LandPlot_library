using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{
    public class Description : ICloneable, IComparable<Description>
    {
        public int GroundwaterLevel { get; set; }
        public string SoilType { get; set; }
        public List<(double, double)> GeodeticReference { get; set; }

        public Description(int groundwaterLevel, string soilType, List<(double, double)> geodeticReference)
        {
            GroundwaterLevel = groundwaterLevel;
            SoilType = soilType;
            GeodeticReference = geodeticReference;
        }

        public Description() { }

        public object Clone()
        {
            return new Description(GroundwaterLevel, SoilType, new List<(double, double)>(GeodeticReference));
        }

        public int CompareTo(Description other)
        {
            return GroundwaterLevel.CompareTo(other.GroundwaterLevel);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Description other = (Description)obj;
            return GroundwaterLevel == other.GroundwaterLevel && SoilType == other.SoilType && Equals(GeodeticReference, other.GeodeticReference);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(GroundwaterLevel, SoilType, GeodeticReference);
        }

        public override string ToString()
        {
            return $"Soil type: {SoilType}, Groundwater level: {GroundwaterLevel}m, Geodetic references: {string.Join(", ", GeodeticReference)}";
        }
    }

}
