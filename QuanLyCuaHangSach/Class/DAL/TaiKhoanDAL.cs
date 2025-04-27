using BAEK_PERCENT.Database;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BAEK_PERCENT.DAL
{
    internal class TaiKhoanDAL
    {
        private static readonly string TableName = "TaiKhoan";

        public static DataTable GetAllTaiKhoan()
        {
            string sql = @"SELECT * FROM TaiKhoan";

            return DatabaseLayer.GetDataToTable(sql);
        }

        public static DataTable GetTenDangNhap()
        {
            string sql = @"SELECT TenDangNhap FROM TaiKhoan";

            return DatabaseLayer.GetDataToTable(sql);
        }

        public static DataTable GetTaiKhoanBySearch(string search)
        {
            string sql = @"SELECT * FROM TaiKhoan WHERE TenDangNhap LIKE '%" + search + "%'";

            return DatabaseLayer.GetDataToTable(sql);
        }
        public static void InsertTaiKhoan(string username, string password, int priv)
        {
            string sqlCheckKey = "SELECT TenDangNhap FROM " + TableName + " WHERE TenDangNhap = @TenDangNhap";
            SqlParameter[] checkKeyParams = { new SqlParameter("@TenDangNhap", username) };

            if (DatabaseLayer.CheckKey(sqlCheckKey, checkKeyParams))
            {
                throw new Exception("Tài khoản đã tồn tại");
            }

            string sqlInsert = "INSERT INTO " + TableName + " (TenDangNhap, MatKhau, Quyen) VALUES (@TenDangNhap, @MatKhau, @Quyen)";
            SqlParameter[] insertParams = {
                new SqlParameter("@TenDangNhap", username),
                new SqlParameter("@MatKhau", password),
                new SqlParameter("@Quyen", priv)
            };

            DatabaseLayer.RunSql(sqlInsert, insertParams);
        }

        public static void UpdateTaiKhoan(string username, string password, int priv)
        {
            string sqlUpdate = "UPDATE " + TableName + " SET MatKhau = @MatKhau, Quyen = @Quyen WHERE TenDangNhap = @TenDangNhap";
            SqlParameter[] updateParams = {
                new SqlParameter("@MatKhau", password),
                new SqlParameter("@Quyen", priv),
                new SqlParameter("@TenDangNhap", username)
            };

            DatabaseLayer.RunSql(sqlUpdate, updateParams);
        }

        public static void DeleteTaiKhoan(string username)
        {
            string sqlDelete = "DELETE FROM " + TableName + " WHERE TenDangNhap = @TenDangNhap";
            SqlParameter[] deleteParams = { new SqlParameter("@TenDangNhap", username) };

            DatabaseLayer.RunSqlDel(sqlDelete, deleteParams);
        }
    }
}
