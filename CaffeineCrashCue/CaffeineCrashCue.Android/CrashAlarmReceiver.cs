using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Xamarin.Essentials;
using Xamarin.Forms;

namespace CaffeineCrashCue.Droid
{
    [BroadcastReceiver]
    public class CrashAlarmReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            var message = intent.GetStringExtra("message");
            var title = intent.GetStringExtra("title");

            var resultIntent = new Intent(context, typeof(SplashActivity));
            var pending = PendingIntent.GetActivity(context, CueConstants.UniqueId, resultIntent, PendingIntentFlags.CancelCurrent | PendingIntentFlags.Immutable);
            resultIntent.SetFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask);

            //If a longer message is warranted in the future...
            //Notification.BigTextStyle bigTextStyle = new Notification.BigTextStyle();

            Intent deleteIntent = new Intent(context, typeof(NotificationReceiver));
            PendingIntent deletePendingIntent = PendingIntent.GetBroadcast(context, CueConstants.UniqueId, deleteIntent, PendingIntentFlags.UpdateCurrent | PendingIntentFlags.Immutable);

            var builder = new Notification.Builder(context, CueConstants.NotifId)
                .SetContentIntent(pending)
                .SetContentTitle(title)
                .SetSmallIcon(Resource.Drawable.coffee)
                .SetContentText(message)
                .SetWhen(Java.Lang.JavaSystem.CurrentTimeMillis())
                .SetDeleteIntent(deletePendingIntent)
                .SetShowWhen(true)
                .SetAutoCancel(true);
            //TODO: SetWhen/SetShowWhen could be revisited for showing timestamps, but they currently aren't functional

            var notification = builder.Build();
            //notification.DeleteIntent = PendingIntent.GetBroadcast(context, CueConstants.UniqueId, intent, PendingIntentFlags.CancelCurrent);
            var manager = NotificationManager.FromContext(context);
            manager.Notify(CueConstants.UniqueId, notification);

            Preferences.Set(CueConstants.AlarmStarted, false);

            //Repeat every 5 minutes until stopped by deleting or clicking the notif
            string updatedCrashTimeText = Preferences.Get(CueConstants.CrashTimePrefKey, "");
            DependencyService.Get<ICrashAlarm>().SetAlarm(Java.Lang.JavaSystem.CurrentTimeMillis() + 300000, updatedCrashTimeText, false);

            Preferences.Set(CueConstants.RepeatStarted, true);
        }
    }
}