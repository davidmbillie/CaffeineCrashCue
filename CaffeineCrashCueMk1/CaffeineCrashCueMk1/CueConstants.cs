namespace CaffeineCrashCueMk1
{
	public static class CueConstants
	{
		//amount of minutes to warn before the crash happens
		public const int cueTime = 20;
		public const string Description = "Caffeine Crash Cue channel";
		public const string Id = "CaffeineCrash";
		public static readonly string Message = $"Your caffeine crash will occur in about {cueTime} minutes";
		public const string Title = "Caffeine Crash Cue";
		public const int uniqueId = 196418;
		public const string EspressoShot = "EspressoShot";
		public const string CoeffPrefKey = "F_coeff";
		public const string CrashTimePrefKey = "L_crashTime";
		public const string BackgroundImage = "drawable/caffBack.png";
	}
}
