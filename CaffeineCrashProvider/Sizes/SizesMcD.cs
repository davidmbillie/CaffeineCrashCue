using CaffeineCrashProvider.Models;
using System.Collections.Generic;

namespace CaffeineCrashProvider.Sizes
{
    public class SizesMcD
    {
        public static readonly Dictionary<string, Beverage> Sizes = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(12, 109)},
            {"Medium", new Beverage(16, 145)},
            {"Large", new Beverage(21, 185)},
        };
    }
}
