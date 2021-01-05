using CaffeineCrashProvider;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CaffeineCrashCueMk1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TimePage : ContentPage
	{
		private const string crashTimeDescriptor = "Your estimated crash time is: ";
		private double crashTimeMillis = 0;
		private static string crashTimeText = "";

		public TimePage()
		{
			BackgroundImageSource = CueConstants.BackgroundImage;
			//default ctor for testing
			InitializeComponent();
			crashTimeMillis = (CueConstants.cueTime + 1) * 60000;
		}

		public TimePage(double coeff, double amount)
		{
			BackgroundImageSource = CueConstants.BackgroundImage;

			InitializeComponent();

			double crashTime = Formulas.CalculateCrash(coeff, amount);
			crashTimeMillis = crashTime * 3600000;

			DateTime crashDateTime = DateTime.Now.AddHours(crashTime);
			crashTimeText = crashDateTime.ToShortTimeString();
			CrashLabel.Text = crashTimeDescriptor + crashTimeText;
			CrashLabel.HorizontalTextAlignment = TextAlignment.Center;
		}

		private async void Notification_Clicked(object o, EventArgs e)
		{
			long crashCueMillis = DependencyService.Get<ICrashAlarm>().GenerateCrashCueMillis(crashTimeMillis);
			DependencyService.Get<ICrashAlarm>().SetAlarm(crashCueMillis);
			Preferences.Set(CueConstants.CrashTimePrefKey, crashTimeText);
			await DisplayAlert("Crash Cue", "Notification set for " + crashTimeText, "OK");
		}
	}
}