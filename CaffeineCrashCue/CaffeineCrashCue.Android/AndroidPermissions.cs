using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Icu.Util;
using Android.Net;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Xamarin.Essentials;

using CaffeineCrashCue.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidPermissions))]
namespace CaffeineCrashCue.Droid
{
    public class AndroidPermissions : IPermissions
    {
        public bool IgnoreBatteryAlreadySet()
        {
            Context context = Android.App.Application.Context;
            string packageName = context.PackageName;

            PowerManager powerManager = (PowerManager)context.GetSystemService(Context.PowerService);
            return powerManager.IsIgnoringBatteryOptimizations(packageName);
        }

        public void IgnoreBatteryOptimizations()
        { 
            Context context = Android.App.Application.Context;
            //string packageName = context.PackageName;

            Intent batteryIntent = new Intent();
            batteryIntent.SetFlags(ActivityFlags.NewTask);

            batteryIntent.SetAction(Settings.ActionIgnoreBatteryOptimizationSettings);

            //batteryIntent.SetAction(Settings.ActionRequestIgnoreBatteryOptimizations);
            //batteryIntent.SetData(Android.Net.Uri.Parse("package:" + packageName));

            context.StartActivity(batteryIntent);
        }

        public bool ExactAlarmAlreadySet()
        {
            throw new NotImplementedException();
        }

        public void ScheduleExactAlarm()
        {
            throw new NotImplementedException();
        }
    }
}