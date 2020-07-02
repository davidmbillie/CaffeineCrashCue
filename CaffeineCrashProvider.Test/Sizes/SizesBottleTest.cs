using CaffeineCrashProvider.Models;
using System.Collections.Generic;

using Xunit;

namespace CaffeineCrashProvider.Sizes
{
    public class SizesBottleTest
    {
        [Fact]
        public void CoffeeSizes_CreateReasonableTimes()
        {
            foreach (KeyValuePair<string, Beverage> kvp in SizesBottle.Coffee)
            {
                double result = Formulas.CalculateCrash(1.0, kvp.Value.Caffeine);
                Assert.True(result >= 3, kvp.Key + "crash time was too low: " + result.ToString());
                Assert.True(result <= 6, kvp.Key + "crash time too high: " + result.ToString());
            }
        }
    }
}
