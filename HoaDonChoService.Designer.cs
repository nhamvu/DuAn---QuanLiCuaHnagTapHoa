
namespace WindowsFormsApp4
{
    partial class HoaDonChoService
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
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.btnThemm = new DuAnBanHang_Winforms_DBFirst.Views.DesignButtonClass();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 20);
            this.label3.TabIndex = 130;
            this.label3.Text = "Customer Name:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(162, 55);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(318, 5);
            this.panel3.TabIndex = 132;
            // 
            // txtTenKH
            // 
            this.txtTenKH.BackColor = System.Drawing.Color.White;
            this.txtTenKH.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTenKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenKH.Location = new System.Drawing.Point(160, 26);
            this.txtTenKH.Multiline = true;
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(320, 27);
            this.txtTenKH.TabIndex = 131;
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
            this.btnThemm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemm.ForeColor = System.Drawing.Color.Black;
            this.btnThemm.Image = global::WindowsFormsApp4.Properties.Resources.tải_xuống;
            this.btnThemm.Location = new System.Drawing.Point(527, 14);
            this.btnThemm.Name = "btnThemm";
            this.btnThemm.Size = new System.Drawing.Size(117, 58);
            this.btnThemm.TabIndex = 133;
            this.btnThemm.Text = "   Add";
            this.btnThemm.TextColor = System.Drawing.Color.Black;
            this.btnThemm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThemm.UseVisualStyleBackColor = false;
            this.btnThemm.Click += new System.EventHandler(this.btnThemm_Click);
            // 
            // HoaDonChoService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 79);
            this.Controls.Add(this.btnThemm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtTenKH);
            this.Name = "HoaDonChoService";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CREATE INVOICE WAITING";
            this.Load += new System.EventHandler(this.HoaDonChoService_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DuAnBanHang_Winforms_DBFirst.Views.DesignButtonClass btnThemm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtTenKH;
    }
}