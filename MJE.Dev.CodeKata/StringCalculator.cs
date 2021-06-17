using System;
using System.Linq;

namespace MJE.Dev.CodeKata
{
    public class StringCalculator
    {

        private int _calledCount = 0;
        public  int Add(string value)
        {
            _calledCount++;
            
            char[] GetDelims()
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

            static void ValidateNumericValues(int[] ints)
            {
                var negativeNumericValues = ints.Where(x => x < 0).ToArray();

                if (negativeNumericValues.Any())
                {
                    throw new Exception($"negatives not allowed {string.Join(",", negativeNumericValues)}");
                }
            }

            if (string.IsNullOrWhiteSpace(value))
            {
                return 0;
            }

            var actualDelim = GetDelims();

            var nums =
                value
                    .Split(actualDelim, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .Select(int.Parse).ToArray();

            ValidateNumericValues(nums);

            return nums.Sum();
        }

        public int GetCalledCount()
        {
            return _calledCount;
        }

        public event Action<string, int> AddOccurred;
    }
}