using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TelerikMVC.Models
{
    public class DBTable
    {
        public int ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Country { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string ActiveStatus { get; set; }
        public string FName2 { get; set; }
        public string LName2 { get; set; }
        public string Country2 { get; set; }
        public string Mobile2 { get; set; }
        public string Email2 { get; set; }
        public string ActiveStatus2 { get; set; }
        public string FName3 { get; set; }
        public string LName3 { get; set; }
        public string Country3 { get; set; }
        public string Mobile3 { get; set; }
        public string Email3 { get; set; }
        public string ActiveStatus3 { get; set; }




        public List<DBTable> dtTable()
        {
            List<DBTable> dbTable = new List<DBTable>();
            string conString = ConfigurationManager.ConnectionStrings["dbName"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("select top 100000 * from TelerikMVC", con);
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        dbTable.Add(new DBTable
                        {
                            ID = Convert.ToInt32(sdr["Id"]),
                            FName = (sdr["FName"]).ToString(),
                            LName = (sdr["LName"]).ToString(),
                            Country = (sdr["Country"]).ToString(),
                            Mobile = (sdr["Mobile"]).ToString(),
                            Email = (sdr["Email"]).ToString(),
                            ActiveStatus = (sdr["ActiveStatus"]).ToString(),
                            FName2 = (sdr["FName2"]).ToString(),
                            LName2 = (sdr["LName2"]).ToString(),
                            Country2 = (sdr["Country2"]).ToString(),
                            Mobile2 = (sdr["Mobile2"]).ToString(),
                            Email2 = (sdr["Email2"]).ToString(),
                            ActiveStatus2 = (sdr["ActiveStatus2"]).ToString(),
                            FName3 = (sdr["FName3"]).ToString(),
                            LName3 = (sdr["LName3"]).ToString(),
                            Country3 = (sdr["Country3"]).ToString(),
                            Mobile3 = (sdr["Mobile3"]).ToString(),
                            Email3 = (sdr["Email3"]).ToString(),
                            ActiveStatus3 = (sdr["ActiveStatus3"]).ToString()
                        });
                    }
                }
                con.Close();
            }
            return dbTable;
        }
        
    }
}