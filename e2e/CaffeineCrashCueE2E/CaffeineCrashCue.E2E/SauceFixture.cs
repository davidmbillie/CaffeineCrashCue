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

namespace CaffeineCrashCue.E2E
{
    [TestFixture]
    public class SauceFixture
    {
        protected AndroidDriver<AndroidElement> Driver { get; private set; }

        private string sauceUri;

        private const string sauceUsWestDomain = "@ondemand.us-west-1.saucelabs.com:443/wd/hub";

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            IConfigurationBuilder configBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true)
                .AddEnvironmentVariables()
                .AddUserSecrets<SauceFixture>();

            IConfigurationRoot config = configBuilder.Build();

            string sauceUser = config.GetRequiredSection("SAUCE_USERNAME").Value ?? throw new ArgumentNullException("");
            string sauceAccessKey = config.GetRequiredSection("SAUCE_ACCESS_KEY").Value ?? throw new ArgumentNullException("");

            sauceUri = $"https://{sauceUser}:{sauceAccessKey}{sauceUsWestDomain}";
        }

        [SetUp]
        public void Setup()
        {
            var capabilities = new AppiumOptions();
            capabilities.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Google Pixel 3a XL GoogleAPI Emulator");
            // capabilities.AddAdditionalCapability(MobileCapabilityType.AppiumVersion, "1.19.1");
            capabilities.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            capabilities.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "11.0");
            capabilities.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, "com.davidmbillie.CaffeineCrashCue");
            capabilities.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, "crc645da8613883ab8f9f.SplashActivity");
            // capabilities.AddAdditionalCapability("appWaitActivity", "crc645da8613883ab8f9f.SplashActivity");
            capabilities.AddAdditionalCapability("appWaitDuration", 50000);
            capabilities.AddAdditionalCapability("name", TestContext.CurrentContext.Test.Name);
            capabilities.AddAdditionalCapability("newCommandTimeout", 320);

            capabilities.AddAdditionalCapability("app",
                "storage:filename=com.davidmbillie.CaffeineCrashCue.apk");

            //60 seconds is the default for the connection timeout
            Driver = new AndroidDriver<AndroidElement>(new Uri(sauceUri), capabilities, TimeSpan.FromSeconds(320));
        }

        [TearDown]
        public void Teardown()
        {
            if (Driver != null)
            {
                var isTestPassed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed;
                ((IJavaScriptExecutor)Driver).ExecuteScript("sauce:job-result=" + (isTestPassed ? "passed" : "failed"));
                Driver.Quit();
                Driver.Dispose();
            }
        }
    }
}
