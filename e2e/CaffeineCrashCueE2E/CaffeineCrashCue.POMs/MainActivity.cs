namespace CaffeineCrashCue.POMs
{
    public class MainActivity
    {
        AndroidDriver<AndroidElement> _driver;
        AndroidElement CoffeeButton => _driver.FindElementByAccessibilityId("btnCoffee");

        public MainActivity(AndroidDriver<AndroidElement> driver)
        {
            _driver = driver;
        }

        public ChooseTypePage GoToTypePage()
        {
            CoffeeButton.Click();
            return new ChooseTypePage(_driver);
        }
    }
}