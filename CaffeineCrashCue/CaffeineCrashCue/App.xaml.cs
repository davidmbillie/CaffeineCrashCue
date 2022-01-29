﻿using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
                BarBackgroundColor = Color.FloralWhite,
                BarBackground = Brush.Transparent,
                BarTextColor = Color.SaddleBrown
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            RefreshAlarmIfNotFinished();
            DeleteRepeatingAlarm();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            RefreshAlarmIfNotFinished();
            DeleteRepeatingAlarm();
        }

        private void RefreshAlarmIfNotFinished()
        {
            if (Preferences.Get(CueConstants.AlarmStarted, false) == true)
            {
                long crashCueMillis = Preferences.Get(CueConstants.CrashCueLongKey, 0L);
                string updatedCrashTimeText = Preferences.Get(CueConstants.CrashTimePrefKey, "");
                DependencyService.Get<ICrashAlarm>().SetAlarm(crashCueMillis, updatedCrashTimeText);
            }
        }

        private void DeleteRepeatingAlarm()
        {
            if (Preferences.Get(CueConstants.RepeatStarted, false) == true)
            {
                DependencyService.Get<ICrashAlarm>().DeleteAlarm();
                Preferences.Set(CueConstants.RepeatStarted, false);
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
