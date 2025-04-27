namespace BAEK_PERCENT.Forms
{
    partial class frmHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHome));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.materialCard3 = new MaterialSkin.Controls.MaterialCard();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.lblSoDonThueThang = new MaterialSkin.Controls.MaterialLabel();
            this.btnDirectToThue = new MaterialSkin.Controls.MaterialFloatingActionButton();
            this.swtDarkMode = new MaterialSkin.Controls.MaterialSwitch();
            this.materialCardDT = new MaterialSkin.Controls.MaterialCard();
            this.lblDoanhThu = new MaterialSkin.Controls.MaterialLabel();
            this.lblDoanhThuThang = new MaterialSkin.Controls.MaterialLabel();
            this.btnDirectToBaoCao = new MaterialSkin.Controls.MaterialFloatingActionButton();
            this.materialCard2 = new MaterialSkin.Controls.MaterialCard();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.lblSoDonThueChuaTra = new MaterialSkin.Controls.MaterialLabel();
            this.btnDirectToTra = new MaterialSkin.Controls.MaterialFloatingActionButton();
            this.chrHome = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.materialCard4 = new MaterialSkin.Controls.MaterialCard();
            this.materialCard3.SuspendLayout();
            this.materialCardDT.SuspendLayout();
            this.materialCard2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrHome)).BeginInit();
            this.materialCard4.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialCard3
            // 
            this.materialCard3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard3.Controls.Add(this.materialLabel1);
            this.materialCard3.Controls.Add(this.lblSoDonThueThang);
            this.materialCard3.Controls.Add(this.btnDirectToThue);
            this.materialCard3.Depth = 0;
            this.materialCard3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialCard3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard3.Location = new System.Drawing.Point(41, 78);
            this.materialCard3.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard3.Name = "materialCard3";
            this.materialCard3.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard3.Size = new System.Drawing.Size(296, 171);
            this.materialCard3.TabIndex = 13;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(25, 25);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(162, 19);
            this.materialLabel1.TabIndex = 20;
            this.materialLabel1.Text = "Số đơn thuê tháng này";
            // 
            // lblSoDonThueThang
            // 
            this.lblSoDonThueThang.AutoSize = true;
            this.lblSoDonThueThang.Depth = 0;
            this.lblSoDonThueThang.Font = new System.Drawing.Font("Roboto", 34F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblSoDonThueThang.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
            this.lblSoDonThueThang.Location = new System.Drawing.Point(25, 55);
            this.lblSoDonThueThang.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSoDonThueThang.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblSoDonThueThang.Name = "lblSoDonThueThang";
            this.lblSoDonThueThang.Size = new System.Drawing.Size(58, 41);
            this.lblSoDonThueThang.TabIndex = 19;
            this.lblSoDonThueThang.Text = "100";
            // 
            // btnDirectToThue
            // 
            this.btnDirectToThue.Depth = 0;
            this.btnDirectToThue.Icon = ((System.Drawing.Image)(resources.GetObject("btnDirectToThue.Icon")));
            this.btnDirectToThue.ImageIndex = 12;
            this.btnDirectToThue.Location = new System.Drawing.Point(223, 98);
            this.btnDirectToThue.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDirectToThue.Name = "btnDirectToThue";
            this.btnDirectToThue.Size = new System.Drawing.Size(56, 56);
            this.btnDirectToThue.TabIndex = 1;
            this.btnDirectToThue.Text = "materialFloatingActionButton3";
            this.btnDirectToThue.UseVisualStyleBackColor = true;
            this.btnDirectToThue.Click += new System.EventHandler(this.btnDirectToThue_Click);
            // 
            // swtDarkMode
            // 
            this.swtDarkMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.swtDarkMode.AutoSize = true;
            this.swtDarkMode.Depth = 0;
            this.swtDarkMode.Location = new System.Drawing.Point(850, 18);
            this.swtDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.swtDarkMode.MouseLocation = new System.Drawing.Point(-1, -1);
            this.swtDarkMode.MouseState = MaterialSkin.MouseState.HOVER;
            this.swtDarkMode.Name = "swtDarkMode";
            this.swtDarkMode.Ripple = true;
            this.swtDarkMode.Size = new System.Drawing.Size(135, 37);
            this.swtDarkMode.TabIndex = 18;
            this.swtDarkMode.Text = "Dark mode";
            this.swtDarkMode.UseVisualStyleBackColor = true;
            this.swtDarkMode.CheckedChanged += new System.EventHandler(this.swtDarkMode_CheckedChanged);
            // 
            // materialCardDT
            // 
            this.materialCardDT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCardDT.Controls.Add(this.lblDoanhThu);
            this.materialCardDT.Controls.Add(this.lblDoanhThuThang);
            this.materialCardDT.Controls.Add(this.btnDirectToBaoCao);
            this.materialCardDT.Depth = 0;
            this.materialCardDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialCardDT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCardDT.Location = new System.Drawing.Point(41, 476);
            this.materialCardDT.Margin = new System.Windows.Forms.Padding(14);
            this.materialCardDT.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCardDT.Name = "materialCardDT";
            this.materialCardDT.Padding = new System.Windows.Forms.Padding(14);
            this.materialCardDT.Size = new System.Drawing.Size(296, 171);
            this.materialCardDT.TabIndex = 21;
            // 
            // lblDoanhThu
            // 
            this.lblDoanhThu.AutoSize = true;
            this.lblDoanhThu.Depth = 0;
            this.lblDoanhThu.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblDoanhThu.Location = new System.Drawing.Point(25, 25);
            this.lblDoanhThu.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDoanhThu.Name = "lblDoanhThu";
            this.lblDoanhThu.Size = new System.Drawing.Size(150, 19);
            this.lblDoanhThu.TabIndex = 20;
            this.lblDoanhThu.Text = "Doanh thu tháng này";
            // 
            // lblDoanhThuThang
            // 
            this.lblDoanhThuThang.AutoSize = true;
            this.lblDoanhThuThang.Depth = 0;
            this.lblDoanhThuThang.Font = new System.Drawing.Font("Roboto", 34F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblDoanhThuThang.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
            this.lblDoanhThuThang.Location = new System.Drawing.Point(24, 55);
            this.lblDoanhThuThang.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDoanhThuThang.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDoanhThuThang.Name = "lblDoanhThuThang";
            this.lblDoanhThuThang.Size = new System.Drawing.Size(58, 41);
            this.lblDoanhThuThang.TabIndex = 19;
            this.lblDoanhThuThang.Text = "100";
            // 
            // btnDirectToBaoCao
            // 
            this.btnDirectToBaoCao.Depth = 0;
            this.btnDirectToBaoCao.Icon = ((System.Drawing.Image)(resources.GetObject("btnDirectToBaoCao.Icon")));
            this.btnDirectToBaoCao.ImageIndex = 12;
            this.btnDirectToBaoCao.Location = new System.Drawing.Point(223, 98);
            this.btnDirectToBaoCao.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDirectToBaoCao.Name = "btnDirectToBaoCao";
            this.btnDirectToBaoCao.Size = new System.Drawing.Size(56, 56);
            this.btnDirectToBaoCao.TabIndex = 1;
            this.btnDirectToBaoCao.Text = "materialFloatingActionButton3";
            this.btnDirectToBaoCao.UseVisualStyleBackColor = true;
            this.btnDirectToBaoCao.Click += new System.EventHandler(this.btnDirectToBaoCao_Click);
            // 
            // materialCard2
            // 
            this.materialCard2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard2.Controls.Add(this.materialLabel3);
            this.materialCard2.Controls.Add(this.lblSoDonThueChuaTra);
            this.materialCard2.Controls.Add(this.btnDirectToTra);
            this.materialCard2.Depth = 0;
            this.materialCard2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialCard2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard2.Location = new System.Drawing.Point(41, 277);
            this.materialCard2.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard2.Name = "materialCard2";
            this.materialCard2.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard2.Size = new System.Drawing.Size(296, 171);
            this.materialCard2.TabIndex = 22;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(25, 25);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(225, 19);
            this.materialLabel3.TabIndex = 20;
            this.materialLabel3.Text = "Số đơn thuê chưa trả tháng này";
            // 
            // lblSoDonThueChuaTra
            // 
            this.lblSoDonThueChuaTra.AutoSize = true;
            this.lblSoDonThueChuaTra.Depth = 0;
            this.lblSoDonThueChuaTra.Font = new System.Drawing.Font("Roboto", 34F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblSoDonThueChuaTra.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
            this.lblSoDonThueChuaTra.Location = new System.Drawing.Point(24, 55);
            this.lblSoDonThueChuaTra.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSoDonThueChuaTra.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblSoDonThueChuaTra.Name = "lblSoDonThueChuaTra";
            this.lblSoDonThueChuaTra.Size = new System.Drawing.Size(58, 41);
            this.lblSoDonThueChuaTra.TabIndex = 19;
            this.lblSoDonThueChuaTra.Text = "100";
            // 
            // btnDirectToTra
            // 
            this.btnDirectToTra.Depth = 0;
            this.btnDirectToTra.Icon = ((System.Drawing.Image)(resources.GetObject("btnDirectToTra.Icon")));
            this.btnDirectToTra.ImageIndex = 12;
            this.btnDirectToTra.Location = new System.Drawing.Point(223, 98);
            this.btnDirectToTra.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDirectToTra.Name = "btnDirectToTra";
            this.btnDirectToTra.Size = new System.Drawing.Size(56, 56);
            this.btnDirectToTra.TabIndex = 1;
            this.btnDirectToTra.Text = "materialFloatingActionButton3";
            this.btnDirectToTra.UseVisualStyleBackColor = true;
            this.btnDirectToTra.Click += new System.EventHandler(this.btnDirectToTra_Click);
            // 
            // chrHome
            // 
            this.chrHome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chrHome.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chrHome.Legends.Add(legend2);
            this.chrHome.Location = new System.Drawing.Point(16, 3);
            this.chrHome.Name = "chrHome";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chrHome.Series.Add(series2);
            this.chrHome.Size = new System.Drawing.Size(589, 589);
            this.chrHome.TabIndex = 23;
            this.chrHome.Text = "chrHome";
            // 
            // materialCard4
            // 
            this.materialCard4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialCard4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard4.Controls.Add(this.chrHome);
            this.materialCard4.Depth = 0;
            this.materialCard4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard4.Location = new System.Drawing.Point(365, 78);
            this.materialCard4.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard4.Name = "materialCard4";
            this.materialCard4.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard4.Size = new System.Drawing.Size(620, 569);
            this.materialCard4.TabIndex = 24;
            // 
            // frmHome
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1024, 819);
            this.Controls.Add(this.materialCard4);
            this.Controls.Add(this.materialCard2);
            this.Controls.Add(this.materialCardDT);
            this.Controls.Add(this.swtDarkMode);
            this.Controls.Add(this.materialCard3);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.StatusAndActionBar_None;
            this.Name = "frmHome";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Text = "frmHome";
            this.Load += new System.EventHandler(this.frmHome_Load);
            this.materialCard3.ResumeLayout(false);
            this.materialCard3.PerformLayout();
            this.materialCardDT.ResumeLayout(false);
            this.materialCardDT.PerformLayout();
            this.materialCard2.ResumeLayout(false);
            this.materialCard2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrHome)).EndInit();
            this.materialCard4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialCard materialCard3;
        private MaterialSkin.Controls.MaterialFloatingActionButton btnDirectToThue;
        private MaterialSkin.Controls.MaterialSwitch swtDarkMode;
        private MaterialSkin.Controls.MaterialLabel lblSoDonThueThang;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialCard materialCardDT;
        private MaterialSkin.Controls.MaterialLabel lblDoanhThu;
        private MaterialSkin.Controls.MaterialLabel lblDoanhThuThang;
        private MaterialSkin.Controls.MaterialFloatingActionButton btnDirectToBaoCao;
        private MaterialSkin.Controls.MaterialCard materialCard2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel lblSoDonThueChuaTra;
        private MaterialSkin.Controls.MaterialFloatingActionButton btnDirectToTra;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrHome;
        private MaterialSkin.Controls.MaterialCard materialCard4;
    }
}