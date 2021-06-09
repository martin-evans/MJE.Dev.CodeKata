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
            var stringCalculator = new StringCalculator();

            var res = stringCalculator.Add(numberString);

            Assert.AreEqual(expectedSum,res);
        }

        public static object[] TestData = {
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

    }

    public class StringCalculator
    {
        public int Add(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return 0;
            }

            var nums = value.Split(new []{",", "\n"}, StringSplitOptions.RemoveEmptyEntries|StringSplitOptions.TrimEntries);

            return nums.Select(int.Parse).Sum();
        }
    }
}
