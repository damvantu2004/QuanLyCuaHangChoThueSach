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
    public partial class frmSach : MaterialForm
    {
        private System.Data.DataTable tblSach;

        private bool isSearching = false;
        private string currentSearchOption = "";
        private string currentSearchKeyword = "";

        public frmSach()
        {
            InitializeComponent();
            InitializeListView();
            LoadData();

            string fillComboLoai = "SELECT * FROM LoaiSach";
            DatabaseLayer.FillCombo(fillComboLoai, cboMaLoai, "MaLoai", "TenLoai");
            cboMaLoai.SelectedItem = null;

            string fillComboTG = "SELECT * FROM TacGia";
            DatabaseLayer.FillCombo(fillComboTG, cboMaTG, "MaTG", "TenTG");
            cboMaTG.SelectedItem = null;

            string fillComboLV = "SELECT * FROM LinhVuc";
            DatabaseLayer.FillCombo(fillComboLV, cboMaLV, "MaLV", "TenLV");
            cboMaLV.SelectedItem = null;

            string fillComboNN = "SELECT * FROM NgonNgu";
            DatabaseLayer.FillCombo(fillComboNN, cboMaNN, "MaNN", "TenNN");
            cboMaNN.SelectedItem = null;

            cboTimKiem.Items.Add("Mã sách");
            cboTimKiem.Items.Add("Tên sách");
            cboTimKiem.Items.Add("Loại sách");
            cboTimKiem.Items.Add("Lĩnh vực");
            cboTimKiem.Items.Add("Tác giả");
            cboTimKiem.Items.Add("Ngôn ngữ");

            cboSoLuong.Items.Add("Mặc định");
            cboSoLuong.Items.Add("Tăng dần");
            cboSoLuong.Items.Add("Giảm dần");

            cboSoLuong.SelectedItem = "Mặc định";

            cboGiaThue.Items.Add("Mặc định");
            cboGiaThue.Items.Add("Tăng dần");
            cboGiaThue.Items.Add("Giảm dần");

            cboGiaThue.SelectedItem = "Mặc định";

            chkSoLuong.Checked = false;
            chkGiaThue.Checked = false;

            cboSoLuong.Enabled = false;
            cboGiaThue.Enabled = false;

        }

        private void InitializeListView()
        {
            listViewSach.FullRowSelect = true;
            listViewSach.MultiSelect = false;
            listViewSach.UseCompatibleStateImageBehavior = false;
            listViewSach.View = View.Details;

            listViewSach.Columns.Add("MaSach", "Mã sách");
            listViewSach.Columns.Add("TenSach", "Tên sách");
            listViewSach.Columns.Add("MaLoai", "Loại sách");
            listViewSach.Columns.Add("MaLV", "Lĩnh vực");
            listViewSach.Columns.Add("MaTG", "Tác giả");
            listViewSach.Columns.Add("MaNN", "Ngôn ngữ");

            listViewSach.Columns.Add("SoTrang", "Số trang");
            listViewSach.Columns.Add("GiaSach", "Giá sách");
            listViewSach.Columns.Add("DonGiaThue", "Đơn giá thuê");
            listViewSach.Columns.Add("SoLuong", "Số lượng");
            listViewSach.Columns.Add("GhiChu", "Ghi chú");
        }

        private void frmSach_Load(object sender, EventArgs e)
        {
            txtMaSach.Enabled = false;
            txtAnh.Enabled = false;

            btnAnh.Enabled = false;

            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            btnLuu.Enabled = false;
            btnHuy.Enabled = false;

            txtTimKiem.Text = "Nhập từ khóa tìm kiếm";
            txtTimKiem.ForeColor = Color.Gray;
        }

        private void AdjustColumnWidth()
        {
            int totalWidth = listViewSach.ClientSize.Width;
            double col1Percentage = 0.1;
            double col2Percentage = 0.2;
            double col3Percentage = 0.05;
            double col4Percentage = 0.05;
            double col5Percentage = 0.05;
            double col6Percentage = 0.05;
            double col7Percentage = 0.05;
            double col8Percentage = 0.1;
            double col9Percentage = 0.1;
            double col10Percentage = 0.05;
            double col12Percentage = 0.2;

            int col1Width = (int)(totalWidth * col1Percentage);
            int col2Width = (int)(totalWidth * col2Percentage);
            int col3Width = (int)(totalWidth * col3Percentage);
            int col4Width = (int)(totalWidth * col4Percentage);
            int col5Width = (int)(totalWidth * col5Percentage);
            int col6Width = (int)(totalWidth * col6Percentage);
            int col7Width = (int)(totalWidth * col7Percentage);
            int col8Width = (int)(totalWidth * col8Percentage);
            int col9Width = (int)(totalWidth * col9Percentage);
            int col10Width = (int)(totalWidth * col10Percentage);
            int col12Width = (int)(totalWidth * col12Percentage);


            listViewSach.Columns[0].Width = col1Width;
            listViewSach.Columns[1].Width = col2Width;
            listViewSach.Columns[2].Width = col3Width;
            listViewSach.Columns[3].Width = col4Width;
            listViewSach.Columns[4].Width = col5Width;
            listViewSach.Columns[5].Width = col6Width;
            listViewSach.Columns[6].Width = col7Width;
            listViewSach.Columns[7].Width = col8Width;
            listViewSach.Columns[8].Width = col9Width;
            listViewSach.Columns[9].Width = col10Width;
            listViewSach.Columns[10].Width = col12Width;
        }

        private void LoadData()
        {
            try
            {
                if (isSearching)
                    tblSach = SachDAL.GetSachBySearch(currentSearchOption, currentSearchKeyword);
                else
                    tblSach = SachDAL.GetAllSach();

                // Sort the data based on checkboxes
                DataView dv = tblSach.DefaultView;

                string sortExpression = "";
                if (chkSoLuong.Checked && cboSoLuong.SelectedItem.ToString() != "Mặc định")
                {
                    sortExpression += "SoLuong " + (cboSoLuong.Text == "Tăng dần" ? "ASC" : "DESC");
                }

                if (chkGiaThue.Checked && cboGiaThue.SelectedItem.ToString() != "Mặc định")
                {
                    if (!string.IsNullOrEmpty(sortExpression))
                    {
                        sortExpression += ", ";
                    }
                    sortExpression += "DonGiaThue " + (cboGiaThue.Text == "Tăng dần" ? "ASC" : "DESC");
                }

                if (!string.IsNullOrEmpty(sortExpression))
                {
                    dv.Sort = sortExpression;
                }

                tblSach = dv.ToTable();
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

            foreach (DataRow row in tblSach.Rows)
            {
                ListViewItem item = new ListViewItem(row["MaSach"].ToString());
                item.SubItems.Add(row["TenSach"].ToString());
                item.SubItems.Add(row["MaLoai"].ToString());
                item.SubItems.Add(row["MaLV"].ToString());
                item.SubItems.Add(row["MaTG"].ToString());
                item.SubItems.Add(row["MaNN"].ToString());

                item.SubItems.Add(row["SoTrang"].ToString());
                item.SubItems.Add(row["GiaSach"].ToString());
                item.SubItems.Add(row["DonGiaThue"].ToString());

                item.SubItems.Add(row["SoLuong"].ToString());
                item.Tag = row["Anh"].ToString();
                item.SubItems.Add(row["GhiChu"].ToString());

                listViewSach.Items.Add(item);
            }

            AdjustColumnWidth();
        }

        private void ClearListView()
        {
            listViewSach.Items.Clear();
        }

        private void listViewSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                Functions.HandleInfo("Đang ở chế độ thêm mới");
                txtMaSach.Focus();
                return;
            }

            if (tblSach.Rows.Count == 0)
            {
                Functions.HandleInfo("Không có dữ liệu");
                return;
            }

            if (listViewSach.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewSach.SelectedItems[0];
                txtMaSach.Text = selectedItem.SubItems[0].Text;
                txtTenSach.Text = selectedItem.SubItems[1].Text;

                cboMaLoai.Text = DatabaseLayer.GetFieldValues("SELECT TenLoai FROM LoaiSach WHERE MaLoai = N'" + selectedItem.SubItems[2].Text + "';");
                cboMaLV.Text = DatabaseLayer.GetFieldValues("SELECT TenLV FROM LinhVuc WHERE MaLV = N'" + selectedItem.SubItems[3].Text + "';");
                cboMaTG.Text = DatabaseLayer.GetFieldValues("SELECT TenTG FROM TacGia WHERE MaTG = N'" + selectedItem.SubItems[4].Text + "';");
                cboMaNN.Text = DatabaseLayer.GetFieldValues("SELECT TenNN FROM NgonNgu WHERE MaNN = N'" + selectedItem.SubItems[5].Text + "';");

                txtSoTrang.Text = selectedItem.SubItems[6].Text;
                txtGia.Text = selectedItem.SubItems[7].Text;
                txtGiaThue.Text = selectedItem.SubItems[8].Text;

                txtSoLuong.Text = selectedItem.SubItems[9].Text;
                txtAnh.Text = selectedItem.Tag as string;

                if (!string.IsNullOrEmpty(txtAnh.Text))
                {
                    picAnh.Image = Image.FromFile(txtAnh.Text);
                }
                else
                {
                    picAnh.Image = null;
                }

                txtGhiChu.Text = selectedItem.SubItems[10].Text;

                btnAnh.Enabled = true;

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnHuy.Enabled = true;
            }
            else
            {
                ResetValues();

                btnAnh.Enabled = false;

                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnHuy.Enabled = false;
            }
        }

        private void ResetValues()
        {
            txtMaSach.Text = "";
            txtTenSach.Text = "";

            cboMaLoai.SelectedItem = null;
            cboMaLV.SelectedItem = null;
            cboMaTG.SelectedItem = null;
            cboMaNN.SelectedItem = null;

            txtSoTrang.Text = "";
            txtGia.Text = "";
            txtGiaThue.Text = "";
            txtSoLuong.Text = "";
            txtAnh.Text = "";
            picAnh.Image = null;
            txtGhiChu.Text = "";
        }

        private bool ValidateInput()
        {
            /*
            if (string.IsNullOrWhiteSpace(txtMaSach.Text))
            {
                Functions.HandleWarning("Bạn phải nhập mã sách");
                txtMaSach.Focus();
                return false;
            }
            */

            if (string.IsNullOrWhiteSpace(txtTenSach.Text))
            {
                Functions.HandleWarning("Bạn phải nhập tên sách");
                txtTenSach.Focus();
                return false;
            }

            if (cboMaLoai.SelectedItem == null)
            {
                Functions.HandleWarning("Bạn phải chọn loại sách");
                cboMaLoai.Focus();
                return false;
            }

            if (cboMaLV.SelectedItem == null)
            {
                Functions.HandleWarning("Bạn phải chọn lĩnh vực");
                cboMaLV.Focus();
                return false;
            }

            if (cboMaTG.SelectedItem == null)
            {
                Functions.HandleWarning("Bạn phải chọn tác giả");
                cboMaTG.Focus();
                return false;
            }

            if (cboMaNN.SelectedItem == null)
            {
                Functions.HandleWarning("Bạn phải chọn ngôn ngữ");
                cboMaNN.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSoLuong.Text))
            {
                Functions.HandleWarning("Bạn phải nhập số lượng");
                txtSoLuong.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtGia.Text))
            {
                Functions.HandleWarning("Bạn phải nhập giá");
                txtGia.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtGiaThue.Text))
            {
                Functions.HandleWarning("Bạn phải nhập giá thuê");
                txtGiaThue.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSoTrang.Text))
            {
                Functions.HandleWarning("Bạn phải nhập số trang");
                txtSoTrang.Focus();
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

            btnAnh.Enabled = true;

            btnLuu.Enabled = true;
            ResetValues();
            txtTenSach.Focus();

            string newMaSach = SachDAL.InsertEmptySach();
            txtMaSach.Text = newMaSach;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (listViewSach.SelectedItems.Count == 0)
            {
                Functions.HandleInfo("Bạn chưa chọn bản ghi nào để sửa");
                return;
            }

            if (ValidateInput())
            {
                string maNV = txtMaSach.Text.Trim();
                string tenNV = txtTenSach.Text.Trim();

                string maLoai = cboMaLoai.SelectedValue.ToString();
                string maLV = cboMaLV.SelectedValue.ToString();
                string maTG = cboMaTG.SelectedValue.ToString();
                string maNN = cboMaNN.SelectedValue.ToString();

                int soLuong = Convert.ToInt32(txtSoLuong.Text.Trim());
                int gia = Convert.ToInt32(txtGia.Text.Trim());
                int giaThue = Convert.ToInt32(txtGiaThue.Text.Trim());
                int soTrang = Convert.ToInt32(txtSoTrang.Text.Trim());

                string anh = txtAnh.Text.Trim();
                string ghiChu = txtGhiChu.Text.Trim();

                try
                {
                    SachDAL.UpdateSach(maNV, tenNV, maLoai, maLV, maTG, maNN, soTrang, gia, giaThue, soLuong, anh, ghiChu);
                    Functions.HandleInfo("Cập nhật sách thành công");
                    LoadData();
                    ResetValues();
                }
                catch (Exception ex)
                {
                    Functions.HandleError("Lỗi khi cập nhật sách: " + ex.Message);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maSach = txtMaSach.Text.Trim();

            if (!string.IsNullOrEmpty(maSach))
            {
                if (Functions.HandleQuestion("Bạn có muốn xóa không?"))
                {
                    try
                    {
                        SachDAL.DeleteSach(maSach);
                        Functions.HandleInfo("Xóa sách thành công");
                        LoadData();
                        ResetValues();

                        btnSua.Enabled = false;
                        btnXoa.Enabled = false;
                        btnHuy.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        Functions.HandleError("Lỗi khi xóa sách: " + ex.Message);
                    }
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                string maNV = txtMaSach.Text.Trim();
                string tenNV = txtTenSach.Text.Trim();

                string maLoai = cboMaLoai.SelectedValue.ToString();
                string maLV = cboMaLV.SelectedValue.ToString();
                string maTG = cboMaTG.SelectedValue.ToString();
                string maNN = cboMaNN.SelectedValue.ToString();

                int soLuong = Convert.ToInt32(txtSoLuong.Text.Trim());
                int gia = Convert.ToInt32(txtGia.Text.Trim());
                int giaThue = Convert.ToInt32(txtGiaThue.Text.Trim());
                int soTrang = Convert.ToInt32(txtSoTrang.Text.Trim());

                string anh = txtAnh.Text.Trim();
                string ghiChu = txtGhiChu.Text.Trim();

                try
                {
                    SachDAL.UpdateSach(maNV, tenNV, maLoai, maLV, maTG, maNN, soTrang, gia, giaThue, soLuong, anh, ghiChu);
                    Functions.HandleInfo("Thêm sách thành công");
                    LoadData();
                    ResetValues();

                    btnAnh.Enabled = false;
                    btnThem.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnHuy.Enabled = false;
                    btnLuu.Enabled = false;
                    txtMaSach.Enabled = false;
                }
                catch (Exception ex)
                {
                    Functions.HandleError("Lỗi khi thêm sách: " + ex.Message);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            string maSach = txtMaSach.Text.Trim();

            ResetValues();

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;

            btnAnh.Enabled = false;

            txtMaSach.Enabled = false;

            txtTimKiem.Text = "";
            isSearching = false;

            if (!string.IsNullOrEmpty(maSach))
            {
                SachDAL.DeleteEmptySach(maSach);
            }
            LoadData();
        }

        private void btnAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Image Files (*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png|All Files (*.*)|*.*";
            dlgOpen.InitialDirectory = "E:\\";
            dlgOpen.FilterIndex = 1;
            dlgOpen.Title = "Chọn hình ảnh để hiển thị";

            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = Image.FromFile(dlgOpen.FileName);
                txtAnh.Text = dlgOpen.FileName;
            }
        }

        private void PerformSearch()
        {
            currentSearchOption = cboTimKiem.Text;
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

        private void txtGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtGiaThue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSoTrang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void chkSoLuong_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSoLuong.Checked)
            {
                cboSoLuong.Enabled = true;
            }
            else
            {
                cboSoLuong.Enabled = false;
            }

            LoadData();
        }

        private void chkGiaThue_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGiaThue.Checked)
            {
                cboGiaThue.Enabled = true;
            }
            else
            {
                cboGiaThue.Enabled = false;
            }

            LoadData();
        }

        private void cboSoLuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkSoLuong.Checked)
            {
                LoadData();
            }
        }

        private void cboGiaThue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkGiaThue.Checked)
            {
                LoadData();
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
