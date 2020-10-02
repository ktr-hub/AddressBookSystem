using System;
using System.Xml.Serialization;

namespace AddressBookSystem
{
    class Program
    {
        public static void userInput(AddressBookMain addressBookMain)
        {
            Console.WriteLine("\nEnter the following details:\n");

            Console.Write("First Name : ");
            string firstName = addressBookMain.getValidateText("First name");
            
            Console.Write("Last Name : ");
            string lastName = addressBookMain.getValidateText("Last name");

            Console.Write("City : ");
            string city = addressBookMain.getValidateText("City");

            Console.Write("ZIP : ");
            int zip = addressBookMain.getValidateNumber("ZIP");

            Console.Write("Contact No : ");
            string phoneNumber = addressBookMain.getValidatePhoneNumber("Contact No");

            Console.Write("Email : ");
            string email = addressBookMain.getValidateEmail("Email");

            addressBookMain.createContact(firstName, lastName, city, zip, phoneNumber, email);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program ..!\n");
            AddressBookMain addressBookMain = new AddressBookMain();
            int choice = 0;
            while (choice != 6)
            {
                Console.Write("\nPress 1. To create a contact\n" +
                                  "Press 2. To edit a contact\n" +
                                  "Press 3. To delete a contact\n" +
                                  "Press 4. To view contact data\n" +
                                  "Press 5. To view all contacts\n" +
                                  "Press 6. To exit\n" +
                                  "Choice : ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        userInput(addressBookMain);
                        break;
                    case 2:
                        addressBookMain.viewContactNames();
                        Console.Write("Provide first_name of contact to be edited : ");
                        string first_name = Console.ReadLine();
                        addressBookMain.editContact(first_name);
                        break;
                    case 3:
                        addressBookMain.viewContactNames();
                        Console.Write("Provide first_name of contact to be deleted : ");
                        string first_name_ = Console.ReadLine();
                        addressBookMain.deleteContact(first_name_);
                        break;
                    case 4:
                        addressBookMain.viewContactNames();
                        Console.Write("Provide first_name of contact to show info : ");
                        string first_name__ = Console.ReadLine();
                        addressBookMain.viewContact(first_name__);
                        break;
                    case 5:
                        addressBookMain.viewContactNames();
                        break;
                    default:
                        Console.Write("Please provide correct input to proceed with");
                        break;
                }
            }
        }
    }
}
