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

namespace CaffeineCrashCueMk1.Droid
{
    [BroadcastReceiver]
    public class CrashAlarmReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            var message = intent.GetStringExtra("message");
            var title = intent.GetStringExtra("title");

            var resultIntent = new Intent(context, typeof(CrashAlarmReceiver));
            var pending = PendingIntent.GetActivity(context, AndroidConstants.uniqueId, resultIntent, PendingIntentFlags.CancelCurrent);
            resultIntent.SetFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask);

            var builder = new Notification.Builder(context, AndroidConstants.Id)
                .SetContentIntent(pending)
                .SetContentTitle(title)
                .SetSmallIcon(Resource.Drawable.notify_panel_notification_icon_bg)
                .SetContentText(message)
                .SetWhen(Java.Lang.JavaSystem.CurrentTimeMillis())
                .SetAutoCancel(true);

            builder.SetContentIntent(pending);
            var notification = builder.Build();
            var manager = NotificationManager.FromContext(context);
            manager.Notify(AndroidConstants.uniqueId, notification);
        }
    }
}