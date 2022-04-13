using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data_Transfer_Object;

namespace WindowsFormsApp4
{
    public partial class ThongTinCaNhan : Form
    {
        public ThongTinCaNhan()
        {
            InitializeComponent();
        }
        private string tentk, mk;
        public ThongTinCaNhan(string ten, string mkhau)
        {
            InitializeComponent();
            this.tentk = ten;
            this.mk = mkhau;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DoiThongTinCaNhan d = new DoiThongTinCaNhan();
            d.ShowDialog();
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            QuenMatKhau qmk = new QuenMatKhau();
            qmk.ShowDialog();
        }

        private void ThongTinCaNhan_Load(object sender, EventArgs e)
        {
            try
            {
                DB__4Entities du = new DB__4Entities();
                lbTenTKQLKhac.Text = tentk;
                txtMK.Text = mk;
                var maNS = from x in du.NhanViens
                           where x.TenTaiKhoan == tentk && x.MatKhau == txtMK.Text
                           select new
                           {
                               x.MaNV
                           };
                lbMaNhanSuQuanLiKhac.Text = maNS.FirstOrDefault().ToString().Split('=')[1].Replace("}", "");
                var tendn = from x in du.NhanViens
                            where x.TenTaiKhoan == lbTenTKQLKhac.Text && x.MatKhau == txtMK.Text
                            select new
                            {
                                x.TenNhanVien
                            };
                lbTenDangNhapQLKHac.Text = tendn.FirstOrDefault().ToString().Split('=')[1].Replace("}", "");
                label1.Text = lbTenDangNhapQLKHac.Text;
                var gt = from x in du.NhanViens
                         where x.TenTaiKhoan == lbTenTKQLKhac.Text && x.MatKhau == txtMK.Text
                         select new
                         {
                             x.GioiTinh
                         };
                string gtinh = gt.FirstOrDefault().ToString().Split('=')[1].Replace("}", "");
                if (gtinh.Contains("0"))
                {
                    lbGioiTinhQLKHac.Text = "Nam";
                }
                else if (gtinh.Contains("1"))
                {
                    lbGioiTinhQLKHac.Text = "Nữ";
                }
                //lbGioiTinhQLKHac.Text == "0" ? "Nam" : "Nữ";
                var ngsinh = from x in du.NhanViens
                             where x.TenTaiKhoan == lbTenTKQLKhac.Text && x.MatKhau == txtMK.Text
                             select new
                             {
                                 x.NgaySinh
                             };
                lbNgaySinhQLKhac.Text = ngsinh.FirstOrDefault().ToString().Split('=')[1].Replace("}", "");
                var sdt = from x in du.NhanViens
                          where x.TenTaiKhoan == lbTenTKQLKhac.Text && x.MatKhau == txtMK.Text
                          select new
                          {
                              x.SDT
                          };
                lbSDTQLKhac.Text = sdt.FirstOrDefault().ToString().Split('=')[1].Replace("}", "");
                var dc = from x in du.NhanViens
                         where x.TenTaiKhoan == lbTenTKQLKhac.Text && x.MatKhau == txtMK.Text
                         select new
                         {
                             x.DiaChi
                         };
                lbDCQLKhac.Text = dc.FirstOrDefault().ToString().Split('=')[1].Replace("}", "");

                var nv = (from x in du.NhanViens
                          where x.TenTaiKhoan == tentk && x.MatKhau == mk
                          select x).FirstOrDefault();
                MemoryStream memoryStream = new MemoryStream(nv.Images.ToArray());
                Image imgs = Image.FromStream(memoryStream);
                if (imgs != null)
                {
                    designPictureboxClass1.Image = imgs;
                    pictureBoxAvartar2.Image = imgs;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
