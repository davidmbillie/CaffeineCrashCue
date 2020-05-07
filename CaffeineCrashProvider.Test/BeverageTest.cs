using Xunit;

namespace CaffeineCrashProvider.Models
{
    public class BeverageTest
    {
        [Fact]
        public void Constructor_SetsOuncesAndCaffeine()
        {
            Beverage subject = new Beverage(12, 80);

            Assert.Equal("12 Oz.", subject.Oz);
            Assert.Equal(80, subject.Caffeine);
        }
    }
}
