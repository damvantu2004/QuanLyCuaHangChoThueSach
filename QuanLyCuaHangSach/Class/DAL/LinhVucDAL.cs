using BAEK_PERCENT.Database;
using System.Data;
using System.Data.SqlClient;

namespace BAEK_PERCENT.DAL
{
    internal class LinhVucDAL
    {
        private static readonly string TableName = "LinhVuc";

        public static DataTable GetAllLinhVuc()
        {
            string sql = @"SELECT * FROM LinhVuc";

            return DatabaseLayer.GetDataToTable(sql);
        }

        public static DataTable GetLinhVucBySearch(string search)
        {
            string sql = @"SELECT * FROM LinhVuc WHERE MaLV LIKE '%" + search + "%' OR TenLV LIKE N'%" + search + "%'";

            return DatabaseLayer.GetDataToTable(sql);
        }

        public static string InsertEmptyLinhVuc()
        {
            string sqlInsert = "INSERT INTO " + TableName + " (TenLV) VALUES ('null')";

            DatabaseLayer.RunSql(sqlInsert);
            return GetLastMaLV();
        }

        public static string GetLastMaLV()
        {
            string sql = "SELECT TOP 1 MaLV FROM " + TableName + " ORDER BY MaLV DESC";

            DataTable dt = DatabaseLayer.GetDataToTable(sql);

            if (dt.Rows.Count == 0)
            {
                return "";
            }

            return dt.Rows[0]["MaLV"].ToString();
        }

        public static void DeleteEmptyLinhVuc(string maLV)
        {
            string sqlCheck = "SELECT TenLV FROM " + TableName + " WHERE MaLV = @MaLV";
            SqlParameter[] param = { new SqlParameter("@MaLV", maLV) };

            DataTable dt = DatabaseLayer.GetDataToTable(sqlCheck, param);

            if (dt.Rows.Count > 0)
            {
                string tenLV = dt.Rows[0]["TenLV"].ToString();

                if (tenLV != "null")
                {
                    return;
                }
            }

            string sqlDelete = "DELETE FROM " + TableName + " WHERE MaLV = @MaLV";
            SqlParameter[] deleteParams = { new SqlParameter("@MaLV", maLV) };

            DatabaseLayer.RunSqlDel(sqlDelete, deleteParams);
        }

        public static void UpdateLinhVuc(string maLV, string tenLV)
        {
            string sqlUpdate = "UPDATE " + TableName + " SET TenLV = @TenLV WHERE MaLV = @MaLV";
            SqlParameter[] updateParams = {
                new SqlParameter("@TenLV", tenLV),
                new SqlParameter("@MaLV", maLV)
            };

            DatabaseLayer.RunSql(sqlUpdate, updateParams);
        }

        public static void DeleteLinhVuc(string maLV)
        {
            string sqlDelete = "DELETE FROM " + TableName + " WHERE MaLV = @MaLV";
            SqlParameter[] deleteParams = { new SqlParameter("@MaLV", maLV) };

            DatabaseLayer.RunSqlDel(sqlDelete, deleteParams);
        }
    }
}
