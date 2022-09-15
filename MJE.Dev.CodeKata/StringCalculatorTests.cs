using NUnit.Framework;
using System;
using System.Collections.Generic;
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
        [TestCase("//;\n1;2", 3)]
        [TestCase("//c\n1c2", 3)]
        public void AddReturnsSum(string csvString, int expectedResult) {
            var sum = StringCalculator.Add(csvString);

            Assert.AreEqual(expectedResult, sum);
        }

        [Test]
        public void AddThrowsExceptionWhenNegativeNumberPassed() {
            Assert.Throws<Exception>(() => { StringCalculator.Add("-1");  });
        }
    }

    internal class StringCalculator
    {        
        static internal int Add(string numberString)
        {
            var delimeterArray = new List<string>() { "\n", ",", "//" };

            if (numberString.StartsWith("//")) {
                var customDelimeter = numberString.Split(new string[] { "//", "\n" }, StringSplitOptions.RemoveEmptyEntries)[0];
                TestContext.WriteLine(customDelimeter);
                delimeterArray.Add(customDelimeter.ToString());
                TestContext.WriteLine(delimeterArray.ToArray().Length);
            }

            return string.IsNullOrEmpty(numberString) 
                ? 0 : numberString.Split(delimeterArray.ToArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Sum();
        }
    }
}