
namespace CaffeineCrashCue
{
	public interface ICrashAlarm
	{
		void SetAlarm(long crashMillis, string cueText);
		long GenerateCrashCueMillis(double crashTime);
	}
}
