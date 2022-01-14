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
        public static string NotifMessage { get { return "Your crash will occur at about "; } }
        public static string NotifTitle { get { return $"{CueTime} Minute Crash Cue"; } }
        public static int UniqueId { get { return 196418; } }
        public static string EspressoShot { get { return "EspressoShot"; } }

        //constants for pref keys used in more than one class
        public static string CoeffPrefKey { get { return "F_coeff"; } }
        public static string CrashTimePrefKey { get { return "L_crashTime"; } }
        public static string CrashCueLongKey {  get { return "L_crashCueLong";  } }
        public static string ExtendedReleaseKey { get { return "A_extended"; } }
        public static string BackgroundImage { get { return "drawable/caffBack.png"; } }

        //ads
        public static string BannerId { get { return "ca-app-pub-7820129744124687/7434620049"; } }
        public static string AppId { get { return "ca-app-pub-7820129744124687~7256857770"; } }
        public static string TestBannerId { get { return "ca-app-pub-3940256099942544/6300978111"; } }
        public static bool UseTestAds { get { return false; } }
    }
}
