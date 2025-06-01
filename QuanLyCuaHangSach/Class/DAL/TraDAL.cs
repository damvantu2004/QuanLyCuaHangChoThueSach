using BAEK_PERCENT.Database;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BAEK_PERCENT.DAL
{
    internal class TraDAL
    {
        private static readonly string TableName = "TraSach";
        private static readonly string TableCTName = "CTTraSach";
        private static readonly string TableThueName = "ThueSach";

        public static DataTable GetAllTra()
        {
            string sql = "SELECT Tr.MaTra, Tr.MaThue, T.MaKH, KH.TenKH, Tr.MaNV, NV.TenNV, T.NgayThue, T.NgayTra, Tr.NgayTra AS NgayThucTe, T.TienDatCoc, Tr.TongTien " +
                $"FROM {TableName} Tr " +
                $"INNER JOIN {TableThueName} T ON Tr.MaThue = T.MaThue " +
                "INNER JOIN KhachHang KH ON T.MaKH = KH.MaKH " +
                "INNER JOIN NhanVien NV ON T.MaNV = NV.MaNV";

            return DatabaseLayer.GetDataToTable(sql);
        }

        public static DataTable GetThongTinTra(string maThue)
        {
            string sqlWithoutFine = @"SELECT 
                Tr.MaTra, T.MaThue, T.NgayThue, T.NgayTra, Tr.NgayTra as NgayThucTe, 
                0 as TienPhat, SUM(CTT.GiaThue) as TienThue, SUM(CTT.GiaThue) as TongTien, 
                KH.TenKH, KH.SDT, KH.DiaChi, NV.TenNV 
            FROM 
                TraSach Tr 
                INNER JOIN ThueSach T ON Tr.MaThue = T.MaThue 
                INNER JOIN KhachHang KH ON T.MaKH = KH.MaKH 
                INNER JOIN NhanVien NV ON T.MaNV = NV.MaNV 
                INNER JOIN CTThueSach CTT ON T.MaThue = CTT.MaThue 
            WHERE 
                Tr.MaTra = @MaTra 
            GROUP BY 
                Tr.MaTra, 
                T.MaThue, 
                T.NgayThue, 
                T.NgayTra, 
                Tr.NgayTra, 
                KH.TenKH, 
                KH.SDT, 
                KH.DiaChi, 
                NV.TenNV;";

            string sqlWithFine = @"SELECT 
                Tr.MaTra, T.MaThue, T.NgayThue, T.NgayTra, Tr.NgayTra as NgayThucTe, 
                COALESCE(SUM(CTTr.ThanhTien), 0) as TienPhat, 

                COALESCE((
                    SELECT SUM(CTT1.GiaThue) 
                    FROM CTThueSach CTT1 
                    WHERE CTT1.MaThue = T.MaThue 
                ), 0) as TienThue, 

                COALESCE(SUM(CTTr.ThanhTien), 0) + COALESCE(( 
                    SELECT SUM(CTT1.GiaThue) 
                    FROM CTThueSach CTT1 
                    WHERE CTT1.MaThue = T.MaThue 
                ), 0) as TongTien, 
                KH.TenKH, KH.SDT, KH.DiaChi, NV.TenNV 
            FROM 
                TraSach Tr 
                INNER JOIN ThueSach T ON Tr.MaThue = T.MaThue 
                LEFT JOIN CTTraSach CTTr ON CTTr.MaTra = Tr.MaTra 
                LEFT JOIN KhachHang KH ON T.MaKH = KH.MaKH 
                LEFT JOIN NhanVien NV ON T.MaNV = NV.MaNV 
            WHERE 
                Tr.MaTra = @MaTra 
            GROUP BY 
                Tr.MaTra, 
                T.MaThue, 
                T.NgayThue, 
                T.NgayTra, 
                Tr.NgayTra, 
                KH.TenKH, 
                KH.SDT, 
                KH.DiaChi, 
                NV.TenNV;";

            string maTra = GetMaTraFromMaThue(maThue);

            if (!string.IsNullOrEmpty(maTra))
            {
                bool hasFine = CheckIfReturnFineExists(maTra);
                string sql = hasFine ? sqlWithFine : sqlWithoutFine;

                SqlParameter[] sqlParams = {
                    new SqlParameter("@MaTra", maTra)
                };

                return DatabaseLayer.GetDataToTable(sql, sqlParams);
            }

            return new DataTable();
        }

        public static DataTable GetThongTinCTTra(string maTra)
        {
            string sql = @"SELECT CTTr.MaSach, S.TenSach, VP.TenVP, CTTr.ThanhTien 
                   FROM CTTraSach CTTr 
                   INNER JOIN Sach S ON CTTr.MaSach = S.MaSach 
                   INNER JOIN ViPham VP ON CTTr.MaVP = VP.MaVP 
                   WHERE CTTr.MaTra = @MaTra";

            SqlParameter[] sqlParams = {
                new SqlParameter("@MaTra", maTra)
            };

            return DatabaseLayer.GetDataToTable(sql, sqlParams);
        }

        public static DataTable GetTraBySearch(string searchOption, string searchKeyword)
        {
            string sql = "SELECT Tr.MaTra, Tr.MaThue, T.MaKH, KH.TenKH, Tr.MaNV, NV.TenNV, T.NgayThue, T.NgayTra, Tr.NgayTra AS NgayThucTe, T.TienDatCoc, Tr.TongTien " +
                $"FROM {TableName} Tr " +
                $"INNER JOIN {TableThueName} T ON Tr.MaThue = T.MaThue " +
                "INNER JOIN KhachHang KH ON T.MaKH = KH.MaKH " +
                "INNER JOIN NhanVien NV ON T.MaNV = NV.MaNV ";

            DateTime parsedDate;
            bool isDate = DateTime.TryParseExact(searchKeyword, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out parsedDate);

            switch (searchOption)
            {
                case "Mã trả":
                    sql += $"WHERE Tr.MaTra LIKE '%{searchKeyword}%'";
                    break;
                case "Mã thuê":
                    sql += $"WHERE Tr.MaThue LIKE '%{searchKeyword}%'";
                    break;
                case "Tên khách hàng":
                    sql += $"WHERE KH.TenKH LIKE N'%{searchKeyword}%'";
                    break;
                case "Ngày thực tế":
                    if (isDate)
                    {
                        sql += $"WHERE CONVERT(date, Tr.NgayThucTe, 103) = CONVERT(date, '{parsedDate:dd/MM/yyyy}', 103)";
                    }
                    else
                    {
                        throw new ArgumentException("Ngày thực tế không hợp lệ");
                    }
                    break;


                default:
                    throw new ArgumentException("Không có tuỳ chọn tìm kiếm");
            }

            return DatabaseLayer.GetDataToTable(sql);
        }

        public static DataTable GetCTTra(string maTra)
        {
            string sql = $"SELECT CT.MaSach, S.TenSach, CT.MaVP, CT.ThanhTien FROM {TableCTName} CT INNER JOIN Sach S ON CT.MaSach = S.MaSach WHERE CT.MaTra = @MaTra";
            SqlParameter[] param = { new SqlParameter("@MaTra", maTra) };

            return DatabaseLayer.GetDataToTable(sql, param);
        }

        public static void DeleteTra(string maTra)
        {
            string sqlDelete = "DELETE FROM " + TableName + " WHERE MaTra = @MaTra";
            SqlParameter[] deleteParams = { new SqlParameter("@MaTra", maTra) };

            DatabaseLayer.RunSqlDel(sqlDelete, deleteParams);
        }

        public static void DeleteCTTra(string maTra)
        {
            string sqlDelete = "DELETE FROM " + TableCTName + " WHERE MaTra = @MaTra";
            SqlParameter[] deleteParams = { new SqlParameter("@MaTra", maTra) };

            DatabaseLayer.RunSqlDel(sqlDelete, deleteParams);
        }

        public static bool CheckMaTraExists(string maTra)
        {
            string sql = "SELECT MaTra FROM " + TableName + " + WHERE MaTra = @MaThue";

            SqlParameter[] sqlParams = {
                new SqlParameter("@MaTra", maTra)
            };

            return DatabaseLayer.CheckKey(sql, sqlParams);
        }

        public static string InsertEmptyTra(string maTra)
        {
            string sqlInsert = "INSERT INTO " + TableName + " (MaTra, NgayTra, TongTien) VALUES (@MaTra, '01/01/2000', -1)";
            SqlParameter[] insertParams = { new SqlParameter("@MaTra", maTra) };

            DatabaseLayer.RunSql(sqlInsert, insertParams);

            return GetLastMaTra();
        }

        public static string GetLastMaTra()
        {
            string sql = "SELECT TOP 1 MaTra FROM " + TableName + " ORDER BY MaTra DESC";

            DataTable dt = DatabaseLayer.GetDataToTable(sql);

            if (dt.Rows.Count == 0)
            {
                return "";
            }

            return dt.Rows[0]["MaTra"].ToString();
        }

        public static void DeleteEmptyTra(string maTra)
        {
            string sqlCheck = "SELECT TongTien FROM " + TableName + " WHERE MaTra = @MaTra AND TongTien = -1";

            SqlParameter[] sqlParams = { new SqlParameter("@MaTra", maTra) };

            DataTable dt = DatabaseLayer.GetDataToTable(sqlCheck, sqlParams);

            if (dt.Rows.Count > 0)
            {
                int tongTien = Convert.ToInt32(dt.Rows[0]["TongTien"].ToString());

                if (tongTien != -1)
                {
                    return;
                }
            }
            else
            {
                return;
            }

            string sqlDelete = "DELETE FROM " + TableName + " WHERE MaTra = @MaTra";
            string sqlDeleteCT = "DELETE FROM " + TableCTName + " WHERE MaTra = @MaTra";

            SqlParameter[] parameters = { new SqlParameter("@MaTra", maTra) };
            SqlParameter[] parametersCT = { new SqlParameter("@MaTra", maTra) };

            DatabaseLayer.RunSqlDel(sqlDeleteCT, parametersCT);
            DatabaseLayer.RunSqlDel(sqlDelete, parameters);
        }

        public static void UpdateTra(string maTra, string maThue, string maNV, DateTime ngayTra, int tongTien)
        {
            string sqlUpdate = "UPDATE " + TableName + " SET MaThue = @MaThue, MaNV = @MaNV, NgayTra = @NgayTra, TongTien = @TongTien WHERE MaTra = @MaTra";
            SqlParameter[] updateParams =
            {
                new SqlParameter("@MaThue", maThue),
                new SqlParameter("@MaNV", maNV),
                new SqlParameter("@NgayTra", ngayTra),
                new SqlParameter("@TongTien", tongTien),
                new SqlParameter("@MaTra", maTra),
            };

            DatabaseLayer.RunSql(sqlUpdate, updateParams);
        }

        public static void InsertSachCTTra(string maTra, string maSach, string maVP, int thanhTien)
        {
            string sql = "INSERT INTO " + TableCTName + " (MaTra, MaSach, MaVP, ThanhTien) VALUES (@MaTra, @MaSach, @MaVP, @ThanhTien)";

            SqlParameter[] sqlParams = {
                new SqlParameter("@MaTra", maTra),
                new SqlParameter("@MaSach", maSach),
                new SqlParameter("@MaVP", maVP),
                new SqlParameter("@ThanhTien", thanhTien)
            };

            DatabaseLayer.RunSql(sql, sqlParams);
        }

        public static bool CheckMaSach(string maTra, string maSach)
        {
            string sql = "SELECT MaSach FROM " + TableCTName + " WHERE MaTra = @MaTra AND MaSach = @MaSach";
            SqlParameter[] sqlParams =
            {
                new SqlParameter("@MaTra", maTra),
                new SqlParameter("@MaSach", maSach)
            };

            return DatabaseLayer.CheckKey(sql, sqlParams);
        }

        public static void UpdateSachCTTra(string maTra, string maSach, string maVP, int thanhTien)
        {
            string sql = "UPDATE " + TableCTName + " SET MaVP = @MaVP, ThanhTien = @ThanhTien WHERE MaTra = @MaTra AND MaSach = @MaSach";

            SqlParameter[] sqlParams =
            {
                new SqlParameter("@MaVP", maVP),
                new SqlParameter("@ThanhTien", thanhTien),
                new SqlParameter("@MaTra", maTra),
                new SqlParameter("@MaSach", maSach)
            };

            DatabaseLayer.RunSql(sql, sqlParams);
        }

        public static void DeleteSachCTTra(string maTra, string maSach)
        {
            string sql = "DELETE FROM " + TableCTName + " WHERE MaTra = @MaTra AND MaSach = @MaSach";

            SqlParameter[] sqlParams =
            {
                new SqlParameter("@MaTra", maTra),
                new SqlParameter("@MaSach", maSach)
            };

            DatabaseLayer.RunSqlDel(sql, sqlParams);
        }

        private static bool CheckIfReturnFineExists(string maTra)
        {
            string sql = "SELECT COUNT(*) FROM CTTraSach WHERE MaTra = @MaTra";

            SqlParameter[] sqlParameter = { new SqlParameter("@MaTra", maTra) };

            DataTable dt = DatabaseLayer.GetDataToTable(sql, sqlParameter);

            return Convert.ToInt32(dt.Rows[0][0].ToString()) > 0;
        }

        private static string GetMaTraFromMaThue(string maThue)
        {
            string sql = "SELECT MaTra FROM TraSach WHERE MaThue = @MaThue";

            SqlParameter[] sqlParams = { new SqlParameter("@MaThue", maThue) };

            DataTable dt = DatabaseLayer.GetDataToTable(sql, sqlParams);

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["MaTra"].ToString();
            }

            return "";
        }

        public static int CalcTongTien(string maThue)
        {
            // 1. Lấy tổng tiền thuê từ bảng CTThueSach
            string sqlGiaThue = "SELECT COALESCE(SUM(GiaThue), 0) AS TongGiaThue FROM CTThueSach WHERE MaThue = @MaThue";
            SqlParameter[] sqlParams = { new SqlParameter("@MaThue", maThue) };

            DataTable dtGiaThue = DatabaseLayer.GetDataToTable(sqlGiaThue, sqlParams);

            int giaThue = 0;
            int tienCoc = 0;

            if (dtGiaThue.Rows.Count > 0 && dtGiaThue.Rows[0]["TongGiaThue"] != DBNull.Value)
            {
                giaThue = Convert.ToInt32(dtGiaThue.Rows[0]["TongGiaThue"]);
            }

            // 2. Lấy tiền đặt cọc bằng cách lọc DataTable
            DataTable data = ThueDAL.GetAllThue();
            string escapedMaThue = maThue.Replace("'", "''");
            DataRow[] rows = data.Select($"MaThue = '{escapedMaThue}'");

            if (rows.Length > 0 && rows[0]["TienDatCoc"] != DBNull.Value)
            {
                tienCoc = Convert.ToInt32(rows[0]["TienDatCoc"]);
            }

            // 3. Trả về tổng tiền = tiền thuê - tiền đặt cọc
            return giaThue - tienCoc;
        }








    }
}