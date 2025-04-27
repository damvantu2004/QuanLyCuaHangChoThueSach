using BAEK_PERCENT.Class;
using BAEK_PERCENT.DAL;
using MaterialSkin.Controls;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BAEK_PERCENT.Forms
{
    public partial class frmTaiKhoan : MaterialForm
    {
        private DataTable tblTaiKhoan;

        private bool isSearching = false;
        private string currentSearchKeyword = "";

        public frmTaiKhoan()
        {
            InitializeComponent();
            InitializeListView();
            LoadData();
        }

        private void InitializeListView()
        {
            listViewTK.FullRowSelect = true;
            listViewTK.MultiSelect = false;
            listViewTK.UseCompatibleStateImageBehavior = false;
            listViewTK.View = View.Details;

            listViewTK.Columns.Add("TenDangNhap", "Tên đăng nhập");
            listViewTK.Columns.Add("Quyen", "Quyền sử dụng");
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            txtUsername.Enabled = false;

            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            btnLuu.Enabled = false;
            btnHuy.Enabled = false;

            cboPriv.Items.Add("Quản lý");
            cboPriv.Items.Add("Nhân viên");

            cboPriv.SelectedItem = null;
            cboPriv.Text = "";

            txtTimKiem.Text = "Nhập từ khóa tìm kiếm";
            txtTimKiem.ForeColor = Color.Gray;
        }

        private void AdjustColumnWidth()
        {
            int totalWidth = listViewTK.ClientSize.Width;
            double col1Percentage = 0.5;
            double col2Percentage = 0.5;
            int col1Width = (int)(totalWidth * col1Percentage);
            int col2Width = (int)(totalWidth * col2Percentage);

            listViewTK.Columns[0].Width = col1Width;
            listViewTK.Columns[1].Width = col2Width;
        }

        private void LoadData()
        {
            try
            {
                if (isSearching)
                    tblTaiKhoan = TaiKhoanDAL.GetTaiKhoanBySearch(currentSearchKeyword);
                else
                    tblTaiKhoan = TaiKhoanDAL.GetAllTaiKhoan();

                LoadListView();
            }
            catch (Exception ex)
            {
                Functions.HandleError("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        // private Dictionary<string, string> passwordMap = new Dictionary<string, string>();

        private void LoadListView()
        {
            ClearListView();

            foreach (DataRow row in tblTaiKhoan.Rows)
            {
                ListViewItem item = new ListViewItem(row["TenDangNhap"].ToString());

                // Gán giá trị mật khẩu vào thuộc tính Tag của ListViewItem
                item.Tag = row["MatKhau"].ToString();

                item.SubItems.Add(row["Quyen"].ToString());
                listViewTK.Items.Add(item);
            }

            AdjustColumnWidth();
        }
        private void ClearListView()
        {
            listViewTK.Items.Clear();
        }

        private void listViewTK_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                Functions.HandleInfo("Đang ở chế độ thêm mới");
                txtUsername.Focus();
                return;
            }

            if (tblTaiKhoan.Rows.Count == 0)
            {
                Functions.HandleInfo("Không có dữ liệu");
                return;
            }

            if (listViewTK.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewTK.SelectedItems[0];
                txtUsername.Text = selectedItem.SubItems[0].Text;

                string password = selectedItem.Tag as string;
                txtPassword.Text = password;

                string quyenValue = selectedItem.SubItems[1].Text;

                if (quyenValue == "1")
                {
                    cboPriv.SelectedItem = "Quản lý";
                }
                else if (quyenValue == "0")
                {
                    cboPriv.SelectedItem = "Nhân viên";
                }

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnHuy.Enabled = true;
            }
            else
            {
                ResetValues();
            }
        }

        private void ResetValues()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            cboPriv.SelectedItem = null;
            cboPriv.Text = "";
        }

        private bool ValidateInput()
        {
            /*
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                Functions.HandleWarning("Bạn phải nhập tên đăng nhập");
                txtUsername.Focus();
                return false;
            }
            */

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                Functions.HandleWarning("Bạn phải nhập mật khẩu");
                txtPassword.Focus();
                return false;
            }

            if (cboPriv.SelectedItem == null)
            {
                Functions.HandleWarning("Bạn phải chọn quyền sử dụng");
                cboPriv.Focus();
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
            txtUsername.Enabled = true;
            txtUsername.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (listViewTK.SelectedItems.Count == 0)
            {
                Functions.HandleInfo("Bạn chưa chọn bản ghi nào để sửa");
                return;
            }

            if (ValidateInput())
            {
                string username = txtUsername.Text.Trim();
                string password = Functions.ComputeSha256Hash(txtPassword.Text.Trim());
                string privStr = cboPriv.SelectedItem.ToString();

                int priv = -1;

                if (privStr == "Quản lý")
                {
                    priv = 1;
                }
                else if (privStr == "Nhân viên")
                {
                    priv = 0;
                }

                try
                {
                    TaiKhoanDAL.UpdateTaiKhoan(username, password, priv);
                    Functions.HandleInfo("Cập nhật tài khoản thành công");
                    LoadData();
                    ResetValues();
                }
                catch (Exception ex)
                {
                    Functions.HandleError("Lỗi khi cập nhật tài khoản: " + ex.Message);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();

            if (!string.IsNullOrEmpty(username))
            {
                if (Functions.HandleQuestion("Bạn có muốn xóa không?"))
                {
                    try
                    {
                        TaiKhoanDAL.DeleteTaiKhoan(username);
                        Functions.HandleInfo("Xóa tài khoản thành công");
                        LoadData();
                        ResetValues();

                        btnSua.Enabled = false;
                        btnXoa.Enabled = false;
                        btnHuy.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        Functions.HandleError("Lỗi khi xóa tài khoản: " + ex.Message);
                    }
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                string username = txtUsername.Text.Trim();
                string password = Functions.ComputeSha256Hash(txtPassword.Text.Trim());
                string privStr = cboPriv.SelectedItem.ToString();

                int priv = -1;

                if (privStr == "Quản lý")
                {
                    priv = 1;
                }
                else if (privStr == "Nhân viên")
                {
                    priv = 0;
                }

                try
                {
                    TaiKhoanDAL.InsertTaiKhoan(username, password, priv);
                    Functions.HandleInfo("Thêm tài khoản thành công");
                    LoadData();
                    ResetValues();

                    btnThem.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnHuy.Enabled = false;
                    btnLuu.Enabled = false;
                    txtUsername.Enabled = false;
                }
                catch (Exception ex)
                {
                    Functions.HandleError("Lỗi khi thêm tài khoản: " + ex.Message);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetValues();

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            txtUsername.Enabled = false;

            txtTimKiem.Text = "";
            isSearching = false;

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
