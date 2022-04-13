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
    public partial class ChiTietSanPhamServices : Form
    {
        public string masp, tensp, dongia, soluongcon, tenkh;
        public Image pc;
        public ChiTietSanPhamServices()
        {
            InitializeComponent();
        }

        private void designButtonaddToCart_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckLoiNull() == true && CheckLoiSoLuong() == true)
                {
                    BUSINESS.HoaDonBUS.ThemGioHang(DateTime.Now.ToString("yyMMdd") + CreateMaHD(9), lbMaSP.Text, lbTenSP.Text, Convert.ToInt32(txtSoLuong.Text), Convert.ToSingle(txtDonGiaG.Text), tenkh);
                    MessageBox.Show("Đã thêm vào giỏ hàng!!!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo !");
            }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.Match(txtSoLuong.Text, @"^\d+$").Success)
            {
                MessageBox.Show("Số lượng không hợp lệ");
            }
            else if (int.Parse(txtSoLuong.Text) > int.Parse(label16.Text))
            {
                MessageBox.Show("Số lượng không được lớn hơn số lượng còn lại");
                txtSoLuong.Clear();
            }
            else if (txtSoLuong.Text != "")
            {
                double tt = Convert.ToInt32(txtSoLuong.Text) * Convert.ToDouble(txtDonGiaG.Text);
                txtThanhTien.Text = (string.Format("{0:0,0} VNĐ", Convert.ToDouble(tt)));
            }
            else if (txtSoLuong.Text == "")
            {
                txtThanhTien.Text = "0";
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Số lượng không hợp lệ");
                e.Handled = true;
            }
        }

        private bool CheckLoiNull()
        {
            if (!string.IsNullOrEmpty(txtSoLuong.Text))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin để đặt hàng", "N Shop Flower", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool CheckLoiSoLuong()
        {
            if (string.IsNullOrEmpty(txtSoLuong.Text))
            {
                MessageBox.Show("Vui lòng nhập Số lượng");
                return false;
            }
            else if (int.Parse(txtSoLuong.Text) < 0 || int.Parse(txtSoLuong.Text) > Convert.ToInt32(label16.Text))
            {
                MessageBox.Show("Số lượng không được lớn hơn số lượng còn lại của sản phẩm", "N Shop Flower",
                    MessageBoxButtons.OK, MessageBoxIcon.Question);
                return false;
            }
            else
            {
                return true;
            }
        }
        public string CreateMaHD(int length)
        {
            const string valid = "QWERTYUIOPASDFGHJKLZXCVBNM0123456789";
            StringBuilder res = new StringBuilder();
            Random rd = new Random();
            while (0 < length--)  //Chạy đến khi đủ độ dài mật khẩu mong muốn
            {
                res.Append(valid[rd.Next(valid.Length)]); //Add thêm kí từ random trong valid
            }
            return res.ToString();
        }
        private void ChiTietSanPhamServices_Load(object sender, EventArgs e)
        {
            lbMaSP.Text = masp;
            lbTenSP.Text = tensp;
            pictureBoxAnhSP.Image = pc;
            label16.Text = soluongcon;
            DB__4Entities db = new DB__4Entities();

            var dsUser = (from x in db.SanPhams.ToList()
                         from y in db.GiamGiaChiTiets.ToList() where x.MaSP == y.MaSP
                         from z in db.GiamGias.ToList() where z.MaGiamGia == y.MaGiamGia
                         where x.MaSP == masp.Trim() && y.TrangThai == "Đang diễn ra"
                         select z).FirstOrDefault();
            txtDonGiaG.Text = dongia;
            if (dsUser != null)
            {
                if (dsUser.DonViGiamGia.ToString() == "0")
                {
                    lbMucGiamGia.Text = dsUser.MucGiamGia.ToString() + "%";
                    txtDonGiaG.Text = (Convert.ToDouble(txtDonGiaG.Text) - (Convert.ToDouble(dsUser.MucGiamGia.ToString()) / Convert.ToDouble(txtDonGiaG.Text) * 100)).ToString();
                }
                else if (dsUser.DonViGiamGia.ToString() == "1")
                {
                    lbMucGiamGia.Text = string.Format("{0:0,0} VNĐ", Convert.ToDouble(dsUser.MucGiamGia.ToString()));
                    txtDonGiaG.Text = (Convert.ToDouble(txtDonGiaG.Text) - (Convert.ToDouble(dsUser.MucGiamGia.ToString()))).ToString();
                }
            }
            else
            {
                txtDonGiaG.Text = dongia;
                lbMucGiamGia.Text = "0 VNĐ";
            }
        }
    }
}
