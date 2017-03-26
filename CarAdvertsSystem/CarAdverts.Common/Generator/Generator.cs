using System.Collections.Generic;

namespace CarAdverts.Common.Generator
{
    public class Generator : IGenerator
    {
        public IEnumerable<int> NumbersGenerator(int min, int max)
        {
            if (min > max)
            {
                var temp = min;
                min = max;
                max = temp;
            }

            var numbers = new List<int>();

            for (int i = max; i >= min; i--)
            {
                numbers.Add(i);
            }

            return numbers;
        }
    }
}
