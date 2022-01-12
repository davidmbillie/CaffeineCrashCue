using System;
using CaffeineCrashProvider.Sizes;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CaffeineCrashCue
{
    public partial class MainPage : ContentPage
    {
        private readonly double coeff;
        public MainPage()
        {
            BackgroundImageSource = CueConstants.BackgroundImage;
            coeff = Preferences.Get(CueConstants.CoeffPrefKey, 1.0);
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            //placing this in OnAppearing to update text after clicking the 'Home' button on the timer page
            lblLatestTime.Text = "Latest Crash Time: " + Preferences.Get(CueConstants.CrashTimePrefKey, "No recent crash times");
            base.OnAppearing();
        }

        private async void CoffeeClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChooseTypePage(new SizesCoffeehouse(), coeff));
        }

        private async void FastFoodClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChooseTypePage(new SizesFastFood(), coeff));
        }

        private async void DonutClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChooseTypePage(new SizesDonut(), coeff));
        }

        private async void BottleClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChooseTypePage(new SizesBottle(), coeff));
        }

        private async void CanClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChooseTypePage(new SizesCan(), coeff));
        }

        private async void InstantClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OuncePage(coeff, 11.0));
        }

        private async void CustomAmountClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CustomAmountPage(coeff));
        }

        private async void HourEnergyClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HourEnergyPage());
        }

        private async void SodaClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChooseTypePage(new SizesSoda(), coeff));
        }

        private async void PersonalizeClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ConfigPage());
        }

        private async void ResetClicked(object sender, EventArgs e)
		{
            string updatedCrashTimeText = Preferences.Get(CueConstants.CrashTimePrefKey, "");
            long crashCueMillis = Preferences.Get(CueConstants.CrashCueLongKey, 0L);

            if (updatedCrashTimeText == "")
			{
                await DisplayAlert("Crash Cue", "No crash cue data found for a reset", "OK");
			}
            else
			{
                bool setNotif = await DisplayAlert("Crash Cue", "Reset notification " + CueConstants.CueTime.ToString() + " minutes before " + updatedCrashTimeText, "OK", "Cancel");
                if (setNotif)
				{
                    DependencyService.Get<ICrashAlarm>().SetAlarm(crashCueMillis, updatedCrashTimeText);
                }
            }
        }

        private async void TestClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TimePage());
        }
    }
}
