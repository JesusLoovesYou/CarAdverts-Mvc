using System.Collections.Generic;
using CarAdverts.Common.Generator;
using NUnit.Framework;

namespace CarAdvertsSystem.UnitTests.CommonTests.GeneratorTests
{
    [TestFixture]
    public class Generator_GenerateSecuential_Numbers_Should
    {
        [TestCase(1, 7)]
        [TestCase(7, 1)]
        public void GenerateCorrectSecuenseOfNumbers(int min, int max)
        {
            // Arrange
            var expectedResult = new List<int>() { 7, 6, 5, 4, 3, 2, 1 };

            var generator = new Generator();

            // Act
            var result = generator.GenerateSecuentialNumbers(min, max);

            // Assert
            Assert.AreEqual(result, expectedResult);
        }
    }
}
