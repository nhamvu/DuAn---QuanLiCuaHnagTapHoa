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
    public partial class QuanLiBanHangg : Form
    {
        public QuanLiBanHangg()
        {
            InitializeComponent();
        }
        private string tentk, mk;
        private Form dform = null;
        public QuanLiBanHangg(string ten, string mkhau)
        {
            InitializeComponent();
            this.tentk = ten;
            this.mk = mkhau;
        }
        private void QuanLiBanHangg_Load(object sender, EventArgs e)
        {
            //Đổi màu button
            button1.FlatAppearance.BorderSize = 3;
            btnSanPham.FlatAppearance.BorderSize = 0;
            btnHoaDon.FlatAppearance.BorderSize = 0;
            btnNhanSu.FlatAppearance.BorderSize = 0;
            btnGiamGia.FlatAppearance.BorderSize = 0;
            btnThongKe.FlatAppearance.BorderSize = 0;
            btnDangXuat.FlatAppearance.BorderSize = 0;

            #region load dữ liệu lên các label
            DB__4Entities du = new DB__4Entities();
            //Hiển thị tên tài khoản
            label10.Text = tentk;
            if (tentk.EndsWith("@manager.store.vn"))
            {
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
            }
            else if (tentk.EndsWith("@staff.store.vn"))
            {
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
                btnNhanSu.Enabled = false;
                btnThongKe.Enabled = false;
                btnGiamGia.Enabled = false;
            }


            #endregion
            txtLaBel.Text = "PRODUCT";
            if (dform != null)
                dform.Close();
            QLBANHANGService ht = new QLBANHANGService(tentk, mk);
            dform = ht;
            dform.TopLevel = false;
            ht.Dock = DockStyle.Fill;
            ht.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(ht);
            panel1.Tag = ht;
            dform.BringToFront();
            panel2.Height = button1.Height;
            panel2.Top = button1.Top;
            button1.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnDangXuat.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSanPham.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNhanSu.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnThongKe.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnGiamGia.TextImageRelation = TextImageRelation.ImageBeforeText;
            ht.Show();
        }

        private void btnSanPham_MouseEnter(object sender, EventArgs e)
        {
            btnSanPham.BackColor = Color.CornflowerBlue;
        }

        private void btnSanPham_MouseLeave(object sender, EventArgs e)
        {
            btnSanPham.BackColor = Color.DodgerBlue;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.CornflowerBlue;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.DodgerBlue;
        }

        private void btnThongKe_MouseEnter(object sender, EventArgs e)
        {
            btnThongKe.BackColor = Color.CornflowerBlue;
        }

        private void btnThongKe_MouseLeave(object sender, EventArgs e)
        {
            btnThongKe.BackColor = Color.DodgerBlue;
        }

        private void btnDangXuat_MouseEnter(object sender, EventArgs e)
        {
            btnDangXuat.BackColor = Color.CornflowerBlue;
        }

        private void btnDangXuat_MouseLeave(object sender, EventArgs e)
        {
            btnDangXuat.BackColor = Color.DodgerBlue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtLaBel.Text = "SELL";
            if (dform != null)
                dform.Close();
            QLBANHANGService z = new QLBANHANGService(tentk, mk);
            dform = z;
            dform.TopLevel = false;
            z.Dock = DockStyle.Fill;
            z.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(z);
            panel1.Tag = z;
            panel2.Height = button1.Height;
            panel2.Top = button1.Top;
            button1.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnHoaDon.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDangXuat.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSanPham.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNhanSu.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnThongKe.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnGiamGia.TextImageRelation = TextImageRelation.ImageBeforeText;
            dform.BringToFront();

            button1.FlatAppearance.BorderSize = 3;
            btnSanPham.FlatAppearance.BorderSize = 0;
            btnHoaDon.FlatAppearance.BorderSize = 0;
            btnNhanSu.FlatAppearance.BorderSize = 0;
            btnGiamGia.FlatAppearance.BorderSize = 0;
            btnThongKe.FlatAppearance.BorderSize = 0;
            btnDangXuat.FlatAppearance.BorderSize = 0;
            z.Show();
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            txtLaBel.Text = "BILL";
            if (dform != null)
                dform.Close();
            QLSPService z = new QLSPService();
            dform = z;
            dform.TopLevel = false;
            z.Dock = DockStyle.Fill;
            z.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(z);
            panel1.Tag = z;
            panel2.Height = button1.Height;
            panel2.Top = button1.Top;
            btnSanPham.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnHoaDon.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDangXuat.TextImageRelation = TextImageRelation.ImageBeforeText;
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNhanSu.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnThongKe.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnGiamGia.TextImageRelation = TextImageRelation.ImageBeforeText;
            dform.BringToFront();

            btnSanPham.FlatAppearance.BorderSize = 3;
            button1.FlatAppearance.BorderSize = 0;
            btnHoaDon.FlatAppearance.BorderSize = 0;
            btnNhanSu.FlatAppearance.BorderSize = 0;
            btnGiamGia.FlatAppearance.BorderSize = 0;
            btnThongKe.FlatAppearance.BorderSize = 0;
            btnDangXuat.FlatAppearance.BorderSize = 0;
            z.Show();
        }

        private void btnNhanSu_Click(object sender, EventArgs e)
        {
            txtLaBel.Text = "PERSONNEL MANAGEMENT";
            if (dform != null)
                dform.Close();
            QLNhanSuService y = new QLNhanSuService();
            dform = y;
            dform.TopLevel = false;
            y.Dock = DockStyle.Fill;
            y.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(y);
            panel1.Tag = y;
            panel2.Height = btnNhanSu.Height;
            panel2.Top = btnNhanSu.Top;
            btnNhanSu.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnHoaDon.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDangXuat.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSanPham.TextImageRelation = TextImageRelation.ImageBeforeText;
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnThongKe.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnGiamGia.TextImageRelation = TextImageRelation.ImageBeforeText;

            button1.FlatAppearance.BorderSize = 0;
            btnSanPham.FlatAppearance.BorderSize = 0;
            btnHoaDon.FlatAppearance.BorderSize = 0;
            btnNhanSu.FlatAppearance.BorderSize = 3;
            btnGiamGia.FlatAppearance.BorderSize = 0;
            btnThongKe.FlatAppearance.BorderSize = 0;
            btnDangXuat.FlatAppearance.BorderSize = 0;
            dform.BringToFront();
            y.Show();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            txtLaBel.Text = "STATICALS";
            if (dform != null)
                dform.Close();
            Statical v = new Statical();
            dform = v;
            dform.TopLevel = false;
            v.Dock = DockStyle.Fill;
            v.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(v);
            panel1.Tag = v;
            dform.BringToFront();
            panel2.Height = btnThongKe.Height;
            panel2.Top = btnThongKe.Top;
            btnThongKe.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnHoaDon.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDangXuat.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSanPham.TextImageRelation = TextImageRelation.ImageBeforeText;
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNhanSu.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnGiamGia.TextImageRelation = TextImageRelation.ImageBeforeText;

            button1.FlatAppearance.BorderSize = 0;
            btnSanPham.FlatAppearance.BorderSize = 0;
            btnHoaDon.FlatAppearance.BorderSize = 0;
            btnNhanSu.FlatAppearance.BorderSize = 0;
            btnGiamGia.FlatAppearance.BorderSize = 0;
            btnThongKe.FlatAppearance.BorderSize = 3;
            btnDangXuat.FlatAppearance.BorderSize = 0;
            v.Show();
        }

        private void btnGiamGia_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void btnGiamGia_MouseEnter(object sender, EventArgs e)
        {
            btnGiamGia.BackColor = Color.CornflowerBlue;
        }

        private void btnGiamGia_MouseLeave(object sender, EventArgs e)
        {
            btnGiamGia.BackColor = Color.DodgerBlue;
        }

        private void btnGiamGia_Click(object sender, EventArgs e)
        {
            txtLaBel.Text = "EVENTS MANAGEMENTS";
            if (dform != null)
                dform.Close();
            GiamGiaService z = new GiamGiaService();
            dform = z;
            dform.TopLevel = false;
            z.Dock = DockStyle.Fill;
            z.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(z);
            panel1.Tag = z;
            dform.BringToFront();
            panel2.Height = btnGiamGia.Height;
            panel2.Top = btnGiamGia.Top;
            btnGiamGia.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnHoaDon.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDangXuat.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSanPham.TextImageRelation = TextImageRelation.ImageBeforeText;
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNhanSu.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnThongKe.TextImageRelation = TextImageRelation.ImageBeforeText;

            button1.FlatAppearance.BorderSize = 0;
            btnSanPham.FlatAppearance.BorderSize = 0;
            btnHoaDon.FlatAppearance.BorderSize = 0;
            btnNhanSu.FlatAppearance.BorderSize = 0;
            btnGiamGia.FlatAppearance.BorderSize = 3;
            btnThongKe.FlatAppearance.BorderSize = 0;
            btnDangXuat.FlatAppearance.BorderSize = 0;
            z.Show();
        }

        private void designPictureboxClass1_DoubleClick(object sender, EventArgs e)
        {
            txtLaBel.Text = "PERSONAL INFORMATION";
            if (dform != null)
                dform.Close();
            //ThongTinCaNhan t = new ThongTinCaNhan();
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

        private void designPictureboxClass1_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(designPictureboxClass1, "Personal Information");
        }

        private void btnHoaDon_MouseEnter(object sender, EventArgs e)
        {
            btnHoaDon.BackColor = Color.CornflowerBlue;
        }

        private void btnHoaDon_MouseLeave(object sender, EventArgs e)
        {
            btnHoaDon.BackColor = Color.DodgerBlue;
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            txtLaBel.Text = "INVOICE MANAGEMENTS";
            if (dform != null)
                dform.Close();
            QLHoaDonServices z = new QLHoaDonServices();
            dform = z;
            dform.TopLevel = false;
            z.Dock = DockStyle.Fill;
            z.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(z);
            panel1.Tag = z;
            panel2.Height = button1.Height;
            panel2.Top = button1.Top;
            btnHoaDon.TextImageRelation = TextImageRelation.TextBeforeImage;
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDangXuat.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSanPham.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNhanSu.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnThongKe.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnGiamGia.TextImageRelation = TextImageRelation.ImageBeforeText;
            dform.BringToFront();

            btnHoaDon.FlatAppearance.BorderSize = 3;
            btnSanPham.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.BorderSize = 0;
            btnNhanSu.FlatAppearance.BorderSize = 0;
            btnGiamGia.FlatAppearance.BorderSize = 0;
            btnThongKe.FlatAppearance.BorderSize = 0;
            btnDangXuat.FlatAppearance.BorderSize = 0;
            z.Show();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            panel2.Height = btnDangXuat.Height;
            panel2.Top = btnDangXuat.Top;
            btnDangXuat.TextImageRelation = TextImageRelation.TextBeforeImage;
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnHoaDon.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSanPham.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNhanSu.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnThongKe.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnGiamGia.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnDangXuat.FlatAppearance.BorderSize = 3;
            btnSanPham.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.BorderSize = 0;
            btnNhanSu.FlatAppearance.BorderSize = 0;
            btnGiamGia.FlatAppearance.BorderSize = 0;
            btnThongKe.FlatAppearance.BorderSize = 0;
            btnHoaDon.FlatAppearance.BorderSize = 0;
            if (MessageBox.Show("Bạn chắc chắn muốn đăng xuất ?", "N Shop Flower",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbNgay.Text = DateTime.Now.ToString("D");
            lbGio.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
