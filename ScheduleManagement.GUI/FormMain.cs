using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScheduleManagement.GUI
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            //this.WindowState = FormWindowState.Maximized;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            OpenChildForm<FormSchedule>();
        }
        private void OpenChildForm<T>() where T : Form, new()
        {
            // Đóng tất cả form con khác
            foreach (Form child in this.MdiChildren) { child.Close(); }

            // Tạo form mới
            T childForm = new T();

            // Thiết lập không title bar, không nút X
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.ControlBox = false;
            childForm.Text = "";

            // Full trong FormMain
            childForm.MdiParent = this;
            childForm.Dock = DockStyle.Fill;
            this.Width = childForm.Width + 20; 
            this.Height = childForm.Height + 60;
            childForm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in this.MdiChildren)
                child.Close();

            this.Hide();

            FormLogin loginForm = new FormLogin();
            loginForm.ShowDialog();

            this.Close();
        }

        private void tasksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm<FormTaskList>();
        }

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm<FormCategory>();
        }

        private void scheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm<FormSchedule>();
        }
    }
}
