using CaffeineCrashProvider.Models;
using System.Collections.Generic;

namespace CaffeineCrashProvider.Sizes
{
    public class SizesBottle : SizesSet
    {
        public override string[] Sources
        {
            get
            {
                return new string[] { "Coffee" };
            }
        }

        public static readonly Dictionary<string, Beverage> Coffee = new Dictionary<string, Beverage>()
        {
            {"Regular", new Beverage(11, 160)},
            {"RegularMedium", new Beverage(14, 180)},
            {"Frappucino", new Beverage(14, 130)},
            {"ColdBrew", new Beverage(11, 175)},
            {"NitroColdBrew", new Beverage(11, 235)},
            {"Espresso", new Beverage(12, 125)},
            {"EspressoMedium", new Beverage(14, 125)},
            {"DoubleShot", new Beverage(7, 110)},
            {"Classic", new Beverage(8, 85)}
        };
    }
}