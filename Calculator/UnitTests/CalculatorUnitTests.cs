using System;
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
            int sum = Calculator.Calculate(input);

            //Assert
            Assert.AreEqual(sum, 0);
        }

        [Test]
        public void TestCalculator_TwoValidNumbers()
        {
            //Arrange
            string input = "1,5";

            //Act
            int sum = Calculator.Calculate(input);

            //Assert
            Assert.AreEqual(sum, 6);
        }

        [Test]
        public void TestCalculator_OneNumber()
        {
            //Arrange
            string input = "7";

            //Act
            int sum = Calculator.Calculate(input);

            //Assert
            Assert.AreEqual(sum, 7);
        }

        [Test]
        public void TestCalculator_FirstValueInvalid()
        {
            //Arrange
            string input = "NaN, 3";

            //Act
            int sum = Calculator.Calculate(input);

            //Assert
            Assert.AreEqual(sum, 3);
        }

        [Test]
        public void TestCalculator_SecondValueInvalid()
        {
            //Arrange
            string input = "1, NaN";

            //Act
            int sum = Calculator.Calculate(input);

            //Assert
            Assert.AreEqual(sum, 1);
        }

        [Test]
        public void TestCalculator_MoreThanTwoValues()
        {
            //Arrange
            string input = "1,3,5,NaN,6,NaN";

            //Act
            int sum = Calculator.Calculate(input);

            //Assert
            Assert.AreEqual(sum, 15);
        }

        [Test]
        public void TestCalculator_NewLineCharDelimiter()
        {
            //Arrange
            string input = "3\\n5,6\\n1";

            //Act
            int sum = Calculator.Calculate(input);

            //Assert
            Assert.AreEqual(sum, 15);
        }
        [Test]
        public void TestCalculator_NegativeNumber()
        {
            //Arrange
            string input = "-3,4,5";

            //Act 
            var exception = Assert.Throws<ArgumentException>(() => Calculator.Calculate(input));

            //Assert
            Assert.AreEqual(exception.Message, "Cannot enter negative numbers. Invalid values: -3");
        }

        [Test]
        public void TestCalculator_GreaterThanOneThousand()
        {
            //Arrange
            string input = "5,1004,9\\n2";

            //Act
            int sum = Calculator.Calculate(input);

            //Assert
            Assert.AreEqual(sum, 16);
        }

        [Test]
        public void TestCalculator_CustomSingleCharacterDelimiter()
        {
            //Arrange
            string input = "//g\n2,7g9g4";

            //Act
            int sum = Calculator.Calculate(input);

            //Assert
            Assert.AreEqual(sum, 22);
        }

        [Test]
        public void TestCalculator_CustomSingleIntegerDelimiter()
        {
            //Arrange
            string input = "//1\n313";

            //Act
            int sum = Calculator.Calculate(input);

            //Assert
            Assert.AreEqual(sum, 6);
        }
    }
}
