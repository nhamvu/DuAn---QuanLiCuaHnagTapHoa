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
using ExcelDataReader;

namespace WindowsFormsApp4
{
    public partial class Import_Product : Form
    {
        DataTableCollection tableCollection;
        public Import_Product()
        {
            InitializeComponent();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (dtgHoaDon.RowCount != 0)
            {
                if (MessageBox.Show("Bạn chắc chắn muốn thêm tất cả?", "N Shop Flower",
                           MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        for (int i = 0; i < dtgHoaDon.RowCount; i++)
                        {
                            string masp = dtgHoaDon.Rows[i].Cells[0].Value.ToString();
                            string tensp = dtgHoaDon.Rows[i].Cells[1].Value.ToString();
                            string tenloaisp = dtgHoaDon.Rows[i].Cells[2].Value.ToString();
                            string nguongoc = dtgHoaDon.Rows[i].Cells[3].Value.ToString();
                            string ngaynhap = dtgHoaDon.Rows[i].Cells[4].Value.ToString();
                            string soluongnhap = dtgHoaDon.Rows[i].Cells[5].Value.ToString();
                            string soluongconlai = dtgHoaDon.Rows[i].Cells[6].Value.ToString();
                            string ngaysx = dtgHoaDon.Rows[i].Cells[7].Value.ToString();
                            string hansd = dtgHoaDon.Rows[i].Cells[8].Value.ToString();
                            string mota = dtgHoaDon.Rows[i].Cells[9].Value.ToString();
                            string gianhap = dtgHoaDon.Rows[i].Cells[10].Value.ToString();
                            string giaban = dtgHoaDon.Rows[i].Cells[11].Value.ToString();
                            string magach = dtgHoaDon.Rows[i].Cells[12].Value.ToString();
                            if (masp == "" || masp.Length > 10 || !Regex.IsMatch(tensp, @"^[\w\s]+$") || tensp.Length > 50
                                || tenloaisp != "Nước giải khát" && tenloaisp != "Đồ ăn nhanh" && tenloaisp != "Thực phẩm" && tenloaisp != "Đồ dùng thiết yếu" && tenloaisp != "Khác"
                                || !Regex.Match(nguongoc, @"^[\w:,\s]+$").Success || nguongoc.Length > 100
                                || Convert.ToDateTime(ngaynhap).Date > DateTime.Now.Date
                                || Convert.ToInt32(soluongnhap) < 0 || Convert.ToInt32(soluongnhap) > 5000
                                || Convert.ToInt32(soluongconlai) < 0 || Convert.ToInt32(soluongconlai) > 5000
                                || Convert.ToDateTime(ngaysx).Date >= DateTime.Now.Date
                                || Convert.ToDateTime(hansd).Date < DateTime.Now.Date
                                || Convert.ToDouble(gianhap) < 0 || Convert.ToDouble(giaban) < 0)
                            {
                                MessageBox.Show("các kí tự không hợp lệ");
                            }
                            else
                            {
                                BUSINESS.SanPhamBUS.ThemSanPhamTuExcel(masp, tensp, nguongoc, Convert.ToDateTime(ngaynhap),
                                                        Convert.ToSingle(gianhap), Convert.ToInt32(soluongnhap), Convert.ToInt32(soluongconlai),
                                                        Convert.ToSingle(giaban), Convert.ToDateTime(ngaysx), Convert.ToDateTime(hansd),
                                                        tenloaisp, mota, magach);
                            }
                        }
                        dtgHoaDon.Columns.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Thêm không thành công");
                    }
                }
            }
            else
            {
                MessageBox.Show("Giỏ hàng hiện đang trống");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[comboBox1.SelectedItem.ToString()];
            dtgHoaDon.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Import Excel";
            op.Filter = "Excel (*.xlsx)|*.xlsx|Excel 2003 (*.xls)|*.xls";
            if (op.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    textBox1.Text = op.FileName;
                    using (var stream = File.Open(op.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                                {
                                    UseHeaderRow = true
                                }
                            });
                            tableCollection = result.Tables;
                            comboBox1.Items.Clear();
                            foreach (DataTable item in tableCollection)
                            {
                                comboBox1.Items.Add(item.TableName);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Import Thất bại" + ex.Message);
                }
            }
        }
    }
}
