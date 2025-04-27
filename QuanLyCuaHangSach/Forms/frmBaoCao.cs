using BAEK_PERCENT.Class;
using BAEK_PERCENT.DAL;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace BAEK_PERCENT.Forms
{
    public partial class frmBaoCao : MaterialForm
    {
        public frmBaoCao()
        {
            InitializeComponent();

            cboBaoCao.Items.Add("Báo cáo doanh thu theo tháng");
            cboBaoCao.Items.Add("Báo cáo doanh thu theo tuần");
            cboBaoCao.Items.Add("Báo cáo doanh thu theo ngày");
            cboBaoCao.Items.Add("Báo cáo loại sách được yêu thích");
            cboBaoCao.Items.Add("Báo cáo sách được yêu thích");
            cboBaoCao.Items.Add("Báo cáo sách bị mất/hỏng");

            cboBaoCao.SelectedItem = null;

            dtpNgayBD.MaxDate = DateTime.Today;
            dtpNgayKT.MinDate = DateTime.Today;
            dtpNgayKT.MaxDate = DateTime.Today;
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            dtpNgayBD.Enabled = false;
            dtpNgayKT.Enabled = false;

            btnTaoBaoCao.Enabled = false;
            btnXuatBaoCao.Enabled = false;

            chrBaoCao.Visible = false;
        }

        private void dtpNgayBD_ValueChanged(object sender, EventArgs e)
        {
            dtpNgayKT.MinDate = dtpNgayBD.Value;
        }

        private void dtpNgayKT_ValueChanged(object sender, EventArgs e)
        {
            dtpNgayBD.MaxDate = dtpNgayKT.Value;
        }

        private void cboBaoCao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBaoCao.SelectedIndex.ToString() != null)
            {
                dtpNgayBD.Enabled = true;
                dtpNgayKT.Enabled = true;

                btnTaoBaoCao.Enabled = true;
            }
            else
            {
                dtpNgayBD.Enabled = false;
                dtpNgayKT.Enabled = false;

                btnTaoBaoCao.Enabled = false;
            }
        }

        private void btnTaoBaoCao_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtpNgayBD.Value;
            DateTime endDate = dtpNgayKT.Value;

            chrBaoCao.Visible = true;
            btnXuatBaoCao.Enabled = true;

            switch (cboBaoCao.SelectedIndex)
            {
                case 0:
                    BCDoanhThuThang(startDate, endDate);
                    break;
                case 1:
                    BCDoanhThuTuan(startDate, endDate);
                    break;
                case 2:
                    BCDoanhThuNgay(startDate, endDate);
                    break;
                case 3:
                    BCLoaiSachYeuThich(startDate, endDate);
                    break;
                case 4:
                    BCSachYeuThich(startDate, endDate);
                    break;
                case 5:
                    BCSachMatHong(startDate, endDate);
                    break;
                default:
                    break;
            }
        }

        private void btnXuatBaoCao_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtpNgayBD.Value;
            DateTime endDate = dtpNgayKT.Value;

            switch (cboBaoCao.SelectedIndex)
            {
                case 0:
                    InBCDoanhThuThang(startDate, endDate);
                    break;
                case 1:
                    InBCDoanhThuTuan(startDate, endDate);
                    break;
                case 2:
                    InBCDoanhThuNgay(startDate, endDate);
                    break;
                case 3:
                    InBCLoaiSachYeuThich(startDate, endDate);
                    break;
                case 4:
                    InBCSachYeuThich(startDate, endDate);
                    break;
                case 5:
                    InBCSachMatHong(startDate, endDate);
                    break;
                default:
                    break;
            }
        }

        private void BCDoanhThuThang(DateTime startDate, DateTime endDate)
        {
            DataTable dt = BaoCaoDAL.GetBCDoanhThuThang(startDate, endDate);

            chrBaoCao.Series.Clear();
            chrBaoCao.Legends.Clear();
            chrBaoCao.Titles.Clear();
            chrBaoCao.ChartAreas.Clear();

            ChartArea chartArea = new ChartArea();
            chartArea.AxisX.LabelStyle.Format = "MMM yyyy";
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.IntervalType = DateTimeIntervalType.Months;
            chartArea.AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisX.LabelStyle.Font = new Font("Microsoft Sans Serif", 12);
            chartArea.AxisY.LabelStyle.Font = new Font("Microsoft Sans Serif", 12);
            chrBaoCao.ChartAreas.Add(chartArea);

            Series series = new Series("Doanh thu")
            {
                XValueType = ChartValueType.Date,
                ChartType = SeriesChartType.Column,
                Font = new Font("Microsoft Sans Serif", 14)
            };

            decimal maxRevenue = 0;

            foreach (DataRow row in dt.Rows)
            {
                int year = Convert.ToInt32(row["Year"]);
                int month = Convert.ToInt32(row["Month"]);
                decimal revenue = Convert.ToDecimal(row["MonthlyRevenue"]);

                DateTime dateValue = new DateTime(year, month, 1);

                series.Points.AddXY(dateValue, revenue);
                series.Points[series.Points.Count - 1].Label = string.Format("{0:#,##0}đ", revenue);
                series.Points[series.Points.Count - 1].Font = new Font("Microsoft Sans Serif", 12);

                if (revenue > maxRevenue)
                {
                    maxRevenue = revenue;
                }
            }

            chrBaoCao.Series.Add(series);
            chrBaoCao.ChartAreas[0].AxisY.Maximum = (double)(maxRevenue * 1.1m);

            Title title = new Title("Báo cáo doanh thu theo tháng", Docking.Top, new Font("Arial", 18, FontStyle.Bold), Color.Black);
            chrBaoCao.Titles.Add(title);

            Legend legend = new Legend
            {
                Docking = Docking.Bottom,
                Alignment = StringAlignment.Center,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular)
            };
            chrBaoCao.Legends.Add(legend);
        }

        private void BCDoanhThuTuan(DateTime startDate, DateTime endDate)
        {
            DataTable dt = BaoCaoDAL.GetBCDoanhThuTuan(startDate, endDate);

            chrBaoCao.Series.Clear();
            chrBaoCao.Legends.Clear();
            chrBaoCao.Titles.Clear();
            chrBaoCao.ChartAreas.Clear();

            ChartArea chartArea = new ChartArea();
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisX.LabelStyle.Font = new Font("Microsoft Sans Serif", 12);
            chartArea.AxisY.LabelStyle.Font = new Font("Microsoft Sans Serif", 12);
            chrBaoCao.ChartAreas.Add(chartArea);

            Series series = new Series("Doanh thu")
            {
                XValueType = ChartValueType.String,
                ChartType = SeriesChartType.Column,
                Font = new Font("Microsoft Sans Serif", 14)
            };

            decimal maxRevenue = 0;

            foreach (DataRow row in dt.Rows)
            {
                int year = Convert.ToInt32(row["Year"]);
                int week = Convert.ToInt32(row["WeekNumber"]);
                string weekLabel = row["Week"].ToString();
                decimal revenue = Convert.ToDecimal(row["WeeklyRevenue"]);

                series.Points.AddXY(weekLabel, revenue);
                series.Points[series.Points.Count - 1].Label = string.Format("{0:#,##0}đ", revenue);
                series.Points[series.Points.Count - 1].Font = new Font("Microsoft Sans Serif", 12);

                if (revenue > maxRevenue)
                {
                    maxRevenue = revenue;
                }
            }

            chrBaoCao.Series.Add(series);
            chrBaoCao.ChartAreas[0].AxisY.Maximum = (double)(maxRevenue * 1.2m);

            Title title = new Title("Báo cáo doanh thu theo tuần", Docking.Top, new Font("Arial", 18, FontStyle.Bold), Color.Black);
            chrBaoCao.Titles.Add(title);

            Legend legend = new Legend
            {
                Docking = Docking.Bottom,
                Alignment = StringAlignment.Center,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular)
            };
            chrBaoCao.Legends.Add(legend);
        }

        private void BCDoanhThuNgay(DateTime startDate, DateTime endDate)
        {
            DataTable dt = BaoCaoDAL.GetBCDoanhThuNgay(startDate, endDate);

            chrBaoCao.Series.Clear();
            chrBaoCao.Legends.Clear();
            chrBaoCao.Titles.Clear();
            chrBaoCao.ChartAreas.Clear();

            ChartArea chartArea = new ChartArea();
            chartArea.AxisX.LabelStyle.Format = "dd/MM/yy";
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.IntervalType = DateTimeIntervalType.Days;
            chartArea.AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisX.LabelStyle.Font = new Font("Microsoft Sans Serif", 12);
            chartArea.AxisY.LabelStyle.Font = new Font("Microsoft Sans Serif", 12);
            chrBaoCao.ChartAreas.Add(chartArea);

            Series series = new Series("Doanh thu")
            {
                XValueType = ChartValueType.DateTime,
                ChartType = SeriesChartType.Column,
                Font = new Font("Microsoft Sans Serif", 14)
            };

            decimal maxRevenue = 0;

            foreach (DataRow row in dt.Rows)
            {
                DateTime date = Convert.ToDateTime(row["Date"]);
                decimal revenue = Convert.ToDecimal(row["DailyRevenue"]);

                series.Points.AddXY(date, revenue);
                series.Points[series.Points.Count - 1].Label = string.Format("{0:#,##0}đ", revenue);
                series.Points[series.Points.Count - 1].Font = new Font("Microsoft Sans Serif", 12);

                if (revenue > maxRevenue)
                {
                    maxRevenue = revenue;
                }
            }

            chrBaoCao.Series.Add(series);
            chrBaoCao.ChartAreas[0].AxisY.Maximum = (double)(maxRevenue * 1.2m);

            Title title = new Title("Báo cáo doanh thu theo ngày", Docking.Top, new Font("Arial", 18, FontStyle.Bold), Color.Black);
            chrBaoCao.Titles.Add(title);

            Legend legend = new Legend
            {
                Docking = Docking.Bottom,
                Alignment = StringAlignment.Center,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular)
            };
            chrBaoCao.Legends.Add(legend);
        }

        private void BCLoaiSachYeuThich(DateTime startDate, DateTime endDate)
        {
            DataTable dt = BaoCaoDAL.GetBCLoaiSachYeuThich(startDate, endDate);

            chrBaoCao.Series.Clear();
            chrBaoCao.Legends.Clear();
            chrBaoCao.Titles.Clear();
            chrBaoCao.ChartAreas.Clear();

            ChartArea chartArea = new ChartArea();
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisX.LabelStyle.Font = new Font("Microsoft Sans Serif", 12);
            chartArea.AxisY.LabelStyle.Font = new Font("Microsoft Sans Serif", 12);
            chartArea.AxisY.Title = "Số lượng mượn";
            chartArea.AxisY.TitleFont = new Font("Microsoft Sans Serif", 12);
            chrBaoCao.ChartAreas.Add(chartArea);

            Series series = new Series("Tên loại sách")
            {
                XValueType = ChartValueType.String,
                ChartType = SeriesChartType.Column,
                Font = new Font("Microsoft Sans Serif", 14)
            };

            decimal maxBorrowCount = 0;

            foreach (DataRow row in dt.Rows)
            {
                string categoryName = row["TenLV"].ToString();
                int borrowCount = Convert.ToInt32(row["SoLuongMuon"]);

                series.Points.AddXY(categoryName, borrowCount);
                series.Points[series.Points.Count - 1].Label = borrowCount.ToString();
                series.Points[series.Points.Count - 1].Font = new Font("Microsoft Sans Serif", 12);

                if (borrowCount > maxBorrowCount)
                {
                    maxBorrowCount = borrowCount;
                }
            }

            chrBaoCao.Series.Add(series);

            chrBaoCao.ChartAreas[0].AxisY.Maximum = (double)(maxBorrowCount * 1.2m);

            Title title = new Title("Báo cáo loại sách được yêu thích", Docking.Top, new Font("Arial", 18, FontStyle.Bold), Color.Black);
            chrBaoCao.Titles.Add(title);

            Legend legend = new Legend
            {
                Docking = Docking.Bottom,
                Alignment = StringAlignment.Center,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular)
            };
            chrBaoCao.Legends.Add(legend);
        }

        private void BCSachYeuThich(DateTime startDate, DateTime endDate)
        {
            DataTable dt = BaoCaoDAL.GetBCSachYeuThich(startDate, endDate);

            chrBaoCao.Series.Clear();
            chrBaoCao.Legends.Clear();
            chrBaoCao.Titles.Clear();
            chrBaoCao.ChartAreas.Clear();

            ChartArea chartArea = new ChartArea();
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisX.LabelStyle.Font = new Font("Microsoft Sans Serif", 12);
            chartArea.AxisY.LabelStyle.Font = new Font("Microsoft Sans Serif", 12);
            chartArea.AxisY.Title = "Số lượng mượn";
            chartArea.AxisY.TitleFont = new Font("Microsoft Sans Serif", 12);
            chrBaoCao.ChartAreas.Add(chartArea);

            Series series = new Series("Tên sách")
            {
                //XValueType = ChartValueType.String,
                //ChartType = SeriesChartType.Column,
                ChartType = SeriesChartType.Pie,
                Font = new Font("Microsoft Sans Serif", 14)
            };

            //decimal maxBorrowCount = 0;

            foreach (DataRow row in dt.Rows)
            {
                string bookTitle = row["TenSach"].ToString();
                int borrowCount = Convert.ToInt32(row["SoLuongMuon"]);

                DataPoint dataPoint = new DataPoint
                {
                    AxisLabel = bookTitle,
                    YValues = new double[] { borrowCount }
                };

                series.Points.AddXY(bookTitle, borrowCount);
                series.Points[series.Points.Count - 1].Label = $"{bookTitle} ({borrowCount})";
                //series.Points[series.Points.Count - 1].Label = borrowCount.ToString();
                series.Points[series.Points.Count - 1].Font = new Font("Microsoft Sans Serif", 12);

                //if (borrowCount > maxBorrowCount)
                //{
                //    maxBorrowCount = borrowCount;
                //}
            }

            chrBaoCao.Series.Add(series);

            Title title = new Title("Báo cáo sách được yêu thích", Docking.Top, new Font("Arial", 18, FontStyle.Bold), Color.Black);
            chrBaoCao.Titles.Add(title);

            Legend legend = new Legend
            {
                Docking = Docking.Bottom,
                Alignment = StringAlignment.Center,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular)
            };
            chrBaoCao.Legends.Add(legend);

            series["PieLabelStyle"] = "Outside";
            //series["PieDrawingStyle"] = "SoftEdge";
            series["PieStartAngle"] = "270";
            series["DoughnutRadius"] = "30";
            chrBaoCao.ChartAreas[0].Area3DStyle.Enable3D = true;
        }

        private void BCSachMatHong(DateTime startDate, DateTime endDate)
        {
            DataTable dt = BaoCaoDAL.GetBCSachMatHong(startDate, endDate);

            chrBaoCao.Series.Clear();
            chrBaoCao.Legends.Clear();
            chrBaoCao.Titles.Clear();
            chrBaoCao.ChartAreas.Clear();

            ChartArea chartArea = new ChartArea();
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisX.LabelStyle.Font = new Font("Microsoft Sans Serif", 12);
            chartArea.AxisY.LabelStyle.Font = new Font("Microsoft Sans Serif", 12);
            chartArea.AxisY.Title = "Số lượng sách";
            chartArea.AxisY.TitleFont = new Font("Microsoft Sans Serif", 12);
            chrBaoCao.ChartAreas.Add(chartArea);

            Series lostBooksSeries = new Series("Mất sách")
            {
                XValueType = ChartValueType.String,
                ChartType = SeriesChartType.Column,
                Font = new Font("Microsoft Sans Serif", 14)
            };

            Series damagedBooksSeries = new Series("Hỏng sách")
            {
                XValueType = ChartValueType.String,
                ChartType = SeriesChartType.Column,
                Font = new Font("Microsoft Sans Serif", 14)
            };

            Dictionary<string, int> lostBooks = new Dictionary<string, int>();
            Dictionary<string, int> damagedBooks = new Dictionary<string, int>();
            HashSet<string> allBooks = new HashSet<string>();

            foreach (DataRow row in dt.Rows)
            {
                string bookName = row["TenSach"].ToString();
                string violationType = row["TenVP"].ToString();
                int quantity = Convert.ToInt32(row["SoLuongSach"]);

                allBooks.Add(bookName);

                if (violationType == "Mất sách")
                {
                    if (!lostBooks.ContainsKey(bookName))
                    {
                        lostBooks[bookName] = 0;
                    }
                    lostBooks[bookName] += quantity;
                }
                else if (violationType == "Hỏng sách")
                {
                    if (!damagedBooks.ContainsKey(bookName))
                    {
                        damagedBooks[bookName] = 0;
                    }
                    damagedBooks[bookName] += quantity;
                }
            }

            int maxBookCount = 0;

            foreach (string bookName in allBooks)
            {
                int lostQuantity = lostBooks.ContainsKey(bookName) ? lostBooks[bookName] : 0;
                int damagedQuantity = damagedBooks.ContainsKey(bookName) ? damagedBooks[bookName] : 0;

                lostBooksSeries.Points.AddXY(bookName, lostQuantity);
                lostBooksSeries.Points[lostBooksSeries.Points.Count - 1].Label = lostQuantity.ToString();
                lostBooksSeries.Points[lostBooksSeries.Points.Count - 1].Font = new Font("Microsoft Sans Serif", 12);

                damagedBooksSeries.Points.AddXY(bookName, damagedQuantity);
                damagedBooksSeries.Points[damagedBooksSeries.Points.Count - 1].Label = damagedQuantity.ToString();
                damagedBooksSeries.Points[damagedBooksSeries.Points.Count - 1].Font = new Font("Microsoft Sans Serif", 12);

                if (lostQuantity > maxBookCount)
                {
                    maxBookCount = lostQuantity;
                }

                if (damagedQuantity > maxBookCount)
                {
                    maxBookCount = damagedQuantity;
                }
            }

            chrBaoCao.Series.Add(lostBooksSeries);
            chrBaoCao.Series.Add(damagedBooksSeries);

            chrBaoCao.ChartAreas[0].AxisY.Maximum = (double)(maxBookCount * 1.2);

            Title title = new Title("Báo cáo sách bị mất/hỏng", Docking.Top, new Font("Arial", 18, FontStyle.Bold), Color.Black);
            chrBaoCao.Titles.Add(title);

            Legend legend = new Legend
            {
                Docking = Docking.Bottom,
                Alignment = StringAlignment.Center,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular)
            };
            chrBaoCao.Legends.Add(legend);
        }

        private void InBCDoanhThuThang(DateTime startDate, DateTime endDate)
        {
            try
            {
                DataTable dt = BaoCaoDAL.GetBCDoanhThuThang(startDate, endDate);

                ExcelHelper.CreateBCDoanhThuThang(dt, startDate, endDate);
            }
            catch (Exception ex)
            {
                Functions.HandleError("Lỗi: " + ex.Message);
            }
        }

        private void InBCDoanhThuTuan(DateTime startDate, DateTime endDate)
        {
            try
            {
                DataTable dt = BaoCaoDAL.GetBCDoanhThuTuan(startDate, endDate);

                ExcelHelper.CreateBCDoanhThuTuan(dt, startDate, endDate);
            }
            catch (Exception ex)
            {
                Functions.HandleError("Lỗi: " + ex.Message);
            }
        }

        private void InBCDoanhThuNgay(DateTime startDate, DateTime endDate)
        {
            try
            {
                DataTable dt = BaoCaoDAL.GetBCDoanhThuNgay(startDate, endDate);

                ExcelHelper.CreateBCDoanhThuNgay(dt, startDate, endDate);
            }
            catch (Exception ex)
            {
                Functions.HandleError("Lỗi: " + ex.Message);
            }
        }

        private void InBCLoaiSachYeuThich(DateTime startDate, DateTime endDate)
        {
            try
            {
                DataTable dt = BaoCaoDAL.GetBCLoaiSachYeuThich(startDate, endDate);

                ExcelHelper.CreateBCLoaiSachYeuThich(dt, startDate, endDate);
            }
            catch (Exception ex)
            {
                Functions.HandleError("Lỗi: " + ex.Message);
            }
        }

        private void InBCSachYeuThich(DateTime startDate, DateTime endDate)
        {
            try
            {
                DataTable dt = BaoCaoDAL.GetBCSachYeuThich(startDate, endDate);

                ExcelHelper.CreateBCSachYeuThich(dt, startDate, endDate);
            }
            catch (Exception ex)
            {
                Functions.HandleError("Lỗi: " + ex.Message);
            }
        }

        private void InBCSachMatHong(DateTime startDate, DateTime endDate)
        {
            try
            {
                DataTable dt = BaoCaoDAL.GetBCSachMatHong(startDate, endDate);

                ExcelHelper.CreateBCSachMatHong(dt, startDate, endDate);
            }
            catch (Exception ex)
            {
                Functions.HandleError("Lỗi: " + ex.Message);
            }
        }
    }
}
