using CaffeineCrashProvider.Models;
using System.Collections.Generic;

namespace CaffeineCrashProvider.Sizes
{
    public class SizesCan : SizesSet
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
                return new string[] { "Coffee", "R_Bull_Energy_Drink", "Energy_Drink", 
                    "Fruit_And_Veg_Energy_Drink", "Workout_Energy_Drink", "Kickstart_Game_Fuel_Energy", "Rise_Energy"};
            }
        }

        public static readonly Dictionary<string, Beverage> Coffee = new Dictionary<string, Beverage>()
        {
            {"Black", new Beverage(8, 140)},
            {"Cold_Brew", new Beverage(10, 155)},
            {"Doubleshot", new Beverage(7, 110)},
            {"Doubleshot_Energy", new Beverage(7, 145)},
            {"Tripleshot", new Beverage(15, 225)}
        };

        public static readonly Dictionary<string, Beverage> R_Bull_Energy_Drink = new Dictionary<string, Beverage>()
        {
            {"Small", new Beverage(8.4F, 77)},
            {"Regular", new Beverage(12, 111)},
            {"Large", new Beverage(16, 148)}
        };

        public static readonly Dictionary<string, Beverage> Energy_Drink = new Dictionary<string, Beverage>()
        {
            {"Regular", new Beverage(16, 163)},
            {"Large", new Beverage(24, 244)}
        };

        public static readonly Dictionary<string, Beverage> Fruit_And_Veg_Energy_Drink = new Dictionary<string, Beverage>()
        {
            {"Regular", new Beverage(8, 80)}
        };

        public static readonly Dictionary<string, Beverage> Workout_Energy_Drink = new Dictionary<string, Beverage>()
        {
            {"Regular", new Beverage(16, 300)}
        };

        public static readonly Dictionary<string, Beverage> Kickstart_Game_Fuel_Energy = new Dictionary<string, Beverage>()
        {
            {"Regular", new Beverage(16, 90)}
        };

        public static readonly Dictionary<string, Beverage> Rise_Energy = new Dictionary<string, Beverage>()
        {
            {"Regular", new Beverage(16, 180)}
        };
    }
}