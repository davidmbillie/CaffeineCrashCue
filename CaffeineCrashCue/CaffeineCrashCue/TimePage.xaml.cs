﻿using CaffeineCrashProvider;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CaffeineCrashCue
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TimePage : ContentPage
	{
		//fields for main ctor values for recalculations
		private readonly double coeff = 0;
		private readonly double amount = 0;
		private readonly bool extendedRelease = false; 

		private readonly string crashTimeDescriptor = $"Your estimated crash time is: {Environment.NewLine}";
		private double crashTimeMillis = 0;
		private static string crashTimeText = "";
		private static DateTime crashDateTime;

		private static readonly DecayProvider decayProvider = DecayProvider.Instance;

		/// <summary>
		/// main-use ctor
		/// </summary>
		/// <param name="coeff"></param>
		/// <param name="amount"></param>
		public TimePage(double coeff, double amount, bool extendedRelease = false)
		{
			this.coeff = coeff;
			this.amount = amount;
			this.extendedRelease = extendedRelease;

			BackgroundImageSource = CueConstants.BackgroundImage;

			InitializeComponent();

			double crashTime = Formulas.CalculateCrash(coeff, amount);

			if (extendedRelease)
			{
				crashTime *= 2;
			}

			SetCrashValues(crashTime);
			SetCrashLabel();

			if (!decayProvider.IsReady(DependencyService.Get<ICrashAlarm>().GetCurrentTimeMillis()))
			{
				btnRecalc.IsVisible = false;
				//btnClear.IsVisible = false;
			}
			//else
			//{
			//	//these will need to be toggled to visible again if made invisible by the `Clear` button
			//	btnRecalc.IsVisible = true;
			//	btnClear.IsVisible = true;
			//}
		}

		/// <summary>
		/// ctor for the 'Hour Energy' grid buttom
		/// </summary>
		/// <param name="crashTime"></param>
		public TimePage(double crashTime)
		{
			BackgroundImageSource = CueConstants.BackgroundImage;
			InitializeComponent();
			SetCrashValues(crashTime);
			SetCrashLabel();
			btnRecalc.IsVisible = false;
			//btnClear.IsVisible = false;
		}

		/// <summary>
		/// empty ctor for testing
		/// </summary>
		public TimePage()
		{
			//default ctor for testing
			BackgroundImageSource = CueConstants.BackgroundImage;
			InitializeComponent();
			//raise notification in half a minute
			crashTimeMillis = (CueConstants.CueTime + 0.5) * CueConstants.MinToMs;
			crashTimeText = DateTime.Now.ToShortTimeString();
			crashDateTime = DateTime.Now;
		}

		private void SetCrashValues(double crashTime)
		{
			crashTimeMillis = crashTime * CueConstants.HoursToMs;
			crashDateTime = DateTime.Now.AddHours(crashTime);
			crashTimeText = crashDateTime.ToShortTimeString();
		}

		private void SetCrashLabel()
		{			
			CrashLabel.Text = crashTimeDescriptor + crashTimeText;
			CrashLabel.HorizontalTextAlignment = TextAlignment.Center;
		}

		private async void Notification_Clicked(object o, EventArgs e)
		{
			double offsetMinutes = OffsetStepper.Value;

			bool setNotif = await DisplayAlert("Crash Cue", "Set notification " + CueConstants.CueTime.ToString() + " minutes before " + crashDateTime.AddMinutes(offsetMinutes).ToShortTimeString(), "OK", "Cancel");
			if (setNotif)
			{
				crashTimeMillis += offsetMinutes * CueConstants.MinToMs;
				//Generate the cue time by subtracting the cue constant from the crash time, then adding it to the Java.Lang.JavaSystem.CurrentTimeMillis() 
				long crashCueMillis = DependencyService.Get<ICrashAlarm>().GenerateCrashCueMillis(crashTimeMillis);

				DependencyService.Get<ICrashAlarm>().SetAlarm(crashCueMillis, crashTimeText);
				Preferences.Set(CueConstants.CrashTimePrefKey, crashTimeText);
				decayProvider.SetDecayVaules(amount, crashTimeMillis, DependencyService.Get<ICrashAlarm>().GetCurrentTimeMillis());
			}
		}

		private async void Recalculate_Clicked(object o, EventArgs e)
		{
			bool yesRecalc = await DisplayAlert("Crash Cue", "Recalculate crash time with remaining caffeine from the previous cue?", "Yes", "No");
			if (yesRecalc)
			{
				double adjustedAmount = decayProvider.GetAdjustedAmount(amount, DependencyService.Get<ICrashAlarm>().GetCurrentTimeMillis());
				await Navigation.PushAsync(new TimePage(coeff, adjustedAmount, extendedRelease));
			}
		}

		//private async void Clear_Clicked(object o, EventArgs e)
		//{
		//	bool confirmClear = await DisplayAlert("Crash Cue", "Confirm", "Yes", "No");
		//	if (confirmClear)
		//	{
		//		decayProvider.SetDecayVaules(-1, -1, -1);
		//		await Navigation.PopAsync();
		//	}
		//}

		private async void Home_Clicked(object o, EventArgs e)
		{
			await Navigation.PopToRootAsync();
		}

		private void OffsetStepper_ValueChanged(object sender, ValueChangedEventArgs e)
		{
			OffsetLabel.Text = $"Add/Subtract: {e.NewValue} minutes";
		}
	}
}