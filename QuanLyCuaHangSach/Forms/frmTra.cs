using BAEK_PERCENT.Class;
using BAEK_PERCENT.DAL;
using BAEK_PERCENT.Database;
using MaterialSkin.Controls;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BAEK_PERCENT.Forms
{
    public partial class frmTra : MaterialForm
    {
        public string Username { get; set; }

        private DataTable tblCTThueSach;
        private DataTable tblTraSach;
        private DataTable tblCTTraSach;

        private int tongTien = -1;

        private bool isSearching = false;
        private string currentSearchOption = "";
        private string currentSearchKeyword = "";

        public frmTra()
        {
            InitializeComponent();

            InitializeListViewCTThue();
            InitializeListView();
            InitializeListViewCT();

            LoadData();

            string fillComboSql = "SELECT * FROM ViPham";
            DatabaseLayer.FillCombo(fillComboSql, cboViPham, "MaVP", "TenVP");
            cboViPham.SelectedItem = null;

            cboTimKiem.Items.Add("Mã thuê");
            cboTimKiem.Items.Add("Mã trả");
            cboTimKiem.Items.Add("Tên khách hàng");
            cboTimKiem.Items.Add("Ngày thực tế");
        }

        private void InitializeListView()
        {
            listViewTra.FullRowSelect = true;
            listViewTra.MultiSelect = false;
            listViewTra.UseCompatibleStateImageBehavior = false;
            listViewTra.View = View.Details;

            listViewTra.Columns.Add("MaTra", "Mã trả");
            listViewTra.Columns.Add("MaThue", "Mã thuê");
            listViewTra.Columns.Add("TenKH", "Tên khách hàng");
            listViewTra.Columns.Add("NgayThucTe", "Ngày trả thực tế");
            listViewTra.Columns.Add("TongTien", "Tổng tiền");
        }

        private void InitializeListViewCT()
        {
            listViewCTTra.FullRowSelect = true;
            listViewCTTra.MultiSelect = false;
            listViewCTTra.UseCompatibleStateImageBehavior = false;
            listViewCTTra.View = View.Details;

            listViewCTTra.Columns.Add("MaSach", "Mã sách");
            listViewCTTra.Columns.Add("TenSach", "Tên sách");
            listViewCTTra.Columns.Add("MaVP", "Mã vi phạm");
            listViewCTTra.Columns.Add("ThanhTien", "Thành tiền");
        }

        private void InitializeListViewCTThue()
        {
            listViewCTThue.FullRowSelect = true;
            listViewCTThue.MultiSelect = false;
            listViewCTThue.UseCompatibleStateImageBehavior = false;
            listViewCTThue.View = View.Details;

            listViewCTThue.Columns.Add("MaSach", "Mã sách");
            listViewCTThue.Columns.Add("TenSach", "Tên sách");
            listViewCTThue.Columns.Add("GiaThue", "Giá thuê");
            listViewCTThue.Columns.Add("DaTra", "Tình trạng");
        }

        private void frmTra_Load(object sender, EventArgs e)
        {
            txtMaTra.Enabled = false;

            btnXoa.Enabled = false;
            btnLuu.Enabled = false;

            btnHuy.Enabled = false;
            btnIn.Enabled = false;

            btnThemSach.Enabled = false;
            btnXoaSach.Enabled = false;

            txtTenKH.Enabled = false;
            txtTenNV.Enabled = false;
            txtNgayThue.Enabled = false;
            txtNgayTra.Enabled = false;
            txtTienDatCoc.Enabled = false;

            txtMaSach.Enabled = false;
            txtTenSach.Enabled = false;
            cboViPham.Enabled = false;
            txtThanhTien.Enabled = false;

            txtTimKiem.Text = "Nhập từ khóa tìm kiếm";
            txtTimKiem.ForeColor = Color.Gray;

            txtMaNV.Text = NhanVienDAL.GetMaNVByUsername(Username);
            txtMaNV.Enabled = false;

            txtTongTien.Enabled = false;
        }

        private void AdjustColumnWidth()
        {
            int col1Width = 150;
            int col2Width = 150;
            int col3Width = 250;
            int col4Width = 150;
            int col5Width = 150;

            listViewTra.Columns[0].Width = col1Width;
            listViewTra.Columns[1].Width = col2Width;
            listViewTra.Columns[2].Width = col3Width;
            listViewTra.Columns[3].Width = col4Width;
            listViewTra.Columns[4].Width = col5Width;
        }

        private void AdjustColumnWidthCT(MaterialListView listView)
        {
            int totalWidth = listView.ClientSize.Width;
            double col1Percentage = 0.2;
            double col2Percentage = 0.3;
            double col3Percentage = 0.25;
            double col4Percentage = 0.25;

            int col1Width = (int)(totalWidth * col1Percentage);
            int col2Width = (int)(totalWidth * col2Percentage);
            int col3Width = (int)(totalWidth * col3Percentage);
            int col4Width = (int)(totalWidth * col4Percentage);

            listView.Columns[0].Width = col1Width;
            listView.Columns[1].Width = col2Width;
            listView.Columns[2].Width = col3Width;
            listView.Columns[3].Width = col4Width;
        }

        public void LoadData()
        {
            try
            {
                if (isSearching)
                    tblTraSach = TraDAL.GetTraBySearch(currentSearchOption, currentSearchKeyword);
                else
                    tblTraSach = TraDAL.GetAllTra();

                LoadListView();
            }
            catch (Exception ex)
            {
                Functions.HandleError("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void LoadDataCT(string maTra)
        {
            try
            {
                tblCTTraSach = TraDAL.GetCTTra(maTra);

                LoadListViewCT();
            }
            catch (Exception ex)
            {
                Functions.HandleError("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void LoadDataCTThue(string maThue)
        {
            try
            {
                tblCTThueSach = ThueDAL.GetCTThueChuaTra(maThue);

                LoadListViewCTThue();
            }
            catch (Exception ex)
            {
                Functions.HandleError("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void LoadListView()
        {
            ClearListView(listViewTra);

            foreach (DataRow row in tblTraSach.Rows)
            {
                ListViewItem item = new ListViewItem(row["MaTra"].ToString());
                item.SubItems.Add(row["MaThue"].ToString());
                item.SubItems.Add(row["TenKH"].ToString());
                item.SubItems.Add(row["NgayThucTe"].ToString());

                DateTime ngayThue;
                DateTime ngayTra;

                item.Tag = new
                {
                    //MaKH = row["MaKH"].ToString(),
                    MaNV = row["MaNV"].ToString(),
                    TenNV = row["TenNV"].ToString(),
                    TienDatCoc = row["TienDatCoc"].ToString(),
                    NgayThue = DateTime.TryParse(row["NgayThue"].ToString(), out ngayThue) ? ngayThue.ToString("dd/MM/yyyy") : "",
                    NgayTra = DateTime.TryParse(row["NgayTra"].ToString(), out ngayTra) ? ngayTra.ToString("dd/MM/yyyy") : ""
                };

                item.SubItems.Add(row["TongTien"].ToString());

                listViewTra.Items.Add(item);
            }

            AdjustColumnWidth();
        }

        private void LoadListViewCT()
        {
            ClearListView(listViewCTTra);

            foreach (DataRow row in tblCTTraSach.Rows)
            {
                ListViewItem item = new ListViewItem(row["MaSach"].ToString());
                item.SubItems.Add(row["TenSach"].ToString());
                item.SubItems.Add(row["MaVP"].ToString());
                item.SubItems.Add(row["ThanhTien"].ToString());

                listViewCTTra.Items.Add(item);
            }

            AdjustColumnWidthCT(listViewCTTra);
        }

        private void LoadListViewCTThue()
        {
            ClearListView(listViewCTThue);

            foreach (DataRow row in tblCTThueSach.Rows)
            {
                ListViewItem item = new ListViewItem(row["MaSach"].ToString());
                item.SubItems.Add(row["TenSach"].ToString());
                item.SubItems.Add(row["GiaThue"].ToString());

                string trangThai = "";
                if (row["DaTra"] != null && row["DaTra"] != DBNull.Value)
                {
                    bool trangThaiValue = Convert.ToBoolean(row["DaTra"]);
                    trangThai = trangThaiValue ? "Đã trả" : "Chưa/không trả";
                }
                else
                {
                    trangThai = "";
                }

                item.SubItems.Add(trangThai);

                listViewCTThue.Items.Add(item);
            }

            AdjustColumnWidthCT(listViewCTThue);
        }

        private void ClearListView(MaterialListView listView)
        {
            listView.Items.Clear();
        }

        private void listViewTra_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                Functions.HandleInfo("Đang ở chế độ thêm mới");
                txtMaSach.Focus();
                return;
            }

            if (tblTraSach.Rows.Count == 0)
            {
                Functions.HandleInfo("Không có dữ liệu");
                return;
            }

            if (listViewTra.SelectedItems.Count > 0)
            {
                // txtMaSach.Enabled = true;
                cboViPham.Enabled = true;

                btnThemSach.Enabled = true;

                ListViewItem selectedItem = listViewTra.SelectedItems[0];
                txtMaTra.Text = selectedItem.SubItems[0].Text;
                txtMaThue.Text = selectedItem.SubItems[1].Text;
                txtTenKH.Text = selectedItem.SubItems[2].Text;

                string ngayThucTeStr = selectedItem.SubItems[3].Text;
                DateTime ngayThucTe;
                if (DateTime.TryParse(ngayThucTeStr, out ngayThucTe))
                {
                    txtNgayThucTe.Text = ngayThucTe.ToString("dd/MM/yyyy");
                }
                else
                {
                    txtNgayThucTe.Text = "";
                }

                txtTongTien.Text = selectedItem.SubItems[4].Text;

                dynamic tagData = selectedItem.Tag;
                txtMaNV.Text = tagData.MaNV;
                txtTenNV.Text = tagData.TenNV;
                txtNgayThue.Text = tagData.NgayThue;
                txtNgayTra.Text = tagData.NgayTra;
                txtTienDatCoc.Text = tagData.TienDatCoc;

                string maTra = txtMaTra.Text.Trim();
                string maThue = txtMaThue.Text.Trim();

                LoadDataCT(maTra);
                LoadDataCTThue(maThue);

                btnXoa.Enabled = true;
                btnHuy.Enabled = true;
                btnIn.Enabled = true;

                btnLuu.Enabled = true;
            }
            else
            {
                ResetValues();
                ResetValuesCT();

                LoadDataCT("");
                LoadDataCTThue("");

                btnXoa.Enabled = false;
                btnHuy.Enabled = false;
                btnIn.Enabled = false;

                ClearListView(listViewCTThue);

                txtMaSach.Enabled = false;
                cboViPham.Enabled = false;

                btnThemSach.Enabled = false;
                btnXoaSach.Enabled = false;

                btnLuu.Enabled = false;
            }
        }

        private void listViewCTThue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tblCTThueSach.Rows.Count == 0)
            {
                Functions.HandleInfo("Không có dữ liệu");
                return;
            }

            if (listViewCTThue.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewCTThue.SelectedItems[0];
                txtMaSach.Text = selectedItem.SubItems[0].Text;
                txtTenSach.Text = selectedItem.SubItems[1].Text;
            }
            else
            {
                txtMaSach.Text = "";
                txtTenSach.Text = "";
            }
        }

        private void listViewCTTra_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (btnThemSach.Enabled == false)
            {
                Functions.HandleInfo("Đang ở chế độ thêm mới");
                txtMaSach.Focus();
                return;
            }

            if (tblCTTraSach.Rows.Count == 0)
            {
                Functions.HandleInfo("Không có dữ liệu");
                return;
            }

            if (listViewCTTra.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewCTTra.SelectedItems[0];
                txtMaSach.Text = selectedItem.SubItems[0].Text;
                txtTenSach.Text = selectedItem.SubItems[1].Text;
                cboViPham.Text = DatabaseLayer.GetFieldValues("SELECT TenVP FROM ViPham WHERE MaVP = N'" + selectedItem.SubItems[2].Text + "';");

                txtThanhTien.Text = selectedItem.SubItems[3].Text;

                btnXoaSach.Enabled = true;
            }
            else
            {
                ResetValuesCT();
                btnXoaSach.Enabled = false;
            }
        }

        private void ResetValues()
        {
            txtMaTra.Text = "";
            txtMaThue.Text = "";
            txtTenKH.Text = "";
            txtMaNV.Text = txtMaNV.Text = NhanVienDAL.GetMaNVByUsername(Username);
            txtNgayThue.Text = "";
            txtNgayTra.Text = "";
            txtNgayThucTe.Text = "";
            txtTienDatCoc.Text = "";
            txtTongTien.Text = "";
        }

        private void ResetValuesCT()
        {
            txtMaSach.Text = "";
            txtTenSach.Text = "";
            cboViPham.SelectedItem = null;
            txtThanhTien.Text = null;
        }

        private bool ValidateInput()
        {
            /*
            if (string.IsNullOrWhiteSpace(txtMaTra.Text))
            {
                Functions.HandleWarning("Bạn phải nhập mã trả");
                txtMaTra.Focus();
                return false;
            }
            */

            if (string.IsNullOrWhiteSpace(txtMaThue.Text))
            {
                Functions.HandleWarning("Bạn phải nhập mã thuê");
                txtMaThue.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenKH.Text))
            {
                Functions.HandleWarning("Bạn phải nhập tên khách hàng");
                txtTenKH.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                Functions.HandleWarning("Bạn phải nhập mã nhân viên");
                txtMaNV.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenNV.Text))
            {
                Functions.HandleWarning("Bạn phải nhập tên nhân viên");
                txtTenNV.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNgayThue.Text))
            {
                Functions.HandleWarning("Bạn phải nhập ngày thuê");
                txtNgayThue.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNgayTra.Text))
            {
                Functions.HandleWarning("Bạn phải nhập ngày trả");
                txtNgayTra.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNgayThucTe.Text))
            {
                Functions.HandleWarning("Bạn phải nhập ngày trả thực tế");
                txtNgayThucTe.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTienDatCoc.Text))
            {
                Functions.HandleWarning("Bạn phải nhập tiền đặt cọc");
                txtTienDatCoc.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTongTien.Text))
            {
                Functions.HandleWarning("Bạn phải nhập tổng tiền");
                txtTongTien.Focus();
                return false;
            }

            return true;
        }

        private bool ValidateInputCT()
        {
            if (string.IsNullOrWhiteSpace(txtMaSach.Text))
            {
                Functions.HandleWarning("Bạn phải nhập mã sách");
                txtMaSach.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenSach.Text))
            {
                Functions.HandleWarning("Bạn phải nhập tên sách");
                txtTenSach.Focus();
                return false;
            }

            if (cboViPham.SelectedItem == null)
            {
                Functions.HandleWarning("Bạn phải chọn vi phạm");
                cboViPham.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtThanhTien.Text))
            {
                Functions.HandleWarning("Bạn phải nhập thành tiền của vi phạm");
                txtThanhTien.Focus();
                return false;
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnIn.Enabled = false;

            btnHuy.Enabled = true;
            btnLuu.Enabled = true;

            // txtMaSach.Enabled = true;
            btnThemSach.Enabled = true;

            cboViPham.Enabled = true;

            ResetValues();
            ResetValuesCT();

            LoadDataCT("");
            LoadDataCTThue("");

            string maTra = DatabaseLayer.CreateKey("TR");
            txtMaTra.Text = maTra;
            txtNgayThucTe.Text = DateTime.Now.ToString("dd/MM/yyyy");
            DateTime today = DateTime.Now;

            TraDAL.InsertEmptyTra(maTra);

            txtMaNV.Focus();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            string maTra = txtMaTra.Text.Trim();

            ResetValuesCT();
            ResetValues();

            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnIn.Enabled = false;

            txtMaSach.Enabled = false;
            cboViPham.Enabled = false;

            txtTimKiem.Text = "";
            isSearching = false;

            if (!string.IsNullOrEmpty(maTra))
            {
                TraDAL.DeleteEmptyTra(maTra);
            }

            LoadDataCTThue("");
            LoadDataCT("");
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maTra = txtMaTra.Text.Trim();

            if (!string.IsNullOrEmpty(maTra))
            {
                if (Functions.HandleQuestion("Bạn có muốn xóa không?"))
                {
                    try
                    {
                        TraDAL.DeleteCTTra(maTra);
                        TraDAL.DeleteTra(maTra);

                        Functions.HandleInfo("Xóa trả sách thành công");
                        LoadData();
                        LoadDataCT("");
                        LoadDataCTThue("");
                        ResetValues();
                        ResetValuesCT();

                        btnXoa.Enabled = false;
                        btnHuy.Enabled = false;
                        btnIn.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        Functions.HandleError("Lỗi khi xóa trả sách: " + ex.Message);
                    }
                }
            }
        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text.Trim();

            if (!string.IsNullOrEmpty(maNV))
            {
                txtTenNV.Text = NhanVienDAL.GetTenNhanVienByMa(maNV);
            }
            else
            {
                txtTenNV.Text = string.Empty;
            }
        }

        private void txtMaSach_TextChanged(object sender, EventArgs e)
        {
            string maSach = txtMaSach.Text.Trim();

            if (!string.IsNullOrEmpty(maSach))
            {
                txtTenSach.Text = SachDAL.GetTenSachByMa(maSach);
                CalculateGiaPhat();
            }
            else
            {
                txtTenSach.Text = string.Empty;
            }
        }

        private void txtMaThue_TextChanged(object sender, EventArgs e)
        {
            string maThue = txtMaThue.Text.Trim();

            if (!string.IsNullOrEmpty(maThue))
            {
                DataTable data = ThueDAL.GetAllThue();

                string escapedMaThue = maThue.Replace("'", "''");

                DataRow[] rows = data.Select($"MaThue = '{escapedMaThue}'");

                if (rows.Length > 0)
                {
                    DataRow row = rows[0];

                    txtTenKH.Text = row["TenKH"].ToString();
                    txtNgayThue.Text = row["NgayThue"].ToString();
                    txtNgayTra.Text = row["NgayTra"].ToString();
                    txtTienDatCoc.Text = row["TienDatCoc"].ToString();

                    tongTien = -1;
                    tongTien = TraDAL.CalcTongTien(maThue);
                    txtTongTien.Text = tongTien.ToString();

                    LoadDataCTThue(maThue);
                }
                else
                {
                    txtTenKH.Text = string.Empty;
                    txtNgayThue.Text = string.Empty;
                    txtNgayTra.Text = string.Empty;
                    txtTienDatCoc.Text = string.Empty;

                    tongTien = -1;
                    txtTongTien.Text = string.Empty;

                    LoadDataCTThue("");
                }
            }
            else
            {
                txtTenKH.Text = string.Empty;
                txtNgayThue.Text = string.Empty;
                txtNgayTra.Text = string.Empty;
                txtTienDatCoc.Text = string.Empty;

                tongTien = -1;
                txtTongTien.Text = string.Empty;
            }
        }

        private void txtNgayThucTe_TextChanged(object sender, EventArgs e)
        {
            CalculateGiaPhat();
        }

        private void CalculateGiaPhat()
        {
            // Chỉ tính toán khi có đầy đủ thông tin
            if (!string.IsNullOrEmpty(txtMaSach.Text.Trim()) &&
                DateTime.TryParse(txtNgayTra.Text, out DateTime ngayTra) &&
                DateTime.TryParse(txtNgayThucTe.Text, out DateTime ngayThucTe))
            {
                string viPham = cboViPham.Text.ToString();
                int tienPhat = 0;

                if (viPham == "Mất sách")
                {
                    // Tiền phạt là 1 lần giá sách
                    int giaSach = SachDAL.GetGiaSach(txtMaSach.Text.Trim());

                    tienPhat = giaSach;
                }
                else if (viPham == "Hỏng sách")
                {
                    // Tiền phạt là 0.7 lần giá sách
                    int giaSach = SachDAL.GetGiaSach(txtMaSach.Text.Trim());
                    tienPhat = (int)(0.7 * giaSach);
                }
                else if (viPham == "Quá hạn trả")
                {
                    // Tính số ngày chậm
                    int soNgayCham = (ngayThucTe - ngayTra).Days;

                    if (soNgayCham > 0)
                    {
                        // Tiền phạt là số ngày chậm * 2000
                        tienPhat = soNgayCham * 2000;
                    }
                }

                txtThanhTien.Text = tienPhat.ToString();
            }
            else
            {
                txtThanhTien.Text = string.Empty;
            }
        }

        private void cboViPham_SelectedIndexChanged(object sender, EventArgs e)
        {


            CalculateGiaPhat();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maTra = txtMaTra.Text.Trim();

            if (!TraDAL.CheckMaTraExists(maTra))
            {
                if (ValidateInput())
                {
                    string maThue = txtMaThue.Text.Trim();
                    string maNV = txtMaNV.Text.Trim();

                    DateTime ngayThucTe;
                    if (!DateTime.TryParse(txtNgayThucTe.Text.Trim(), out ngayThucTe))
                    {
                        Functions.HandleWarning("Ngày thực tế không hợp lệ");
                        txtNgayThucTe.Focus();
                        return;
                    }

                    try
                    {
                        tongTien = Convert.ToInt32(txtTongTien.Text.Trim());
                        TraDAL.UpdateTra(maTra, maThue, maNV, ngayThucTe, tongTien);

                        Functions.HandleInfo("Thêm trả sách thành công");
                        LoadData();
                        LoadDataCT("");
                        LoadDataCTThue("");

                        ResetValues();
                        ResetValuesCT();

                        btnThem.Enabled = true;
                        btnXoa.Enabled = false;
                        btnHuy.Enabled = false;
                        btnLuu.Enabled = false;
                        btnIn.Enabled = false;

                        txtMaSach.Enabled = false;
                        btnThemSach.Enabled = false;
                        btnXoaSach.Enabled = false;
                        cboViPham.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        Functions.HandleError("Lỗi khi thêm trả sách: " + ex.Message);
                    }
                }
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                string maTra = txtMaTra.Text;
                string maThue = txtMaThue.Text;
                DataTable tblThongTinTra, tblThongTinCTTra;

                tblThongTinTra = TraDAL.GetThongTinTra(maThue);
                tblThongTinCTTra = TraDAL.GetThongTinCTTra(maTra);

                // Tạo và hiển thị hóa đơn trong Excel
                ExcelHelper.CreateBillTra(tblThongTinTra, tblThongTinCTTra);
            }
            catch (Exception ex)
            {
                Functions.HandleError("Lỗi: " + ex.Message);
            }
        }

        private void btnThemSach_Click(object sender, EventArgs e)
        {
            string maTra = txtMaTra.Text.Trim();
            string maThue = txtMaThue.Text.Trim();

            if (ValidateInputCT())
            {
                string maSach = txtMaSach.Text.Trim();
                string viPham = cboViPham.SelectedValue.ToString();
                int thanhTien = Convert.ToInt32(txtThanhTien.Text.Trim());

                // Kiểm tra xem mã sách đã có trong chi tiết trả chưa
                if (TraDAL.CheckMaSach(maSach, maTra))
                {
                    Functions.HandleWarning("Sách này đã có trong hóa đơn, vui lòng chọn sách khác hoặc xoá");
                    ResetValuesCT();
                    txtMaSach.Focus();
                    return;
                }

                try
                {
                    TraDAL.InsertSachCTTra(maTra, maSach, viPham, thanhTien);
                    Functions.HandleInfo("Thêm chi tiết trả sách thành công");

                    DataTable tblTra = ThueDAL.GetCTThue(maThue);
                    DataTable tblCTTra = TraDAL.GetThongTinCTTra(maTra);
                    tongTien = tblTra.AsEnumerable().Sum(row => row.Field<int>("GiaThue")) + tblCTTra.AsEnumerable().Sum(row => row.Field<int>("ThanhTien"));
                    txtTongTien.Text = tongTien.ToString();

                    LoadDataCT(maTra);
                    ResetValuesCT();
                }
                catch (Exception ex)
                {
                    Functions.HandleError("Lỗi khi thêm chi tiết trả sách: " + ex.Message);
                }
            }
        }

        private void btnXoaSach_Click(object sender, EventArgs e)
        {
            string maTra = txtMaTra.Text.Trim();
            string maThue = txtMaThue.Text.Trim();
            string maSach = txtMaSach.Text.Trim();
            int thanhTien = Convert.ToInt32(txtThanhTien.Text.Trim());

            if (!string.IsNullOrEmpty(maTra) && !string.IsNullOrEmpty(maSach))
            {
                if (Functions.HandleQuestion("Bạn có muốn xóa không?"))
                {
                    try
                    {
                        TraDAL.DeleteSachCTTra(maTra, maSach);
                        Functions.HandleInfo("Xóa sách thành công");

                        DataTable tblTra = ThueDAL.GetCTThue(maThue);
                        DataTable tblCTTra = TraDAL.GetThongTinCTTra(maTra);

                        // Sum up the rental price and individual book prices
                        int totalGiaThue = tblTra.AsEnumerable().Sum(row => row.Field<int>("GiaThue"));
                        int totalThanhTien = tblCTTra.AsEnumerable().Sum(row => row.Field<int>("ThanhTien"));

                        tongTien = totalGiaThue + totalThanhTien;
                        txtTongTien.Text = tongTien.ToString();

                        //if (TraDAL.CheckMaThueInsertedInMaTra(maTra, maThue))
                        //{
                        //    if (ValidateInput())
                        //    {
                        //        string maNV = txtMaNV.Text.Trim();

                        //        DateTime ngayThucTe;
                        //        if (!DateTime.TryParse(txtNgayThucTe.Text.Trim(), out ngayThucTe))
                        //        {
                        //            Functions.HandleWarning("Ngày thực tế không hợp lệ");
                        //            txtNgayThucTe.Focus();
                        //            return;
                        //        }

                        //        try
                        //        {
                        //            TraDAL.UpdateTra(maTra, maThue, maNV, ngayThucTe, tongTien);

                        //            Functions.HandleInfo("Cập nhật trả sách thành công");

                        //            // Reload the main data and reset the form
                        //            LoadData();
                        //            LoadDataCT("");
                        //            LoadDataCTThue("");

                        //            ResetValues();
                        //            ResetValuesCT();

                        //            btnThem.Enabled = true;
                        //            btnXoa.Enabled = false;
                        //            btnHuy.Enabled = false;
                        //            btnLuu.Enabled = false;
                        //            btnIn.Enabled = false;

                        //            txtMaSach.Enabled = false;
                        //            btnThemSach.Enabled = false;
                        //            btnXoaSach.Enabled = false;
                        //            cboViPham.Enabled = false;
                        //        }
                        //        catch (Exception ex)
                        //        {
                        //            Functions.HandleError("Lỗi khi cập nhật trả sách: " + ex.Message);
                        //        }
                        //    }
                        //}    

                        LoadDataCT(maTra);
                        ResetValuesCT();
                    }
                    catch (Exception ex)
                    {
                        Functions.HandleError("Lỗi khi xóa sách: " + ex.Message);
                    }
                }
            }
        }

        private void PerformSearch()
        {
            currentSearchOption = cboTimKiem.Text;
            currentSearchKeyword = txtTimKiem.Text.Trim();
            isSearching = true;

            LoadData();
            LoadDataCT("");

            btnHuy.Enabled = true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformSearch();
                e.SuppressKeyPress = true;
            }
        }

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "Nhập từ khóa tìm kiếm")
            {
                txtTimKiem.Text = "";
                txtTimKiem.ForeColor = Color.Black;
            }
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                txtTimKiem.Text = "Nhập từ khóa tìm kiếm";
                txtTimKiem.ForeColor = Color.Gray;
            }
        }
    }
}