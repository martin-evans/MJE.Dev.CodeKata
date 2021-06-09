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
            var res = StringCalculator.Add(numberString);

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
                StringCalculator.Add(numberString);
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

            for (var i = 0; i <= 3; i++)
            {
                var _ = StringCalculator.Add(i.ToString());
            }

            var res = stringCalculator.GetCalledCount();

            Assert.AreEqual(3, res);
        }
    }

    public class StringCalculator
    {
        public static int Add(string value)
        {
            char[] GetDelims()
            {
                char delim = default;

                if (value.StartsWith("//"))
                {
                    delim = value[2];

                    value = value.Remove(0, 3);
                }

                var chars = delim != default ? new[] {delim} : new[] {',', '\n'};
                return chars;
            }

            static void ValidateNumericValues(int[] ints)
            {
                var negativeNumericValues = ints.Where(x => x < 0).ToArray();

                if (negativeNumericValues.Any())
                {
                    throw new Exception($"negatives not allowed {string.Join(",", negativeNumericValues)}");
                }
            }

            if (string.IsNullOrWhiteSpace(value))
            {
                return 0;
            }

            var actualDelim = GetDelims();

            var nums =
                value
                    .Split(actualDelim, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .Select(int.Parse).ToArray();

            ValidateNumericValues(nums);

            return nums.Sum();
        }

        public int GetCalledCount()
        {
            return 0;
        }
    }
}
