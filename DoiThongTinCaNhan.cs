using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data_Transfer_Object;

namespace WindowsFormsApp4
{
    public partial class DoiThongTinCaNhan : Form
    {
        public DoiThongTinCaNhan()
        {
            InitializeComponent();
        }
        private bool CheckLoiNullQLNV()
        {
            if (!string.IsNullOrEmpty(txtMaNVQLNV.Text)
                && !string.IsNullOrEmpty(txtTenNVQLNV.Text) && !string.IsNullOrEmpty(txtTenTK.Text) &&
                !string.IsNullOrEmpty(txtMK.Text) &&
                !string.IsNullOrEmpty(txtSDTQLNV.Text) &&
                !string.IsNullOrEmpty(txtDCQLNV.Text))
            {

                return true;
            }
            else
            {
                MessageBox.Show("Không được bỏ trống thông tin", "N Shop Flower", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool CheckLoiSDTQLNV()
        {
            if (!Regex.Match(txtSDTQLNV.Text, @"^(0)[0-9]{9}$").Success)
            {
                MessageBox.Show("Số điện thoại không hợp lệ");
                return false;
            }
            else
            {
                return true;
            }// end if  
        }
        private bool CheckLoiMaNVQLNV()
        {
            if (!Regex.IsMatch(txtMaNVQLNV.Text, @"^[NV]+\d{5}$") || txtMaNVQLNV.Text.Length > 16)
            {
                MessageBox.Show("Mã NV phải bắt đầu bằng NV và gồm ít nhất 5 số");
                return false;
            }
            else
            {
                return true;
            }// end if  
        }

        private bool ChecLoiTenNV()
        {
            string muihuong = txtTenNVQLNV.Text;
            bool result = muihuong.Replace(" ", "").All(Char.IsLetter);
            if (result == false || txtTenNVQLNV.Text.Length > 50)
            {
                MessageBox.Show("Tên NV không hợp lệ");
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool CheckLoiMK()
        {
            if (!Regex.Match(txtMK.Text, @"^[0-9a-zA-Z]+$").Success || txtMK.Text.Length < 4)
            {
                MessageBox.Show("Mật khẩu chỉ bao gồm các kí tự chữ và số và phải từu 4 kí tự trở lên");
                return false;
            }
            else
            {
                return true;
            }// end if  
        }
        private bool ChecLoiTenTkQLNS()
        {
            string email = txtTenTK.Text;
            Regex regexemail = new Regex(@"^\w+ ([@gmail.com] || +[@fpt.edu.vn])+$");
            Match match = regexemail.Match(email);
            if (!Regex.Match(txtTenTK.Text, @"\w+@manager.store.vn|\w+@staff.store.vn").Success || txtTenTK.Text.Length > 50)
            {
                MessageBox.Show("Tên Tài khoản phải có đuôi là @manager.store.vn(nếu là Quản lí) " +
                    "hoặc @staff.store.vn(nếu là Nhân Viên) và không được dài hơn 50 kí tự");
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool CheckLoiDiaChiQLNS()
        {
            if (!Regex.Match(txtDCQLNV.Text, @"^[\w\s]+$").Success || txtDCQLNV.Text.Length > 100)
            {
                MessageBox.Show("Địa chỉ không hợp lệ");
                return false;
            }
            else
            {
                return true;
            }// end if  
        }
        private bool CheckLoiNgaySinh()
        {
            if (dateTimePickerNgaySinh.Value > Convert.ToDateTime("2004-01-01 18:00:00.142"))
            {
                MessageBox.Show("Tuổi không được nhỏ hơn 18");
                return false;
            }
            else
            {
                return true;
            }
        }
        private void DoiThongTinCaNhan_Load(object sender, EventArgs e)
        {

        }
        private byte[] ImagesToBySP(PictureBox picture)
        {
            MemoryStream memoryStream = new MemoryStream();
            picture.Image.Save(memoryStream, picture.Image.RawFormat);
            return memoryStream.ToArray();
        }
        private void btnXemQLNS_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckLoiNullQLNV() == true && CheckLoiMaNVQLNV() == true && ChecLoiTenNV()
                    == true && ChecLoiTenTkQLNS() == true && CheckLoiMK() == true
                    && CheckLoiSDTQLNV() == true && CheckLoiNgaySinh() == true &&
                    CheckLoiDiaChiQLNS() == true)
                {
                    if (MessageBox.Show("Bạn chắc chắn muốn Sửa ?", "N Shop Flower",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        byte[] anh = ImagesToBySP(pcAnhNV);
                        BUSINESS.NhanVienBUS.SuaThongTinNhanVien(txtMaNVQLNV.Text, txtTenNVQLNV.Text,
                            dateTimePickerNgaySinh.Value, txtTenTK.Text, txtMK.Text, rdNam.Checked == true ? 0 : 1,
                            txtSDTQLNV.Text, txtDCQLNV.Text, anh);
                        MessageBox.Show("Đổi thành công");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pcAnhNV_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string imgLocation = "";//tạo biến để lưu đường dẫ cho ảnh
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.ShowDialog();
                //khi mình chọn 1 file thì đường dẫn của file sẽ được lưu lại
                imgLocation = dialog.FileName;//FileName là thuộc tính lưu lại đường dẫn
                pcAnhNV.Image = Image.FromFile(imgLocation);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txtSDTQLNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Số điện thoại không hợp lệ");
                e.Handled = true;
            }
        }
    }
}
