using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class UserDetails
    {
        public int Record_number { get; set; }
      
        public string FirstName         { get; set; }
        public string MiddleName        { get; set; }
        
        public string LastName          { get; set; }
       
        public int Age { get; set; }
       
        public Sex Gender { get; set; }
       
        public string Email_Address { get; set; }
       
        public string Mobile_No { get; set; }
        public string Address { get; set; }
       
        public string Username { get; set; }
        
        public string Password { get; set; }
        public string DateAdded { get; set; }
        public string DateUpdated { get; set; }
        public bool WithOTP { get; set; }
        public enum Sex
        {
            F,
            M
        }


    }
}
