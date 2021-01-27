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
		private static string crashWarningText = "";

		/// <summary>
		/// empty ctor for testing
		/// </summary>
		public TimePage()
		{
			//default ctor for testing
			BackgroundImageSource = CueConstants.BackgroundImage;
			InitializeComponent();
			crashTimeMillis = (CueConstants.cueTime + 1) * 60000;
			crashTimeText = DateTime.Now.ToShortTimeString();
			crashWarningText = DateTime.Now.ToShortTimeString();
		}

		/// <summary>
		/// ctor for the 'Hour Energy' grid buttom
		/// </summary>
		/// <param name="crashTime"></param>
		public TimePage(double crashTime)
		{
			BackgroundImageSource = CueConstants.BackgroundImage;

			InitializeComponent();

			SetCrashLabel(crashTime);
		}

		/// <summary>
		/// main-use ctor
		/// </summary>
		/// <param name="coeff"></param>
		/// <param name="amount"></param>
		public TimePage(double coeff, double amount)
		{
			BackgroundImageSource = CueConstants.BackgroundImage;

			InitializeComponent();

			double crashTime = Formulas.CalculateCrash(coeff, amount);

			if (Preferences.Get(CueConstants.ExtendedReleaseKey, false))
			{
				crashTime = crashTime * 2;
			}

			SetCrashLabel(crashTime);
		}

		private void SetCrashLabel(double crashTime)
		{
			crashTimeMillis = crashTime * 3600000;

			DateTime crashDateTime = DateTime.Now.AddHours(crashTime);
			DateTime crashWarningTime = DateTime.Now.AddMinutes(-CueConstants.cueTime);

			crashTimeText = crashDateTime.ToShortTimeString();
			crashWarningText = crashWarningTime.ToShortTimeString();
			
			CrashLabel.Text = crashTimeDescriptor + crashTimeText;
			CrashLabel.HorizontalTextAlignment = TextAlignment.Center;
		}

		private async void Notification_Clicked(object o, EventArgs e)
		{
			long crashCueMillis = DependencyService.Get<ICrashAlarm>().GenerateCrashCueMillis(crashTimeMillis);
			DependencyService.Get<ICrashAlarm>().SetAlarm(crashCueMillis, crashWarningText);
			Preferences.Set(CueConstants.CrashTimePrefKey, crashTimeText);
			await DisplayAlert("Crash Cue", "Notification set " + CueConstants.cueTime.ToString() + " minutes before " + crashTimeText, "OK");
		}

		private async void Home_Clicked(object o, EventArgs e)
		{
			await Navigation.PushAsync(new MainPage());
		}
	}
}