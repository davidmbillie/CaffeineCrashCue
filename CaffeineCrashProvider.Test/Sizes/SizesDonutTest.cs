using CaffeineCrashProvider.Models;
using System.Collections.Generic;

using Xunit;

namespace CaffeineCrashProvider.Sizes
{
    public class SizesDonutTest
    {
        [Fact]
        public void RegularSizes_CreateReasonableTimes()
        {
            foreach (KeyValuePair<string, Beverage> kvp in SizesDonut.Regular)
            {
                double result = Formulas.CalculateCrash(1.0, kvp.Value.Caffeine);
                Assert.True(result >= 3, kvp.Key + "crash time was too low: " + result.ToString());
                Assert.True(result <= 6, kvp.Key + "crash time too high: " + result.ToString());
            }
        }

        [Fact]
        public void DarkSizes_CreateReasonableTimes()
        {
            foreach (KeyValuePair<string, Beverage> kvp in SizesDonut.Dark)
            {
                double result = Formulas.CalculateCrash(1.0, kvp.Value.Caffeine);
                Assert.True(result >= 3, kvp.Key + "crash time was too low: " + result.ToString());
                Assert.True(result <= 6, kvp.Key + "crash time too high: " + result.ToString());
            }
        }

        [Fact]
        public void AmericanoSizes_CreateReasonableTimes()
        {
            foreach (KeyValuePair<string, Beverage> kvp in SizesDonut.Americano)
            {
                double result = Formulas.CalculateCrash(1.0, kvp.Value.Caffeine);
                Assert.True(result >= 3, kvp.Key + "crash time was too low: " + result.ToString());
                Assert.True(result <= 6, kvp.Key + "crash time too high: " + result.ToString());
            }
        }

        [Fact]
        public void MacchiatoSizes_CreateReasonableTimes()
        {
            foreach (KeyValuePair<string, Beverage> kvp in SizesDonut.Macchiato)
            {
                double result = Formulas.CalculateCrash(1.0, kvp.Value.Caffeine);
                Assert.True(result >= 3, kvp.Key + "crash time was too low: " + result.ToString());
                Assert.True(result <= 6, kvp.Key + "crash time too high: " + result.ToString());
            }
        }

        [Fact]
        public void IcedSizes_CreateReasonableTimes()
        {
            foreach (KeyValuePair<string, Beverage> kvp in SizesDonut.Iced)
            {
                double result = Formulas.CalculateCrash(1.0, kvp.Value.Caffeine);
                Assert.True(result >= 3, kvp.Key + "crash time was too low: " + result.ToString());
                Assert.True(result <= 6, kvp.Key + "crash time too high: " + result.ToString());
            }
        }

        [Fact]
        public void IcedDarkSizes_CreateReasonableTimes()
        {
            foreach (KeyValuePair<string, Beverage> kvp in SizesDonut.IcedDark)
            {
                double result = Formulas.CalculateCrash(1.0, kvp.Value.Caffeine);
                Assert.True(result >= 3, kvp.Key + "crash time was too low: " + result.ToString());
                Assert.True(result <= 6, kvp.Key + "crash time too high: " + result.ToString());
            }
        }

        [Fact]
        public void FrozenSizes_CreateReasonableTimes()
        {
            foreach (KeyValuePair<string, Beverage> kvp in SizesDonut.Frozen)
            {
                double result = Formulas.CalculateCrash(1.0, kvp.Value.Caffeine);
                Assert.True(result >= 3, kvp.Key + "crash time was too low: " + result.ToString());
                Assert.True(result <= 6, kvp.Key + "crash time too high: " + result.ToString());
            }
        }

        [Fact]
        public void IcedTeaSizes_CreateReasonableTimes()
        {
            foreach (KeyValuePair<string, Beverage> kvp in SizesDonut.IcedTea)
            {
                double result = Formulas.CalculateCrash(1.0, kvp.Value.Caffeine);
                Assert.True(result >= 3, kvp.Key + "crash time was too low: " + result.ToString());
                Assert.True(result <= 6, kvp.Key + "crash time too high: " + result.ToString());
            }
        }

        [Fact]
        public void IcedGreenTeaSizes_CreateReasonableTimes()
        {
            foreach (KeyValuePair<string, Beverage> kvp in SizesDonut.IcedGreenTea)
            {
                double result = Formulas.CalculateCrash(1.0, kvp.Value.Caffeine);
                Assert.True(result >= 3, kvp.Key + "crash time was too low: " + result.ToString());
                Assert.True(result <= 6, kvp.Key + "crash time too high: " + result.ToString());
            }
        }

        [Fact]
        public void HotTeaSizes_CreateReasonableTimes()
        {
            foreach (KeyValuePair<string, Beverage> kvp in SizesDonut.HotTea)
            {
                double result = Formulas.CalculateCrash(1.0, kvp.Value.Caffeine);
                Assert.True(result >= 3, kvp.Key + "crash time was too low: " + result.ToString());
                Assert.True(result <= 6, kvp.Key + "crash time too high: " + result.ToString());
            }
        }

        [Fact]
        public void ChaiTeaSizes_CreateReasonableTimes()
        {
            foreach (KeyValuePair<string, Beverage> kvp in SizesDonut.ChaiTea)
            {
                double result = Formulas.CalculateCrash(1.0, kvp.Value.Caffeine);
                Assert.True(result >= 3, kvp.Key + "crash time was too low: " + result.ToString());
                Assert.True(result <= 6, kvp.Key + "crash time too high: " + result.ToString());
            }
        }
        [Fact]
        public void GreenTeaSizes_CreateReasonableTimes()
        {
            foreach (KeyValuePair<string, Beverage> kvp in SizesDonut.GreenTea)
            {
                double result = Formulas.CalculateCrash(1.0, kvp.Value.Caffeine);
                Assert.True(result >= 3, kvp.Key + "crash time was too low: " + result.ToString());
                Assert.True(result <= 6, kvp.Key + "crash time too high: " + result.ToString());
            }
        }

        [Fact]
        public void ColdBrewSizes_CreateReasonableTimes()
        {
            foreach (KeyValuePair<string, Beverage> kvp in SizesDonut.ColdBrew)
            {
                double result = Formulas.CalculateCrash(1.0, kvp.Value.Caffeine);
                Assert.True(result >= 3, kvp.Key + "crash time was too low: " + result.ToString());
                Assert.True(result <= 6, kvp.Key + "crash time too high: " + result.ToString());
            }
        }

        [Fact]
        public void EnergyColdBrewSizes_CreateReasonableTimes()
        {
            foreach (KeyValuePair<string, Beverage> kvp in SizesDonut.EnergyColdBrew)
            {
                double result = Formulas.CalculateCrash(1.0, kvp.Value.Caffeine);
                Assert.True(result >= 3, kvp.Key + "crash time was too low: " + result.ToString());
                Assert.True(result <= 6, kvp.Key + "crash time too high: " + result.ToString());
            }
        }

        [Fact]
        public void EspressoMilkSizes_CreateReasonableTimes()
        {
            foreach (KeyValuePair<string, Beverage> kvp in SizesDonut.EspressoMilk)
            {
                double result = Formulas.CalculateCrash(1.0, kvp.Value.Caffeine);
                Assert.True(result >= 3, kvp.Key + "crash time was too low: " + result.ToString());
                Assert.True(result <= 6, kvp.Key + "crash time too high: " + result.ToString());
            }
        }

        [Fact]
        public void IcedEspressoMilkSizes_CreateReasonableTimes()
        {
            foreach (KeyValuePair<string, Beverage> kvp in SizesDonut.IcedEspressoMilk)
            {
                double result = Formulas.CalculateCrash(1.0, kvp.Value.Caffeine);
                Assert.True(result >= 3, kvp.Key + "crash time was too low: " + result.ToString());
                Assert.True(result <= 6, kvp.Key + "crash time too high: " + result.ToString());
            }
        }

    }
}
