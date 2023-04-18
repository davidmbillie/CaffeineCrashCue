using Microsoft.Extensions.Configuration;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;

namespace CaffeineCrashCue.E2E
{
    [TestFixture]
    public class BaseFixture
    {
        protected AndroidDriver<AndroidElement> Driver { get; private set; }

        private string appiumUri = "";
        private bool isSauce;
        private string deviceName;
        private string platformVersion;

        private const string sauceUsWestDomain = "@ondemand.us-west-1.saucelabs.com:443/wd/hub";

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            IConfigurationBuilder configBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true)
                .AddEnvironmentVariables()
                .AddUserSecrets<BaseFixture>();

            IConfigurationRoot config = configBuilder.Build();

            isSauce = config.GetValue<bool>("IS_SAUCE");

            if (isSauce)
            {
                string sauceUser = config.GetRequiredSection("SAUCE_USERNAME").Value ?? throw new ArgumentNullException("SAUCE_USERNAME env var is missing - check secrets");
                string sauceAccessKey = config.GetRequiredSection("SAUCE_ACCESS_KEY").Value ?? throw new ArgumentNullException("SAUCE_ACCESS_KEY env var is missing - check secrets");
                appiumUri = $"https://{sauceUser}:{sauceAccessKey}{sauceUsWestDomain}";
            }
            else
            {
                appiumUri = "http://localhost:4723/wd/hub";
            }

            deviceName = config.GetRequiredSection("DEVICE_NAME").Value ?? throw new ArgumentNullException("DEVICE_NAME env var is missing - check runsettings");
            platformVersion = config.GetRequiredSection("PLATFORM_VERSION").Value ?? throw new ArgumentNullException("PLATFORM_VERSION env var is missing - check runsettings");

        }

        [SetUp]
        public void Setup()
        {
            var capabilities = new AppiumOptions();
            capabilities.AddAdditionalCapability(MobileCapabilityType.DeviceName, deviceName);
            // capabilities.AddAdditionalCapability(MobileCapabilityType.AppiumVersion, "1.19.1");
            capabilities.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            capabilities.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, platformVersion);
            capabilities.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, "com.davidmbillie.CaffeineCrashCue");
            capabilities.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, "crc645da8613883ab8f9f.SplashActivity");
            // capabilities.AddAdditionalCapability("appWaitActivity", "crc645da8613883ab8f9f.SplashActivity");
            capabilities.AddAdditionalCapability("appWaitDuration", 50000);
            capabilities.AddAdditionalCapability("name", TestContext.CurrentContext.Test.Name);
            capabilities.AddAdditionalCapability("newCommandTimeout", 320);

            if (isSauce)
            {
                capabilities.AddAdditionalCapability("app",
                    "storage:filename=com.davidmbillie.CaffeineCrashCue.apk");
            }

            //60 seconds is the default for the connection timeout
            Driver = new AndroidDriver<AndroidElement>(new Uri(appiumUri), capabilities, TimeSpan.FromSeconds(320));
        }

        [TearDown]
        public void Teardown()
        {
            if (Driver != null)
            {
                if (isSauce)
                {
                    var isTestPassed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed;
                    ((IJavaScriptExecutor)Driver).ExecuteScript("sauce:job-result=" + (isTestPassed ? "passed" : "failed"));
                }
                Driver.Quit();
                Driver.Dispose();
            }
        }
    }
}
