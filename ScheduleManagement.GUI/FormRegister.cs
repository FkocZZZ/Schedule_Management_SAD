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
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();
                string confirmPwd = txtConfirmPassword.Text.Trim();

                // Validate không để trống
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Username và Password không được để trống!", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate confirm password
                if (password != confirmPwd)
                {
                    MessageBox.Show("Password và Confirm Password không khớp!", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                UserBLL userBLL = new UserBLL();

                // Kiểm tra username tồn tại
                if (userBLL.IsUsernameExists(username))
                {
                    MessageBox.Show("Username đã tồn tại, vui lòng chọn tên khác!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Thêm user
                bool success = userBLL.RegisterUser(username, password); // password có thể hash ở BLL

                if (success)
                {
                    MessageBox.Show("Đăng ký thành công! Bạn có thể đăng nhập ngay.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Đóng form, quay về FormLogin
                }
                else
                {
                    MessageBox.Show("Đăng ký thất bại, thử lại sau.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
