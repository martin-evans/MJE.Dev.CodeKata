using NUnit.Framework;
using System;

namespace CCG.Dev.CodeKata
{
    public class DummyTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddTakesStringReturnsSum()
        {
            var sut = new StringCalculator();
            int sum = sut.Add("");

            Assert.AreEqual(0, sum);
        }

    }

    internal class StringCalculator
    {
        public StringCalculator()
        {
        }

        internal int Add(string v)
        {
            throw new NotImplementedException();
        }
    }
}