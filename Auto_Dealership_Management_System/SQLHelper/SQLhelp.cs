using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Auto_Dealership_Management_System.SQLHelper
{
    public class SQLhelp
    {

        private string DBCONN = ConfigurationManager.AppSettings["DBCONN"];
        public DataSet GetUserData()
        {

            DataSet ds = new DataSet();
            using (SqlConnection sqlcon = new SqlConnection(DBCONN))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = sqlcon;
                    cmd.CommandText = "sp_getuserdata";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;


                    try
                    {
                        sqlcon.Open();
                        SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
                        sqlda.Fill(ds);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            return ds;

        }
    }
}