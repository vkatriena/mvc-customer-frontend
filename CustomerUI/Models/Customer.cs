using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerUI.Models
{
    public class Customer
    {
        public int ID { get; set; }
        [Required (ErrorMessage ="First Name is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "State")]
        public string State { get; set; }
        [Display(Name ="Postal Code")]
        [RegularExpression("^[A-Z]{1,1}[0-9]{1,1}[A-Z]{1,1}[0-9]{1,1}[A-Z]{1,1}[0-9]{1,1}$",
            ErrorMessage = "Incorrect Postal Code Entered")]
        public string PostalCode { get; set; }
        [Required (ErrorMessage = "Phone Number is required")]
        [RegularExpression("[0-9]{10,10}",ErrorMessage ="Please enter upto 10 digits for a contact number")]
        [Display(Name = "Contact Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Customer Type")]
        public CustomerType CustomerTypeId { get; set; }
        [Required (ErrorMessage ="Customer Type is Required")]
        //public int CustomerType { get; set; }
        public bool IsActive { get; set; }

        public Customer(string fName, string lName, string address, string city, string state, string postalCode, string pNumber, CustomerType custType)
        {
            FirstName = fName;
            LastName = lName;
            Address = address;
            City = city;
            State = state;
            PostalCode = postalCode;
            PhoneNumber = pNumber;
            CustomerTypeId = custType;
            IsActive = true;

        }
        public Customer()
        {
            IsActive=true;
        }


    }

    public enum CustomerType
    {
        Customer = 2,
        Lead = 1
    }
}
