using System;
using System.Linq;
using NUnit.Framework;

namespace MJE.Dev.CodeKata
{
    public class StringCalculatorTests
    {
        [Test]
        public void Add_TakesString_ReturnsInt()
        {
            var stringCalculator = new StringCalculator();

            int res = stringCalculator.Add("");
        }

        [Test]
        public void Add_TakesEmptyString_ReturnsZero()
        {
            var stringCalculator = new StringCalculator();

            var res = stringCalculator.Add(string.Empty);

            Assert.AreEqual(res, 0);
        }

        [Test]
        public void Add_TakesOne_ReturnsOne()
        {
            var stringCalculator = new StringCalculator();

            var res = stringCalculator.Add("1");

            Assert.AreEqual(res, 1);
        }

        [Test]
        public void Add_TakesCsvString_ReturnsSum()
        {
            var stringCalculator = new StringCalculator();

            var res = stringCalculator.Add("1,2");

            Assert.AreEqual(res, 3);
        }

        [Test]
        public void Add_TakesRandomAmountOfNumbers_ReturnsSum()
        {
            var nums = new[] {1, 40, 70, 55, 99, 109};
            var sum = nums.Sum();

            var values = string.Join(",", nums);

            var stringCalculator = new StringCalculator();

            var res = stringCalculator.Add(values);

            Assert.AreEqual(sum, res);
        }

        [Test]
        public void Add_TakesCsvOrNewLineString_ReturnsSum()
        {
            var stringCalculator = new StringCalculator();

            var res = stringCalculator.Add("1\n2,3");

            Assert.AreEqual(res, 6);
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

            var nums = value.Split(',', StringSplitOptions.RemoveEmptyEntries|StringSplitOptions.TrimEntries);

            return nums.Select(int.Parse).Sum();
        }
    }
}
