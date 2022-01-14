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
            var pending = PendingIntent.GetActivity(context, CueConstants.UniqueId, resultIntent, PendingIntentFlags.UpdateCurrent);
            resultIntent.SetFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask);

            //If a longer message is warranted in the future...
            //Notification.BigTextStyle bigTextStyle = new Notification.BigTextStyle();

            var builder = new Notification.Builder(context, CueConstants.NotifId)
                .SetContentIntent(pending)
                .SetContentTitle(title)
                .SetSmallIcon(Resource.Drawable.coffee)
                .SetContentText(message)
                .SetWhen(Java.Lang.JavaSystem.CurrentTimeMillis())
                .SetShowWhen(true)
                .SetAutoCancel(true);
            //TODO: SetWhen/SetShowWhen could be revisited for showing timestamps, but they currently aren't functional

            builder.SetContentIntent(pending);
            var notification = builder.Build();
            var manager = NotificationManager.FromContext(context);
            manager.Notify(CueConstants.UniqueId, notification);
        }
    }
}