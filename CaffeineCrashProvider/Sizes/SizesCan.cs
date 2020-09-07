using CaffeineCrashProvider.Models;
using System.Collections.Generic;

namespace CaffeineCrashProvider.Sizes
{
    public static class SizesCan
    {
        public static readonly Dictionary<string, Beverage> Coffee = new Dictionary<string, Beverage>()
        {
            {"Black", new Beverage(8, 140)},
            {"ColdBrew", new Beverage(10, 155)},
            {"Doubleshot", new Beverage(7, 110)},
            {"DoubleshotEnergy", new Beverage(7, 145)},
            {"Tripleshot", new Beverage(15, 225)}
        };

        public static readonly Dictionary<string, Beverage> EnergyDrinkSmall = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(8, 77)},
            {"Regular", new Beverage(12, 111)},
            {"Large", new Beverage(16, 148)}
        };

        public static readonly Dictionary<string, Beverage> EnergyDrink = new Dictionary<string, Beverage>()
        {
            {"Regular", new Beverage(16, 163)},
            {"Large", new Beverage(24, 244)}
        };

        public static readonly Dictionary<string, Beverage> FruitVegEnergyDrink = new Dictionary<string, Beverage>()
        {
            {"Regular", new Beverage(8, 80)}
        };

        public static readonly Dictionary<string, Beverage> WorkoutEnergyDrink = new Dictionary<string, Beverage>()
        {
            {"Regular", new Beverage(16, 300)}
        };
    }
}