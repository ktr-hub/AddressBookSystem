using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;


namespace AddressBookSystem
{
    class AddressBookMain
    {
        List<Contact> contactList=new List<Contact>();
        Dictionary<string, Contact> contactDetailsMap = new Dictionary<string, Contact>();
        public void createContact(string firstName, string lastName, string city, int zip, string phoneNumber, string email)
        {
            Contact contact = new Contact(firstName, lastName, city, zip, phoneNumber, email);
            contactList.Add(contact);
            contactDetailsMap.Add(firstName, contact);
            Console.WriteLine("\n\n\n\t\t\tNew contact created...");
        }
        public void editContact(string first_name)
        {
            viewContact(first_name);
            Contact contact = contactDetailsMap[first_name];
            if (contact == null)
            {
                Console.WriteLine("\n\n\n\t\t\tNo contact with the name " + first_name);
            }
            else
            {
                takeUserInput(contact);
                Console.WriteLine("\n\n\n\t\t\tDetails edited...");
            }
        }
        public void viewContactNames()
        {
            if (contactList.Count == 0)
            {
                Console.WriteLine("No contacts saved to display");
            }
            else
            {
                Console.WriteLine("\n\n\n\t\t\tContact names saved so far : ");
                foreach (Contact contact in contactList)
                {
                    Console.WriteLine(contact.getFirstName());
                }
            }
        }
        public void deleteContact(string first_name)
        {
            List<string> keyList = new List<string>(contactDetailsMap.Keys);

            if (keyList.Contains(first_name))
            {
                contactList.Remove(contactDetailsMap[first_name]);
                contactDetailsMap.Remove(first_name);
                Console.WriteLine("\n\n\n\t\t\tContact " + first_name + " deleted successfully...");
            }
            else
            {
                Console.WriteLine("\n\n\n\t\t\tNo contact found with spoecified data");
            }
        }
        public void viewContact(string first_name)
        {
            Console.WriteLine("\n\nContact Info :- ");
            Contact contact = contactDetailsMap[first_name];

            if (contact == null)
            {
                Console.WriteLine("\n\n\n\t\t\t contact with the name " + first_name);
            }
            else
            {
                Console.WriteLine("first_name      : " + contact.getFirstName() + "\n" +
                                  "last_name       : " + contact.getLastName() + "\n" +
                                  "city            : " + contact.getCity() + "\n" +
                                  "ZIP             : " + contact.getZip() + "\n" +
                                  "Phone No        : " + contact.getPhoneNumber() + "\n" +
                                  "Email           : " + contact.getEmail() + "\n");
            }
        }
        public void takeUserInput(Contact contact)
        {
            int choice = 0;

            while (choice != 7)
            {
                Console.Write("Press 1. To edit first_name\n" +
                                  "Press 2. To edit last_name\n" +
                                  "Press 3. To edit city\n" +
                                  "Press 4. To edit zip\n" +
                                  "Press 5. To edit phone number\n" +
                                  "Press 6. To edit email\n" +
                                  "Press 7. TO exit editing\n" +
                                  "Choice : ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1: 
                        Console.Write("Enter new first_name : ");
                        string firstName = this.getValidateText("First name");
                        contactDetailsMap.Remove(contact.getFirstName());
                        contact.setFirstName(firstName);
                        contactDetailsMap.Add(firstName, contact);
                        break;
                    case 2:
                        Console.Write("Enter new last_name : ");
                        string lastName = this.getValidateText("Last name");
                        contact.setLastName(lastName);
                        break;
                    case 3:
                        Console.Write("Enter new city : ");
                        string city = this.getValidateText("City");
                        contact.setCity(city);
                        break;
                    case 4:
                        Console.Write("Enter new ZIP : ");
                        int zip = this.getValidateNumber("ZIP");
                        contact.setZip(zip);
                        break;
                    case 5:
                        Console.Write("Enter new Contact No : ");
                        string mobile = this.getValidatePhoneNumber("Contact No");
                        contact.getPhoneNumber();
                        break;
                    case 6:
                        Console.Write("Enter new email : ");
                        string email = this.getValidateEmail("Email");
                        contact.getEmail();
                        break;
                    case 7:
                        Console.WriteLine("Thank you...");
                        break;
                    default:
                        Console.WriteLine("Please enter correct input");
                        break;
                }

                Console.WriteLine("Details Updated :-");
                viewContact(contact.getFirstName());
            }
        }
        public string getValidateText(string prompt)
        {
            Boolean boolean = true;
            while (boolean)
            {
                string text = Console.ReadLine();
                if (Regex.Match(text, "^[a-zA-Z]*$").Success)
                {
                    return text;
                }
                else
                {
                    Console.Write("Only alphabets required... Please enter again ... \n" + prompt + " : ");
                }
            }
            return null;
        }
        public int getValidateNumber(string prompt)
        {
            Boolean boolean = true;
            while (boolean)
            {
                string number = Console.ReadLine();
                int myInt;
                bool isNumerical = int.TryParse(number, out myInt);
                if (isNumerical&&number.Length==6)
                {
                    return myInt;
                }
                else
                {
                    Console.Write("Only six digit number required... Please enter again ...\n" + prompt + " : ");
                }
            }
            return 0;
        }
        public string getValidatePhoneNumber(string prompt)
        {
            Boolean boolean = true;
            while (boolean)
            {
                string number = Console.ReadLine();
                if (Regex.Match(number, "^[0-9]{10}").Success)
                {
                    return number;
                }
                else
                {
                    Console.Write("Only 10 numbers required... Please enter again ...\n " + prompt + " : ");
                }
            }
            return null;
        }
        public string getValidateEmail(string prompt)
        {
            Boolean boolean = true;
            while (boolean)
            {
                string text = Console.ReadLine();
                if (text.Contains('@')&&text.Contains('.')&&(text.IndexOf('.', text.IndexOf('@'))-text.IndexOf('@')>1))
                {
                    {
                        return text;
                    }
                }
                else
                {
                    Console.Write("Enter valid mail... \n"+prompt+" : ");
                }
            }
            return null;
        }
    }
}
