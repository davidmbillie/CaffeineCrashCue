using System;
using Xunit;

namespace CaffeineCrashCue.Jenkins
{
    public class JenkinsTest
    {
        [Theory]
        [InlineData(2, 4, 16)]
        public void Raise_Base_To_Power(double x, double y, double expected)
        {
            JenkinsPower resultTest = new JenkinsPower();

            double result = resultTest.Power(x, y);

            Assert.Equal(expected, result);
        }
    }
}
