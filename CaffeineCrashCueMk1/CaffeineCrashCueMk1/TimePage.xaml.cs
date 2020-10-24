using CaffeineCrashProvider;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CaffeineCrashCueMk1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TimePage : ContentPage
	{
		private long crashMillis = 0;
		private const string crashTimeDescriptor = "Your estimated crash time is: ";

		public TimePage()
		{
			//default ctor for testing
			InitializeComponent();
			crashMillis = 30000;
		}

		public TimePage(double coeff, double amount)
		{
			double crash = Formulas.CalculateCrash(coeff, amount);
			DateTime crashTime = DateTime.Now.AddHours(crash);
			string crashTimeText = crashTime.ToShortTimeString();

			InitializeComponent();

			CrashLabel.Text = crashTimeDescriptor + crashTimeText;

			crashMillis = Convert.ToInt64(crash) * 3600000;
		}

		private void Notification_Clicked(object o, EventArgs e)
		{
			DependencyService.Get<ICrashAlarm>().SetAlarm(crashMillis);
		}
	}
}