using CaffeineCrashProvider.Models;
using System.Collections.Generic;

using Xunit;

namespace CaffeineCrashProvider.Sizes
{
    public class SizesFastFoodTest

    {
        [Fact]
        public void RegularSizes_CreateReasonableTimes()
        {
            foreach (KeyValuePair<string, Beverage> kvp in SizesFastFood.Regular)
            {
                double result = Formulas.CalculateCrash(1.0, kvp.Value.Caffeine);
                Assert.True(result >= 3, kvp.Key + "crash time was too low: " + result.ToString());
                Assert.True(result <= 6, kvp.Key + "crash time too high: " + result.ToString());
            }
        }

        [Fact]
        public void EspressoMilkSizes_CreateReasonableTimes()
        {
            foreach (KeyValuePair<string, Beverage> kvp in SizesFastFood.EspressoMilk)
            {
                double result = Formulas.CalculateCrash(1.0, kvp.Value.Caffeine);
                Assert.True(result >= 3, kvp.Key + "crash time was too low: " + result.ToString());
                Assert.True(result <= 6, kvp.Key + "crash time too high: " + result.ToString());
            }
        }

        [Fact]
        public void IcedSizes_CreateReasonableTimes()
        {
            foreach (KeyValuePair<string, Beverage> kvp in SizesFastFood.Iced)
            {
                double result = Formulas.CalculateCrash(1.0, kvp.Value.Caffeine);
                Assert.True(result >= 3, kvp.Key + "crash time was too low: " + result.ToString());
                Assert.True(result <= 6, kvp.Key + "crash time too high: " + result.ToString());
            }
        }
    }
}
