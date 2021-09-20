using CaffeineCrashProvider.Models;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace CaffeineCrashProvider.Sizes
{
    public class SizesCoffeehouse : SizesSet
    {
        //https://globalassets.starbucks.com/assets/94fbcc2ab1e24359850fa1870fc988bc.pdf

        public override Dictionary<string, double> QuantOnly
        {
            get
			{
                return new Dictionary<string, double>()
                {
                    {SizeConstants.EspressoShot, 75.0 }
                };
			}
		}

        public override string[] Sources
        {
            get
            {
                return new string[] { "Dark", "Medium", "Light", "Iced", "Cold_Brew", "Mocha_Latte_Cappuccino_Etc", "Iced_Mocha_Latte_Cappuccino_Etc",
                "Chai_Tea", "Iced_Chai_Tea", "Green_Tea_Latte", "Coffee_Frappucino", "Espresso_Frappucino", "Frappucino_Lite", "Green_Tea_Frappucino"};
            }
        }

        public static readonly Dictionary<string, Beverage> Dark = new Dictionary<string, Beverage>()
        {
            {"Short", new Beverage(8, 130)},
            {"Small", new Beverage(12, 193)},
            {"Medium", new Beverage(16, 260)},
            {"Large", new Beverage(24, 340) }
        };

        public static readonly Dictionary<string, Beverage> Medium = new Dictionary<string, Beverage>()
        {
            {"Short", new Beverage(8, 155)},
            {"Small", new Beverage(12, 235)},
            {"Medium", new Beverage(16, 310)},
            {"Large", new Beverage(24, 410) }
        };

        public static readonly Dictionary<string, Beverage> Light = new Dictionary<string, Beverage>()
        {
            {"Short", new Beverage(8, 180)},
            {"Small", new Beverage(12, 270)},
            {"Medium", new Beverage(16, 360)},
            {"Large", new Beverage(24, 475) }
        };

        public static readonly Dictionary<string, Beverage> Iced = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(12, 120)},
            {"Medium", new Beverage(16, 165)},
            {"Large", new Beverage(24, 235)},
            {"Extra_Large", new Beverage(31, 280) }
        };

        public static readonly Dictionary<string, Beverage> Cold_Brew = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(12, 150)},
            {"Medium", new Beverage(16, 200)},
            {"Large", new Beverage(24, 300)},
            {"Extra_Large", new Beverage(31, 330) }
        };

        public static readonly Dictionary<string, Beverage> Mocha_Latte_Cappuccino_Etc = new Dictionary<string, Beverage>()
        {
            {"Short", new Beverage(8, 75)},
            {"Small", new Beverage(12, 75)},
            {"Medium", new Beverage(16, 150)},
            {"Large", new Beverage(24, 150) }
        };

        public static readonly Dictionary<string, Beverage> Iced_Mocha_Latte_Cappuccino_Etc = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(12, 75)},
            {"Medium", new Beverage(16, 150)},
            {"Large", new Beverage(24, 225) }
        };

        public static readonly Dictionary<string, Beverage> Chai_Tea = new Dictionary<string, Beverage>()
        {
            {"Short", new Beverage(8, 50)},
            {"Small", new Beverage(12, 70)},
            {"Medium", new Beverage(16, 95)},
            {"Large", new Beverage(24, 120) }
        };

        public static readonly Dictionary<string, Beverage> Iced_Chai_Tea = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(8, 70)},
            {"Medium", new Beverage(12, 95)},
            {"Large", new Beverage(16, 145)}
        };

        //works for both hot and iced
        public static readonly Dictionary<string, Beverage> Green_Tea_Latte = new Dictionary<string, Beverage>()
        {
            {"Short", new Beverage(8, 30)},
            {"Small", new Beverage(12, 55)},
            {"Medium", new Beverage(16, 80)},
            {"Large", new Beverage(24, 110) }
        };

        public static readonly Dictionary<string, Beverage> Coffee_Frappucino = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(8, 70)},
            {"Medium", new Beverage(12, 100)},
            {"Large", new Beverage(16, 130)}
        };

        public static readonly Dictionary<string, Beverage> Espresso_Frappucino = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(8, 130)},
            {"Medium", new Beverage(12, 165)},
            {"Large", new Beverage(16, 185)}
        };

        public static readonly Dictionary<string, Beverage> Frappucino_Lite = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(8, 70)},
            {"Medium", new Beverage(12, 95)},
            {"Large", new Beverage(16, 120)}
        };

        public static readonly Dictionary<string, Beverage> Green_Tea_Frappucino = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(8, 50)},
            {"Medium", new Beverage(12, 70)},
            {"Large", new Beverage(16, 95)}
        };
    }
}