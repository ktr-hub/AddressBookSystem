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

            Console.WriteLine("Provide first_name of contact to be edited : ");

            string first_name = Console.ReadLine();
            addressBookMain.editContact(first_name);
            addressBookMain.viewContactNames();

            Console.WriteLine("Provide first_name of contact to be deleted : ");

            first_name = Console.ReadLine();
            addressBookMain.deleteContact(first_name);
            addressBookMain.viewContactNames();
        }
    }
}
