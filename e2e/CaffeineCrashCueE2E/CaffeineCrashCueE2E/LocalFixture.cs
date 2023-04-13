using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaffeineCrashCueE2E
{
    [TestFixture]
    public class LocalFixture
    {
        protected AndroidDriver<AndroidElement> Driver { get; private set; }

        [SetUp]
        public void Setup()
        {
            var capabilities = new AppiumOptions();
            capabilities.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Google Pixel 5");
            capabilities.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            capabilities.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "11.0");
            capabilities.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, "com.davidmbillie.CaffeineCrashCue");
            capabilities.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, "crc645da8613883ab8f9f.SplashActivity");
            // capabilities.AddAdditionalCapability("appWaitActivity", "crc645da8613883ab8f9f.SplashActivity");
            // capabilities.AddAdditionalCapability("appWaitDuration", 50000);
            capabilities.AddAdditionalCapability("name", TestContext.CurrentContext.Test.Name);
            Driver = new AndroidDriver<AndroidElement>(new Uri("http://localhost:4723/wd/hub"), capabilities, TimeSpan.FromSeconds(320));
        }

        [TearDown]
        public void Teardown()
        {
            if (Driver == null) return;

            var isTestPassed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed;
            Driver.Quit();
        }
    }
}
