using CaffeineCrashProvider.Models;
using System.Collections.Generic;

namespace CaffeineCrashProvider.Sizes
{
    public static class SizesStar
    {
        //Espresso shots are 75 mg
        //https://globalassets.starbucks.com/assets/94fbcc2ab1e24359850fa1870fc988bc.pdf
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
            {"ExtraLarge", new Beverage(31, 280) }
        };

        public static readonly Dictionary<string, Beverage> ColdBrew = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(12, 150)},
            {"Medium", new Beverage(16, 200)},
            {"Large", new Beverage(24, 300)},
            {"ExtraLarge", new Beverage(31, 330) }
        };

        public static readonly Dictionary<string, Beverage> EspressoMilk = new Dictionary<string, Beverage>()
        {
            {"Short", new Beverage(8, 75)},
            {"Small", new Beverage(12, 75)},
            {"Medium", new Beverage(16, 150)},
            {"Large", new Beverage(24, 150) }
        };

        public static readonly Dictionary<string, Beverage> IcedEspressoMilk = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(12, 75)},
            {"Medium", new Beverage(16, 150)},
            {"Large", new Beverage(24, 150) }
        };

        public static readonly Dictionary<string, Beverage> ChaiTea = new Dictionary<string, Beverage>()
        {
            {"Short", new Beverage(8, 50)},
            {"Small", new Beverage(12, 70)},
            {"Medium", new Beverage(16, 95)},
            {"Large", new Beverage(24, 120) }
        };

        public static readonly Dictionary<string, Beverage> IcedChaiTea = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(8, 70)},
            {"Medium", new Beverage(12, 95)},
            {"Large", new Beverage(16, 145)},
        };

        //works for both hot and iced
        public static readonly Dictionary<string, Beverage> GreenTeaLatte = new Dictionary<string, Beverage>()
        {
            {"Short", new Beverage(8, 30)},
            {"Small", new Beverage(12, 55)},
            {"Medium", new Beverage(16, 80)},
            {"Large", new Beverage(24, 110) }
        };

        public static readonly Dictionary<string, Beverage> CoffeeFrap = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(8, 70)},
            {"Medium", new Beverage(12, 100)},
            {"Large", new Beverage(16, 130)},
        };

        public static readonly Dictionary<string, Beverage> EspressoFrap = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(8, 130)},
            {"Medium", new Beverage(12, 165)},
            {"Large", new Beverage(16, 185)},
        };

        public static readonly Dictionary<string, Beverage> FrappLite = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(8, 70)},
            {"Medium", new Beverage(12, 95)},
            {"Large", new Beverage(16, 120)},
        };

        public static readonly Dictionary<string, Beverage> GreenTeaFrapp = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(8, 50)},
            {"Medium", new Beverage(12, 70)},
            {"Large", new Beverage(16, 95)},
        };
    }
}