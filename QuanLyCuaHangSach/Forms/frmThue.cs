using BAEK_PERCENT.Class;
using BAEK_PERCENT.DAL;
using BAEK_PERCENT.Database;
using MaterialSkin.Controls;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BAEK_PERCENT.Forms
{
    public partial class frmThue : MaterialForm
    {
        public string Username { get; set; }

        private DataTable tblThueSach;
        private DataTable tblCTThueSach;

        private bool isSearching = false;
        private string currentSearchOption = "";
        private string currentSearchKeyword = "";

        public frmThue()
        {
            InitializeComponent();

            InitializeListView();
            InitializeListViewCT();

            LoadData();

            cboTimKiem.Items.Add("Mã thuê");
            cboTimKiem.Items.Add("Tên khách hàng");
            cboTimKiem.Items.Add("Ngày thuê");
            cboTimKiem.Items.Add("Ngày trả");
        }

        private void InitializeListView()
        {
            listViewThue.FullRowSelect = true;
            listViewThue.MultiSelect = false;
            listViewThue.UseCompatibleStateImageBehavior = false;
            listViewThue.View = View.Details;

            listViewThue.Columns.Add("MaThue", "Mã thuê");
            listViewThue.Columns.Add("TenKH", "Tên khách hàng");
            listViewThue.Columns.Add("NgayThue", "Ngày thuê");
            listViewThue.Columns.Add("NgayTra", "Ngày trả");
            listViewThue.Columns.Add("TienDatCoc", "Tiền đặt cọc");
        }

        private void InitializeListViewCT()
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

        private void frmThue_Load(object sender, EventArgs e)
        {
            txtMaThue.Enabled = false;

            btnXoa.Enabled = false;
            btnLuu.Enabled = false;

            btnHuy.Enabled = false;
            btnIn.Enabled = false;

            btnThemSach.Enabled = false;
            btnSuaSach.Enabled = false;
            btnXoaSach.Enabled = false;

            txtTenKH.Enabled = false;
            txtTenNV.Enabled = false;

            txtMaSach.Enabled = false;
            txtTenSach.Enabled = false;
            txtGiaThue.Enabled = false;
            rdoChuaTra.Enabled = false;
            rdoDaTra.Enabled = false;

            txtTimKiem.Text = "Nhập từ khóa tìm kiếm";
            txtTimKiem.ForeColor = Color.Gray;

            txtMaNV.Text = NhanVienDAL.GetMaNVByUsername(Username);
            txtMaNV.Enabled = false;
        }

        private void AdjustColumnWidth()
        {
            int col1Width = 150;
            int col2Width = 250;
            int col3Width = 150;
            int col4Width = 150;
            int col5Width = 125;

            listViewThue.Columns[0].Width = col1Width;
            listViewThue.Columns[1].Width = col2Width;
            listViewThue.Columns[2].Width = col3Width;
            listViewThue.Columns[3].Width = col4Width;
            listViewThue.Columns[4].Width = col5Width;
        }

        private void AdjustColumnWidthCT()
        {
            int totalWidth = listViewCTThue.ClientSize.Width;
            double col1Percentage = 0.2;
            double col2Percentage = 0.3;
            double col3Percentage = 0.2;
            double col4Percentage = 0.3;

            int col1Width = (int)(totalWidth * col1Percentage);
            int col2Width = (int)(totalWidth * col2Percentage);
            int col3Width = (int)(totalWidth * col3Percentage);
            int col4Width = (int)(totalWidth * col4Percentage);

            listViewCTThue.Columns[0].Width = col1Width;
            listViewCTThue.Columns[1].Width = col2Width;
            listViewCTThue.Columns[2].Width = col3Width;
            listViewCTThue.Columns[3].Width = col4Width;
        }

        public void LoadData()
        {
            try
            {
                if (isSearching)
                    tblThueSach = ThueDAL.GetThueBySearch(currentSearchOption, currentSearchKeyword);
                else
                    tblThueSach = ThueDAL.GetAllThue();

                LoadListView();
            }
            catch (Exception ex)
            {
                Functions.HandleError("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void LoadDataCT(string maThue)
        {
            try
            {
                tblCTThueSach = ThueDAL.GetCTThue(maThue);

                LoadListViewCT();
            }
            catch (Exception ex)
            {
                Functions.HandleError("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void LoadListView()
        {
            ClearListView(listViewThue);

            foreach (DataRow row in tblThueSach.Rows)
            {
                ListViewItem item = new ListViewItem(row["MaThue"].ToString());
                item.SubItems.Add(row["TenKH"].ToString());

                item.Tag = new
                {
                    MaKH = row["MaKH"].ToString(),
                    MaNV = row["MaNV"].ToString(),
                    TenNV = row["TenNV"].ToString()
                };

                DateTime ngayThue;
                if (DateTime.TryParse(row["NgayThue"].ToString(), out ngayThue))
                {
                    string ngayThueFormatted = ngayThue.ToString("dd/MM/yyyy");

                    item.SubItems.Add(ngayThueFormatted);
                }
                else
                {
                    item.SubItems.Add("");
                }

                DateTime ngayTra;
                if (DateTime.TryParse(row["NgayTra"].ToString(), out ngayTra))
                {
                    string ngayTraFormatted = ngayTra.ToString("dd/MM/yyyy");

                    item.SubItems.Add(ngayTraFormatted);
                }
                else
                {
                    item.SubItems.Add("");
                }

                item.SubItems.Add(row["TienDatCoc"].ToString());

                listViewThue.Items.Add(item);
            }

            AdjustColumnWidth();
        }

        private void LoadListViewCT()
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

            AdjustColumnWidthCT();
        }

        private void ClearListView(MaterialListView listView)
        {
            listView.Items.Clear();
        }

        private void listViewThue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                Functions.HandleInfo("Đang ở chế độ thêm mới");
                txtMaSach.Focus();
                return;
            }

            if (tblThueSach.Rows.Count == 0)
            {
                Functions.HandleInfo("Không có dữ liệu");
                return;
            }

            if (listViewThue.SelectedItems.Count > 0)
            {
                txtMaSach.Enabled = true;
                rdoChuaTra.Enabled = true;
                rdoDaTra.Enabled = true;

                btnThemSach.Enabled = true;

                ListViewItem selectedItem = listViewThue.SelectedItems[0];
                txtMaThue.Text = selectedItem.SubItems[0].Text;
                txtTenKH.Text = selectedItem.SubItems[1].Text;

                string ngayThueStr = selectedItem.SubItems[2].Text;
                DateTime ngayThue;
                if (DateTime.TryParse(ngayThueStr, out ngayThue))
                {
                    txtNgayThue.Text = ngayThue.ToString("dd/MM/yyyy");
                }
                else
                {
                    txtNgayThue.Text = "";
                }

                string ngayTraStr = selectedItem.SubItems[3].Text;
                DateTime ngayTra;
                if (DateTime.TryParse(ngayTraStr, out ngayTra))
                {
                    txtNgayTra.Text = ngayTra.ToString("dd/MM/yyyy");
                }
                else
                {
                    txtNgayTra.Text = "";
                }

                txtTienDatCoc.Text = selectedItem.SubItems[4].Text;

                dynamic tagData = selectedItem.Tag;
                txtMaKH.Text = tagData.MaKH;
                txtMaNV.Text = tagData.MaNV;
                txtTenNV.Text = tagData.TenNV;

                string maThue = txtMaThue.Text.Trim();
                LoadDataCT(maThue);

                btnXoa.Enabled = true;
                btnHuy.Enabled = true;
                btnIn.Enabled = true;
            }
            else
            {
                ResetValues();
                ResetValuesCT();

                btnXoa.Enabled = false;
                btnHuy.Enabled = false;
                btnIn.Enabled = false;

                ClearListView(listViewCTThue);

                txtMaSach.Enabled = false;
                rdoChuaTra.Enabled = false;
                rdoDaTra.Enabled = false;

                btnThemSach.Enabled = false;
                btnSuaSach.Enabled = false;
                btnXoaSach.Enabled = false;
            }
        }

        private void listViewCTThue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (btnThemSach.Enabled == false)
            {
                Functions.HandleInfo("Đang ở chế độ thêm mới");
                txtMaSach.Focus();
                return;
            }

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
                txtGiaThue.Text = selectedItem.SubItems[2].Text;

                if (selectedItem.SubItems[3].Text == "Đã trả")
                {
                    rdoDaTra.Checked = true;
                    rdoChuaTra.Checked = false;
                }
                else if (selectedItem.SubItems[3].Text == "Chưa/không trả")
                {
                    rdoDaTra.Checked = false;
                    rdoChuaTra.Checked = true;
                }

                btnSuaSach.Enabled = true;
                btnXoaSach.Enabled = true;
            }
            else
            {
                ResetValuesCT();

                btnSuaSach.Enabled = false;
                btnXoaSach.Enabled = false;
            }
        }

        private void ResetValues()
        {
            txtMaThue.Text = "";
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtMaNV.Text = NhanVienDAL.GetMaNVByUsername(Username);
            txtNgayThue.Text = "";
            txtNgayTra.Text = "";
            txtTienDatCoc.Text = "";
        }

        private void ResetValuesCT()
        {
            txtMaSach.Text = "";
            txtTenSach.Text = "";
            txtGiaThue.Text = "";
            rdoDaTra.Checked = false;
            rdoChuaTra.Checked = false;
        }

        private bool ValidateInput()
        {
            /*
            if (string.IsNullOrWhiteSpace(txtMaThue.Text))
            {
                Functions.HandleWarning("Bạn phải nhập mã thuê");
                txtMaThue.Focus();
                return false;
            }
            */

            if (string.IsNullOrWhiteSpace(txtMaKH.Text))
            {
                Functions.HandleWarning("Bạn phải nhập mã khách hàng");
                txtMaKH.Focus();
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

            if (string.IsNullOrWhiteSpace(txtTienDatCoc.Text))
            {
                Functions.HandleWarning("Bạn phải nhập tiền đặt cọc");
                txtTienDatCoc.Focus();
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

            if (string.IsNullOrWhiteSpace(txtGiaThue.Text))
            {
                Functions.HandleWarning("Bạn phải nhập giá thuê");
                txtGiaThue.Focus();
                return false;
            }

            if (!rdoDaTra.Checked && !rdoChuaTra.Checked)
            {
                Functions.HandleWarning("Bạn phải chọn tình trạng trả sách");
                rdoChuaTra.Focus();
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

            txtMaSach.Enabled = true;
            btnThemSach.Enabled = true;

            rdoChuaTra.Enabled = true;
            rdoDaTra.Enabled = true;

            ResetValues();
            ResetValuesCT();

            LoadDataCT("");

            string maThue = DatabaseLayer.CreateKey("TH");
            txtMaThue.Text = maThue;
            txtNgayThue.Text = DateTime.Now.ToString("dd/MM/yyyy");
            DateTime today = DateTime.Now;
            txtNgayTra.Text = $"__/{today:MM/yyyy}";

            ThueDAL.InsertEmptyThue(maThue);

            txtMaKH.Focus();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            string maThue = txtMaThue.Text.Trim();

            ResetValuesCT();
            ResetValues();

            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnIn.Enabled = false;

            txtMaThue.Enabled = false;

            txtMaSach.Enabled = false;
            rdoChuaTra.Enabled = false;
            rdoDaTra.Enabled = false;

            txtTimKiem.Text = "";
            isSearching = false;

            if (!string.IsNullOrEmpty(maThue))
            {
                ThueDAL.DeleteEmptyThue(maThue);
            }

            LoadDataCT("");
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maThue = txtMaThue.Text.Trim();

            if (!string.IsNullOrEmpty(maThue))
            {
                if (Functions.HandleQuestion("Bạn có muốn xóa không?"))
                {
                    try
                    {
                        ThueDAL.DeleteCTThue(maThue);
                        ThueDAL.DeleteThue(maThue);

                        Functions.HandleInfo("Xóa thuê sách thành công");
                        LoadData();
                        LoadDataCT("");
                        ResetValues();
                        ResetValuesCT();

                        btnXoa.Enabled = false;
                        btnHuy.Enabled = false;
                        btnIn.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        Functions.HandleError("Lỗi khi xóa thuê sách: " + ex.Message);
                    }
                }
            }
        }

        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {
            string maKH = txtMaKH.Text.Trim();

            if (!string.IsNullOrEmpty(maKH))
            {
                txtTenKH.Text = KhachHangDAL.GetTenKhachHangByMa(maKH);
            }
            else
            {
                txtTenKH.Text = string.Empty;
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
                var sachInfo = SachDAL.GetTenGiaSachByMa(maSach);
                if (sachInfo != null)
                {
                    txtTenSach.Text = sachInfo.Item1;

                    // Lấy đơn giá thuê
                    string donGiaThueStr = sachInfo.Item2;
                    txtGiaThue.Tag = donGiaThueStr; // Sử dụng Tag để lưu đơn giá thuê

                    // Tính giá thuê
                    CalculateGiaThue();
                }
                else
                {
                    txtTenSach.Text = string.Empty;
                    txtGiaThue.Text = string.Empty;
                }
            }
            else
            {
                txtTenSach.Text = string.Empty;
                txtGiaThue.Text = string.Empty;
            }
        }

        private void txtNgayThue_TextChanged(object sender, EventArgs e)
        {
            CalculateGiaThue();
        }

        private void txtNgayTra_TextChanged(object sender, EventArgs e)
        {
            CalculateGiaThue();
        }

        private void CalculateGiaThue()
        {
            // Chỉ tính toán khi có đầy đủ thông tin
            if (!string.IsNullOrEmpty(txtMaSach.Text.Trim()) &&
                DateTime.TryParse(txtNgayThue.Text, out DateTime ngayThue) &&
                DateTime.TryParse(txtNgayTra.Text, out DateTime ngayTra) &&
                int.TryParse(txtGiaThue.Tag?.ToString(), out int donGiaThue))
            {
                // Tính số ngày thuê
                int soNgayThue = (ngayTra - ngayThue).Days;

                // Tính giá thuê
                int giaThue = soNgayThue * donGiaThue;

                // Hiển thị giá thuê
                txtGiaThue.Text = giaThue.ToString();
            }
            else
            {
                txtGiaThue.Text = string.Empty;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maThue = txtMaThue.Text.Trim();

            if (!ThueDAL.CheckMaThueExists(maThue))
            {
                if (ValidateInput())
                {
                    string maKH = txtMaKH.Text.Trim();
                    string tenKH = txtTenKH.Text.Trim();
                    string maNV = txtMaNV.Text.Trim();
                    string tenNV = txtTenNV.Text.Trim();

                    DateTime ngayThue;
                    if (!DateTime.TryParse(txtNgayThue.Text.Trim(), out ngayThue))
                    {
                        Functions.HandleWarning("Ngày thuê không hợp lệ");
                        txtNgayThue.Focus();
                        return;
                    }

                    DateTime ngayTra;
                    if (!DateTime.TryParse(txtNgayTra.Text.Trim(), out ngayTra))
                    {
                        Functions.HandleWarning("Ngày trả không hợp lệ");
                        txtNgayThue.Focus();
                        return;
                    }

                    int tienDatCoc = Convert.ToInt32(txtTienDatCoc.Text.Trim());

                    try
                    {
                        ThueDAL.UpdateThue(maThue, maKH, maNV, ngayThue, ngayTra, tienDatCoc);

                        Functions.HandleInfo("Thêm thuê sách thành công");
                        LoadData();
                        LoadDataCT("");

                        ResetValues();
                        ResetValuesCT();

                        btnThem.Enabled = true;
                        btnXoa.Enabled = false;
                        btnHuy.Enabled = false;
                        btnLuu.Enabled = false;
                        btnIn.Enabled = false;

                        txtMaSach.Enabled = false;
                        btnThemSach.Enabled = false;
                        btnSuaSach.Enabled = false;
                        btnXoaSach.Enabled = false;
                        rdoChuaTra.Enabled = false;
                        rdoDaTra.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        Functions.HandleError("Lỗi khi thêm thuê sách: " + ex.Message);
                    }
                }
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                string maThue = txtMaThue.Text;
                DataTable tblThongTinThue, tblThongTinCTThue;

                tblThongTinThue = ThueDAL.GetThongTinThue(maThue);
                tblThongTinCTThue = ThueDAL.GetThongTinCTThue(maThue);

                // Tạo và hiển thị hóa đơn trong Excel
                ExcelHelper.CreateBillThue(tblThongTinThue, tblThongTinCTThue);
            }
            catch (Exception ex)
            {
                Functions.HandleError("Lỗi: " + ex.Message);
            }
        }

        private void btnThemSach_Click(object sender, EventArgs e)
        {
            string maThue = txtMaThue.Text.Trim();

            if (ValidateInputCT())
            {
                string maSach = txtMaSach.Text.Trim();
                int giaThue = Convert.ToInt32(txtGiaThue.Text);
                bool tinhTrang = rdoDaTra.Checked;

                // Kiểm tra xem mã sách đã có trong chi tiết thuê chưa
                if (ThueDAL.CheckMaSach(maSach, maThue))
                {
                    Functions.HandleWarning("Sách này đã có trong hóa đơn, vui lòng chọn sách khác hoặc xoá");
                    ResetValuesCT();
                    txtMaSach.Focus();
                    return;
                }

                // Kiểm tra số lượng sách còn đủ để cho mượn không
                int soLuongCon = SachDAL.GetSoLuong(maSach);
                if (soLuongCon < 1)
                {
                    Functions.HandleWarning("Sách này hiện không còn cuốn để cho mượn");
                    ResetValuesCT();
                    txtMaSach.Focus();
                    return;
                }

                try
                {
                    ThueDAL.InsertSachCTThue(maThue, maSach, giaThue, tinhTrang);
                    Functions.HandleInfo("Thêm chi tiết thuê sách thành công");

                    if (tinhTrang)
                    {
                        SachDAL.TangSoLuong(maSach);
                    }
                    else
                    {
                        SachDAL.GiamSoLuong(maSach);
                    }

                    LoadDataCT(maThue);
                    ResetValuesCT();
                }
                catch (Exception ex)
                {
                    Functions.HandleError("Lỗi khi thêm chi tiết thuê sách: " + ex.Message);
                }
            }
        }

        private void btnSuaSach_Click(object sender, EventArgs e)
        {
            string maThue = txtMaThue.Text.Trim();

            bool tinhTrangCu = listViewCTThue.SelectedItems[0].SubItems[3].Text == "Đã trả" ? true : false;

            if (ValidateInputCT())
            {
                string maSach = txtMaSach.Text.Trim();
                int giaThue = Convert.ToInt32(txtGiaThue.Text);
                bool tinhTrang = rdoDaTra.Checked;

                // Kiểm tra xem mã sách đã có trong chi tiết thuê chưa
                if (ThueDAL.CheckMaSach(maSach, maThue))
                {
                    Functions.HandleWarning("Sách này đã có trong hóa đơn, vui lòng chọn sách khác hoặc xoá");
                    ResetValuesCT();
                    txtMaSach.Focus();
                    return;
                }

                // Kiểm tra số lượng sách còn đủ để cho mượn không
                int soLuongCon = SachDAL.GetSoLuong(maSach);
                if (soLuongCon < 1)
                {
                    Functions.HandleWarning("Sách này hiện không còn cuốn để cho mượn");
                    ResetValuesCT();
                    txtMaSach.Focus();
                    return;
                }

                try
                {
                    ThueDAL.UpdateSachCTThue(maThue, maSach, giaThue, tinhTrang);
                    Functions.HandleInfo("Sửa chi tiết thuê sách thành công");

                    if (tinhTrang == true && tinhTrangCu == false)
                    {
                        SachDAL.TangSoLuong(maSach);
                    }
                    else if (tinhTrang == false && tinhTrangCu == true)
                    {
                        SachDAL.GiamSoLuong(maSach);
                    }

                    LoadDataCT(maThue);
                    ResetValuesCT();
                }
                catch (Exception ex)
                {
                    Functions.HandleError("Lỗi khi sửa chi tiết thuê sách: " + ex.Message);
                }
            }
        }

        private void btnXoaSach_Click(object sender, EventArgs e)
        {
            string maThue = txtMaThue.Text.Trim();
            string maSach = txtMaSach.Text.Trim();

            bool tinhTrang = listViewCTThue.SelectedItems[0].SubItems[3].Text == "Đã trả" ? true : false;

            if (!string.IsNullOrEmpty(maThue) && !string.IsNullOrEmpty(maSach))
            {
                if (Functions.HandleQuestion("Bạn có muốn xóa không?"))
                {
                    try
                    {
                        ThueDAL.DeleteSachCTThue(maThue, maSach);
                        Functions.HandleInfo("Xóa sách thành công");

                        if (!tinhTrang)
                        {
                            SachDAL.TangSoLuong(maSach);
                        }

                        LoadDataCT(maThue);
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

        private void txtTienDatCoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
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