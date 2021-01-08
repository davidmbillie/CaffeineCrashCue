using Xunit;

namespace CaffeineCrashProvider
{
	public class ProviderExtensionsTest
	{
		private const double defaultWeight = 150.0;
		private const double defaultWeightNoDecimals = 150;

		[Fact]
		public void ToNumericString_ReturnsOnlyNumbersAndDecimals()
		{
			string inputText = "150,a.0";

			string result = inputText.ToNumericString();

			Assert.Equal(defaultWeight.ToString(), result);
		}

		[Fact]
		public void ToNaturalNumericString_ReturnsOnlyNumbers()
		{
			string inputText = "150,a.";

			string result = inputText.ToNaturalNumericString();

			Assert.Equal(defaultWeightNoDecimals.ToString(), result);
		}

		//[Fact]
		//public void StandardizeWeight_CanConvert()
		//{
		//	string inputText = "144";
		//	double expected = 144;

		//	double result = inputText.StandardizeWeight();

		//	Assert.Equal(expected, result);
		//}

		//[Fact]
		//public void StandardizeWeight_NumberWithLetters_CanConvert()
		//{
		//	string inputText = "a166";
		//	double expected = 166;

		//	double result = inputText.StandardizeWeight();

		//	Assert.Equal(expected, result);
		//}

		//[Fact]
		//public void StandardizeWeight_AllLetters_ReturnsDefault()
		//{
		//	string inputText = "aaa";

		//	double result = inputText.StandardizeWeight();

		//	Assert.Equal(defaultWeight, result);
		//}

		//[Fact]
		//public void StandardizeWeight_Empty_ReturnsDefault()
		//{
		//	string inputText = string.Empty;

		//	double result = inputText.StandardizeWeight();

		//	Assert.Equal(defaultWeight, result);
		//}

		//[Fact]
		//public void StandardizeWeight_Whitespace_ReturnsDefault()
		//{
		//	string inputText = "   ";

		//	double result = inputText.StandardizeWeight();

		//	Assert.Equal(defaultWeight, result);
		//}

		//[Fact]
		//public void StandardizeWeight_Null_ReturnsDefault()
		//{
		//	string inputText = null;

		//	double result = inputText.StandardizeWeight();

		//	Assert.Equal(defaultWeight, result);
		//}
	}
}
