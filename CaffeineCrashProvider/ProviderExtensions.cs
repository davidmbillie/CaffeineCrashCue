using System;
using System.Text.RegularExpressions;

namespace CaffeineCrashProvider
{
    public static class ProviderExtensions
    {
        public static string ToNumericString(this string text)
        {
            return Regex.Replace(text, "[^0-9.]", "");
        }

        public static string ToNaturalNumericString(this string text)
        {
            return Regex.Replace(text, "[^0-9]", "");
        }
    }
}
