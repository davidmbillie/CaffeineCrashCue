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
		private double crashTime = 0;

		public TimePage()
		{
			//default ctor for testing
			InitializeComponent();
			//current test default is 11 minutes because of the current cue constant of 10 minutes 
			crashTime = 660000;
		}

		public TimePage(double coeff, double amount)
		{
			crashTime = Formulas.CalculateCrash(coeff, amount);
			DateTime crashDateTime = DateTime.Now.AddHours(crashTime);
			string crashTimeText = crashDateTime.ToShortTimeString();

			InitializeComponent();

			CrashLabel.Text = crashTimeDescriptor + crashTimeText;
			double crashTimeMillis = crashTime * 3600000;
			long crashCueMillis = DependencyService.Get<ICrashAlarm>().GenerateCrashCueMillis(crashTimeMillis);
			DependencyService.Get<ICrashAlarm>().SetAlarm(crashCueMillis);
		}

		private void Notification_Clicked(object o, EventArgs e)
		{
			long crashMillis = DependencyService.Get<ICrashAlarm>().GenerateCrashCueMillis(crashTime);
			DependencyService.Get<ICrashAlarm>().SetAlarm(crashMillis);
		}
	}
}