using System.IO;
using System.Net;
using System.Text;
using AddressImporter.Common.Interfaces.Repositories;
using AddressImporter.Entities;
using Newtonsoft.Json;

namespace AddressImporter.Data.Coordinates
{
    public class CoordinatesRepository : ICoordinatesRepository
    {
        private string sURL = "http://uk-postcodes.com/postcode/{0}.json";
        public Entities.Coordinates GetCoordinates(string postalCode)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Format(sURL, postalCode));
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                        PostalCodeDetails postalCodeDetails =
                            JsonConvert.DeserializeObject<PostalCodeDetails>(reader.ReadToEnd());
                        return new Entities.Coordinates()
                        {
                            Easting = postalCodeDetails.geo.easting,
                            Northing = postalCodeDetails.geo.northing
                        };
                    }
                }
            }
            catch (WebException ex)
            {
                //Should Catch the exception and log it..
                return null;
            }
        }
    }
}
