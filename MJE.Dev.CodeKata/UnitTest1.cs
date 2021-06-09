using NUnit.Framework;

namespace CCG.Dev.CodeKata
{
    public class DummyTests
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
    }

    public class StringCalculator
    {
        public int Add(string value)
        {
            return 0;
        }
    }
}
