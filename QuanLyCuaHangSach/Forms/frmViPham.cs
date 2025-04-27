using BAEK_PERCENT.Class;
using BAEK_PERCENT.DAL;
using MaterialSkin.Controls;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BAEK_PERCENT.Forms
{
    public partial class frmViPham : MaterialForm
    {
        private DataTable tblViPham;

        private bool isSearching = false;
        private string currentSearchKeyword = "";

        public frmViPham()
        {
            InitializeComponent();
            InitializeListView();
            LoadData();
        }

        private void InitializeListView()
        {
            listViewVP.FullRowSelect = true;
            listViewVP.MultiSelect = false;
            listViewVP.UseCompatibleStateImageBehavior = false;
            listViewVP.View = View.Details;

            listViewVP.Columns.Add("MaVP", "Mã vi phạm");
            listViewVP.Columns.Add("TenVP", "Tên vi phạm");
        }

        private void frmViPham_Load(object sender, EventArgs e)
        {
            txtMaVP.Enabled = false;

            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            btnLuu.Enabled = false;
            btnHuy.Enabled = false;

            txtTimKiem.Text = "Nhập từ khóa tìm kiếm";
            txtTimKiem.ForeColor = Color.Gray;
        }

        private void AdjustColumnWidth()
        {
            int totalWidth = listViewVP.ClientSize.Width;
            double col1Percentage = 0.3;
            double col2Percentage = 0.7;
            int col1Width = (int)(totalWidth * col1Percentage);
            int col2Width = (int)(totalWidth * col2Percentage);

            listViewVP.Columns[0].Width = col1Width;
            listViewVP.Columns[1].Width = col2Width;
        }

        private void LoadData()
        {
            try
            {
                if (isSearching)
                    tblViPham = ViPhamDAL.GetViPhamBySearch(currentSearchKeyword);
                else
                    tblViPham = ViPhamDAL.GetAllViPham();

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

            foreach (DataRow row in tblViPham.Rows)
            {
                ListViewItem item = new ListViewItem(row["MaVP"].ToString());
                item.SubItems.Add(row["TenVP"].ToString());
                listViewVP.Items.Add(item);
            }

            AdjustColumnWidth();
        }

        private void ClearListView()
        {
            listViewVP.Items.Clear();
        }

        private void listViewVP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                Functions.HandleInfo("Đang ở chế độ thêm mới");
                txtMaVP.Focus();
                return;
            }

            if (tblViPham.Rows.Count == 0)
            {
                Functions.HandleInfo("Không có dữ liệu");
                return;
            }

            if (listViewVP.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewVP.SelectedItems[0];
                txtMaVP.Text = selectedItem.SubItems[0].Text;
                txtTenVP.Text = selectedItem.SubItems[1].Text;

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnHuy.Enabled = true;
            }
            else
            {
                txtMaVP.Text = "";
                txtTenVP.Text = "";
            }
        }

        private void ResetValues()
        {
            txtMaVP.Text = "";
            txtTenVP.Text = "";
        }

        private bool ValidateInput()
        {
            /*
            if (string.IsNullOrWhiteSpace(txtMaVP.Text))
            {
                Functions.HandleWarning("Bạn phải nhập mã vi phạm");
                txtMaVP.Focus();
                return false;
            }
            */

            if (string.IsNullOrWhiteSpace(txtTenVP.Text))
            {
                Functions.HandleWarning("Bạn phải nhập tên vi phạm");
                txtTenVP.Focus();
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
            txtTenVP.Focus();

            string newMaVP = ViPhamDAL.InsertEmptyViPham();
            txtMaVP.Text = newMaVP;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (listViewVP.SelectedItems.Count == 0)
            {
                Functions.HandleInfo("Bạn chưa chọn bản ghi nào để sửa");
                return;
            }

            if (ValidateInput())
            {
                string maVP = txtMaVP.Text.Trim();
                string tenVP = txtTenVP.Text.Trim();

                try
                {
                    ViPhamDAL.UpdateViPham(maVP, tenVP);
                    Functions.HandleInfo("Cập nhật vi phạm thành công");
                    LoadData();
                    ResetValues();
                }
                catch (Exception ex)
                {
                    Functions.HandleError("Lỗi khi cập nhật vi phạm: " + ex.Message);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maVP = txtMaVP.Text.Trim();

            if (!string.IsNullOrEmpty(maVP))
            {
                if (Functions.HandleQuestion("Bạn có muốn xóa không?"))
                {
                    try
                    {
                        ViPhamDAL.DeleteViPham(maVP);
                        Functions.HandleInfo("Xóa vi phạm thành công");
                        LoadData();
                        ResetValues();

                        btnSua.Enabled = false;
                        btnXoa.Enabled = false;
                        btnHuy.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        Functions.HandleError("Lỗi khi xóa vi phạm: " + ex.Message);
                    }
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                string maVP = txtMaVP.Text.Trim();
                string tenVP = txtTenVP.Text.Trim();

                try
                {
                    ViPhamDAL.UpdateViPham(maVP, tenVP);
                    Functions.HandleInfo("Thêm vi phạm thành công");
                    LoadData();
                    ResetValues();

                    btnThem.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnHuy.Enabled = false;
                    btnLuu.Enabled = false;
                    txtMaVP.Enabled = false;
                }
                catch (Exception ex)
                {
                    Functions.HandleError("Lỗi khi thêm vi phạm: " + ex.Message);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            string maVP = txtMaVP.Text.Trim();

            ResetValues();

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            txtMaVP.Enabled = false;

            txtTimKiem.Text = "";
            isSearching = false;

            if (!string.IsNullOrEmpty(maVP))
            {
                ViPhamDAL.DeleteEmptyViPham(maVP);
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
