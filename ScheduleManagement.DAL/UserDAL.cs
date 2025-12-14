using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ScheduleManagement.DAL
{
    public class UserDAL
    {
        private readonly DBHelper _db;

        public UserDAL()
        {
            _db = new DBHelper();
        }

        public bool CheckUserLogin(string username, string password)
        {
            using (var conn = _db.GetConnection())
            {
                string sql = "SELECT COUNT(*) FROM users WHERE username=@username AND password=@password";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    long count = (long)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        public bool CheckUsernameExists(string username)
        {
            using (var conn = _db.GetConnection())
            {
                string sql = "SELECT COUNT(*) FROM users WHERE username=@username";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    long count = (long)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        public bool AddUser(string username, string password)
        {
            using (var conn = _db.GetConnection())
            {
                string sql = "INSERT INTO users(username, password) VALUES(@username, @password)";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                } ;
            }
        }
    }
}
