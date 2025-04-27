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
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.Hide();
        }

        public MainFormManager()
        {
            mainForm = new frmMain();
            initForm(mainForm);

            loginForm = new newfrmLogin();
            initForm(loginForm);
        }

        public Form CurrentForm
        {
            get { return MainForm; }
            set
            {
                if (MainForm != null)
                {
                    // hide the current form, but don't exit the application
                    MainForm.Hide();
                }
                // switch to the new form
                MainForm = value;
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
