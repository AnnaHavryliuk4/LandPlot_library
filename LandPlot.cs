using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{
    public class LandPlot : ICloneable, IComparable<LandPlot>
    {
        public Owner Owner { get; set; }
        public Description Description { get; set; }
        public Purpose Purpose { get; set; }
        public double MarketValue { get; set; }

        public LandPlot() { }

        public LandPlot(Owner owner, Description description, Purpose purpose, double marketValue)
        {
            Owner = owner;
            Description = description;
            Purpose = purpose;
            MarketValue = marketValue;
        }

        public object Clone()
        {
            return new LandPlot((Owner)Owner.Clone(), (Description)Description.Clone(), Purpose, MarketValue);
        }

        public int CompareTo(LandPlot other)
        {
            return MarketValue.CompareTo(other.MarketValue);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            LandPlot other = (LandPlot)obj;
            return Owner.Equals(other.Owner) && Description.Equals(other.Description) && Purpose == other.Purpose && MarketValue == other.MarketValue;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Owner, Description, Purpose, MarketValue);
        }

        public override string ToString()
        {
            return $"Owner: {Owner.ToString()}, Purpose: {Purpose}, Market Value: {MarketValue} USD";
        }

        public string GetShortInfo()
        {
            return $"Owner's Last Name: {Owner.LastName}, Market Value: {MarketValue} USD";
        }
    }
}
