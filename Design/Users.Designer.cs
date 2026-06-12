namespace Design
{
    partial class frmUsers
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsers));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2GradientPanel2 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnUsrDsh = new System.Windows.Forms.Button();
            this.btnUsrLogout = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnUsrOrders = new System.Windows.Forms.Button();
            this.btnUsrTrans = new System.Windows.Forms.Button();
            this.btnUsrStocks = new System.Windows.Forms.Button();
            this.btnUsrProd = new System.Windows.Forms.Button();
            this.dgvAll = new System.Windows.Forms.DataGridView();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbUsrStatus = new System.Windows.Forms.ComboBox();
            this.cmbRoles = new System.Windows.Forms.ComboBox();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnEditStaff = new System.Windows.Forms.Button();
            this.btnDeleteStaff = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddStaff = new System.Windows.Forms.Button();
            this.cmbStaffStatus = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbStaffRole = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUsrPw = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStaffname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSelectedUserID = new System.Windows.Forms.Label();
            this.guna2GradientPanel2.SuspendLayout();
            this.guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAll)).BeginInit();
            this.guna2GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2GradientPanel2
            // 
            this.guna2GradientPanel2.Controls.Add(this.label1);
            this.guna2GradientPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2GradientPanel2.FillColor = System.Drawing.Color.LightPink;
            this.guna2GradientPanel2.FillColor2 = System.Drawing.Color.MistyRose;
            this.guna2GradientPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.guna2GradientPanel2.Location = new System.Drawing.Point(292, 0);
            this.guna2GradientPanel2.Name = "guna2GradientPanel2";
            this.guna2GradientPanel2.Size = new System.Drawing.Size(993, 70);
            this.guna2GradientPanel2.TabIndex = 107;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label1.Location = new System.Drawing.Point(33, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 44);
            this.label1.TabIndex = 4;
            this.label1.Text = "Users";
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Controls.Add(this.pictureBox1);
            this.guna2GradientPanel1.Controls.Add(this.btnUsrDsh);
            this.guna2GradientPanel1.Controls.Add(this.btnUsrLogout);
            this.guna2GradientPanel1.Controls.Add(this.btnUsers);
            this.guna2GradientPanel1.Controls.Add(this.btnUsrOrders);
            this.guna2GradientPanel1.Controls.Add(this.btnUsrTrans);
            this.guna2GradientPanel1.Controls.Add(this.btnUsrStocks);
            this.guna2GradientPanel1.Controls.Add(this.btnUsrProd);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.MistyRose;
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.LightPink;
            this.guna2GradientPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(292, 1041);
            this.guna2GradientPanel1.TabIndex = 106;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(47, 27);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(178, 170);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // btnUsrDsh
            // 
            this.btnUsrDsh.BackColor = System.Drawing.Color.Transparent;
            this.btnUsrDsh.FlatAppearance.BorderSize = 0;
            this.btnUsrDsh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsrDsh.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsrDsh.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnUsrDsh.Location = new System.Drawing.Point(1, 258);
            this.btnUsrDsh.Name = "btnUsrDsh";
            this.btnUsrDsh.Size = new System.Drawing.Size(290, 43);
            this.btnUsrDsh.TabIndex = 17;
            this.btnUsrDsh.Text = "     Dashboard";
            this.btnUsrDsh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsrDsh.UseVisualStyleBackColor = false;
            this.btnUsrDsh.Click += new System.EventHandler(this.btnUsrDsh_Click);
            // 
            // btnUsrLogout
            // 
            this.btnUsrLogout.BackColor = System.Drawing.Color.Transparent;
            this.btnUsrLogout.FlatAppearance.BorderSize = 0;
            this.btnUsrLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsrLogout.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsrLogout.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnUsrLogout.Location = new System.Drawing.Point(1, 938);
            this.btnUsrLogout.Name = "btnUsrLogout";
            this.btnUsrLogout.Size = new System.Drawing.Size(290, 43);
            this.btnUsrLogout.TabIndex = 16;
            this.btnUsrLogout.Text = "     Logout";
            this.btnUsrLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsrLogout.UseVisualStyleBackColor = false;
            this.btnUsrLogout.Click += new System.EventHandler(this.btnUsrLogout_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.BackColor = System.Drawing.Color.MistyRose;
            this.btnUsers.FlatAppearance.BorderSize = 0;
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsers.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnUsers.Location = new System.Drawing.Point(1, 879);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(290, 43);
            this.btnUsers.TabIndex = 14;
            this.btnUsers.Text = "     Users";
            this.btnUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsers.UseVisualStyleBackColor = false;
            // 
            // btnUsrOrders
            // 
            this.btnUsrOrders.BackColor = System.Drawing.Color.Transparent;
            this.btnUsrOrders.FlatAppearance.BorderSize = 0;
            this.btnUsrOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsrOrders.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsrOrders.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnUsrOrders.Location = new System.Drawing.Point(1, 474);
            this.btnUsrOrders.Name = "btnUsrOrders";
            this.btnUsrOrders.Size = new System.Drawing.Size(290, 43);
            this.btnUsrOrders.TabIndex = 13;
            this.btnUsrOrders.Text = "     Orders";
            this.btnUsrOrders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsrOrders.UseVisualStyleBackColor = false;
            this.btnUsrOrders.Click += new System.EventHandler(this.btnUsrOrders_Click);
            // 
            // btnUsrTrans
            // 
            this.btnUsrTrans.BackColor = System.Drawing.Color.Transparent;
            this.btnUsrTrans.FlatAppearance.BorderSize = 0;
            this.btnUsrTrans.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsrTrans.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsrTrans.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnUsrTrans.Location = new System.Drawing.Point(1, 420);
            this.btnUsrTrans.Name = "btnUsrTrans";
            this.btnUsrTrans.Size = new System.Drawing.Size(290, 43);
            this.btnUsrTrans.TabIndex = 12;
            this.btnUsrTrans.Text = "     Transaction";
            this.btnUsrTrans.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsrTrans.UseVisualStyleBackColor = false;
            this.btnUsrTrans.Click += new System.EventHandler(this.btnUsrTrans_Click);
            // 
            // btnUsrStocks
            // 
            this.btnUsrStocks.BackColor = System.Drawing.Color.Transparent;
            this.btnUsrStocks.FlatAppearance.BorderSize = 0;
            this.btnUsrStocks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsrStocks.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsrStocks.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnUsrStocks.Location = new System.Drawing.Point(1, 366);
            this.btnUsrStocks.Name = "btnUsrStocks";
            this.btnUsrStocks.Size = new System.Drawing.Size(290, 43);
            this.btnUsrStocks.TabIndex = 11;
            this.btnUsrStocks.Text = "     Stocks";
            this.btnUsrStocks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsrStocks.UseVisualStyleBackColor = false;
            this.btnUsrStocks.Click += new System.EventHandler(this.btnUsrStocks_Click);
            // 
            // btnUsrProd
            // 
            this.btnUsrProd.BackColor = System.Drawing.Color.Transparent;
            this.btnUsrProd.FlatAppearance.BorderSize = 0;
            this.btnUsrProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsrProd.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsrProd.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnUsrProd.Location = new System.Drawing.Point(1, 312);
            this.btnUsrProd.Name = "btnUsrProd";
            this.btnUsrProd.Size = new System.Drawing.Size(290, 43);
            this.btnUsrProd.TabIndex = 10;
            this.btnUsrProd.Text = "     Products";
            this.btnUsrProd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsrProd.UseVisualStyleBackColor = false;
            this.btnUsrProd.Click += new System.EventHandler(this.btnProd_Click);
            // 
            // dgvAll
            // 
            this.dgvAll.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAll.BackgroundColor = System.Drawing.Color.Linen;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAll.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAll.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvAll.Location = new System.Drawing.Point(333, 258);
            this.dgvAll.Name = "dgvAll";
            this.dgvAll.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAll.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvAll.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAll.Size = new System.Drawing.Size(912, 320);
            this.dgvAll.TabIndex = 114;
            this.dgvAll.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAll_CellClick);
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.FillColor = System.Drawing.Color.MistyRose;
            this.guna2Separator1.FillThickness = 3;
            this.guna2Separator1.Location = new System.Drawing.Point(323, 145);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(352, 15);
            this.guna2Separator1.TabIndex = 116;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label2.Location = new System.Drawing.Point(325, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(294, 44);
            this.label2.TabIndex = 115;
            this.label2.Text = "Users Management";
            // 
            // cmbUsrStatus
            // 
            this.cmbUsrStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsrStatus.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUsrStatus.FormattingEnabled = true;
            this.cmbUsrStatus.Location = new System.Drawing.Point(574, 208);
            this.cmbUsrStatus.Name = "cmbUsrStatus";
            this.cmbUsrStatus.Size = new System.Drawing.Size(235, 34);
            this.cmbUsrStatus.TabIndex = 118;
            this.cmbUsrStatus.SelectedIndexChanged += new System.EventHandler(this.cmbUsrStatus_SelectedIndexChanged);
            // 
            // cmbRoles
            // 
            this.cmbRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoles.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRoles.FormattingEnabled = true;
            this.cmbRoles.Location = new System.Drawing.Point(333, 208);
            this.cmbRoles.Name = "cmbRoles";
            this.cmbRoles.Size = new System.Drawing.Size(235, 34);
            this.cmbRoles.TabIndex = 117;
            this.cmbRoles.SelectedIndexChanged += new System.EventHandler(this.cmbRoles_SelectedIndexChanged);
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BorderRadius = 10;
            this.guna2GroupBox1.Controls.Add(this.btnEditStaff);
            this.guna2GroupBox1.Controls.Add(this.btnDeleteStaff);
            this.guna2GroupBox1.Controls.Add(this.btnAddStaff);
            this.guna2GroupBox1.Controls.Add(this.cmbStaffStatus);
            this.guna2GroupBox1.Controls.Add(this.label7);
            this.guna2GroupBox1.Controls.Add(this.cmbStaffRole);
            this.guna2GroupBox1.Controls.Add(this.label6);
            this.guna2GroupBox1.Controls.Add(this.txtUsrPw);
            this.guna2GroupBox1.Controls.Add(this.label5);
            this.guna2GroupBox1.Controls.Add(this.txtUsername);
            this.guna2GroupBox1.Controls.Add(this.label4);
            this.guna2GroupBox1.Controls.Add(this.txtStaffname);
            this.guna2GroupBox1.Controls.Add(this.label3);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.MistyRose;
            this.guna2GroupBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.guna2GroupBox1.Location = new System.Drawing.Point(333, 611);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(855, 370);
            this.guna2GroupBox1.TabIndex = 119;
            this.guna2GroupBox1.Text = "Add/Edit Staff";
            // 
            // btnEditStaff
            // 
            this.btnEditStaff.BackColor = System.Drawing.Color.RosyBrown;
            this.btnEditStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditStaff.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditStaff.ForeColor = System.Drawing.Color.White;
            this.btnEditStaff.Location = new System.Drawing.Point(604, 311);
            this.btnEditStaff.Name = "btnEditStaff";
            this.btnEditStaff.Size = new System.Drawing.Size(118, 40);
            this.btnEditStaff.TabIndex = 33;
            this.btnEditStaff.Text = "Edit Staff";
            this.btnEditStaff.UseVisualStyleBackColor = false;
            this.btnEditStaff.Click += new System.EventHandler(this.btnEditStaff_Click);
            // 
            // btnDeleteStaff
            // 
            this.btnDeleteStaff.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDeleteStaff.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDeleteStaff.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDeleteStaff.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDeleteStaff.FillColor = System.Drawing.Color.Transparent;
            this.btnDeleteStaff.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteStaff.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnDeleteStaff.Location = new System.Drawing.Point(728, 311);
            this.btnDeleteStaff.Name = "btnDeleteStaff";
            this.btnDeleteStaff.Size = new System.Drawing.Size(118, 40);
            this.btnDeleteStaff.TabIndex = 32;
            this.btnDeleteStaff.Text = "Delete";
            this.btnDeleteStaff.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddStaff
            // 
            this.btnAddStaff.BackColor = System.Drawing.Color.RosyBrown;
            this.btnAddStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddStaff.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddStaff.ForeColor = System.Drawing.Color.White;
            this.btnAddStaff.Location = new System.Drawing.Point(480, 311);
            this.btnAddStaff.Name = "btnAddStaff";
            this.btnAddStaff.Size = new System.Drawing.Size(118, 40);
            this.btnAddStaff.TabIndex = 31;
            this.btnAddStaff.Text = "Add Staff";
            this.btnAddStaff.UseVisualStyleBackColor = false;
            this.btnAddStaff.Click += new System.EventHandler(this.btnAddStaff_Click);
            // 
            // cmbStaffStatus
            // 
            this.cmbStaffStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStaffStatus.FormattingEnabled = true;
            this.cmbStaffStatus.Location = new System.Drawing.Point(487, 248);
            this.cmbStaffStatus.Name = "cmbStaffStatus";
            this.cmbStaffStatus.Size = new System.Drawing.Size(146, 30);
            this.cmbStaffStatus.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(482, 219);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 26);
            this.label7.TabIndex = 8;
            this.label7.Text = "Status:";
            // 
            // cmbStaffRole
            // 
            this.cmbStaffRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStaffRole.FormattingEnabled = true;
            this.cmbStaffRole.Location = new System.Drawing.Point(487, 174);
            this.cmbStaffRole.Name = "cmbStaffRole";
            this.cmbStaffRole.Size = new System.Drawing.Size(146, 30);
            this.cmbStaffRole.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(482, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 26);
            this.label6.TabIndex = 6;
            this.label6.Text = "Role:";
            // 
            // txtUsrPw
            // 
            this.txtUsrPw.Location = new System.Drawing.Point(487, 104);
            this.txtUsrPw.Multiline = true;
            this.txtUsrPw.Name = "txtUsrPw";
            this.txtUsrPw.Size = new System.Drawing.Size(248, 30);
            this.txtUsrPw.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(482, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 26);
            this.label5.TabIndex = 4;
            this.label5.Text = "Password:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(51, 181);
            this.txtUsername.Multiline = true;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(248, 30);
            this.txtUsername.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(46, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 26);
            this.label4.TabIndex = 2;
            this.label4.Text = "Username:";
            // 
            // txtStaffname
            // 
            this.txtStaffname.Location = new System.Drawing.Point(51, 104);
            this.txtStaffname.Multiline = true;
            this.txtStaffname.Name = "txtStaffname";
            this.txtStaffname.Size = new System.Drawing.Size(248, 30);
            this.txtStaffname.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(46, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 26);
            this.label3.TabIndex = 0;
            this.label3.Text = "Fullname:";
            // 
            // lblSelectedUserID
            // 
            this.lblSelectedUserID.AutoSize = true;
            this.lblSelectedUserID.Location = new System.Drawing.Point(370, 404);
            this.lblSelectedUserID.Name = "lblSelectedUserID";
            this.lblSelectedUserID.Size = new System.Drawing.Size(0, 13);
            this.lblSelectedUserID.TabIndex = 124;
            this.lblSelectedUserID.Visible = false;
            // 
            // frmUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(1285, 1041);
            this.Controls.Add(this.lblSelectedUserID);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.cmbUsrStatus);
            this.Controls.Add(this.cmbRoles);
            this.Controls.Add(this.guna2Separator1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvAll);
            this.Controls.Add(this.guna2GradientPanel2);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Name = "frmUsers";
            this.Text = "Users";
            this.guna2GradientPanel2.ResumeLayout(false);
            this.guna2GradientPanel2.PerformLayout();
            this.guna2GradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAll)).EndInit();
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnUsrDsh;
        private System.Windows.Forms.Button btnUsrLogout;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnUsrOrders;
        private System.Windows.Forms.Button btnUsrTrans;
        private System.Windows.Forms.Button btnUsrStocks;
        private System.Windows.Forms.Button btnUsrProd;
        private System.Windows.Forms.DataGridView dgvAll;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbUsrStatus;
        private System.Windows.Forms.ComboBox cmbRoles;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStaffname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbStaffStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbStaffRole;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUsrPw;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnEditStaff;
        private Guna.UI2.WinForms.Guna2Button btnDeleteStaff;
        private System.Windows.Forms.Button btnAddStaff;
        private System.Windows.Forms.Label lblSelectedUserID;
    }
}