namespace Algorithms.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PowerCalculatorTest
    {
        private PowerCalculator calculator;

        [TestInitialize]
        public void Initialize()
        {
            this.calculator = new PowerCalculator();
        }

        [TestMethod]
        public void Calculate_PowerOfZero_One()
        {
            Assert.AreEqual(1, this.calculator.Calculate(1, 0));
            Assert.AreEqual(1, this.calculator.Calculate(15, 0));
            Assert.AreEqual(1, this.calculator.Calculate(999, 0));
            Assert.AreEqual(1, this.calculator.Calculate(1234567, 0));
        }

        [TestMethod]
        public void Calculate_PowerOfOne_BaseItself()
        {
            Assert.AreEqual(1, this.calculator.Calculate(1, 1));
            Assert.AreEqual(15, this.calculator.Calculate(15, 1));
            Assert.AreEqual(999, this.calculator.Calculate(999, 1));
            Assert.AreEqual(1234567, this.calculator.Calculate(1234567, 1));
        }

        [TestMethod]
        public void Calculate_CommonCase_BaseOnPowerExp()
        {
            Assert.AreEqual(4, this.calculator.Calculate(2,2));
            Assert.AreEqual(65536, this.calculator.Calculate(16,4));
            Assert.AreEqual(100000000, this.calculator.Calculate(10,8));
        }
    }
}
