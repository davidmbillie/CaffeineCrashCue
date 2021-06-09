using CaffeineCrashProvider.Models;
using System.Collections.Generic;

namespace CaffeineCrashProvider.Sizes
{
    public class SizesSoda : SizesSet
    {
        public override Dictionary<string, double> QuantOnly
        {
            get
            {
                return new Dictionary<string, double>()
                {
                };
            }
        }
        public override string[] Sources
        {
            get
            {
                return new string[] { "Cola", "Diet_Cola", "Mtn_Dew", "Mtn_Dew_High_Caff", "Diet_Mtn_Dew" };
            }
        }

        public static readonly Dictionary<string, Beverage> Cola = new Dictionary<string, Beverage>()
        {
        };

        public static readonly Dictionary<string, Beverage> Diet_Cola = new Dictionary<string, Beverage>()
        {
        };

        public static readonly Dictionary<string, Beverage> Mtn_Dew = new Dictionary<string, Beverage>()
        {
        };

        public static readonly Dictionary<string, Beverage> Mtn_Dew_High_Caff = new Dictionary<string, Beverage>()
        {
        };

        public static readonly Dictionary<string, Beverage> Diet_Mtn_Dew = new Dictionary<string, Beverage>()
        {
        };
    }
}