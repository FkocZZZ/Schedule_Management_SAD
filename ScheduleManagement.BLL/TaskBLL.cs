using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleManagement.DAL;

namespace ScheduleManagement.BLL
{
    public class TaskBLL
    {
        private readonly TaskDAL _dal;

        public TaskBLL()
        {
            _dal = new TaskDAL();
        }

        // Get all
        public List<TaskModel> GetAllTasks()
        {
            return _dal.GetAll()
                .Select(t => new TaskModel
                {
                    TaskId = t.TaskId,
                    Title = t.Title,
                    CategoryId = t.CategoryId,
                    CategoryName = t.CategoryName,
                    StartDate = t.StartDate,
                    EndDate = t.EndDate,
                    Status = t.Status,
                    Note = t.Note
                }).ToList();
        }

        // Add
        public void AddTask(TaskModel model)
        {
            Validate(model);

            TaskEntity entity = new TaskEntity
            {
                Title = model.Title,
                CategoryId = model.CategoryId,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Status = model.Status,
                Note = model.Note
            };

            _dal.Add(entity);
        }

        // Update
        public void UpdateTask(TaskModel model)
        {
            Validate(model);

            TaskEntity entity = new TaskEntity
            {
                TaskId = model.TaskId,
                Title = model.Title,
                CategoryId = model.CategoryId,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Status = model.Status,
                Note = model.Note
            };

            _dal.Update(entity);
        }

        // Delete
        public void DeleteTask(int id)
        {
            _dal.Delete(id);
        }

        // Validate logic
        private void Validate(TaskModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Title))
                throw new Exception("Tên công việc không được để trống.");

            if (model.EndDate.HasValue && model.StartDate > model.EndDate.Value)
                throw new Exception("Ngày bắt đầu phải <= ngày kết thúc.");
        }

        public List<TaskModel> GetTasksByDateRange(DateTime from, DateTime to)
        {
            return _dal.GetTasksByDateRange(from, to)
                .Select(t => new TaskModel
                {
                    TaskId = t.TaskId,
                    Title = t.Title,
                    CategoryId = t.CategoryId,
                    CategoryName = t.CategoryName,
                    StartDate = t.StartDate,
                    EndDate = t.EndDate,
                    Status = t.Status,
                    Note = t.Note
                })
                .ToList();
        }

        public List<TaskModel> GetTasksByDay(DateTime day)
        {
            DateTime from = day.Date;
            DateTime to = from.AddDays(1);

            var entities = _dal.GetTasksByDateRange(from, to);

            // map sang TaskModel
            return entities.Select(e => new TaskModel
            {
                TaskId = e.TaskId,
                Title = e.Title,
                CategoryId = e.CategoryId,
                CategoryName = e.CategoryName,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                Status = e.Status,
                Note = e.Note
            }).ToList();
        }

        public List<TaskModel> GetTasksByWeek(DateTime weekStart)
        {
            DateTime from = weekStart.Date;
            DateTime to = from.AddDays(7);

            var entities = _dal.GetTasksByDateRange(from, to);

            return entities.Select(e => new TaskModel
            {
                TaskId = e.TaskId,
                Title = e.Title,
                CategoryId = e.CategoryId,
                CategoryName = e.CategoryName,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                Status = e.Status,
                Note = e.Note
            }).ToList();
        }
    }
}
