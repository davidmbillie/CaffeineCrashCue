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

using CaffeineCrashCueMk1.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidCrashAlarm))]
namespace CaffeineCrashCueMk1.Droid
{
	public class AndroidCrashAlarm : ICrashAlarm
	{
		public void SetAlarm(long crashMillis)
		{
			Context context = Android.App.Application.Context;

			Intent alarmIntent = new Intent(context, typeof(CrashAlarmReceiver));
			alarmIntent.PutExtra("title", AndroidConstants.Title);
			alarmIntent.PutExtra("message", AndroidConstants.Message);
			alarmIntent.PutExtra("Id", AndroidConstants.uniqueId);

			bool alreadyExists = (PendingIntent.GetBroadcast(context, AndroidConstants.uniqueId, alarmIntent, PendingIntentFlags.NoCreate) != null);

			PendingIntent pendingIntent = PendingIntent.GetBroadcast(context, AndroidConstants.uniqueId, alarmIntent, PendingIntentFlags.UpdateCurrent);
			AlarmManager alarmManager = (AlarmManager)context.GetSystemService(Context.AlarmService);

			if (alreadyExists)
			{
				alarmManager.Cancel(pendingIntent);
			}

			alarmManager.SetExactAndAllowWhileIdle(AlarmType.RtcWakeup, crashMillis, pendingIntent);
		}

		public long GenerateCrashCueMillis(double crashTime)
		{
			long crashLong = Convert.ToInt64(crashTime);
			long cueTimeMillis = 60000 * AndroidConstants.cueTime;
			return Java.Lang.JavaSystem.CurrentTimeMillis() + crashLong - cueTimeMillis;
		}
	}
}