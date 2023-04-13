using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaffeineCrashCue.POMs
{
    public class CustomAmountPage
    {
        private AndroidDriver<AndroidElement> _driver;
        private AndroidElement CustomAmountText => _driver.FindElementByAccessibilityId("txtAmount");
        private AndroidElement TotalButton => _driver.FindElementByAccessibilityId("btnTotal");

        public CustomAmountPage(AndroidDriver<AndroidElement> driver)
        {
            _driver = driver;
        }

        public void SetCustomAmount(int amount)
        {
            CustomAmountText.ReplaceValue(amount.ToString());
        }

        public TimePage ClickTotal()
        {
            TotalButton.Click();
            return new TimePage(_driver);
        }
    }
}
