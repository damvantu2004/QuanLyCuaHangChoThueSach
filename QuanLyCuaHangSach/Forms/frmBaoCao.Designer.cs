namespace BAEK_PERCENT.Forms
{
    partial class frmBaoCao
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.cboBaoCao = new MaterialSkin.Controls.MaterialComboBox();
            this.dtpNgayBD = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayKT = new System.Windows.Forms.DateTimePicker();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.btnXuatBaoCao = new MaterialSkin.Controls.MaterialButton();
            this.chrBaoCao = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnTaoBaoCao = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.chrBaoCao)).BeginInit();
            this.SuspendLayout();
            // 
            // cboBaoCao
            // 
            this.cboBaoCao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBaoCao.AutoResize = false;
            this.cboBaoCao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboBaoCao.Depth = 0;
            this.cboBaoCao.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboBaoCao.DropDownHeight = 174;
            this.cboBaoCao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBaoCao.DropDownWidth = 121;
            this.cboBaoCao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboBaoCao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cboBaoCao.FormattingEnabled = true;
            this.cboBaoCao.IntegralHeight = false;
            this.cboBaoCao.ItemHeight = 43;
            this.cboBaoCao.Location = new System.Drawing.Point(46, 31);
            this.cboBaoCao.MaxDropDownItems = 4;
            this.cboBaoCao.MouseState = MaterialSkin.MouseState.OUT;
            this.cboBaoCao.Name = "cboBaoCao";
            this.cboBaoCao.Size = new System.Drawing.Size(934, 49);
            this.cboBaoCao.StartIndex = 0;
            this.cboBaoCao.TabIndex = 0;
            this.cboBaoCao.SelectedIndexChanged += new System.EventHandler(this.cboBaoCao_SelectedIndexChanged);
            // 
            // dtpNgayBD
            // 
            this.dtpNgayBD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpNgayBD.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayBD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayBD.Location = new System.Drawing.Point(147, 108);
            this.dtpNgayBD.MaximumSize = new System.Drawing.Size(220, 30);
            this.dtpNgayBD.MinimumSize = new System.Drawing.Size(220, 30);
            this.dtpNgayBD.Name = "dtpNgayBD";
            this.dtpNgayBD.Size = new System.Drawing.Size(220, 30);
            this.dtpNgayBD.TabIndex = 1;
            this.dtpNgayBD.ValueChanged += new System.EventHandler(this.dtpNgayBD_ValueChanged);
            // 
            // dtpNgayKT
            // 
            this.dtpNgayKT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpNgayKT.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayKT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayKT.Location = new System.Drawing.Point(472, 108);
            this.dtpNgayKT.MaximumSize = new System.Drawing.Size(220, 30);
            this.dtpNgayKT.MinimumSize = new System.Drawing.Size(220, 30);
            this.dtpNgayKT.Name = "dtpNgayKT";
            this.dtpNgayKT.Size = new System.Drawing.Size(220, 30);
            this.dtpNgayKT.TabIndex = 2;
            this.dtpNgayKT.ValueChanged += new System.EventHandler(this.dtpNgayKT_ValueChanged);
            // 
            // materialLabel1
            // 
            this.materialLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(75, 113);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(60, 19);
            this.materialLabel1.TabIndex = 3;
            this.materialLabel1.Text = "Từ ngày";
            // 
            // materialLabel2
            // 
            this.materialLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(385, 113);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(67, 19);
            this.materialLabel2.TabIndex = 4;
            this.materialLabel2.Text = "đến ngày";
            // 
            // btnXuatBaoCao
            // 
            this.btnXuatBaoCao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXuatBaoCao.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnXuatBaoCao.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnXuatBaoCao.Depth = 0;
            this.btnXuatBaoCao.HighEmphasis = true;
            this.btnXuatBaoCao.Icon = null;
            this.btnXuatBaoCao.Location = new System.Drawing.Point(855, 108);
            this.btnXuatBaoCao.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnXuatBaoCao.MaximumSize = new System.Drawing.Size(0, 30);
            this.btnXuatBaoCao.MinimumSize = new System.Drawing.Size(0, 30);
            this.btnXuatBaoCao.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnXuatBaoCao.Name = "btnXuatBaoCao";
            this.btnXuatBaoCao.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnXuatBaoCao.Size = new System.Drawing.Size(125, 30);
            this.btnXuatBaoCao.TabIndex = 5;
            this.btnXuatBaoCao.Text = "Xuất báo cáo";
            this.btnXuatBaoCao.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnXuatBaoCao.UseAccentColor = false;
            this.btnXuatBaoCao.UseVisualStyleBackColor = true;
            this.btnXuatBaoCao.Click += new System.EventHandler(this.btnXuatBaoCao_Click);
            // 
            // chrBaoCao
            // 
            this.chrBaoCao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chrBaoCao.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chrBaoCao.Legends.Add(legend1);
            this.chrBaoCao.Location = new System.Drawing.Point(46, 166);
            this.chrBaoCao.Name = "chrBaoCao";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chrBaoCao.Series.Add(series1);
            this.chrBaoCao.Size = new System.Drawing.Size(934, 607);
            this.chrBaoCao.TabIndex = 6;
            this.chrBaoCao.Text = "Chart";
            // 
            // btnTaoBaoCao
            // 
            this.btnTaoBaoCao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTaoBaoCao.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnTaoBaoCao.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnTaoBaoCao.Depth = 0;
            this.btnTaoBaoCao.HighEmphasis = true;
            this.btnTaoBaoCao.Icon = null;
            this.btnTaoBaoCao.Location = new System.Drawing.Point(717, 108);
            this.btnTaoBaoCao.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnTaoBaoCao.MaximumSize = new System.Drawing.Size(0, 30);
            this.btnTaoBaoCao.MinimumSize = new System.Drawing.Size(0, 30);
            this.btnTaoBaoCao.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnTaoBaoCao.Name = "btnTaoBaoCao";
            this.btnTaoBaoCao.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnTaoBaoCao.Size = new System.Drawing.Size(116, 30);
            this.btnTaoBaoCao.TabIndex = 7;
            this.btnTaoBaoCao.Text = "Tạo báo cáo";
            this.btnTaoBaoCao.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnTaoBaoCao.UseAccentColor = false;
            this.btnTaoBaoCao.UseVisualStyleBackColor = true;
            this.btnTaoBaoCao.Click += new System.EventHandler(this.btnTaoBaoCao_Click);
            // 
            // frmBaoCao
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1024, 819);
            this.Controls.Add(this.btnTaoBaoCao);
            this.Controls.Add(this.chrBaoCao);
            this.Controls.Add(this.btnXuatBaoCao);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.dtpNgayKT);
            this.Controls.Add(this.dtpNgayBD);
            this.Controls.Add(this.cboBaoCao);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.StatusAndActionBar_None;
            this.Name = "frmBaoCao";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Text = "frmBaoCao";
            this.Load += new System.EventHandler(this.frmBaoCao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chrBaoCao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialComboBox cboBaoCao;
        private System.Windows.Forms.DateTimePicker dtpNgayBD;
        private System.Windows.Forms.DateTimePicker dtpNgayKT;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialButton btnXuatBaoCao;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrBaoCao;
        private MaterialSkin.Controls.MaterialButton btnTaoBaoCao;
    }
}