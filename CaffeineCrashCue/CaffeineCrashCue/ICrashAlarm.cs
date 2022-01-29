
namespace CaffeineCrashCue
{
    public interface ICrashAlarm
    {
        void SetAlarm(long crashMillis, string cueText, bool setPref = true);
        void DeleteAlarm();

        /// <summary>
        /// Generate the cue time by subtracting the cue constant from the crash time, then adding it to the Java.Lang.JavaSystem.CurrentTimeMillis() 
        /// </summary>
        long GenerateCrashCueMillis(double crashTime);

        long GetCurrentTimeMillis();
    }
}
