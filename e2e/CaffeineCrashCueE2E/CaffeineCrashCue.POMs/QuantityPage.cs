
namespace CaffeineCrashCue.POMs
{
    public class QuantityPage : CaffeinePage
    {
        private AndroidElement CalcButton => _driver.FindElementByAccessibilityId("btnCalc");
        public QuantityPage(AndroidDriver<AndroidElement> driver) : base(driver)
        {

        }

        public TimePage CalculateCrash()
        {
            CalcButton.Click();
            return new TimePage(_driver);
        }

    }
}
