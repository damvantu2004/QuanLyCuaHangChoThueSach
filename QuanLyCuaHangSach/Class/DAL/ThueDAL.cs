using BAEK_PERCENT.Database;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BAEK_PERCENT.DAL
{
    internal class ThueDAL
    {
        private static readonly string TableName = "ThueSach";
        private static readonly string TableCTName = "CTThueSach";

        public static DataTable GetAllThue()
        {
            string sql = $"SELECT T.MaThue, T.MaKH, KH.TenKH, T.MaNV, NV.TenNV, T.NgayThue, T.NgayTra, T.TienDatCoc FROM {TableName} T INNER JOIN KhachHang KH ON T.MaKH = KH.MaKH INNER JOIN NhanVien NV ON T.MaNV = NV.MaNV";

            return DatabaseLayer.GetDataToTable(sql);
        }

        public static DataTable GetCTThue(string maThue)
        {
            string sql = $"SELECT CT.MaSach, S.TenSach, CT.GiaThue, CT.DaTra FROM {TableCTName} CT INNER JOIN Sach S ON CT.MaSach = S.MaSach WHERE CT.MaThue = @MaThue";
            SqlParameter[] param = { new SqlParameter("@MaThue", maThue) };

            return DatabaseLayer.GetDataToTable(sql, param);
        }

        public static DataTable GetCTThueChuaTra(string maThue)
        {
            string sql = $"SELECT CT.MaSach, S.TenSach, CT.GiaThue, CT.DaTra FROM {TableCTName} CT INNER JOIN Sach S ON CT.MaSach = S.MaSach WHERE CT.MaThue = @MaThue AND CT.DaTra = 0";
            SqlParameter[] param = { new SqlParameter("@MaThue", maThue) };

            return DatabaseLayer.GetDataToTable(sql, param);
        }

        public static DataTable GetThongTinThue(string maThue)
        {
            string sql = @"SELECT T.MaThue, T.NgayThue, T.NgayTra, SUM(CT.GiaThue) as TongTien, T.TienDatCoc, KH.TenKH, KH.SDT, KH.DiaChi, NV.TenNV 
                   FROM ThueSach T 
                   INNER JOIN KhachHang KH ON T.MaKH = KH.MaKH 
                   INNER JOIN NhanVien NV ON T.MaNV = NV.MaNV 
                   INNER JOIN CTThueSach CT ON T.MaThue = CT.MaThue 
                   WHERE T.MaThue = @MaThue  
                   GROUP BY T.MaThue, T.NgayThue, T.NgayTra, T.TienDatCoc, KH.TenKH, KH.SDT, KH.DiaChi, NV.TenNV";

            SqlParameter[] sqlParams = {
                new SqlParameter("@MaThue", maThue)
            };

            return DatabaseLayer.GetDataToTable(sql, sqlParams);
        }

        public static DataTable GetThongTinCTThue(string maThue)
        {
            string sql = @"SELECT CT.MaSach, S.TenSach, CT.GiaThue 
                   FROM CTThueSach CT 
                   INNER JOIN Sach S ON CT.MaSach = S.MaSach 
                   WHERE CT.MaThue = @MaThue";

            SqlParameter[] sqlParams = {
                new SqlParameter("@MaThue", maThue)
            };

            return DatabaseLayer.GetDataToTable(sql, sqlParams);
        }

        public static DataTable GetThueBySearch(string searchOption, string searchKeyword)
        {
            string sql = "SELECT T.MaThue, T.MaKH, KH.TenKH, T.MaNV, NV.TenNV, T.NgayThue, T.NgayTra, T.TienDatCoc FROM " + TableName + " T INNER JOIN KhachHang KH ON T.MaKH = KH.MaKH INNER JOIN NhanVien NV ON T.MaNV = NV.MaNV ";

            DateTime parsedDate;
            bool isDate = DateTime.TryParseExact(searchKeyword, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out parsedDate);

            switch (searchOption)
            {
                case "Mã thuê":
                    sql += $"WHERE T.MaThue LIKE '%{searchKeyword}%'";
                    break;
                case "Tên khách hàng":
                    sql += $"WHERE KH.TenKH LIKE N'%{searchKeyword}%'";
                    break;
                case "Ngày thuê":
                    if (isDate)
                    {
                        sql += $"WHERE CONVERT(date, T.NgayThue, 103) = CONVERT(date, '{parsedDate:dd/MM/yyyy}', 103)";
                    }
                    else
                    {
                        throw new ArgumentException("Ngày thuê không hợp lệ");
                    }
                    break;
                case "Ngày trả":
                    if (isDate)
                    {
                        sql += $"WHERE CONVERT(date, T.NgayTra, 103) = CONVERT(date, '{parsedDate:dd/MM/yyyy}', 103)";
                    }
                    else
                    {
                        throw new ArgumentException("Ngày trả không hợp lệ");
                    }
                    break;
                default:
                    throw new ArgumentException("Không có tuỳ chọn tìm kiếm");
            }

            return DatabaseLayer.GetDataToTable(sql);
        }

        public static void DeleteThue(string maThue)
        {
            string sqlDelete = "DELETE FROM " + TableName + " WHERE MaThue = @MaThue";
            SqlParameter[] deleteParams = { new SqlParameter("@MaThue", maThue) };

            DatabaseLayer.RunSqlDel(sqlDelete, deleteParams);
        }

        public static void DeleteCTThue(string maThue)
        {
            string sqlDelete = "DELETE FROM " + TableCTName + " WHERE MaThue = @MaThue";
            SqlParameter[] deleteParams = { new SqlParameter("@MaThue", maThue) };

            DatabaseLayer.RunSqlDel(sqlDelete, deleteParams);
        }

        public static bool CheckMaThueExists(string maThue)
        {
            string sql = "SELECT MaThue FROM " + TableName + " + WHERE MaThue = @MaThue";

            SqlParameter[] sqlParams = {
                new SqlParameter("@MaThue", maThue)
            };

            return DatabaseLayer.CheckKey(sql, sqlParams);
        }

        public static string InsertEmptyThue(string maThue)
        {
            string sqlInsert = "INSERT INTO " + TableName + " (MaThue, NgayThue, NgayTra, TienDatCoc) VALUES (@MaThue, '01/01/2000', '01/02/2000', -1)";
            SqlParameter[] insertParams = { new SqlParameter("@MaThue", maThue) };

            DatabaseLayer.RunSql(sqlInsert, insertParams);

            return GetLastMaThue();
        }

        public static string GetLastMaThue()
        {
            string sql = "SELECT TOP 1 MaThue FROM " + TableName + " ORDER BY MaThue DESC";

            DataTable dt = DatabaseLayer.GetDataToTable(sql);

            if (dt.Rows.Count == 0)
            {
                return "";
            }

            return dt.Rows[0]["MaThue"].ToString();
        }

        public static void DeleteEmptyThue(string maThue)
        {
            string sqlCheck = "SELECT TienDatCoc FROM " + TableName + " WHERE MaThue = @MaThue AND TienDatCoc = -1";

            SqlParameter[] sqlParams = { new SqlParameter("@MaThue", maThue) };

            DataTable dt = DatabaseLayer.GetDataToTable(sqlCheck, sqlParams);

            if (dt.Rows.Count > 0)
            {
                int tienDatCoc = Convert.ToInt32(dt.Rows[0]["TienDatCoc"].ToString());

                if (tienDatCoc != -1)
                {
                    return;
                }
            }
            else
            {
                return;
            }

            string sqlDelete = "DELETE FROM " + TableName + " WHERE MaThue = @MaThue";
            string sqlDeleteCT = "DELETE FROM " + TableCTName + " WHERE MaThue = @MaThue";

            SqlParameter[] parameters = { new SqlParameter("@MaThue", maThue) };
            SqlParameter[] parametersCT = { new SqlParameter("@MaThue", maThue) };

            DatabaseLayer.RunSqlDel(sqlDeleteCT, parametersCT);
            DatabaseLayer.RunSqlDel(sqlDelete, parameters);
        }

        public static void UpdateThue(string maThue, string maKH, string maNV, DateTime ngayThue, DateTime ngayTra, int tienDatCoc)
        {
            string sqlUpdate = "UPDATE " + TableName + " SET MaKH = @MaKH, MaNV = @MaNV, NgayThue = @NgayThue, NgayTra = @NgayTra, TienDatCoc = @TienDatCoc WHERE MaThue = @MaThue";
            SqlParameter[] updateParams =
            {
                new SqlParameter("@MaKH", maKH),
                new SqlParameter("@MaNV", maNV),
                new SqlParameter("@NgayThue", ngayThue),
                new SqlParameter("@NgayTra", ngayTra),
                new SqlParameter("@TienDatCoc", tienDatCoc),
                new SqlParameter("@MaThue", maThue)
            };

            DatabaseLayer.RunSql(sqlUpdate, updateParams);
        }

        public static void InsertSachCTThue(string maThue, string maSach, int giaThue, bool trangThai)
        {
            string sql = "INSERT INTO " + TableCTName + " (MaThue, MaSach, GiaThue, DaTra) VALUES (@MaThue, @MaSach, @GiaThue, @DaTra)";

            SqlParameter[] sqlParams = {
                new SqlParameter("@MaThue", maThue),
                new SqlParameter("@MaSach", maSach),
                new SqlParameter("@GiaThue", giaThue),
                new SqlParameter("@DaTra", trangThai)
            };

            DatabaseLayer.RunSql(sql, sqlParams);
        }

        public static bool CheckMaSach(string maThue, string maSach)
        {
            string sql = "SELECT MaSach FROM " + TableCTName + " WHERE MaThue = @MaThue AND MaSach = @MaSach";
            SqlParameter[] sqlParams =
            {
                new SqlParameter("@MaThue", maThue),
                new SqlParameter("@MaSach", maSach)
            };

            return DatabaseLayer.CheckKey(sql, sqlParams);
        }

        public static void UpdateSachCTThue(string maThue, string maSach, int giaThue, bool trangThai)
        {
            string sql = "UPDATE " + TableCTName + " SET GiaThue = @GiaThue, DaTra = @DaTra WHERE MaThue = @MaThue AND MaSach = @MaSach";

            SqlParameter[] sqlParams =
            {
                new SqlParameter("@GiaThue", giaThue),
                new SqlParameter("@DaTra", trangThai),
                new SqlParameter("@MaThue", maThue),
                new SqlParameter("@MaSach", maSach)
            };

            DatabaseLayer.RunSql(sql, sqlParams);
        }

        public static void DeleteSachCTThue(string maThue, string maSach)
        {
            string sql = "DELETE FROM " + TableCTName + " WHERE MaThue = @MaThue AND MaSach = @MaSach";

            SqlParameter[] sqlParams =
            {
                new SqlParameter("@MaThue", maThue),
                new SqlParameter("@MaSach", maSach)
            };

            DatabaseLayer.RunSqlDel(sql, sqlParams);
        }
    }
}
