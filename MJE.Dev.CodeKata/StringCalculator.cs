using System;
using System.Collections.Generic;
using System.Linq;

namespace MJE.Dev.CodeKata
{
    public class StringCalculator
    {

        private int _calledCount = 0;
        public  int Add(string value)
        {
            _calledCount++;

            if (string.IsNullOrWhiteSpace(value))
            {
                AddOccurred?.Invoke(value, 0);
                return 0;
            }

            var actualDelim = GetDelims(ref value);

            var nums =
                value
                    .Split(actualDelim, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .Select(int.Parse).ToArray();

            ValidateNumericValues(nums);

            var sum = nums.Sum();

            AddOccurred?.Invoke(value, sum);

            return sum;
        }

        private static void ValidateNumericValues(IEnumerable<int> ints)
        {
            var negativeNumericValues = ints.Where(x => x < 0).ToArray();

            if (negativeNumericValues.Any())
            {
                throw new Exception($"negatives not allowed {string.Join(",", negativeNumericValues)}");
            }
        }

        private static char[] GetDelims(ref string value)
        {
            char delim = default;

            if (value.StartsWith("//"))
            {
                delim = value[2];

                value = value.Remove(0, 3);
            }

            var chars = delim != default ? new[] {delim} : new[] {',', '\n'};
            return chars;
        }

        public int GetCalledCount()
        {
            return _calledCount;
        }

        public event Action<string, int> AddOccurred;
    }
}
