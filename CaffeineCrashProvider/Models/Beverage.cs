using CaffeineCrashProvider.Sizes;
using System;

namespace CaffeineCrashProvider.Models
{
    public class Beverage
    {
        public string Oz { get; }
        public string Ml { get; }
        public int Caffeine { get; }
        public double CaffeinePerOz { get; }
        public double CaffeinePerMl { get; }

        /// <summary>
        /// Constructor using total caffeine amount as an integer
        /// </summary>
        /// <param name="ounces"></param>
        /// <param name="caffeine"></param>
        public Beverage(float ounces, int caffeine)
        {
            Oz = $"{ounces} Oz";
            Ml = $"{Math.Round(ounces * SizeConstants.OzToMl)} Ml";
            Caffeine = caffeine;
            CaffeinePerOz = (double)caffeine / ounces;
            CaffeinePerMl = CaffeinePerOz * SizeConstants.OzToMl;
        }

        /// <summary>
        /// Constructor using caffeine per oz as a double
        /// </summary>
        /// <param name="ounces"></param>
        /// <param name="caffeinePerOz"></param>
        public Beverage(float ounces, double caffeinePerOz)
        {
            Oz = $"{ounces} Oz";
            Ml = $"{ounces * SizeConstants.OzToMl} Ml";
            Caffeine = (int)Math.Round(caffeinePerOz * ounces);
            CaffeinePerOz = caffeinePerOz;
            CaffeinePerMl = CaffeinePerOz * SizeConstants.OzToMl;
        }
    }
}
