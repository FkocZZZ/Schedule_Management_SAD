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
    public partial class FormCategory : Form
    {
        private readonly CategoryBLL _bll;
        public FormCategory()
        {
            InitializeComponent();
            _bll = new CategoryBLL();
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                dgvCategories.DataSource = null;
                dgvCategories.DataSource = _bll.GetAllCategories();
                //dgvCategories.Columns["CategoryId"].Visible = false;
                dgvCategories.Columns["CategoryId"].Width = 50;
                dgvCategories.Columns["CategoryId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                dgvCategories.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvCategories.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                CategoryModel c = new CategoryModel
                {
                    Name = txtName.Text.Trim(),
                    Description = txtDescription.Text.Trim()
                };
                _bll.AddCategory(c);
                LoadData();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentRow == null) return;

            try
            {
                CategoryModel c = new CategoryModel
                {
                    CategoryId = Convert.ToInt32(dgvCategories.CurrentRow.Cells["CategoryId"].Value),
                    Name = txtName.Text.Trim(),
                    Description = txtDescription.Text.Trim()
                };
                _bll.UpdateCategory(c);
                LoadData();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            ClearInputs();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentRow == null) return;

            try
            {
                int id = Convert.ToInt32(dgvCategories.CurrentRow.Cells["CategoryId"].Value);
                var result = MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    _bll.DeleteCategory(id);
                    LoadData();
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dgvCategories_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentRow == null) return;

            txtName.Text = dgvCategories.CurrentRow.Cells["Name"].Value.ToString();
            txtDescription.Text = dgvCategories.CurrentRow.Cells["Description"].Value.ToString();
        }

        private void ClearInputs()
        {
            txtName.Text = "";
            txtDescription.Text = "";
        }

        private void dgvCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
