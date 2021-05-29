
namespace CaffeineCrashCue
{
	public interface ICrashAlarm
	{
		void SetAlarm(long crashMillis, string cueText);
		/// <summary>
		/// Generate the cue time by subtracting the cue constant from the crash time, then adding it to the Java.Lang.JavaSystem.CurrentTimeMillis() 
		/// </summary>
		/// <param name="crashTime"></param>
		/// <returns></returns>
		long GenerateCrashCueMillis(double crashTime);

		long GetCurrentTimeMillis();
	}
}
