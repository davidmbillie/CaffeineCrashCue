namespace CaffeineCrashCue
{
	public static class CueConstants
	{
		//amount of minutes to warn before the crash happens
		public static int CueTime { get { return 20; } }
		public static int MinToMs { get { return 60000; } }
		public static int HoursToMs { get { return 3600000; } }
		public static string Description { get { return "Caffeine Crash Cue channel"; } }
		public static string NotifId { get { return "CaffeineCrash"; } }
		public static string NotifMessage { get { return "Your caffeine crash will occur at about "; } }
		public static string NotifTitle { get { return $"{CueTime} Minute Crash Cue"; } }
		public static int UniqueId { get { return 196418; } }
		public static string EspressoShot { get { return "EspressoShot"; } }
		//constants for pref keys used in more than one class
		public static string CoeffPrefKey { get { return "F_coeff"; } }
		public static string CrashTimePrefKey { get { return "L_crashTime"; } }
		public static string ExtendedReleaseKey { get { return "A_extended"; } }
		public static string BackgroundImage { get { return "drawable/caffBack.png"; } }
	}
}
