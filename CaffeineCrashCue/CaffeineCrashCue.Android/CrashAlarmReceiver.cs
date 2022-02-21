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

namespace CaffeineCrashCue.Droid
{
    [BroadcastReceiver(Name = "com.davidmbillie.CaffeineCrashCue")]
    public class CrashAlarmReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            var message = intent.GetStringExtra("message");
            var title = intent.GetStringExtra("title");
            int uniqueId = intent.GetIntExtra("Id", CueConstants.UniqueId);

            //var resultIntent = new Intent(context, typeof(SplashActivity));
            //resultIntent.SetFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask);
            //var pending = PendingIntent.GetActivity(context, uniqueId, resultIntent, PendingIntentFlags.CancelCurrent | PendingIntentFlags.Immutable);

            //If a longer message is warranted in the future...
            //Notification.BigTextStyle bigTextStyle = new Notification.BigTextStyle();

            var builder = new Notification.Builder(context, CueConstants.NotifId)
                //.SetContentIntent(pending)
                .SetContentTitle(title)
                .SetSmallIcon(Resource.Drawable.coffee)
                .SetContentText(message)
                .SetWhen(Java.Lang.JavaSystem.CurrentTimeMillis())
                .SetShowWhen(true)
                .SetAutoCancel(true);
            //TODO: SetWhen/SetShowWhen could be revisited for showing timestamps, but they currently aren't functional

            var notification = builder.Build();
            var manager = NotificationManager.FromContext(context);
            manager.Notify(uniqueId, notification);

            Preferences.Set(CueConstants.AlarmStarted, false);
        }
    }
}