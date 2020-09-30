using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    class AddressBookMain
    {
        List<Contact> contactList=new List<Contact>();
        Dictionary<string, Contact> contactDetailsMap = new Dictionary<string, Contact>();


        public void userInput(Contact contact)
        {
            Console.WriteLine("\nEnter the following details:\nFirst Name : ");
            contact.first_name = Console.ReadLine();
            Console.WriteLine("Last Name : ");
            contact.last_name = Console.ReadLine();
            Console.WriteLine("City : ");
            contact.city = Console.ReadLine();
            Console.WriteLine("ZIP : ");
            contact.zip = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Phone No : ");
            contact.phone_number = Console.ReadLine();
            Console.WriteLine("Email : ");
            contact.email = Console.ReadLine();

        }

        public void createContact()
        {
            Contact contact = new Contact();
            userInput(contact);
            contactList.Add(contact);
            contactDetailsMap.Add(contact.first_name, contact);
            Console.WriteLine("New contact created");
        }
        public void editContact(string first_name)
        {
            Contact contact = contactDetailsMap[first_name];
            userInput(contact);
            Console.WriteLine("Details edited");
        }
        public void viewContactNames()
        {
            Console.WriteLine("\n\nContact names saved so far");
            foreach(Contact contact in contactList)
            {
                Console.WriteLine(contact.first_name);
            }
        }
    }
}
