using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AddressBookSystem
{
    class Contact
    {

        //Getters and Setters of Last name ... Annotations to validate it
        [StringLength(20,ErrorMessage = "\n\tString length must be present between 3 and 20",MinimumLength =3)]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[A-Z][A-Za-z]+$",ErrorMessage = "\n\tPlease enter valid first name (Eg.: John, Tom) -> Start with Capital -> Should contain Only alphabets")]
        public string FirstName 
        {
            get; set;
        }

        //Getters and Setters of Last name ... Annotations to validate it
        [StringLength(20, ErrorMessage = "\n\tString length must be present between 3 and 20", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[A-Z][A-Za-z]+", ErrorMessage = "\n\tPlease enter valid first name (Eg.: John, Tom) -> Start with Capital -> Should contain Only alphabets")]
        public string LastName
        {
            get; set;
        }

        //Getters and Setters of Address ... Annotations to validate it
        [StringLength(100, ErrorMessage = "\n\tString length between 3-100 is valid",MinimumLength =3)]
        [DataType(DataType.MultilineText)]
        public string Address
        {
            get; set;
        }

        //Getters and Setters of Zip Code ... Annotations to validate it
        [StringLength(6, ErrorMessage = "\n\tZIP code number should consist 6 digits")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[0-9]{6}", ErrorMessage = "\n\tPlease enter valid ZIP Code (Eg.: 012345) ->  Should contain Only numbers")]
        public int Zip
        {
            get; set;
        }

        //Getters and Setters of Phone Number ... Annotations to validate it
        [StringLength(14, ErrorMessage = "\n\tPhone number should follow this format +91 1234567890")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[+][9][1]/s[0-9]{10}", ErrorMessage = "\n\tPlease enter valid Phone Number (Eg.: +91 1234567890) -> Start with '+91' -> Should contain Only Numbers")]
        [Phone]
        public string PhoneNumber
        {
            get;set;
        }

        //Getters and Setters of Email ... Annotations to validate it
        [StringLength(40, ErrorMessage = "\n\tPlease enter valid Email (Eg.: ktr@gmail.com)")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email
        {
            get; set;
        }
    }
}
