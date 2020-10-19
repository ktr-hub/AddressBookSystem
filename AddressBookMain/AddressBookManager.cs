using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace AddressBookSystem
{
    class AddressBookManager
    {
        public const int EXIT = 6;
        List<AddressBookMain> addressBookList = new List<AddressBookMain>();
        Dictionary<string, AddressBookMain> addressBookDetailsMap = new Dictionary<string, AddressBookMain>();

        public void createAddressBook()
        {
            AddressBookMain addressBookMain = new AddressBookMain();

            while (true) 
            {
                Console.Write("Enter user name of Address Book : ");
                string userInput = Console.ReadLine();
                Regex regex = new Regex(@"^[A-Za-z]+$");
                if (regex.IsMatch(userInput))
                {
                    if(addressBookDetailsMap.ContainsKey(userInput))
                    {
                        Console.WriteLine(userInput + " address book already exists on the system...");
                        break;
                    }
                    addressBookMain.addressBookUserName = userInput;
                    addressBookList.Add(addressBookMain);
                    addressBookDetailsMap.Add(addressBookMain.addressBookUserName, addressBookMain);
                    Console.WriteLine("\nNew Address Book created...");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Input... Please enter correctly... ->Only alphabets allowed");
                }
            }
        }
        public void deleteAddressBook()
        {
            if (addressBookList.Count == 0)
            {
                Console.WriteLine("\nNo Address Books to delete now...");
            }
            else
            {
                Console.Write("\nProvide Name of contact to be deleted : ");
                string first_name = Console.ReadLine();
                try
                {
                    addressBookList.Remove(addressBookDetailsMap[first_name]);
                    Console.WriteLine("\nAddress Book " + first_name + " deleted successfully...");
                }
                catch (KeyNotFoundException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
        public void editAddressBook()
        {
            if (addressBookList.Count == 0)
            {
                Console.WriteLine("No address books created to edit...");
            }
            else
            {
                viewAddressBookNames();
                Console.Write("Please enter address book name to edit : ");
                string userInput = Console.ReadLine();
                try
                {
                    accessAddressBook(addressBookDetailsMap[userInput]);
                }
                catch (KeyNotFoundException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
        public void accessAddressBook(AddressBookMain addressBookUser)
        {
            int choice = 0;
            while (choice != 5)
            {
                Console.Write("You're currently in AddressBookUser : "+addressBookUser.addressBookUserName +
                                        "\nPress 1. To add Contact \n" +
                                       "      2. To view Contacts\n" +
                                       "      3. To edit a Contact\n" +
                                       "      4. To delete a Contact\n" +
                                       "      5. Go to address books\n" +
                                       "Your Choice .: ");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                finally
                {
                    switch (choice)
                    {
                        case 1:
                            addressBookUser.createContact();
                            break;
                        case 2:
                            addressBookUser.viewContactNames();
                            break;
                        case 3:
                            addressBookUser.editContact();
                            break;
                        case 4:
                            addressBookUser.deleteContact();
                            break;
                        case 5:
                            Console.WriteLine("\nThank You for using user AddressBook of : "+addressBookUser.addressBookUserName+" ...");
                            break;
                        default:
                            Console.WriteLine("\nPlease enter valid choice...");
                            break;
                    }
                }
            }
        }
        public void viewAddressBookNames()
        {
            if (addressBookList.Count == 0)
            {
                Console.WriteLine("No Address Books found to display");
            }
            else
            {
                Console.WriteLine("\n\nAddress Book users saved so far : ");
                int count = 1;
                foreach (AddressBookMain addressBookMain in addressBookList)
                {
                    Console.WriteLine((count++) + ")\t" + addressBookMain.addressBookUserName);
                }
            }
        }

        public void accessCityFromSystem()
        {
            Console.Write("Enter city : ");
            string city = Console.ReadLine();
            Console.Write("Enter state : ");
            string state = Console.ReadLine();
            int count = 0;
            foreach(AddressBookMain addressBookUser in addressBookList)
            {
                foreach(Contact contact in addressBookUser.contactList)
                {
                    if (contact.City == city || contact.State== state)
                    {
                        if (count == 0)
                        {
                            Console.WriteLine("Contacts with specified data : ");
                        }
                        Console.WriteLine(contact.FirstName);
                        count++;
                    }
                }
            }
        }

        public void startAddressBook()
        {
            int choice = 0;
            while (choice != EXIT)
            {
                Console.Write("\nPress 1. To add Address Book \n" +
                                       "      2. To view Address Books\n" +
                                       "      3. To add/edit/access/delete contacts of Address Book\n" +
                                       "      4. To delete an Address Book\n" +
                                       "      5. TO access persons from city/state\n" +
                                       "      6. Exit\n" +
                                       "Your Choice .: ");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                finally
                {
                    switch (choice)
                    {
                        case 1:
                            createAddressBook();
                            break;
                        case 2:
                            viewAddressBookNames();
                            break;
                        case 3:
                            editAddressBook();
                            break;
                        case 4:
                            deleteAddressBook();
                            break;
                        case 5:
                            accessCityFromSystem();
                            break;
                        case6:
                            Console.WriteLine("\nThank You ...");
                            break;
                        default:
                            Console.WriteLine("\nPlease enter valid choice...");
                            break;
                    }
                }
            }
        }
    }
}
