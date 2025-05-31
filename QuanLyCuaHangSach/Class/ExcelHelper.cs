using Microsoft.Office.Interop.Excel;
using System;
using System.Data;
using System.IO;

namespace BAEK_PERCENT.Class
{
    public static class ExcelHelper // dùng để tạo file excel
    {
        public static void CreateBillThue(System.Data.DataTable tblThongTinThue, System.Data.DataTable tblThongTinCTThue)
        {
            Application exApp = new Application();
            Workbook exBook;
            Worksheet exSheet;
            Range exRange;

            exBook = exApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            exSheet = (Worksheet)exBook.Worksheets[1];
            exSheet.Columns["B"].ColumnWidth = 13;

            // Định dạng tiêu đề và thông tin chung của hóa đơn
            exRange = exSheet.Range["A2:F2"];
            exRange.Merge();
            exRange.Font.Size = 12;
            exRange.Font.Bold = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = "Cửa Hàng Sách Truyện";

            exRange = exSheet.Range["A3:F3"];
            exRange.Merge();
            exRange.Font.Size = 11;
            exRange.Font.Italic = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = "Số 12 Chùa Bộc, Đống Đa, Hà Nội";

            exRange = exSheet.Range["A4:F4"];
            exRange.Merge();
            exRange.Font.Size = 11;
            exRange.Font.Italic = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = "Điện thoại: 024 3852 1305";

            exRange = exSheet.Range["A6:F7"];
            exRange.Merge();
            exRange.Font.Size = 16;
            exRange.Font.Bold = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = "HOÁ ĐƠN THUÊ SÁCH";

            if (tblThongTinThue.Rows.Count > 0)
            {
                exRange = exSheet.Range["A9:F9"];
                exRange.Merge();
                exRange.Font.Size = 11;
                //exRange.Font.Bold = true;
                exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                exRange.Value = $"Mã thuê: {tblThongTinThue.Rows[0]["MaThue"]}";

                exRange = exSheet.Range["A10:F10"];
                exRange.Merge();
                exRange.Font.Size = 11;
                //exRange.Font.Bold = true;
                exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                exRange.Value = $"Nhân viên: {tblThongTinThue.Rows[0]["TenNV"]}";

                exRange = exSheet.Range["A12:F12"];
                exRange.Merge();
                exRange.Font.Size = 11;
                //exRange.Font.Bold = true;
                exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                exRange.Value = $"Khách hàng: {tblThongTinThue.Rows[0]["TenKH"]}";

                exRange = exSheet.Range["A13:F13"];
                exRange.Merge();
                exRange.Font.Size = 11;
                //exRange.Font.Bold = true;
                exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                exRange.Value = $"Địa chỉ: {tblThongTinThue.Rows[0]["DiaChi"]}";

                exRange = exSheet.Range["A14:F14"];
                exRange.Merge();
                exRange.Font.Size = 11;
                //exRange.Font.Bold = true;
                exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                exRange.Value = $"Điện thoại: {tblThongTinThue.Rows[0]["SDT"]}";

                exRange = exSheet.Range["A15:F15"];
                exRange.Merge();
                exRange.Font.Size = 11;
                //exRange.Font.Bold = true;
                exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                exRange.Value = $"Ngày thuê: {Convert.ToDateTime(tblThongTinThue.Rows[0]["NgayThue"]).ToString("dd/MM/yyyy")}";

                exRange = exSheet.Range["A16:F16"];
                exRange.Merge();
                exRange.Font.Size = 11;
                //exRange.Font.Bold = true;
                exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                exRange.Value = $"Ngày trả: {Convert.ToDateTime(tblThongTinThue.Rows[0]["NgayTra"]).ToString("dd/MM/yyyy")}";
            }

            // Định dạng bảng thông tin chi tiết hàng hóa
            exRange = exSheet.Range["A18:F18"];
            exRange.Merge();
            exRange.Font.Size = 12;
            exRange.Font.Bold = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.Value = "Thông tin chi tiết hoá đơn";

            exSheet.Cells[19, 1] = "STT";
            exSheet.Cells[19, 1].Font.Bold = true;

            exSheet.Cells[19, 2] = "Mã sách";
            exSheet.Cells[19, 2].Font.Bold = true;

            exRange = exSheet.Range["C19:E19"];
            exRange.Merge();
            exRange.Value = "Tên sách";
            exRange.Font.Bold = true;

            exSheet.Cells[19, 6] = "Giá thuê";
            exSheet.Cells[19, 6].Font.Bold = true;

            int rowIndex = 20;
            int stt = 1;
            foreach (DataRow row in tblThongTinCTThue.Rows)
            {
                exSheet.Cells[rowIndex, 1] = stt++;
                exSheet.Cells[rowIndex, 2] = row["MaSach"];

                exRange = exSheet.Range[$"C{rowIndex}:E{rowIndex}"];
                exRange.Merge();
                exRange.Value = row["TenSach"];
                exSheet.Cells[rowIndex, 6] = row["GiaThue"];
                rowIndex++;
            }

            if (tblThongTinThue.Rows.Count > 0)
            {
                exRange = exSheet.Range[$"D{rowIndex + 1}:F{rowIndex + 1}"];
                exRange.Merge();
                exRange.Font.Size = 12;
                exRange.Font.Bold = true;
                exRange.HorizontalAlignment = XlHAlign.xlHAlignRight;
                exRange.Value = "Tổng tiền: " + tblThongTinThue.Rows[0]["TongTien"];

                exRange = exSheet.Range[$"D{rowIndex + 2}:F{rowIndex + 2}"];
                exRange.Merge();
                exRange.Font.Size = 12;
                exRange.Font.Bold = true;
                exRange.HorizontalAlignment = XlHAlign.xlHAlignRight;
                exRange.Value = "Tiền đặt cọc: " + tblThongTinThue.Rows[0]["TienDatCoc"];

                exRange = exSheet.Range[$"A{rowIndex + 4}:F{rowIndex + 4}"];
                exRange.Merge();
                exRange.Font.Size = 11;
                exRange.Font.Italic = true;
                exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                exRange.Value = $"Bằng chữ: {Functions.ChuyenSoSangChu(tblThongTinThue.Rows[0]["TongTien"].ToString())}";

                exRange = exSheet.Range[$"A{rowIndex + 6}:F{rowIndex + 6}"];
                exRange.Merge();
                exRange.Font.Size = 11;
                exRange.Font.Italic = true;
                exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
                exRange.Value = $"Ngày xuất: {DateTime.Now.ToString()}";
            }

            exSheet.Rows[$"1:{rowIndex + 6}"].RowHeight = 16.5;

            // Lưu file Excel
            string filePath = $"C:\\Users\\doant\\Desktop\\BC_CUAHANGSACH\\Thue\\{tblThongTinThue.Rows[0]["MaThue"]}.xlsx"; // Đường dẫn lưu file

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            exBook.SaveAs(filePath); // Lưu file Excel
            exApp.Visible = true; // Hiển thị file Excel

            // Giải phóng tài nguyên COM
            ReleaseObject(exSheet);
            ReleaseObject(exBook);
            ReleaseObject(exApp);
        }

        public static void CreateBillTra(System.Data.DataTable tblThongTinTra, System.Data.DataTable tblThongTinCTTra)
        {
            Application exApp = new Application();
            Workbook exBook;
            Worksheet exSheet;
            Range exRange;

            exBook = exApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            exSheet = (Worksheet)exBook.Worksheets[1];
            exSheet.Columns["B"].ColumnWidth = 13;

            // Định dạng tiêu đề và thông tin chung của hóa đơn
            exRange = exSheet.Range["A2:F2"];
            exRange.Merge();
            exRange.Font.Size = 12;
            exRange.Font.Bold = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = "Cửa Hàng Sách Truyện";

            exRange = exSheet.Range["A3:F3"];
            exRange.Merge();
            exRange.Font.Size = 11;
            exRange.Font.Italic = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = "Số 12 Chùa Bộc, Đống Đa, Hà Nội";

            exRange = exSheet.Range["A4:F4"];
            exRange.Merge();
            exRange.Font.Size = 11;
            exRange.Font.Italic = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = "Điện thoại: 024 3852 1305";

            exRange = exSheet.Range["A6:F7"];
            exRange.Merge();
            exRange.Font.Size = 16;
            exRange.Font.Bold = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = "HOÁ ĐƠN TRẢ SÁCH";

            if (tblThongTinTra.Rows.Count > 0)
            {
                exRange = exSheet.Range["A9:F9"];
                exRange.Merge();
                exRange.Font.Size = 11;
                //exRange.Font.Bold = true;
                exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                exRange.Value = $"Mã trả: {tblThongTinTra.Rows[0]["MaTra"]}";

                exRange = exSheet.Range["A10:F10"];
                exRange.Merge();
                exRange.Font.Size = 11;
                //exRange.Font.Bold = true;
                exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                exRange.Value = $"Mã thuê: {tblThongTinTra.Rows[0]["MaThue"]}";

                exRange = exSheet.Range["A11:F11"];
                exRange.Merge();
                exRange.Font.Size = 11;
                //exRange.Font.Bold = true;
                exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                exRange.Value = $"Nhân viên: {tblThongTinTra.Rows[0]["TenNV"]}";

                exRange = exSheet.Range["A13:F13"];
                exRange.Merge();
                exRange.Font.Size = 11;
                //exRange.Font.Bold = true;
                exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                exRange.Value = $"Khách hàng: {tblThongTinTra.Rows[0]["TenKH"]}";

                exRange = exSheet.Range["A14:F14"];
                exRange.Merge();
                exRange.Font.Size = 11;
                //exRange.Font.Bold = true;
                exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                exRange.Value = $"Địa chỉ: {tblThongTinTra.Rows[0]["DiaChi"]}";

                exRange = exSheet.Range["A15:F15"];
                exRange.Merge();
                exRange.Font.Size = 11;
                //exRange.Font.Bold = true;
                exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                exRange.Value = $"Điện thoại: {tblThongTinTra.Rows[0]["SDT"]}";

                exRange = exSheet.Range["A16:F16"];
                exRange.Merge();
                exRange.Font.Size = 11;
                //exRange.Font.Bold = true;
                exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                exRange.Value = $"Ngày thuê: {Convert.ToDateTime(tblThongTinTra.Rows[0]["NgayThue"]).ToString("dd/MM/yyyy")}";

                exRange = exSheet.Range["A17:F17"];
                exRange.Merge();
                exRange.Font.Size = 11;
                //exRange.Font.Bold = true;
                exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                exRange.Value = $"Ngày trả: {Convert.ToDateTime(tblThongTinTra.Rows[0]["NgayTra"]).ToString("dd/MM/yyyy")}";

                exRange = exSheet.Range["A18:F18"];
                exRange.Merge();
                exRange.Font.Size = 11;
                //exRange.Font.Bold = true;
                exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                exRange.Value = $"Ngày thực tế: {Convert.ToDateTime(tblThongTinTra.Rows[0]["NgayThucTe"]).ToString("dd/MM/yyyy")}";
            }

            // Định dạng bảng thông tin chi tiết hàng hóa
            exRange = exSheet.Range["A20:F20"];
            exRange.Merge();
            exRange.Font.Size = 12;
            exRange.Font.Bold = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.Value = "Thông tin chi tiết phạt do vi phạm";

            exSheet.Cells[21, 1] = "STT";
            exSheet.Cells[21, 1].Font.Bold = true;

            exSheet.Cells[21, 2] = "Mã sách";
            exSheet.Cells[21, 2].Font.Bold = true;

            exRange = exSheet.Range["C21:D21"];
            exRange.Merge();
            exRange.Value = "Tên sách";
            exRange.Font.Bold = true;

            exSheet.Cells[21, 5] = "Vi phạm";
            exSheet.Cells[21, 5].Font.Bold = true;

            exSheet.Cells[21, 6] = "Thành tiền";
            exSheet.Cells[21, 6].Font.Bold = true;

            int rowIndex = 22;
            int stt = 1;
            foreach (DataRow row in tblThongTinCTTra.Rows)
            {
                exSheet.Cells[rowIndex, 1] = stt++;
                exSheet.Cells[rowIndex, 2] = row["MaSach"];

                exRange = exSheet.Range[$"C{rowIndex}:D{rowIndex}"];
                exRange.Merge();
                exRange.Value = row["TenSach"];
                exSheet.Cells[rowIndex, 5] = row["TenVP"];
                exSheet.Cells[rowIndex, 6] = row["ThanhTien"];
                rowIndex++;
            }

            if (tblThongTinTra.Rows.Count > 0)
            {
                exRange = exSheet.Range[$"D{rowIndex + 1}:F{rowIndex + 1}"];
                exRange.Merge();
                exRange.Font.Size = 12;
                exRange.Font.Bold = true;
                exRange.HorizontalAlignment = XlHAlign.xlHAlignRight;
                exRange.Value = "Tiền thuê: " + tblThongTinTra.Rows[0]["TienThue"];

                exRange = exSheet.Range[$"D{rowIndex + 2}:F{rowIndex + 2}"];
                exRange.Merge();
                exRange.Font.Size = 12;
                exRange.Font.Bold = true;
                exRange.HorizontalAlignment = XlHAlign.xlHAlignRight;
                exRange.Value = "Tiền phạt: " + tblThongTinTra.Rows[0]["TienPhat"];

                exRange = exSheet.Range[$"D{rowIndex + 3}:F{rowIndex + 3}"];
                exRange.Merge();
                exRange.Font.Size = 12;
                exRange.Font.Bold = true;
                exRange.HorizontalAlignment = XlHAlign.xlHAlignRight;
                exRange.Value = "Tổng tiền: " + tblThongTinTra.Rows[0]["TongTien"];

                exRange = exSheet.Range[$"A{rowIndex + 5}:F{rowIndex + 5}"];
                exRange.Merge();
                exRange.Font.Size = 11;
                exRange.Font.Italic = true;
                exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                exRange.Value = $"Bằng chữ: {Functions.ChuyenSoSangChu(tblThongTinTra.Rows[0]["TongTien"].ToString())}";

                exRange = exSheet.Range[$"A{rowIndex + 7}:C{rowIndex + 7}"];
                exRange.Merge();
                exRange.Font.Size = 11;
                exRange.Font.Italic = true;
                exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
                exRange.Value = $"Ngày xuất: {DateTime.Now.ToString()}";
            }

            exSheet.Columns["E:F"].ColumnWidth = 10;
            exSheet.Rows[$"1:{rowIndex + 7}"].RowHeight = 16.5;

            // Lưu file Excel
            string filePath = $"C:\\Users\\doant\\Desktop\\BC_CUAHANGSACH\\Tra\\{tblThongTinTra.Rows[0]["MaTra"]}.xlsx"; // Đường dẫn lưu file

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            exBook.SaveAs(filePath); // Lưu file Excel
            exApp.Visible = true; // Hiển thị file Excel

            // Giải phóng tài nguyên COM
            ReleaseObject(exSheet);
            ReleaseObject(exBook);
            ReleaseObject(exApp);
        }

        public static void CreateBCDoanhThuThang(System.Data.DataTable tblDoanhThu, DateTime startDate, DateTime endDate)
        {
            Application exApp = new Application();
            Workbook exBook;
            Worksheet exSheet;
            Range exRange;

            exBook = exApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            exSheet = (Worksheet)exBook.Worksheets[1];

            exSheet.Columns["A:B"].ColumnWidth = 12;
            exSheet.Columns["C"].ColumnWidth = 18;

            exRange = exSheet.Range["A2:C2"];
            exRange.Merge();
            exRange.Font.Size = 12;
            exRange.Font.Bold = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = "Cửa Hàng Sách Truyện";

            exRange = exSheet.Range["A3:C3"];
            exRange.Merge();
            exRange.Font.Size = 11;
            exRange.Font.Italic = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = "Số 12 Chùa Bộc, Đống Đa, Hà Nội";

            exRange = exSheet.Range["A4:C4"];
            exRange.Merge();
            exRange.Font.Size = 11;
            exRange.Font.Italic = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = "Điện thoại: 024 3852 1305";

            exRange = exSheet.Range["A6:C7"];
            exRange.Merge();
            exRange.Font.Size = 16;
            exRange.Font.Bold = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = "BÁO CÁO DOANH THU THÁNG";

            exRange = exSheet.Range["A8:C8"];
            exRange.Merge();
            exRange.Font.Size = 11;
            exRange.Font.Italic = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = $"Thời gian: {startDate.ToString("dd/MM/yyyy")} - {endDate.ToString("dd/MM/yyyy")}";

            exSheet.Cells[10, 1] = "Năm";
            exSheet.Cells[10, 1].Font.Bold = true;
            exSheet.Cells[10, 1].HorizontalAlignment = XlHAlign.xlHAlignRight;

            exSheet.Cells[10, 2] = "Tháng";
            exSheet.Cells[10, 2].Font.Bold = true;
            exSheet.Cells[10, 2].HorizontalAlignment = XlHAlign.xlHAlignRight;

            exSheet.Cells[10, 3] = "Doanh thu";
            exSheet.Cells[10, 3].Font.Bold = true;
            exSheet.Cells[10, 3].HorizontalAlignment = XlHAlign.xlHAlignRight;

            decimal totalRevenue = 0;
            int rowIndex = 11;
            foreach (DataRow row in tblDoanhThu.Rows)
            {
                exSheet.Cells[rowIndex, 1] = row["Year"];
                exSheet.Cells[rowIndex, 1].HorizontalAlignment = XlHAlign.xlHAlignRight;

                exSheet.Cells[rowIndex, 2] = row["Month"];
                exSheet.Cells[rowIndex, 2].HorizontalAlignment = XlHAlign.xlHAlignRight;

                exSheet.Cells[rowIndex, 3] = string.Format("{0:#,##0}đ", row["MonthlyRevenue"]);
                exSheet.Cells[rowIndex, 3].HorizontalAlignment = XlHAlign.xlHAlignRight;

                totalRevenue += Convert.ToDecimal(row["MonthlyRevenue"]);
                rowIndex++;
            }

            exRange = exSheet.Range[$"A{rowIndex + 1}:C{rowIndex + 1}"];
            exRange.Merge();
            exRange.Font.Size = 12;
            exRange.Font.Bold = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignRight;
            exRange.Value = "Tổng doanh thu: " + string.Format("{0:#,##0}đ", totalRevenue);

            exRange = exSheet.Range[$"A{rowIndex + 3}:C{rowIndex + 3}"];
            exRange.Merge();
            exRange.Font.Size = 11;
            exRange.Font.Italic = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = $"Ngày xuất: {DateTime.Now.ToString()}";

            exSheet.Rows[$"1:{rowIndex + 4}"].RowHeight = 16.5;

            string startDateStr = startDate.ToString("yyMMdd");
            string endDateStr = endDate.ToString("yyMMdd");

            // Lưu file Excel
            string filePath = $"C:\\Users\\doant\\Desktop\\BC_CUAHANGSACH\\DoanhThuThang\\{startDateStr}_{endDateStr}.xlsx"; // Đường dẫn lưu file

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            exBook.SaveAs(filePath); // Lưu file Excel
            exApp.Visible = true; // Hiển thị file Excel

            // Giải phóng tài nguyên COM
            ReleaseObject(exSheet);
            ReleaseObject(exBook);
            ReleaseObject(exApp);
        }

        public static void CreateBCDoanhThuTuan(System.Data.DataTable tblDoanhThu, DateTime startDate, DateTime endDate)
        {
            Application exApp = new Application();
            Workbook exBook;
            Worksheet exSheet;
            Range exRange;

            exBook = exApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            exSheet = (Worksheet)exBook.Worksheets[1];

            exSheet.Columns["A:B"].ColumnWidth = 12;
            exSheet.Columns["C:D"].ColumnWidth = 18;

            exRange = exSheet.Range["A2:D2"];
            exRange.Merge();
            exRange.Font.Size = 12;
            exRange.Font.Bold = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = "Cửa Hàng Sách Truyện";

            exRange = exSheet.Range["A3:D3"];
            exRange.Merge();
            exRange.Font.Size = 11;
            exRange.Font.Italic = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = "Số 12 Chùa Bộc, Đống Đa, Hà Nội";

            exRange = exSheet.Range["A4:D4"];
            exRange.Merge();
            exRange.Font.Size = 11;
            exRange.Font.Italic = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = "Điện thoại: 024 3852 1305";

            exRange = exSheet.Range["A6:D7"];
            exRange.Merge();
            exRange.Font.Size = 16;
            exRange.Font.Bold = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = "BÁO CÁO DOANH THU TUẦN";

            exRange = exSheet.Range["A8:D8"];
            exRange.Merge();
            exRange.Font.Size = 11;
            exRange.Font.Italic = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = $"Thời gian: {startDate.ToString("dd/MM/yyyy")} - {endDate.ToString("dd/MM/yyyy")}";

            exSheet.Cells[10, 1] = "Năm";
            exSheet.Cells[10, 1].Font.Bold = true;
            exSheet.Cells[10, 1].HorizontalAlignment = XlHAlign.xlHAlignRight;

            exSheet.Cells[10, 2] = "Tuần thứ";
            exSheet.Cells[10, 2].Font.Bold = true;
            exSheet.Cells[10, 2].HorizontalAlignment = XlHAlign.xlHAlignRight;

            exSheet.Cells[10, 3] = "Tuần";
            exSheet.Cells[10, 3].Font.Bold = true;
            exSheet.Cells[10, 3].HorizontalAlignment = XlHAlign.xlHAlignRight;

            exSheet.Cells[10, 4] = "Doanh thu";
            exSheet.Cells[10, 4].Font.Bold = true;
            exSheet.Cells[10, 4].HorizontalAlignment = XlHAlign.xlHAlignRight;

            decimal totalRevenue = 0;
            int rowIndex = 11;
            foreach (DataRow row in tblDoanhThu.Rows)
            {
                exSheet.Cells[rowIndex, 1] = row["Year"];
                exSheet.Cells[rowIndex, 1].HorizontalAlignment = XlHAlign.xlHAlignRight;

                exSheet.Cells[rowIndex, 2] = row["WeekNumber"];
                exSheet.Cells[rowIndex, 2].HorizontalAlignment = XlHAlign.xlHAlignRight;

                exSheet.Cells[rowIndex, 3] = row["Week"];
                exSheet.Cells[rowIndex, 3].HorizontalAlignment = XlHAlign.xlHAlignRight;

                exSheet.Cells[rowIndex, 4] = string.Format("{0:#,##0}đ", row["WeeklyRevenue"]);
                exSheet.Cells[rowIndex, 4].HorizontalAlignment = XlHAlign.xlHAlignRight;

                totalRevenue += Convert.ToDecimal(row["WeeklyRevenue"]);
                rowIndex++;
            }

            exRange = exSheet.Range[$"A{rowIndex + 1}:D{rowIndex + 1}"];
            exRange.Merge();
            exRange.Font.Size = 12;
            exRange.Font.Bold = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignRight;
            exRange.Value = "Tổng doanh thu: " + string.Format("{0:#,##0}đ", totalRevenue);

            exRange = exSheet.Range[$"A{rowIndex + 3}:D{rowIndex + 3}"];
            exRange.Merge();
            exRange.Font.Size = 11;
            exRange.Font.Italic = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = $"Ngày xuất: {DateTime.Now.ToString()}";

            exSheet.Rows[$"1:{rowIndex + 4}"].RowHeight = 16.5;

            string startDateStr = startDate.ToString("yyMMdd");
            string endDateStr = endDate.ToString("yyMMdd");

            // Lưu file Excel
            string filePath = $"C:\\Users\\doant\\Desktop\\BC_CUAHANGSACH\\DoanhThuTuan\\{startDateStr}_{endDateStr}.xlsx"; // Đường dẫn lưu file

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            exBook.SaveAs(filePath); // Lưu file Excel
            exApp.Visible = true; // Hiển thị file Excel

            // Giải phóng tài nguyên COM
            ReleaseObject(exSheet);
            ReleaseObject(exBook);
            ReleaseObject(exApp);
        }

        public static void CreateBCDoanhThuNgay(System.Data.DataTable tblDoanhThu, DateTime startDate, DateTime endDate)
        {
            Application exApp = new Application();
            Workbook exBook;
            Worksheet exSheet;
            Range exRange;

            exBook = exApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            exSheet = (Worksheet)exBook.Worksheets[1];

            exSheet.Columns["A:B"].ColumnWidth = 24;

            exRange = exSheet.Range["A2:B2"];
            exRange.Merge();
            exRange.Font.Size = 12;
            exRange.Font.Bold = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = "Cửa Hàng Sách Truyện";

            exRange = exSheet.Range["A3:B3"];
            exRange.Merge();
            exRange.Font.Size = 11;
            exRange.Font.Italic = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = "Số 12 Chùa Bộc, Đống Đa, Hà Nội";

            exRange = exSheet.Range["A4:B4"];
            exRange.Merge();
            exRange.Font.Size = 11;
            exRange.Font.Italic = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = "Điện thoại: 024 3852 1305";

            exRange = exSheet.Range["A6:B7"];
            exRange.Merge();
            exRange.Font.Size = 16;
            exRange.Font.Bold = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = "BÁO CÁO DOANH THU NGÀY";

            exRange = exSheet.Range["A8:B8"];
            exRange.Merge();
            exRange.Font.Size = 11;
            exRange.Font.Italic = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = $"Thời gian: {startDate.ToString("dd/MM/yyyy")} - {endDate.ToString("dd/MM/yyyy")}";

            exSheet.Cells[10, 1] = "Ngày";
            exSheet.Cells[10, 1].Font.Bold = true;
            exSheet.Cells[10, 1].HorizontalAlignment = XlHAlign.xlHAlignRight;

            exSheet.Cells[10, 2] = "Doanh thu";
            exSheet.Cells[10, 2].Font.Bold = true;
            exSheet.Cells[10, 2].HorizontalAlignment = XlHAlign.xlHAlignRight;

            decimal totalRevenue = 0;
            int rowIndex = 11;
            foreach (DataRow row in tblDoanhThu.Rows)
            {
                exSheet.Cells[rowIndex, 1] = row["Date"];
                exSheet.Cells[rowIndex, 1].HorizontalAlignment = XlHAlign.xlHAlignRight;

                exSheet.Cells[rowIndex, 2] = string.Format("{0:#,##0}đ", row["DailyRevenue"]);
                exSheet.Cells[rowIndex, 2].HorizontalAlignment = XlHAlign.xlHAlignRight;

                totalRevenue += Convert.ToDecimal(row["DailyRevenue"]);
                rowIndex++;
            }

            exRange = exSheet.Range[$"A{rowIndex + 1}:B{rowIndex + 1}"];
            exRange.Merge();
            exRange.Font.Size = 12;
            exRange.Font.Bold = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignRight;
            exRange.Value = "Tổng doanh thu: " + string.Format("{0:#,##0}đ", totalRevenue);

            exRange = exSheet.Range[$"A{rowIndex + 3}:B{rowIndex + 3}"];
            exRange.Merge();
            exRange.Font.Size = 11;
            exRange.Font.Italic = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = $"Ngày xuất: {DateTime.Now.ToString()}";

            exSheet.Rows[$"1:{rowIndex + 4}"].RowHeight = 16.5;

            string startDateStr = startDate.ToString("yyMMdd");
            string endDateStr = endDate.ToString("yyMMdd");

            // Lưu file Excel
            string filePath = $"C:\\Users\\doant\\Desktop\\BC_CUAHANGSACH\\DoanhThuNgay\\{startDateStr}_{endDateStr}.xlsx"; // Đường dẫn lưu file

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            exBook.SaveAs(filePath); // Lưu file Excel
            exApp.Visible = true; // Hiển thị file Excel

            // Giải phóng tài nguyên COM
            ReleaseObject(exSheet);
            ReleaseObject(exBook);
            ReleaseObject(exApp);
        }

        public static void CreateBCLoaiSachYeuThich(System.Data.DataTable tblLoaiSach, DateTime startDate, DateTime endDate)
        {
            Application exApp = new Application();
            Workbook exBook;
            Worksheet exSheet;
            Range exRange;

            exBook = exApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            exSheet = (Worksheet)exBook.Worksheets[1];

            exSheet.Columns["A"].ColumnWidth = 28;
            exSheet.Columns["B"].ColumnWidth = 18;

            exRange = exSheet.Range["A2:B2"];
            exRange.Merge();
            exRange.Font.Size = 12;
            exRange.Font.Bold = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = "Cửa Hàng Sách Truyện";

            exRange = exSheet.Range["A3:B3"];
            exRange.Merge();
            exRange.Font.Size = 11;
            exRange.Font.Italic = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = "Số 12 Chùa Bộc, Đống Đa, Hà Nội";

            exRange = exSheet.Range["A4:B4"];
            exRange.Merge();
            exRange.Font.Size = 11;
            exRange.Font.Italic = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = "Điện thoại: 024 3852 1305";

            exRange = exSheet.Range["A6:B7"];
            exRange.Merge();
            exRange.Font.Size = 16;
            exRange.Font.Bold = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = "BÁO CÁO LOẠI SÁCH YÊU THÍCH";

            exRange = exSheet.Range["A8:B8"];
            exRange.Merge();
            exRange.Font.Size = 11;
            exRange.Font.Italic = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = $"Thời gian: {startDate.ToString("dd/MM/yyyy")} - {endDate.ToString("dd/MM/yyyy")}";

            exSheet.Cells[10, 1] = "Lĩnh vực";
            exSheet.Cells[10, 1].Font.Bold = true;
            exSheet.Cells[10, 1].HorizontalAlignment = XlHAlign.xlHAlignRight;

            exSheet.Cells[10, 2] = "Số lượng mượn";
            exSheet.Cells[10, 2].Font.Bold = true;
            exSheet.Cells[10, 2].HorizontalAlignment = XlHAlign.xlHAlignRight;

            int rowIndex = 11;
            foreach (DataRow row in tblLoaiSach.Rows)
            {
                exSheet.Cells[rowIndex, 1] = row["TenLV"];
                exSheet.Cells[rowIndex, 1].HorizontalAlignment = XlHAlign.xlHAlignRight;

                exSheet.Cells[rowIndex, 2] = row["SoLuongMuon"];
                exSheet.Cells[rowIndex, 2].HorizontalAlignment = XlHAlign.xlHAlignRight;

                rowIndex++;
            }

            exRange = exSheet.Range[$"A{rowIndex + 1}:B{rowIndex + 1}"];
            exRange.Merge();
            exRange.Font.Size = 11;
            exRange.Font.Italic = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = $"Ngày xuất: {DateTime.Now.ToString()}";

            exSheet.Rows[$"1:{rowIndex + 2}"].RowHeight = 16.5;

            string startDateStr = startDate.ToString("yyMMdd");
            string endDateStr = endDate.ToString("yyMMdd");

            // Lưu file Excel
            string filePath = $"C:\\Users\\doant\\Desktop\\BC_CUAHANGSACH\\LoaiSachYeuThich\\{startDateStr}_{endDateStr}.xlsx"; // Đường dẫn lưu file

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            exBook.SaveAs(filePath); // Lưu file Excel
            exApp.Visible = true; // Hiển thị file Excel

            // Giải phóng tài nguyên COM
            ReleaseObject(exSheet);
            ReleaseObject(exBook);
            ReleaseObject(exApp);
        }

        public static void CreateBCSachYeuThich(System.Data.DataTable tblSach, DateTime startDate, DateTime endDate)
        {
            Application exApp = new Application();
            Workbook exBook;
            Worksheet exSheet;
            Range exRange;

            exBook = exApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            exSheet = (Worksheet)exBook.Worksheets[1];

            exSheet.Columns["A"].ColumnWidth = 48;
            exSheet.Columns["B"].ColumnWidth = 18;

            exRange = exSheet.Range["A2:B2"];
            exRange.Merge();
            exRange.Font.Size = 12;
            exRange.Font.Bold = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = "Cửa Hàng Sách Truyện";

            exRange = exSheet.Range["A3:B3"];
            exRange.Merge();
            exRange.Font.Size = 11;
            exRange.Font.Italic = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = "Số 12 Chùa Bộc, Đống Đa, Hà Nội";

            exRange = exSheet.Range["A4:B4"];
            exRange.Merge();
            exRange.Font.Size = 11;
            exRange.Font.Italic = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = "Điện thoại: 024 3852 1305";

            exRange = exSheet.Range["A6:B7"];
            exRange.Merge();
            exRange.Font.Size = 16;
            exRange.Font.Bold = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = "BÁO CÁO SÁCH YÊU THÍCH";

            exRange = exSheet.Range["A8:B8"];
            exRange.Merge();
            exRange.Font.Size = 11;
            exRange.Font.Italic = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = $"Thời gian: {startDate.ToString("dd/MM/yyyy")} - {endDate.ToString("dd/MM/yyyy")}";

            exSheet.Cells[10, 1] = "Sách";
            exSheet.Cells[10, 1].Font.Bold = true;
            exSheet.Cells[10, 1].HorizontalAlignment = XlHAlign.xlHAlignRight;

            exSheet.Cells[10, 2] = "Số lượng mượn";
            exSheet.Cells[10, 2].Font.Bold = true;
            exSheet.Cells[10, 2].HorizontalAlignment = XlHAlign.xlHAlignRight;

            int rowIndex = 11;
            foreach (DataRow row in tblSach.Rows)
            {
                exSheet.Cells[rowIndex, 1] = row["TenSach"];
                exSheet.Cells[rowIndex, 1].HorizontalAlignment = XlHAlign.xlHAlignRight;

                exSheet.Cells[rowIndex, 2] = row["SoLuongMuon"];
                exSheet.Cells[rowIndex, 2].HorizontalAlignment = XlHAlign.xlHAlignRight;

                rowIndex++;
            }

            exRange = exSheet.Range[$"A{rowIndex + 1}:B{rowIndex + 1}"];
            exRange.Merge();
            exRange.Font.Size = 11;
            exRange.Font.Italic = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = $"Ngày xuất: {DateTime.Now.ToString()}";

            exSheet.Rows[$"1:{rowIndex + 2}"].RowHeight = 16.5;

            string startDateStr = startDate.ToString("yyMMdd");
            string endDateStr = endDate.ToString("yyMMdd");

            // Lưu file Excel
            string filePath = $"C:\\Users\\doant\\Desktop\\BC_CUAHANGSACH\\SachYeuThich\\{startDateStr}_{endDateStr}.xlsx"; // Đường dẫn lưu file

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            exBook.SaveAs(filePath); // Lưu file Excel
            exApp.Visible = true; // Hiển thị file Excel

            // Giải phóng tài nguyên COM
            ReleaseObject(exSheet);
            ReleaseObject(exBook);
            ReleaseObject(exApp);
        }

        public static void CreateBCSachMatHong(System.Data.DataTable tblSachMatHong, DateTime startDate, DateTime endDate)
        {
            Application exApp = new Application();
            Workbook exBook;
            Worksheet exSheet;
            Range exRange;

            exBook = exApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            exSheet = (Worksheet)exBook.Worksheets[1];

            exSheet.Columns["A"].ColumnWidth = 48;
            exSheet.Columns["B:C"].ColumnWidth = 18;

            exRange = exSheet.Range["A2:C2"];
            exRange.Merge();
            exRange.Font.Size = 12;
            exRange.Font.Bold = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = "Cửa Hàng Sách Truyện";

            exRange = exSheet.Range["A3:C3"];
            exRange.Merge();
            exRange.Font.Size = 11;
            exRange.Font.Italic = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = "Số 12 Chùa Bộc, Đống Đa, Hà Nội";

            exRange = exSheet.Range["A4:C4"];
            exRange.Merge();
            exRange.Font.Size = 11;
            exRange.Font.Italic = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = "Điện thoại: 024 3852 1305";

            exRange = exSheet.Range["A6:C7"];
            exRange.Merge();
            exRange.Font.Size = 16;
            exRange.Font.Bold = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = "BÁO CÁO SÁCH BỊ MẤT/HỎNG";

            exRange = exSheet.Range["A8:C8"];
            exRange.Merge();
            exRange.Font.Size = 11;
            exRange.Font.Italic = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = $"Thời gian: {startDate.ToString("dd/MM/yyyy")} - {endDate.ToString("dd/MM/yyyy")}";

            exSheet.Cells[10, 1] = "Sách";
            exSheet.Cells[10, 1].Font.Bold = true;
            exSheet.Cells[10, 1].HorizontalAlignment = XlHAlign.xlHAlignRight;

            exSheet.Cells[10, 2] = "Trạng thái";
            exSheet.Cells[10, 2].Font.Bold = true;
            exSheet.Cells[10, 2].HorizontalAlignment = XlHAlign.xlHAlignRight;

            exSheet.Cells[10, 3] = "Số lượng";
            exSheet.Cells[10, 3].Font.Bold = true;
            exSheet.Cells[10, 3].HorizontalAlignment = XlHAlign.xlHAlignRight;

            int rowIndex = 11;
            foreach (DataRow row in tblSachMatHong.Rows)
            {
                exSheet.Cells[rowIndex, 1] = row["TenSach"];
                exSheet.Cells[rowIndex, 1].HorizontalAlignment = XlHAlign.xlHAlignRight;

                exSheet.Cells[rowIndex, 2] = row["TenVP"];
                exSheet.Cells[rowIndex, 2].HorizontalAlignment = XlHAlign.xlHAlignRight;

                exSheet.Cells[rowIndex, 3] = row["SoLuongSach"];
                exSheet.Cells[rowIndex, 3].HorizontalAlignment = XlHAlign.xlHAlignRight;

                rowIndex++;
            }

            exRange = exSheet.Range[$"A{rowIndex + 1}:C{rowIndex + 1}"];
            exRange.Merge();
            exRange.Font.Size = 11;
            exRange.Font.Italic = true;
            exRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            exRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            exRange.Value = $"Ngày xuất: {DateTime.Now.ToString()}";

            exSheet.Rows[$"1:{rowIndex + 2}"].RowHeight = 16.5;

            string startDateStr = startDate.ToString("yyMMdd");
            string endDateStr = endDate.ToString("yyMMdd");

            // Lưu file Excel
            string filePath = $"C:\\Users\\doant\\Desktop\\BC_CUAHANGSACH\\MatHong\\{startDateStr}_{endDateStr}.xlsx"; // Đường dẫn lưu file

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            exBook.SaveAs(filePath); // Lưu file Excel
            exApp.Visible = true; // Hiển thị file Excel

            // Giải phóng tài nguyên COM
            ReleaseObject(exSheet);
            ReleaseObject(exBook);
            ReleaseObject(exApp);
        }

        private static void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                Console.WriteLine("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}