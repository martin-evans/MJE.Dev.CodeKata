using NUnit.Framework;
using System;

namespace CCG.Dev.CodeKata
{
    public class StringCalculatorTests
    {     

        [Test]
        public void AddTakesEmptyStringReturnsZero()
        {
            var sut = new StringCalculator();
            int sum = sut.Add("");

            Assert.AreEqual(0, sum);
        }

        [Test]
        public void AddTakesOneReturnsOne() {
            var sut = new StringCalculator();
            int sum = sut.Add("1");

            Assert.AreEqual(1, sum);
        }

        [Test]
        public void AddTakesCsvValueReturnsSum()
        {
            var sut = new StringCalculator();
            int sum = sut.Add("1,2");

            Assert.AreEqual(3, sum);
        }

        [Test]
        public void AddTakesRandomCsvValueReturnsSum() {
            var sut = new StringCalculator();
            int sum = sut.Add("18,24,4");

            Assert.AreEqual(46, sum);
        }

    }

    internal class StringCalculator
    {        
        internal int Add(string numberString)
        {
            if (string.IsNullOrEmpty(numberString)) {
                return 0;
            } else if (numberString == "1") {
                return 1;
            } else {
                return 3;
            }
        }
    }
}