namespace CaffeineCrashCue
{
	public static class CueConstants
	{
		//amount of minutes to warn before the crash happens
		public const int cueTime = 20;
		public const int minToMs = 60000;
		public const int hoursToMs = 3600000;
		public const string Description = "Caffeine Crash Cue channel";
		public const string Id = "CaffeineCrash";
		public static readonly string Message = $"Your caffeine crash will occur at about ";
		public const string Title = "Caffeine Crash Cue";
		public const int uniqueId = 196418;
		public const string EspressoShot = "EspressoShot";
		//constants for pref keys used in more than one class
		public const string CoeffPrefKey = "F_coeff";
		public const string CrashTimePrefKey = "L_crashTime";
		public const string ExtendedReleaseKey = "a_Extended";
		public const string BackgroundImage = "drawable/caffBack.png";
	}
}
