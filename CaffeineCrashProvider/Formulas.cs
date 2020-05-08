using System;

namespace CaffeineCrashProvider
{
    public static class Formulas
    {
        public static double CalculateCrash(double coefficient, double amount)
        {
            double crashTime = coefficient * Math.Log(amount, 2.875);
            if (crashTime < 3)
            {
                return 3;
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
                coeff = coeff * val;
            }
            return coeff;
        }

        public static double WeightSubCoeff(double weight)
        {
            double weightfactor = weight - 150;
            return 1 + (0.003434307937522 * weightfactor);
        }
        //test4
    }
}
