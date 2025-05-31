using BAEK_PERCENT.Database;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BAEK_PERCENT.DAL
{
    internal class KhachHangDAL
    {
        private static readonly string TableName = "KhachHang";

        public static DataTable GetAllKhachHang()
        {
            string sql = @"SELECT * FROM KhachHang";

            return DatabaseLayer.GetDataToTable(sql);
        }

        public static DataTable GetKhachHangBySearch(string search)
        {
            string sql = @"SELECT * FROM KhachHang WHERE MaKH LIKE '%" + search + "%' OR TenKH LIKE N'%" + search + "%'";

            return DatabaseLayer.GetDataToTable(sql);
        }

        public static string InsertEmptyKhachHang()
        {
            string sqlInsert = "INSERT INTO " + TableName + " (TenKH, NgaySinh, GioiTinh, DiaChi, SDT) VALUES ('null', '01/01/2000', 0, 'null', 'null')"; 

            DatabaseLayer.RunSql(sqlInsert);
            return GetLastMaKH();
        }

        public static string GetLastMaKH()
        {
            string sql = "SELECT TOP 1 MaKH FROM " + TableName + " ORDER BY MaKH DESC";

            DataTable dt = DatabaseLayer.GetDataToTable(sql);

            if (dt.Rows.Count == 0)
            {
                return "";
            }

            return dt.Rows[0]["MaKH"].ToString();
        }

        public static void DeleteEmptyKhachHang(string maKH)
        {
            string sqlCheck = "SELECT TenKH FROM " + TableName + " WHERE MaKH = @MaKH";
            SqlParameter[] param = { new SqlParameter("@MaKH", maKH) };

            DataTable dt = DatabaseLayer.GetDataToTable(sqlCheck, param);

            if (dt.Rows.Count > 0)
            {
                string tenKH = dt.Rows[0]["TenKH"].ToString();

                if (tenKH != "null")
                {
                    return;
                }
            }

            string sqlDelete = "DELETE FROM " + TableName + " WHERE MaKH = @MaKH";
            SqlParameter[] deleteParams = { new SqlParameter("@MaKH", maKH) };

            DatabaseLayer.RunSqlDel(sqlDelete, deleteParams);
        }

        public static void UpdateKhachHang(string maKH, string tenKH, DateTime ngaySinh, bool gioiTinh, string diaChi, string SDT)
        {
            string sqlUpdate = "UPDATE " + TableName + " SET TenKH = @TenKH, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, DiaChi = @DiaChi, SDT = @SDT WHERE MaKH = @MaKH";
            SqlParameter[] updateParams = {
                new SqlParameter("@TenKH", tenKH),
                new SqlParameter("@MaKH", maKH),
                new SqlParameter("@NgaySinh", ngaySinh),
                new SqlParameter("@GioiTinh", gioiTinh),
                new SqlParameter("@DiaChi", diaChi),
                new SqlParameter("@SDT", SDT)
            };

            DatabaseLayer.RunSql(sqlUpdate, updateParams);
        }

        public static void DeleteKhachHang(string maKH)
        {
            string sqlDelete = "DELETE FROM " + TableName + " WHERE MaKH = @MaKH";
            SqlParameter[] deleteParams = { new SqlParameter("@MaKH", maKH) };

            DatabaseLayer.RunSqlDel(sqlDelete, deleteParams);
        }

        public static string GetTenKhachHangByMa(string maKH)
        {
            string query = "SELECT TenKH FROM KhachHang WHERE MaKH = @MaKH";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaKH", maKH)
            };

            DataTable dt = DatabaseLayer.GetDataToTable(query, parameters);

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["TenKH"].ToString();
            }

            return string.Empty;
        }
    }
}