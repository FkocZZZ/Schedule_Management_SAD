using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ScheduleManagement.DAL
{
    public class CategoryDAL
    {
        private readonly DBHelper _db;

        public CategoryDAL()
        {
            _db = new DBHelper();
        }
        public List<Category> GetAll()
        {
            List<Category> list = new List<Category>();
            using (var conn = _db.GetConnection())
            {
                string sql = "SELECT * FROM Categories";
                using (var cmd = new MySqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Category
                        {
                            CategoryId = reader.GetInt32("category_id"),
                            Name = reader.GetString("name"),
                            Description = reader["description"] == DBNull.Value ? "" : reader.GetString("description")
                        });
                    }
                }
            }
            return list;
        }
        public void Add(Category c)
        {
            using (var conn = _db.GetConnection())
            {
                string sql = "INSERT INTO Categories (name, description) VALUES (@name, @desc)";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", c.Name);
                    cmd.Parameters.AddWithValue("@desc", c.Description);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Category c)
        {
            using (var conn = _db.GetConnection())
            {
                string sql = "UPDATE Categories SET name=@name, description=@desc WHERE category_id=@id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", c.Name);
                    cmd.Parameters.AddWithValue("@desc", c.Description);
                    cmd.Parameters.AddWithValue("@id", c.CategoryId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = _db.GetConnection())
            {
                string sql = "DELETE FROM Categories WHERE category_id=@id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
