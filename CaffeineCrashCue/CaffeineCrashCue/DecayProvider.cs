using Xamarin.Essentials;

namespace CaffeineCrashCue
{
    public sealed class DecayProvider
    {
        private static DecayProvider instance = null;
		private static readonly object padlock = new object();

		private const string oldAmountKey = "D_oldAmount";
		private const string decayRateKey = "D_decayRate";
		private const string halfLifeKey = "D_halfLife";
		private const string startTimeKey = "D_startTime";

		private double oldAmount
		{
			get
			{
				return Preferences.Get(oldAmountKey, -1.0);
			}
			set
			{
				Preferences.Set(oldAmountKey, value);
			}
		}

		private double decayRate
		{
			get
			{
				return Preferences.Get(decayRateKey, -1.0);
			}
			set
			{
				Preferences.Set(decayRateKey, value);
			}
		}
		private double halfLife
		{
			get
			{
				return Preferences.Get(halfLifeKey, -1.0);
			}
			set
			{
				Preferences.Set(halfLifeKey, value);
			}
		}
		private long startTime
		{
			get
			{
				return Preferences.Get(startTimeKey, -1L);
			}
			set
			{
				Preferences.Set(startTimeKey, value);
			}
		}

		public static DecayProvider Instance
		{
			get
			{
				lock(padlock)
				{
					if (instance == null)
					{
						instance = new DecayProvider();
					}
				}
				return instance;
			}
		}

		public bool IsReady(long currentTime)
		{
			if (halfLife == -1.0)
			{
				return false;
			}
			else if (currentTime - startTime > halfLife)
			{
				halfLife = -1.0;
				return false;
			}
			else
			{
				return true;
			}
		}

		public void SetDecayVaules(double amount, double crashTime, long currentTime)
		{
			decayRate = (amount / 2) / crashTime;
			oldAmount = amount;
			halfLife = crashTime;
			startTime = currentTime;
		}

		public double GetAdjustedAmount(double newAmount, long currentTime)
		{

			long elapsedTime = currentTime - startTime;
			if (elapsedTime < halfLife)
			{
				double caffeineRemaining = oldAmount - (decayRate * elapsedTime);
				return newAmount + caffeineRemaining;
			}
			else
			{
				//reset for ready check
				halfLife = -1;
				return newAmount;
			}
		}
    }
}
