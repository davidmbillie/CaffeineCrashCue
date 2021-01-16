using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics.Drawables;

namespace CaffeineCrashCueMk1.Droid
{
    [Activity(Label = "CaffeineCrashCueMk1", Icon = "@drawable/caffIcon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
            CreateNotificationChannel();
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

			var channel = new NotificationChannel(CueConstants.Id, CueConstants.Id, NotificationImportance.Default)
			{
				Description = CueConstants.Description
			};

			var notificationManager = (NotificationManager)GetSystemService(NotificationService);
			notificationManager.CreateNotificationChannel(channel);
		}
	}
}