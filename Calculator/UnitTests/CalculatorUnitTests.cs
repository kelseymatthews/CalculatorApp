using NUnit.Framework;

namespace Calculator
{
    public class CalculatorUnitTests
    {
        [Test]
        public void TestCalculator_EmptyString()
        {
            //Arrange
            string input = "";

            //Act
            int sum = CalculatorApp.AddNumbers(input);

            //Assert
            Assert.AreEqual(sum, 0);
        }

        [Test]
        public void TestCalculator_TwoValidNumbers()
        {
            //Arrange
            string input = "1,5";

            //Act
            int sum = CalculatorApp.AddNumbers(input);

            //Assert
            Assert.AreEqual(sum, 6);
        }

        [Test]
        public void TestCalculator_OneNumber()
        {
            //Arrange
            string input = "7";

            //Act
            int sum = CalculatorApp.AddNumbers(input);

            //Assert
            Assert.AreEqual(sum, 7);
        }

        [Test]
        public void TestCalculator_FirstValueInvalid()
        {
            //Arrange
            string input = "NaN, 3";

            //Act
            int sum = CalculatorApp.AddNumbers(input);

            //Assert
            Assert.AreEqual(sum, 3);
        }

        [Test]
        public void TestCalculator_SecondValueInvalid()
        {
            //Arrange
            string input = "1, NaN";

            //Act
            int sum = CalculatorApp.AddNumbers(input);

            //Assert
            Assert.AreEqual(sum, 1);
        }
    }
}
