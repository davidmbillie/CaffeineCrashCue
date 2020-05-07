using System;
using Xunit;

namespace CaffeineCrashProvider
{
    public class FormulasTest
    {
        [Fact]
        public void CalculateCrash_ReturnsIntuitiveValue()
        {
            double result = Formulas.CalculateCrash(1, 80);
            Assert.Equal(4.15, Math.Round(result, 2));
        }

        [Fact]
        public void CalculateCrash_ReturnsIntuitiveValueWithHighCoeff()
        {
            double result = Formulas.CalculateCrash(1.34, 80);
            Assert.Equal(5.56, Math.Round(result, 2));
        }

        [Fact]
        public void CalculateCrash_ReturnsIntuitiveValueWithLowCoeff()
        {
            double result = Formulas.CalculateCrash(0.79, 80);
            Assert.Equal(3.28, Math.Round(result, 2));
        }

        [Fact]
        public void CalculateCrash_ReturnsMax6()
        {
            double result = Formulas.CalculateCrash(2, 160);
            Assert.Equal(6, result);
        }

        [Fact]
        public void CalculateCrash_ReturnsMin3()
        {
            double result = Formulas.CalculateCrash(0.5, 40);
            Assert.Equal(3, result);
        }

        [Fact]
        public void CalculateCoeff_ReturnsIntuitiveValueFromAllConstants()
        {
            double result = Formulas.CalculateCoefficient(CoefficientConstants.alcohol,
            CoefficientConstants.birthControl, CoefficientConstants.exercized,
            CoefficientConstants.grapefruitJuice, CoefficientConstants.pregnant,
            CoefficientConstants.smoker, CoefficientConstants.vegetableAndGrilledChickenDiet);

            Assert.Equal(1.17, Math.Round(result, 2));
        }

        [Fact]
        public void WeightSubCoeff_ReturnsBaseline()
        {
            double result = Formulas.WeightSubCoeff(150);
            Assert.Equal(1, result);
        }

        [Fact]
        public void WeightSubCoeff_Above150ReturnsIntuitiveValue()
        {
            double result = Formulas.WeightSubCoeff(250);
            Assert.Equal(1.34, Math.Round(result, 2));
        }

        [Fact]
        public void WeightSubCoeff_Below150ReturnsIntuitiveValue()
        {
            double result = Formulas.WeightSubCoeff(90);
            Assert.Equal(0.79, Math.Round(result, 2));
        }
    }
}
