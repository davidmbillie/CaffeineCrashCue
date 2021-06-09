using CaffeineCrashProvider.Models;
using System.Collections.Generic;
using System.Reflection;

using Xunit;

namespace CaffeineCrashProvider.Sizes
{
    public class SizesDonutTest
    {
        [Fact]
        public void All_Fields_Are_Contained_In_Sources()
        {
            SizesSet sizes = new SizesDonut();
            FieldInfo[] fields = sizes.GetType().GetFields();
            foreach (FieldInfo field in fields)
            {
                Assert.Contains(field.Name, sizes.Sources);
            }
        }

        [Fact]
        public void All_Sources_Have_Fields()
        {
            SizesSet sizes = new SizesDonut();
            FieldInfo[] fields = sizes.GetType().GetFields();
            List<string> fieldNames = new List<string>();
            foreach (FieldInfo field in fields)
            {
                fieldNames.Add(field.Name);
            }
            foreach (string source in sizes.Sources)
            {
                Assert.Contains(source, fieldNames);
            }
        }

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
        public void Iced_DarkSizes_CreateReasonableTimes()
        {
            foreach (KeyValuePair<string, Beverage> kvp in SizesDonut.Iced_Dark)
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
        public void Iced_TeaSizes_CreateReasonableTimes()
        {
            foreach (KeyValuePair<string, Beverage> kvp in SizesDonut.Iced_Tea)
            {
                double result = Formulas.CalculateCrash(1.0, kvp.Value.Caffeine);
                Assert.True(result >= 3, kvp.Key + "crash time was too low: " + result.ToString());
                Assert.True(result <= 6, kvp.Key + "crash time too high: " + result.ToString());
            }
        }

        [Fact]
        public void Iced_Green_TeaSizes_CreateReasonableTimes()
        {
            foreach (KeyValuePair<string, Beverage> kvp in SizesDonut.Frozen_Green_Matcha)
            {
                double result = Formulas.CalculateCrash(1.0, kvp.Value.Caffeine);
                Assert.True(result >= 3, kvp.Key + "crash time was too low: " + result.ToString());
                Assert.True(result <= 6, kvp.Key + "crash time too high: " + result.ToString());
            }
        }

        [Fact]
        public void Hot_TeaSizes_CreateReasonableTimes()
        {
            foreach (KeyValuePair<string, Beverage> kvp in SizesDonut.Hot_Tea)
            {
                double result = Formulas.CalculateCrash(1.0, kvp.Value.Caffeine);
                Assert.True(result >= 3, kvp.Key + "crash time was too low: " + result.ToString());
                Assert.True(result <= 6, kvp.Key + "crash time too high: " + result.ToString());
            }
        }

        [Fact]
        public void Chai_TeaSizes_CreateReasonableTimes()
        {
            foreach (KeyValuePair<string, Beverage> kvp in SizesDonut.Chai_Tea)
            {
                double result = Formulas.CalculateCrash(1.0, kvp.Value.Caffeine);
                Assert.True(result >= 3, kvp.Key + "crash time was too low: " + result.ToString());
                Assert.True(result <= 6, kvp.Key + "crash time too high: " + result.ToString());
            }
        }
        [Fact]
        public void Green_TeaSizes_CreateReasonableTimes()
        {
            foreach (KeyValuePair<string, Beverage> kvp in SizesDonut.Green_Tea)
            {
                double result = Formulas.CalculateCrash(1.0, kvp.Value.Caffeine);
                Assert.True(result >= 3, kvp.Key + "crash time was too low: " + result.ToString());
                Assert.True(result <= 6, kvp.Key + "crash time too high: " + result.ToString());
            }
        }

        [Fact]
        public void Cold_BrewSizes_CreateReasonableTimes()
        {
            foreach (KeyValuePair<string, Beverage> kvp in SizesDonut.Cold_Brew)
            {
                double result = Formulas.CalculateCrash(1.0, kvp.Value.Caffeine);
                Assert.True(result >= 3, kvp.Key + "crash time was too low: " + result.ToString());
                Assert.True(result <= 6, kvp.Key + "crash time too high: " + result.ToString());
            }
        }

        [Fact]
        public void Energy_Cold_BrewSizes_CreateReasonableTimes()
        {
            foreach (KeyValuePair<string, Beverage> kvp in SizesDonut.Energy_Cold_Brew)
            {
                double result = Formulas.CalculateCrash(1.0, kvp.Value.Caffeine);
                Assert.True(result >= 3, kvp.Key + "crash time was too low: " + result.ToString());
                Assert.True(result <= 6, kvp.Key + "crash time too high: " + result.ToString());
            }
        }

        [Fact]
        public void Mocha_Latte_Cappuccino_EtcSizes_CreateReasonableTimes()
        {
            foreach (KeyValuePair<string, Beverage> kvp in SizesDonut.Mocha_Latte_Cappuccino_Etc)
            {
                double result = Formulas.CalculateCrash(1.0, kvp.Value.Caffeine);
                Assert.True(result >= 3, kvp.Key + "crash time was too low: " + result.ToString());
                Assert.True(result <= 6, kvp.Key + "crash time too high: " + result.ToString());
            }
        }

        [Fact]
        public void Iced_Mocha_Latte_Cappuccino_EtcSizes_CreateReasonableTimes()
        {
            foreach (KeyValuePair<string, Beverage> kvp in SizesDonut.Iced_Mocha_Latte_Cappuccino_Etc)
            {
                double result = Formulas.CalculateCrash(1.0, kvp.Value.Caffeine);
                Assert.True(result >= 3, kvp.Key + "crash time was too low: " + result.ToString());
                Assert.True(result <= 6, kvp.Key + "crash time too high: " + result.ToString());
            }
        }

    }
}
