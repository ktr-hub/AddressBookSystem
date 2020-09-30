using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    class Contact
    {
        public string first_name;
        public string last_name;
        public string city;
        public int zip;
        public string phone_number;
        public string email;

        public Contact()
        {
            Console.WriteLine("In Constructor");
        }
    }
}
