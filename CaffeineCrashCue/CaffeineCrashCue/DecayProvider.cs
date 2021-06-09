namespace CaffeineCrashCue
{
    public sealed class DecayProvider
    {
        private static DecayProvider instance = null;
		private static readonly object padlock = new object();

		private double oldAmount = -1;
		private double decayRate = -1;
		private double halfLife = -1;
		private long startTime = -1;

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
			if (halfLife == -1)
			{
				return false;
			}
			else if (currentTime - startTime > halfLife)
			{
				halfLife = -1;
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
