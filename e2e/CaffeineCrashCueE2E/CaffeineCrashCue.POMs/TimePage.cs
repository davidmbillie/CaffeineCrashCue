using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaffeineCrashCue.POMs
{
    public class TimePage
    {
        private AndroidDriver<AndroidElement> _driver;
        private AndroidElement NotficationButton => _driver.FindElementByAccessibilityId("btnNotif");

        public TimePage(AndroidDriver<AndroidElement> driver)
        {
            _driver = driver;
        }

        public void SetNotification()
        {
            NotficationButton.Click();
        }
    }
}
