using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;

namespace CaffeineCrashCue.E2E
{
    [TestFixture]
    [Parallelizable]

    public class SmokeTest : LocalFixture
    {
        [Test]
        [Category("Android")]
        [Category("SmokeTest")]

        public void App_SetsCrashNotification()
        {
            Thread.Sleep(2000);
            MainActivity main = new MainActivity(Driver);            
            CustomAmountPage customPage = main.GoToCustomPage();

            customPage.SetCustomAmount(999);
            TimePage timePage = customPage.ClickTotal();

            timePage.SetNotification();
            timePage.AcceptNotificationAlert();

            //Wait the expected ~30 seconds for the notification to be set
            Thread.Sleep(35000);
            Assert.True(timePage.ReceivedCrashNotification());
        }
    }
}