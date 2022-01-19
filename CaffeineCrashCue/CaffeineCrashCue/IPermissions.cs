
namespace CaffeineCrashCue
{
    public interface IPermissions
    {
        bool IgnoreBatteryAlreadySet();
        void IgnoreBatteryOptimizations();
        bool CanSetExactAlarmPermission();
        bool ExactAlarmPermissionAlreadySet();
        void RequestScheduleExactAlarm();
    }
}
