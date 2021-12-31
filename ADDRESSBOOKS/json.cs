using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace ADDRESSBOOKS
{
    public class json
    {
        public static void ImplementCSVToJSON()
        {
            string importFilePath = @"C:\Users\CSC\source\repos\ADDRESSBOOKS\ADDRESSBOOKS\import.csv";
            string exportFilePath = @"C:\Users\CSC\source\repos\ADDRESSBOOKS\ADDRESSBOOKS\export.json";

            //reading csv file
            using (var reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Contacts>().ToList();
                Console.WriteLine("Read data Successfully from address.csv here are codes");
                foreach (Contacts addressdata in records)
                {


                    Console.Write("\t", addressdata.firstName);
                    Console.Write("\t", addressdata.lastName);
                    Console.Write("\t", addressdata.email);
                    Console.Write("\t", addressdata.phoneNumber);
                    Console.Write("\t", addressdata.state);
                    Console.Write("\t", addressdata.zip);
                    Console.Write("\t", addressdata.city);
                    Console.Write("\t", addressdata.address);


                }
                Console.WriteLine("\n********** reading Csv from write it to JSON file ****** ");

                //write dat to json file
                JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                using (StreamWriter sw = new StreamWriter(exportFilePath))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, records);
                }

            }
        }
        public static void ImplementCSVDataHandling()
        {
            //initialization
            string importFilePath = @"C:\Users\CSC\source\repos\ADDRESSBOOKS\ADDRESSBOOKS\import.csv";
            string expoertFilePath = @"C:\Users\CSC\source\repos\ADDRESSBOOKS\ADDRESSBOOKS\export.csv";

            //reading csv file
            using (var reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Contacts>().ToList();
                Console.WriteLine("Read data Successfully from address.csv.");
                foreach (Contacts addressdata in records)
                {




                    Console.Write("\t", addressdata.firstName);
                    Console.Write("\t", addressdata.lastName);
                    Console.Write("\t", addressdata.email);
                    Console.Write("\t", addressdata.phoneNumber);
                    Console.Write("\t", addressdata.zip);
                    Console.Write("\t", addressdata.city);
                    Console.Write("\t", addressdata.address);
                   


                }

                Console.WriteLine("\n ********** Now Reading from csv file read and write to csv file ********* ");

                //writing csv file
                using (var writer = new StreamWriter(expoertFilePath))
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(records);
                }
            }
        }
    }
}
