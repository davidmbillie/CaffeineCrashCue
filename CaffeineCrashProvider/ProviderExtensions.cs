using System;
using System.Text.RegularExpressions;

namespace CaffeineCrashProvider
{
	public static class ProviderExtensions
	{
		//	private static double defaultWeight = 150;
		//	public static double StandardizeWeight(this string text)
		//	{
		//		if (string.IsNullOrWhiteSpace(text))
		//		{
		//			return defaultWeight;
		//		}

		//		text = text.ToNumericString();

		//		//the text could be empty after replacing all the non-numeric characters
		//		if (string.IsNullOrWhiteSpace(text))
		//		{
		//			return defaultWeight;
		//		}

		//		return Convert.ToDouble(text);
		//	}

		public static string ToNumericString(this string text)
		{
			return Regex.Replace(text, "[^0-9]", "");
		}
	}
}
