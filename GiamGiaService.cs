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
using Data_Transfer_Object;

namespace WindowsFormsApp4
{
    public partial class GiamGiaService : Form
    {
        public GiamGiaService()
        {
            InitializeComponent();
            cbChonDonViGG.SelectedIndex = 0;
            cbTrangThai.SelectedIndex = 0;
        }

        private void GiamGiaService_Load(object sender, EventArgs e)
        {
            dtgChonSP.EnableHeadersVisualStyles = false;
            dtgChonSP.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkTurquoise;
            dtgEventList.EnableHeadersVisualStyles = false;
            dtgEventList.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkTurquoise;
            LoadGG();
            LoadDataSP();
        }
        private void LoadGG()
        {
            List<GiamGiaDTO> dsUser = BUSINESS.GiamGiaBUS.LoadGG();
            dtgEventList.Columns.Clear();
            dtgEventList.DataSource = dsUser;
        }
        private void LoadDataSP()
        {
            var dsUser = from x in BUSINESS.SanPhamBUS.TatcaSP()
                         where x.Product_Id != ((from y in BUSINESS.GiamGiaBUS.LoadGG() where y.Status == "Đang diễn ra" select y.Product_ID).FirstOrDefault())
                         select new
                         {
                             Product_Id = x.Product_Id,
                             Product_Name = x.Product_Name,
                             Product_Type = x.Product_Type,
                             DOM = x.DOM.Value.Date,
                             Expiry = x.Expiry.Value.Date,
                             Price = Convert.ToString(string.Format("{0:0,0} VND", x.Price))
                         };
            dtgChonSP.DataSource = dsUser.ToList();
        }
        private bool CheckLoiNull()
        {
            if (!string.IsNullOrEmpty(txtMaGG.Text) &&
                !string.IsNullOrEmpty(txtTenGG.Text) &&
                !string.IsNullOrEmpty(txtMucGG.Text))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Vui Lòng nhập đầy đủ thông tin", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BUSINESS.GiamGiaBUS.ChuyenTrangThaiTuDong();
        }

        private void dateTimePickerNgayKT_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerNgayKT.Value < dateTimePickerNgayBD.Value)
            {
                MessageBox.Show("Ngày kết thúc không được nhỏ hơn ngày bắt đầu");
            }
            else if (dateTimePickerNgayKT.Value < DateTime.Now)
            {
                cbTrangThai.Text = "Đã kết thuc";
            }
            else if (dateTimePickerNgayKT.Value > DateTime.Now)
            {
                cbTrangThai.Text = "Đang diễn ra";
            }
        }

        private void cbChonDonViGG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbChonDonViGG.SelectedIndex == 0)
            {
                label15.Text = "%";
            }
            else if (cbChonDonViGG.SelectedIndex == 1)
            {
                label15.Text = "VND";
            }
        }

        private void btnThemm_Click(object sender, EventArgs e)
        {
            try
            {
                #region
                string tt = null;
                if (dateTimePickerNgayBD.Value.Date > DateTime.Now.Date)
                {
                    tt = "Chưa diễn ra";
                }
                else if (dateTimePickerNgayBD.Value.Date < DateTime.Now.Date || dateTimePickerNgayBD.Value.Date == DateTime.Now.Date)
                {
                    tt = "Đang diễn ra";
                }
                #endregion
                if (CheckLoiNull() == true)
                {
                    int total = dtgChonSP.Rows.Cast<DataGridViewRow>().Where(p => Convert.ToBoolean(p.Cells["Select_Product"].Value) == true).Count();
                    if (total > 0)
                    {
                        string mess = $"Bạn đang chọn {total} dòng";
                        if (total >= 1)
                            mess = $"Bạn chắc chắn giảm giá {total} sản phẩm này chứ?";
                        if (MessageBox.Show(mess, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            for (int i = 0; i < total; i++)
                            {
                                MessageBox.Show($"{i}");
                                DataGridViewRow r = dtgChonSP.Rows[i];
                                BUSINESS.GiamGiaBUS.ThemGG(txtMaGG.Text, txtTenGG.Text, cbChonDonViGG.SelectedIndex,
                                        Convert.ToSingle(txtMucGG.Text), dateTimePickerNgayBD.Value, dateTimePickerNgayKT.Value, dtgChonSP.Rows[i].Cells[1].Value.ToString(), tt);
                            }
                            LoadGG();
                            LoadDataSP();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn sản phẩm");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiem.Text != "")
            {
                List<GiamGiaDTO> dsUser = BUSINESS.GiamGiaBUS.FindGG(txtTimKiem.Text);
                dtgEventList.DataSource = dsUser;
            }
            else
            {
                LoadGG();
            }
        }

        private void btnSuaa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn chuyển trạng thái thành đã kết thúc ?", "Star Glocery", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (BUSINESS.GiamGiaBUS.ChuyenTrangThaiBangTay(txtMaGG.Text) == true)
                {
                    MessageBox.Show("Chuyển trạng thái thành công");
                    LoadGG();
                }
                else
                {
                    MessageBox.Show("Chuyển trạng thái thất bại");
                }
            }
        }

        private void txtMaGG_TextChanged(object sender, EventArgs e)
        {
            if (txtMaGG.Text.Length > 10)
            {
                if (!Regex.Match(txtMaGG.Text, @"^\w+$").Success)
                {
                    MessageBox.Show("Mã Giảm giá không hợp lệ");
                }
            }
        }

        private void txtTenGG_TextChanged(object sender, EventArgs e)
        {
            if (txtTenGG.Text != "")
            {
                if (!Regex.IsMatch(txtTenGG.Text, @"^[\w\s]+$") || txtTenGG.Text.Length >= 100)
                {
                    MessageBox.Show("Tên Chương trình không hợp lệ");
                }
            }
        }

        private void txtMucGG_TextChanged(object sender, EventArgs e)
        {
            if (txtMucGG.Text != "")
            {
                if (cbChonDonViGG.SelectedIndex == 0)
                {
                    if (!Regex.Match(txtMucGG.Text, @"^\d+$").Success)
                    {
                        MessageBox.Show("Mức giảm giá không hợp lệ");
                    }
                    else if (int.Parse(txtMucGG.Text) < 0)
                    {
                        MessageBox.Show("Mức giảm giá không được nhỏ hơn 0%");
                    }
                    else if (int.Parse(txtMucGG.Text) > 100)
                    {
                        MessageBox.Show("Mức giảm giá không được lớn hơn 100%");
                    }
                }
                else
                {
                    if (!Regex.Match(txtMucGG.Text, @"^\d+$").Success)
                    {
                        MessageBox.Show("Mức giảm giá không hợp lệ");
                    }
                    else if (int.Parse(txtMucGG.Text) < 0)
                    {
                        MessageBox.Show("Mức giảm giá không được nhỏ hơn 0 VNĐ");
                    }
                    else
                    {
                        var dsUser = from x in BUSINESS.SanPhamBUS.TatcaSP()
                                     where x.Product_Id != ((from y in BUSINESS.GiamGiaBUS.LoadGG()
                                                             where y.Status == "Đang diễn ra"
                                                             select y.Product_ID).FirstOrDefault())
                                     && x.Price >= Convert.ToSingle(txtMucGG.Text)
                                     select new
                                     {
                                         Product_Id = x.Product_Id,
                                         Product_Name = x.Product_Name,
                                         Product_Type = x.Product_Type,
                                         DOM = x.DOM.Value.Date,
                                         Expiry = x.Expiry.Value.Date,
                                         Price = Convert.ToString(string.Format("{0:0,0} VND", x.Price))
                                     };
                        dtgChonSP.DataSource = dsUser.ToList();
                    }
                }
            }
        }

        private void dtgEventList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = e.RowIndex;
            DataGridViewRow select = dtgEventList.Rows[id];
            txtMaGG.Text = select.Cells[0].Value.ToString();
            txtTenGG.Text = select.Cells[1].Value.ToString();
            cbChonDonViGG.SelectedIndex = Convert.ToInt32(select.Cells[3].Value.ToString()) - 1;
            txtMucGG.Text = select.Cells[4].Value.ToString();
            dateTimePickerNgayBD.Text = select.Cells[5].Value.ToString();
            dateTimePickerNgayKT.Text = select.Cells[6].Value.ToString();
        }

        private void txtMucGG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
