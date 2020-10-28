using CaffeineCrashProvider;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CaffeineCrashCueMk1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TimePage : ContentPage
	{
		private const string crashTimeDescriptor = "Your estimated crash time is: ";
		private double crashTimeMillis = 0;

		public TimePage()
		{
			//default ctor for testing
			InitializeComponent();
			crashTimeMillis = (CueConstants.cueTime + 1) * 60000;
		}

		public TimePage(double coeff, double amount)
		{
			InitializeComponent();

			double crashTime = Formulas.CalculateCrash(coeff, amount);
			crashTimeMillis = crashTime * 3600000;

			DateTime crashDateTime = DateTime.Now.AddHours(crashTime);
			string crashTimeText = crashDateTime.ToShortTimeString();
			CrashLabel.Text = crashTimeDescriptor + crashTimeText;
		}

		private void Notification_Clicked(object o, EventArgs e)
		{
			long crashCueMillis = DependencyService.Get<ICrashAlarm>().GenerateCrashCueMillis(crashTimeMillis);
			DependencyService.Get<ICrashAlarm>().SetAlarm(crashCueMillis);
		}
	}
}