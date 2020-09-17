using CaffeineCrashProvider.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace CaffeineCrashProvider.Sizes
{
	public class SizesSetTest
	{
		[Fact]
		public void SizeDictionariesCanBeLoadedWithReflection()
		{
			SizesSet sizesSet = new SizesFastFood();
			Type fastFoodType = sizesSet.GetType();
			FieldInfo regularSizeInfo = fastFoodType.GetField("Regular");
			Dictionary<string, Beverage> result = (Dictionary<string, Beverage>)regularSizeInfo.GetValue(sizesSet);
			Assert.True(result.ContainsKey("Small"));
		}

	}
}
