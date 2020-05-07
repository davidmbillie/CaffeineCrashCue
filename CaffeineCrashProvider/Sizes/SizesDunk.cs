using CaffeineCrashProvider.Models;
using System.Collections.Generic;

namespace CaffeineCrashProvider.Sizes
{
    public static class SizesDunk
    {
        public static readonly Dictionary<string, Beverage> Sizes = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(10, 150)},
            {"Medium", new Beverage(14, 210)},
            {"Large", new Beverage(20, 300)},
            {"Extra Large", new Beverage(24, 359) }
        };
    }
}
