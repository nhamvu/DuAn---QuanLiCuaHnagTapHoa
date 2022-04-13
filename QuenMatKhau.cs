using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class QuenMatKhau : Form
    {
        public QuenMatKhau()
        {
            InitializeComponent();
        }
        private bool CheckLoiSDTQLNV()
        {
            if (!Regex.Match(txtSDT.Text, @"^(0)[0-9]{9}$").Success)
            {
                MessageBox.Show("Số điện thoại không hợp lệ");
                return false;
            }
            else
            {
                return true;
            }// end if  
        }
        private bool CheckLoiMK()
        {
            if (!Regex.Match(txtMKMoi.Text, @"^[0-9a-zA-Z]+$").Success || txtMKMoi.Text.Length < 4)
            {
                MessageBox.Show("Mật khẩu mới chỉ bao gồm các kí tự chữ và số và phải từu 4 kí tự trở lên");
                return false;
            }
            else
            {
                return true;
            }// end if  
        }
        private bool ChecLoiTenTkQLNS()
        {
            if (!Regex.Match(txtTenTK.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success || txtTenTK.Text.Length > 50)
            {
                MessageBox.Show("Tên Tài khoản Không hợp lệ!!!");
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool CheckLoiNull()
        {
            if (!string.IsNullOrEmpty(txtTenTK.Text) && !string.IsNullOrEmpty(txtSDT.Text)
                && !string.IsNullOrEmpty(txtDC.Text) && !string.IsNullOrEmpty(txtMKMoi.Text)
                && !string.IsNullOrEmpty(txtNhapLaiMKMOI.Text))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Không được bỏ trống thông tin");
                return false;
            }// end if  
        }
        private bool CheckLoiDiaChiQLNS()
        {
            if (!Regex.Match(txtDC.Text, @"^[\w\s]+$").Success || txtDC.Text.Length > 100)
            {
                MessageBox.Show("Địa chỉ không hợp lệ");
                return false;
            }
            else
            {
                return true;
            }// end if  
        }
        private void QuenMatKhau_Load(object sender, EventArgs e)
        {

        }

        private void btnXacNhanDoi_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckLoiNull() == true && ChecLoiTenTkQLNS() == true && CheckLoiSDTQLNV() == true
                    && CheckLoiDiaChiQLNS() == true && CheckLoiMK() == true && CheckLoiMK() == true)
                {
                    if (MessageBox.Show("Bạn chắc chắn muốn đổi mật khẩu ?", "N Shop Flower",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (BUSINESS.General_BUS.QuenMK(txtTenTK.Text, txtSDT.Text, txtDC.Text, txtMKMoi.Text) == true)
                        {
                            MessageBox.Show("Đổi Mật khẩu thành công");
                        }
                        else
                        {
                            MessageBox.Show("Thông tin không chính xác");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo !");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn Thoát ?", "N Shop Flower",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Để lấy lại mật khẩu,bạn cần nhập đúng tên tài khoản và " +
                "số điện thoại cùng địa chỉ đã dùng để tạo tài khoản đó,nếu thông tin" +
                " không trùng khớp bạn không thể lấy lại", "N Shop Flower", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
