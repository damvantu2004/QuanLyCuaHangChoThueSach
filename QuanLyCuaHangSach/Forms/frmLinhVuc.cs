using BAEK_PERCENT.Class;
using BAEK_PERCENT.DAL;
using MaterialSkin.Controls;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BAEK_PERCENT.Forms
{
    public partial class frmLinhVuc : MaterialForm
    {
        private DataTable tblLinhVuc;

        private bool isSearching = false;
        private string currentSearchKeyword = "";

        public frmLinhVuc()
        {
            InitializeComponent();
            InitializeListView();
            LoadData();
        }

        private void InitializeListView()
        {
            listViewLV.FullRowSelect = true;
            listViewLV.MultiSelect = false;
            listViewLV.UseCompatibleStateImageBehavior = false;
            listViewLV.View = View.Details;

            listViewLV.Columns.Add("MaLV", "Mã lĩnh vực");
            listViewLV.Columns.Add("TenLV", "Tên lĩnh vực");
        }

        private void frmLinhVuc_Load(object sender, EventArgs e)
        {
            txtMaLV.Enabled = false;

            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            btnLuu.Enabled = false;
            btnHuy.Enabled = false;

            txtTimKiem.Text = "Nhập từ khóa tìm kiếm";
            txtTimKiem.ForeColor = Color.Gray;
        }

        private void AdjustColumnWidth()
        {
            int totalWidth = listViewLV.ClientSize.Width;
            double col1Percentage = 0.3;
            double col2Percentage = 0.7;
            int col1Width = (int)(totalWidth * col1Percentage);
            int col2Width = (int)(totalWidth * col2Percentage);

            listViewLV.Columns[0].Width = col1Width;
            listViewLV.Columns[1].Width = col2Width;
        }

        private void LoadData()
        {
            try
            {
                if (isSearching)
                    tblLinhVuc = LinhVucDAL.GetLinhVucBySearch(currentSearchKeyword);
                else
                    tblLinhVuc = LinhVucDAL.GetAllLinhVuc();

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

            foreach (DataRow row in tblLinhVuc.Rows)
            {
                ListViewItem item = new ListViewItem(row["MaLV"].ToString());
                item.SubItems.Add(row["TenLV"].ToString());
                listViewLV.Items.Add(item);
            }

            AdjustColumnWidth();
        }

        private void ClearListView()
        {
            listViewLV.Items.Clear();
        }

        private void listViewLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                Functions.HandleInfo("Đang ở chế độ thêm mới");
                txtMaLV.Focus();
                return;
            }

            if (tblLinhVuc.Rows.Count == 0)
            {
                Functions.HandleInfo("Không có dữ liệu");
                return;
            }

            if (listViewLV.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewLV.SelectedItems[0];
                txtMaLV.Text = selectedItem.SubItems[0].Text;
                txtTenLV.Text = selectedItem.SubItems[1].Text;

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnHuy.Enabled = true;
            }
            else
            {
                txtMaLV.Text = "";
                txtTenLV.Text = "";
            }
        }

        private void ResetValues()
        {
            txtMaLV.Text = "";
            txtTenLV.Text = "";
        }

        private bool ValidateInput()
        {
            /*
            if (string.IsNullOrWhiteSpace(txtMaLV.Text))
            {
                Functions.HandleWarning("Bạn phải nhập mã lĩnh vực");
                txtMaLV.Focus();
                return false;
            }
            */

            if (string.IsNullOrWhiteSpace(txtTenLV.Text))
            {
                Functions.HandleWarning("Bạn phải nhập tên lĩnh vực");
                txtTenLV.Focus();
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
            txtTenLV.Focus();

            string newMaLV = LinhVucDAL.InsertEmptyLinhVuc();
            txtMaLV.Text = newMaLV;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (listViewLV.SelectedItems.Count == 0)
            {
                Functions.HandleInfo("Bạn chưa chọn bản ghi nào để sửa");
                return;
            }

            if (ValidateInput())
            {
                string maLV = txtMaLV.Text.Trim();
                string tenLV = txtTenLV.Text.Trim();

                try
                {
                    LinhVucDAL.UpdateLinhVuc(maLV, tenLV);
                    Functions.HandleInfo("Cập nhật lĩnh vực thành công");
                    LoadData();
                    ResetValues();
                }
                catch (Exception ex)
                {
                    Functions.HandleError("Lỗi khi cập nhật lĩnh vực: " + ex.Message);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maLV = txtMaLV.Text.Trim();

            if (!string.IsNullOrEmpty(maLV))
            {
                if (Functions.HandleQuestion("Bạn có muốn xóa không?"))
                {
                    try
                    {
                        LinhVucDAL.DeleteLinhVuc(maLV);
                        Functions.HandleInfo("Xóa lĩnh vực thành công");
                        LoadData();
                        ResetValues();

                        btnSua.Enabled = false;
                        btnXoa.Enabled = false;
                        btnHuy.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        Functions.HandleError("Lỗi khi xóa lĩnh vực: " + ex.Message);
                    }
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                string maLV = txtMaLV.Text.Trim();
                string tenLV = txtTenLV.Text.Trim();

                try
                {
                    LinhVucDAL.UpdateLinhVuc(maLV, tenLV);
                    Functions.HandleInfo("Thêm lĩnh vực thành công");
                    LoadData();
                    ResetValues();

                    btnThem.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnHuy.Enabled = false;
                    btnLuu.Enabled = false;
                    txtMaLV.Enabled = false;
                }
                catch (Exception ex)
                {
                    Functions.HandleError("Lỗi khi thêm lĩnh vực: " + ex.Message);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            string maLV = txtMaLV.Text.Trim();

            ResetValues();

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            txtMaLV.Enabled = false;

            txtTimKiem.Text = "";
            isSearching = false;

            if (!string.IsNullOrEmpty(maLV))
            {
                LinhVucDAL.DeleteEmptyLinhVuc(maLV);
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
