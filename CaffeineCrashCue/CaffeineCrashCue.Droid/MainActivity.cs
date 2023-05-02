using System;

using Android.App;
using Android.Content.PM;
using Android.Gms.Ads;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using CaffeineCrashCue;

namespace CaffeineCrashCue.Droid
{
    [Activity(Label = "@string/app_name", Icon = "@drawable/caffIcon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : MauiAppCompatActivity
    {
        App app;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            //TabLayoutResource = Resource.Layout.Tabbar;
            //ToolbarResource = Resource.Layout.Toolbar;

            MobileAds.Initialize(ApplicationContext);

            base.OnCreate(savedInstanceState);
            //global::Xamarin.Form.Forms.Init(this, savedInstanceState);
            app = new App();
            //LoadApplication(app);
            CreateNotificationChannel();
        }

        //allow back button to exit from app
        public override void OnBackPressed()
        {
            if (app.DoBack)
            {
                base.OnBackPressed();
            }
            else
            {
                MoveTaskToBack(true);
                Finish();
            }
        }

        private void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                // Notification channels are new in API 26 (and not a part of the
                // support library). There is no need to create a notification
                // channel on older versions of Android.
                return;
            }

            var channel = new NotificationChannel(CueConstants.NotifId, CueConstants.NotifId, NotificationImportance.High)
            {
                Description = CueConstants.Description
            };

            var notificationManager = (NotificationManager)GetSystemService(NotificationService);
            notificationManager.CreateNotificationChannel(channel);
        }
    }
}