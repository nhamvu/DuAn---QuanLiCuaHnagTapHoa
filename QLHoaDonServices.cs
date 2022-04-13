using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data_Transfer_Object;

namespace WindowsFormsApp4
{
    public partial class QLHoaDonServices : Form
    {
        public QLHoaDonServices()
        {
            InitializeComponent();
        }
        private void LoadDataHoaDonChiTiet()
        {
            List<HoaDonChiTietDTO> dsUser = BUSINESS.HoaDonBUS.LoadHoaDonChiTiet();
            dtgHoaDonCT.DataSource = dsUser;
        }
        private void LoadHoaDon()
        {
            var dsUser = from x in BUSINESS.HoaDonBUS.LoadHoaDon() select x;
            dtgHoaDon.DataSource = dsUser.ToList();
        }
        private void LoadHoaDonChuaTra()
        {
            var dsUser = from x in BUSINESS.HoaDonBUS.LoadHoaDon() where x.Status == "Unpaid" select x;
            dtgHoaDonChuaTra.DataSource = dsUser.ToList();
        }
        private void LoadHoaDonChiTietChuaTra()
        {
            var dsUser = from x in BUSINESS.HoaDonBUS.LoadHoaDonChiTiet()
                         join y in BUSINESS.HoaDonBUS.LoadHoaDon() on x.Invoice_Id equals y.Invoice_Id
                         where y.Status == "Unpaid"
                         select x;
            dtgHoaDonCTChuaTra.DataSource = dsUser.ToList();
        }
        private void QLHoaDonServices_Load(object sender, EventArgs e)
        {
            LoadDataHoaDonChiTiet();
            LoadHoaDon();
            LoadHoaDonChuaTra();
            LoadHoaDonChiTietChuaTra();
            cbThang.SelectedIndex = 0;
            cbNgay.SelectedIndex = 0;
            cbNam.SelectedIndex = 0;
            cbLocTheoHinhThucThanhToan.SelectedIndex = 0;
            cbThangHoaDonChuaTra.SelectedIndex = 0;
            cbNgayHoaDonChuaTra.SelectedIndex = 0;
            cbNamHoaDonChuaTra.SelectedIndex = 0;
            cbLocLoaiThanhToanHoaDonChuaTra.SelectedIndex = 0;
            dtgHoaDon.EnableHeadersVisualStyles = false;
            dtgHoaDon.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkTurquoise;
            dtgHoaDonChuaTra.EnableHeadersVisualStyles = false;
            dtgHoaDonChuaTra.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkTurquoise;
            dtgHoaDonCT.EnableHeadersVisualStyles = false;
            dtgHoaDonCT.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkTurquoise;
            dtgHoaDonCTChuaTra.EnableHeadersVisualStyles = false;
            dtgHoaDonCTChuaTra.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkTurquoise;
        }


        private void TimHoaDon()
        {
            if (cbNgay.Text != "DD" && cbThang.Text != "MM" && cbNam.Text != "YYYY")
            {
                var lstInvoice = from x in BUSINESS.HoaDonBUS.LoadHoaDon()
                                 where x.Date_Of_Invoice.Value.ToString("dd") == cbNgay.Text
                                 && x.Date_Of_Invoice.Value.Month == Convert.ToInt32(cbThang.Text)
                                 && x.Date_Of_Invoice.Value.Year == Convert.ToInt32(cbNam.Text)
                                 select x;

                var lst_Invoice_Details = from x in BUSINESS.HoaDonBUS.LoadHoaDon()
                                          join y in BUSINESS.HoaDonBUS.LoadHoaDonChiTiet() on x.Invoice_Id equals y.Invoice_Id
                                          where x.Date_Of_Invoice.Value.ToString("dd") == cbNgay.Text
                                          && x.Date_Of_Invoice.Value.Month == Convert.ToInt32(cbThang.Text)
                                          && x.Date_Of_Invoice.Value.Year == Convert.ToInt32(cbNam.Text)
                                          select x;
                dtgHoaDon.DataSource = lstInvoice.ToList();
                dtgHoaDonCT.DataSource = lst_Invoice_Details.ToList();
            }
            else if (cbNgay.Text != "DD" && cbThang.Text != "MM" && cbNam.Text == "YYYY")
            {
                var dsUser = from x in BUSINESS.HoaDonBUS.LoadHoaDon()
                             where x.Date_Of_Invoice.Value.ToString("dd") == cbNgay.Text
                             && x.Date_Of_Invoice.Value.Month == Convert.ToInt32(cbThang.Text)
                             select x;

                var lst_Invoice_Details = from x in BUSINESS.HoaDonBUS.LoadHoaDon()
                                          join y in BUSINESS.HoaDonBUS.LoadHoaDonChiTiet() on x.Invoice_Id equals y.Invoice_Id
                                          where x.Date_Of_Invoice.Value.ToString("dd") == cbNgay.Text
                                          && x.Date_Of_Invoice.Value.Month == Convert.ToInt32(cbThang.Text)
                                          select x;
                dtgHoaDon.DataSource = dsUser.ToList();
                dtgHoaDonCT.DataSource = lst_Invoice_Details.ToList();
            }
            else if (cbNgay.Text != "DD" && cbThang.Text == "MM" && cbNam.Text == "YYYY")
            {
                var dsUser = from x in BUSINESS.HoaDonBUS.LoadHoaDon()
                             where x.Date_Of_Invoice.Value.ToString("dd") == cbNgay.Text
                             select x;

                var lst_Invoice_Details = from x in BUSINESS.HoaDonBUS.LoadHoaDon()
                                          join y in BUSINESS.HoaDonBUS.LoadHoaDonChiTiet() on x.Invoice_Id equals y.Invoice_Id
                                          where x.Date_Of_Invoice.Value.ToString("dd") == cbNgay.Text
                                          select x;

                dtgHoaDon.DataSource = dsUser.ToList();
                dtgHoaDonCT.DataSource = lst_Invoice_Details.ToList();
            }
            else if (cbNgay.Text == "DD" && cbThang.Text != "MM" && cbNam.Text != "YYYY")
            {
                var dsUser = from x in BUSINESS.HoaDonBUS.LoadHoaDon()
                             where x.Date_Of_Invoice.Value.Year == Convert.ToInt32(cbThang.Text)
                             && x.Date_Of_Invoice.Value.Month == Convert.ToInt32(cbNam.Text)
                             select x;

                var lst_Invoice_Details = from x in BUSINESS.HoaDonBUS.LoadHoaDon()
                                          join y in BUSINESS.HoaDonBUS.LoadHoaDonChiTiet() on x.Invoice_Id equals y.Invoice_Id
                                          where x.Date_Of_Invoice.Value.Year == Convert.ToInt32(cbNam.Text)
                                          && x.Date_Of_Invoice.Value.Month == Convert.ToInt32(cbThang.Text)
                                          select x;

                dtgHoaDon.DataSource = dsUser.ToList();
                dtgHoaDonCT.DataSource = lst_Invoice_Details.ToList();
            }
            else if (cbNgay.Text == "DD" && cbThang.Text != "MM" && cbNam.Text == "YYYY")
            {
                var dsUser = from x in BUSINESS.HoaDonBUS.LoadHoaDon()
                             where x.Date_Of_Invoice.Value.Month == Convert.ToInt32(cbThang.Text)
                             select x;

                var lst_Invoice_Details = from x in BUSINESS.HoaDonBUS.LoadHoaDon()
                                          join y in BUSINESS.HoaDonBUS.LoadHoaDonChiTiet() on x.Invoice_Id equals y.Invoice_Id
                                          where x.Date_Of_Invoice.Value.Month == Convert.ToInt32(cbThang.Text)
                                          select x;

                dtgHoaDon.DataSource = dsUser.ToList();
                dtgHoaDonCT.DataSource = lst_Invoice_Details.ToList();
            }
            else if (cbNgay.Text == "DD" && cbThang.Text == "MM" && cbNam.Text != "YYYY")
            {
                var dsUser = from x in BUSINESS.HoaDonBUS.LoadHoaDon()
                             where x.Date_Of_Invoice.Value.Year == Convert.ToInt32(cbNam.Text)
                             select x;
                var lst_Invoice_Details = from x in BUSINESS.HoaDonBUS.LoadHoaDon()
                                          join y in BUSINESS.HoaDonBUS.LoadHoaDonChiTiet() on x.Invoice_Id equals y.Invoice_Id
                                          where x.Date_Of_Invoice.Value.Year == Convert.ToInt32(cbNam.Text)
                                          select x;

                dtgHoaDon.DataSource = dsUser.ToList();
                dtgHoaDonCT.DataSource = lst_Invoice_Details.ToList();
            }
            else
            {
                LoadHoaDon();
                LoadDataHoaDonChiTiet();
            }
        }
        private void TimHoaDonChuaTra()
        {
            if (cbNgayHoaDonChuaTra.Text != "DD" && cbThangHoaDonChuaTra.Text != "MM" && cbNamHoaDonChuaTra.Text != "YYYY")
            {
                var lstInvoice = from x in BUSINESS.HoaDonBUS.LoadHoaDon()
                                 where x.Date_Of_Invoice.Value.ToString("dd") == cbNgayHoaDonChuaTra.Text
                                 && x.Date_Of_Invoice.Value.Month == Convert.ToInt32(cbThangHoaDonChuaTra.Text)
                                 && x.Date_Of_Invoice.Value.Year == Convert.ToInt32(cbNamHoaDonChuaTra.Text) && x.Status == "Unpaid"
                                 select x;

                var lst_Invoice_Details = from x in BUSINESS.HoaDonBUS.LoadHoaDon()
                                          join y in BUSINESS.HoaDonBUS.LoadHoaDonChiTiet() on x.Invoice_Id equals y.Invoice_Id
                                          where x.Date_Of_Invoice.Value.ToString("dd") == cbNgayHoaDonChuaTra.Text
                                          && x.Date_Of_Invoice.Value.Month == Convert.ToInt32(cbThangHoaDonChuaTra.Text)
                                          && x.Date_Of_Invoice.Value.Year == Convert.ToInt32(cbNamHoaDonChuaTra.Text) && x.Status == "Unpaid"
                                          select x;
                dtgHoaDonChuaTra.DataSource = lstInvoice.ToList();
                dtgHoaDonCTChuaTra.DataSource = lst_Invoice_Details.ToList();
            }
            else if (cbNgayHoaDonChuaTra.Text != "DD" && cbThangHoaDonChuaTra.Text != "MM" && cbNamHoaDonChuaTra.Text == "YYYY")
            {
                var dsUser = from x in BUSINESS.HoaDonBUS.LoadHoaDon()
                             where x.Date_Of_Invoice.Value.ToString("dd") == cbNgayHoaDonChuaTra.Text
                             && x.Date_Of_Invoice.Value.Month == Convert.ToInt32(cbThangHoaDonChuaTra.Text) && x.Status == "Unpaid"
                             select x;

                var lst_Invoice_Details = from x in BUSINESS.HoaDonBUS.LoadHoaDon()
                                          join y in BUSINESS.HoaDonBUS.LoadHoaDonChiTiet() on x.Invoice_Id equals y.Invoice_Id
                                          where x.Date_Of_Invoice.Value.ToString("dd") == cbNgayHoaDonChuaTra.Text
                                          && x.Date_Of_Invoice.Value.Month == Convert.ToInt32(cbThangHoaDonChuaTra.Text) && x.Status == "Unpaid"
                                          select x;
                dtgHoaDonChuaTra.DataSource = dsUser.ToList();
                dtgHoaDonCTChuaTra.DataSource = lst_Invoice_Details.ToList();
            }
            else if (cbNgayHoaDonChuaTra.Text != "DD" && cbThangHoaDonChuaTra.Text == "MM" && cbNamHoaDonChuaTra.Text == "YYYY")
            {
                var dsUser = from x in BUSINESS.HoaDonBUS.LoadHoaDon()
                             where x.Date_Of_Invoice.Value.ToString("dd") == cbNgayHoaDonChuaTra.Text && x.Status == "Unpaid"
                             select x;

                var lst_Invoice_Details = from x in BUSINESS.HoaDonBUS.LoadHoaDon()
                                          join y in BUSINESS.HoaDonBUS.LoadHoaDonChiTiet() on x.Invoice_Id equals y.Invoice_Id
                                          where x.Date_Of_Invoice.Value.ToString("dd") == cbNgayHoaDonChuaTra.Text && x.Status == "Unpaid"
                                          select x;

                dtgHoaDonChuaTra.DataSource = dsUser.ToList();
                dtgHoaDonCTChuaTra.DataSource = lst_Invoice_Details.ToList();
            }
            else if (cbNgayHoaDonChuaTra.Text == "DD" && cbThangHoaDonChuaTra.Text != "MM" && cbNamHoaDonChuaTra.Text != "YYYY")
            {
                var dsUser = from x in BUSINESS.HoaDonBUS.LoadHoaDon()
                             where x.Date_Of_Invoice.Value.Year == Convert.ToInt32(cbNamHoaDonChuaTra.Text)
                             && x.Date_Of_Invoice.Value.Month == Convert.ToInt32(cbThangHoaDonChuaTra.Text) && x.Status == "Unpaid"
                             select x;

                var lst_Invoice_Details = from x in BUSINESS.HoaDonBUS.LoadHoaDon()
                                          join y in BUSINESS.HoaDonBUS.LoadHoaDonChiTiet() on x.Invoice_Id equals y.Invoice_Id
                                          where x.Date_Of_Invoice.Value.Year == Convert.ToInt32(cbNamHoaDonChuaTra.Text)
                                          && x.Date_Of_Invoice.Value.Month == Convert.ToInt32(cbThangHoaDonChuaTra.Text) && x.Status == "Unpaid"
                                          select x;

                dtgHoaDonChuaTra.DataSource = dsUser.ToList();
                dtgHoaDonCTChuaTra.DataSource = lst_Invoice_Details.ToList();
            }
            else if (cbNgayHoaDonChuaTra.Text == "DD" && cbThangHoaDonChuaTra.Text != "MM" && cbNamHoaDonChuaTra.Text == "YYYY")
            {
                var dsUser = from x in BUSINESS.HoaDonBUS.LoadHoaDon()
                             where x.Date_Of_Invoice.Value.Month == Convert.ToInt32(cbThangHoaDonChuaTra.Text) && x.Status == "Unpaid"
                             select x;

                var lst_Invoice_Details = from x in BUSINESS.HoaDonBUS.LoadHoaDon()
                                          join y in BUSINESS.HoaDonBUS.LoadHoaDonChiTiet() on x.Invoice_Id equals y.Invoice_Id
                                          where x.Date_Of_Invoice.Value.Month == Convert.ToInt32(cbThangHoaDonChuaTra.Text) && x.Status == "Unpaid"
                                          select x;

                dtgHoaDonChuaTra.DataSource = dsUser.ToList();
                dtgHoaDonCTChuaTra.DataSource = lst_Invoice_Details.ToList();
            }
            else if (cbNgayHoaDonChuaTra.Text == "DD" && cbThangHoaDonChuaTra.Text == "MM" && cbNamHoaDonChuaTra.Text != "YYYY")
            {
                var dsUser = from x in BUSINESS.HoaDonBUS.LoadHoaDon()
                             where x.Date_Of_Invoice.Value.Year == Convert.ToInt32(cbNamHoaDonChuaTra.Text) && x.Status == "Unpaid"
                             select x;
                var lst_Invoice_Details = from x in BUSINESS.HoaDonBUS.LoadHoaDon()
                                          join y in BUSINESS.HoaDonBUS.LoadHoaDonChiTiet() on x.Invoice_Id equals y.Invoice_Id
                                          where x.Date_Of_Invoice.Value.Year == Convert.ToInt32(cbNamHoaDonChuaTra.Text) && x.Status == "Unpaid"
                                          select x;

                dtgHoaDonChuaTra.DataSource = dsUser.ToList();
                dtgHoaDonCTChuaTra.DataSource = lst_Invoice_Details.ToList();
            }
            else
            {
                LoadHoaDonChuaTra();
                LoadHoaDonChiTietChuaTra();
            }
        }

        private void dtgHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = e.RowIndex;
            DataGridViewRow select = dtgHoaDon.Rows[id];
            string find = select.Cells[0].Value.ToString();
            var lst_Invoice_Details = from x in BUSINESS.HoaDonBUS.TimHoaDon(find)
                                      join y in BUSINESS.HoaDonBUS.LoadHoaDonChiTiet() on x.Invoice_Id equals y.Invoice_Id
                                      select x;
            dtgHoaDonCT.DataSource = lst_Invoice_Details.ToList();
        }

        private void dtgHoaDonChuaTra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = e.RowIndex;
            DataGridViewRow select = dtgHoaDonChuaTra.Rows[id];
            string find = select.Cells[0].Value.ToString();
            var lst_Invoice_Details = from x in BUSINESS.HoaDonBUS.TimHoaDon(find)
                                      join y in BUSINESS.HoaDonBUS.LoadHoaDonChiTiet() on x.Invoice_Id equals y.Invoice_Id
                                      where x.Status == "Unpaid"
                                      select x;
            dtgHoaDonCTChuaTra.DataSource = lst_Invoice_Details.ToList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                List<HoaDonDTO> dsUser = BUSINESS.HoaDonBUS.TimHoaDon(textBox1.Text);
                var lst_Invoice_Details = from x in BUSINESS.HoaDonBUS.TimHoaDon(textBox1.Text)
                                          join y in BUSINESS.HoaDonBUS.LoadHoaDonChiTiet() on x.Invoice_Id equals y.Invoice_Id
                                          select x;
                dtgHoaDon.DataSource = dsUser;
                dtgHoaDonCT.DataSource = lst_Invoice_Details.ToList();
            }
            else
            {
                LoadHoaDon();
                LoadDataHoaDonChiTiet();
            }
        }
        private void cbLocTheoHinhThucThanhToan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLocTheoHinhThucThanhToan.SelectedIndex == 0)
            {
                var lstHoaDon = from x in BUSINESS.HoaDonBUS.LoadHoaDon()
                             select x;
                var lstHoaDonCt = from x in BUSINESS.HoaDonBUS.LoadHoaDonChiTiet()
                             select x;
                dtgHoaDon.DataSource = lstHoaDon.ToList();
                dtgHoaDonCT.DataSource = lstHoaDonCt.ToList();
            }
            else if (cbLocTheoHinhThucThanhToan.SelectedIndex == 1)
            {
                var lstHoaDon = from x in BUSINESS.HoaDonBUS.LoadHoaDon() where x.Payments == "Transfer"
                                select x;
                var lstHoaDonCt = from x in BUSINESS.HoaDonBUS.LoadHoaDonChiTiet() join y in BUSINESS.HoaDonBUS.LoadHoaDon()
                                  on x.Invoice_Id equals y.Invoice_Id where y.Payments == "Transfer"
                                  select x;
                dtgHoaDon.DataSource = lstHoaDon.ToList();
                dtgHoaDonCT.DataSource = lstHoaDonCt.ToList();
            }
            else if (cbLocTheoHinhThucThanhToan.SelectedIndex == 2)
            {
                var lstHoaDon = from x in BUSINESS.HoaDonBUS.LoadHoaDon()
                                where x.Payments == "Cash"
                                select x;
                var lstHoaDonCt = from x in BUSINESS.HoaDonBUS.LoadHoaDonChiTiet()
                                  join y in BUSINESS.HoaDonBUS.LoadHoaDon() on x.Invoice_Id equals y.Invoice_Id
                                  where y.Payments == "Cash"
                                  select x;
                dtgHoaDon.DataSource = lstHoaDon.ToList();
                dtgHoaDonCT.DataSource = lstHoaDonCt.ToList();
            }
        }

        private void txtTimKiemThongTinKhachHang_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiemThongTinKhachHang.Text != "")
            {
                var dsUser = from x in BUSINESS.HoaDonBUS.LoadHoaDon() where x.Customer_Name.ToLower().Contains(txtTimKiemThongTinKhachHang.Text.ToLower()) select x;
                var lst_Invoice_Details = from x in BUSINESS.HoaDonBUS.LoadHoaDon()
                                          join y in BUSINESS.HoaDonBUS.LoadHoaDonChiTiet() on x.Invoice_Id equals y.Invoice_Id
                                          where x.Customer_Name.ToLower().Contains(txtTimKiemThongTinKhachHang.Text.ToLower())
                                          select x;
                dtgHoaDon.DataSource = dsUser.ToList();
                dtgHoaDonCT.DataSource = lst_Invoice_Details.ToList();
            }
            else
            {
                LoadHoaDon();
                LoadDataHoaDonChiTiet();
            }
        }

        private void cbNgay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNgay.SelectedIndex != 0)
            {
                TimHoaDon();
            }
            else
            {
                LoadHoaDon();
                LoadDataHoaDonChiTiet();
            }
        }

        private void cbThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbThang.SelectedIndex != 0)
            {
                TimHoaDon();
            }
            else
            {
                LoadHoaDon();
                LoadDataHoaDonChiTiet();
            }
        }

        private void cbNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNam.SelectedIndex != 0)
            {
                TimHoaDon();
            }
            else
            {
                LoadHoaDon();
                LoadDataHoaDonChiTiet();
            }
        }

        private void txtTimKiemHoaDonChuaTra_TextChanged_1(object sender, EventArgs e)
        {
            if (txtTimKiemHoaDonChuaTra.Text != "")
            {
                var dsUser = from x in BUSINESS.HoaDonBUS.TimHoaDon(txtTimKiemHoaDonChuaTra.Text) where x.Status == "Unpaid" select x;
                var lst_Invoice_Details = from x in BUSINESS.HoaDonBUS.TimHoaDon(txtTimKiemHoaDonChuaTra.Text)
                                          join y in BUSINESS.HoaDonBUS.LoadHoaDonChiTiet() on x.Invoice_Id equals y.Invoice_Id
                                          where x.Status == "Unpaid"
                                          select x;
                dtgHoaDonChuaTra.DataSource = dsUser.ToList();
                dtgHoaDonCTChuaTra.DataSource = lst_Invoice_Details.ToList();
            }
            else
            {
                LoadHoaDonChuaTra();
                LoadHoaDonChiTietChuaTra();
            }
        }

        private void cbLocLoaiThanhToanHoaDonChuaTra_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLocLoaiThanhToanHoaDonChuaTra.SelectedIndex == 0)
            {
                var lstHoaDon = from x in BUSINESS.HoaDonBUS.LoadHoaDon() where x.Status == "Unpaid"
                                select x;
                var lstHoaDonCt = from x in BUSINESS.HoaDonBUS.LoadHoaDonChiTiet()
                                  join y in BUSINESS.HoaDonBUS.LoadHoaDon() on x.Invoice_Id equals y.Invoice_Id
                                  where y.Status == "Unpaid"
                                  select x;
                dtgHoaDonChuaTra.DataSource = lstHoaDon.ToList();
                dtgHoaDonCTChuaTra.DataSource = lstHoaDonCt.ToList();
            }
            else if (cbLocLoaiThanhToanHoaDonChuaTra.SelectedIndex == 1)
            {
                var lstHoaDon = from x in BUSINESS.HoaDonBUS.LoadHoaDon()
                                where x.Payments == "Transfer" && x.Status == "Unpaid"
                                select x;
                var lstHoaDonCt = from x in BUSINESS.HoaDonBUS.LoadHoaDonChiTiet()
                                  join y in BUSINESS.HoaDonBUS.LoadHoaDon() on x.Invoice_Id equals y.Invoice_Id
                                  where y.Payments == "Transfer" && y.Status == "Unpaid"
                                  select x;
                dtgHoaDonChuaTra.DataSource = lstHoaDon.ToList();
                dtgHoaDonCTChuaTra.DataSource = lstHoaDonCt.ToList();
            }
            else if (cbLocLoaiThanhToanHoaDonChuaTra.SelectedIndex == 2)
            {
                var lstHoaDon = from x in BUSINESS.HoaDonBUS.LoadHoaDon()
                                where x.Payments == "Cash" && x.Status == "Unpaid"
                                select x;
                var lstHoaDonCt = from x in BUSINESS.HoaDonBUS.LoadHoaDonChiTiet()
                                  join y in BUSINESS.HoaDonBUS.LoadHoaDon() on x.Invoice_Id equals y.Invoice_Id
                                  where y.Payments == "Cash" && y.Status == "Unpaid"
                                  select x;
                dtgHoaDonChuaTra.DataSource = lstHoaDon.ToList();
                dtgHoaDonCTChuaTra.DataSource = lstHoaDonCt.ToList();
            }
        }

        private void txtTimKiemHoaTenKHHoaDonChuaTra_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiemHoaTenKHHoaDonChuaTra.Text != "")
            {
                var dsUser = from x in BUSINESS.HoaDonBUS.LoadHoaDon() where x.Customer_Name.ToLower().Contains(txtTimKiemHoaTenKHHoaDonChuaTra.Text.ToLower()) && x.Status == "Unpaid" select x;
                var lst_Invoice_Details = from x in BUSINESS.HoaDonBUS.LoadHoaDon()
                                          join y in BUSINESS.HoaDonBUS.LoadHoaDonChiTiet() on x.Invoice_Id equals y.Invoice_Id
                                          where x.Customer_Name.ToLower().Contains(txtTimKiemHoaTenKHHoaDonChuaTra.Text.ToLower()) && x.Status == "Unpaid"
                                          select x;
                dtgHoaDonChuaTra.DataSource = dsUser.ToList();
                dtgHoaDonCTChuaTra.DataSource = lst_Invoice_Details.ToList();
            }
            else
            {
                LoadHoaDonChuaTra();
                LoadHoaDonChiTietChuaTra();
            }
        }

        private void cbNgayHoaDonChuaTra_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNgayHoaDonChuaTra.SelectedIndex != 0)
            {
                TimHoaDonChuaTra();
            }
            else
            {
                LoadHoaDonChuaTra();
                LoadHoaDonChiTietChuaTra();
            }
        }

        private void cbThangHoaDonChuaTra_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbThangHoaDonChuaTra.SelectedIndex != 0)
            {
                TimHoaDonChuaTra();
            }
            else
            {
                LoadHoaDonChuaTra();
                LoadHoaDonChiTietChuaTra();
            }
        }

        private void cbNamHoaDonChuaTra_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNamHoaDonChuaTra.SelectedIndex != 0)
            {
                TimHoaDonChuaTra();
            }
            else
            {
                LoadHoaDonChuaTra();
                LoadHoaDonChiTietChuaTra();
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
