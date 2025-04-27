using BAEK_PERCENT.Database;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BAEK_PERCENT.DAL
{
    internal class BaoCaoDAL
    {
        public static DataTable GetBCLoaiSachYeuThich(DateTime ngayBD, DateTime ngayKT)
        {
            string sql = @"SELECT DISTINCT L.TenLV, COUNT(*) AS SoLuongMuon 
                    FROM CTThueSach CT 
                    INNER JOIN ThueSach T ON T.MaThue = CT.MaThue 
                    INNER JOIN Sach S ON CT.MaSach = S.MaSach 
                    INNER JOIN LinhVuc L ON L.MaLV = S.MaLV 
                    WHERE T.NgayThue BETWEEN @NgayBD AND @NgayKT 
                    GROUP BY L.TenLV 
                    ORDER BY SoLuongMuon DESC;";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@NgayBD", ngayBD),
                new SqlParameter("@NgayKT", ngayKT)
            };

            return DatabaseLayer.GetDataToTable(sql, sqlParameters);
        }

        public static DataTable GetBCSachYeuThich(DateTime ngayBD, DateTime ngayKT)
        {
            string sql = @"SELECT DISTINCT S.TenSach, COUNT(*) AS SoLuongMuon 
                    FROM CTThueSach CT 
                    INNER JOIN ThueSach T ON T.MaThue = CT.MaThue 
                    INNER JOIN Sach S ON CT.MaSach = S.MaSach 
                    WHERE T.NgayThue BETWEEN @NgayBD AND @NgayKT 
                    GROUP BY S.TenSach 
                    ORDER BY SoLuongMuon DESC;";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@NgayBD", ngayBD),
                new SqlParameter("@NgayKT", ngayKT)
            };

            return DatabaseLayer.GetDataToTable(sql, sqlParameters);
        }

        public static DataTable GetBCSachMatHong(DateTime ngayBD, DateTime ngayKT)
        {
            string sql = @"SELECT DISTINCT S.TenSach, VP.TenVP, COUNT(*) AS SoLuongSach
                    FROM CTTraSach CT
                    INNER JOIN TraSach T ON T.MaTra = CT.MaTra
                    INNER JOIN Sach S ON CT.MaSach = S.MaSach
                    INNER JOIN ViPham VP ON VP.MaVP = CT.MaVP
                    WHERE T.NgayTra BETWEEN @NgayBD AND @NgayKT AND VP.MaVP IN ('VP002', 'VP003')
                    GROUP BY S.TenSach, VP.TenVP
                    ORDER BY SoLuongSach DESC;";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@NgayBD", ngayBD),
                new SqlParameter("@NgayKT", ngayKT)
            };

            return DatabaseLayer.GetDataToTable(sql, sqlParameters);
        }

        public static DataTable GetBCDoanhThuThang(DateTime ngayBD, DateTime ngayKT)
        {
            string sql = @"WITH AllMonths AS (
                    SELECT
                        YEAR(@NgayBD) AS Year,
                        MONTH(@NgayBD) AS Month
                    UNION ALL
                    SELECT
                        YEAR(DATEADD(MONTH, 1, DATEFROMPARTS(Year, Month, 1))) AS Year,
                        MONTH(DATEADD(MONTH, 1, DATEFROMPARTS(Year, Month, 1))) AS Month
                    FROM AllMonths
                    WHERE DATEADD(MONTH, 1, DATEFROMPARTS(Year, Month, 1)) <= @NgayKT
                ),
                MonthlyRevenue AS (
                    SELECT
                        YEAR(T.NgayThue) AS Year,
                        MONTH(T.NgayThue) AS Month,
                        COALESCE(SUM(T.TienDatCoc), 0) AS Revenue
                    FROM ThueSach T
                    LEFT JOIN TraSach R ON T.MaThue = R.MaThue
                    WHERE R.MaThue IS NULL
                    AND T.NgayThue BETWEEN @NgayBD AND @NgayKT
                    GROUP BY YEAR(T.NgayThue), MONTH(T.NgayThue)
                    UNION ALL
                    SELECT
                        YEAR(R.NgayTra) AS Year,
                        MONTH(R.NgayTra) AS Month,
                        COALESCE(SUM(R.TongTien), 0) AS Revenue
                    FROM TraSach R
                    INNER JOIN ThueSach T ON R.MaThue = T.MaThue
                    WHERE T.NgayThue BETWEEN @NgayBD AND @NgayKT
                    AND R.NgayTra BETWEEN @NgayBD AND @NgayKT
                    GROUP BY YEAR(R.NgayTra), MONTH(R.NgayTra)
                )

                SELECT
                    AM.Year,
                    AM.Month,
                    COALESCE(SUM(MR.Revenue), 0) AS MonthlyRevenue
                FROM AllMonths AM
                LEFT JOIN MonthlyRevenue MR ON AM.Year = MR.Year AND AM.Month = MR.Month
                GROUP BY AM.Year, AM.Month
                ORDER BY AM.Year, AM.Month;";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@NgayBD", ngayBD),
                new SqlParameter("@NgayKT", ngayKT)
            };

            return DatabaseLayer.GetDataToTable(sql, sqlParameters);
        }

        public static DataTable GetBCDoanhThuTuan(DateTime ngayBD, DateTime ngayKT)
        {
            string sql = @"WITH WeeklyRevenue AS (
                    SELECT 
                        YEAR(DateTable.WeekStart) AS Year, 
                        DATEPART(WEEK, DateTable.WeekStart) AS WeekNumber, 
                        CONCAT(
                            LEFT(CONVERT(VARCHAR(10), DateTable.WeekStart, 103), 6), 
                            RIGHT(CONVERT(VARCHAR(10), DateTable.WeekStart, 103), 2),
                            ' - ', 
                            LEFT(CONVERT(VARCHAR(10), DateTable.WeekEnd, 103), 6), 
                            RIGHT(CONVERT(VARCHAR(10), DateTable.WeekEnd, 103), 2)
                        ) AS Week, 
                        COALESCE(SUM(MR.Revenue), 0) AS Revenue 
                    FROM (
                        SELECT 
                            DATEADD(WEEK, DATEDIFF(WEEK, 0, @NgayBD) + number, 0) AS WeekStart, 
                            DATEADD(DAY, 6, DATEADD(WEEK, DATEDIFF(WEEK, 0, @NgayBD) + number, 0)) AS WeekEnd 
                        FROM master..spt_values 
                        WHERE type = 'P' AND number BETWEEN 0 AND DATEDIFF(WEEK, @NgayBD, @NgayKT)
                    ) AS DateTable 
                    LEFT JOIN (
                        SELECT 
                            YEAR(T.NgayThue) AS Year, 
                            DATEPART(WEEK, T.NgayThue) AS Week, 
                            COALESCE(SUM(T.TienDatCoc), 0) AS Revenue 
                        FROM ThueSach T 
                        LEFT JOIN TraSach R ON T.MaThue = R.MaThue 
                        WHERE R.MaThue IS NULL 
                        AND T.NgayThue BETWEEN @NgayBD AND @NgayKT 
                        GROUP BY YEAR(T.NgayThue), DATEPART(WEEK, T.NgayThue) 
                        UNION ALL 
                        SELECT 
                            YEAR(R.NgayTra) AS Year, 
                            DATEPART(WEEK, R.NgayTra) AS Week, 
                            COALESCE(SUM(R.TongTien), 0) AS Revenue 
                        FROM TraSach R 
                        INNER JOIN ThueSach T ON R.MaThue = T.MaThue 
                        WHERE T.NgayThue BETWEEN @NgayBD AND @NgayKT 
                        AND R.NgayTra BETWEEN @NgayBD AND @NgayKT 
                        GROUP BY YEAR(R.NgayTra), DATEPART(WEEK, R.NgayTra)
                    ) AS MR ON YEAR(DateTable.WeekStart) = MR.Year 
                    AND DateTable.WeekStart <= @NgayKT 
                    AND DateTable.WeekEnd >= @NgayBD 
                    AND MR.Week = DATEPART(WEEK, DateTable.WeekStart) 
                    GROUP BY YEAR(DateTable.WeekStart), DATEPART(WEEK, DateTable.WeekStart), 
                    CONCAT(
                        LEFT(CONVERT(VARCHAR(10), DateTable.WeekStart, 103), 6), 
                        RIGHT(CONVERT(VARCHAR(10), DateTable.WeekStart, 103), 2),
                        ' - ', 
                        LEFT(CONVERT(VARCHAR(10), DateTable.WeekEnd, 103), 6), 
                        RIGHT(CONVERT(VARCHAR(10), DateTable.WeekEnd, 103), 2)
                    )
                ) 
                SELECT 
                    Year, 
                    WeekNumber, 
                    Week, 
                    SUM(Revenue) AS WeeklyRevenue 
                FROM WeeklyRevenue 
                WHERE WeekNumber BETWEEN DATEPART(WEEK, @NgayBD) AND DATEPART(WEEK, @NgayKT) 
                GROUP BY Year, WeekNumber, Week 
                ORDER BY Year, WeekNumber;";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@NgayBD", ngayBD),
                new SqlParameter("@NgayKT", ngayKT)
            };

            return DatabaseLayer.GetDataToTable(sql, sqlParameters);
        }

        public static DataTable GetBCDoanhThuNgay(DateTime ngayBD, DateTime ngayKT)
        {
            string sql = @"WITH DailyRevenue AS (
                    SELECT 
                        DateTable.Date AS Date,
                        COALESCE(SUM(MR.Revenue), 0) AS Revenue 
                    FROM (
                        SELECT 
                            DATEADD(DAY, number, @NgayBD) AS Date
                        FROM master..spt_values 
                        WHERE type = 'P' AND number BETWEEN 0 AND DATEDIFF(DAY, @NgayBD, @NgayKT)
                    ) AS DateTable 
                    LEFT JOIN (
                        SELECT 
                            T.NgayThue AS Date,
                            COALESCE(SUM(T.TienDatCoc), 0) AS Revenue 
                        FROM ThueSach T 
                        LEFT JOIN TraSach R ON T.MaThue = R.MaThue 
                        WHERE R.MaThue IS NULL 
                        AND T.NgayThue BETWEEN @NgayBD AND @NgayKT 
                        GROUP BY T.NgayThue
                        UNION ALL 
                        SELECT 
                            R.NgayTra AS Date,
                            COALESCE(SUM(R.TongTien), 0) AS Revenue 
                        FROM TraSach R 
                        INNER JOIN ThueSach T ON R.MaThue = T.MaThue 
                        WHERE T.NgayThue BETWEEN @NgayBD AND @NgayKT 
                        AND R.NgayTra BETWEEN @NgayBD AND @NgayKT 
                        GROUP BY R.NgayTra
                    ) AS MR ON DateTable.Date = MR.Date 
                    GROUP BY DateTable.Date
                ) 
                SELECT 
                    Date,
                    SUM(Revenue) AS DailyRevenue 
                FROM DailyRevenue 
                GROUP BY Date 
                ORDER BY Date;";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@NgayBD", ngayBD),
                new SqlParameter("@NgayKT", ngayKT)
            };

            return DatabaseLayer.GetDataToTable(sql, sqlParameters);
        }

        public static int GetSoDonThueThangNay()
        {
            string sql = "SELECT COUNT(*) AS SoDonThue FROM ThueSach WHERE MONTH(NgayThue) = MONTH(GETDATE())";

            DataTable dt = DatabaseLayer.GetDataToTable(sql);

            if (dt.Rows.Count == 0)
            {
                return 0;
            }
            else return Convert.ToInt32(dt.Rows[0]["SoDonThue"]);
        }

        public static int GetDoanhThuThangNay()
        {
            string sql = @"DECLARE @CurrentYear INT = YEAR(GETDATE());
                    DECLARE @CurrentMonth INT = MONTH(GETDATE());

                    WITH MonthlyRevenue AS (
                        SELECT
                            YEAR(T.NgayThue) AS Year,
                            MONTH(T.NgayThue) AS Month,
                            COALESCE(SUM(T.TienDatCoc), 0) AS Revenue
                        FROM ThueSach T
                        LEFT JOIN TraSach R ON T.MaThue = R.MaThue
                        WHERE R.MaThue IS NULL
                        AND YEAR(T.NgayThue) = @CurrentYear
                        AND MONTH(T.NgayThue) = @CurrentMonth
                        GROUP BY YEAR(T.NgayThue), MONTH(T.NgayThue)
                        UNION ALL
                        SELECT
                            YEAR(R.NgayTra) AS Year,
                            MONTH(R.NgayTra) AS Month,
                            COALESCE(SUM(R.TongTien), 0) AS Revenue
                        FROM TraSach R
                        INNER JOIN ThueSach T ON R.MaThue = T.MaThue
                        WHERE YEAR(R.NgayTra) = @CurrentYear
                        AND MONTH(R.NgayTra) = @CurrentMonth
                        GROUP BY YEAR(R.NgayTra), MONTH(R.NgayTra)
                    )

                    SELECT
                        @CurrentYear AS Year,
                        @CurrentMonth AS Month,
                        COALESCE(SUM(MR.Revenue), 0) AS MonthlyRevenue
                    FROM MonthlyRevenue MR;";

            DataTable dt = DatabaseLayer.GetDataToTable(sql);

            if (dt.Rows.Count == 0)
            {
                return 0;
            }
            else return Convert.ToInt32(dt.Rows[0]["MonthlyRevenue"]);
        }

        public static int GetSoDonThueChuaTraThangNay()
        {
            string sql = "SELECT COUNT(*) AS SoDonThue FROM ThueSach WHERE MONTH(NgayThue) = MONTH(GETDATE()) AND YEAR(NgayThue) = YEAR(GETDATE()) AND MaThue NOT IN (SELECT DISTINCT MaThue FROM TraSach WHERE MONTH(NgayTra) = MONTH(GETDATE()) AND YEAR(NgayTra) = YEAR(GETDATE()));";

            DataTable dt = DatabaseLayer.GetDataToTable(sql);

            if (dt.Rows.Count == 0)
            {
                return 0;
            }
            else return Convert.ToInt32(dt.Rows[0]["SoDonThue"]);
        }

        public static DataTable GetSoSachThue10Ngay()
        {
            string sql = @"WITH DateTable AS (
                    SELECT 
                        DATEADD(DAY, -number, CAST(GETDATE() AS DATE)) AS Date
                    FROM master..spt_values 
                    WHERE type = 'P' AND number BETWEEN 0 AND 9
                ),
                DailyBookRentals AS (
                    SELECT 
                        DT.Date AS Date,
                        COUNT(CT.MaSach) AS BooksRented
                    FROM DateTable DT
                    LEFT JOIN ThueSach T ON CAST(T.NgayThue AS DATE) = DT.Date
                    LEFT JOIN CTThueSach CT ON T.MaThue = CT.MaThue
                    GROUP BY DT.Date
                )
                SELECT 
                    Date,
                    BooksRented
                FROM DailyBookRentals
                ORDER BY Date;";

            DataTable dt = DatabaseLayer.GetDataToTable(sql);

            return dt;
        }
    }
}