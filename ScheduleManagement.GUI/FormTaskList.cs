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
    public partial class FormTaskList : Form
    {
        private readonly TaskBLL _taskBLL;
        private readonly CategoryBLL _categoryBLL;
        private bool _isLoading = false;
        public FormTaskList()
        {
            InitializeComponent();
            _taskBLL = new TaskBLL();
            _categoryBLL = new CategoryBLL();

            LoadCategories();
            dgvTasks.SelectionChanged += dgvTasks_SelectionChanged;

            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            LoadTasks();
        }
        private void LoadTasks()
        {
            try
            {
                _isLoading = true;
                var tasks = _taskBLL.GetAllTasks().OrderByDescending(t => t.TaskId).ToList(); ;
                dgvTasks.DataSource = tasks;
                FormatGrid();
                ClearInputs();
                dgvTasks.ClearSelection();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { _isLoading = false; UpdateButtonState(); }
        }

        private void FormatGrid()
        {
            dgvTasks.Columns["TaskId"].HeaderText = "ID";
            dgvTasks.Columns["CategoryId"].Visible = false;
            dgvTasks.Columns["Title"].HeaderText = "Tiêu đề";
            dgvTasks.Columns["CategoryName"].HeaderText = "Loại công việc";
            dgvTasks.Columns["StartDate"].HeaderText = "Bắt đầu";
            dgvTasks.Columns["EndDate"].HeaderText = "Kết thúc";
            dgvTasks.Columns["Status"].HeaderText = "Trạng thái";
            dgvTasks.Columns["Note"].HeaderText = "Ghi chú";
            dgvTasks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvTasks.Columns["StartDate"].DefaultCellStyle.Format = "hh:mm tt yyyy-MM-dd";
            dgvTasks.Columns["EndDate"].DefaultCellStyle.Format = "hh:mm tt yyyy-MM-dd";

            cboStatus.Items.Clear();
            cboStatus.Items.Add("In Progress");
            cboStatus.SelectedIndex = 0;
            if (cboCategory.Items.Count > 0)
                cboCategory.SelectedIndex = 0;
        }
        private void LoadCategories()
        {
            var categories = _categoryBLL.GetAllCategories().OrderByDescending(c => c.CategoryId)
                                     .ToList();
            cboCategory.DataSource = categories;
            cboCategory.DisplayMember = "Name";
            cboCategory.ValueMember = "CategoryId";
            if (categories.Any())
                cboCategory.SelectedIndex = 0;
        }

        private bool ValidateTask(out string error)
        {
            error = "";

            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                error = "Tiêu đề công việc không được để trống.";
                return false;
            }

            // Nếu endDate có chọn mới validate
            if (dtpEnd.Checked && dtpStart.Value > dtpEnd.Value)
            {
                error = "Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.";
                return false;
            }

            return true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private TaskModel CreateTaskFromForm(bool isAdd = true)
        {
            int categoryId = cboCategory.SelectedValue != null ? Convert.ToInt32(cboCategory.SelectedValue) : 1;
            DateTime? endDate = dtpEnd.Checked ? (DateTime?)dtpEnd.Value : null;
            string status = isAdd ? "In Progress" : (cboStatus.SelectedItem?.ToString() ?? "In Progress");


            return new TaskModel
            {
                Title = txtTitle.Text.Trim(),
                CategoryId = categoryId,
                StartDate = dtpStart.Value,
                EndDate = endDate,
                Status = status,
                Note = txtNote.Text.Trim()
            };
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateTask(out string error))
            {
                MessageBox.Show(error, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TaskModel task = CreateTaskFromForm(isAdd: true);

            try
            {
                _taskBLL.AddTask(task);
                LoadTasks();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvTasks.CurrentRow == null) return;
            if (!ValidateTask(out string err)) { MessageBox.Show(err); return; }
            var task = CreateTaskFromForm();
            task.TaskId = Convert.ToInt32(dgvTasks.CurrentRow.Cells["TaskId"].Value);
            _taskBLL.UpdateTask(task);
            LoadTasks();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTasks.CurrentRow == null) return;
            if (MessageBox.Show("Xóa công việc?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgvTasks.CurrentRow.Cells["TaskId"].Value);
                _taskBLL.DeleteTask(id);
                LoadTasks();
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e) => LoadTasks();
        private void ClearInputs()
        {
            txtTitle.Clear();
            txtNote.Clear();
            cboCategory.SelectedIndex = -1;
            dtpStart.Value = DateTime.Now;
            dtpEnd.Value = DateTime.Now;
            dtpEnd.Checked = false;
            cboStatus.SelectedIndex = 0;
            if (cboCategory.Items.Count > 0)
                cboCategory.SelectedIndex = 0;
            btnAdd.Enabled = true;
        }

        private void dgvTasks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgvTasks_SelectionChanged(object sender, EventArgs e)
        {
            if (_isLoading) return;

            if (dgvTasks.CurrentRow == null || !dgvTasks.CurrentRow.Selected)
            {
                ClearInputs();
                UpdateButtonState();
                return;
            }

            var row = dgvTasks.CurrentRow;
            txtTitle.Text = row.Cells["Title"].Value?.ToString() ?? "";
            txtNote.Text = row.Cells["Note"].Value?.ToString() ?? "";
            cboCategory.SelectedValue = row.Cells["CategoryId"].Value ?? 1;
            dtpStart.Value = Convert.ToDateTime(row.Cells["StartDate"].Value);

            var end = row.Cells["EndDate"].Value;
            if (end != DBNull.Value && end != null)
            {
                dtpEnd.Value = Convert.ToDateTime(end);
                dtpEnd.Checked = true;
            }
            else
            {
                dtpEnd.Value = DateTime.Now;
                dtpEnd.Checked = false;
            }

            // Khi Update -> cho user chọn status
            cboStatus.Items.Clear();
            cboStatus.Items.AddRange(new string[] { "Pending", "In Progress", "Done" });
            cboStatus.SelectedItem = row.Cells["Status"].Value?.ToString() ?? "In Progress";

            UpdateButtonState();
        }

        private void UpdateButtonState()
        {
            bool hasSelection = dgvTasks.CurrentRow != null && dgvTasks.CurrentRow.Selected;
            btnUpdate.Enabled = hasSelection;
            btnDelete.Enabled = hasSelection;
            btnAdd.Enabled = !hasSelection;
        }
    }
}
