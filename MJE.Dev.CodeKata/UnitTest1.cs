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

    }

    internal class StringCalculator
    {
        public StringCalculator()
        {
        }

        internal int Add(string v)
        {
            return 0;
        }
    }
}