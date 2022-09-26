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
        [TestCase("1,2,1001,2000,4,1000", 7)]
        [TestCase("1\n2,3", 6)]
        [TestCase("//;\n1;2", 3)]
        [TestCase("//c\n1c2", 3)]
        public void AddReturnsSum(string csvString, int expectedResult) {
            var sum = new StringCalculator().Add(csvString);

            Assert.AreEqual(expectedResult, sum);
        }
        
        
        [TestCase("-1, -2, -3, 1","negatives not allowed : -1, -2, -3")]
        [TestCase("-1, 2, 3, 1","negatives not allowed : -1")]
        [TestCase("-33","negatives not allowed : -33")]
        public void AddThrowsExceptionWhenMultipleNegativeNumbersArePassed(string csvNumberString, string expectedExceptionMessage) {

            Assert.That(() => new StringCalculator().Add(csvNumberString),
                Throws.TypeOf<Exception>()
                    .With.Message.EqualTo(expectedExceptionMessage));

        }

        [Test]
        public void GetCalledCountReturnsNumberOfTimesAddInvoked()
        {
            var stringCalculator = new StringCalculator();
            stringCalculator.Add("1");
            stringCalculator.Add("1");
            stringCalculator.Add("1");
            stringCalculator.Add("1");
            
            Assert.AreEqual(4, stringCalculator.GetCalledCount());

        }

        [Test]
        public void AddOccuredEvent_InvokedAsExpected() { 
            var stringCalculator = new StringCalculator();
            
            stringCalculator.AddOccured += StringCalculator_AddOccured;
            stringCalculator.AddOccured += (s, i) => { Console.WriteLine($"From anonymous method: {s}: {i}");  }; 
            
            stringCalculator.Add("1");
            
        }

        private void StringCalculator_AddOccured(string arg1, int arg2) {
            Console.WriteLine($"From method: {arg1}: {arg2}");
        }

    }

   internal class StringCalculator {
        private int addCount;

        public event Action<string, int> AddOccured;

        internal int Add(string numberString) {
            addCount++;
            AddOccured?.Invoke(numberString, 99);

            var delimeterArray = new List<string>() { "\n", ",", "//" };

            if (numberString.StartsWith("//")) {
                var customDelimeter = numberString.Split(new string[] { "//", "\n" }, StringSplitOptions.RemoveEmptyEntries)[0];
                TestContext.WriteLine(customDelimeter);
                delimeterArray.Add(customDelimeter.ToString());
                TestContext.WriteLine(delimeterArray.ToArray().Length);
            }

            return string.IsNullOrEmpty(numberString)
                ? 0 : numberString
                    .Split(delimeterArray.ToArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .Validate()
                    .Sum();
        }

        public int GetCalledCount() {
            return this.addCount;
        }


    }
    internal static class Validator {
        public static IEnumerable<int> Validate(this IEnumerable<int> numbers) {
            var enumerable = numbers as int[] ?? numbers.ToArray();

            if (enumerable.Any(x => x < 0)) {
                var negativeNumbers = enumerable.Where(y => y < 0).Select(z => z.ToString()).ToArray();

                throw new Exception($"negatives not allowed : {string.Join(", ", negativeNumbers)}");
            };

            return enumerable;
        }
    } 

}