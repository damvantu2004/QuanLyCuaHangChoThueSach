using BAEK_PERCENT.Class.Types;
using BAEK_PERCENT.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BAEK_PERCENT
{
    public partial class frmMain : MaterialForm
    {
        private frmHome childFormHome;

        private frmSach childFormSach;
        private frmThue childFormThue;
        private frmTra childFormTra;
        private frmBaoCao childFormBaoCao;
        private frmKhach childFormKhach;

        private frmNhanVien childFormNhanVien;
        private frmTacGia childFormTacGia;
        private frmLinhVuc childFormLinhVuc;

        private frmLoaiSach childFormLoaiSach;
        private frmNgonNgu childFormNgonNgu;
        private frmViPham childFormViPham;

        private frmTaiKhoan childFormTaiKhoan;
        private frmThongTin childFormThongTin;

        public frmMain()
        {
            InitializeComponent();

            Color primaryColor = Color.FromArgb(255, 255, 255);       // White
            Color darkPrimaryColor = Color.FromArgb(240, 240, 240);   // Light Gray
            Color lightPrimaryColor = Color.FromArgb(255, 255, 255);  // White
            Color accentColor = Color.FromArgb(255, 150, 79);         // Orange
            // màu sắc của chương trình là màu trắng và màu cam
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            var colorScheme = new ColorScheme( // màu chủ đạo của chương trình là màu trắng và màu cam
                primaryColor, // màu chủ đạo
                darkPrimaryColor, // màu chủ đạo tối
                lightPrimaryColor, // màu chủ đạo sáng
                accentColor, // màu phụ
                TextShade.BLACK // màu chữ
            );

            materialSkinManager.ColorScheme = colorScheme; // màu chủ đạo của chương trình là màu trắng và màu cam
            materialSkinManager.AddFormToManage(this); // thêm form vào quản lý

            UpdateFormTitle(materialTabControl.SelectedTab); // cập nhật tiêu đề form
        }

        public UserRole currentRole; // vai trò người dùng

        public string Username { get; set; } // tên người dùng

        private MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance; // quản lý màu sắc của chương trình, instance là một phương thức của MaterialSkinManager, dùng để lấy instance của MaterialSkinManager

        private void initForm(MaterialForm form) // khởi tạo form, nhằm đưa form vào quản lý để gọi các phương thức của form khi bấm vào các tab
        {
            form.TopLevel = false; // form không phải là form chính
            form.FormBorderStyle = FormBorderStyle.None; // không có viền form
            form.Dock = DockStyle.Fill; // form chiếm toàn bộ không gian
            materialSkinManager.AddFormToManage(form); // thêm form vào quản lý
        }

        private void initAllForm() // khởi tạo tất cả form
        {
            initFormHome(); // khởi tạo form home

            initFormSach(); // khởi tạo form sach
            initFormThue(); // khởi tạo form thue
            initFormTra(); // khởi tạo form tra
            initFormBaoCao(); // khởi tạo form bao cao

            initFormKhach(); // khởi tạo form khach
            initFormLoaiSach(); // khởi tạo form loai sach
            initFormNgonNgu(); // khởi tạo form ngon ngu

            initFormTacGia(); // khởi tạo form tac gia
            initFormLinhVuc(); // khởi tạo form linh vuc
            initFormNhanVien(); // khởi tạo form nhan vien

            initFormViPham(); // khởi tạo form vi pham
            initFormTaiKhoan(); // khởi tạo form tai khoan
            initFormThongTin(); // khởi tạo form thong tin
        }

        private void mainTabControl_SelectedIndexChanged(object sender, EventArgs e) // cập nhật tiêu đề form
        {
            UpdateFormTitle(materialTabControl.SelectedTab); // cập nhật tiêu đề form
        }

        private void UpdateFormTitle(TabPage selectedTab) // cập nhật tiêu đề form
        {
            if (selectedTab != null) // nếu tab được chọn không phải null
            {
                this.Text = $"{selectedTab.Text}"; // cập nhật tiêu đề form là tên tab được chọn ở tabcontrol
            }
        }

        private void initFormHome() // khởi tạo form home
        {
            childFormHome = new frmHome(); // khởi tạo form home
            initForm(childFormHome); // khởi tạo form home
            tabPageHome.Controls.Add(childFormHome); // thêm form home vào tabcontrol
            childFormHome.Show(); // hiển thị form home

            childFormHome.DirectToThueClicked += FrmHome_DirectToThueClicked; // khi bấm vào tab thue, sẽ gọi phương thức FrmHome_DirectToThueClicked
            childFormHome.DirectToTraClicked += FrmHome_DirectToTraClicked; // khi bấm vào tab tra, sẽ gọi phương thức FrmHome_DirectToTraClicked
            childFormHome.DirectToBaoCaoClicked += FrmHome_DirectToBaoCaoClicked; // khi bấm vào tab bao cao, sẽ gọi phương thức FrmHome_DirectToBaoCaoClicked
        }

        private void initFormSach() // khởi tạo form sach
        {
            childFormSach = new frmSach(); // khởi tạo form sach
            initForm(childFormSach); // khởi tạo form sach
            tabPageSach.Controls.Add(childFormSach); // thêm form sach vào tabcontrol
            childFormSach.Show(); // hiển thị form sach
        }

        private void initFormThue() // khởi tạo form thue
        {
            childFormThue = new frmThue(); // khởi tạo form thue
            childFormThue.Username = this.Username; // gán tên người dùng cho form thue
            initForm(childFormThue); // khởi tạo form thue
            tabPageThue.Controls.Add(childFormThue); // thêm form thue vào tabcontrol
            childFormThue.Show(); // hiển thị form thue
        }

        private void initFormTra()
        {
            childFormTra = new frmTra();
            childFormTra.Username = this.Username;
            initForm(childFormTra);
            tabPageTra.Controls.Add(childFormTra); 
            childFormTra.Show();
        }

        private void initFormBaoCao()
        {
            childFormBaoCao = new frmBaoCao();
            initForm(childFormBaoCao);
            tabPageBC.Controls.Add(childFormBaoCao);
            childFormBaoCao.Show();
        }

        private void initFormKhach()
        {
            childFormKhach = new frmKhach();
            initForm(childFormKhach);
            tabPageKhach.Controls.Add(childFormKhach);
            childFormKhach.Show();
        }

        private void initFormNhanVien()
        {
            childFormNhanVien = new frmNhanVien();
            initForm(childFormNhanVien);
            tabPageNV.Controls.Add(childFormNhanVien);
            childFormNhanVien.Show();
        }

        private void initFormTacGia()
        {
            childFormTacGia = new frmTacGia();
            initForm(childFormTacGia);
            tabPageTG.Controls.Add(childFormTacGia);
            childFormTacGia.Show();
        }

        private void initFormLinhVuc()
        {
            childFormLinhVuc = new frmLinhVuc();
            initForm(childFormLinhVuc);
            tabPageLV.Controls.Add(childFormLinhVuc);
            childFormLinhVuc.Show();
        }

        private void initFormLoaiSach()
        {
            childFormLoaiSach = new frmLoaiSach();
            initForm(childFormLoaiSach);
            tabPageLoai.Controls.Add(childFormLoaiSach);
            childFormLoaiSach.Show();
        }

        private void initFormNgonNgu()
        {
            childFormNgonNgu = new frmNgonNgu();
            initForm(childFormNgonNgu);
            tabPageNN.Controls.Add(childFormNgonNgu);
            childFormNgonNgu.Show();
        }

        private void initFormViPham()
        {
            childFormViPham = new frmViPham();
            initForm(childFormViPham);
            tabPageVP.Controls.Add(childFormViPham);
            childFormViPham.Show();
        }

        private void initFormTaiKhoan()
        {
            childFormTaiKhoan = new frmTaiKhoan();
            initForm(childFormTaiKhoan);
            tabPageTK.Controls.Add(childFormTaiKhoan);
            childFormTaiKhoan.Show();
        }

        private void initFormThongTin()
        {
            childFormThongTin = new frmThongTin();
            childFormThongTin.Username = this.Username;
            childFormThongTin.currentRole = this.currentRole;
            initForm(childFormThongTin);
            tabPageTT.Controls.Add(childFormThongTin);
            childFormThongTin.Show();
        }

        private void atEnd_frmMain_Shown(object sender, EventArgs e) // khi form được hiển thị
        {
            initAllForm(); // khởi tạo tất cả form
            UpdateChildForms(); // cập nhật form con
            UpdateTabVisibility(); // cập nhật hiển thị tab
        }

        private void UpdateChildForms() // cập nhật form con    
        {
            childFormThue.Username = this.Username; // gán tên người dùng cho form thue
            childFormTra.Username = this.Username; // gán tên người dùng cho form tra
            childFormThongTin.Username = this.Username; // gán tên người dùng cho form thong tin
            childFormThongTin.currentRole = this.currentRole; // gán vai trò người dùng cho form thong tin

            // tải dữ liệu cho form con phụ thuộc vào Username
            childFormThue.LoadData(); // tải dữ liệu cho form thue
            childFormTra.LoadData(); // tải dữ liệu cho form tra
            childFormThongTin.LoadData(); // tải dữ liệu cho form thong tin
        }

        private void frmMain_VisibleChanged(object sender, EventArgs e) // khi form được hiển thị
        {
            if (this.Visible) // nếu form được hiển thị
            {
                initAllForm(); // khởi tạo tất cả form
                UpdateChildForms(); // cập nhật form con
                UpdateTabVisibility(); // cập nhật hiển thị tab
            }
        }

        private void UpdateTabVisibility() // cập nhật hiển thị tab
        {   // Hiển thị/ẩn card doanh thu cho form home
            childFormHome.SetDoanhThuCardVisible(this.currentRole == UserRole.Admin); // hiển thị card doanh thu cho form home

            if (this.currentRole == UserRole.User) // nếu vai trò người dùng là user
            {
                HideUserTabs(); // ẩn các tab không cho phép user truy cập
            }
            else if (this.currentRole == UserRole.Admin) // nếu vai trò người dùng là admin
            {
                ShowAllTabs(); // hiển thị tất cả các tab
            }
        }

        private void HideUserTabs() // ẩn các tab không cho phép user truy cập
        {
            if (materialTabControl != null) // đảm bảo tabcontrol không phải null
            { // Nếu không kiểm tra và materialTabControl là null, khi truy cập .TabPages sẽ gây ra lỗi NullReferenceException
                materialTabControl.TabPages.Remove(tabPageBC); // xóa tab bao cao
                materialTabControl.TabPages.Remove(tabPageNV); // xóa tab nhan vien
                materialTabControl.TabPages.Remove(tabPageVP); // xóa tab vi pham
                materialTabControl.TabPages.Remove(tabPageTK); // xóa tab tai khoan
            }

        }

        private void ShowAllTabs() // hiển thị tất cả các tab không phải user
        {
            if (materialTabControl != null) // nếu tabcontrol không phải null
            {
                if (!materialTabControl.TabPages.Contains(tabPageBC)) // nếu tab bao cao không có trong tabcontrol
                    materialTabControl.TabPages.Add(tabPageBC); // thêm tab bao cao vào tabcontrol

                if (!materialTabControl.TabPages.Contains(tabPageNV)) // nếu tab nhan vien không có trong tabcontrol
                    materialTabControl.TabPages.Add(tabPageNV); // thêm tab nhan vien vào tabcontrol

                if (!materialTabControl.TabPages.Contains(tabPageVP)) // nếu tab vi pham không có trong tabcontrol
                    materialTabControl.TabPages.Add(tabPageVP); // thêm tab vi pham vào tabcontrol

                if (!materialTabControl.TabPages.Contains(tabPageTK)) // nếu tab tai khoan không có trong tabcontrol
                    materialTabControl.TabPages.Add(tabPageTK); // thêm tab tai khoan vào tabcontrol
            }
        }


        private void FrmHome_DirectToThueClicked(object sender, EventArgs e)
        {
            materialTabControl.SelectedTab = tabPageThue;
        }

        private void FrmHome_DirectToTraClicked(object sender, EventArgs e)
        {
            materialTabControl.SelectedTab = tabPageTra;
        }

        private void FrmHome_DirectToBaoCaoClicked(object sender, EventArgs e)
        {
            materialTabControl.SelectedTab = tabPageBC;
        }
    }
};