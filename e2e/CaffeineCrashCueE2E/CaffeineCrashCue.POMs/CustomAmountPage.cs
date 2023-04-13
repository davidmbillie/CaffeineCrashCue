
namespace CaffeineCrashCue.POMs
{
    public class CustomAmountPage : CaffeinePage
    {
        private AndroidElement CustomAmountText => _driver.FindElementByAccessibilityId("txtAmount");
        private AndroidElement TotalButton => _driver.FindElementByAccessibilityId("btnTotal");

        public CustomAmountPage(AndroidDriver<AndroidElement> driver) : base(driver)
        {

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
