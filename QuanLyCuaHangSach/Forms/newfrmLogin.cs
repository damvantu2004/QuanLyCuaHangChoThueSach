using BAEK_PERCENT.Class;
using BAEK_PERCENT.Class.Types;
using BAEK_PERCENT.DAL;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace BAEK_PERCENT.Forms
{
    public partial class newfrmLogin : MaterialForm
    {
        public newfrmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            MaterialSkinManager.Instance.AddFormToManage(this);
            txtUsername.Focus();
        }

        private void Authenticate()
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (username == "root" && password == "root")
            {
                Program.FormControl.mainForm.currentRole = UserRole.Admin; // trả về giá trị UserRole.Admin nếu đăng nhập với tài khoản root
                Program.FormControl.mainForm.Username = username; // gán tên đăng nhập là root

                txtPassword.Clear();
                lblError.Hide(); // ẩn thông báo lỗi nếu đăng nhập thành công

                Program.FormControl.CurrentForm = Program.FormControl.mainForm; // chuyển sang form chính là mainForm
                return;
            }

            string hashedPassword = Functions.ComputeSha256Hash(password);
            UserRole? tempRole = LoginDAL.TryLogin(username, hashedPassword);  // nếu đăng nhập thành công thì trả về UserRole, nếu không thì trả về null

            if (tempRole.HasValue) // kiểm tra xem tempRole có giá trị hay không, hashValue để tránh lỗi khi tempRole là null
            {
                Program.FormControl.mainForm.currentRole = tempRole.Value; // gán giá trị cho currentRole
                Program.FormControl.mainForm.Username = username; // gán tên đăng nhập

                txtPassword.Clear();
                lblError.Hide();

                Program.FormControl.CurrentForm = Program.FormControl.mainForm; // chuyển sang form chính
            }
            else
            {
                lblError.Show();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Authenticate();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Authenticate();
                e.SuppressKeyPress = true;
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Authenticate();
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.Tab)
            {
                txtPassword.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void newfrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}