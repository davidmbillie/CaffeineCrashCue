using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Icu.Util;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Xamarin.Essentials;

using CaffeineCrashCue.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidCrashAlarm))]
namespace CaffeineCrashCue.Droid
{
    public class AndroidCrashAlarm : ICrashAlarm
    {
        public void SetAlarm(long crashCueMillis, string cueText, bool setPref = true)
        {
            Context context = Android.App.Application.Context;

            Intent alarmIntent = new Intent(context, typeof(CrashAlarmReceiver));
            alarmIntent.PutExtra("title", CueConstants.NotifTitle);
            alarmIntent.PutExtra("message", CueConstants.NotifMessage + cueText);
            alarmIntent.PutExtra("Id", CueConstants.UniqueId);

            PendingIntent pendingIntent = PendingIntent.GetBroadcast(context, CueConstants.UniqueId, alarmIntent, PendingIntentFlags.UpdateCurrent | PendingIntentFlags.Immutable);
            AlarmManager alarmManager = (AlarmManager)context.GetSystemService(Context.AlarmService);

            //alarmManager.SetRepeating(AlarmType.RtcWakeup, crashCueMillis, 60000, pendingIntent);
            alarmManager.SetAlarmClock(new AlarmManager.AlarmClockInfo(crashCueMillis, pendingIntent), pendingIntent);

            Preferences.Set(CueConstants.AlarmStarted, setPref);
        }

        public void DeleteAlarm()
        {
            Context context = Android.App.Application.Context;
            Intent alarmIntent = new Intent(context, typeof(CrashAlarmReceiver));
            PendingIntent sender = PendingIntent.GetBroadcast(context, CueConstants.UniqueId, alarmIntent, PendingIntentFlags.UpdateCurrent | PendingIntentFlags.Immutable);
            AlarmManager alarmManager = (AlarmManager)context.GetSystemService(Context.AlarmService);
            alarmManager.Cancel(sender);
        }

        public long GenerateCrashCueMillis(double crashTimeMillis)
        {
            long crashLong = Convert.ToInt64(crashTimeMillis);
            return Java.Lang.JavaSystem.CurrentTimeMillis() + crashLong - CueConstants.CueTimeMs;
        }

        public long GetCurrentTimeMillis()
        {
            return Java.Lang.JavaSystem.CurrentTimeMillis();
        }

        //if (Build.VERSION.SdkInt < Android.OS.BuildVersionCodes.M)
        //{
        //    if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Kitkat)
        //    {
        //        alarmManager.SetExact(AlarmType.RtcWakeup, crashCueMillis, pendingIntent);
        //    }
        //    else
        //    {
        //        alarmManager.Set(AlarmType.RtcWakeup, crashCueMillis, pendingIntent);
        //    }
        //}
        //else
        //{
        //    alarmManager.SetExactAndAllowWhileIdle(AlarmType.RtcWakeup, crashCueMillis, pendingIntent);
        //}
    }
}