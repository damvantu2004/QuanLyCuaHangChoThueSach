using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BAEK_PERCENT.Database
{
    internal static class DatabaseLayer //  kết nối csdl
    {
        private static readonly string connectionString =
            ConfigurationManager.ConnectionStrings["QuanLyCuaHangSach"].ConnectionString; // chuỗi kết nối csdl

        public static SqlConnection conn { get; private set; } // khai báo biến kết nối gồm SqlConnection, SqlCommand, SqlDataAdapter. Sqlcommand dùng để thực hiện các câu lệnh SQL, SqlDataAdapter dùng để chuyển đổi dữ liệu từ csdl về DataTable, sqlConnection dùng để kết nối csdl. getset là thuộc tính của biến conn, get là lấy giá trị của biến conn, set là gán giá trị cho biến conn, private set là chỉ cho phép truy cập từ trong class này, không cho phép truy cập từ ngoài class này.

        public static void Connect() // phương thức kết nối csdl
        {
            try
            {
                conn = new SqlConnection(connectionString); // khởi tạo biến conn với chuỗi kết nối csdl
                conn.Open();  // mở kết nối csdl

                Console.WriteLine("Kết nối thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối không thành công: " + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static void Disconnect() // phương thức ngắt kết nối csdl
        {
            if (conn != null && conn.State == ConnectionState.Open) // kiểm tra xem biến conn có khác null và trạng thái của biến conn có bằng Open không
            {
                conn.Close(); // ngắt kết nối csdl
                MessageBox.Show("Đã ngắt kết nối");
                Console.WriteLine("Đã ngắt kết nối");
            }
            else
            {
                conn.Close();
                conn.Dispose();
                conn = null;
                Console.WriteLine("Đã đóng kết nối");
            }
        }

        public static DataTable GetDataToTable(string sql) // phương thức lấy dữ liệu từ csdl
        {
            DataTable table = new DataTable(); // khởi tạo biến table với kiểu dữ liệu DataTable

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString)) // khởi tạo biến conn với chuỗi kết nối csdl
                {
                    conn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn)) // khởi tạo biến adapter 
                    {
                        adapter.Fill(table); // dùng để chuyển đổi dữ liệu từ csdl về DataTable
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy dữ liệu từ bảng: " + ex.Message);
            }

            return table;
        }

        public static DataTable GetDataToTable(string sql, SqlParameter[] parameters) // phương thức lấy dữ liệu từ csdl, khác với phương thức trên là có tham số SqlParameter[]. Parameter là kiểu dữ liệu dùng để truyền tham số vào câu lệnh SQL. SqlParameter[] là mảng các tham số SqlParameter.
        { // phương thức này dùng để truyền tham số vào câu lệnh SQL, phương thức trên không có tham số SqlParameter[] dùng để làm việc với câu lệnh SQL không có tham số. SqlParameter[] là mảng các tham số SqlParameter. SqlParameter là kiểu dữ liệu dùng để truyền tham số vào câu lệnh SQL. SqlParameter[] là mảng các tham số SqlParameter. SqlParameter là kiểu dữ liệu dùng để truyền tham số vào câu lệnh SQL. SqlParameter[] là mảng các tham số SqlParameter.
            DataTable table = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))// khởi tạo biến connection với chuỗi kết nối csdl
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection); // khởi tạo biến command với câu lệnh SQL và biến connection. biến command dùng để thực hiện các câu lệnh SQL,

                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters); // thêm các tham số vào câu lệnh SQL
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command); // khởi tạo biến adapter với câu lệnh SQL và biến connection. biến adapter dùng để chuyển đổi dữ liệu từ csdl về DataTable
                    adapter.Fill(table);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy dữ liệu từ bảng: " + ex.Message);
            }

            return table;
        }

        public static DataTable GetDataToTable(string sql, string[] parameters, object[] values) // phương thức lấy dữ liệu từ csdl, khác với phương thức trên là có tham số string[] parameters, object[] values. parameters là mảng các tham số string, values là mảng các tham số object. phương thức này dùng để truyền tham số vào câu lệnh SQL, phương thức trên không có tham số string[] parameters, object[] values dùng để làm việc với câu lệnh SQL không có tham số.
        {
            DataTable table = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);

                    if (parameters != null && values != null && parameters.Length == values.Length)
                    {
                        for (int i = 0; i < parameters.Length; i++)
                        {
                            command.Parameters.AddWithValue(parameters[i], values[i]);
                        }
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(table);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy dữ liệu từ bảng: " + ex.Message);
            }

            return table;
        }

        public static bool CheckKey(string sql, SqlParameter[] parameters) // phương thức kiểm tra khóa, khác với phương thức trên là có tham số SqlParameter[] parameters. phương thức này dùng để kiểm tra khóa trong csdl, phương thức trên không có tham số SqlParameter[] parameters dùng để làm việc với câu lệnh SQL không có tham số.
        {
            bool recordExists = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            recordExists = reader.HasRows;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi kiểm tra khóa: " + ex.Message);
                recordExists = false;
            }

            return recordExists;
        }

        public static void RunSql(string sql, SqlParameter[] parameters = null) // phương thức thực thi câu lệnh SQL, khác với phương thức trên là có tham số SqlParameter[] parameters. phương thức này dùng để thực thi câu lệnh SQL, phương thức trên không có tham số SqlParameter[] parameters dùng để làm việc với câu lệnh SQL không có tham số.
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void RunSqlDel(string sql, SqlParameter[] parameters = null) // phương thức thực thi câu lệnh SQL xóa, khác với phương thức trên là có tham số SqlParameter[] parameters. phương thức này dùng để thực thi câu lệnh SQL xóa, phương thức trên không có tham số SqlParameter[] parameters dùng để làm việc với câu lệnh SQL không có tham số.
        {
            try
            {
                RunSql(sql, parameters);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    MessageBox.Show("Dữ liệu đang được dùng, không thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static void FillCombo(string sql, ComboBox cbo, string valueMember, string displayMember) // phương thức điền dữ liệu vào ComboBox, khác với phương thức trên là có tham số ComboBox cbo, string valueMember, string displayMember. phương thức này dùng để điền dữ liệu vào ComboBox, phương thức trên không có tham số ComboBox cbo, string valueMember, string displayMember dùng để làm việc với câu lệnh SQL không có tham số.
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        DataTable dataTable = new DataTable();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd)) 
                        {
                            adapter.Fill(dataTable);
                        }

                        cbo.DataSource = dataTable; // gán nguồn dữ liệu cho ComboBox
                        cbo.ValueMember = valueMember;// gán giá trị cho thuộc tính ValueMember của ComboBox
                        cbo.DisplayMember = displayMember;// gán giá trị cho thuộc tính DisplayMember của ComboBox
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu vào ComboBox: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string GetFieldValues(string sql) 
        {
            string result = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        object value = cmd.ExecuteScalar();
                        if (value != null && value != DBNull.Value)
                        {
                            result = value.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy giá trị từ cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }

        public static object GetFieldValues(string sql, SqlParameter[] parameters = null) // phương thức lấy giá trị từ csdl
        {
            object result = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        if (parameters != null && parameters.Length > 0)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        result = cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy giá trị từ cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }

        public static string CreateKey(string tiento) //phương thức tạo khóa, dùng để tạo khóa cho các bảng trong csdl. phương thức này nhận vào một chuỗi tiento, chuỗi này dùng để tạo khóa cho các bảng trong csdl. phương thức này trả về một chuỗi khóa.
        {
            DateTime now = DateTime.Now;

            string datePart = now.ToString("yyMMdd");

            string timePart = now.ToString("HHmmss");

            string key = tiento + datePart + timePart;

            return key;
        }
    }
}
