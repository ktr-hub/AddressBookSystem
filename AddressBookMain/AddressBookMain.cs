using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;
using System.Transactions;

namespace AddressBookSystem
{
    class AddressBookMain
    {
        public List<Contact> contactList = new List<Contact>();
        public Dictionary<string, Contact> contactDetailsMap = new Dictionary<string, Contact>();
        public Dictionary<Contact,string> cityMapWithPerson = new Dictionary<Contact, string>();
        public Dictionary<Contact,string> stateMapWithPerson = new Dictionary<Contact, string>();
        public string addressBookUserName;
        static ValidationContext validationContext;
        static List<ValidationResult> results = new List<ValidationResult>();

        public bool validateInputs(Contact contact, string input, string fieldName)
        {
           
            /*
            Type type = contact.GetType();
            string methodName = "set_" + fieldName;
            MethodInfo method = type.GetMethod(methodName);
            method.Invoke(contact, new object[]{input});
            validationContext = new ValidationContext(contact, null, null);
            bool valid = Validator.TryValidateObject(contact, validationContext, results, true);
            if (!valid)
            {
                Console.WriteLine(results[results.Count - 1].ErrorMessage);
                return false;
            }*/
            return true;
        }

        //To get user details from the console

        public void userInput(Contact contact)
        {

            Console.WriteLine("\nEnter the following details:");
            while (true)
            {
                Console.Write("\nFirst Name : ");
                string input = Console.ReadLine();
                contact.FirstName = input;
                bool valid = validateInputs(contact, input, "FirstName");
                
                if(contact.Equals(contactDetailsMap, contact.FirstName))
                {
                    Console.WriteLine("Same contact already exists on this address book... Try another one...");
                }

                if (valid)
                {
                    break;
                }
            }

            while (true)
            {
                Console.Write("\nLast Name : ");
                string input = Console.ReadLine();
                contact.LastName = input;
                bool valid = validateInputs(contact, input, "LastName");
                if (valid)
                {
                    break;
                }
            }

            while (true)
            {
                Console.Write("\nAddress : ");
                string input = Console.ReadLine(); 
                contact.Address = input;
                bool valid = validateInputs(contact, input, "Address");
                if (valid)
                {
                    break;
                }
            }

            while (true)
            {
                Console.Write("\nCity : ");
                string input = Console.ReadLine();
                contact.City = input;
                bool valid = validateInputs(contact, input, "City");
                if (valid)
                {
                    break;
                }
            }

            while (true)
            {
                Console.Write("\nState : ");
                string input = Console.ReadLine();
                contact.State = input;
                bool valid = validateInputs(contact, input, "State");
                if (valid)
                {
                    break;
                }
            }

            while (true)
            {
                Console.Write("\nZIP : ");
                try
                {
                    string input = Console.ReadLine();
                    contact.Zip = input;
                    int inputConvert = Convert.ToInt32(input);

                    bool valid = validateInputs(contact, input, "ZIP");
                    if (valid)
                    {
                        break;
                    }
                }
                catch(FormatException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            while (true)
            {
                Console.Write("\nPhone Number : ");
                string input = Console.ReadLine();
                contact.PhoneNumber = input;
                bool valid = validateInputs(contact, input, "PhoneNumber");
                if (valid)
                {
                    break;
                }
            }

            while (true)
            {
                Console.Write("\nEmail : ");
                string input = Console.ReadLine();
                contact.Email = input;
                bool valid = validateInputs(contact, input, "Email");
                if (valid)
                {
                    break;
                }
            }
        }

        //To create a contact in address book
        public void createContact()
        {
            Contact contact = new Contact();
            userInput(contact);
            contactList.Add(contact); 
            cityMapWithPerson.Add(contact, contact.City);
            stateMapWithPerson.Add(contact, contact.State);
            contactDetailsMap.Add(contact.FirstName, contact);
            Console.WriteLine("\nNew contact created...");

        }
        public void editContact()
        {
            if (contactList.Count==0)
            {
                Console.WriteLine("\nNo contacts in the Address Book to edit now ...");
            }
            else {
                Console.WriteLine("\nProvide first_name of contact to be edited : ");
                string first_name = Console.ReadLine();
                Contact contact = null;
                try
                {
                    contact = contactDetailsMap[first_name];
                }
                catch (KeyNotFoundException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                finally
                {
                    userInput(contact);
                    Console.WriteLine("\nDetails edited successfully...");
                }
            }
        }
        public void viewContactNames()
        {
            if (contactList.Count == 0)
            {
                Console.WriteLine("No contacts in the Address Book to display");
            }
            else
            {
                Boolean boolean = true;
                while (boolean)
                {
                    Console.Write("Select sorting order to view : \n 1:First Name\n 2:City\n 3.ZIP\n 4.State\n Your Choice : ");
                    try
                    {
                        int choice = Convert.ToInt32(Console.ReadLine());
                        switch (choice)
                        {
                            case 1: SortByName();
                                boolean = false;
                                break;
                            case 2: SortByCity();
                                boolean = false;
                                break;
                            case 3: SortByZIP();
                                boolean = false;
                                break;
                            case 4: SortByState();
                                boolean = false;
                                break;
                            default:
                                Console.Write("Enter valid input :- ");
                                break;
                        }
                    }
                    catch (FormatException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
                
            }
        }

        public void SortByName()
        {
            Console.WriteLine("\n\nContact names saved so far : ");
            int count = 1;
            contactList.Sort((x, y) => (x.FirstName.CompareTo(y.FirstName)));

            foreach (Contact contact in contactList)
            {
                Console.WriteLine((count++) + ")\t" + contact.FirstName + "\t" + contact.LastName + "\t" + contact.Address + "\t" + contact.Zip + "\t" + contact.PhoneNumber + "\t" + contact.Email);
            }
        }

        public void SortByCity()
        {
            Console.WriteLine("\n\nContact names saved so far : ");
            int count = 1;
            contactList.Sort((x, y) => (x.city.CompareTo(y.city)));

            foreach (Contact contact in contactList)
            {
                Console.WriteLine((count++) + ")\t" + contact.city + "\t" + contact.firstName+"\t"+ contact.LastName + "\t" + contact.Address + "\t" + contact.Zip + "\t" + contact.PhoneNumber + "\t" + contact.Email);
            }
        }

        public void SortByZIP()
        {
            Console.WriteLine("\n\nContact names saved so far : ");
            int count = 1;
            contactList.Sort((x, y) => (x.zip.CompareTo(y.zip)));

            foreach (Contact contact in contactList)
            {
                Console.WriteLine((count++) + ")\t" + contact.zip + "\t" + contact.firstName + "\t" + contact.LastName + "\t" + contact.Address + "\t" + contact.City + "\t" + contact.PhoneNumber + "\t" + contact.Email);
            }
        }

        public void SortByState()
        {
            Console.WriteLine("\n\nContact names saved so far : ");
            int count = 1;
            contactList.Sort((x, y) => (x.state.CompareTo(y.state)));

            foreach (Contact contact in contactList)
            {
                Console.WriteLine((count++) + ")\t" + contact.state + "\t" + contact.firstName + "\t" + contact.LastName + "\t" + contact.Address + "\t" + contact.City + "\t" + contact.PhoneNumber + "\t" + contact.Email);
            }
        }

        public void deleteContact()
        {
            if (contactList.Count==0)
            {
                Console.WriteLine("\nNo contacts in the Address Book to delete now...");
            }
            else {

                Console.Write("\nProvide first_name of contact to be deleted : ");
                string first_name = Console.ReadLine();
                try
                {
                    contactList.Remove(contactDetailsMap[first_name]);
                    contactDetailsMap.Remove(first_name);
                    Console.WriteLine("\nContact " + first_name + " deleted successfully...");
                }
                catch (KeyNotFoundException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }

        //UC 9 & UC 10: Dictionary creation of city and state and get count of them
        public void countOfCities()
        {
            //To get the required count of persons from cities and states
            Console.Write("Enter city : ");
            string city = Console.ReadLine();
            Console.Write("Enter state : ");
            string state = Console.ReadLine();

            int cityCount = contactList.FindAll(e => (cityMapWithPerson[e] == city)).Count;
            int stateCount = contactList.FindAll(e => (stateMapWithPerson[e] == state)).Count;

            Console.WriteLine("Count of Persons who stay in " + city + " is : " + cityCount);
            Console.WriteLine("Count of Persons who stay in " + state + " is : " + stateCount);

        }

    }
}
