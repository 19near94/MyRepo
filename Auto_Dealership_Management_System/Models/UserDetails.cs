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

    public class ManageUser
    {
        private string DBConn = ConfigurationManager.AppSettings["DBCONN"];
        public bool CreateUser(UserDetails usr)
        {
            using (SqlConnection sqlcon = new SqlConnection(DBConn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = sqlcon;
                    cmd.CommandText = "PROC_Create_User";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;

                    cmd.Parameters.AddWithValue("@FirstName", usr.FirstName);
                    cmd.Parameters.AddWithValue("@MiddleName", usr.MiddleName);
                    cmd.Parameters.AddWithValue("@LastName", usr.LastName);
                    cmd.Parameters.AddWithValue("@Age", usr.Age);
                    cmd.Parameters.AddWithValue("@Gender", usr.Gender);
                    cmd.Parameters.AddWithValue("@Email_Address", usr.Email_Address);
                    cmd.Parameters.AddWithValue("@Mobile_no", usr.Mobile_No);
                    cmd.Parameters.AddWithValue("@Address", usr.Address);
                    cmd.Parameters.AddWithValue("@Username", usr.Username);
                    cmd.Parameters.AddWithValue("@Password", usr.Password);
                    cmd.Parameters.AddWithValue("@DateAdded", DateTime.Now.ToString());
                    cmd.Parameters.AddWithValue("@DateUpdated", DateTime.Now.ToString());
                    cmd.Parameters.AddWithValue("@withOTP", usr.WithOTP);
                    try
                    {
                        sqlcon.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                }
            }

            return false;
        }

        public List<UserDetails> GetUserDet()
        {

            List<UserDetails> lstusr = new List<UserDetails>();
            using (SqlConnection sqlcon = new SqlConnection(DBConn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.Connection = sqlcon;
                    cmd.CommandText = "PROC_GetUserDet";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;

                    SqlDataReader rd = null;
                    try
                    {
                        sqlcon.Open();
                        rd = cmd.ExecuteReader();

                        while (rd.Read())
                        {
                            UserDetails usr = new UserDetails();
                            usr.Record_number = (int)rd["Record_number"];
                            usr.FirstName = rd["FirstName"].ToString();
                            usr.MiddleName = rd["MiddleName"].ToString();
                            usr.LastName = rd["LastName"].ToString();
                            usr.Age = (int)rd["Age"];
                            usr.Gender = (UserDetails.Sex)Enum.Parse(typeof(UserDetails.Sex), rd["Gender"].ToString());
                            usr.Email_Address = rd["Email_Address"].ToString();
                            usr.Mobile_No = rd["Mobile_No"].ToString();
                            usr.Address = rd["Address"].ToString();
                            usr.Username = rd["Username"].ToString();
                            usr.Password = rd["Password"].ToString();
                            usr.DateAdded = rd["DateAdded"].ToString();
                            usr.DateUpdated = rd["DateUpdated"].ToString();
                            usr.WithOTP = Convert.ToBoolean(rd["withOTP"]);

                            lstusr.Add(usr);
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }

            return lstusr;
        }


        public UserDetails GetUserDetByID(int Record_number)
        {
            UserDetails usr = new UserDetails();

            using (SqlConnection sqlcon = new SqlConnection(DBConn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.Connection = sqlcon;
                    cmd.CommandText = "PROC_GetUserDet_ByID";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;

                    cmd.Parameters.AddWithValue("@Record_number", Record_number);

                    SqlDataReader rd = null;
                    try
                    {
                        sqlcon.Open();
                        rd = cmd.ExecuteReader();

                        while (rd.Read())
                        {
                            usr.Record_number = (int)rd["Record_number"];
                            usr.FirstName = rd["FirstName"].ToString();
                            usr.MiddleName = rd["MiddleName"].ToString();
                            usr.LastName = rd["LastName"].ToString();
                            usr.Age = (int)rd["Age"];
                            usr.Gender = (UserDetails.Sex)Enum.Parse(typeof(UserDetails.Sex), rd["Gender"].ToString());
                            usr.Email_Address = rd["Email_Address"].ToString();
                            usr.Mobile_No = rd["Mobile_No"].ToString();
                            usr.Address = rd["Address"].ToString();
                            usr.Username = rd["Username"].ToString();
                            usr.Password = rd["Password"].ToString();
                            usr.DateAdded = rd["DateAdded"].ToString();
                            usr.DateUpdated = rd["DateUpdated"].ToString();
                            usr.WithOTP = Convert.ToBoolean(rd["withOTP"]);

                            
                        }
                        return usr;
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }

            return usr;
        }


        public bool UpdateUser(UserDetails usr)
        {
            using (SqlConnection sqlcon = new SqlConnection(DBConn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = sqlcon;
                    cmd.CommandText = "PROC_UpdateUserDet_ByID";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;


                    cmd.Parameters.AddWithValue("@Record_number", usr.Record_number);
                    cmd.Parameters.AddWithValue("@FirstName", usr.FirstName);
                    cmd.Parameters.AddWithValue("@MiddleName", usr.MiddleName);
                    cmd.Parameters.AddWithValue("@LastName", usr.LastName);
                    cmd.Parameters.AddWithValue("@Age", usr.Age);
                    cmd.Parameters.AddWithValue("@Gender", usr.Gender);
                    cmd.Parameters.AddWithValue("@Email_Address", usr.Email_Address);
                    cmd.Parameters.AddWithValue("@Mobile_no", usr.Mobile_No);
                    cmd.Parameters.AddWithValue("@Address", usr.Address);
                    cmd.Parameters.AddWithValue("@Username", usr.Username);
                    cmd.Parameters.AddWithValue("@Password", usr.Password);
                    cmd.Parameters.AddWithValue("@DateAdded", DateTime.Now.ToString());
                    cmd.Parameters.AddWithValue("@DateUpdated", DateTime.Now.ToString());
                    cmd.Parameters.AddWithValue("@withOTP", usr.WithOTP);

                    try
                    {
                        sqlcon.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                }
            }

            return false;
        }
    }
    



}