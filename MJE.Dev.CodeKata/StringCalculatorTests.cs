using NUnit.Framework;
using System;
using System.Linq;

namespace CCG.Dev.CodeKata
{
    public class StringCalculatorTests
    {     

        [Test]
        public void AddTakesEmptyStringReturnsZero()
        {            
            int sum = StringCalculator.Add("");

            Assert.AreEqual(0, sum);
        }

        [Test]
        public void AddTakesOneReturnsOne() {
            
            int sum = StringCalculator.Add("1");

            Assert.AreEqual(1, sum);
        }

        [Test]
        public void AddTakesCsvValueReturnsSum()
        {
            int sum = StringCalculator.Add("1,2");

            Assert.AreEqual(3, sum);
        }

        [Test]
        public void AddTakesRandomCsvValueReturnsSum() {

            int sum = StringCalculator.Add("18,24,4");

            Assert.AreEqual(46, sum);
        }


        [Test]
        public void AddTakesAnotherRandomCsvValueReturnsSum()
        {            
            int sum = StringCalculator.Add("18,24,4,66");

            Assert.AreEqual(112, sum);
        }

        [Test]
        public void AddHAndlesNewLinesBetweenNumbers()
        {

            int sum = StringCalculator.Add("1\n2,3");

            Assert.AreEqual(6, sum);

        }

    }

    internal class StringCalculator
    {        
        static internal int Add(string numberString)
        {            
            return string.IsNullOrEmpty(numberString) 
                ? 0 : numberString.Split(",").Select(int.Parse).Sum();
        }
    }
}