namespace BAEK_PERCENT
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.materialTabControl = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPageHome = new System.Windows.Forms.TabPage();
            this.tabPageSach = new System.Windows.Forms.TabPage();
            this.tabPageThue = new System.Windows.Forms.TabPage();
            this.tabPageTra = new System.Windows.Forms.TabPage();
            this.tabPageBC = new System.Windows.Forms.TabPage();
            this.tabPageKhach = new System.Windows.Forms.TabPage();
            this.tabPageNV = new System.Windows.Forms.TabPage();
            this.tabPageTG = new System.Windows.Forms.TabPage();
            this.tabPageLV = new System.Windows.Forms.TabPage();
            this.tabPageLoai = new System.Windows.Forms.TabPage();
            this.tabPageNN = new System.Windows.Forms.TabPage();
            this.tabPageVP = new System.Windows.Forms.TabPage();
            this.tabPageTK = new System.Windows.Forms.TabPage();
            this.tabPageTT = new System.Windows.Forms.TabPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.materialTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialTabControl
            // 
            this.materialTabControl.Controls.Add(this.tabPageHome);
            this.materialTabControl.Controls.Add(this.tabPageSach);
            this.materialTabControl.Controls.Add(this.tabPageThue);
            this.materialTabControl.Controls.Add(this.tabPageTra);
            this.materialTabControl.Controls.Add(this.tabPageBC);
            this.materialTabControl.Controls.Add(this.tabPageKhach);
            this.materialTabControl.Controls.Add(this.tabPageNV);
            this.materialTabControl.Controls.Add(this.tabPageTG);
            this.materialTabControl.Controls.Add(this.tabPageLV);
            this.materialTabControl.Controls.Add(this.tabPageLoai);
            this.materialTabControl.Controls.Add(this.tabPageNN);
            this.materialTabControl.Controls.Add(this.tabPageVP);
            this.materialTabControl.Controls.Add(this.tabPageTK);
            this.materialTabControl.Controls.Add(this.tabPageTT);
            this.materialTabControl.Depth = 0;
            this.materialTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialTabControl.ImageList = this.imageList1;
            this.materialTabControl.Location = new System.Drawing.Point(0, 80);
            this.materialTabControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.materialTabControl.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl.Multiline = true;
            this.materialTabControl.Name = "materialTabControl";
            this.materialTabControl.SelectedIndex = 0;
            this.materialTabControl.Size = new System.Drawing.Size(1356, 877);
            this.materialTabControl.TabIndex = 0;
            this.materialTabControl.SelectedIndexChanged += new System.EventHandler(this.mainTabControl_SelectedIndexChanged);
            // 
            // tabPageHome
            // 
            this.tabPageHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageHome.ImageKey = "HomeIcon.png";
            this.tabPageHome.Location = new System.Drawing.Point(4, 31);
            this.tabPageHome.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageHome.Name = "tabPageHome";
            this.tabPageHome.Size = new System.Drawing.Size(1348, 842);
            this.tabPageHome.TabIndex = 0;
            this.tabPageHome.Text = "Trang chủ";
            this.tabPageHome.UseVisualStyleBackColor = true;
            // 
            // tabPageSach
            // 
            this.tabPageSach.BackColor = System.Drawing.Color.Transparent;
            this.tabPageSach.ImageKey = "SachTruyenIcon.png";
            this.tabPageSach.Location = new System.Drawing.Point(4, 31);
            this.tabPageSach.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageSach.Name = "tabPageSach";
            this.tabPageSach.Size = new System.Drawing.Size(1348, 842);
            this.tabPageSach.TabIndex = 1;
            this.tabPageSach.Text = "Sách truyện";
            // 
            // tabPageThue
            // 
            this.tabPageThue.ImageKey = "ThueSachIcon.png";
            this.tabPageThue.Location = new System.Drawing.Point(4, 31);
            this.tabPageThue.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageThue.Name = "tabPageThue";
            this.tabPageThue.Size = new System.Drawing.Size(1348, 842);
            this.tabPageThue.TabIndex = 2;
            this.tabPageThue.Text = "Thuê sách";
            this.tabPageThue.UseVisualStyleBackColor = true;
            // 
            // tabPageTra
            // 
            this.tabPageTra.ImageKey = "TraSachIcon.png";
            this.tabPageTra.Location = new System.Drawing.Point(4, 31);
            this.tabPageTra.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageTra.Name = "tabPageTra";
            this.tabPageTra.Size = new System.Drawing.Size(1348, 842);
            this.tabPageTra.TabIndex = 3;
            this.tabPageTra.Text = "Trả sách";
            this.tabPageTra.UseVisualStyleBackColor = true;
            // 
            // tabPageBC
            // 
            this.tabPageBC.ImageKey = "ReportIcon.png";
            this.tabPageBC.Location = new System.Drawing.Point(4, 31);
            this.tabPageBC.Name = "tabPageBC";
            this.tabPageBC.Size = new System.Drawing.Size(1348, 842);
            this.tabPageBC.TabIndex = 13;
            this.tabPageBC.Text = "Báo cáo";
            this.tabPageBC.UseVisualStyleBackColor = true;
            // 
            // tabPageKhach
            // 
            this.tabPageKhach.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageKhach.ImageKey = "KhachHangIcon.png";
            this.tabPageKhach.Location = new System.Drawing.Point(4, 31);
            this.tabPageKhach.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageKhach.Name = "tabPageKhach";
            this.tabPageKhach.Size = new System.Drawing.Size(1348, 842);
            this.tabPageKhach.TabIndex = 4;
            this.tabPageKhach.Text = "Khách hàng";
            this.tabPageKhach.UseVisualStyleBackColor = true;
            // 
            // tabPageNV
            // 
            this.tabPageNV.ImageKey = "NhanVienIcon.png";
            this.tabPageNV.Location = new System.Drawing.Point(4, 31);
            this.tabPageNV.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageNV.Name = "tabPageNV";
            this.tabPageNV.Size = new System.Drawing.Size(1348, 842);
            this.tabPageNV.TabIndex = 5;
            this.tabPageNV.Text = "Nhân viên";
            this.tabPageNV.UseVisualStyleBackColor = true;
            // 
            // tabPageTG
            // 
            this.tabPageTG.ImageKey = "TacGiaIcon.png";
            this.tabPageTG.Location = new System.Drawing.Point(4, 31);
            this.tabPageTG.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageTG.Name = "tabPageTG";
            this.tabPageTG.Size = new System.Drawing.Size(1348, 842);
            this.tabPageTG.TabIndex = 6;
            this.tabPageTG.Text = "Tác giả";
            this.tabPageTG.UseVisualStyleBackColor = true;
            // 
            // tabPageLV
            // 
            this.tabPageLV.AutoScroll = true;
            this.tabPageLV.BackColor = System.Drawing.Color.Transparent;
            this.tabPageLV.ImageKey = "LinhVucIcon.png";
            this.tabPageLV.Location = new System.Drawing.Point(4, 31);
            this.tabPageLV.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageLV.Name = "tabPageLV";
            this.tabPageLV.Size = new System.Drawing.Size(1348, 842);
            this.tabPageLV.TabIndex = 7;
            this.tabPageLV.Text = "Lĩnh vực";
            // 
            // tabPageLoai
            // 
            this.tabPageLoai.ImageKey = "LoaiSachIcon.png";
            this.tabPageLoai.Location = new System.Drawing.Point(4, 31);
            this.tabPageLoai.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageLoai.Name = "tabPageLoai";
            this.tabPageLoai.Size = new System.Drawing.Size(1348, 842);
            this.tabPageLoai.TabIndex = 8;
            this.tabPageLoai.Text = "Loại sách";
            this.tabPageLoai.UseVisualStyleBackColor = true;
            // 
            // tabPageNN
            // 
            this.tabPageNN.ImageKey = "NgonNguIcon.png";
            this.tabPageNN.Location = new System.Drawing.Point(4, 31);
            this.tabPageNN.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageNN.Name = "tabPageNN";
            this.tabPageNN.Size = new System.Drawing.Size(1348, 842);
            this.tabPageNN.TabIndex = 9;
            this.tabPageNN.Text = "Ngôn ngữ";
            this.tabPageNN.UseVisualStyleBackColor = true;
            // 
            // tabPageVP
            // 
            this.tabPageVP.ImageKey = "ViPhamIcon.png";
            this.tabPageVP.Location = new System.Drawing.Point(4, 31);
            this.tabPageVP.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageVP.Name = "tabPageVP";
            this.tabPageVP.Size = new System.Drawing.Size(1348, 842);
            this.tabPageVP.TabIndex = 10;
            this.tabPageVP.Text = "Vi phạm";
            this.tabPageVP.UseVisualStyleBackColor = true;
            // 
            // tabPageTK
            // 
            this.tabPageTK.ImageKey = "TaiKhoanIcon.png";
            this.tabPageTK.Location = new System.Drawing.Point(4, 31);
            this.tabPageTK.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageTK.Name = "tabPageTK";
            this.tabPageTK.Size = new System.Drawing.Size(1348, 842);
            this.tabPageTK.TabIndex = 11;
            this.tabPageTK.Text = "Tài khoản";
            this.tabPageTK.UseVisualStyleBackColor = true;
            // 
            // tabPageTT
            // 
            this.tabPageTT.ImageKey = "ThongTinIcon.png";
            this.tabPageTT.Location = new System.Drawing.Point(4, 31);
            this.tabPageTT.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageTT.Name = "tabPageTT";
            this.tabPageTT.Size = new System.Drawing.Size(1348, 842);
            this.tabPageTT.TabIndex = 12;
            this.tabPageTT.Text = "Thông tin";
            this.tabPageTT.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "HomeIcon.png");
            this.imageList1.Images.SetKeyName(1, "KhachHangIcon.png");
            this.imageList1.Images.SetKeyName(2, "LinhVucIcon.png");
            this.imageList1.Images.SetKeyName(3, "LoaiSachIcon.png");
            this.imageList1.Images.SetKeyName(4, "NgonNguIcon.png");
            this.imageList1.Images.SetKeyName(5, "NhanVienIcon.png");
            this.imageList1.Images.SetKeyName(6, "SachTruyenIcon.png");
            this.imageList1.Images.SetKeyName(7, "TacGiaIcon.png");
            this.imageList1.Images.SetKeyName(8, "TaiKhoanIcon.png");
            this.imageList1.Images.SetKeyName(9, "ThueSachIcon.png");
            this.imageList1.Images.SetKeyName(10, "TraSachIcon.png");
            this.imageList1.Images.SetKeyName(11, "ViPhamIcon.png");
            this.imageList1.Images.SetKeyName(12, "LogoutIcon.png");
            this.imageList1.Images.SetKeyName(13, "ThongTinIcon.png");
            this.imageList1.Images.SetKeyName(14, "ReportIcon.png");
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 960);
            this.Controls.Add(this.materialTabControl);
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.materialTabControl;
            this.DrawerWidth = 250;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_56;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(1200, 960);
            this.Name = "frmMain";
            this.Padding = new System.Windows.Forms.Padding(0, 80, 4, 3);
            this.Text = "BAEK-PERCENT";
            this.Shown += new System.EventHandler(this.atEnd_frmMain_Shown);
            this.VisibleChanged += new System.EventHandler(this.frmMain_VisibleChanged);
            this.materialTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl;
        private System.Windows.Forms.TabPage tabPageHome;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabPage tabPageThue;
        private System.Windows.Forms.TabPage tabPageTra;
        private System.Windows.Forms.TabPage tabPageKhach;
        private System.Windows.Forms.TabPage tabPageNV;
        private System.Windows.Forms.TabPage tabPageTG;
        private System.Windows.Forms.TabPage tabPageLV;
        private System.Windows.Forms.TabPage tabPageLoai;
        private System.Windows.Forms.TabPage tabPageNN;
        private System.Windows.Forms.TabPage tabPageVP;
        private System.Windows.Forms.TabPage tabPageTK;
        private System.Windows.Forms.TabPage tabPageSach;
        private System.Windows.Forms.TabPage tabPageTT;
        private System.Windows.Forms.TabPage tabPageBC;
    }
}

