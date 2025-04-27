using BAEK_PERCENT.DAL;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms.DataVisualization.Charting;

namespace BAEK_PERCENT.Forms
{
    public partial class frmHome : MaterialForm
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void swtDarkMode_CheckedChanged(object sender, EventArgs e)
        {
            if (swtDarkMode.Checked)
            {
                EnableDarkMode();
            }
            else
            {
                EnableLightMode();
            }
        }

        private MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;

        private void EnableDarkMode()
        {
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            var darkestColorScheme = new ColorScheme(
                Color.FromArgb(12, 12, 12),        // Darkest Gray
                Color.FromArgb(8, 8, 8),           // Darkest Black
                Color.FromArgb(18, 18, 18),        // Very Dark Gray
                Color.FromArgb(255, 150, 79),      // Orange
                TextShade.WHITE
            );
            materialSkinManager.ColorScheme = darkestColorScheme;

        }

        private void EnableLightMode()
        {
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            var lightColorScheme = new ColorScheme(
                Color.FromArgb(255, 255, 255),     // White
                Color.FromArgb(240, 240, 240),     // Light Gray
                Color.FromArgb(255, 255, 255),     // White
                Color.FromArgb(255, 150, 79),      // Orange
                TextShade.BLACK
            );
            materialSkinManager.ColorScheme = lightColorScheme;
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            lblSoDonThueThang.Text = BaoCaoDAL.GetSoDonThueThangNay().ToString();
            lblSoDonThueChuaTra.Text = BaoCaoDAL.GetSoDonThueChuaTraThangNay().ToString();
            lblDoanhThuThang.Text = FormatCurrency(BaoCaoDAL.GetDoanhThuThangNay());

            BCSach10Ngay();
        }

        public void SetDoanhThuCardVisible(bool isVisible)
        {
            lblDoanhThu.Visible = isVisible;
            lblDoanhThuThang.Visible = isVisible;
            materialCardDT.Visible = isVisible;
            btnDirectToBaoCao.Visible = isVisible;
        }

        private void BCSach10Ngay()
        {
            DataTable dt = BaoCaoDAL.GetSoSachThue10Ngay();

            chrHome.Series.Clear();
            chrHome.Legends.Clear();
            chrHome.Titles.Clear();
            chrHome.ChartAreas.Clear();

            ChartArea chartArea = new ChartArea();
            chartArea.AxisX.LabelStyle.Format = "dd/MM";
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.IntervalType = DateTimeIntervalType.Days;
            chartArea.AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisX.LabelStyle.Font = new Font("Microsoft Sans Serif", 14);
            chartArea.AxisY.LabelStyle.Font = new Font("Microsoft Sans Serif", 14);
            chrHome.ChartAreas.Add(chartArea);

            Series series = new Series("Số sách thuê")
            {
                XValueType = ChartValueType.Date,
                ChartType = SeriesChartType.Line,
                Font = new Font("Microsoft Sans Serif", 14),
                BorderWidth = 3
            };

            int maxBooksRented = 0;
            foreach (DataRow row in dt.Rows)
            {
                DateTime date = Convert.ToDateTime(row["Date"]);
                int booksRented = Convert.ToInt32(row["BooksRented"]);

                series.Points.AddXY(date, booksRented);
                series.Points[series.Points.Count - 1].Label = booksRented.ToString();

                if (booksRented > maxBooksRented)
                {
                    maxBooksRented = booksRented;
                }
            }

            chrHome.Series.Add(series);
            chrHome.ChartAreas[0].AxisY.Maximum = maxBooksRented + (maxBooksRented * 0.1);

            Title title = new Title("Báo cáo số sách thuê trong 10 ngày gần nhất", Docking.Top, new Font("Arial", 18, FontStyle.Bold), Color.Black);
            chrHome.Titles.Add(title);

            Legend legend = new Legend
            {
                Docking = Docking.Bottom,
                Alignment = StringAlignment.Center,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular)
            };
            chrHome.Legends.Add(legend);

            series.IsVisibleInLegend = false;
        }

        public event EventHandler DirectToThueClicked;
        public event EventHandler DirectToTraClicked;
        public event EventHandler DirectToBaoCaoClicked;

        private void btnDirectToThue_Click(object sender, EventArgs e)
        {
            DirectToThueClicked?.Invoke(sender, e); // Gọi sự kiện DirectToThueClicked
        }

        private void btnDirectToTra_Click(object sender, EventArgs e)
        {
            DirectToTraClicked?.Invoke(sender, e); // Gọi sự kiện DirectToThueClicked
        }

        private void btnDirectToBaoCao_Click(object sender, EventArgs e)
        {
            DirectToBaoCaoClicked?.Invoke(sender, e); // Gọi sự kiện DirectToBaoCaoClicked
        }

        private string FormatCurrency(decimal value)
        {
            return value.ToString("N0", CultureInfo.CreateSpecificCulture("vi-VN")) + "đ";
        }
    }
}