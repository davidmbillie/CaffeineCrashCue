namespace CaffeineCrashCue.POMs
{
    public class MainActivity
    {
        private AndroidDriver<AndroidElement> _driver;
        private AndroidElement CoffeeButton => _driver.FindElementByAccessibilityId("btnCoffee");
        private AndroidElement CustomButton => _driver.FindElementByAccessibilityId("btnCustom");

        public MainActivity(AndroidDriver<AndroidElement> driver)
        {
            _driver = driver;
        }

        public ChooseTypePage GoToTypePage()
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