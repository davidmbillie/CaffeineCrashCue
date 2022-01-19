
namespace CaffeineCrashCue
{
    public interface IPermissions
    {
        bool IgnoreBatteryAlreadySet();
        void IgnoreBatteryOptimizations();
        bool ExactAlarmAlreadySet();
        void ScheduleExactAlarm();
    }
}
