
using System;

namespace CaffeineCrashProvider.Models
{
    public class Beverage
    {
        public string Oz { get; }
        public int Caffeine { get; }
        public double CaffeinePerOz { get; }

        /// <summary>
        /// Constructor using total caffeine amount as an integer
        /// </summary>
        /// <param name="ounces"></param>
        /// <param name="caffeine"></param>
        public Beverage(float ounces, int caffeine)
        {
            Oz = $"{ounces} Oz.";
            Caffeine = caffeine;
            CaffeinePerOz = (double)caffeine / ounces;
        }

        /// <summary>
        /// Constructor using caffeine per oz as a double
        /// </summary>
        /// <param name="ounces"></param>
        /// <param name="caffeinePerOz"></param>
        public Beverage(float ounces, double caffeinePerOz)
        {
            Oz = $"{ounces} Oz.";
            Caffeine = (int)Math.Round(caffeinePerOz * ounces);
            CaffeinePerOz = caffeinePerOz;
        }
    }
}
