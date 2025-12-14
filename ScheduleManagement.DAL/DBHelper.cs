using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ScheduleManagement.DAL
{
    internal class DBHelper
    {
        private string _connStr;

        public DBHelper()
        {
            _connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        }

        public MySqlConnection GetConnection()
        {
            var conn = new MySqlConnection(_connStr);
            conn.Open();
            return conn;
        }
    }
}
