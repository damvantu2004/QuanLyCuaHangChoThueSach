namespace BAEK_PERCENT.Forms
{
    partial class frmKhach
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
            this.btnTimKiem = new MaterialSkin.Controls.MaterialButton();
            this.txtTimKiem = new MaterialSkin.Controls.MaterialTextBox2();
            this.btnHuy = new MaterialSkin.Controls.MaterialButton();
            this.btnLuu = new MaterialSkin.Controls.MaterialButton();
            this.btnXoa = new MaterialSkin.Controls.MaterialButton();
            this.btnSua = new MaterialSkin.Controls.MaterialButton();
            this.btnThem = new MaterialSkin.Controls.MaterialButton();
            this.txtTenKH = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.txtMaKH = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.listViewKhach = new MaterialSkin.Controls.MaterialListView();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.rdoNam = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdoNu = new MaterialSkin.Controls.MaterialRadioButton();
            this.txtDiaChi = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.txtNgaySinh = new MaterialSkin.Controls.MaterialMaskedTextBox();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.txtSDT = new MaterialSkin.Controls.MaterialMaskedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTimKiem.AutoSize = false;
            this.btnTimKiem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnTimKiem.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnTimKiem.Depth = 0;
            this.btnTimKiem.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.HighEmphasis = true;
            this.btnTimKiem.Icon = null;
            this.btnTimKiem.Location = new System.Drawing.Point(904, 27);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(4, 12, 4, 6);
            this.btnTimKiem.MaximumSize = new System.Drawing.Size(96, 40);
            this.btnTimKiem.MinimumSize = new System.Drawing.Size(0, 48);
            this.btnTimKiem.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnTimKiem.Padding = new System.Windows.Forms.Padding(3);
            this.btnTimKiem.Size = new System.Drawing.Size(96, 48);
            this.btnTimKiem.TabIndex = 47;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnTimKiem.UseAccentColor = false;
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiem.AnimateReadOnly = false;
            this.txtTimKiem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtTimKiem.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTimKiem.Depth = 0;
            this.txtTimKiem.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.HideSelection = true;
            this.txtTimKiem.LeadingIcon = null;
            this.txtTimKiem.Location = new System.Drawing.Point(27, 27);
            this.txtTimKiem.MaximumSize = new System.Drawing.Size(0, 40);
            this.txtTimKiem.MaxLength = 32767;
            this.txtTimKiem.MinimumSize = new System.Drawing.Size(0, 48);
            this.txtTimKiem.MouseState = MaterialSkin.MouseState.OUT;
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PasswordChar = '\0';
            this.txtTimKiem.PrefixSuffixText = null;
            this.txtTimKiem.ReadOnly = false;
            this.txtTimKiem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTimKiem.SelectedText = "";
            this.txtTimKiem.SelectionLength = 0;
            this.txtTimKiem.SelectionStart = 0;
            this.txtTimKiem.ShortcutsEnabled = true;
            this.txtTimKiem.Size = new System.Drawing.Size(860, 48);
            this.txtTimKiem.TabIndex = 46;
            this.txtTimKiem.TabStop = false;
            this.txtTimKiem.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTimKiem.TrailingIcon = null;
            this.txtTimKiem.UseSystemPasswordChar = false;
            this.txtTimKiem.Enter += new System.EventHandler(this.txtTimKiem_Enter);
            this.txtTimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimKiem_KeyDown);
            this.txtTimKiem.Leave += new System.EventHandler(this.txtTimKiem_Leave);
            // 
            // btnHuy
            // 
            this.btnHuy.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnHuy.AutoSize = false;
            this.btnHuy.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnHuy.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnHuy.Depth = 0;
            this.btnHuy.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.HighEmphasis = true;
            this.btnHuy.Icon = null;
            this.btnHuy.Location = new System.Drawing.Point(687, 756);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnHuy.MaximumSize = new System.Drawing.Size(0, 36);
            this.btnHuy.MinimumSize = new System.Drawing.Size(80, 36);
            this.btnHuy.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnHuy.Size = new System.Drawing.Size(80, 36);
            this.btnHuy.TabIndex = 45;
            this.btnHuy.Text = "Huỷ";
            this.btnHuy.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnHuy.UseAccentColor = false;
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnLuu.AutoSize = false;
            this.btnLuu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLuu.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnLuu.Depth = 0;
            this.btnLuu.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.HighEmphasis = true;
            this.btnLuu.Icon = null;
            this.btnLuu.Location = new System.Drawing.Point(579, 756);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnLuu.MaximumSize = new System.Drawing.Size(0, 36);
            this.btnLuu.MinimumSize = new System.Drawing.Size(80, 36);
            this.btnLuu.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnLuu.Size = new System.Drawing.Size(80, 36);
            this.btnLuu.TabIndex = 44;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnLuu.UseAccentColor = false;
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnXoa.AutoSize = false;
            this.btnXoa.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnXoa.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnXoa.Depth = 0;
            this.btnXoa.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.HighEmphasis = true;
            this.btnXoa.Icon = null;
            this.btnXoa.Location = new System.Drawing.Point(475, 756);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnXoa.MaximumSize = new System.Drawing.Size(0, 36);
            this.btnXoa.MinimumSize = new System.Drawing.Size(80, 36);
            this.btnXoa.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnXoa.Size = new System.Drawing.Size(80, 36);
            this.btnXoa.TabIndex = 43;
            this.btnXoa.Text = "Xoá";
            this.btnXoa.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnXoa.UseAccentColor = false;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSua.AutoSize = false;
            this.btnSua.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSua.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSua.Depth = 0;
            this.btnSua.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.HighEmphasis = true;
            this.btnSua.Icon = null;
            this.btnSua.Location = new System.Drawing.Point(373, 756);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSua.MaximumSize = new System.Drawing.Size(0, 36);
            this.btnSua.MinimumSize = new System.Drawing.Size(80, 36);
            this.btnSua.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSua.Name = "btnSua";
            this.btnSua.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSua.Size = new System.Drawing.Size(80, 36);
            this.btnSua.TabIndex = 42;
            this.btnSua.Text = "Sửa";
            this.btnSua.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSua.UseAccentColor = false;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnThem.AutoSize = false;
            this.btnThem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnThem.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnThem.Depth = 0;
            this.btnThem.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.HighEmphasis = true;
            this.btnThem.Icon = null;
            this.btnThem.Location = new System.Drawing.Point(274, 756);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnThem.MaximumSize = new System.Drawing.Size(0, 36);
            this.btnThem.MinimumSize = new System.Drawing.Size(80, 36);
            this.btnThem.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnThem.Name = "btnThem";
            this.btnThem.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnThem.Size = new System.Drawing.Size(80, 36);
            this.btnThem.TabIndex = 41;
            this.btnThem.Text = "Thêm";
            this.btnThem.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnThem.UseAccentColor = false;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtTenKH
            // 
            this.txtTenKH.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenKH.AnimateReadOnly = false;
            this.txtTenKH.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtTenKH.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTenKH.Depth = 0;
            this.txtTenKH.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenKH.HideSelection = true;
            this.txtTenKH.LeadingIcon = null;
            this.txtTenKH.Location = new System.Drawing.Point(418, 27);
            this.txtTenKH.MaximumSize = new System.Drawing.Size(0, 40);
            this.txtTenKH.MaxLength = 32767;
            this.txtTenKH.MinimumSize = new System.Drawing.Size(0, 48);
            this.txtTenKH.MouseState = MaterialSkin.MouseState.OUT;
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.PasswordChar = '\0';
            this.txtTenKH.PrefixSuffixText = null;
            this.txtTenKH.ReadOnly = false;
            this.txtTenKH.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTenKH.SelectedText = "";
            this.txtTenKH.SelectionLength = 0;
            this.txtTenKH.SelectionStart = 0;
            this.txtTenKH.ShortcutsEnabled = true;
            this.txtTenKH.Size = new System.Drawing.Size(270, 48);
            this.txtTenKH.TabIndex = 40;
            this.txtTenKH.TabStop = false;
            this.txtTenKH.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTenKH.TrailingIcon = null;
            this.txtTenKH.UseSystemPasswordChar = false;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(293, 41);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(119, 19);
            this.materialLabel2.TabIndex = 39;
            this.materialLabel2.Text = "Tên khách hàng:";
            // 
            // txtMaKH
            // 
            this.txtMaKH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMaKH.AnimateReadOnly = true;
            this.txtMaKH.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtMaKH.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtMaKH.Depth = 0;
            this.txtMaKH.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaKH.HideSelection = true;
            this.txtMaKH.LeadingIcon = null;
            this.txtMaKH.Location = new System.Drawing.Point(140, 27);
            this.txtMaKH.MaximumSize = new System.Drawing.Size(0, 40);
            this.txtMaKH.MaxLength = 32767;
            this.txtMaKH.MinimumSize = new System.Drawing.Size(0, 48);
            this.txtMaKH.MouseState = MaterialSkin.MouseState.OUT;
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.PasswordChar = '\0';
            this.txtMaKH.PrefixSuffixText = null;
            this.txtMaKH.ReadOnly = false;
            this.txtMaKH.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMaKH.SelectedText = "";
            this.txtMaKH.SelectionLength = 0;
            this.txtMaKH.SelectionStart = 0;
            this.txtMaKH.ShortcutsEnabled = true;
            this.txtMaKH.Size = new System.Drawing.Size(140, 48);
            this.txtMaKH.TabIndex = 38;
            this.txtMaKH.TabStop = false;
            this.txtMaKH.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtMaKH.TrailingIcon = null;
            this.txtMaKH.UseSystemPasswordChar = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(17, 41);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(115, 19);
            this.materialLabel1.TabIndex = 37;
            this.materialLabel1.Text = "Mã khách hàng:";
            // 
            // listViewKhach
            // 
            this.listViewKhach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewKhach.AutoSizeTable = false;
            this.listViewKhach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.listViewKhach.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewKhach.CheckBoxes = true;
            this.listViewKhach.Depth = 0;
            this.listViewKhach.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewKhach.FullRowSelect = true;
            this.listViewKhach.HideSelection = false;
            this.listViewKhach.Location = new System.Drawing.Point(27, 270);
            this.listViewKhach.MinimumSize = new System.Drawing.Size(820, 378);
            this.listViewKhach.MouseLocation = new System.Drawing.Point(-1, -1);
            this.listViewKhach.MouseState = MaterialSkin.MouseState.OUT;
            this.listViewKhach.Name = "listViewKhach";
            this.listViewKhach.OwnerDraw = true;
            this.listViewKhach.Size = new System.Drawing.Size(973, 461);
            this.listViewKhach.TabIndex = 36;
            this.listViewKhach.UseCompatibleStateImageBehavior = false;
            this.listViewKhach.View = System.Windows.Forms.View.Details;
            this.listViewKhach.SelectedIndexChanged += new System.EventHandler(this.listViewKhach_SelectedIndexChanged);
            // 
            // materialLabel3
            // 
            this.materialLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(742, 41);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(64, 19);
            this.materialLabel3.TabIndex = 48;
            this.materialLabel3.Text = "Giới tính:";
            // 
            // rdoNam
            // 
            this.rdoNam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rdoNam.AutoSize = true;
            this.rdoNam.Depth = 0;
            this.rdoNam.Location = new System.Drawing.Point(812, 31);
            this.rdoNam.Margin = new System.Windows.Forms.Padding(0);
            this.rdoNam.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdoNam.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdoNam.Name = "rdoNam";
            this.rdoNam.Ripple = true;
            this.rdoNam.Size = new System.Drawing.Size(69, 37);
            this.rdoNam.TabIndex = 49;
            this.rdoNam.TabStop = true;
            this.rdoNam.Text = "Nam";
            this.rdoNam.UseVisualStyleBackColor = true;
            // 
            // rdoNu
            // 
            this.rdoNu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rdoNu.AutoSize = true;
            this.rdoNu.Depth = 0;
            this.rdoNu.Location = new System.Drawing.Point(894, 31);
            this.rdoNu.Margin = new System.Windows.Forms.Padding(0);
            this.rdoNu.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdoNu.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdoNu.Name = "rdoNu";
            this.rdoNu.Ripple = true;
            this.rdoNu.Size = new System.Drawing.Size(56, 37);
            this.rdoNu.TabIndex = 50;
            this.rdoNu.TabStop = true;
            this.rdoNu.Text = "Nữ";
            this.rdoNu.UseVisualStyleBackColor = true;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiaChi.AnimateReadOnly = false;
            this.txtDiaChi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtDiaChi.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDiaChi.Depth = 0;
            this.txtDiaChi.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaChi.HideSelection = true;
            this.txtDiaChi.LeadingIcon = null;
            this.txtDiaChi.Location = new System.Drawing.Point(418, 90);
            this.txtDiaChi.MaximumSize = new System.Drawing.Size(0, 40);
            this.txtDiaChi.MaxLength = 32767;
            this.txtDiaChi.MinimumSize = new System.Drawing.Size(0, 48);
            this.txtDiaChi.MouseState = MaterialSkin.MouseState.OUT;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.PasswordChar = '\0';
            this.txtDiaChi.PrefixSuffixText = null;
            this.txtDiaChi.ReadOnly = false;
            this.txtDiaChi.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDiaChi.SelectedText = "";
            this.txtDiaChi.SelectionLength = 0;
            this.txtDiaChi.SelectionStart = 0;
            this.txtDiaChi.ShortcutsEnabled = true;
            this.txtDiaChi.Size = new System.Drawing.Size(270, 48);
            this.txtDiaChi.TabIndex = 54;
            this.txtDiaChi.TabStop = false;
            this.txtDiaChi.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDiaChi.TrailingIcon = null;
            this.txtDiaChi.UseSystemPasswordChar = false;
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.Location = new System.Drawing.Point(358, 104);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(54, 19);
            this.materialLabel4.TabIndex = 53;
            this.materialLabel4.Text = "Địa chỉ:";
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.Location = new System.Drawing.Point(56, 104);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(76, 19);
            this.materialLabel5.TabIndex = 51;
            this.materialLabel5.Text = "Ngày sinh:";
            // 
            // txtNgaySinh
            // 
            this.txtNgaySinh.AllowPromptAsInput = true;
            this.txtNgaySinh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNgaySinh.AnimateReadOnly = false;
            this.txtNgaySinh.AsciiOnly = false;
            this.txtNgaySinh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtNgaySinh.BeepOnError = false;
            this.txtNgaySinh.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.txtNgaySinh.Depth = 0;
            this.txtNgaySinh.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtNgaySinh.HidePromptOnLeave = false;
            this.txtNgaySinh.HideSelection = true;
            this.txtNgaySinh.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.txtNgaySinh.LeadingIcon = null;
            this.txtNgaySinh.Location = new System.Drawing.Point(140, 90);
            this.txtNgaySinh.Mask = "00/00/0000";
            this.txtNgaySinh.MaximumSize = new System.Drawing.Size(0, 40);
            this.txtNgaySinh.MaxLength = 32767;
            this.txtNgaySinh.MinimumSize = new System.Drawing.Size(0, 48);
            this.txtNgaySinh.MouseState = MaterialSkin.MouseState.OUT;
            this.txtNgaySinh.Name = "txtNgaySinh";
            this.txtNgaySinh.PasswordChar = '\0';
            this.txtNgaySinh.PrefixSuffixText = null;
            this.txtNgaySinh.PromptChar = '_';
            this.txtNgaySinh.ReadOnly = false;
            this.txtNgaySinh.RejectInputOnFirstFailure = false;
            this.txtNgaySinh.ResetOnPrompt = true;
            this.txtNgaySinh.ResetOnSpace = true;
            this.txtNgaySinh.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNgaySinh.SelectedText = "";
            this.txtNgaySinh.SelectionLength = 0;
            this.txtNgaySinh.SelectionStart = 0;
            this.txtNgaySinh.ShortcutsEnabled = true;
            this.txtNgaySinh.Size = new System.Drawing.Size(140, 48);
            this.txtNgaySinh.SkipLiterals = true;
            this.txtNgaySinh.TabIndex = 55;
            this.txtNgaySinh.TabStop = false;
            this.txtNgaySinh.Text = "  /  /";
            this.txtNgaySinh.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtNgaySinh.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.txtNgaySinh.TrailingIcon = null;
            this.txtNgaySinh.UseSystemPasswordChar = false;
            this.txtNgaySinh.ValidatingType = null;
            // 
            // materialLabel7
            // 
            this.materialLabel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel7.Location = new System.Drawing.Point(707, 104);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(99, 19);
            this.materialLabel7.TabIndex = 77;
            this.materialLabel7.Text = "Số điện thoại:";
            // 
            // txtSDT
            // 
            this.txtSDT.AllowPromptAsInput = true;
            this.txtSDT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSDT.AnimateReadOnly = false;
            this.txtSDT.AsciiOnly = false;
            this.txtSDT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtSDT.BeepOnError = false;
            this.txtSDT.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.txtSDT.Depth = 0;
            this.txtSDT.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtSDT.HidePromptOnLeave = false;
            this.txtSDT.HideSelection = true;
            this.txtSDT.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.txtSDT.LeadingIcon = null;
            this.txtSDT.Location = new System.Drawing.Point(812, 90);
            this.txtSDT.Mask = "000 000 0000";
            this.txtSDT.MaximumSize = new System.Drawing.Size(0, 40);
            this.txtSDT.MaxLength = 32767;
            this.txtSDT.MinimumSize = new System.Drawing.Size(0, 48);
            this.txtSDT.MouseState = MaterialSkin.MouseState.OUT;
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.PasswordChar = '\0';
            this.txtSDT.PrefixSuffixText = null;
            this.txtSDT.PromptChar = '_';
            this.txtSDT.ReadOnly = false;
            this.txtSDT.RejectInputOnFirstFailure = false;
            this.txtSDT.ResetOnPrompt = true;
            this.txtSDT.ResetOnSpace = true;
            this.txtSDT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSDT.SelectedText = "";
            this.txtSDT.SelectionLength = 0;
            this.txtSDT.SelectionStart = 0;
            this.txtSDT.ShortcutsEnabled = true;
            this.txtSDT.Size = new System.Drawing.Size(140, 48);
            this.txtSDT.SkipLiterals = true;
            this.txtSDT.TabIndex = 79;
            this.txtSDT.TabStop = false;
            this.txtSDT.Text = "        ";
            this.txtSDT.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSDT.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.txtSDT.TrailingIcon = null;
            this.txtSDT.UseSystemPasswordChar = false;
            this.txtSDT.ValidatingType = null;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rdoNam);
            this.groupBox1.Controls.Add(this.txtSDT);
            this.groupBox1.Controls.Add(this.materialLabel1);
            this.groupBox1.Controls.Add(this.materialLabel7);
            this.groupBox1.Controls.Add(this.txtMaKH);
            this.groupBox1.Controls.Add(this.txtNgaySinh);
            this.groupBox1.Controls.Add(this.materialLabel2);
            this.groupBox1.Controls.Add(this.txtDiaChi);
            this.groupBox1.Controls.Add(this.txtTenKH);
            this.groupBox1.Controls.Add(this.materialLabel4);
            this.groupBox1.Controls.Add(this.materialLabel3);
            this.groupBox1.Controls.Add(this.materialLabel5);
            this.groupBox1.Controls.Add(this.rdoNu);
            this.groupBox1.Location = new System.Drawing.Point(27, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(973, 161);
            this.groupBox1.TabIndex = 80;
            this.groupBox1.TabStop = false;
            // 
            // frmKhach
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1024, 819);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.listViewKhach);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.StatusAndActionBar_None;
            this.Name = "frmKhach";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Text = "frmKhach";
            this.Load += new System.EventHandler(this.frmKhach_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton btnTimKiem;
        private MaterialSkin.Controls.MaterialTextBox2 txtTimKiem;
        private MaterialSkin.Controls.MaterialButton btnHuy;
        private MaterialSkin.Controls.MaterialButton btnLuu;
        private MaterialSkin.Controls.MaterialButton btnXoa;
        private MaterialSkin.Controls.MaterialButton btnSua;
        private MaterialSkin.Controls.MaterialButton btnThem;
        private MaterialSkin.Controls.MaterialTextBox2 txtTenKH;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialTextBox2 txtMaKH;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialListView listViewKhach;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialRadioButton rdoNam;
        private MaterialSkin.Controls.MaterialRadioButton rdoNu;
        private MaterialSkin.Controls.MaterialTextBox2 txtDiaChi;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialMaskedTextBox txtNgaySinh;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private MaterialSkin.Controls.MaterialMaskedTextBox txtSDT;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}