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
    public partial class HoaDonChoService : Form
    {
        public string manv;
        public HoaDonChoService()
        {
            InitializeComponent();
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
        private void HoaDonChoService_Load(object sender, EventArgs e)
        {

        }

        private void btnThemm_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtTenKH.Text))
                {
                    var result = from x in BUSINESS.HoaDonBUS.LoadHoaDonCho() where x.Customer_Name == txtTenKH.Text select x;
                    string mahd = DateTime.Now.ToString("yyMMdd") + CreateMaHD(9);
                    if (result.FirstOrDefault() != null)
                    {
                        for (int i = 0; i <= result.ToList().Count; i++)
                        {
                            var result2 = from x in BUSINESS.HoaDonBUS.LoadHoaDonCho() where x.Customer_Name == txtTenKH.Text + " (" + (result.Count()) + ")" || x.Customer_Name == txtTenKH.Text + " (" + (result.Count()) + (i++) +")" select x;
                            if (result2.FirstOrDefault() != null)
                            {
                                BUSINESS.HoaDonBUS.ThemHoaDonCho(mahd, manv.Trim(), txtTenKH.Text + " (" + (result.Count() + (i + 1)) + ")", DateTime.Now);
                                this.Close();
                            }
                            else
                            {
                                BUSINESS.HoaDonBUS.ThemHoaDonCho(mahd, manv.Trim(), txtTenKH.Text + " (" + (result.Count() + i) + ")", DateTime.Now);
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        BUSINESS.HoaDonBUS.ThemHoaDonCho(mahd, manv.Trim(), txtTenKH.Text, DateTime.Now);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Star Glocery");
            }
        }
    }
}
