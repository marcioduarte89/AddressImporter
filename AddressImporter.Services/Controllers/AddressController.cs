using System.Collections.Generic;
using System.Web.Http;
using AddressImporter.Common.Dtos;
using AddressImporter.Common.Interfaces.Services;

namespace AddressImporter.Services.Controllers
{
    public class AddressController : ApiController
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public IEnumerable<NearestAddressDetails> Get(string postalCode, int numberOfIndexes)
        {
            return _addressService.Get(postalCode, numberOfIndexes);
        }
    }
}
