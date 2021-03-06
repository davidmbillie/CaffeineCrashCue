﻿using Xunit;

namespace CaffeineCrashProvider.Models
{
    public class BeverageTest
    {
        [Fact]
        public void Constructor_SetsOuncesAndCaffeine()
        {
            Beverage subject = new Beverage(12, 48);

            Assert.Equal("12 Oz.", subject.Oz);
            Assert.Equal(48, subject.Caffeine);
            Assert.Equal(4, subject.CaffeinePerOz);
        }
    }
}
