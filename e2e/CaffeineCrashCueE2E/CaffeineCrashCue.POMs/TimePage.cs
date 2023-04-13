using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaffeineCrashCue.POMs
{
    public class TimePage
    {
        private AndroidDriver<AndroidElement> _driver;
        private AndroidElement NotficationButton => _driver.FindElementByAccessibilityId("btnNotif");
        private ReadOnlyCollection<AndroidElement> Notifications => _driver.FindElementsById("android:id/title");

        public TimePage(AndroidDriver<AndroidElement> driver)
        {
            _driver = driver;
        }

        public void SetNotification()
        {
            NotficationButton.Click();
        }

        public void AcceptNotificationAlert()
        {
            IAlert alert = _driver.SwitchTo().Alert();
            alert.Accept();
        }

        public bool ReceivedCrashNotification()
        {
            _driver.OpenNotifications();
            foreach (AndroidElement notification in Notifications)
            {
                if (notification.Text.Contains("Crash"))
                {
                    _driver.PressKeyCode(AndroidKeyCode.Back);
                    return true;
                }
            }
            _driver.PressKeyCode(AndroidKeyCode.Back);
            return false;
        }
    }
}
