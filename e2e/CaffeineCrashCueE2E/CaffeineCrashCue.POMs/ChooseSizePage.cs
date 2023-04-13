
namespace CaffeineCrashCue.POMs
{
    public class ChooseSizePage : CaffeinePage
    {
        private AndroidElement FirstChoice => _driver.FindElementByAccessibilityId("choice1");
        public ChooseSizePage(AndroidDriver<AndroidElement> driver) : base(driver)
        {

        }

        public QuantityPage ClickFirstChoice()
        {
            FirstChoice.Click();
            return new QuantityPage(_driver);
        }
    }
}
