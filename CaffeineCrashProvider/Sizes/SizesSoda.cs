using CaffeineCrashProvider.Models;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace CaffeineCrashProvider.Sizes
{
    public class SizesSoda : SizesSet
    {
        public override Dictionary<string, double> QuantOnly
        {
            get
            {
                return new Dictionary<string, double>()
                {
                };
            }
        }
        public override string[] Sources
        {
            get
            {
                return new string[] { "Cola", "Diet_Cola", "Mtn_Dew", "Mtn_Dew_High_Caff", "Diet_Mtn_Dew" };
            }
        }

        public static readonly ImmutableDictionary<string, Beverage> Cola = new Dictionary<string, Beverage>()
        {
        }.ToImmutableDictionary();

        public static readonly ImmutableDictionary<string, Beverage> Diet_Cola = new Dictionary<string, Beverage>()
        {
        }.ToImmutableDictionary();

        public static readonly ImmutableDictionary<string, Beverage> Mtn_Dew = new Dictionary<string, Beverage>()
        {
        }.ToImmutableDictionary();

        public static readonly ImmutableDictionary<string, Beverage> Mtn_Dew_High_Caff = new Dictionary<string, Beverage>()
        {
        }.ToImmutableDictionary();

        public static readonly ImmutableDictionary<string, Beverage> Diet_Mtn_Dew = new Dictionary<string, Beverage>()
        {
        }.ToImmutableDictionary();
    }
}