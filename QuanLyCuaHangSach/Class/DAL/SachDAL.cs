using BAEK_PERCENT.Database;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BAEK_PERCENT.DAL
{
    internal class SachDAL
    {
        private static readonly string TableName = "Sach";

        public static DataTable GetAllSach()
        {
            string sql = @"SELECT * FROM Sach";

            return DatabaseLayer.GetDataToTable(sql);
        }

        public static DataTable GetSachBySearch(string searchOption, string searchKeyword)
        {
            string sql = "SELECT Sach.* FROM Sach ";

            switch (searchOption)
            {
                case "Mã sách":
                    sql += $"WHERE MaSach LIKE '%{searchKeyword}%'";
                    break;
                case "Tên sách":
                    sql += $"WHERE TenSach LIKE N'%{searchKeyword}%'";
                    break;
                case "Loại sách":
                    sql += $"INNER JOIN LoaiSach ON Sach.MaLoai = LoaiSach.MaLoai WHERE LoaiSach.TenLoai LIKE N'%{searchKeyword}%'";
                    break;
                case "Lĩnh vực":
                    sql += $"INNER JOIN LinhVuc ON Sach.MaLV = LinhVuc.MaLV WHERE LinhVuc.MaLV LIKE N'%{searchKeyword}%'";
                    break;
                case "Tác giả":
                    sql += $"INNER JOIN TacGia ON Sach.MaTG = TacGia.MaTG WHERE TacGia.TenTG LIKE N'%{searchKeyword}%'";
                    break;
                case "Ngôn ngữ":
                    sql += $"INNER JOIN NgonNgu ON Sach.MaNN = NgonNgu.MaNN WHERE NgonNgu.TenNN LIKE N'%{searchKeyword}%'";
                    break;
                default:
                    throw new ArgumentException("Không có tuỳ chọn tìm kiếm");
            }

            sql += " AND Sach.SoLuong > 0";

            return DatabaseLayer.GetDataToTable(sql);
        }

        public static string InsertEmptySach()
        {
            string sqlInsert = "INSERT INTO " + TableName + " (TenSach, SoTrang, GiaSach, DonGiaThue, SoLuong) VALUES ('null', -1, -1, -1, -1)";

            DatabaseLayer.RunSql(sqlInsert);
            return GetLastMaSach();
        }

        public static string GetLastMaSach()
        {
            string sql = "SELECT TOP 1 MaSach FROM " + TableName + " ORDER BY MaSach DESC";

            DataTable dt = DatabaseLayer.GetDataToTable(sql);

            if (dt.Rows.Count == 0)
            {
                return "";
            }

            return dt.Rows[0]["MaSach"].ToString();
        }

        public static void DeleteEmptySach(string maSach)
        {
            string sqlCheck = "SELECT TenSach FROM " + TableName + " WHERE MaSach = @MaSach";
            SqlParameter[] param = { new SqlParameter("@MaSach", maSach) };

            DataTable dt = DatabaseLayer.GetDataToTable(sqlCheck, param);

            if (dt.Rows.Count > 0)
            {
                string tenSach = dt.Rows[0]["TenSach"].ToString();

                if (tenSach != "null")
                {
                    return;
                }
            }

            string sqlDelete = "DELETE FROM " + TableName + " WHERE MaSach = @MaSach";
            SqlParameter[] deleteParams = { new SqlParameter("@MaSach", maSach) };

            DatabaseLayer.RunSqlDel(sqlDelete, deleteParams);
        }

        public static void UpdateSach(string maSach, string tenSach, string loai, string linhVuc, string tacGia, string ngonNgu, int soTrang, int gia, int giaThue, int soLuong, string anh, string ghiChu)
        {
            string sqlUpdate = "UPDATE " + TableName + " SET TenSach = @TenSach, MaLoai = @MaLoai, MaLV = @MaLV, MaTG = @MaTG, MaNN = @MaNN, " +
                "SoTrang = @SoTrang, GiaSach = @GiaSach, DonGiaThue = @DonGiaThue, SoLuong = @SoLuong, Anh = @Anh, GhiChu = @GhiChu WHERE MaSach = @MaSach";
            SqlParameter[] updateParams = {
                new SqlParameter("@TenSach", tenSach),
                new SqlParameter("@MaLoai", loai),
                new SqlParameter("@MaLV", linhVuc),
                new SqlParameter("@MaTG", tacGia),

                new SqlParameter("@MaNN", ngonNgu),
                new SqlParameter("@SoTrang", soTrang),
                new SqlParameter("@GiaSach", gia),
                new SqlParameter("@DonGiaThue", giaThue),

                new SqlParameter("@SoLuong", soLuong),
                new SqlParameter("@Anh", anh),
                new SqlParameter("@GhiChu", ghiChu),
                new SqlParameter("@MaSach", maSach)
            };

            DatabaseLayer.RunSql(sqlUpdate, updateParams);
        }

        public static void DeleteSach(string maSach)
        {
            string sqlDelete = "DELETE FROM " + TableName + " WHERE MaSach = @MaSach";
            SqlParameter[] deleteParams = { new SqlParameter("@MaSach", maSach) };

            DatabaseLayer.RunSqlDel(sqlDelete, deleteParams);
        }

        public static Tuple<string, string> GetTenGiaSachByMa(string maSach)
        {
            string query = "SELECT TenSach, DonGiaThue FROM Sach WHERE MaSach = @MaSach";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaSach", maSach)
            };

            DataTable dt = DatabaseLayer.GetDataToTable(query, parameters);

            if (dt.Rows.Count > 0)
            {
                string tenSach = dt.Rows[0]["TenSach"].ToString();
                string donGiaThue = dt.Rows[0]["DonGiaThue"].ToString();
                return Tuple.Create(tenSach, donGiaThue);
            }

            return null;
        }

        public static string GetTenSachByMa(string maSach)
        {
            string query = "SELECT TenSach FROM Sach WHERE MaSach = @MaSach";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaSach", maSach)
            };

            DataTable dt = DatabaseLayer.GetDataToTable(query, parameters);

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["TenSach"].ToString();
            }

            return string.Empty;
        }

        public static int GetSoLuong(string maSach)
        {
            string sql = "SELECT SoLuong FROM Sach WHERE MaSach = @MaSach";
            SqlParameter[] param = { new SqlParameter("@MaSach", maSach) };

            DataTable dt = DatabaseLayer.GetDataToTable(sql, param);

            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["SoLuong"].ToString());
            }
            return 0;
        }

        public static void GiamSoLuong(string maSach)
        {
            string sql = "UPDATE Sach SET SoLuong = SoLuong - 1 WHERE MaSach = @MaSach";
            SqlParameter[] param = { new SqlParameter("@MaSach", maSach) };

            DatabaseLayer.RunSql(sql, param);
        }

        public static void TangSoLuong(string maSach)
        {
            string sql = "UPDATE Sach SET SoLuong = SoLuong + 1 WHERE MaSach = @MaSach";
            SqlParameter[] param = { new SqlParameter("@MaSach", maSach) };

            DatabaseLayer.RunSql(sql, param);
        }

        public static int GetGiaSach(string maSach)
        {
            string sql = "SELECT GiaSach FROM Sach WHERE MaSach = @MaSach";
            SqlParameter[] param = { new SqlParameter("@MaSach", maSach) };

            DataTable dt = DatabaseLayer.GetDataToTable(sql, param);

            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["GiaSach"].ToString());
            }
            return 0;
        }
    }
}
