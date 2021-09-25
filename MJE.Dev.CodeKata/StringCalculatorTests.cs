using System;
using MJE.Dev.CodeKata.FingStringCalculator;
using NUnit.Framework;

namespace MJE.Dev.CodeKata
{
    public class StringCalculatorTests
    {
        [TestCase("", 0)]
        [TestCase("1", 1)]
        [TestCase("1,2", 3)]
        [TestCase("1\n2,3", 6)]
        [TestCase("//;\n1;2;5", 8)]
        public void AddTakesString_ReturnsSum(string csvString, int expectedValue)
        {
            Assert.AreEqual(expectedValue, new StringCalculator().Add(csvString));
        }

        [Test]
        public void NegativesNotAllowed_ExceptionWillBeThrown()
        {
            Assert.Throws(Is.TypeOf<Exception>().And.Message.EqualTo("Negatives not allowed -1,-4"),
                ()=> new StringCalculator().Add("1,2,-1,-4,5"));
        }
        
        [Test]
        public void GetCalledCount_ReturnsNUmberOfTimesAddIsCalled()
        {

            var sut = new StringCalculator();
            
            sut.Add("1,3");
            sut.Add("1,3");
            sut.Add("1,3");
            sut.Add("1,3");
            
            Assert.AreEqual(4, sut.CalledCount);

        }
        
        
    }
}