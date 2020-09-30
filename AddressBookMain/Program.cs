using System;

namespace AddressBookSystem
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program ..!\n");
            
            AddressBookMain addressBookMain = new AddressBookMain();

            addressBookMain.createContact();
            addressBookMain.viewContactNames();

            addressBookMain.createContact();
            addressBookMain.viewContactNames();

            Console.WriteLine("Provide first_name to edit info : ");

            string first_name = Console.ReadLine();
            addressBookMain.editContact(first_name);
            addressBookMain.viewContactNames();

        }
    }
}
