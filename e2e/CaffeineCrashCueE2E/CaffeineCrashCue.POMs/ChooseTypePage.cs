
namespace CaffeineCrashCue.POMs
{
    public class ChooseTypePage : CaffeinePage
    {
        private AndroidElement FirstChoice => _driver.FindElementByAccessibilityId("choice1");
        public ChooseTypePage(AndroidDriver<AndroidElement> driver) : base(driver)
        {

        }

        public ChooseSizePage ClickFirstChoice()
        {
            FirstChoice.Click();
            return new ChooseSizePage(_driver);
        }
    }
}
