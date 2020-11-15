using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Auto_Dealership_Management_System.Models
{
    public class UserDetails
    {
        public int Record_number        { get; set; }
        [Required]
        public string FirstName         { get; set; }
        public string MiddleName        { get; set; }
        [Required]
        public string LastName          { get; set; }
        [Required]
        public int    Age               { get; set; }
        [Required]
        public Sex Gender               { get; set; }
        [Required]
        public string Email_Address { get; set; }
        [Required]
        [MaxLength(10)]
        public string Mobile_No { get; set; }
        public string Address           { get; set; }
        [Required]
        public string Username          { get; set; }
        [Required]
        [MaxLength(8)]
        public string Password          { get; set; }
        public string DateAdded         { get; set; }
        public string DateUpdated       { get; set; }
        public bool WithOTP { get; set; }
        public enum Sex
        {
            F,
            M
        }
    }
    
}