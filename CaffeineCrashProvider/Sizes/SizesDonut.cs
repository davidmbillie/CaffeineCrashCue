using CaffeineCrashProvider.Models;
using System.Collections.Generic;

namespace CaffeineCrashProvider.Sizes
{
    public class SizesDonut : SizesSet
    {
        public override Dictionary<string, double> QuantOnly
        {
            get
            {
                return new Dictionary<string, double>()
                {
                    {SizeConstants.EspressoShot, 118.0 }
                };
            }
        }
        public override string[] Sources
        {
            get
            {
                return new string[] { "Regular", "Extra_Charged", "Dark", "Americano", "Macchiato", "Iced", "Iced_Dark", "Frozen",
                "Iced_Tea", "Iced_Green_Tea", "Hot_Tea", "Chai_Tea", "Green_Tea", "Cold_Brew", "Energy_Cold_Brew", "Espresso_Drink", "Iced_Espresso_Drink"};
            }
        }

        public static readonly Dictionary<string, Beverage> Regular = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(10, 150)},
            {"Medium", new Beverage(14, 210)},
            {"Large", new Beverage(20, 300)},
            {"Extra_Large", new Beverage(24, 359) }
        };

        public static readonly Dictionary<string, Beverage> Extra_Charged = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(10, 180)},
            {"Medium", new Beverage(14, 252)},
            {"Large", new Beverage(20, 360)},
            {"Extra_Large", new Beverage(24, 431) }
        };

        public static readonly Dictionary<string, Beverage> Dark = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(10, 117)},
            {"Medium", new Beverage(14, 164)},
            {"Large", new Beverage(20, 235)},
            {"Extra_Large", new Beverage(24, 282) }
        };

        public static readonly Dictionary<string, Beverage> Americano = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(10, 237)},
            {"Medium", new Beverage(14, 284)},
            {"Large", new Beverage(20, 371)}
        };

        //Iced also, same sizes
        public static readonly Dictionary<string, Beverage> Macchiato = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(10, 237)},
            {"Medium", new Beverage(14, 284)},
            {"Large", new Beverage(20, 371)}
        };

        public static readonly Dictionary<string, Beverage> Iced = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(16, 198)},
            {"Medium", new Beverage(24, 297)},
            {"Large", new Beverage(32, 396) }
        };

        public static readonly Dictionary<string, Beverage> Iced_Dark = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(16, 124)},
            {"Medium", new Beverage(24, 186)},
            {"Large", new Beverage(32, 248) }
        };

        public static readonly Dictionary<string, Beverage> Frozen = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(16, 196)},
            {"Medium", new Beverage(24, 295)},
            {"Large", new Beverage(32, 393) }
        };

        public static readonly Dictionary<string, Beverage> Iced_Tea = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(16, 45)},
            {"Medium", new Beverage(24, 67)},
            {"Large", new Beverage(32, 90) }
        };

        public static readonly Dictionary<string, Beverage> Iced_Green_Tea = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(16, 45)},
            {"Medium", new Beverage(24, 67)},
            {"Large", new Beverage(32, 91) }
        };

        public static readonly Dictionary<string, Beverage> Hot_Tea = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(10, 90)},
            {"Medium", new Beverage(14, 90)},
            {"Large", new Beverage(20, 180)}
        };

        public static readonly Dictionary<string, Beverage> Chai_Tea = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(10, 54)},
            {"Medium", new Beverage(14, 80)},
            {"Large", new Beverage(20, 107)}
        };

        public static readonly Dictionary<string, Beverage> Green_Tea = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(10, 70)},
            {"Medium", new Beverage(14, 70)},
            {"Large", new Beverage(20, 140)}
        };

        public static readonly Dictionary<string, Beverage> Cold_Brew = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(10, 174)},
            {"Medium", new Beverage(14, 260)},
            {"Large", new Beverage(20, 347) }
        };

        public static readonly Dictionary<string, Beverage> Energy_Cold_Brew = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(10, 292)},
            {"Medium", new Beverage(14, 378)},
            {"Large", new Beverage(20, 465) }
        };

        public static readonly Dictionary<string, Beverage> Espresso_Drink = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(10, 118)},
            {"Medium", new Beverage(14, 166)},
            {"Large", new Beverage(20, 252)}
        };

        public static readonly Dictionary<string, Beverage> Iced_Espresso_Drink = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(16, 118)},
            {"Medium", new Beverage(24, 166)},
            {"Large", new Beverage(32, 252) }
        };
    }
}
