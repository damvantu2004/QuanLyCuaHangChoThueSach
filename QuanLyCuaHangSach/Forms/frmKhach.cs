using BAEK_PERCENT.Class;
using BAEK_PERCENT.DAL;
using MaterialSkin.Controls;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BAEK_PERCENT.Forms
{
    public partial class frmKhach : MaterialForm
    {
        private DataTable tblKhachHang;

        private bool isSearching = false;
        private string currentSearchKeyword = "";

        public frmKhach()
        {
            InitializeComponent();
            InitializeListView();
            LoadData();
        }

        private void InitializeListView()
        {
            listViewKhach.FullRowSelect = true;
            listViewKhach.MultiSelect = false;
            listViewKhach.UseCompatibleStateImageBehavior = false;
            listViewKhach.View = View.Details;

            listViewKhach.Columns.Add("MaKH", "Mã khách hàng");
            listViewKhach.Columns.Add("TenKH", "Tên khách hàng");
            listViewKhach.Columns.Add("NgaySinh", "Ngày sinh");
            listViewKhach.Columns.Add("GioiTinh", "Giới tính");
            listViewKhach.Columns.Add("DiaChi", "Địa chỉ");
            listViewKhach.Columns.Add("SDT", "Số điện thoại");
        }

        private void frmKhach_Load(object sender, EventArgs e)
        {
            txtMaKH.Enabled = false;

            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            btnLuu.Enabled = false;
            btnHuy.Enabled = false;

            txtTimKiem.Text = "Nhập từ khóa tìm kiếm";
            txtTimKiem.ForeColor = Color.Gray;
        }

        private void AdjustColumnWidth()
        {
            int totalWidth = listViewKhach.ClientSize.Width;
            double col1Percentage = 0.1;
            double col2Percentage = 0.2;
            double col3Percentage = 0.15;
            double col4Percentage = 0.1;
            double col5Percentage = 0.3;
            double col6Percentage = 0.15;

            int col1Width = (int)(totalWidth * col1Percentage);
            int col2Width = (int)(totalWidth * col2Percentage);
            int col3Width = (int)(totalWidth * col3Percentage);
            int col4Width = (int)(totalWidth * col4Percentage);
            int col5Width = (int)(totalWidth * col5Percentage);
            int col6Width = (int)(totalWidth * col6Percentage);

            listViewKhach.Columns[0].Width = col1Width;
            listViewKhach.Columns[1].Width = col2Width;
            listViewKhach.Columns[2].Width = col3Width;
            listViewKhach.Columns[3].Width = col4Width;
            listViewKhach.Columns[4].Width = col5Width;
            listViewKhach.Columns[5].Width = col6Width;
        }

        private void LoadData()
        {
            try
            {
                if (isSearching)
                    tblKhachHang = KhachHangDAL.GetKhachHangBySearch(currentSearchKeyword);
                else
                    tblKhachHang = KhachHangDAL.GetAllKhachHang();

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

            foreach (DataRow row in tblKhachHang.Rows)
            {
                ListViewItem item = new ListViewItem(row["MaKH"].ToString());
                item.SubItems.Add(row["TenKH"].ToString());

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
                listViewKhach.Items.Add(item);
            }

            AdjustColumnWidth();
        }

        private void ClearListView()
        {
            listViewKhach.Items.Clear();
        }

        private void listViewKhach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                Functions.HandleInfo("Đang ở chế độ thêm mới");
                txtMaKH.Focus();
                return;
            }

            if (tblKhachHang.Rows.Count == 0)
            {
                Functions.HandleInfo("Không có dữ liệu");
                return;
            }

            if (listViewKhach.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewKhach.SelectedItems[0];
                txtMaKH.Text = selectedItem.SubItems[0].Text;
                txtTenKH.Text = selectedItem.SubItems[1].Text;

                string ngaySinhStr = selectedItem.SubItems[2].Text;
                DateTime ngaySinh;
                if (DateTime.TryParse(ngaySinhStr, out ngaySinh))
                {
                    txtNgaySinh.Text = ngaySinh.ToString("dd/MM/yyyy");
                }
                else
                {
                    txtNgaySinh.Text = "";
                }

                if (selectedItem.SubItems[3].Text == "Nam")
                {
                    rdoNam.Checked = true;
                    rdoNu.Checked = false;
                }
                else if (selectedItem.SubItems[3].Text == "Nữ")
                {
                    rdoNam.Checked = false;
                    rdoNu.Checked = true;
                }

                txtDiaChi.Text = selectedItem.SubItems[4].Text;
                txtSDT.Text = selectedItem.SubItems[5].Text;

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
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            rdoNam.Checked = false;
            rdoNu.Checked = false;
            txtNgaySinh.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
        }

        private bool ValidateInput()
        {
            /*
            if (string.IsNullOrWhiteSpace(txtMaKH.Text))
            {
                Functions.HandleWarning("Bạn phải nhập mã khách hàng");
                txtMaKH.Focus();
                return false;
            }
            */

            if (string.IsNullOrWhiteSpace(txtTenKH.Text))
            {
                Functions.HandleWarning("Bạn phải nhập tên khách hàng");
                txtTenKH.Focus();
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

            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                Functions.HandleWarning("Bạn phải nhập số điện thoại");
                txtSDT.Focus();
                return false;
            }

            if (rdoNam.Checked == false && rdoNu.Checked == false)
            {
                Functions.HandleWarning("Bạn phải chọn giới tính");
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
            txtTenKH.Focus();

            string newMaKH = KhachHangDAL.InsertEmptyKhachHang();
            txtMaKH.Text = newMaKH;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (listViewKhach.SelectedItems.Count == 0)
            {
                Functions.HandleInfo("Bạn chưa chọn bản ghi nào để sửa");
                return;
            }

            if (ValidateInput())
            {
                string maKH = txtMaKH.Text.Trim();
                string tenKH = txtTenKH.Text.Trim();

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

                try
                {
                    KhachHangDAL.UpdateKhachHang(maKH, tenKH, ngaySinh, gioiTinh, diaChi, SDT);
                    Functions.HandleInfo("Cập nhật khách hàng thành công");
                    LoadData();
                    ResetValues();
                }
                catch (Exception ex)
                {
                    Functions.HandleError("Lỗi khi cập nhật khách hàng: " + ex.Message);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maKH = txtMaKH.Text.Trim();

            if (!string.IsNullOrEmpty(maKH))
            {
                if (Functions.HandleQuestion("Bạn có muốn xóa không?"))
                {
                    try
                    {
                        KhachHangDAL.DeleteKhachHang(maKH);
                        Functions.HandleInfo("Xóa khách hàng thành công");
                        LoadData();
                        ResetValues();

                        btnSua.Enabled = false;
                        btnXoa.Enabled = false;
                        btnHuy.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        Functions.HandleError("Lỗi khi xóa khách hàng: " + ex.Message);
                    }
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                string maKH = txtMaKH.Text.Trim();
                string tenKH = txtTenKH.Text.Trim();

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

                try
                {
                    KhachHangDAL.UpdateKhachHang(maKH, tenKH, ngaySinh, gioiTinh, diaChi, SDT);
                    Functions.HandleInfo("Thêm khách hàng thành công");
                    LoadData();
                    ResetValues();

                    btnThem.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnHuy.Enabled = false;
                    btnLuu.Enabled = false;
                    txtMaKH.Enabled = false;
                }
                catch (Exception ex)
                {
                    Functions.HandleError("Lỗi khi thêm khách hàng: " + ex.Message);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            string maKH = txtMaKH.Text.Trim();

            ResetValues();

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            txtMaKH.Enabled = false;

            txtTimKiem.Text = "";
            isSearching = false;

            if (!string.IsNullOrEmpty(maKH))
            {
                KhachHangDAL.DeleteEmptyKhachHang(maKH);
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
