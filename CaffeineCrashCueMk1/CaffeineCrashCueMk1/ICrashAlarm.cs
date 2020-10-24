
namespace CaffeineCrashCueMk1
{
	public interface ICrashAlarm
	{
		void SetAlarm(long crashMillis);
		long GenerateCrashMillis(double crashTime);
	}
}
