using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace AddressBookSystem
{
    class AddressBookMain
    {
        List<Contact> contactList = new List<Contact>();
        Dictionary<string, Contact> contactDetailsMap = new Dictionary<string, Contact>();
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
                bool valid = validateInputs(contact, input ,"FirstName");
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
                Console.WriteLine("\n\nContact names saved so far : ");
                int count = 1;
                foreach (Contact contact in contactList)
                {
                    Console.WriteLine((count++)+")\t"+contact.FirstName+"\t"+contact.LastName+"\t"+contact.Address+"\t"+contact.Zip+"\t"+contact.PhoneNumber+"\t"+contact.Email);
                }
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
    }
}
