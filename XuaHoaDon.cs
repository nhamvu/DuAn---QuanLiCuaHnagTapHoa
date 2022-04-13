using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class XuaHoaDon : Form
    {
        public string mahd;
        private Bitmap memoryimng;
        public XuaHoaDon()
        {
            InitializeComponent();
        }

        private void XuaHoaDon_Load(object sender, EventArgs e)
        {
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            //Load danh sách sản phẩm
            var r = from x in BUSINESS.HoaDonBUS.LoadHoaDon()
                    join y in BUSINESS.HoaDonBUS.LoadHoaDonChiTiet() on x.Invoice_Id equals y.Invoice_Id
                    join z in BUSINESS.SanPhamBUS.TatcaSP() on y.Product_Id equals z.Product_Id
                    where x.Invoice_Id == mahd
                    select new
                    {
                        Product_Name = z.Product_Name,
                        Quantily = y.Quantily,
                        Unit_Price = string.Format("{0:0,0} ₫", Convert.ToDouble(z.Price)),
                        TuTol_Money = y.Tutol_Money
                    };
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = r.ToList();

            var layThongTin = from x in BUSINESS.HoaDonBUS.LoadHoaDon()
                              join y in BUSINESS.HoaDonBUS.LoadHoaDonChiTiet() on x.Invoice_Id equals y.Invoice_Id
                              join z in BUSINESS.SanPhamBUS.TatcaSP() on y.Product_Id equals z.Product_Id
                              where x.Invoice_Id == mahd
                              select new
                              {
                                  Customer_Name = x.Customer_Name,
                                  Date_Of_Invoice = x.Date_Of_Invoice,
                                  Phone_Number = x.Customer_Phone_Number,
                                  Status = x.Status,
                                  Payment = x.Payments
                              };
            lbmaHD.Text = mahd;
            lbTrangThai.Text = Convert.ToString(layThongTin.Select(c => c.Status).FirstOrDefault());
            lbSDT.Text = Convert.ToString(layThongTin.Select(c => c.Phone_Number).FirstOrDefault());
            lbTenKH.Text = Convert.ToString(layThongTin.Select(c => c.Customer_Name).FirstOrDefault());
            lbLoaiThanhToan.Text = Convert.ToString(layThongTin.Select(c => c.Payment).FirstOrDefault());
            labelNgãyuatHoaDon.Text = Convert.ToString(layThongTin.Select(c => c.Date_Of_Invoice).FirstOrDefault());
            lbThanhTien.Text = (string.Format("{0:0,0} ₫", Convert.ToDouble(r.Sum(c => c.TuTol_Money))));
            In(this.panel1);
        }
        private void In(Panel pnl)
        {
            PrinterSettings ps = new PrinterSettings();
            panel1 = pnl;
            getprintarea(pnl);
            printPreviewDialog1.Document = printDocument1;
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printPreviewDialog1.ShowDialog();
        }
        
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(memoryimng, (pagearea.Width / 2) - (this.panel1.Width / 2), this.panel1.Location.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            In(this.panel1);
        }
        private void getprintarea(Panel pnl)
        {
            memoryimng = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(memoryimng, new Rectangle(0, 0, pnl.Width, pnl.Height));
        }
    }
}
