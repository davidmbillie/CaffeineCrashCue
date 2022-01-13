using System;

namespace CaffeineCrashProvider
{
    public static class Formulas
    {
        public static double CalculateCrash(double coefficient, double amount)
        {
            double crashTime = coefficient * Math.Log(amount, 2.875);
            if (crashTime < 0)
            {
                //a double can store negative infinity from the log(0), but I'd rather not pass that around
                return 0;
            }
            else if (crashTime > 6)
            {
                return 6;
            }
            else
            {
                return crashTime;
            }
        }

        public static double CalculateCoefficient(params double[] subCoeffs)
        {
            double coeff = 1;
            foreach (double val in subCoeffs)
            {
                coeff *= val;
            }
            return coeff;
        }

        public static double WeightFactor(double weight)
        {
            double weightfactor = weight - 150;
            return 1 + (0.003434307937522 * weightfactor);
        }
    }
}
