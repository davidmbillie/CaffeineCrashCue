using CaffeineCrashProvider.Models;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace CaffeineCrashProvider.Sizes
{
    public class SizesBottle : SizesSet
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
                return new string[] { "Coffee", "Energy" };
            }
        }

        public static readonly Dictionary<string, Beverage> Coffee = new Dictionary<string, Beverage>()
        {
            {"Regular", new Beverage(11, 160)},
            {"Regular_Large", new Beverage(14, 180)},
            {"Frappucino", new Beverage(14, 130)},
            {"Cold_Brew", new Beverage(11, 175)},
            {"Nitro_Cold_Brew", new Beverage(11, 235)},
            {"Espresso", new Beverage(12, 125)},
            {"Mocha_Latte_Cappuccino_Etc_Large", new Beverage(14, 125)},
            {"Double_Shot", new Beverage(7, 110)},
            {"Classic", new Beverage(8, 85)}
        };

        public static readonly Dictionary<string, Beverage> Energy = new Dictionary<string, Beverage>()
        {
            {"Hydro Energy", new Beverage(25, 188)},
        };
    }
}