using System;

namespace AddressBookSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program ..!\n\nEnter the following details:\nFirst Name : ");
            string first_name = Console.ReadLine();
            Console.WriteLine("Last Name : ");
            string last_name = Console.ReadLine();
            Console.WriteLine("City : ");
            string city = Console.ReadLine();
            Console.WriteLine("ZIP : ");
            int zip = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Phone No : ");
            string phone_number = Console.ReadLine();
            Console.WriteLine("Email : ");
            string email = Console.ReadLine();

            Contact contact = new Contact();
            contact.createContact(first_name, last_name, city, zip, phone_number, email);
        }
    }
}
