using System;
using System.Linq;
using NUnit.Framework;

namespace MJE.Dev.CodeKata
{
    public class StringCalculatorTests
    {
        [TestCaseSource(nameof(TestData))]
        public void Add_WithStringValues_ShouldReturnSum(string numberString, int expectedSum)
        {
            var res = new StringCalculator().Add(numberString);

            Assert.AreEqual(expectedSum, res);
        }

        public static object[] TestData =
        {
            new object[] {"", 0},
            new object[] {"1", 1},
            new object[] {"1,2", 3},
            new object[] {"1\n2,3", 6},
            new object[] {"//;\n1;2", 3},
        };

        [Test]
        public void Add_TakesRandomAmountOfNumbers_ReturnsSum()
        {
            var nums = new[] {1, 40, 70, 55, 99, 109};
            var sum = nums.Sum();

            var values = string.Join(",", nums);

            Add_WithStringValues_ShouldReturnSum(values, sum);
        }

        [TestCase("1,-1", "-1")]
        [TestCase("1,-1,3,-2", "-1,-2")]
        public void Add_WithNegativeStringValues_ShouldThrow(string numberString, string expectedValues)
        {
            var expectedMessage = $"negatives not allowed {expectedValues}";

            try
            {
                new StringCalculator().Add(numberString);
            }
            catch (Exception e) when (e.Message.Equals(expectedMessage))
            {
                Assert.Pass();
            }
            catch
            {
                Assert.Fail($"Expected Message : {expectedMessage} ");
            }
        }

        [Test]
        public void GetCalledCount_ReturnsAmountOfTimesAddCalled()
        {
            var stringCalculator = new StringCalculator();

            var expected = 0;
            for (var i = 0; i <= 99; i++)
            {
                expected++;
                
                var _ = stringCalculator.Add(i.ToString());
            }

            var res = stringCalculator.GetCalledCount();

            Assert.AreEqual(expected, res);
        }
    }
}
