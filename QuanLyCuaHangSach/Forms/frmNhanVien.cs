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
    public partial class frmNhanVien : MaterialForm
    {
        private DataTable tblNhanVien;

        private bool isSearching = false;
        private string currentSearchKeyword = "";

        public frmNhanVien()
        {
            InitializeComponent();
            InitializeListView();
            LoadData();

            string fillComboSql = "SELECT TenDangNhap FROM TaiKhoan";
            DatabaseLayer.FillCombo(fillComboSql, cboTaiKhoan, "TenDangNhap", "TenDangNhap");
            cboTaiKhoan.SelectedItem = null;
        }

        private void InitializeListView()
        {
            listViewNV.FullRowSelect = true;
            listViewNV.MultiSelect = false;
            listViewNV.UseCompatibleStateImageBehavior = false;
            listViewNV.View = View.Details;

            listViewNV.Columns.Add("MaNV", "Mã nhân viên");
            listViewNV.Columns.Add("TenNV", "Tên nhân viên");
            listViewNV.Columns.Add("TenDangNhap", "Tài khoản");
            listViewNV.Columns.Add("NgaySinh", "Ngày sinh");
            listViewNV.Columns.Add("GioiTinh", "Giới tính");
            listViewNV.Columns.Add("DiaChi", "Địa chỉ");
            listViewNV.Columns.Add("SDT", "Số điện thoại");
            listViewNV.Columns.Add("Luong", "Lương");
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            txtMaNV.Enabled = false;

            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            btnLuu.Enabled = false;
            btnHuy.Enabled = false;

            txtTimKiem.Text = "Nhập từ khóa tìm kiếm";
            txtTimKiem.ForeColor = Color.Gray;
        }

        private void AdjustColumnWidth()
        {
            int totalWidth = listViewNV.ClientSize.Width;
            double col1Percentage = 0.1;
            double col2Percentage = 0.2;
            double col3Percentage = 0.1;
            double col4Percentage = 0.1;
            double col5Percentage = 0.1;
            double col6Percentage = 0.2;
            double col7Percentage = 0.1;
            double col8Percentage = 0.1;

            int col1Width = (int)(totalWidth * col1Percentage);
            int col2Width = (int)(totalWidth * col2Percentage);
            int col3Width = (int)(totalWidth * col3Percentage);
            int col4Width = (int)(totalWidth * col4Percentage);
            int col5Width = (int)(totalWidth * col5Percentage);
            int col6Width = (int)(totalWidth * col6Percentage);
            int col7Width = (int)(totalWidth * col7Percentage);
            int col8Width = (int)(totalWidth * col8Percentage);

            listViewNV.Columns[0].Width = col1Width;
            listViewNV.Columns[1].Width = col2Width;
            listViewNV.Columns[2].Width = col3Width;
            listViewNV.Columns[3].Width = col4Width;
            listViewNV.Columns[4].Width = col5Width;
            listViewNV.Columns[5].Width = col6Width;
            listViewNV.Columns[6].Width = col7Width;
            listViewNV.Columns[7].Width = col8Width;
        }

        private void LoadData()
        {
            try
            {
                if (isSearching)
                    tblNhanVien = NhanVienDAL.GetNhanVienBySearch(currentSearchKeyword);
                else
                    tblNhanVien = NhanVienDAL.GetAllNhanVien();

                LoadListView();
            }
            catch (Exception ex)
            {
                Functions.HandleError("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void LoadListView()
        {
            ClearListView();

            foreach (DataRow row in tblNhanVien.Rows)
            {
                ListViewItem item = new ListViewItem(row["MaNV"].ToString());
                item.SubItems.Add(row["TenNV"].ToString());
                item.SubItems.Add(row["TenDangNhap"].ToString());

                DateTime ngaySinh;
                if (DateTime.TryParse(row["NgaySinh"].ToString(), out ngaySinh))
                {
                    string ngaySinhFormatted = ngaySinh.ToString("dd/MM/yyyy");

                    item.SubItems.Add(ngaySinhFormatted);
                }
                else
                {
                    item.SubItems.Add("");
                }

                string gioiTinh = "";
                if (row["GioiTinh"] != null && row["GioiTinh"] != DBNull.Value)
                {
                    bool gioiTinhValue = Convert.ToBoolean(row["GioiTinh"]);
                    gioiTinh = gioiTinhValue ? "Nam" : "Nữ";
                }
                else
                {
                    gioiTinh = "";
                }

                item.SubItems.Add(gioiTinh);

                item.SubItems.Add(row["DiaChi"].ToString());
                item.SubItems.Add(row["SDT"].ToString());
                item.SubItems.Add(row["Luong"].ToString());

                listViewNV.Items.Add(item);
            }

            AdjustColumnWidth();
        }

        private void ClearListView()
        {
            listViewNV.Items.Clear();
        }

        private void listViewNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                Functions.HandleInfo("Đang ở chế độ thêm mới");
                txtMaNV.Focus();
                return;
            }

            if (tblNhanVien.Rows.Count == 0)
            {
                Functions.HandleInfo("Không có dữ liệu");
                return;
            }

            if (listViewNV.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewNV.SelectedItems[0];
                txtMaNV.Text = selectedItem.SubItems[0].Text;
                txtTenNV.Text = selectedItem.SubItems[1].Text;

                string taiKhoanText = selectedItem.SubItems[2].Text;
                cboTaiKhoan.SelectedValue = taiKhoanText;

                string ngaySinhStr = selectedItem.SubItems[3].Text;
                DateTime ngaySinh;
                if (DateTime.TryParse(ngaySinhStr, out ngaySinh))
                {
                    txtNgaySinh.Text = ngaySinh.ToString("dd/MM/yyyy");
                }
                else
                {
                    txtNgaySinh.Text = "";
                }

                if (selectedItem.SubItems[4].Text == "Nam")
                {
                    rdoNam.Checked = true;
                    rdoNu.Checked = false;
                }
                else if (selectedItem.SubItems[4].Text == "Nữ")
                {
                    rdoNam.Checked = false;
                    rdoNu.Checked = true;
                }

                txtDiaChi.Text = selectedItem.SubItems[5].Text;
                txtSDT.Text = selectedItem.SubItems[6].Text;
                txtLuong.Text = selectedItem.SubItems[7].Text;

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnHuy.Enabled = true;
            }
            else
            {
                ResetValues();

                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnHuy.Enabled = false;
            }
        }

        private void ResetValues()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            cboTaiKhoan.SelectedItem = null;
            rdoNam.Checked = false;
            rdoNu.Checked = false;
            txtNgaySinh.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtLuong.Text = "";
        }

        private bool ValidateInput()
        {
            /*
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                Functions.HandleWarning("Bạn phải nhập mã nhân viên");
                txtMaNV.Focus();
                return false;
            }
            */

            if (string.IsNullOrWhiteSpace(txtTenNV.Text))
            {
                Functions.HandleWarning("Bạn phải nhập tên nhân viên");
                txtTenNV.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNgaySinh.Text))
            {
                Functions.HandleWarning("Bạn phải nhập ngày sinh");
                txtNgaySinh.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                Functions.HandleWarning("Bạn phải nhập địa chỉ");
                txtDiaChi.Focus();
                return false;
            }

            if (rdoNam.Checked == false && rdoNu.Checked == false)
            {
                Functions.HandleWarning("Bạn phải chọn giới tính");
                return false;
            }

            if (cboTaiKhoan.SelectedItem == null)
            {
                Functions.HandleWarning("Bạn phải chọn tài khoản sử dụng");
                cboTaiKhoan.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                Functions.HandleWarning("Bạn phải nhập số điện thoại");
                txtSDT.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLuong.Text))
            {
                Functions.HandleWarning("Bạn phải nhập lương");
                txtLuong.Focus();
                return false;
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = true;

            btnLuu.Enabled = true;
            ResetValues();
            txtTenNV.Focus();

            string newMaNV = NhanVienDAL.InsertEmptyNhanVien();
            txtMaNV.Text = newMaNV;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (listViewNV.SelectedItems.Count == 0)
            {
                Functions.HandleInfo("Bạn chưa chọn bản ghi nào để sửa");
                return;
            }

            if (ValidateInput())
            {
                string maNV = txtMaNV.Text.Trim();
                string tenNV = txtTenNV.Text.Trim();

                string account = cboTaiKhoan.SelectedValue.ToString();

                DateTime ngaySinh;
                if (!DateTime.TryParse(txtNgaySinh.Text, out ngaySinh))
                {
                    Functions.HandleWarning("Ngày sinh không hợp lệ");
                    txtNgaySinh.Focus();
                    return;
                }

                bool gioiTinh = rdoNam.Checked;

                string diaChi = txtDiaChi.Text.Trim();
                string SDT = txtSDT.Text.Trim().Replace(" ", "");
                int luong = Convert.ToInt32(txtLuong.Text.Trim());

                try
                {
                    NhanVienDAL.UpdateNhanVien(maNV, tenNV, account, ngaySinh, gioiTinh, diaChi, SDT, luong);
                    Functions.HandleInfo("Cập nhật nhân viên thành công");
                    LoadData();
                    ResetValues();
                }
                catch (Exception ex)
                {
                    Functions.HandleError("Lỗi khi cập nhật nhân viên: " + ex.Message);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text.Trim();

            if (!string.IsNullOrEmpty(maNV))
            {
                if (Functions.HandleQuestion("Bạn có muốn xóa không?"))
                {
                    try
                    {
                        NhanVienDAL.DeleteNhanVien(maNV);
                        Functions.HandleInfo("Xóa nhân viên thành công");
                        LoadData();
                        ResetValues();

                        btnSua.Enabled = false;
                        btnXoa.Enabled = false;
                        btnHuy.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        Functions.HandleError("Lỗi khi xóa nhân viên: " + ex.Message);
                    }
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                string maNV = txtMaNV.Text.Trim();
                string tenNV = txtTenNV.Text.Trim();

                string account = cboTaiKhoan.SelectedValue.ToString();

                DateTime ngaySinh;
                if (!DateTime.TryParse(txtNgaySinh.Text, out ngaySinh))
                {
                    Functions.HandleWarning("Ngày sinh không hợp lệ");
                    txtNgaySinh.Focus();
                    return;
                }

                bool gioiTinh = rdoNam.Checked;

                string diaChi = txtDiaChi.Text.Trim();
                string SDT = txtSDT.Text.Trim().Replace(" ", "");
                int luong = Convert.ToInt32(txtLuong.Text.Trim());

                try
                {
                    NhanVienDAL.UpdateNhanVien(maNV, tenNV, account, ngaySinh, gioiTinh, diaChi, SDT, luong);
                    Functions.HandleInfo("Thêm nhân viên thành công");
                    LoadData();
                    ResetValues();

                    btnThem.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnHuy.Enabled = false;
                    btnLuu.Enabled = false;
                    txtMaNV.Enabled = false;
                }
                catch (Exception ex)
                {
                    Functions.HandleError("Lỗi khi thêm nhân viên: " + ex.Message);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text.Trim();

            ResetValues();

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            txtMaNV.Enabled = false;

            txtTimKiem.Text = "";
            isSearching = false;

            if (!string.IsNullOrEmpty(maNV))
            {
                NhanVienDAL.DeleteEmptyNhanVien(maNV);
            }
            LoadData();
        }

        private void PerformSearch()
        {
            currentSearchKeyword = txtTimKiem.Text.Trim();
            isSearching = true;

            LoadData();

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

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtLuong_KeyPress(object sender, KeyPressEventArgs e)
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