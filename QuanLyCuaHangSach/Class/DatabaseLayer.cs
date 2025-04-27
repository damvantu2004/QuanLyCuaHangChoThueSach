using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BAEK_PERCENT.Database
{
    internal static class DatabaseLayer
    {
        private static readonly string connectionString =
            ConfigurationManager.ConnectionStrings["QuanLyCuaHangSach"].ConnectionString;

        public static SqlConnection conn { get; private set; }

        public static void Connect()
        {
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                MessageBox.Show("Kết nối  thành công");

                Console.WriteLine("Kết nối thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối không thành công: " + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static void Disconnect()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
                conn.Dispose();
                conn = null;
                Console.WriteLine("Đã đóng kết nối");
            }
        }

        public static DataTable GetDataToTable(string sql)
        {
            DataTable table = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn))
                    {
                        adapter.Fill(table);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy dữ liệu từ bảng: " + ex.Message);
            }

            return table;
        }

        public static DataTable GetDataToTable(string sql, SqlParameter[] parameters)
        {
            DataTable table = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);

                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
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

        public static DataTable GetDataToTable(string sql, string[] parameters, object[] values)
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

        public static bool CheckKey(string sql, SqlParameter[] parameters)
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

        public static void RunSql(string sql, SqlParameter[] parameters = null)
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

        public static void RunSqlDel(string sql, SqlParameter[] parameters = null)
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

        public static void FillCombo(string sql, ComboBox cbo, string valueMember, string displayMember)
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

                        cbo.DataSource = dataTable;
                        cbo.ValueMember = valueMember;
                        cbo.DisplayMember = displayMember;
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

        public static object GetFieldValues(string sql, SqlParameter[] parameters = null)
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

        public static string CreateKey(string tiento)
        {
            DateTime now = DateTime.Now;

            string datePart = now.ToString("yyMMdd");

            string timePart = now.ToString("HHmmss");

            string key = tiento + datePart + timePart;

            return key;
        }
    }
}
