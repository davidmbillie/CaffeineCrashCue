using CaffeineCrashProvider.Models;
using System.Collections.Generic;

using Xunit;

namespace CaffeineCrashProvider.Sizes
{
    public class SizesCanTest
    {
        [Fact]
        public void CoffeeSizes_CreateReasonableTimes()
        {
            foreach (KeyValuePair<string, Beverage> kvp in SizesCan.Coffee)
            {
                double result = Formulas.CalculateCrash(1.0, kvp.Value.Caffeine);
                Assert.True(result >= 3, kvp.Key + "crash time was too low: " + result.ToString());
                Assert.True(result <= 6, kvp.Key + "crash time too high: " + result.ToString());
            }
        }

        [Fact]
        public void EnergyDrinkSmallSizes_CreateReasonableTimes()
        {
            foreach (KeyValuePair<string, Beverage> kvp in SizesCan.EnergyDrinkSmall)
            {
                double result = Formulas.CalculateCrash(1.0, kvp.Value.Caffeine);
                Assert.True(result >= 3, kvp.Key + "crash time was too low: " + result.ToString());
                Assert.True(result <= 6, kvp.Key + "crash time too high: " + result.ToString());
            }
        }

        [Fact]
        public void EnergyDrinkSizes_CreateReasonableTimes()
        {
            foreach (KeyValuePair<string, Beverage> kvp in SizesCan.EnergyDrink)
            {
                double result = Formulas.CalculateCrash(1.0, kvp.Value.Caffeine);
                Assert.True(result >= 3, kvp.Key + "crash time was too low: " + result.ToString());
                Assert.True(result <= 6, kvp.Key + "crash time too high: " + result.ToString());
            }
        }

        [Fact]
        public void FruitVegEnergyDrinkSizes_CreateReasonableTimes()
        {
            foreach (KeyValuePair<string, Beverage> kvp in SizesCan.FruitVegEnergyDrink)
            {
                double result = Formulas.CalculateCrash(1.0, kvp.Value.Caffeine);
                Assert.True(result >= 3, kvp.Key + "crash time was too low: " + result.ToString());
                Assert.True(result <= 6, kvp.Key + "crash time too high: " + result.ToString());
            }
        }

        [Fact]
        public void WorkoutEnergyDrinkSizes_CreateReasonableTimes()
        {
            foreach (KeyValuePair<string, Beverage> kvp in SizesCan.WorkoutEnergyDrink)
            {
                double result = Formulas.CalculateCrash(1.0, kvp.Value.Caffeine);
                Assert.True(result >= 3, kvp.Key + "crash time was too low: " + result.ToString());
                Assert.True(result <= 6, kvp.Key + "crash time too high: " + result.ToString());
            }
        }
    }
}
