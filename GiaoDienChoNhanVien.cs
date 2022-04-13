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
    public partial class GiaoDienChoNhanVien : Form
    {
        public GiaoDienChoNhanVien()
        {
            InitializeComponent();
        }
        private string tentk, mk;
        private Form dform = null;
        public GiaoDienChoNhanVien(string ten, string mkhau)
        {
            InitializeComponent();
            this.tentk = ten;
            this.mk = mkhau;
        }

        private void btnDatHang_Click(object sender, EventArgs e)
        {
            txtLaBel.Text = "HOME";
            if (dform != null)
                dform.Close();
            GiaoDienChungCuaNV x = new GiaoDienChungCuaNV();
            x.tentk = tentk;
            x.tendn = lbTenDN.Text;
            dform = x;
            dform.TopLevel = false;
            x.Dock = DockStyle.Fill;
            x.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(x);
            panel1.Tag = x;
            dform.BringToFront();
            panel2.Height = btnDatHang.Height;
            panel2.Top = btnDatHang.Top;
            btnDatHang.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnDangXuat.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSanPham.TextImageRelation = TextImageRelation.ImageBeforeText;
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnKhachHang.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBaoCao.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnBaoCao.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.BorderSize = 0;
            btnSanPham.FlatAppearance.BorderSize = 0;
            btnDatHang.FlatAppearance.BorderSize = 3;
            btnKhachHang.FlatAppearance.BorderSize = 0;
            btnDangXuat.FlatAppearance.BorderSize = 0;
            x.Show();
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            txtLaBel.Text = "PRODUCT MANAGEMENT";
            if (dform != null)
                dform.Close();
            QLSPService x = new QLSPService();
            dform = x;
            dform.TopLevel = false;
            x.Dock = DockStyle.Fill;
            x.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(x);
            panel1.Tag = x;
            dform.BringToFront();
            panel2.Height = btnSanPham.Height;
            panel2.Top = btnSanPham.Top;
            btnSanPham.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnDatHang.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDangXuat.TextImageRelation = TextImageRelation.ImageBeforeText;
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnKhachHang.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBaoCao.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnBaoCao.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.BorderSize = 0;
            btnSanPham.FlatAppearance.BorderSize = 3;
            btnDatHang.FlatAppearance.BorderSize = 0;
            btnKhachHang.FlatAppearance.BorderSize = 0;
            btnDangXuat.FlatAppearance.BorderSize = 0;
            x.Show();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            txtLaBel.Text = "INVOICE MANAGEMENT";
            if (dform != null)
                dform.Close();
            QLBANHANGService z = new QLBANHANGService(tentk, mk);
            dform = z;
            dform.TopLevel = false;
            z.Dock = DockStyle.Fill;
            z.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(z);
            panel1.Tag = z;
            panel2.Height = btnKhachHang.Height;
            panel2.Top = btnKhachHang.Top;
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDatHang.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDangXuat.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSanPham.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnKhachHang.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnBaoCao.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnBaoCao.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.BorderSize = 0;
            btnSanPham.FlatAppearance.BorderSize = 0;
            btnDatHang.FlatAppearance.BorderSize = 0;
            btnKhachHang.FlatAppearance.BorderSize = 3;
            btnDangXuat.FlatAppearance.BorderSize = 0;
            dform.BringToFront();
            z.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtLaBel.Text = "INVOICE MANAGEMENT";
            if (dform != null)
                dform.Close();
            QLHoaDonServices v = new QLHoaDonServices();
            dform = v;
            dform.TopLevel = false;
            v.Dock = DockStyle.Fill;
            v.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(v);
            panel2.Height = button1.Height;
            panel2.Top = button1.Top;
            btnKhachHang.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDatHang.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDangXuat.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSanPham.TextImageRelation = TextImageRelation.ImageBeforeText;
            button1.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnBaoCao.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnBaoCao.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.BorderSize = 3;
            btnSanPham.FlatAppearance.BorderSize = 0;
            btnDatHang.FlatAppearance.BorderSize = 0;
            btnKhachHang.FlatAppearance.BorderSize = 0;
            btnDangXuat.FlatAppearance.BorderSize = 0;
            panel1.Tag = v;
            dform.BringToFront();
            v.Show();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            panel2.Height = btnDangXuat.Height;
            panel2.Top = btnDangXuat.Top;
            btnDangXuat.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSanPham.TextImageRelation = TextImageRelation.ImageBeforeText;
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnKhachHang.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDatHang.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBaoCao.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnBaoCao.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.BorderSize = 0;
            btnSanPham.FlatAppearance.BorderSize = 0;
            btnDatHang.FlatAppearance.BorderSize = 0;
            btnKhachHang.FlatAppearance.BorderSize = 0;
            btnDangXuat.FlatAppearance.BorderSize = 3;
            if (MessageBox.Show("Bạn chắc chắn muốn đăng xuất ?", "N Shop Flower",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnDatHang_MouseEnter(object sender, EventArgs e)
        {
            btnDatHang.BackColor = Color.CornflowerBlue;
        }

        private void btnDatHang_MouseLeave(object sender, EventArgs e)
        {
            btnDatHang.BackColor = Color.DodgerBlue;
        }

        private void btnSanPham_MouseEnter(object sender, EventArgs e)
        {
            btnSanPham.BackColor = Color.CornflowerBlue;
        }

        private void btnSanPham_MouseLeave(object sender, EventArgs e)
        {
            btnSanPham.BackColor = Color.DodgerBlue;
        }

        private void btnKhachHang_MouseEnter(object sender, EventArgs e)
        {
            btnKhachHang.BackColor = Color.CornflowerBlue;
        }

        private void btnKhachHang_MouseLeave(object sender, EventArgs e)
        {
            btnKhachHang.BackColor = Color.DodgerBlue;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.DodgerBlue;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.CornflowerBlue;
        }

        private void btnDangXuat_MouseLeave(object sender, EventArgs e)
        {
            btnDangXuat.BackColor = Color.DodgerBlue;
        }

        private void btnDangXuat_MouseEnter(object sender, EventArgs e)
        {
            btnDangXuat.BackColor = Color.CornflowerBlue;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbNgay.Text = DateTime.Now.ToString("D");
            lbGio.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void designButtonClass1_Click(object sender, EventArgs e)
        {

        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            txtLaBel.Text = "REPORT";
            if (dform != null)
                dform.Close();
            BaoCaoServices z = new BaoCaoServices(tentk,mk);
            dform = z;
            dform.TopLevel = false;
            z.Dock = DockStyle.Fill;
            z.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(z);
            panel1.Tag = z;
            panel2.Height = btnBaoCao.Height;
            panel2.Top = btnBaoCao.Top;
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDatHang.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDangXuat.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSanPham.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBaoCao.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnKhachHang.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnKhachHang.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.BorderSize = 0;
            btnSanPham.FlatAppearance.BorderSize = 0;
            btnDatHang.FlatAppearance.BorderSize = 0;
            btnBaoCao.FlatAppearance.BorderSize = 3;
            btnDangXuat.FlatAppearance.BorderSize = 0;
            dform.BringToFront();
            z.Show();
        }

        private void btnBaoCao_MouseEnter(object sender, EventArgs e)
        {
            btnBaoCao.BackColor = Color.CornflowerBlue;
        }

        private void btnBaoCao_MouseLeave(object sender, EventArgs e)
        {
            btnBaoCao.BackColor = Color.DodgerBlue;
        }

        private void designPictureboxClass1_DoubleClick(object sender, EventArgs e)
        {
            txtLaBel.Text = "PERSONAL INFORMATION";
            if (dform != null)
                dform.Close();
            ThongTinCaNhan tt = new ThongTinCaNhan(tentk, mk);
            dform = tt;
            dform.TopLevel = false;
            tt.Dock = DockStyle.Fill;
            tt.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(tt);
            panel1.Tag = tt;
            dform.BringToFront();
            tt.Show();
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {

        }

        private void GiaoDienChoNhanVien_Load(object sender, EventArgs e)
        {
            #region load dữ liệu lên các label
            DB__4Entities du = new DB__4Entities();
            //Hiển thị tên tài khoản
            label10.Text = tentk;
            var tendn = from x in du.NhanViens
                        where x.TenTaiKhoan == tentk && x.MatKhau == mk
                        select new
                        {
                            x.TenNhanVien
                        };
            lbTenDN.Text = tendn.FirstOrDefault().ToString().Split('=')[1].Replace("}", "");

            var nv = (from x in du.NhanViens
                      where x.TenTaiKhoan == tentk && x.MatKhau == mk
                      select x).FirstOrDefault();
            MemoryStream memoryStream = new MemoryStream(nv.Images.ToArray());
            Image imgs = Image.FromStream(memoryStream);
            if (imgs != null)
            {
                designPictureboxClass1.Image = imgs;
            }
            #endregion

            txtLaBel.Text = "HOME";
            if (dform != null)
                dform.Close();
            GiaoDienChungCuaNV y = new GiaoDienChungCuaNV();
            y.tentk = tentk;
            y.tendn = lbTenDN.Text;
            dform = y;
            dform.TopLevel = false;
            y.Dock = DockStyle.Fill;
            y.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(y);
            panel1.Tag = y;
            dform.BringToFront();
            panel2.Height = btnDatHang.Height;
            panel2.Top = btnDatHang.Top;
            btnDatHang.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnDangXuat.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSanPham.TextImageRelation = TextImageRelation.ImageBeforeText;
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnKhachHang.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBaoCao.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnBaoCao.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.BorderSize = 0;
            btnSanPham.FlatAppearance.BorderSize = 0;
            btnDatHang.FlatAppearance.BorderSize = 3;
            btnKhachHang.FlatAppearance.BorderSize = 0;
            btnDangXuat.FlatAppearance.BorderSize = 0;
            y.Show();
        }
    }
}
