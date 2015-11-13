using System.Text.RegularExpressions;
using AddressImporter.Common.Interfaces.Services;

namespace AddressImporter.AddressService.ValidationRules
{
    public class AddressValidationRules : IAddressValidationRules
    {
        /// <summary>
        /// Address Validation
        /// 
        /// Reference From:
        /// https://en.wikipedia.org/wiki/Postcodes_in_the_United_Kingdom
        /// </summary>
        /// <param name="postalCode"></param>
        /// <returns></returns>
        public bool IsAddressValid(string postalCode)
        {
            //General Rules
            if (string.IsNullOrEmpty(postalCode)) return false;

            if (!Regex.Match(postalCode.Replace(" ", ""), "^[a-zA-Z0-9]*$", RegexOptions.IgnoreCase).Success) return false;

            string[] splitedPostalCode = postalCode.Split(' ');

            if (splitedPostalCode.Length != 2) return false;

            if ((splitedPostalCode[0].Length) + (splitedPostalCode[0].Length) > 8 ||
                (splitedPostalCode[0].Length) + (splitedPostalCode[0].Length) < 6) return false;

            if (splitedPostalCode[0].Length < 2 || splitedPostalCode[0].Length > 4) return false;


            if (splitedPostalCode[1].Length != 3) return false;

            return true;
        }
    }
}
