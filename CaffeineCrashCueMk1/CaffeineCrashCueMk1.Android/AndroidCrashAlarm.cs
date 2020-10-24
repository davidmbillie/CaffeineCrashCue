using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
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

			PendingIntent pendingIntent = PendingIntent.GetBroadcast(context, AndroidConstants.uniqueId, alarmIntent, PendingIntentFlags.UpdateCurrent);
			AlarmManager alarmManager = (AlarmManager)context.GetSystemService(Context.AlarmService);

			alarmManager.SetExact(AlarmType.RtcWakeup, crashMillis, pendingIntent);
		}
	}
}