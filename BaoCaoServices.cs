using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using Data_Transfer_Object;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Net.Mail;
using System.Net;

namespace WindowsFormsApp4
{
    public partial class BaoCaoServices : Form
    {
        Attachment attach = null;
        private string tentk,mkhau;
        public BaoCaoServices()
        {
            InitializeComponent();
        }
        public BaoCaoServices(string ten,string mk)
        {
            InitializeComponent();
            this.tentk = ten;
            this.mkhau = mk;
        }
        private void ExportExCel(string path)
        {
            Excel.Application application = new Excel.Application();
            application.Application.Workbooks.Add(Type.Missing);
            for (int i = 0; i < dtgHoaDon.Columns.Count; i++)
            {
                application.Cells[1, i + 1] = dtgHoaDon.Columns[i].HeaderText;
            }
            for (int i = 0; i < dtgHoaDon.Rows.Count; i++)
            {
                for (int j = 0; j < dtgHoaDon.Columns.Count; j++)
                {
                    application.Cells[i + 2, j + 1] = dtgHoaDon.Rows[i].Cells[j].Value;
                }
            }
            application.Columns.AutoFit();
            application.ActiveWorkbook.SaveCopyAs(path);
            application.ActiveWorkbook.Saved = true;
        }
        void GuiMaill(string from, string to, string subject, string message, Attachment file = null)
        {
            try
            {
                MailMessage mess = new MailMessage(from, to, subject, message);
                if (attach != null)
                {
                    mess.Attachments.Add(attach);
                }
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
        private void btnGuiDi_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Export Excel";
            saveFileDialog.Filter = "Excel (*.xlsx)|*.xlsx|Excel 2003 (*.xls)|*.xls";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                attach = null;
                try
                {
                    ExportExCel(saveFileDialog.FileName);
                    if (MessageBox.Show("Xuất Thành công bạn có muốn gửi báo cáo luôn không?","Thông báo!",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        FileInfo file = new FileInfo(saveFileDialog.FileName);
                        attach = new Attachment(saveFileDialog.FileName);
                        GuiMaill("vuducnham1123@gmail.com", "nhamvdph18699@fpt.edu.vn", "Sales information report today: ", DateTime.Now.Date.ToString(), attach);
                        MessageBox.Show("Gửi báo cáo thành công");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xuất Thất bại \n" + ex.Message);
                }
            }
        }

        private void BaoCaoServices_Load(object sender, EventArgs e)
        {
            dtgHoaDon.EnableHeadersVisualStyles = false;
            dtgHoaDon.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkTurquoise;
            DB__4Entities du = new DB__4Entities();
            var maNS = from x in du.NhanViens
                       where x.TenTaiKhoan == tentk && x.MatKhau == mkhau
                       select new
                       {
                           x.MaNV
                       };
            string manv = maNS.FirstOrDefault().ToString().Trim().Split('=')[1].Replace("}", "");
            var lstHoaDonCT = from x in BUSINESS.HoaDonBUS.LoadHoaDonChiTiet()
                              join y in BUSINESS.HoaDonBUS.LoadHoaDon() on x.Invoice_Id equals y.Invoice_Id
                              where y.Employee_Id == manv.Trim() && y.Date_Of_Invoice.Value.Date == DateTime.Now.Date
                              select new
                              {
                                  Invoice_Id = x.Invoice_Id,
                                  Employeee_Id = y.Employee_Id,
                                  Cus_Name = y.Customer_Name,
                                  Cus_PhoneNumber = y.Customer_Phone_Number,
                                  Date_Of_Invoice = y.Date_Of_Invoice.Value.Date,
                                  Product_Id = x.Product_Id,
                                  Quantity = x.Quantily,
                                  Tutol_Money = Convert.ToString(string.Format("{0:0,0} VNĐ", x.Tutol_Money)),
                                  Payment = y.Payments
                              };
            dtgHoaDon.DataSource = lstHoaDonCT.ToList();
        }
    }
}
