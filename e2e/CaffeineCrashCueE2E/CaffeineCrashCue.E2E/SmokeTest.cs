
namespace CaffeineCrashCue.E2E
{
    [TestFixture]
    public class SmokeTest : BaseFixture
    {
        [Test]
        [Category("SmokeTest")]

        public void App_SetsCrashNotification()
        {
            Thread.Sleep(2000);
            MainActivity main = new MainActivity(Driver);            
            CustomAmountPage customPage = main.GoToCustomPage();

            //Set the hard-coded dummy value for setting a notification in 30 seconds
            customPage.SetCustomAmount(999);
            TimePage timePage = customPage.ClickTotal();

            timePage.SetNotification();
            timePage.AcceptNotificationAlert();

            //Wait the expected ~30 seconds for the notification to be set
            Thread.Sleep(35000);
            Assert.True(timePage.ReceivedCrashNotification());
        }

        [Test]
        [Category("SmokeTest")]

        public void CrashLabel_ContainsTimeStamp()
        {
            Thread.Sleep(2000);
            MainActivity main = new MainActivity(Driver);
            ChooseTypePage typePage = main.ClickCoffeeButton();
            ChooseSizePage sizePage = typePage.ClickFirstChoice();
            QuantityPage quantityPage = sizePage.ClickFirstChoice();
            TimePage timePage = quantityPage.CalculateCrash();
            string labelText = timePage.GetCrashLabelText();

            // Check that a time was calculated and set
            Assert.True(labelText.Contains("AM") || labelText.Contains("PM"));
        }
    }
}