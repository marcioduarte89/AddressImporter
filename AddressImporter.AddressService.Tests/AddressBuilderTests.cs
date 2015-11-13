using AddressImporter.Common;
using NUnit.Framework;
using Moq;
using AddressImporter.AddressService.Builders;
using AddressImporter.Common.Interfaces.Repositories;
using AddressImporter.Common.Interfaces.Services;
using AddressImporter.Entities;

namespace AddressImporter.AddressService.Tests
{
    public class AddressBuilderTests
    {
        //sut == System Under Test
        private IAddressBuilder _sut;
        private Mock<ICoordinatesRepository> _mockCoordinatesRepository;
        private Mock<IAddressValidationRules> _mockValidationRules;

        [SetUp]
        public void Initialize()
        {
            _mockCoordinatesRepository = new Mock<ICoordinatesRepository>();
            _mockValidationRules = new Mock<IAddressValidationRules>();
            
        }

        [Test]
        public void AddressBuilderTests_CoordinatesAreNull_ReturnsNullTest()
        {
            //AAA Rule

            //Arrange
            Coordinates nullCoordinates = null;
            _mockCoordinatesRepository.Setup(x => x.GetCoordinates("Rg1 1eg")).Returns(nullCoordinates);
            _sut = new AddressBuilder(_mockCoordinatesRepository.Object, _mockValidationRules.Object);

            //Act
            var result = _sut.BuildAddress("Address line 1", "Address Line 2", "City", "Rg1 1eg");

            //Assert
            Assert.AreEqual(result, null);
        }
    }
}
