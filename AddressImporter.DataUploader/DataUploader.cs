using System;
using System.Collections.Generic;
using System.IO;
using System.Timers;
using AddressImporter.Common;
using AddressImporter.Common.Interfaces.Services;
using AddressImporter.Entities;
using CsvHelper;

namespace AddressImporter.DataUploader
{
    public class DataUploader
    {
        private readonly IAddressService _addressService;
        private readonly IAddressBuilder _addressBuilder;
        protected static int Counter = 0;

        protected static string DefaultHeader =
            "LineId,Name,LastName,Telephone,PhoneNumber,Email,AddressLine1,AddressLine2,City,PostalCode,Company,OtherData,Url";

        public DataUploader(IAddressService addressService, IAddressBuilder addressBuilder)
        {
            _addressService = addressService;
            _addressBuilder = addressBuilder;
        }

        public void Run()
        {
            string filePath;

            do
            {
                 Console.WriteLine("Please write the path to the file you wish to import the data");
                filePath = Console.ReadLine();
            } while (string.IsNullOrEmpty(filePath));
            
            Console.WriteLine("Initiate Importing Process...");
            Timer aTimer = new Timer(1000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.Start();

            List<Address> addressList = new List<Address>();
            Dictionary<string, string> postalCodes = new Dictionary<string, string>();
            IncludeHeaderInCsvFile(filePath);
            var textStream = File.OpenText(filePath);
            var csv = new CsvReader(textStream);
            csv.Configuration.AutoMap<FileLineDetails>();

            while (csv.Read())
            {
                var addressLine1 = csv.GetField<string>("AddressLine1");
                var addressLine2 = csv.GetField<string>("AddressLine2");
                var city = csv.GetField<string>("City");
                var postalCode = csv.GetField<string>("PostalCode");
                if (!postalCodes.ContainsKey(postalCode.ToLower().Replace(" ", "")))
                {
                    var address = _addressBuilder.BuildAddress(addressLine1, addressLine2, city, postalCode);
                    if (address != null)
                    {
                        postalCodes.Add(address.PostalCode.ToLower().Replace(" ", ""), address.PostalCode.ToLower().Replace(" ", ""));
                        addressList.Add(address);
                    }
                }
            }

            _addressService.Add(addressList);
            aTimer.Stop();
            aTimer.Dispose();
            Console.WriteLine("Press Any Key to Exit...");
            Console.Read();
        }

        private static void IncludeHeaderInCsvFile(string filePath)
        {
            bool hasHeaderIncluded = false;
            string tempfile = Path.GetTempFileName();
            using (var writer = new StreamWriter(tempfile))
            using (
                var reader = new StreamReader(filePath))
            {
                string firstLine = reader.ReadLine();
                hasHeaderIncluded = firstLine.ToLower().Equals(DefaultHeader.ToLower(), StringComparison.InvariantCultureIgnoreCase);
                if (!hasHeaderIncluded)
                {
                    writer.WriteLine(
                        "LineId,Name,LastName,Telephone,PhoneNumber,Email,AddressLine1,AddressLine2,City,PostalCode,Company,OtherData,Url");
                    writer.WriteLine(firstLine);
                    while (!reader.EndOfStream)
                        writer.WriteLine(reader.ReadLine());
                }
            }
            if (!hasHeaderIncluded) File.Copy(tempfile, filePath, true);
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.Clear();
            Console.Write(++Counter);
        }
    }
}
