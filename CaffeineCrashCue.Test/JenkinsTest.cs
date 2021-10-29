using System;
using NUnit.Framework;

namespace CaffeineCrashCue.Jenkins
{
	[TestFixture]
	public class JenkinsTest
	{
		[Test]
		[TestCase(2, 4, 16)]
		public void DoesJenkinsAggregateMetrics(double x, double y, double expected)
		{
			JenkinsPower resultTest = new JenkinsPower();

			double result = resultTest.Power(x, y);

			Assert.AreEqual(expected, result);
		}

		[Test]
		public void WarningForJenkins()
		{
			Assert.Warn("Warning for Jenkins");
		}
	}
}
