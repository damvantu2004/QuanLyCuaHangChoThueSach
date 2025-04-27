using BAEK_PERCENT.Class;
using BAEK_PERCENT.DAL;
using MaterialSkin.Controls;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BAEK_PERCENT.Forms
{
    public partial class frmNgonNgu : MaterialForm
    {
        private DataTable tblNgonNgu;

        private bool isSearching = false;
        private string currentSearchKeyword = "";

        public frmNgonNgu()
        {
            InitializeComponent();
            InitializeListView();
            LoadData();
        }

        private void InitializeListView()
        {
            listViewNN.FullRowSelect = true;
            listViewNN.MultiSelect = false;
            listViewNN.UseCompatibleStateImageBehavior = false;
            listViewNN.View = View.Details;

            listViewNN.Columns.Add("MaNN", "Mã ngôn ngữ");
            listViewNN.Columns.Add("TenNN", "Tên ngôn ngữ");
        }

        private void frmNgonNgu_Load(object sender, EventArgs e)
        {
            txtMaNN.Enabled = false;

            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            btnLuu.Enabled = false;
            btnHuy.Enabled = false;

            txtTimKiem.Text = "Nhập từ khóa tìm kiếm";
            txtTimKiem.ForeColor = Color.Gray;
        }

        private void AdjustColumnWidth()
        {
            int totalWidth = listViewNN.ClientSize.Width;
            double col1Percentage = 0.3;
            double col2Percentage = 0.7;
            int col1Width = (int)(totalWidth * col1Percentage);
            int col2Width = (int)(totalWidth * col2Percentage);

            listViewNN.Columns[0].Width = col1Width;
            listViewNN.Columns[1].Width = col2Width;
        }

        private void LoadData()
        {
            try
            {
                if (isSearching)
                    tblNgonNgu = NgonNguDAL.GetNgonNguBySearch(currentSearchKeyword);
                else
                    tblNgonNgu = NgonNguDAL.GetAllNgonNgu();

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

            foreach (DataRow row in tblNgonNgu.Rows)
            {
                ListViewItem item = new ListViewItem(row["MaNN"].ToString());
                item.SubItems.Add(row["TenNN"].ToString());
                listViewNN.Items.Add(item);
            }

            AdjustColumnWidth();
        }

        private void ClearListView()
        {
            listViewNN.Items.Clear();
        }

        private void listViewNN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                Functions.HandleInfo("Đang ở chế độ thêm mới");
                txtMaNN.Focus();
                return;
            }

            if (tblNgonNgu.Rows.Count == 0)
            {
                Functions.HandleInfo("Không có dữ liệu");
                return;
            }

            if (listViewNN.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewNN.SelectedItems[0];
                txtMaNN.Text = selectedItem.SubItems[0].Text;
                txtTenNN.Text = selectedItem.SubItems[1].Text;

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnHuy.Enabled = true;
            }
            else
            {
                txtMaNN.Text = "";
                txtTenNN.Text = "";
            }
        }

        private void ResetValues()
        {
            txtMaNN.Text = "";
            txtTenNN.Text = "";
        }

        private bool ValidateInput()
        {
            /*
            if (string.IsNullOrWhiteSpace(txtMaNN.Text))
            {
                Functions.HandleWarning("Bạn phải nhập mã ngôn ngữ");
                txtMaNN.Focus();
                return false;
            }
            */

            if (string.IsNullOrWhiteSpace(txtTenNN.Text))
            {
                Functions.HandleWarning("Bạn phải nhập tên ngôn ngữ");
                txtTenNN.Focus();
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
            txtTenNN.Focus();

            string newMaNN = NgonNguDAL.InsertEmptyNgonNgu();
            txtMaNN.Text = newMaNN;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (listViewNN.SelectedItems.Count == 0)
            {
                Functions.HandleInfo("Bạn chưa chọn bản ghi nào để sửa");
                return;
            }

            if (ValidateInput())
            {
                string maNN = txtMaNN.Text.Trim();
                string tenNN = txtTenNN.Text.Trim();

                try
                {
                    NgonNguDAL.UpdateNgonNgu(maNN, tenNN);
                    Functions.HandleInfo("Cập nhật ngôn ngữ thành công");
                    LoadData();
                    ResetValues();
                }
                catch (Exception ex)
                {
                    Functions.HandleError("Lỗi khi cập nhật ngôn ngữ: " + ex.Message);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maNN = txtMaNN.Text.Trim();

            if (!string.IsNullOrEmpty(maNN))
            {
                if (Functions.HandleQuestion("Bạn có muốn xóa không?"))
                {
                    try
                    {
                        NgonNguDAL.DeleteNgonNgu(maNN);
                        Functions.HandleInfo("Xóa ngôn ngữ thành công");
                        LoadData();
                        ResetValues();

                        btnSua.Enabled = false;
                        btnXoa.Enabled = false;
                        btnHuy.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        Functions.HandleError("Lỗi khi xóa ngôn ngữ: " + ex.Message);
                    }
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                string maNN = txtMaNN.Text.Trim();
                string tenNN = txtTenNN.Text.Trim();

                try
                {
                    NgonNguDAL.UpdateNgonNgu(maNN, tenNN);
                    Functions.HandleInfo("Thêm ngôn ngữ thành công");
                    LoadData();
                    ResetValues();

                    btnThem.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnHuy.Enabled = false;
                    btnLuu.Enabled = false;
                    txtMaNN.Enabled = false;
                }
                catch (Exception ex)
                {
                    Functions.HandleError("Lỗi khi thêm ngôn ngữ: " + ex.Message);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            string maNN = txtMaNN.Text.Trim();

            ResetValues();

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            txtMaNN.Enabled = false;

            txtTimKiem.Text = "";
            isSearching = false;

            if (!string.IsNullOrEmpty(maNN))
            {
                NgonNguDAL.DeleteEmptyNgonNgu(maNN);
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
