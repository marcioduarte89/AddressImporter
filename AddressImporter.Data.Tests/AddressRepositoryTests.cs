using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NUnit.Framework;
using Moq;
using AddressImporter.Data.Repositories;
using AddressImporter.Common.Interfaces;
using AddressImporter.Common.Interfaces.Contexts;
using AddressImporter.Common.Interfaces.Repositories;
using AddressImporter.Common.Interfaces.Services;
using AddressImporter.Entities;

namespace AddressImporter.Data.Tests
{
    public class AddressRepositoryTests
    {
        [Test]
        public void AddressRepositoryTests_AddressCollectionIsNull_ThrowsExceptionTest()
        {
            Mock<IAddressImporterContext> _mockContext = new Mock<IAddressImporterContext>();
            Mock<ICacheProvider> _mockCacheProvider = new Mock<ICacheProvider>();
            IAddressRepository _sut = new AddressRepository(_mockContext.Object, _mockCacheProvider.Object);
            List<Address> addresses = null;
            Assert.Throws<ArgumentNullException>(() => _sut.Add(addresses));
        }

        //[Test]
        //public void AddressRepositoryTests_GetNearestAddresses_ReturnNearestAddresses()
        //{
            
        //    List<Address> addresses = null;

        //    List<NearestAddressDetails> expectedListResult = new List<NearestAddressDetails>()
        //    {
        //        new NearestAddressDetails()
        //        {
        //            Distance = 7,
        //            PostalCode = "Rg1 3EG"
        //        },
        //        new NearestAddressDetails()
        //        {
        //            Distance = 10,
        //            PostalCode = "Rg1 2EG"
        //        },
        //    };

        //    var addressCol = new List<Address>()
        //    {
        //        new Address()
        //        {
        //            Id=1,
        //            PostalCode = "Rg1 1EG"
        //        },
        //        new Address()
        //        {
        //            Id=2,
        //            PostalCode = "Rg1 2EG"
        //        },
        //        new Address()
        //        {
        //            Id=3,
        //            PostalCode = "Rg1 3EG"
        //        }
        //    }.AsQueryable();

        //    var addressConnections = new List<AddressConnections>()
        //    {
        //        new AddressConnections()
        //        {
        //            InitialAddressId = 1,
        //            FinalAddressId = 2,
        //            Distance = 10
        //        },
        //        new AddressConnections()
        //        {
        //            InitialAddressId = 1,
        //            FinalAddressId = 3,
        //            Distance = 7
        //        },
        //        new AddressConnections()
        //        {
        //            InitialAddressId = 2,
        //            FinalAddressId = 1,
        //            Distance = 10
        //        },
        //        new AddressConnections()
        //        {
        //            InitialAddressId = 2,
        //            FinalAddressId = 3,
        //            Distance = 15
        //        },
        //        new AddressConnections()
        //        {
        //            InitialAddressId = 3,
        //            FinalAddressId = 1,
        //            Distance = 7
        //        },
        //        new AddressConnections()
        //        {
        //            InitialAddressId = 3,
        //            FinalAddressId = 2,
        //            Distance = 15
        //        },
        //    }.AsQueryable();

        //    var mockSetAddresses = new Mock<DbSet<Address>>();
        //    mockSetAddresses.As<IQueryable<Address>>().Setup(m => m.Provider).Returns(addressCol.Provider);
        //    var mockSetAddressesConnections = new Mock<DbSet<AddressConnections>>();
        //    mockSetAddressesConnections.As<IQueryable<Address>>().Setup(m => m.Provider).Returns(addressConnections.Provider);

        //    var _mockContext = new Mock<IAddressImporterContext>();
        //    var _mockCacheProvider = new Mock<ICacheProvider>();
        //    _mockContext.Setup(x => x.Addresses).Returns(mockSetAddresses.Object);
        //    _mockContext.Setup(x => x.AddressConnections).Returns(mockSetAddressesConnections.Object);

        //    var _sut = new AddressRepository(_mockContext.Object, _mockCacheProvider.Object);
        //    var result = _sut.Get("Rg1 1EG", 2);

        //    Assert.AreEqual(result, expectedListResult);

        //}

    }
}
