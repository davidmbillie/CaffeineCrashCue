using System;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CaffeineCrashCue
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Colors.FloralWhite,
                //BarBackground = Brush.Transparent,
                BarTextColor = Colors.SaddleBrown
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            RefreshAlarmIfNotFinished();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private void RefreshAlarmIfNotFinished()
        {
            if (Preferences.Get(CueConstants.AlarmStarted, false))
            {
                long crashCueMillis = Preferences.Get(CueConstants.CrashCueLongKey, 0L);
                string updatedCrashTimeText = Preferences.Get(CueConstants.CrashTimePrefKey, "");
                DependencyService.Get<ICrashAlarm>().SetAlarm(crashCueMillis, updatedCrashTimeText, CueConstants.UniqueId);
            }
        }

        public bool DoBack
        {
            get
            {
                return MainPage.Navigation.NavigationStack.Count > 1;
            }
        }
    }
}
