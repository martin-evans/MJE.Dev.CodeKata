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
    }

    public class StringCalculator
    {
        public int Add(string value)
        {
            return value == string.Empty ? 0 : 1;
        }
    }
}
