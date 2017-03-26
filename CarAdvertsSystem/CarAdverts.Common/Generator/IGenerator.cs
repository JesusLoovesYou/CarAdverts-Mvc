using System.Collections.Generic;

namespace CarAdverts.Common.Generator
{
    public interface IGenerator
    {
        IEnumerable<int> GenerateSecuentialNumbers(int min, int max);
    }
}