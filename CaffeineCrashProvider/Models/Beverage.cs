
namespace CaffeineCrashProvider.Models
{
    public class Beverage
    {
        public string Oz { get; }
        public int Caffeine { get; }
        public double CaffeinePerOz { get; }

        public Beverage(int ounces, int caffeine)
        {
            Oz = $"{ounces} Oz.";
            Caffeine = caffeine;
            CaffeinePerOz = (double)caffeine / ounces;            
        }
    }
}
