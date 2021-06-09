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
    }

    public class StringCalculator
    {
        public int Add(string empty)
        {
            throw new System.NotImplementedException();
        }
    }
}