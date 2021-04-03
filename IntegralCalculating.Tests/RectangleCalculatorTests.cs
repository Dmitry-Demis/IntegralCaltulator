using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntegralCalculating;

namespace IntegralCalculating.Tests
{
    [TestClass]
    public class RectangleCalculatorTests
    {
        [TestMethod]
        public void Intergrate_xx_Gives_Correct_Result()
        {
            //arrange
            double expected = 333_333.3333;
            double a = 0;
            double b = 100;
            long n = 100000;
            RectangleCalculator rectangleCalculator = new RectangleCalculator();
            Func<double, double> f = x => x * x;

            //act
            double actual = rectangleCalculator.Calculate(a, b, n, f);

            //assert

            Assert.AreEqual(expected, actual, 0.0001);

        }
        [TestMethod]
        public void Intergrate_xx_Gives_0()
        {
            //arrange
            double expected = 0;
            double a = 0;
            double b = a;

            long n = 100000;
            RectangleCalculator rectangleCalculator = new RectangleCalculator();
            Func<double, double> f = x => x * x;

            //act
            double actual = rectangleCalculator.Calculate(a, b, n, f);

            //assert

            Assert.AreEqual(expected, actual, 0.0001);

        }
        [TestMethod]

        [ExpectedException(typeof(ArgumentException))]
        public void Intergrate_xx_negative_n()
        {
            //arrange
            double expected = default;
            double a = 0;
            double b = a;

            long n = -10;
            RectangleCalculator rectangleCalculator = new RectangleCalculator();
            Func<double, double> f = x => x * x;

            //act
            double actual = rectangleCalculator.Calculate(a, b, n, f);
        }
        [TestMethod]
        public void IntegrateNegativeArguments()
        {
            double expected = 18.666667;
            double a = -4;
            double b = -2;
            long n = 100_000;
            RectangleCalculator rectangleCalculator = new RectangleCalculator();
            Func<double, double> f = x => x * x;
            double actual = rectangleCalculator.Calculate(a, b, n, f);
            Assert.AreEqual(expected, actual, 1e-4);

        }
        [TestMethod]
        public void IntegrateALessB()
        {
            double expected = -25.16667;
            double a = -2.5;
            double b = -4.5;
            long n = 100_000;
            RectangleCalculator rectangleCalculator = new RectangleCalculator();
            Func<double, double> f = x => x * x;
            double actual = rectangleCalculator.Calculate(a, b, n, f);
            Assert.AreEqual(expected, actual, 1e-4);

        }
        [TestMethod]
        public void TrapezeMethod()
        {
            double expected = -21.18765;
            double a = 1;
            double b = 3;

            long n = 100_000;
            TrapezeCalculator trapezeCalculator = new TrapezeCalculator();
            Func<double, double> f = x => 2 * x - Math.Log(7 * x) - 12;

            //act
            double actual = trapezeCalculator.Calculate(a, b, n, f);

            //assert

            Assert.AreEqual(expected, actual, 0.0001);
        }
    }
}
