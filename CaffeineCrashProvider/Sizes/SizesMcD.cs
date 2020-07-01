using CaffeineCrashProvider.Models;
using System.Collections.Generic;

namespace CaffeineCrashProvider.Sizes
{
    public class SizesMcD
    {
        //Espresso shots are 71 mg

        public static readonly Dictionary<string, Beverage> Regular = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(12, 109)},
            {"Medium", new Beverage(16, 145)},
            {"Large", new Beverage(21, 185)}
        };

        //same as iced sizes
        public static readonly Dictionary<string, Beverage> EspressoMilk = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(12, 71)},
            {"Medium", new Beverage(16, 142)},
            {"Large", new Beverage(21, 178)}
        };

        public static readonly Dictionary<string, Beverage> Iced = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(16, 133)},
            {"Medium", new Beverage(21, 200)},
            {"Large", new Beverage(32, 320)}
        };
    }
}
