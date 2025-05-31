using System;

using System.Windows.Forms;


namespace BAEK_PERCENT
{
    internal static class Program

    {
        private static MainFormManager mainFormManager;
        public static MainFormManager FormControl
        {
            get { return mainFormManager; }
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles(); // Bật chế độ hiển thị giao diện người dùng hiện đại
            Application.SetCompatibleTextRenderingDefault(false); // để sử dụng GDI+ cho việc vẽ văn bản
            Database.DatabaseLayer.Connect(); 

            mainFormManager = new MainFormManager(); 
            mainFormManager.CurrentForm = mainFormManager.loginForm; 

            Application.Run(mainFormManager);
        }
    }
}
