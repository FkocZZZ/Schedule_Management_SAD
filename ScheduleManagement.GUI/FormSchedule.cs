using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScheduleManagement.BLL;

namespace ScheduleManagement.GUI
{
    public partial class FormSchedule : Form
    {
        private readonly TaskBLL _taskBLL;
        public FormSchedule()
        {
            InitializeComponent();
            _taskBLL = new TaskBLL();

            dtpDay.Value = DateTime.Now;
            dtpWeekStart.Value = DateTime.Now;

            LoadTasksByDay();
            LoadTasksByWeek();
        }
        private void LoadTasksByDay()
        {
            var tasks = _taskBLL.GetTasksByDay(dtpDay.Value);
            dgvTasksDay.DataSource = tasks;
            FormatGrid(dgvTasksDay);
        }

        private void LoadTasksByWeek()
        {
            dgvTasksWeek.DataSource = _taskBLL.GetTasksByWeek(dtpWeekStart.Value);
        }

        private void FormatGrid(DataGridView dgv)
        {
            if (dgv.Columns.Count == 0) return;

            dgv.Columns["TaskId"].Visible = false;
            dgv.Columns["CategoryId"].Visible = false;

            dgv.Columns["Title"].HeaderText = "Tiêu đề";
            dgv.Columns["CategoryName"].HeaderText = "Loại công việc";
            dgv.Columns["StartDate"].HeaderText = "Bắt đầu";
            dgv.Columns["EndDate"].HeaderText = "Kết thúc";
            dgv.Columns["Status"].HeaderText = "Trạng thái";
            dgv.Columns["Note"].HeaderText = "Ghi chú";

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.Columns["StartDate"].DefaultCellStyle.Format = "hh:mm tt yyyy-MM-dd";
            dgv.Columns["EndDate"].DefaultCellStyle.Format = "hh:mm tt yyyy-MM-dd";
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Khi đổi tab, load lại dữ liệu
            if (tabControl1.SelectedTab == tabDay) 
                LoadTasksByDay();
            else
                LoadTasksByWeek();
        }

        //Week
        private void button1_Click(object sender, EventArgs e)
        {
            // Đặt lại ngày hiện tại
            dtpDay.Value = DateTime.Now;
            dtpWeekStart.Value = DateTime.Now;

            // Load lại dữ liệu
            LoadTasksByWeek();
        }
        //Day
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Đặt lại ngày hiện tại
            dtpDay.Value = DateTime.Now;
            dtpWeekStart.Value = DateTime.Now;

            // Load lại dữ liệu
            LoadTasksByDay();
            LoadTasksByWeek();
        }

        private void dgvTasksDay_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtpDay_ValueChanged_1(object sender, EventArgs e) => LoadTasksByDay();
        private void dtpWeekStart_ValueChanged_1(object sender, EventArgs e) => LoadTasksByWeek();

    }
}
