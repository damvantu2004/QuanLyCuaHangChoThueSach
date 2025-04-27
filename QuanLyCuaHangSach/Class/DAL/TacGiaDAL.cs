using BAEK_PERCENT.Database;
using System.Data;
using System.Data.SqlClient;

namespace BAEK_PERCENT.DAL
{
    internal class TacGiaDAL
    {
        private static readonly string TableName = "TacGia";

        public static DataTable GetAllTacGia()
        {
            string sql = @"SELECT * FROM TacGia";

            return DatabaseLayer.GetDataToTable(sql);
        }

        public static DataTable GetTacGiaBySearch(string search)
        {
            string sql = @"SELECT * FROM TacGia WHERE MaTG LIKE '%" + search + "%' OR TenTG LIKE N'%" + search + "%'";

            return DatabaseLayer.GetDataToTable(sql);
        }

        public static string InsertEmptyTacGia()
        {
            string sqlInsert = "INSERT INTO " + TableName + " (TenTG) VALUES ('null')";

            DatabaseLayer.RunSql(sqlInsert);
            return GetLastMaTG();
        }

        public static string GetLastMaTG()
        {
            string sql = "SELECT TOP 1 MaTG FROM " + TableName + " ORDER BY MaTG DESC";

            DataTable dt = DatabaseLayer.GetDataToTable(sql);

            if (dt.Rows.Count == 0)
            {
                return "";
            }

            return dt.Rows[0]["MaTG"].ToString();
        }

        public static void DeleteEmptyTacGia(string maTG)
        {
            string sqlCheck = "SELECT TenTG FROM " + TableName + " WHERE MaTG = @MaTG";
            SqlParameter[] param = { new SqlParameter("@MaTG", maTG) };

            DataTable dt = DatabaseLayer.GetDataToTable(sqlCheck, param);

            if (dt.Rows.Count > 0)
            {
                string tenTG = dt.Rows[0]["TenTG"].ToString();

                if (tenTG != "null")
                {
                    return;
                }
            }

            string sqlDelete = "DELETE FROM " + TableName + " WHERE MaTG = @MaTG";
            SqlParameter[] deleteParams = { new SqlParameter("@MaTG", maTG) };

            DatabaseLayer.RunSqlDel(sqlDelete, deleteParams);
        }

        public static void UpdateTacGia(string maTG, string tenTG)
        {
            string sqlUpdate = "UPDATE " + TableName + " SET TenTG = @TenTG WHERE MaTG = @MaTG";
            SqlParameter[] updateParams = {
                new SqlParameter("@TenTG", tenTG),
                new SqlParameter("@MaTG", maTG)
            };

            DatabaseLayer.RunSql(sqlUpdate, updateParams);
        }

        public static void DeleteTacGia(string maTG)
        {
            string sqlDelete = "DELETE FROM " + TableName + " WHERE MaTG = @MaTG";
            SqlParameter[] deleteParams = { new SqlParameter("@MaTG", maTG) };

            DatabaseLayer.RunSqlDel(sqlDelete, deleteParams);
        }
    }
}
