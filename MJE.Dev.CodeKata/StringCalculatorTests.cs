using NUnit.Framework;
using System;
using System.Linq;

namespace CCG.Dev.CodeKata
{
    public class StringCalculatorTests {

        [TestCase("", 0)]
        [TestCase("1", 1)]
        [TestCase("1, 2", 3)]
        [TestCase("18,24,4", 46)]
        [TestCase("18,24,4,66", 112)]
        [TestCase("1\n2,3", 6)]
        public void AddReturnsSum(string csvString, int expectedResult) {
            var sum = StringCalculator.Add(csvString);

            Assert.AreEqual(expectedResult, sum);
        }
    }

    internal class StringCalculator
    {        
        static internal int Add(string numberString)
        {
            return string.IsNullOrEmpty(numberString) 
                ? 0 : numberString.Split(new string[] { "\n", "," }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Sum();
        }
    }
}