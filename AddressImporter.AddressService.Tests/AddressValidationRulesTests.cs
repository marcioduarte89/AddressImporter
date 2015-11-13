using AddressImporter.Common.Interfaces.Services;
using NUnit.Framework;
using AddressImporter.AddressService.ValidationRules;

namespace AddressImporter.Data.Tests
{
    public class AddressValidationRulesTests
    {

        //sut == System Under Test
        private IAddressValidationRules _sut;
        [SetUp]
        public void Initialize()
        {
            _sut = new AddressValidationRules();
        }

        [Test]
        public void AddressValidationRule_PostalCodeIsNull_PostalCodeIsInvalidTest()
        {
            //AAA Rule

            //Arrange
            string postalCode = null;
           
            //Act
            bool result = _sut.IsAddressValid(postalCode);

            //Assert
            Assert.AreEqual(result, false);
        }


        [Test]
        public void AddressValidationRule_PostalCodeHasSpecialCharacters_PostalCodeIsInvalidTest()
        {
            //AAA Rule

            //Arrange
            string postalCode = "rg1 $1e";

            //Act
            bool result = _sut.IsAddressValid(postalCode);

            //Assert
            Assert.AreEqual(result, false);
        }

        [Test]
        public void AddressValidationRule_PostalCodeHasDoesntHaveWhiteSpaces_PostalCodeIsInvalidTest()
        {
            //AAA Rule

            //Arrange
            string postalCode = "Rg11eg";

            //Act
            bool result = _sut.IsAddressValid(postalCode);

            //Assert
            Assert.AreEqual(result, false);
        }

        [Test]
        public void AddressValidationRule_PostalCodeHasMoreThan2WhiteSpaces_PostalCodeIsInvalidTest()
        {
            //AAA Rule

            //Arrange
            string postalCode = "Rg1 1EG ER2";

            //Act
            bool result = _sut.IsAddressValid(postalCode);

            //Assert
            Assert.AreEqual(result, false);
        }

        [Test]
        public void AddressValidationRule_PostalCodeHasLessThanSixCharacters_PostalCodeIsInvalidTest()
        {
            //AAA Rule

            //Arrange
            string postalCode = "Rg1 er";

            //Act
            bool result = _sut.IsAddressValid(postalCode);

            //Assert
            Assert.AreEqual(result, false);
        }

        [Test]
        public void AddressValidationRule_PostalCodeHasMoreThan8Characters_PostalCodeIsInvalidTest()
        {
            //AAA Rule

            //Arrange
            string postalCode = "Rg13 34345";

            //Act
            bool result = _sut.IsAddressValid(postalCode);

            //Assert
            Assert.AreEqual(result, false);
        }

        [Test]
        public void AddressValidationRule_PostalCodeLeftSideHasLessThan2Characters_PostalCodeIsInvalidTest()
        {
            //AAA Rule

            //Arrange
            string postalCode = "R erer";

            //Act
            bool result = _sut.IsAddressValid(postalCode);

            //Assert
            Assert.AreEqual(result, false);
        }

        [Test]
        public void AddressValidationRule_PostalCodeLeftSideHasMoreThan4Characters_PostalCodeIsInvalidTest()
        {
            //AAA Rule

            //Arrange
            string postalCode = "R32 dered";

            //Act
            bool result = _sut.IsAddressValid(postalCode);

            //Assert
            Assert.AreEqual(result, false);
        }

        [Test]
        public void AddressValidationRule_PostalCodeLeftSideIsDifferentThan3Characters_PostalCodeIsInvalidTest()
        {
            //AAA Rule

            //Arrange
            string postalCode = "RG1 esre";

            //Act
            bool result = _sut.IsAddressValid(postalCode);

            //Assert
            Assert.AreEqual(result, false);
        }

        [Test]
        public void AddressValidationRule_PostalCodeLeftSideIsDifferentThan3Characters_PostalCodeIsValidTest()
        {
            //AAA Rule

            //Arrange
            string postalCode = "RG1 1EG";

            //Act
            bool result = _sut.IsAddressValid(postalCode);

            //Assert
            Assert.AreEqual(result, true);
        }

    }
}
