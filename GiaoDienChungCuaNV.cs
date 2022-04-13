using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class GiaoDienChungCuaNV : Form
    {
        public string tentk, tendn;
        public GiaoDienChungCuaNV()
        {
            InitializeComponent();
        }

        private void GiaoDienChungCuaNV_Load(object sender, EventArgs e)
        {
            dataGridView3.EnableHeadersVisualStyles = false;
            dataGridView3.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            grbChart.Width = 1570;
            grbChiTiet.Width = 0;
            grbChiTiet.Text = "";
            grbChiTiet.Location = new Point(1586, 112);
            grbChiTiet.Width = 35;
            dataGridView3.Width = 0;
            btnXemChiTiet.Image = Properties.Resources.left_arrow;
            if (BUSINESS.General_BUS.TrangThai(tentk) == true)
            {
                designButtonClass1.BackColor = Color.LimeGreen;
                designButtonClass1.Text = "Đã báo danh";
                designButtonClass1.Enabled = false;
            }
            else
            {
                designButtonClass1.BackColor = Color.Red;
                designButtonClass1.Text = "Chưa báo danh";
            }
            LoadTenNV();
            LoadKPI();
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (grbChiTiet.Width == 649)
            {
                grbChart.Width = 1570;
                grbChiTiet.Width = 0;
                grbChiTiet.Text = "";
                grbChiTiet.Location = new Point(1586, 112);
                grbChiTiet.Width = 35;
                dataGridView3.Width = 0;
                btnXemChiTiet.Image = Properties.Resources.left_arrow;
            }
            else if (grbChiTiet.Width == 35)
            {
                grbChart.Width = 961;
                grbChiTiet.Width = 649;
                grbChiTiet.Text = "DETAILS RESULTS";
                grbChiTiet.Location = new Point(971, 112);
                dataGridView3.Width = 608;
                btnXemChiTiet.Image = Properties.Resources.right_arrow;
            }
        }

        private void designButtonClass1_Click(object sender, EventArgs e)
        {
            BaoDanhBangKhuonMat b = new BaoDanhBangKhuonMat();
            b.ShowDialog();
        }

        private void LoadTenNV()
        {
            var results = from invoice in BUSINESS.HoaDonBUS.LoadHoaDon()
                          join employee in BUSINESS.NhanVienBUS.GetDSUSer() on invoice.Employee_Id equals employee.Employee_Id
                          join invoice_Details in BUSINESS.HoaDonBUS.LoadHoaDonChiTiet() on invoice.Invoice_Id equals invoice_Details.Invoice_Id
                          where employee.Employee_Name.Trim() == tendn.Trim() && invoice.Date_Of_Invoice.Value.Month == DateTime.Now.Month
                          orderby invoice.Date_Of_Invoice descending
                          group invoice_Details by new
                          {
                              invoice.Employee_Id,
                              employee.Employee_Name,
                              invoice.Date_Of_Invoice.Value.Date,
                          }
                          into g
                          select new
                          {
                              Employee_Name = g.Key.Employee_Name,
                              Number_of_transactions = g.Count(),
                              Total_Quantity = Convert.ToInt32(g.Sum(c => c.Quantily)),
                              Date = g.Key.Date
                          };
            dataGridView3.DataSource = results.ToList();
            #region Load chart column
            try
            {
                chart1.Series.Clear();
                chart1.Titles.Clear();
                chart1.Titles.Add("TỔNG SỐ LƯỢNG SẢN PHẨM BÁN ĐƯỢC CỦA BẠN TRONG THÁNG NÀY");
                chart1.Series.Add("Tổng số lượng");
                chart1.ChartAreas["ChartArea1"].AxisX.Title = "Date";
                chart1.ChartAreas["ChartArea1"].AxisY.Title = "Number_of_transactions";
                chart1.Series["Tổng số lượng"]["DrawingStyle"] = "Cylinder";
                chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                chart1.Series["Tổng số lượng"].IsValueShownAsLabel = true;
                chart1.Series["Tổng số lượng"].Points.Clear();
                var l = results.ToList();
                for (int i = 0; i < l.Count; i++)
                {
                    chart1.Series["Tổng số lượng"].Points.AddXY(l[i].Date, l[i].Total_Quantity);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion
        }
        private void LoadKPI()
        {
            var results = from invoice in BUSINESS.HoaDonBUS.LoadHoaDon()
                          join employee in BUSINESS.NhanVienBUS.GetDSUSer() on invoice.Employee_Id equals employee.Employee_Id
                          join invoice_Details in BUSINESS.HoaDonBUS.LoadHoaDonChiTiet() on invoice.Invoice_Id equals invoice_Details.Invoice_Id
                          where employee.Employee_Name.ToLower().Trim().Contains(tendn.Trim().ToLower()) && invoice.Date_Of_Invoice.Value.Month == DateTime.Now.Month
                          group invoice_Details by new
                          {
                              invoice.Employee_Id,
                              employee.Employee_Name,
                              invoice.Date_Of_Invoice.Value.Date,
                          }
                          into g
                          select new
                          {
                              Employee_Name = g.Key.Employee_Name,
                              Number_of_transactions = g.Count(),
                              Total_Quantity = Convert.ToInt32(g.Sum(c => c.Quantily)),
                          };
            lbSoLuong.Text = Convert.ToString(results.Select(c => c.Total_Quantity).FirstOrDefault());
            lbTongHoaDon.Text = Convert.ToString(results.Select(c => c.Number_of_transactions).FirstOrDefault());
            if (results.Select(c => c.Total_Quantity).FirstOrDefault() < Convert.ToInt32(lbTongSoLanBan.Text))
            {
                lbTongHoaDon.ForeColor = Color.Red;
            }
            else
            {
                lbTongHoaDon.ForeColor = Color.LightGreen;
            }
        }
    }
}
