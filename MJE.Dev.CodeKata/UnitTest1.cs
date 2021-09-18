using MJE.Dev.CodeKata.FingStringCalculator;
using NUnit.Framework;

namespace MJE.Dev.CodeKata
{
    public class DummyTests
    {
        [TestCase("", 0)]
        [TestCase("1", 1)]
        [TestCase("1,2", 3)]
        public void AddTakesString_ReturnsSum(string csvString, int expectedValue)
        {
            Assert.AreEqual(expectedValue, StringCalculator.Add(csvString));
        }
    }
}