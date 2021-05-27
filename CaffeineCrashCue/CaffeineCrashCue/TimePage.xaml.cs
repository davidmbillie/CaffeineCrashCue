using CaffeineCrashProvider;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CaffeineCrashCue
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TimePage : ContentPage
	{
		private readonly string crashTimeDescriptor = $"Your estimated crash time is: {Environment.NewLine}";
		private double crashTimeMillis = 0;
		private static string crashTimeText = "";
		private static string crashWarningText = "";
		private static DateTime crashDateTime;

		/// <summary>
		/// empty ctor for testing
		/// </summary>
		public TimePage()
		{
			//default ctor for testing
			BackgroundImageSource = CueConstants.BackgroundImage;
			InitializeComponent();
			//raise notification in half a minute
			crashTimeMillis = (CueConstants.cueTime + 0.5) * CueConstants.minToMs;
			crashTimeText = DateTime.Now.ToShortTimeString();
			crashWarningText = DateTime.Now.ToShortTimeString();
			crashDateTime = DateTime.Now;
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
		public TimePage(double coeff, double amount, bool extendedRelease = false)
		{
			BackgroundImageSource = CueConstants.BackgroundImage;

			InitializeComponent();

			double crashTime = Formulas.CalculateCrash(coeff, amount);

			if (extendedRelease)
			{
				crashTime = crashTime * 2;
			}

			SetCrashLabel(crashTime);
		}

		private void SetCrashLabel(double crashTime)
		{
			crashTimeMillis = crashTime * CueConstants.hoursToMs;

			crashDateTime = DateTime.Now.AddHours(crashTime);
			crashTimeText = crashDateTime.ToShortTimeString();

			DateTime crashWarningDateTime = crashDateTime.AddMinutes(-CueConstants.cueTime);
			crashWarningText = crashWarningDateTime.ToShortTimeString();
			
			CrashLabel.Text = crashTimeDescriptor + crashTimeText;
			CrashLabel.HorizontalTextAlignment = TextAlignment.Center;
		}

		private async void Notification_Clicked(object o, EventArgs e)
		{
			double offsetMinutes = OffsetStepper.Value;

			bool setNotif = await DisplayAlert("Crash Cue", "Set notification " + CueConstants.cueTime.ToString() + " minutes before " + crashDateTime.AddMinutes(offsetMinutes).ToShortTimeString(), "OK", "Cancel");
			if (setNotif)
			{
				crashTimeMillis = crashTimeMillis + offsetMinutes * CueConstants.minToMs;
				long crashCueMillis = DependencyService.Get<ICrashAlarm>().GenerateCrashCueMillis(crashTimeMillis);
				DependencyService.Get<ICrashAlarm>().SetAlarm(crashCueMillis, crashWarningText);
				Preferences.Set(CueConstants.CrashTimePrefKey, crashTimeText);
			}
		}

		private async void Home_Clicked(object o, EventArgs e)
		{
			await Navigation.PushAsync(new MainPage());
		}

		private void OffsetStepper_ValueChanged(object sender, ValueChangedEventArgs e)
		{
			OffsetLabel.Text = $"Add/Subtract: {e.NewValue} minutes";
		}
	}
}