using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AddressBookSystem
{
    class FileInputOutput
    {
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

    }
}
