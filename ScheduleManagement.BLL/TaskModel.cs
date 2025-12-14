using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleManagement.BLL
{
    public class TaskModel
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
}
