using CaffeineCrashProvider.Models;
using System.Collections.Generic;

namespace CaffeineCrashProvider.Sizes
{
    /// <summary>
    /// WIP - might implement in the future
    /// </summary>
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
            { "Can/12_oz", new Beverage(12, 3.17)},
            { "16 oz", new Beverage(16, 3.17)},
            { "Bottle/20_oz", new Beverage(20, 3.17)},
            { "30_oz", new Beverage(30, 3.17)},
            { "40_oz", new Beverage(40, 3.17)},
            { "44_oz", new Beverage(44, 3.17)}

        };

        public static readonly Dictionary<string, Beverage> Diet_Cola = new Dictionary<string, Beverage>()
        {
            { "Can/12_oz", new Beverage(12, 3.0)},
            { "16 oz", new Beverage(16, 3.0)},
            { "Bottle/20_oz", new Beverage(20, 3.0)},
            { "30_oz", new Beverage(30, 3.0)},
            { "40_oz", new Beverage(40, 3.0)},
            { "44_oz", new Beverage(44, 3.0)}
        };

        public static readonly Dictionary<string, Beverage> Mtn_Dew = new Dictionary<string, Beverage>()
        {
            { "Can/12_oz", new Beverage(12, 4.5)},
            { "16 oz", new Beverage(16, 4.5)},
            { "Bottle/20_oz", new Beverage(20, 4.5)},
            { "30_oz", new Beverage(30, 4.5)},
            { "40_oz", new Beverage(40, 4.5)},
            { "44_oz", new Beverage(44, 4.5)}
        };

        public static readonly Dictionary<string, Beverage> Mtn_Dew_High_Caff = new Dictionary<string, Beverage>()
        {
            { "Can/12_oz", new Beverage(12, 5.62)},
            { "16 oz", new Beverage(16, 5.62)},
            { "Bottle/20_oz", new Beverage(20, 5.62)},
            { "30_oz", new Beverage(30, 5.62)},
            { "40_oz", new Beverage(40, 5.62)},
            { "44_oz", new Beverage(44, 5.62)}
        };
    }
}