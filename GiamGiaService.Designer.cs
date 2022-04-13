
namespace WindowsFormsApp4
{
    partial class GiamGiaService
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbTrangThai = new System.Windows.Forms.ComboBox();
            this.btnClear = new DuAnBanHang_Winforms_DBFirst.Views.DesignButtonClass();
            this.btnSuaa = new DuAnBanHang_Winforms_DBFirst.Views.DesignButtonClass();
            this.btnThemm = new DuAnBanHang_Winforms_DBFirst.Views.DesignButtonClass();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtgChonSP = new System.Windows.Forms.DataGridView();
            this.Select_Product = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtMaGG = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtTenGG = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtMucGG = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dateTimePickerNgayKT = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerNgayBD = new System.Windows.Forms.DateTimePicker();
            this.cbChonDonViGG = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtgEventList = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgChonSP)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEventList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbTrangThai);
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Controls.Add(this.btnSuaa);
            this.groupBox2.Controls.Add(this.btnThemm);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.panel5);
            this.groupBox2.Controls.Add(this.txtMaGG);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Controls.Add(this.txtTenGG);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.txtMucGG);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.panel7);
            this.groupBox2.Controls.Add(this.dateTimePickerNgayKT);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dateTimePickerNgayBD);
            this.groupBox2.Controls.Add(this.cbChonDonViGG);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(15);
            this.groupBox2.Size = new System.Drawing.Size(1575, 345);
            this.groupBox2.TabIndex = 150;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "EVENT INFORMATION";
            // 
            // cbTrangThai
            // 
            this.cbTrangThai.BackColor = System.Drawing.Color.White;
            this.cbTrangThai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbTrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTrangThai.ForeColor = System.Drawing.Color.White;
            this.cbTrangThai.FormattingEnabled = true;
            this.cbTrangThai.Items.AddRange(new object[] {
            "Xắp diễn ra",
            "Đang diễn ra",
            "Đã kết thúc"});
            this.cbTrangThai.Location = new System.Drawing.Point(1588, 744);
            this.cbTrangThai.Name = "cbTrangThai";
            this.cbTrangThai.Size = new System.Drawing.Size(1, 21);
            this.cbTrangThai.TabIndex = 159;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.White;
            this.btnClear.BackgroundColor = System.Drawing.Color.White;
            this.btnClear.BorderColor = System.Drawing.Color.Black;
            this.btnClear.BorderRadius = 10;
            this.btnClear.BorderSize = 5;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Image = global::WindowsFormsApp4.Properties.Resources.broom;
            this.btnClear.Location = new System.Drawing.Point(1440, 242);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(117, 78);
            this.btnClear.TabIndex = 158;
            this.btnClear.Text = "Clear";
            this.btnClear.TextColor = System.Drawing.Color.Black;
            this.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // btnSuaa
            // 
            this.btnSuaa.BackColor = System.Drawing.Color.White;
            this.btnSuaa.BackgroundColor = System.Drawing.Color.White;
            this.btnSuaa.BorderColor = System.Drawing.Color.Black;
            this.btnSuaa.BorderRadius = 10;
            this.btnSuaa.BorderSize = 5;
            this.btnSuaa.FlatAppearance.BorderSize = 0;
            this.btnSuaa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaa.ForeColor = System.Drawing.Color.Black;
            this.btnSuaa.Image = global::WindowsFormsApp4.Properties.Resources.images;
            this.btnSuaa.Location = new System.Drawing.Point(1440, 145);
            this.btnSuaa.Name = "btnSuaa";
            this.btnSuaa.Size = new System.Drawing.Size(117, 78);
            this.btnSuaa.TabIndex = 157;
            this.btnSuaa.Text = "Update";
            this.btnSuaa.TextColor = System.Drawing.Color.Black;
            this.btnSuaa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSuaa.UseVisualStyleBackColor = false;
            this.btnSuaa.Click += new System.EventHandler(this.btnSuaa_Click);
            // 
            // btnThemm
            // 
            this.btnThemm.BackColor = System.Drawing.Color.White;
            this.btnThemm.BackgroundColor = System.Drawing.Color.White;
            this.btnThemm.BorderColor = System.Drawing.Color.Black;
            this.btnThemm.BorderRadius = 10;
            this.btnThemm.BorderSize = 5;
            this.btnThemm.FlatAppearance.BorderSize = 0;
            this.btnThemm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemm.ForeColor = System.Drawing.Color.Black;
            this.btnThemm.Image = global::WindowsFormsApp4.Properties.Resources.tải_xuống;
            this.btnThemm.Location = new System.Drawing.Point(1440, 49);
            this.btnThemm.Name = "btnThemm";
            this.btnThemm.Size = new System.Drawing.Size(117, 78);
            this.btnThemm.TabIndex = 156;
            this.btnThemm.Text = "Add";
            this.btnThemm.TextColor = System.Drawing.Color.Black;
            this.btnThemm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnThemm.UseVisualStyleBackColor = false;
            this.btnThemm.Click += new System.EventHandler(this.btnThemm_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.dtgChonSP);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(565, 34);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(848, 296);
            this.groupBox3.TabIndex = 155;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "PRODUCT LIST";
            // 
            // dtgChonSP
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dtgChonSP.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgChonSP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgChonSP.BackgroundColor = System.Drawing.Color.White;
            this.dtgChonSP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgChonSP.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dtgChonSP.ColumnHeadersHeight = 40;
            this.dtgChonSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgChonSP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select_Product});
            this.dtgChonSP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgChonSP.GridColor = System.Drawing.Color.Blue;
            this.dtgChonSP.Location = new System.Drawing.Point(3, 25);
            this.dtgChonSP.Name = "dtgChonSP";
            this.dtgChonSP.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgChonSP.RowTemplate.Height = 35;
            this.dtgChonSP.Size = new System.Drawing.Size(842, 268);
            this.dtgChonSP.TabIndex = 33;
            // 
            // Select_Product
            // 
            this.Select_Product.HeaderText = "Select Product";
            this.Select_Product.Name = "Select_Product";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(26, 93);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(111, 20);
            this.label16.TabIndex = 142;
            this.label16.Text = "Event Name:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(468, 203);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(46, 20);
            this.label15.TabIndex = 154;
            this.label15.Text = "VND";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Location = new System.Drawing.Point(194, 123);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(320, 5);
            this.panel5.TabIndex = 145;
            // 
            // txtMaGG
            // 
            this.txtMaGG.BackColor = System.Drawing.Color.White;
            this.txtMaGG.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMaGG.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaGG.Location = new System.Drawing.Point(194, 37);
            this.txtMaGG.Multiline = true;
            this.txtMaGG.Name = "txtMaGG";
            this.txtMaGG.Size = new System.Drawing.Size(324, 32);
            this.txtMaGG.TabIndex = 140;
            this.txtMaGG.TextChanged += new System.EventHandler(this.txtMaGG_TextChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(196, 70);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(322, 5);
            this.panel3.TabIndex = 144;
            // 
            // txtTenGG
            // 
            this.txtTenGG.BackColor = System.Drawing.Color.White;
            this.txtTenGG.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTenGG.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenGG.Location = new System.Drawing.Point(194, 93);
            this.txtTenGG.Multiline = true;
            this.txtTenGG.Name = "txtTenGG";
            this.txtTenGG.Size = new System.Drawing.Size(324, 27);
            this.txtTenGG.TabIndex = 141;
            this.txtTenGG.TextChanged += new System.EventHandler(this.txtTenGG_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(26, 49);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(86, 20);
            this.label17.TabIndex = 143;
            this.label17.Text = "Event_Id:";
            // 
            // txtMucGG
            // 
            this.txtMucGG.BackColor = System.Drawing.Color.White;
            this.txtMucGG.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMucGG.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMucGG.Location = new System.Drawing.Point(195, 197);
            this.txtMucGG.Multiline = true;
            this.txtMucGG.Name = "txtMucGG";
            this.txtMucGG.Size = new System.Drawing.Size(257, 32);
            this.txtMucGG.TabIndex = 147;
            this.txtMucGG.TextChanged += new System.EventHandler(this.txtMucGG_TextChanged);
            this.txtMucGG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMucGG_KeyPress);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(22, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 32);
            this.label5.TabIndex = 148;
            this.label5.Text = "Discount rate:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(25, 283);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 20);
            this.label3.TabIndex = 124;
            this.label3.Text = "End:";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Black;
            this.panel7.Location = new System.Drawing.Point(197, 230);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(321, 5);
            this.panel7.TabIndex = 149;
            // 
            // dateTimePickerNgayKT
            // 
            this.dateTimePickerNgayKT.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerNgayKT.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerNgayKT.Location = new System.Drawing.Point(194, 291);
            this.dateTimePickerNgayKT.Name = "dateTimePickerNgayKT";
            this.dateTimePickerNgayKT.Size = new System.Drawing.Size(320, 29);
            this.dateTimePickerNgayKT.TabIndex = 123;
            this.dateTimePickerNgayKT.ValueChanged += new System.EventHandler(this.dateTimePickerNgayKT_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(25, 249);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 122;
            this.label1.Text = "Start:";
            // 
            // dateTimePickerNgayBD
            // 
            this.dateTimePickerNgayBD.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerNgayBD.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerNgayBD.Location = new System.Drawing.Point(194, 249);
            this.dateTimePickerNgayBD.Name = "dateTimePickerNgayBD";
            this.dateTimePickerNgayBD.Size = new System.Drawing.Size(320, 29);
            this.dateTimePickerNgayBD.TabIndex = 121;
            // 
            // cbChonDonViGG
            // 
            this.cbChonDonViGG.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.cbChonDonViGG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbChonDonViGG.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbChonDonViGG.FormattingEnabled = true;
            this.cbChonDonViGG.Items.AddRange(new object[] {
            "Discount by %",
            "Discount by VND"});
            this.cbChonDonViGG.Location = new System.Drawing.Point(195, 154);
            this.cbChonDonViGG.Name = "cbChonDonViGG";
            this.cbChonDonViGG.Size = new System.Drawing.Size(324, 28);
            this.cbChonDonViGG.TabIndex = 137;
            this.cbChonDonViGG.SelectedIndexChanged += new System.EventHandler(this.cbChonDonViGG_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(22, 154);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(123, 20);
            this.label21.TabIndex = 136;
            this.label21.Text = "Discount Unit:";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.White;
            this.groupBox4.Controls.Add(this.txtTimKiem);
            this.groupBox4.Controls.Add(this.panel1);
            this.groupBox4.Controls.Add(this.dtgEventList);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(12, 369);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1570, 509);
            this.groupBox4.TabIndex = 157;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "EVENT LIST";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.BackColor = System.Drawing.Color.White;
            this.txtTimKiem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(133, 28);
            this.txtTimKiem.Multiline = true;
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(498, 32);
            this.txtTimKiem.TabIndex = 159;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(135, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(496, 5);
            this.panel1.TabIndex = 161;
            // 
            // dtgEventList
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dtgEventList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgEventList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgEventList.BackgroundColor = System.Drawing.Color.White;
            this.dtgEventList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgEventList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dtgEventList.ColumnHeadersHeight = 50;
            this.dtgEventList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgEventList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dtgEventList.GridColor = System.Drawing.Color.Blue;
            this.dtgEventList.Location = new System.Drawing.Point(3, 72);
            this.dtgEventList.Name = "dtgEventList";
            this.dtgEventList.RowTemplate.Height = 40;
            this.dtgEventList.Size = new System.Drawing.Size(1564, 434);
            this.dtgEventList.TabIndex = 33;
            this.dtgEventList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEventList_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(30, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 160;
            this.label2.Text = "Search:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // GiamGiaService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1603, 890);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Name = "GiamGiaService";
            this.Text = "GiamGiaService";
            this.Load += new System.EventHandler(this.GiamGiaService_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgChonSP)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEventList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private DuAnBanHang_Winforms_DBFirst.Views.DesignButtonClass btnClear;
        private DuAnBanHang_Winforms_DBFirst.Views.DesignButtonClass btnSuaa;
        private DuAnBanHang_Winforms_DBFirst.Views.DesignButtonClass btnThemm;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dtgChonSP;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select_Product;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtMaGG;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtTenGG;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtMucGG;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.DateTimePicker dateTimePickerNgayKT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerNgayBD;
        private System.Windows.Forms.ComboBox cbChonDonViGG;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dtgEventList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTrangThai;
        private System.Windows.Forms.Timer timer1;
    }
}