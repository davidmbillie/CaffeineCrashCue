using System;
using System.Collections.Generic;
using System.Text;

namespace CaffeineCrashProvider.Sizes
{
	public abstract class SizesSet
	{
		public abstract Dictionary<string, double> QuantOnly { get; }
		public abstract string[] Sources { get; }
	}
}
