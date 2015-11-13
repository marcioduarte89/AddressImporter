using AddressImporter.Common.Helpers;
using NUnit.Framework;

namespace AddressImporter.Common.Tests
{
    public class MathTests
    {
        [Test]
        public void MathTests_CalculationOfDistanceBetweenTwoValidCoordinates_ReturnCorrectDistanceTest()
        {
            double result = Math.CalculatePythagoreanTheorem(471447, 470135, 173649, 173949);

            Assert.AreEqual(1.35, result);
        }


        [Test]
        public void MathTests_CalculationOfDistanceBetweenTwoValidCoordinates2_ReturnCorrectDistanceTest()
        {
            double result = Math.CalculatePythagoreanTheorem(471447.0, 532531.0, 173649.0, 182390.0);

            Assert.AreEqual(61.71, result);
        }

    }
}
