using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data_Transfer_Object;
using LiveCharts;
using LiveCharts.Wpf;

namespace WindowsFormsApp4
{
    public partial class Statical : Form
    {
        public Statical()
        {
            InitializeComponent();
        }

        private void Statical_Load(object sender, EventArgs e)
        {
            LoadDoanhThu();
            LoadTenSSP();
            LoadTenNV();
        }
        private void LoadDoanhThu()
        {
            List<BanHangDTO2> dsUser = BUSINESS.Statical_BUS.LayDoanhThuTungThang();
            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = dsUser;
            #region Load chart column
            try
            {
                var l = dsUser.ToList();
                List<string> lstDate = new List<string>();
                for (int i = 0; i < l.Count; i++)
                {
                    lstDate.Add(l[i].Date.Value.ToString("dd/MM/yyyy"));
                }
                cartesianChart1.AxisX.Add(new LiveCharts.Wpf.Axis
                {
                    Title = "DATE",
                    Labels = lstDate
                });

                cartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis
                {
                    Title = "REVENUE",
                    LabelFormatter = value => value.ToString("C")
                });
                cartesianChart1.LegendLocation = LiveCharts.LegendLocation.Right;
                cartesianChart1.Series.Clear();
                SeriesCollection series = new SeriesCollection();
                
                List<double> values = new List<double>();
                for (int i = 0; i < l.Count; i++)
                {
                    values.Add(Convert.ToDouble(l[i].Tutol_Revenue));
                }
                series.Add(new LineSeries() { Title = "Revenue", Values = new ChartValues<double>(values) });
                cartesianChart1.Series = series;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion

        }
        private void LoadTenSSP()
        {
            List<SanPhamDTO2> dsUser = BUSINESS.Statical_BUS.LayThongTinSanPham();
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = dsUser;

            #region Load chart column
            try
            {
                chart2.Series.Clear();
                chart2.Titles.Clear();
                chart2.Titles.Add("TỔNG SỐ LƯỢNG SẢN PHẨM BÁN ĐƯỢC THEO THÁNG");
                chart2.Series.Add("Tổng số lượng");
                chart2.ChartAreas["ChartArea1"].AxisX.Title = "TÊN SẢN PHẨM";
                chart2.ChartAreas["ChartArea1"].AxisY.Title = "TỔNG SỐ LƯỢNG";
                chart2.Series["Tổng số lượng"]["DrawingStyle"] = "Cylinder";
                chart2.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                chart2.Series["Tổng số lượng"].IsValueShownAsLabel = true;
                chart2.Series["Tổng số lượng"].Points.Clear();
                var l = dsUser.ToList();
                for (int i = 0; i < l.Count; i++)
                {
                    chart2.Series["Tổng số lượng"].Points.AddXY(l[i].Product_Name, l[i].Tutol_Quantity);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion
        }
        private void LoadTenNV()
        {
            List<NhanVien_DTO2> dsUser = BUSINESS.Statical_BUS.LayThongTinNV();
            dataGridView3.EnableHeadersVisualStyles = false;
            dataGridView3.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            dataGridView3.Columns.Clear();
            dataGridView3.DataSource = dsUser;
            #region Load chart column
            try
            {
                chart3.Series.Clear();
                chart3.Titles.Clear();
                chart3.Titles.Add("TỔNG SỐ LƯỢNG SẢN PHẨM BÁN ĐƯỢC CỦA TỪNG NHÂN VIÊN THEO THÁNG");
                chart3.Series.Add("Tổng số lượng");
                chart3.ChartAreas["ChartArea1"].AxisX.Title = "TÊN NHÂN VIÊN";
                chart3.ChartAreas["ChartArea1"].AxisY.Title = "SỐ SẢN PHẨM BÁN ĐƯỢC";
                chart3.Series["Tổng số lượng"]["DrawingStyle"] = "Cylinder";
                chart3.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                chart3.Series["Tổng số lượng"].IsValueShownAsLabel = true;
                chart3.Series["Tổng số lượng"].Points.Clear();
                var l = dsUser.ToList();
                for (int i = 0; i < l.Count; i++)
                {
                    chart3.Series["Tổng số lượng"].Points.AddXY(l[i].Employee_Name, l[i].Total_Product_Quantity);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion
        }

    }
}
