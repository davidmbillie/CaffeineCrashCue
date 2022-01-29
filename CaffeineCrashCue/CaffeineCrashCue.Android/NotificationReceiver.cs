using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace CaffeineCrashCue.Droid
{
    [BroadcastReceiver]
    public class NotificationReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            Intent alarmIntent = new Intent(context, typeof(CrashAlarmReceiver));
            PendingIntent sender = PendingIntent.GetBroadcast(context, CueConstants.UniqueId, alarmIntent, PendingIntentFlags.UpdateCurrent | PendingIntentFlags.Immutable);
            AlarmManager alarmManager = (AlarmManager)context.GetSystemService(Context.AlarmService);
            alarmManager.Cancel(sender);
            Preferences.Set(CueConstants.RepeatStarted, false);
        }
    }
}