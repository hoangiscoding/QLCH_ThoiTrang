using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public interface ICommon
    {
        List<String> LoadAllUsername();
        List<String> LoadAllEmail();
        List<String> LoadAllPhoneNumber();
        string GetDefaultAvatarPath();
    }
    public class CommonController : ICommon
    {
        private string connStr = "Data Source=LAPTOP-DNIFFA8V\\SQLEXPRESS;Initial Catalog=HatiShop;Integrated Security=True";
        //Load các username có trong hệ thống
        public List<String> LoadAllUsername()
        {
            List<String> usernames = new List<String>();
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("LoadUsername", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usernames.Add(reader["Username"].ToString());
                        }
                    }
                }
            }
            return usernames;
        }
        //load các gmail có trong hệ thống
        public List<String> LoadAllEmail()
        {
            List<String> emails = new List<String>();
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("LoadEmail", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            emails.Add(reader["Email"].ToString());
                        }
                    }
                }
            }
            return emails;
        }
        public List<string> LoadAllPhoneNumber()
        {
            List<String> phones = new List<String>();
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("LoadPhone", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            phones.Add(reader["PhoneNumber"].ToString());
                        }
                    }
                }
            }
            return phones;
        }
        public string GetDefaultAvatarPath()
        {
            return "D:\\DH\\Kì 5\\LTTQ\\BTL\\QLCH_ThoiTrang\\images\\Avatars\\man.png";
        }
    }
}
