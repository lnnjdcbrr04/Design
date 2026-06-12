namespace Design
{
    partial class frmDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDashboard));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnDsh = new System.Windows.Forms.Button();
            this.btnDbLogout = new System.Windows.Forms.Button();
            this.btnDbUsers = new System.Windows.Forms.Button();
            this.btnDbOrders = new System.Windows.Forms.Button();
            this.btnDbTrans = new System.Windows.Forms.Button();
            this.btnDbStocks = new System.Windows.Forms.Button();
            this.btnDbProd = new System.Windows.Forms.Button();
            this.guna2ShadowPanel2 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.lblTransac = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvPendings = new System.Windows.Forms.DataGridView();
            this.Customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pickup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.guna2ShadowPanel5 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.lblRevenue = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.guna2ShadowPanel7 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.lblPendings = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.lblLowStocks = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2GradientPanel2 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.chMonthlySales = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.label6 = new System.Windows.Forms.Label();
            this.guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.guna2ShadowPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendings)).BeginInit();
            this.guna2ShadowPanel5.SuspendLayout();
            this.guna2ShadowPanel7.SuspendLayout();
            this.guna2ShadowPanel1.SuspendLayout();
            this.guna2GradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chMonthlySales)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Controls.Add(this.pictureBox1);
            this.guna2GradientPanel1.Controls.Add(this.btnDsh);
            this.guna2GradientPanel1.Controls.Add(this.btnDbLogout);
            this.guna2GradientPanel1.Controls.Add(this.btnDbUsers);
            this.guna2GradientPanel1.Controls.Add(this.btnDbOrders);
            this.guna2GradientPanel1.Controls.Add(this.btnDbTrans);
            this.guna2GradientPanel1.Controls.Add(this.btnDbStocks);
            this.guna2GradientPanel1.Controls.Add(this.btnDbProd);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.MistyRose;
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.LightPink;
            this.guna2GradientPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(292, 1041);
            this.guna2GradientPanel1.TabIndex = 84;
            this.guna2GradientPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2GradientPanel1_Paint);
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
            // btnDsh
            // 
            this.btnDsh.BackColor = System.Drawing.Color.MistyRose;
            this.btnDsh.FlatAppearance.BorderSize = 0;
            this.btnDsh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDsh.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDsh.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnDsh.Location = new System.Drawing.Point(1, 258);
            this.btnDsh.Name = "btnDsh";
            this.btnDsh.Size = new System.Drawing.Size(290, 43);
            this.btnDsh.TabIndex = 17;
            this.btnDsh.Text = "     Dashboard";
            this.btnDsh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDsh.UseVisualStyleBackColor = false;
            // 
            // btnDbLogout
            // 
            this.btnDbLogout.BackColor = System.Drawing.Color.Transparent;
            this.btnDbLogout.FlatAppearance.BorderSize = 0;
            this.btnDbLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDbLogout.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDbLogout.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnDbLogout.Location = new System.Drawing.Point(1, 938);
            this.btnDbLogout.Name = "btnDbLogout";
            this.btnDbLogout.Size = new System.Drawing.Size(290, 43);
            this.btnDbLogout.TabIndex = 16;
            this.btnDbLogout.Text = "     Logout";
            this.btnDbLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDbLogout.UseVisualStyleBackColor = false;
            this.btnDbLogout.Click += new System.EventHandler(this.btnDbLogout_Click);
            // 
            // btnDbUsers
            // 
            this.btnDbUsers.BackColor = System.Drawing.Color.Transparent;
            this.btnDbUsers.FlatAppearance.BorderSize = 0;
            this.btnDbUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDbUsers.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDbUsers.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnDbUsers.Location = new System.Drawing.Point(1, 879);
            this.btnDbUsers.Name = "btnDbUsers";
            this.btnDbUsers.Size = new System.Drawing.Size(290, 43);
            this.btnDbUsers.TabIndex = 14;
            this.btnDbUsers.Text = "     Users";
            this.btnDbUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDbUsers.UseVisualStyleBackColor = false;
            this.btnDbUsers.Click += new System.EventHandler(this.btnDbUsers_Click);
            // 
            // btnDbOrders
            // 
            this.btnDbOrders.BackColor = System.Drawing.Color.Transparent;
            this.btnDbOrders.FlatAppearance.BorderSize = 0;
            this.btnDbOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDbOrders.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDbOrders.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnDbOrders.Location = new System.Drawing.Point(1, 474);
            this.btnDbOrders.Name = "btnDbOrders";
            this.btnDbOrders.Size = new System.Drawing.Size(290, 43);
            this.btnDbOrders.TabIndex = 13;
            this.btnDbOrders.Text = "     Orders";
            this.btnDbOrders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDbOrders.UseVisualStyleBackColor = false;
            this.btnDbOrders.Click += new System.EventHandler(this.btnDbOrders_Click);
            // 
            // btnDbTrans
            // 
            this.btnDbTrans.BackColor = System.Drawing.Color.Transparent;
            this.btnDbTrans.FlatAppearance.BorderSize = 0;
            this.btnDbTrans.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDbTrans.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDbTrans.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnDbTrans.Location = new System.Drawing.Point(1, 420);
            this.btnDbTrans.Name = "btnDbTrans";
            this.btnDbTrans.Size = new System.Drawing.Size(290, 43);
            this.btnDbTrans.TabIndex = 12;
            this.btnDbTrans.Text = "     Transaction";
            this.btnDbTrans.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDbTrans.UseVisualStyleBackColor = false;
            this.btnDbTrans.Click += new System.EventHandler(this.btnDbTrans_Click);
            // 
            // btnDbStocks
            // 
            this.btnDbStocks.BackColor = System.Drawing.Color.Transparent;
            this.btnDbStocks.FlatAppearance.BorderSize = 0;
            this.btnDbStocks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDbStocks.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDbStocks.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnDbStocks.Location = new System.Drawing.Point(1, 366);
            this.btnDbStocks.Name = "btnDbStocks";
            this.btnDbStocks.Size = new System.Drawing.Size(290, 43);
            this.btnDbStocks.TabIndex = 11;
            this.btnDbStocks.Text = "     Stocks";
            this.btnDbStocks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDbStocks.UseVisualStyleBackColor = false;
            this.btnDbStocks.Click += new System.EventHandler(this.btnDbStocks_Click);
            // 
            // btnDbProd
            // 
            this.btnDbProd.BackColor = System.Drawing.Color.Transparent;
            this.btnDbProd.FlatAppearance.BorderSize = 0;
            this.btnDbProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDbProd.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDbProd.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnDbProd.Location = new System.Drawing.Point(1, 312);
            this.btnDbProd.Name = "btnDbProd";
            this.btnDbProd.Size = new System.Drawing.Size(290, 43);
            this.btnDbProd.TabIndex = 10;
            this.btnDbProd.Text = "     Products";
            this.btnDbProd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDbProd.UseVisualStyleBackColor = false;
            this.btnDbProd.Click += new System.EventHandler(this.btnDbProd_Click);
            // 
            // guna2ShadowPanel2
            // 
            this.guna2ShadowPanel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel2.Controls.Add(this.lblTransac);
            this.guna2ShadowPanel2.Controls.Add(this.label5);
            this.guna2ShadowPanel2.FillColor = System.Drawing.Color.LavenderBlush;
            this.guna2ShadowPanel2.Location = new System.Drawing.Point(358, 207);
            this.guna2ShadowPanel2.Name = "guna2ShadowPanel2";
            this.guna2ShadowPanel2.Radius = 10;
            this.guna2ShadowPanel2.ShadowColor = System.Drawing.Color.Salmon;
            this.guna2ShadowPanel2.Size = new System.Drawing.Size(255, 165);
            this.guna2ShadowPanel2.TabIndex = 87;
            // 
            // lblTransac
            // 
            this.lblTransac.AutoSize = true;
            this.lblTransac.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransac.Location = new System.Drawing.Point(31, 70);
            this.lblTransac.Name = "lblTransac";
            this.lblTransac.Size = new System.Drawing.Size(47, 36);
            this.lblTransac.TabIndex = 1;
            this.lblTransac.Text = "00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 26);
            this.label5.TabIndex = 0;
            this.label5.Text = "Transactions";
            // 
            // dgvPendings
            // 
            this.dgvPendings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPendings.BackgroundColor = System.Drawing.Color.Linen;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPendings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPendings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPendings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Customer,
            this.product,
            this.qty,
            this.Pickup,
            this.Status,
            this.Total});
            this.dgvPendings.Location = new System.Drawing.Point(358, 463);
            this.dgvPendings.Name = "dgvPendings";
            this.dgvPendings.RowHeadersVisible = false;
            this.dgvPendings.Size = new System.Drawing.Size(1088, 159);
            this.dgvPendings.TabIndex = 91;
            // 
            // Customer
            // 
            this.Customer.HeaderText = "Customer";
            this.Customer.Name = "Customer";
            // 
            // product
            // 
            this.product.HeaderText = "Product";
            this.product.Name = "product";
            // 
            // qty
            // 
            this.qty.HeaderText = "Quantity";
            this.qty.Name = "qty";
            // 
            // Pickup
            // 
            this.Pickup.HeaderText = "Pickup";
            this.Pickup.Name = "Pickup";
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label10.Location = new System.Drawing.Point(352, 422);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(190, 33);
            this.label10.TabIndex = 95;
            this.label10.Text = "Pending Orders";
            // 
            // guna2ShadowPanel5
            // 
            this.guna2ShadowPanel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel5.Controls.Add(this.lblRevenue);
            this.guna2ShadowPanel5.Controls.Add(this.label14);
            this.guna2ShadowPanel5.FillColor = System.Drawing.Color.LavenderBlush;
            this.guna2ShadowPanel5.Location = new System.Drawing.Point(629, 207);
            this.guna2ShadowPanel5.Name = "guna2ShadowPanel5";
            this.guna2ShadowPanel5.Radius = 10;
            this.guna2ShadowPanel5.ShadowColor = System.Drawing.Color.Salmon;
            this.guna2ShadowPanel5.Size = new System.Drawing.Size(255, 165);
            this.guna2ShadowPanel5.TabIndex = 100;
            // 
            // lblRevenue
            // 
            this.lblRevenue.AutoSize = true;
            this.lblRevenue.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevenue.Location = new System.Drawing.Point(31, 70);
            this.lblRevenue.Name = "lblRevenue";
            this.lblRevenue.Size = new System.Drawing.Size(115, 36);
            this.lblRevenue.TabIndex = 1;
            this.lblRevenue.Text = "₱ 00.00";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(22, 26);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(99, 26);
            this.label14.TabIndex = 0;
            this.label14.Text = "Revenue";
            // 
            // guna2ShadowPanel7
            // 
            this.guna2ShadowPanel7.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel7.Controls.Add(this.lblPendings);
            this.guna2ShadowPanel7.Controls.Add(this.label20);
            this.guna2ShadowPanel7.FillColor = System.Drawing.Color.LavenderBlush;
            this.guna2ShadowPanel7.Location = new System.Drawing.Point(901, 207);
            this.guna2ShadowPanel7.Name = "guna2ShadowPanel7";
            this.guna2ShadowPanel7.Radius = 10;
            this.guna2ShadowPanel7.ShadowColor = System.Drawing.Color.Salmon;
            this.guna2ShadowPanel7.Size = new System.Drawing.Size(255, 165);
            this.guna2ShadowPanel7.TabIndex = 101;
            // 
            // lblPendings
            // 
            this.lblPendings.AutoSize = true;
            this.lblPendings.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendings.Location = new System.Drawing.Point(31, 70);
            this.lblPendings.Name = "lblPendings";
            this.lblPendings.Size = new System.Drawing.Size(47, 36);
            this.lblPendings.TabIndex = 1;
            this.lblPendings.Text = "00";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(22, 26);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(176, 26);
            this.label20.TabIndex = 0;
            this.label20.Text = "Pending Orders";
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.lblLowStocks);
            this.guna2ShadowPanel1.Controls.Add(this.label3);
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.LavenderBlush;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(1172, 207);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.Radius = 10;
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Salmon;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(255, 165);
            this.guna2ShadowPanel1.TabIndex = 102;
            // 
            // lblLowStocks
            // 
            this.lblLowStocks.AutoSize = true;
            this.lblLowStocks.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowStocks.Location = new System.Drawing.Point(31, 70);
            this.lblLowStocks.Name = "lblLowStocks";
            this.lblLowStocks.Size = new System.Drawing.Size(47, 36);
            this.lblLowStocks.TabIndex = 1;
            this.lblLowStocks.Text = "00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 26);
            this.label3.TabIndex = 0;
            this.label3.Text = "Low Stocks";
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
            this.guna2GradientPanel2.Size = new System.Drawing.Size(1592, 70);
            this.guna2GradientPanel2.TabIndex = 103;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label1.Location = new System.Drawing.Point(33, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 44);
            this.label1.TabIndex = 4;
            this.label1.Text = "Dashboard";
            // 
            // chMonthlySales
            // 
            chartArea2.Name = "ChartArea1";
            this.chMonthlySales.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chMonthlySales.Legends.Add(legend2);
            this.chMonthlySales.Location = new System.Drawing.Point(358, 684);
            this.chMonthlySales.Name = "chMonthlySales";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chMonthlySales.Series.Add(series2);
            this.chMonthlySales.Size = new System.Drawing.Size(595, 320);
            this.chMonthlySales.TabIndex = 104;
            this.chMonthlySales.Text = "Monthly Sales";
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.FillColor = System.Drawing.Color.MistyRose;
            this.guna2Separator1.FillThickness = 3;
            this.guna2Separator1.Location = new System.Drawing.Point(323, 148);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(318, 15);
            this.guna2Separator1.TabIndex = 109;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label6.Location = new System.Drawing.Point(325, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(283, 44);
            this.label6.TabIndex = 108;
            this.label6.Text = "Admin Dashboard";
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(1884, 1041);
            this.Controls.Add(this.guna2Separator1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chMonthlySales);
            this.Controls.Add(this.guna2GradientPanel2);
            this.Controls.Add(this.guna2ShadowPanel1);
            this.Controls.Add(this.guna2ShadowPanel7);
            this.Controls.Add(this.guna2ShadowPanel5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dgvPendings);
            this.Controls.Add(this.guna2ShadowPanel2);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Name = "frmDashboard";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.guna2GradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.guna2ShadowPanel2.ResumeLayout(false);
            this.guna2ShadowPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendings)).EndInit();
            this.guna2ShadowPanel5.ResumeLayout(false);
            this.guna2ShadowPanel5.PerformLayout();
            this.guna2ShadowPanel7.ResumeLayout(false);
            this.guna2ShadowPanel7.PerformLayout();
            this.guna2ShadowPanel1.ResumeLayout(false);
            this.guna2ShadowPanel1.PerformLayout();
            this.guna2GradientPanel2.ResumeLayout(false);
            this.guna2GradientPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chMonthlySales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private System.Windows.Forms.Button btnDsh;
        private System.Windows.Forms.Button btnDbLogout;
        private System.Windows.Forms.Button btnDbUsers;
        private System.Windows.Forms.Button btnDbOrders;
        private System.Windows.Forms.Button btnDbTrans;
        private System.Windows.Forms.Button btnDbStocks;
        private System.Windows.Forms.Button btnDbProd;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel2;
        private System.Windows.Forms.Label lblTransac;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvPendings;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel5;
        private System.Windows.Forms.Label lblRevenue;
        private System.Windows.Forms.Label label14;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel7;
        private System.Windows.Forms.Label lblPendings;
        private System.Windows.Forms.Label label20;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private System.Windows.Forms.Label lblLowStocks;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chMonthlySales;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn product;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pickup;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
    }
}

