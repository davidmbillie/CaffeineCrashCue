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
			crashTime = 60000;
		}

		public TimePage(double coeff, double amount)
		{
			crashTime = Formulas.CalculateCrash(coeff, amount);
			DateTime crashDateTime = DateTime.Now.AddHours(crashTime);
			string crashTimeText = crashDateTime.ToShortTimeString();

			InitializeComponent();

			CrashLabel.Text = crashTimeDescriptor + crashTimeText;
			long crashMillis = DependencyService.Get<ICrashAlarm>().GenerateCrashMillis(crashTime);
			DependencyService.Get<ICrashAlarm>().SetAlarm(crashMillis);
		}

		private void Notification_Clicked(object o, EventArgs e)
		{
			long crashMillis = DependencyService.Get<ICrashAlarm>().GenerateCrashMillis(crashTime);
			DependencyService.Get<ICrashAlarm>().SetAlarm(crashMillis);
		}
	}
}