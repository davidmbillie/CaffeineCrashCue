using CaffeineCrashProvider.Models;
using System.Collections.Generic;
using System.Reflection;

using Xunit;

namespace CaffeineCrashProvider.Sizes
{
    public class SizesBottleTest
    {
        [Fact(Skip = "Skipping for Jenkins")]
        public void SkippingATestForJenkins()
		{
            Assert.True(true);
		}

        [Fact]
        public void All_Fields_Are_Contained_In_Sources()
        {
            SizesSet sizes = new SizesBottle();
            FieldInfo[] fields = sizes.GetType().GetFields();
            foreach (FieldInfo field in fields)
            {
                Assert.Contains(field.Name, sizes.Sources);
            }
        }

        [Fact]
        public void All_Sources_Have_Fields()
        {
            SizesSet sizes = new SizesBottle();
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
