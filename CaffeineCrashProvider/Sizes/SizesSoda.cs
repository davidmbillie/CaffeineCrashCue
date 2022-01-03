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
                return new string[] { "Cola", "Diet_Cola", "Mtn_Dew", "Mtn_Dew_High_Caffeine", "Diet_Mtn_Dew" };
            }
        }

        public static readonly Dictionary<string, Beverage> Cola = new Dictionary<string, Beverage>()
        {
            { "Can/Small", new Beverage(12, 3.17)},
            { "Small", new Beverage(16, 3.17)},
            { "Bottle/Medium", new Beverage(20, 3.17)},
            { "Medium/Large", new Beverage(30, 3.17)},
            { "Large/X-Large", new Beverage(40, 3.17)},
            { "X-Large", new Beverage(44, 3.17)}

        };

        public static readonly Dictionary<string, Beverage> Diet_Cola = new Dictionary<string, Beverage>()
        {
            { "Can/Small", new Beverage(12, 3.0)},
            { "Small", new Beverage(16, 3.0)},
            { "Bottle/Medium", new Beverage(20, 3.0)},
            { "Medium/Large", new Beverage(30, 3.0)},
            { "Large/X-Large", new Beverage(40, 3.0)},
            { "X-Large", new Beverage(44, 3.0)}
        };

        public static readonly Dictionary<string, Beverage> Mtn_Dew = new Dictionary<string, Beverage>()
        {
            { "Can/Small", new Beverage(12, 4.5)},
            { "Small", new Beverage(16, 4.5)},
            { "Bottle/Medium", new Beverage(20, 4.5)},
            { "Medium/Large", new Beverage(30, 4.5)},
            { "Large/X-Large", new Beverage(40, 4.5)},
            { "X-Large", new Beverage(44, 4.5)}
        };

        public static readonly Dictionary<string, Beverage> Mtn_Dew_High_Caffeine = new Dictionary<string, Beverage>()
        {
            { "Can/Small", new Beverage(12, 5.62)},
            { "Small", new Beverage(16, 5.62)},
            { "Bottle/Medium", new Beverage(20, 5.62)},
            { "Medium/Large", new Beverage(30, 5.62)},
            { "Large/X-Large", new Beverage(40, 5.62)},
            { "X-Large", new Beverage(44, 5.62)}
        };
    }
}