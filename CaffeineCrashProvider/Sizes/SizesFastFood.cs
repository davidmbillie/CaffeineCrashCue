using CaffeineCrashProvider.Models;
using System.Collections.Generic;

namespace CaffeineCrashProvider.Sizes
{
    public class SizesFastFood : SizesSet
    {
        public override Dictionary<string, double> QuantOnly
        {
            get
            {
                return new Dictionary<string, double>()
                {
                    {SizeConstants.EspressoShot, 71.0 }
                };
            }
        }
        public override string[] Sources
        {
            get
            {
                return new string[] { "Regular", "Iced", "Mocha_Latte_Cappuccino_Etc", "Iced_Mocha_Latte_Cappuccino_Etc", "Caramel_Frappe", "Mocha_Frappe" };
            }
        }

        public static readonly Dictionary<string, Beverage> Regular = new Dictionary<string, Beverage>()
        {
            {"Short/Mug", new Beverage(8, 73)},
            {"Small", new Beverage(12, 109)},
            {"Medium", new Beverage(16, 145)},
            {"Large", new Beverage(21, 185)}
        };

        public static readonly Dictionary<string, Beverage> Iced = new Dictionary<string, Beverage>()
        {
            {"Short/Mug", new Beverage(8, 67)},
            {"Small", new Beverage(16, 133)},
            {"Medium", new Beverage(21, 200)},
            {"Large", new Beverage(32, 320)}
        };

        public static readonly Dictionary<string, Beverage> Mocha_Latte_Cappuccino_Etc = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(12, 71)},
            {"Medium", new Beverage(16, 142)},
            {"Large", new Beverage(21, 178)}
        };

        public static readonly Dictionary<string, Beverage> Iced_Mocha_Latte_Cappuccino_Etc = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(12, 71)},
            {"Medium", new Beverage(16, 142)},
            {"Large", new Beverage(22, 178)}
        };

        public static readonly Dictionary<string, Beverage> Caramel_Frappe = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(12, 75)},
            {"Medium", new Beverage(16, 90)},
            {"Large", new Beverage(22, 130)}
        };

        public static readonly Dictionary<string, Beverage> Mocha_Frappe = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(12, 100)},
            {"Medium", new Beverage(16, 125)},
            {"Large", new Beverage(22, 180)}
        };
    }
}
