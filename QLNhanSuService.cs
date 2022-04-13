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
using FaceRecognition;

namespace WindowsFormsApp4
{
    public partial class QLNhanSuService : Form
    {
        public QLNhanSuService()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }
        #region QL nhân viên
        private void LoadDataNV()
        {
            List<NhanVienDTO> dsUser = BUSINESS.NhanVienBUS.GetDSUSer();
            dataGVHienThiNV.DataSource = dsUser;
            dataGVHienThiNV.EnableHeadersVisualStyles = false;
            dataGVHienThiNV.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkTurquoise;
            DataGridViewImageColumn pic = new DataGridViewImageColumn();
            pic = (DataGridViewImageColumn)dataGVHienThiNV.Columns[0];
            pic.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }
        private bool CheckLoiNgaySinh()
        {
            if (dateTimePickerNgaySinh.Value.Year < Convert.ToInt32(DateTime.Now.Year - 18))
            {
                MessageBox.Show("Tuổi không được nhỏ hơn 18");
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool ChecLoiTenNV()
        {
            string muihuong = txtTenNVQLNV.Text;
            bool result = muihuong.Replace(" ", "").All(Char.IsLetter);
            if (result == false || txtTenNVQLNV.Text.Length > 50)
            {
                MessageBox.Show("Tên NV không hợp lệ");
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool CheckLoiMK()
        {
            if (!Regex.Match(txtMK.Text, @"^[0-9a-zA-Z]+$").Success || txtMK.Text.Length < 4)
            {
                MessageBox.Show("Mật khẩu chỉ bao gồm các kí tự chữ và số và phải từu 4 kí tự trở lên");
                return false;
            }
            else
            {
                return true;
            }// end if  
        }
        private bool CheckLoiNullQLNV()
        {
            if (!string.IsNullOrEmpty(txtMaNVQLNV.Text)
                && !string.IsNullOrEmpty(txtTenNVQLNV.Text) && !string.IsNullOrEmpty(txtTenTK.Text) &&
                !string.IsNullOrEmpty(txtMK.Text) &&
                !string.IsNullOrEmpty(txtSDTQLNV.Text) &&
                !string.IsNullOrEmpty(txtLuongQLNV.Text) &&
                !string.IsNullOrEmpty(txtDCQLNV.Text) && pcAnhNV.Image != null)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Không được bỏ trống thông tin", "N Shop Flower", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool CheckLoiSDTQLNV()
        {
            if (!Regex.Match(txtSDTQLNV.Text, @"^(0)[0-9]{9}$").Success)
            {
                MessageBox.Show("Số điện thoại không hợp lệ");
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool CheckLoiMaNVQLNV()
        {
            if (!Regex.IsMatch(txtMaNVQLNV.Text, @"^[NV]+\d{5}$") || txtMaNVQLNV.Text.Length > 16)
            {
                MessageBox.Show("Mã NV phải bắt đầu bằng NV và gồm ít nhất 5 số");
                return false;
            }
            else
            {
                return true;
            }// end if  
        }
        private bool CheckLoiLuongQLNV()
        {
            if (float.Parse(txtLuongQLNV.Text) < 0 || float.Parse(txtLuongQLNV.Text) > 100000000)
            {
                MessageBox.Show("Lương không hợp lệ");
                return false;
            }
            else
            {
                return true;
            }
        }
        private void ClearDataQLNV()
        {
            txtMaNVQLNV.Clear();
            txtTenNVQLNV.Clear();
            txtSDTQLNV.Clear();
            txtLuongQLNV.Clear();
            txtDCQLNV.Clear();
            txtTenTK.Clear();
            txtMK.Clear();
            pcAnhNV.Image = null;
        }
        private byte[] ImagesToBySP(PictureBox picture)
        {
            MemoryStream memoryStream = new MemoryStream();
            picture.Image.Save(memoryStream, picture.Image.RawFormat);
            return memoryStream.ToArray();
        }
        private bool CheckLoiAnhNV()
        {
            if (pcAnhNV.Image == null)
            {
                MessageBox.Show("Vui Lòng tải ảnh nhân viên");
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool ChecLoiTenTkQLNS()
        {
            if (!Regex.Match(txtTenTK.Text, @"\w+@staff.store.vn|\w+@manager.store.vn").Success || txtTenTK.Text.Length > 50)
            {
                MessageBox.Show("Tên Tài khoản phải có đuôi là @manager.store.vn(nếu là Quản lí) " +
                    "hoặc @staff.store.vn(nếu là Nhân Viên) và không được dài hơn 50 kí tự");
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool CheckLoiDiaChiQLNS()
        {
            if (!Regex.Match(txtDCQLNV.Text, @"^[\w:,\s]+$").Success || txtDCQLNV.Text.Length > 100)
            {
                MessageBox.Show("Địa chỉ không hợp lệ");
                return false;
            }
            else
            {
                return true;
            }// end if  
        }
        private void QLNhanSuService_Load(object sender, EventArgs e)
        {
            LoadDataNV();
            LoadTraCongNV();
            LoadDiemDanh();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != 0)
            {
                List<NhanVienDTO> dsUser = BUSINESS.NhanVienBUS.FindToGender(comboBox1.Text);
                dataGVHienThiNV.DataSource = dsUser;
            }
            else
            {
                LoadDataNV();
            }
        }

        private void txtTimKiemQLNV_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiemQLNV.Text != "")
            {
                List<NhanVienDTO> dsUser = BUSINESS.NhanVienBUS.FindStaff(txtTimKiemQLNV.Text);
                dataGVHienThiNV.DataSource = dsUser;
            }
            else
            {
                LoadDataNV();
            }
        }

        private void dataGVHienThiNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = e.RowIndex;
            DataGridViewRow select = dataGVHienThiNV.Rows[id];
            if (select.Cells[0].Value.ToString() != "")
            {
                MemoryStream memoryStream = new MemoryStream((byte[])select.Cells[0].Value);
                pcAnhNV.Image = Image.FromStream(memoryStream);
            }
            else
            {
                pcAnhNV.Image = null;
            }
            txtMaNVQLNV.Text = select.Cells[1].Value.ToString();
            txtTenNVQLNV.Text = select.Cells[2].Value.ToString();
            dateTimePickerNgaySinh.Text = select.Cells[3].Value.ToString();
            if (select.Cells[4].Value.ToString().Trim().Contains("0"))
            {
                rdNam.Checked = true;
            }
            else if (select.Cells[4].Value.ToString().Trim().Contains("1"))
            {
                rdNu.Checked = true;
            }
            txtSDTQLNV.Text = select.Cells[5].Value.ToString();
            txtLuongQLNV.Text = select.Cells[6].Value.ToString();
            txtDCQLNV.Text = select.Cells[7].Value.ToString();
            dateTimePickerNgayGiaNhap.Text = select.Cells[8].Value.ToString();
            comboBoxTrangThai.Text = select.Cells[9].Value.ToString();
        }

        private void pcAnhNV_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string imgLocation = "";//tạo biến để lưu đường dẫ cho ảnh
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.ShowDialog();
                //khi mình chọn 1 file thì đường dẫn của file sẽ được lưu lại
                imgLocation = dialog.FileName;//FileName là thuộc tính lưu lại đường dẫn
                pcAnhNV.Image = Image.FromFile(imgLocation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != 0)
            {
                List<NhanVienDTO> dsUser = BUSINESS.NhanVienBUS.Sort(comboBox2.Text);
                dataGVHienThiNV.DataSource = dsUser;
            }
            else
            {
                LoadDataNV();
            }
        }

        private void btnThemm_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckLoiNullQLNV() == true && CheckLoiMaNVQLNV() == true && ChecLoiTenNV() == true && ChecLoiTenTkQLNS() == true && CheckLoiMK() == true && CheckLoiNgaySinh() == true && CheckLoiSDTQLNV() == true && CheckLoiLuongQLNV() == true && CheckLoiDiaChiQLNS() == true && CheckLoiAnhNV() == true)
                {
                    if (MessageBox.Show("Bạn chắc chắn muốn Thêm ?", "N Shop Flower",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        byte[] anh = ImagesToBySP(pcAnhNV);
                        faceRec.Save_IMAGE(txtTenNVQLNV.Text);
                        if (BUSINESS.NhanVienBUS.ThemNhanVien(txtMaNVQLNV.Text, txtTenNVQLNV.Text, txtTenTK.Text, txtMK.Text,
                            dateTimePickerNgaySinh.Value, rdNam.Checked == true ? 0 : 1, txtSDTQLNV.Text, Convert.ToSingle(txtLuongQLNV.Text),
                            txtDCQLNV.Text, dateTimePickerNgayGiaNhap.Value, comboBoxTrangThai.Text, anh) == true)
                        {
                            MessageBox.Show("Thêm thành công");
                        }
                        else
                        {
                            MessageBox.Show("Thêm không thành công");
                        }
                        ClearDataQLNV();
                        LoadDataNV();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSuaa_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckLoiNullQLNV() == true && CheckLoiMaNVQLNV() == true && ChecLoiTenNV() == true && ChecLoiTenTkQLNS() == true && CheckLoiMK() == true && CheckLoiNgaySinh() == true && CheckLoiSDTQLNV() == true && CheckLoiLuongQLNV() == true && CheckLoiDiaChiQLNS() == true && CheckLoiAnhNV() == true)
                {
                    if (MessageBox.Show("Bạn chắc chắn muốn Sửa ?", "N Shop Flower",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        byte[] anh = ImagesToBySP(pcAnhNV);
                        if (BUSINESS.NhanVienBUS.SuaNhanVien(txtMaNVQLNV.Text, txtTenNVQLNV.Text,
                            dateTimePickerNgaySinh.Value, rdNam.Checked == true ? 0 : 1, txtSDTQLNV.Text, Convert.ToSingle(txtLuongQLNV.Text),
                            txtDCQLNV.Text, dateTimePickerNgayGiaNhap.Value, comboBoxTrangThai.Text, anh) == true)
                        {
                            MessageBox.Show("Sửa thành công");
                        }
                        else
                        {
                            MessageBox.Show("Sửa không thành công");
                        }
                        ClearDataQLNV();
                        LoadDataNV();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "N Shop Flower");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearDataQLNV();
        }
        #endregion kết thúc quản lí nhân viên
        #region Điểm danh và trả công nhân viên
        private void LoadDiemDanh()
        {
            dtgTraCongNV.EnableHeadersVisualStyles = false;
            dtgTraCongNV.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkTurquoise;
            List<DiemDanhNV_DTO> dsUser = BUSINESS.General_BUS.LoadDiemDanh();
            dtgTraCongNV.DataSource = dsUser;
            DataGridViewImageColumn pic = new DataGridViewImageColumn();
            pic = (DataGridViewImageColumn)dtgTraCongNV.Columns[0];
            pic.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }
        private void LoadTraCongNV()
        {
            dtgLuongNV.EnableHeadersVisualStyles = false;
            dtgLuongNV.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkTurquoise;
            List<TraCongNV_DTO> dsUser = BUSINESS.General_BUS.LoadPay2();
            dtgTraCongNV.DataSource = dsUser;
        }

        private void txtTimKiemNVDiemDanh_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiemNVDiemDanh.Text != "")
            {
                List<DiemDanhNV_DTO> dsUser = BUSINESS.General_BUS.TimKiemDiemDanh(txtTimKiemNVDiemDanh.Text);
                dtgTraCongNV.DataSource = dsUser;
            }
            else
            {
                LoadDiemDanh();
            }
        }

        private void txdtTimKiemTraLuongNV_TextChanged(object sender, EventArgs e)
        {
            if (txdtTimKiemTraLuongNV.Text != "")
            {
                List<TraCongNV_DTO> dsUser = BUSINESS.General_BUS.TimKiemTraCongNv(txdtTimKiemTraLuongNV.Text);
                dtgLuongNV.DataSource = dsUser;
            }
            else
            {
                LoadTraCongNV();
            }
        }
        #endregion kết thúc điểm danh và trả công nhân viên

        private void txtLuongQLNV_TextChanged(object sender, EventArgs e)
        {
            if (txtLuongQLNV.Text != "")
            {
                if (!Regex.Match(txtLuongQLNV.Text, @"^\d+$").Success)
                {
                    MessageBox.Show("Lương không hợp lệ");
                }
            }
        }
        FaceRec faceRec = new FaceRec();
        private void button1_Click(object sender, EventArgs e)
        {
            faceRec.openCamera(pictureBox1, pictureBox2);
        }

        private void txtLuongQLNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Lương không hợp lệ");
                e.Handled = true;
            }
        }

        private void txtSDTQLNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Số điện thoại không hợp lệ");
                e.Handled = true;
            }
        }

        private void dateTimePickerNgaySinh_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerNgaySinh.Value.Year > Convert.ToInt32(DateTime.Now.Year - 18))
            {
                MessageBox.Show("Tuổi không được nhỏ hơn 18");
                dateTimePickerNgaySinh.Value = DateTime.Now;
            }
        }

        private void dateTimePickerNgayGiaNhap_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerNgayGiaNhap.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày gia nhập không được lớn hơn ngày hiện tại");
                dateTimePickerNgayGiaNhap.Value = DateTime.Now;
            }
        }
    }
}
