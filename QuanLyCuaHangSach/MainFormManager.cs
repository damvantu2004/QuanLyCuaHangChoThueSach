using BAEK_PERCENT.Forms;
using QuanLyCuaHangSach;
using System;
using System.Windows.Forms;

namespace BAEK_PERCENT
{
    internal class MainFormManager : ApplicationContext
    {
        public readonly frmMain mainForm;
        public readonly newfrmLogin loginForm;

        private void initForm(Form form)
        {
            form.FormBorderStyle = FormBorderStyle.None; // xóa viền của form
            form.Dock = DockStyle.Fill; // đặt form chiếm toàn bộ không gian của cha
            form.Hide(); // ẩn form ban đầu
        }

        public MainFormManager()
        {
            mainForm = new frmMain(); 
            initForm(mainForm);  // khởi tạo form chính với các thuộc tính cần thiết ở initForm với viền bỏ đi và chiếm toàn bộ không gian của cha

            loginForm = new newfrmLogin();
            initForm(loginForm); // khởi tạo form đăng nhập với các thuộc tính cần thiết ở initForm với viền bỏ đi và chiếm toàn bộ không gian của cha
        }

        public Form CurrentForm
        {
            get { return MainForm; } // trả về form hiện tại đang hiển thị
            set
            {
                if (MainForm != null)
                {
                    // nếu form hiện tại không phải là null, ẩn nó đi
                    MainForm.Hide();
                }
                MainForm = value; // gán form hiện tại là form mới được truyền vào
                MainForm.Show();
            }
        }

        protected override void OnMainFormClosed(object sender, EventArgs e)
        {
            Console.WriteLine("Closed all");
            base.OnMainFormClosed(sender, e);
        }
    }
}
