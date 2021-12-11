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
            double result = Formulas.CalculateCrash(8, 480);
            Assert.Equal(6, result);
        }

        [Fact]
        public void CalculateCrash_ReturnsMin3()
        {
            double result = Formulas.CalculateCrash(0.25, 16);
            Assert.Equal(3, result);
        }

        [Fact]
        public void CalculateCrash_ReturnsIntuitiveValueWithColaCan()
        {
            double result = Formulas.CalculateCrash(1, 29);
            Assert.True(result > 3);
        }
        [Fact]
        public void CalculateCoeff_ReturnsIntuitiveValueFromAllConstants()
        {
            double result = Formulas.CalculateCoefficient(CoefficientConstants.alcohol,
            CoefficientConstants.birthControl, CoefficientConstants.exercise,
            CoefficientConstants.grapefruitJuice, CoefficientConstants.pregnant,
            CoefficientConstants.smoker, CoefficientConstants.vegetableAndGrilledChickenDiet);

            Assert.Equal(1.17, Math.Round(result, 2));
        }

        [Fact]
        public void WeightFactor_ReturnsBaseline()
        {
            double result = Formulas.WeightFactor(150);
            Assert.Equal(1, result);
        }

        [Fact]
        public void WeightFactor_Above150ReturnsIntuitiveValue()
        {
            double result = Formulas.WeightFactor(250);
            Assert.Equal(1.34, Math.Round(result, 2));
        }

        [Fact]
        public void WeightFactor_Below150ReturnsIntuitiveValue()
        {
            double result = Formulas.WeightFactor(90);
            Assert.Equal(0.79, Math.Round(result, 2));
        }
    }
}
