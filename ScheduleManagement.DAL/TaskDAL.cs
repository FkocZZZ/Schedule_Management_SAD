using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ScheduleManagement.DAL
{
    public class TaskEntity
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
    }
    public class TaskDAL
    {
        private readonly DBHelper _db;

        public TaskDAL()
        {
            _db = new DBHelper();
        }

        // Lấy danh sách task (JOIN Category)
        public List<TaskEntity> GetAll()
        {
            List<TaskEntity> list = new List<TaskEntity>();

            using (var conn = _db.GetConnection())
            {
                string sql = @"
                    SELECT t.task_id, t.title, t.category_id,
                           c.name AS category_name,
                           t.start_date, t.end_date,
                           t.status, t.note
                    FROM Tasks t
                    LEFT JOIN Categories c ON t.category_id = c.category_id
                    ORDER BY t.start_date DESC";

                using (var cmd = new MySqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TaskEntity
                        {
                            TaskId = reader.GetInt32("task_id"),
                            Title = reader.GetString("title"),
                            CategoryId = reader["category_id"] == DBNull.Value ? (int?)null : reader.GetInt32("category_id"),
                            CategoryName = reader["category_name"] == DBNull.Value ? "" : reader.GetString("category_name"),
                            StartDate = reader.GetDateTime("start_date"),
                            EndDate = reader["end_date"] == DBNull.Value ? (DateTime?)null : reader.GetDateTime("end_date"),
                            Status = reader.GetString("status"),
                            Note = reader["note"] == DBNull.Value ? "" : reader.GetString("note")
                        });
                    }
                }
            }
            return list;
        }

        // Add
        public void Add(TaskEntity t)
        {
            using (var conn = _db.GetConnection())
            {
                string sql = @"
                    INSERT INTO Tasks (title, category_id, start_date, end_date, status, note)
                    VALUES (@title, @category_id, @start_date, @end_date, @status, @note)";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@title", t.Title);
                    cmd.Parameters.AddWithValue("@category_id", (object)t.CategoryId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@start_date", t.StartDate);
                    cmd.Parameters.AddWithValue("@end_date", (object)t.EndDate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@status", t.Status);
                    cmd.Parameters.AddWithValue("@note", t.Note);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Update
        public void Update(TaskEntity t)
        {
            using (var conn = _db.GetConnection())
            {
                string sql = @"
                    UPDATE Tasks
                    SET title=@title,
                        category_id=@category_id,
                        start_date=@start_date,
                        end_date=@end_date,
                        status=@status,
                        note=@note
                    WHERE task_id=@id";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", t.TaskId);
                    cmd.Parameters.AddWithValue("@title", t.Title);
                    cmd.Parameters.AddWithValue("@category_id", (object)t.CategoryId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@start_date", t.StartDate);
                    cmd.Parameters.AddWithValue("@end_date", (object)t.EndDate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@status", t.Status);
                    cmd.Parameters.AddWithValue("@note", t.Note);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Delete
        public void Delete(int id)
        {
            using (var conn = _db.GetConnection())
            {
                string sql = "DELETE FROM Tasks WHERE task_id=@id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //Filter task by date
        public List<TaskEntity> GetTasksByDateRange(DateTime from, DateTime to)
        {
            List<TaskEntity> list = new List<TaskEntity>();
            string sql = @"
                SELECT t.task_id, t.title, t.category_id, c.name AS category_name,
                       t.start_date, t.end_date, t.status, t.note
                FROM Tasks t
                LEFT JOIN Categories c ON t.category_id = c.category_id
                WHERE t.start_date >= @from AND t.start_date < @to
                ORDER BY t.start_date ASC";

            using (var conn = _db.GetConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@from", from);
                cmd.Parameters.AddWithValue("@to", to);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TaskEntity
                        {
                            TaskId = reader.GetInt32("task_id"),
                            Title = reader["title"]?.ToString() ?? "",
                            CategoryId = reader["category_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["category_id"]),
                            CategoryName = reader["category_name"]?.ToString() ?? "",
                            StartDate = Convert.ToDateTime(reader["start_date"]),
                            EndDate = reader["end_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["end_date"]),
                            Status = reader["status"]?.ToString() ?? "",
                            Note = reader["note"]?.ToString() ?? ""
                        });
                    }
                }
            }
            return list;
        }


    }
}
