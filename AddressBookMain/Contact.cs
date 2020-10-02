using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    class Contact
    {
        private string firstName;
        private string lastName;
        private string city;
        private int zip;
        private string phoneNumber;
        private string email;

        public Contact(string firstName,string lastName, string city, int zip, string phoneNumber, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.city = city;
            this.zip = zip;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }

        public Contact()
        {
            //Console.WriteLine("In Constructor");
        }
        public string getFirstName()
        {
            return this.firstName;
        }
        public string getLastName()
        {
            return this.lastName;
        }
        public string getCity() 
        {
            return this.city;
        }
        public int getZip()
        {
            return this.zip;
        }
        public string getPhoneNumber()
        {
            return this.phoneNumber;
        }
        public string getEmail()
        {
            return this.email;
        }
        public void setFirstName(string firstName)
        {
            this.firstName = firstName;
        }
        public void setLastName(string lastName)
        {
            this.lastName = lastName;
        }
        public void setCity(string city)
        {
            this.city = city;
        }
        public void setZip(int zip)
        {
            this.zip = zip;
        }
        public void setPhoneNumber(string phoneNumber)
        {
            this.phoneNumber= phoneNumber;
        }
        public void setEmail(string email)
        {
            this.email = email;
        }

    }
}
