using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    class AddressBook
    {
        public string first_name;
        public string last_name;
        public string city;
        public int zip;
        public string phone_number;
        public string email;

        public AddressBook(string first_name, string last_name, string city, int zip, string phone_number, string email)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.city = city;
            this.zip = zip;
            this.phone_number = phone_number;
            this.email = email;
            Console.WriteLine("New contact created");
        }

    }
}
