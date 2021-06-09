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

        [TestCase("1,-1", "-1")]
        [TestCase("1,-1,3,-2", "-1,-2")]
        public void Add_WithNegativeStringValues_ShouldThrow(string numberString, string expectedValues)
        {
            var stringCalculator = new StringCalculator();

            var expectedMessage = $"negatives not allowed {expectedValues}";

            try
            {
                stringCalculator.Add("-1");
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


    }

    public class StringCalculator
    {
        public int Add(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return 0;
            }

            char delim = default;

            if (value.StartsWith("//"))
            {
                delim = value[2];

                value = value.Remove(0, 3);
            }

            var actualDelim = delim != default ? new [] { delim } : new[] {',', '\n'};

            var nums = value.Split(actualDelim, StringSplitOptions.RemoveEmptyEntries|StringSplitOptions.TrimEntries);

            var numericValues =  nums.Select(int.Parse).ToArray();

            if (numericValues.Any(x=>x < 0))
            {
                throw new Exception($"negatives not allowed {numericValues.First(x=> x <0)}");
            }
            
            return numericValues.Sum();
        }
    }
}
