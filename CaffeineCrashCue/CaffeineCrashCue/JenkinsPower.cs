using System;

namespace CaffeineCrashCue.Jenkins
{
    public class JenkinsPower : IJenkinsPower
    {
        public double Power(double Base, double Exponent)
        {
            return Math.Pow(Base, Exponent);
        }
    }

    public interface IJenkinsPower
    {
        double Power(double Base, double Exponent);
    }
}
