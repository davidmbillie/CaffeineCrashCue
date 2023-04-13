
namespace CaffeineCrashCue.POMs
{
    public class TimePage : CaffeinePage
    {
        private AndroidElement NotficationButton => _driver.FindElementByAccessibilityId("btnNotif");
        private ReadOnlyCollection<AndroidElement> Notifications => _driver.FindElementsById("android:id/title");
        private AndroidElement CrashLabel => _driver.FindElementByAccessibilityId("lblCrash");

        public TimePage(AndroidDriver<AndroidElement> driver) : base(driver)
        {

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

        public string GetCrashLabelText()
        {
            return CrashLabel.Text;
        }
    }
}
