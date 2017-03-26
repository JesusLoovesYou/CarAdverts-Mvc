using System.Collections.Generic;

namespace CarAdverts.Common.Generator
{
    public interface IGenerator
    {
        IEnumerable<int> NumbersGenerator(int min, int max);
    }
}