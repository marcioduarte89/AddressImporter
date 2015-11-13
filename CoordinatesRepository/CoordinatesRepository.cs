using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AddressImporter.Common.Repositories;
using AddressImporter.Entities;
using Newtonsoft.Json;

namespace AddressImporter.
{
    public class CoordinatesRepository : ICoordinatesRepository
    {
        private string sURL = "http://uk-postcodes.com/postcode/{0}.json";
        public Coordinates GetCoordinates(string postalCode)
        {

            return new Coordinates()
            {
                Easting = 1000,
                Northing = 2000
            };
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
                        return new Coordinates()
                        {
                            Easting = postalCodeDetails.geo.easting,
                            Northing = postalCodeDetails.geo.northing
                        };
                    }
                }
            }
            catch (WebException ex)
            {
                //Should Catch the exception and do something with it..
            }
            return null;
        }
    }
}
