
namespace CaffeineCrashCueMk1
{
	public interface ICrashAlarm
	{
		void SetAlarm(long crashMillis, string cueText);
		long GenerateCrashCueMillis(double crashTime);
	}
}
