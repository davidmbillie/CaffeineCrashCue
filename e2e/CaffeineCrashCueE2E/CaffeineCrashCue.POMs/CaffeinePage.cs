
namespace CaffeineCrashCue.POMs
{
    public abstract class CaffeinePage
    {
        protected AndroidDriver<AndroidElement> _driver;
        public CaffeinePage(AndroidDriver<AndroidElement> driver)
        {
            _driver = driver;
        }
    }
}
