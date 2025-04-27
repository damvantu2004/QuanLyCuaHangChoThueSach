using BAEK_PERCENT.Class;
using BAEK_PERCENT.DAL;
using MaterialSkin.Controls;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BAEK_PERCENT.Forms
{
    public partial class frmTacGia : MaterialForm
    {
        private DataTable tblTacGia;

        private bool isSearching = false;
        private string currentSearchKeyword = "";

        public frmTacGia()
        {
            InitializeComponent();
            InitializeListView();
            LoadData();
        }

        private void InitializeListView()
        {
            listViewTG.FullRowSelect = true;
            listViewTG.MultiSelect = false;
            listViewTG.UseCompatibleStateImageBehavior = false;
            listViewTG.View = View.Details;

            listViewTG.Columns.Add("MaTG", "Mã tác giả");
            listViewTG.Columns.Add("TenTG", "Tên tác giả");
        }

        private void frmTacGia_Load(object sender, EventArgs e)
        {
            txtMaTG.Enabled = false;

            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            btnLuu.Enabled = false;
            btnHuy.Enabled = false;

            txtTimKiem.Text = "Nhập từ khóa tìm kiếm";
            txtTimKiem.ForeColor = Color.Gray;
        }

        private void AdjustColumnWidth()
        {
            int totalWidth = listViewTG.ClientSize.Width;
            double col1Percentage = 0.3;
            double col2Percentage = 0.7;
            int col1Width = (int)(totalWidth * col1Percentage);
            int col2Width = (int)(totalWidth * col2Percentage);

            listViewTG.Columns[0].Width = col1Width;
            listViewTG.Columns[1].Width = col2Width;
        }

        private void LoadData()
        {
            try
            {
                if (isSearching)
                    tblTacGia = TacGiaDAL.GetTacGiaBySearch(currentSearchKeyword);
                else
                    tblTacGia = TacGiaDAL.GetAllTacGia();

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

            foreach (DataRow row in tblTacGia.Rows)
            {
                ListViewItem item = new ListViewItem(row["MaTG"].ToString());
                item.SubItems.Add(row["TenTG"].ToString());
                listViewTG.Items.Add(item);
            }

            AdjustColumnWidth();
        }

        private void ClearListView()
        {
            listViewTG.Items.Clear();
        }

        private void listViewTG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                Functions.HandleInfo("Đang ở chế độ thêm mới");
                txtMaTG.Focus();
                return;
            }

            if (tblTacGia.Rows.Count == 0)
            {
                Functions.HandleInfo("Không có dữ liệu");
                return;
            }

            if (listViewTG.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewTG.SelectedItems[0];
                txtMaTG.Text = selectedItem.SubItems[0].Text;
                txtTenTG.Text = selectedItem.SubItems[1].Text;

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnHuy.Enabled = true;
            }
            else
            {
                txtMaTG.Text = "";
                txtTenTG.Text = "";
            }
        }

        private void ResetValues()
        {
            txtMaTG.Text = "";
            txtTenTG.Text = "";
        }

        private bool ValidateInput()
        {
            /*
            if (string.IsNullOrWhiteSpace(txtMaTG.Text))
            {
                Functions.HandleWarning("Bạn phải nhập mã tác giả");
                txtMaTG.Focus();
                return false;
            }
            */

            if (string.IsNullOrWhiteSpace(txtTenTG.Text))
            {
                Functions.HandleWarning("Bạn phải nhập tên tác giả");
                txtTenTG.Focus();
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
            txtTenTG.Focus();

            string newMaTG = TacGiaDAL.InsertEmptyTacGia();
            txtMaTG.Text = newMaTG;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (listViewTG.SelectedItems.Count == 0)
            {
                Functions.HandleInfo("Bạn chưa chọn bản ghi nào để sửa");
                return;
            }

            if (ValidateInput())
            {
                string maTG = txtMaTG.Text.Trim();
                string tenTG = txtTenTG.Text.Trim();

                try
                {
                    TacGiaDAL.UpdateTacGia(maTG, tenTG);
                    Functions.HandleInfo("Cập nhật tác giả thành công");
                    LoadData();
                    ResetValues();
                }
                catch (Exception ex)
                {
                    Functions.HandleError("Lỗi khi cập nhật tác giả: " + ex.Message);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maTG = txtMaTG.Text.Trim();

            if (!string.IsNullOrEmpty(maTG))
            {
                if (Functions.HandleQuestion("Bạn có muốn xóa không?"))
                {
                    try
                    {
                        TacGiaDAL.DeleteTacGia(maTG);
                        Functions.HandleInfo("Xóa tác giả thành công");
                        LoadData();
                        ResetValues();

                        btnSua.Enabled = false;
                        btnXoa.Enabled = false;
                        btnHuy.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        Functions.HandleError("Lỗi khi xóa tác giả: " + ex.Message);
                    }
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                string maTG = txtMaTG.Text.Trim();
                string tenTG = txtTenTG.Text.Trim();

                try
                {
                    TacGiaDAL.UpdateTacGia(maTG, tenTG);
                    Functions.HandleInfo("Thêm tác giả thành công");
                    LoadData();
                    ResetValues();

                    btnThem.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnHuy.Enabled = false;
                    btnLuu.Enabled = false;
                    txtMaTG.Enabled = false;
                }
                catch (Exception ex)
                {
                    Functions.HandleError("Lỗi khi thêm tác giả: " + ex.Message);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            string maTG = txtMaTG.Text.Trim();

            ResetValues();

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            txtMaTG.Enabled = false;

            txtTimKiem.Text = "";
            isSearching = false;

            if (!string.IsNullOrEmpty(maTG))
            {
                TacGiaDAL.DeleteEmptyTacGia(maTG);
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
