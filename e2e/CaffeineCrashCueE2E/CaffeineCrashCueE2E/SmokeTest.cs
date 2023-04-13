using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;

namespace CaffeineCrashCueE2E
{
    [TestFixture]
    [Parallelizable]

    public class AndroidGetStarted : SauceFixture
    {
        [Test]
        [Category("Android")]
        [Category("SmokeTest")]

        public void ShouldOpenNativeAndroidApp()
        {
            var size = Driver.Manage().Window.Size;
            Assert.That(size.Height, Is.Not.EqualTo(0));
        }
    }
}