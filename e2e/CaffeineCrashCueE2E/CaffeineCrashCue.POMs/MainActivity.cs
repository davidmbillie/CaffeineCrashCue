
namespace CaffeineCrashCue.POMs
{
    public class MainActivity : CaffeinePage
    {
        private AndroidElement CoffeeButton => _driver.FindElementByAccessibilityId("btnCoffee");
        private AndroidElement CustomButton => _driver.FindElementByAccessibilityId("btnCustom");

        public MainActivity(AndroidDriver<AndroidElement> driver) : base(driver)
        {

        }

        public ChooseTypePage ClickCoffeeButton()
        {
            CoffeeButton.Click();
            return new ChooseTypePage(_driver);
        }

        public CustomAmountPage GoToCustomPage()
        {
            CustomButton.Click();
            return new CustomAmountPage(_driver);
        }
    }
}