using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using Newtonsoft.Json;

namespace AddressBookSystem
{
    class FileInputOutput
    {

        public string firstname { get; set; }
        public string lastname { get; set; }
        public string city { get; set; }
        public int zip { get; set; }
        public string address { get; set; }
        public string phone { get; set; }

        public void WriteContactsIntoFile(List<Contact> contacts)
        {
            String path = @"C:\Users\Tirupathi Rao\source\repos\AddressBookMain\AddressBookMain\Exapmple.txt";

            StreamWriter stream = new StreamWriter(path);
            foreach(Contact contact in contacts)
            {
                stream.Write(contact.firstName+"\t");
                stream.Write(contact.lastName + "\t");
                stream.Write(contact.state + "\t");
                stream.WriteLine("\n");
            }
            stream.Close();
            ReadContactsFromFile(contacts);
        }
        public void ReadContactsFromFile(List<Contact> contacts)
        {
            String path = @"C:\Users\Tirupathi Rao\source\repos\AddressBookMain\AddressBookMain\Exapmple.txt";

            StreamReader stream = new StreamReader(path);
            
            Console.WriteLine(stream.ReadToEnd());
            stream.Close();
        }
        public static void WriteContactsIntoCsv(List<Contact> contacts)
        {
            string path = @"C:\Users\Tirupathi Rao\source\repos\AddressBookMain\AddressBookMain\export.csv";

            using (StreamWriter stream = new StreamWriter(path))
            using (CsvWriter csvWriter = new CsvWriter(stream, CultureInfo.InvariantCulture))
            {
                csvWriter.WriteRecords(contacts);
            }
            Console.WriteLine("Following data line added to CSV file...");
            ReadContactsFromCSV();
        }
        public static void ReadContactsFromCSV()
        {
            string path = @"C:\Users\Tirupathi Rao\source\repos\AddressBookMain\AddressBookMain\export.csv";

            using(StreamReader reader = new StreamReader(path))
            using(var read = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var contacts = read.GetRecords<Contact>().ToList();
                foreach(Contact contact in contacts)
                {
                    Console.WriteLine(contact.FirstName+","+contact.LastName + "," + contact.Address + "," + contact.City + "," + contact.State + "," + contact.Zip + "," + contact.PhoneNumber + "," + contact.Email);
                }
            }

        }

        public static void JsonSerializeDeserialize(List<Contact> contacts)
        {
            string path = @"C:\Users\Tirupathi Rao\source\repos\AddressBookMain\AddressBookMain\example.json";

            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter writer = new StreamWriter(path))
            using (var write = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                serializer.Serialize(writer, contacts);
            }

            IList<Contact> contacts1 = JsonConvert.DeserializeObject<IList<Contact>>(File.ReadAllText(path));

            Console.WriteLine("\nContact info printing via JSON file desrialization");
            foreach (Contact contact in contacts1)
            {
                Console.WriteLine(contact.FirstName + "," + contact.LastName + "," + contact.Address + "," + contact.City + "," + contact.State + "," + contact.Zip + "," + contact.PhoneNumber + "," + contact.Email);
            }

        }

    }
}
