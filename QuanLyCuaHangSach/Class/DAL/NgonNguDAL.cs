using BAEK_PERCENT.Database;
using System.Data;
using System.Data.SqlClient;

namespace BAEK_PERCENT.DAL
{
    internal class NgonNguDAL
    {
        private static readonly string TableName = "NgonNgu";

        public static DataTable GetAllNgonNgu()
        {
            string sql = @"SELECT * FROM NgonNgu";

            return DatabaseLayer.GetDataToTable(sql);
        }

        public static DataTable GetNgonNguBySearch(string search)
        {
            string sql = @"SELECT * FROM NgonNgu WHERE MaNN LIKE '%" + search + "%' OR TenNN LIKE N'%" + search + "%'";

            return DatabaseLayer.GetDataToTable(sql);
        }

        public static string InsertEmptyNgonNgu()
        {
            string sqlInsert = "INSERT INTO " + TableName + " (TenNN) VALUES ('null')";

            DatabaseLayer.RunSql(sqlInsert);
            return GetLastMaNN();
        }

        public static string GetLastMaNN()
        {
            string sql = "SELECT TOP 1 MaNN FROM " + TableName + " ORDER BY MaNN DESC";

            DataTable dt = DatabaseLayer.GetDataToTable(sql);

            if (dt.Rows.Count == 0)
            {
                return "";
            }

            return dt.Rows[0]["MaNN"].ToString();
        }

        public static void DeleteEmptyNgonNgu(string maNN)
        {
            string sqlCheck = "SELECT TenNN FROM " + TableName + " WHERE MaNN = @MaNN";
            SqlParameter[] param = { new SqlParameter("@MaNN", maNN) };

            DataTable dt = DatabaseLayer.GetDataToTable(sqlCheck, param);

            if (dt.Rows.Count > 0)
            {
                string tenNN = dt.Rows[0]["TenNN"].ToString();

                if (tenNN != "null")
                {
                    return;
                }
            }

            string sqlDelete = "DELETE FROM " + TableName + " WHERE MaNN = @MaNN";
            SqlParameter[] deleteParams = { new SqlParameter("@MaNN", maNN) };

            DatabaseLayer.RunSqlDel(sqlDelete, deleteParams);
        }

        public static void UpdateNgonNgu(string maNN, string tenNN)
        {
            string sqlUpdate = "UPDATE " + TableName + " SET TenNN = @TenNN WHERE MaNN = @MaNN";
            SqlParameter[] updateParams = {
                new SqlParameter("@TenNN", tenNN),
                new SqlParameter("@MaNN", maNN)
            };

            DatabaseLayer.RunSql(sqlUpdate, updateParams);
        }

        public static void DeleteNgonNgu(string maNN)
        {
            string sqlDelete = "DELETE FROM " + TableName + " WHERE MaNN = @MaNN";
            SqlParameter[] deleteParams = { new SqlParameter("@MaNN", maNN) };

            DatabaseLayer.RunSqlDel(sqlDelete, deleteParams);
        }
    }
}
