namespace BAEK_PERCENT.Forms
{
    partial class frmThongTin
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
            this.btnLogOut = new MaterialSkin.Controls.MaterialButton();
            this.txtMaNV = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.swtEdit = new MaterialSkin.Controls.MaterialSwitch();
            this.btnLuu = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.txtTenDangNhap = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            this.txtMatKhau = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
            this.rdoNam = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdoNu = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialLabel10 = new MaterialSkin.Controls.MaterialLabel();
            this.cboPriv = new MaterialSkin.Controls.MaterialComboBox();
            this.txtTenNV = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtDiaChi = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtNgaySinh = new MaterialSkin.Controls.MaterialMaskedTextBox();
            this.txtSDT = new MaterialSkin.Controls.MaterialMaskedTextBox();
            this.SuspendLayout();
            // 
            // btnLogOut
            // 
            this.btnLogOut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLogOut.BackColor = System.Drawing.Color.Coral;
            this.btnLogOut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnLogOut.Depth = 0;
            this.btnLogOut.ForeColor = System.Drawing.Color.IndianRed;
            this.btnLogOut.HighEmphasis = true;
            this.btnLogOut.Icon = null;
            this.btnLogOut.Location = new System.Drawing.Point(49, 607);
            this.btnLogOut.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnLogOut.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnLogOut.Size = new System.Drawing.Size(103, 36);
            this.btnLogOut.TabIndex = 1;
            this.btnLogOut.Text = "Đăng xuất";
            this.btnLogOut.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnLogOut.UseAccentColor = false;
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // txtMaNV
            // 
            this.txtMaNV.AnimateReadOnly = false;
            this.txtMaNV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtMaNV.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtMaNV.Depth = 0;
            this.txtMaNV.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtMaNV.HideSelection = true;
            this.txtMaNV.LeadingIcon = null;
            this.txtMaNV.Location = new System.Drawing.Point(49, 177);
            this.txtMaNV.MaxLength = 32767;
            this.txtMaNV.MouseState = MaterialSkin.MouseState.OUT;
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.PasswordChar = '\0';
            this.txtMaNV.PrefixSuffixText = null;
            this.txtMaNV.ReadOnly = false;
            this.txtMaNV.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMaNV.SelectedText = "";
            this.txtMaNV.SelectionLength = 0;
            this.txtMaNV.SelectionStart = 0;
            this.txtMaNV.ShortcutsEnabled = true;
            this.txtMaNV.Size = new System.Drawing.Size(387, 48);
            this.txtMaNV.TabIndex = 2;
            this.txtMaNV.TabStop = false;
            this.txtMaNV.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtMaNV.TrailingIcon = null;
            this.txtMaNV.UseSystemPasswordChar = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel1.Location = new System.Drawing.Point(49, 143);
            this.materialLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(126, 24);
            this.materialLabel1.TabIndex = 20;
            this.materialLabel1.Text = "Mã nhân viên:";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel2.Location = new System.Drawing.Point(491, 143);
            this.materialLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(131, 24);
            this.materialLabel2.TabIndex = 28;
            this.materialLabel2.Text = "Tên nhân viên:";
            // 
            // swtEdit
            // 
            this.swtEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.swtEdit.AutoSize = true;
            this.swtEdit.Depth = 0;
            this.swtEdit.Location = new System.Drawing.Point(850, 40);
            this.swtEdit.Margin = new System.Windows.Forms.Padding(0);
            this.swtEdit.MouseLocation = new System.Drawing.Point(-1, -1);
            this.swtEdit.MouseState = MaterialSkin.MouseState.HOVER;
            this.swtEdit.Name = "swtEdit";
            this.swtEdit.Ripple = true;
            this.swtEdit.Size = new System.Drawing.Size(130, 37);
            this.swtEdit.TabIndex = 29;
            this.swtEdit.Text = "Chỉnh sửa";
            this.swtEdit.UseVisualStyleBackColor = true;
            this.swtEdit.CheckedChanged += new System.EventHandler(this.swtEdit_CheckedChanged);
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLuu.BackColor = System.Drawing.Color.Coral;
            this.btnLuu.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnLuu.Depth = 0;
            this.btnLuu.ForeColor = System.Drawing.Color.IndianRed;
            this.btnLuu.HighEmphasis = true;
            this.btnLuu.Icon = null;
            this.btnLuu.Location = new System.Drawing.Point(916, 607);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnLuu.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnLuu.Size = new System.Drawing.Size(64, 36);
            this.btnLuu.TabIndex = 30;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnLuu.UseAccentColor = false;
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel3.Location = new System.Drawing.Point(491, 251);
            this.materialLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(94, 24);
            this.materialLabel3.TabIndex = 34;
            this.materialLabel3.Text = "Ngày sinh:";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel4.Location = new System.Drawing.Point(49, 251);
            this.materialLabel4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(139, 24);
            this.materialLabel4.TabIndex = 32;
            this.materialLabel4.Text = "Tên đăng nhập:";
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.AnimateReadOnly = false;
            this.txtTenDangNhap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtTenDangNhap.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTenDangNhap.Depth = 0;
            this.txtTenDangNhap.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtTenDangNhap.HideSelection = true;
            this.txtTenDangNhap.LeadingIcon = null;
            this.txtTenDangNhap.Location = new System.Drawing.Point(49, 285);
            this.txtTenDangNhap.MaxLength = 32767;
            this.txtTenDangNhap.MouseState = MaterialSkin.MouseState.OUT;
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.PasswordChar = '\0';
            this.txtTenDangNhap.PrefixSuffixText = null;
            this.txtTenDangNhap.ReadOnly = false;
            this.txtTenDangNhap.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTenDangNhap.SelectedText = "";
            this.txtTenDangNhap.SelectionLength = 0;
            this.txtTenDangNhap.SelectionStart = 0;
            this.txtTenDangNhap.ShortcutsEnabled = true;
            this.txtTenDangNhap.Size = new System.Drawing.Size(387, 48);
            this.txtTenDangNhap.TabIndex = 31;
            this.txtTenDangNhap.TabStop = false;
            this.txtTenDangNhap.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTenDangNhap.TrailingIcon = null;
            this.txtTenDangNhap.UseSystemPasswordChar = false;
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel5.Location = new System.Drawing.Point(491, 473);
            this.materialLabel5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(123, 24);
            this.materialLabel5.TabIndex = 42;
            this.materialLabel5.Text = "Số điện thoại:";
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel6.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel6.Location = new System.Drawing.Point(49, 473);
            this.materialLabel6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(63, 24);
            this.materialLabel6.TabIndex = 40;
            this.materialLabel6.Text = "Quyền:";
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel7.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel7.Location = new System.Drawing.Point(491, 360);
            this.materialLabel7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(66, 24);
            this.materialLabel7.TabIndex = 38;
            this.materialLabel7.Text = "Địa chỉ:";
            // 
            // materialLabel8
            // 
            this.materialLabel8.AutoSize = true;
            this.materialLabel8.Depth = 0;
            this.materialLabel8.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel8.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel8.Location = new System.Drawing.Point(49, 360);
            this.materialLabel8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel8.Name = "materialLabel8";
            this.materialLabel8.Size = new System.Drawing.Size(90, 24);
            this.materialLabel8.TabIndex = 36;
            this.materialLabel8.Text = "Mật khẩu:";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.AnimateReadOnly = false;
            this.txtMatKhau.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtMatKhau.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtMatKhau.Depth = 0;
            this.txtMatKhau.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtMatKhau.HideSelection = true;
            this.txtMatKhau.LeadingIcon = null;
            this.txtMatKhau.Location = new System.Drawing.Point(49, 394);
            this.txtMatKhau.MaxLength = 32767;
            this.txtMatKhau.MouseState = MaterialSkin.MouseState.OUT;
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '\0';
            this.txtMatKhau.PrefixSuffixText = null;
            this.txtMatKhau.ReadOnly = false;
            this.txtMatKhau.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMatKhau.SelectedText = "";
            this.txtMatKhau.SelectionLength = 0;
            this.txtMatKhau.SelectionStart = 0;
            this.txtMatKhau.ShortcutsEnabled = true;
            this.txtMatKhau.Size = new System.Drawing.Size(387, 48);
            this.txtMatKhau.TabIndex = 35;
            this.txtMatKhau.TabStop = false;
            this.txtMatKhau.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtMatKhau.TrailingIcon = null;
            this.txtMatKhau.UseSystemPasswordChar = false;
            // 
            // materialLabel9
            // 
            this.materialLabel9.AutoSize = true;
            this.materialLabel9.Depth = 0;
            this.materialLabel9.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel9.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel9.Location = new System.Drawing.Point(656, 251);
            this.materialLabel9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel9.Name = "materialLabel9";
            this.materialLabel9.Size = new System.Drawing.Size(81, 24);
            this.materialLabel9.TabIndex = 43;
            this.materialLabel9.Text = "Giới tính:";
            // 
            // rdoNam
            // 
            this.rdoNam.AutoSize = true;
            this.rdoNam.Depth = 0;
            this.rdoNam.Location = new System.Drawing.Point(651, 288);
            this.rdoNam.Margin = new System.Windows.Forms.Padding(0);
            this.rdoNam.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdoNam.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdoNam.Name = "rdoNam";
            this.rdoNam.Ripple = true;
            this.rdoNam.Size = new System.Drawing.Size(69, 37);
            this.rdoNam.TabIndex = 44;
            this.rdoNam.TabStop = true;
            this.rdoNam.Text = "Nam";
            this.rdoNam.UseVisualStyleBackColor = true;
            // 
            // rdoNu
            // 
            this.rdoNu.AutoSize = true;
            this.rdoNu.Depth = 0;
            this.rdoNu.Location = new System.Drawing.Point(744, 288);
            this.rdoNu.Margin = new System.Windows.Forms.Padding(0);
            this.rdoNu.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdoNu.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdoNu.Name = "rdoNu";
            this.rdoNu.Ripple = true;
            this.rdoNu.Size = new System.Drawing.Size(56, 37);
            this.rdoNu.TabIndex = 45;
            this.rdoNu.TabStop = true;
            this.rdoNu.Text = "Nữ";
            this.rdoNu.UseVisualStyleBackColor = true;
            // 
            // materialLabel10
            // 
            this.materialLabel10.AutoSize = true;
            this.materialLabel10.Depth = 0;
            this.materialLabel10.Font = new System.Drawing.Font("Roboto", 34F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel10.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
            this.materialLabel10.Location = new System.Drawing.Point(46, 40);
            this.materialLabel10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel10.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel10.Name = "materialLabel10";
            this.materialLabel10.Size = new System.Drawing.Size(296, 41);
            this.materialLabel10.TabIndex = 46;
            this.materialLabel10.Text = "Thông tin nhân viên";
            // 
            // cboPriv
            // 
            this.cboPriv.AutoResize = false;
            this.cboPriv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboPriv.Depth = 0;
            this.cboPriv.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboPriv.DropDownHeight = 174;
            this.cboPriv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPriv.DropDownWidth = 121;
            this.cboPriv.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboPriv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cboPriv.FormattingEnabled = true;
            this.cboPriv.IntegralHeight = false;
            this.cboPriv.ItemHeight = 43;
            this.cboPriv.Location = new System.Drawing.Point(49, 507);
            this.cboPriv.MaxDropDownItems = 4;
            this.cboPriv.MouseState = MaterialSkin.MouseState.OUT;
            this.cboPriv.Name = "cboPriv";
            this.cboPriv.Size = new System.Drawing.Size(387, 49);
            this.cboPriv.StartIndex = 0;
            this.cboPriv.TabIndex = 48;
            // 
            // txtTenNV
            // 
            this.txtTenNV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenNV.AnimateReadOnly = false;
            this.txtTenNV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtTenNV.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTenNV.Depth = 0;
            this.txtTenNV.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtTenNV.HideSelection = true;
            this.txtTenNV.LeadingIcon = null;
            this.txtTenNV.Location = new System.Drawing.Point(491, 177);
            this.txtTenNV.MaxLength = 32767;
            this.txtTenNV.MouseState = MaterialSkin.MouseState.OUT;
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.PasswordChar = '\0';
            this.txtTenNV.PrefixSuffixText = null;
            this.txtTenNV.ReadOnly = false;
            this.txtTenNV.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTenNV.SelectedText = "";
            this.txtTenNV.SelectionLength = 0;
            this.txtTenNV.SelectionStart = 0;
            this.txtTenNV.ShortcutsEnabled = true;
            this.txtTenNV.Size = new System.Drawing.Size(489, 48);
            this.txtTenNV.TabIndex = 49;
            this.txtTenNV.TabStop = false;
            this.txtTenNV.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTenNV.TrailingIcon = null;
            this.txtTenNV.UseSystemPasswordChar = false;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiaChi.AnimateReadOnly = false;
            this.txtDiaChi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtDiaChi.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDiaChi.Depth = 0;
            this.txtDiaChi.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtDiaChi.HideSelection = true;
            this.txtDiaChi.LeadingIcon = null;
            this.txtDiaChi.Location = new System.Drawing.Point(491, 394);
            this.txtDiaChi.MaxLength = 32767;
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
            this.txtDiaChi.Size = new System.Drawing.Size(489, 48);
            this.txtDiaChi.TabIndex = 49;
            this.txtDiaChi.TabStop = false;
            this.txtDiaChi.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDiaChi.TrailingIcon = null;
            this.txtDiaChi.UseSystemPasswordChar = false;
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
            this.txtNgaySinh.Location = new System.Drawing.Point(491, 285);
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
            this.txtNgaySinh.TabIndex = 75;
            this.txtNgaySinh.TabStop = false;
            this.txtNgaySinh.Text = "  /  /";
            this.txtNgaySinh.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtNgaySinh.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.txtNgaySinh.TrailingIcon = null;
            this.txtNgaySinh.UseSystemPasswordChar = false;
            this.txtNgaySinh.ValidatingType = null;
            // 
            // txtSDT
            // 
            this.txtSDT.AllowPromptAsInput = true;
            this.txtSDT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
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
            this.txtSDT.Location = new System.Drawing.Point(491, 508);
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
            this.txtSDT.Size = new System.Drawing.Size(489, 48);
            this.txtSDT.SkipLiterals = true;
            this.txtSDT.TabIndex = 82;
            this.txtSDT.TabStop = false;
            this.txtSDT.Text = "        ";
            this.txtSDT.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSDT.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.txtSDT.TrailingIcon = null;
            this.txtSDT.UseSystemPasswordChar = false;
            this.txtSDT.ValidatingType = null;
            // 
            // frmThongTin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1024, 819);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.txtNgaySinh);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.txtTenNV);
            this.Controls.Add(this.cboPriv);
            this.Controls.Add(this.materialLabel10);
            this.Controls.Add(this.rdoNu);
            this.Controls.Add(this.rdoNam);
            this.Controls.Add(this.materialLabel9);
            this.Controls.Add(this.materialLabel5);
            this.Controls.Add(this.materialLabel6);
            this.Controls.Add(this.materialLabel7);
            this.Controls.Add(this.materialLabel8);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.txtTenDangNhap);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.swtEdit);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.txtMaNV);
            this.Controls.Add(this.btnLogOut);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.StatusAndActionBar_None;
            this.Name = "frmThongTin";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Text = "Thông tin";
            this.Load += new System.EventHandler(this.frmThongTin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton btnLogOut;
        private MaterialSkin.Controls.MaterialTextBox2 txtMaNV;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialSwitch swtEdit;
        private MaterialSkin.Controls.MaterialButton btnLuu;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialTextBox2 txtTenDangNhap;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private MaterialSkin.Controls.MaterialTextBox2 txtMatKhau;
        private MaterialSkin.Controls.MaterialLabel materialLabel9;
        private MaterialSkin.Controls.MaterialRadioButton rdoNam;
        private MaterialSkin.Controls.MaterialRadioButton rdoNu;
        private MaterialSkin.Controls.MaterialLabel materialLabel10;
        private MaterialSkin.Controls.MaterialComboBox cboPriv;
        private MaterialSkin.Controls.MaterialTextBox2 txtTenNV;
        private MaterialSkin.Controls.MaterialTextBox2 txtDiaChi;
        private MaterialSkin.Controls.MaterialMaskedTextBox txtNgaySinh;
        private MaterialSkin.Controls.MaterialMaskedTextBox txtSDT;
    }
}