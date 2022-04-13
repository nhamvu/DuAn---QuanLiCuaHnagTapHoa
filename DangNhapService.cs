using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data_Transfer_Object;


namespace WindowsFormsApp4
{
    public partial class DangNhapService : Form
    {
        public DangNhapService()
        {
            InitializeComponent();
        }

        private void DangNhapService_Load(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn Thoát ?", "N Shop Flower",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private bool CheckLoiNull()
        {
            if (!string.IsNullOrEmpty(txtTenTK.Text)
                && !string.IsNullOrEmpty(txtMK.Text))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Không được bỏ trống thông tin", "N Shop Flower", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool CheckLoiTenTk()
        {

            if (!Regex.Match(txtTenTK.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)|\w+@manager.store.vn|\w+@staff.store.vn$").Success
                || txtTenTK.Text.Length > 50)
            {
                MessageBox.Show("Tên Tài khoản Không hợp lệ");
                return false;
            }
            else
            {
                return true;
            }
        }

        void GuiMaill(string from, string to, string subject, string message)
        {
            try
            {
                MailMessage mess = new MailMessage(from, to, subject, message);
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("vuducnham1123@gmail.com", "14082002nham");
                client.Send(mess);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtMK_TextChanged(object sender, EventArgs e)
        {
            if (txtMK.Text.Length > 15)
            {
                MessageBox.Show("Mật khẩu không được dài quá 15 kí tự");
            }
        }

        private void txtTenTK_TextChanged(object sender, EventArgs e)
        {
            if (txtTenTK.Text.Length > 50)
            {
                MessageBox.Show("Tên tài khoản không được vượt quá 50 kí tự");
            }
        }

        private void txtTenTK_MouseEnter(object sender, EventArgs e)
        {
            if (txtTenTK.Text == "email")
            {
                txtTenTK.Text = "";
                txtTenTK.ForeColor = Color.Black;
            }
        }

        private void txtTenTK_MouseLeave(object sender, EventArgs e)
        {
            if (txtTenTK.Text == "")
            {
                txtTenTK.Text = "email";
                txtTenTK.ForeColor = Color.DimGray;
            }
        }

        private void txtMK_MouseLeave(object sender, EventArgs e)
        {
            if (txtMK.Text == "")
            {
                txtMK.Text = "password";
                txtMK.ForeColor = Color.DimGray;
            }
        }

        private void txtMK_MouseEnter(object sender, EventArgs e)
        {
            if (txtMK.Text == "password")
            {
                txtMK.Text = "";
                txtMK.ForeColor = Color.Black;
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckLoiNull() == true && CheckLoiTenTk() == true)
                {
                    if (BUSINESS.General_BUS.DangNhap(txtTenTK.Text, txtMK.Text) == true)
                    {
                        if (txtTenTK.Text.EndsWith("@staff.store.vn"))
                        {
                            GiaoDienChoNhanVien vn = new GiaoDienChoNhanVien(txtTenTK.Text, txtMK.Text);
                            ThongTinCaNhan tt = new ThongTinCaNhan(txtTenTK.Text, txtMK.Text);
                            vn.ShowDialog();
                            this.Close();
                        }
                        else if (txtTenTK.Text.EndsWith("@manager.store.vn"))
                        {
                            QuanLiBanHangg vn = new QuanLiBanHangg(txtTenTK.Text, txtMK.Text);
                            ThongTinCaNhan tt = new ThongTinCaNhan(txtTenTK.Text, txtMK.Text);
                            vn.ShowDialog();
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!\nVui lòng nhập lại !!!",
                            "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo !");
            }
        }

        private void designButtonClass2_Click(object sender, EventArgs e)
        {
            if (txtMK.UseSystemPasswordChar == true)
            {
                txtMK.UseSystemPasswordChar = false;
                designButtonClass2.Image = Properties.Resources.show;
            }
            else if (txtMK.UseSystemPasswordChar == false)
            {
                txtMK.UseSystemPasswordChar = true;
                designButtonClass2.Image = Properties.Resources.tải_xuống__3_;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckLoiTenTk() == true)
                {
                    DB__4Entities du = new DB__4Entities();
                    var pass = (from x in du.NhanViens.ToList()
                                where x.TenTaiKhoan.ToLower() == txtTenTK.Text.ToLower()
                                select x.MatKhau).FirstOrDefault();
                    if (pass != null)
                    {
                        GuiMaill("vuducnham1123@gmail.com", txtTenTK.Text, "Your Password is  ", pass);
                        if (MessageBox.Show("Bạn có muốn kiểm tra mail ngay không?", "Gửi thành công", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start("https://mail.google.com/mail/u/0/#inbox");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản không tồn tại hoặc không hợp lệ");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gửi không thành công" + ex.Message);
            }
        }
    }
}
