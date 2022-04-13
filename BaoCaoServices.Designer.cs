
namespace WindowsFormsApp4
{
    partial class BaoCaoServices
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtgHoaDon = new System.Windows.Forms.DataGridView();
            this.btnGuiDi = new DuAnBanHang_Winforms_DBFirst.Views.DesignButtonClass();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(518, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(479, 37);
            this.label7.TabIndex = 115;
            this.label7.Text = "LIST OF YOUR BILLS TODAY";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dtgHoaDon);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(7, 85);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(12);
            this.panel1.Size = new System.Drawing.Size(1596, 813);
            this.panel1.TabIndex = 114;
            // 
            // dtgHoaDon
            // 
            this.dtgHoaDon.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dtgHoaDon.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgHoaDon.BackgroundColor = System.Drawing.Color.White;
            this.dtgHoaDon.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dtgHoaDon.ColumnHeadersHeight = 40;
            this.dtgHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgHoaDon.GridColor = System.Drawing.Color.Blue;
            this.dtgHoaDon.Location = new System.Drawing.Point(12, 12);
            this.dtgHoaDon.Margin = new System.Windows.Forms.Padding(12);
            this.dtgHoaDon.Name = "dtgHoaDon";
            this.dtgHoaDon.ReadOnly = true;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgHoaDon.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgHoaDon.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgHoaDon.RowTemplate.Height = 35;
            this.dtgHoaDon.Size = new System.Drawing.Size(1570, 787);
            this.dtgHoaDon.TabIndex = 41;
            // 
            // btnGuiDi
            // 
            this.btnGuiDi.BackColor = System.Drawing.Color.White;
            this.btnGuiDi.BackgroundColor = System.Drawing.Color.White;
            this.btnGuiDi.BorderColor = System.Drawing.Color.Black;
            this.btnGuiDi.BorderRadius = 15;
            this.btnGuiDi.BorderSize = 5;
            this.btnGuiDi.FlatAppearance.BorderSize = 0;
            this.btnGuiDi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuiDi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuiDi.ForeColor = System.Drawing.Color.Black;
            this.btnGuiDi.Image = global::WindowsFormsApp4.Properties.Resources.excel;
            this.btnGuiDi.Location = new System.Drawing.Point(1273, 12);
            this.btnGuiDi.Name = "btnGuiDi";
            this.btnGuiDi.Size = new System.Drawing.Size(317, 67);
            this.btnGuiDi.TabIndex = 119;
            this.btnGuiDi.Text = "Export and send reports";
            this.btnGuiDi.TextColor = System.Drawing.Color.Black;
            this.btnGuiDi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuiDi.UseVisualStyleBackColor = false;
            this.btnGuiDi.Click += new System.EventHandler(this.btnGuiDi_Click);
            // 
            // BaoCaoServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1615, 902);
            this.Controls.Add(this.btnGuiDi);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Name = "BaoCaoServices";
            this.Text = "BaoCaoServices";
            this.Load += new System.EventHandler(this.BaoCaoServices_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dtgHoaDon;
        private DuAnBanHang_Winforms_DBFirst.Views.DesignButtonClass btnGuiDi;
    }
}