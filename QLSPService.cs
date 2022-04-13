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
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using Data_Transfer_Object;

namespace WindowsFormsApp4
{
    public partial class QLSPService : Form
    {
        FilterInfoCollection fill;
        VideoCaptureDevice video;
        public QLSPService()
        {
            InitializeComponent();
            pictureBoxHienAnhSP.TabStop = false;
            comboBoxLoáianPham.SelectedIndex = 0;
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
        private void QLSPService_Load(object sender, EventArgs e)
        {
            dataGridViewHienThiSanPhamQLSP.EnableHeadersVisualStyles = false;
            dataGridViewHienThiSanPhamQLSP.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkTurquoise;
            dataFastFood.EnableHeadersVisualStyles = false;
            dataFastFood.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkTurquoise;
            dataGVdoDungThietYeu.EnableHeadersVisualStyles = false;
            dataGVdoDungThietYeu.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkTurquoise;
            dataGVKhac.EnableHeadersVisualStyles = false;
            dataGVKhac.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkTurquoise;
            dataGVNuocGiaiKhat.EnableHeadersVisualStyles = false;
            dataGVNuocGiaiKhat.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkTurquoise;
            dataGVFood.EnableHeadersVisualStyles = false;
            dataGVFood.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkTurquoise;

            LoadDataAllSP();
            LoadDataDoAnNhanh();
            LoadDataDoDungThietYeu();
            LoadDataNuocGiaiKhat();
            LoadDataThucPham();
            LoadDataSPKhac();

            fill = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in fill)
                cbWebCam.Items.Add(device.Name);
            cbWebCam.SelectedIndex = 0;
        }
        private void ClearData()
        {
            txtMaSPQLSP.Clear();
            txtTenSPQLSP.Clear();
            txtDonGiaQLSP.Clear();
            txtNguonGocXuatXu.Clear();
            txtMoTa.Clear();
            txtSoLuongNhap.Clear();
            txtSoLuongConLai.Clear();
            pictureBoxHienAnhSP.Image = null;
            txtGiaNhapVao.Clear();
            txtMaGach.Clear();
        }
        private bool CheckLoiNull()
        {
            if (!string.IsNullOrEmpty(txtTenSPQLSP.Text) &&
                !string.IsNullOrEmpty(txtDonGiaQLSP.Text) &&
                !string.IsNullOrEmpty(txtGiaNhapVao.Text) &&
                !string.IsNullOrEmpty(txtSoLuongNhap.Text) &&
                !string.IsNullOrEmpty(txtNguonGocXuatXu.Text) &&
                !string.IsNullOrEmpty(txtSoLuongConLai.Text) && pictureBoxHienAnhSP.Image != null &&
                !string.IsNullOrEmpty(txtMaGach.Text))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Vui Lòng nhập đầy đủ thông tin", "N Shop Flower", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool CheckloiAnhSP()
        {
            if (pictureBoxHienAnhSP.Image != null)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Vùi lòng tải ảnh", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        private bool CheckLoiTenSP()
        {
            if (!Regex.IsMatch(txtTenSPQLSP.Text, @"^[\w\s]+$") || txtTenSPQLSP.Text.Length > 50)
            {
                MessageBox.Show("Tên SP k hợp lệ");
                return false;
            }
            else
            {
                return true;
            }// end if  
        }
        private bool CheckLoisoLuong()
        {
            if (int.Parse(txtSoLuongNhap.Text) < 0 || int.Parse(txtSoLuongNhap.Text) > 5000)
            {
                MessageBox.Show("Số Lượng nhập chỉ được nằm trong khoảng 0 ->5000");
                return false;
            }
            else if (int.Parse(txtSoLuongConLai.Text) < 0 || int.Parse(txtSoLuongConLai.Text) > 5000 || int.Parse(txtSoLuongConLai.Text) > int.Parse(txtSoLuongNhap.Text))
            {
                MessageBox.Show("Số Lượng còn lại không hợp lệ");
                return false;
            }
            else
            {
                return true;
            }// end if  
        }
        private byte[] ImagesToBySP(PictureBox picture)
        {
            MemoryStream memoryStream = new MemoryStream();
            picture.Image.Save(memoryStream, picture.Image.RawFormat);
            return memoryStream.ToArray();
        }

        private void LoadDataAllSP()
        {
            List<SanPhamDTO> dsUser = BUSINESS.SanPhamBUS.TatcaSP();
            dataGridViewHienThiSanPhamQLSP.DataSource = dsUser;
            DataGridViewImageColumn pic = new DataGridViewImageColumn();
            pic = (DataGridViewImageColumn)dataGridViewHienThiSanPhamQLSP.Columns[0];
            pic.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }
        private void LoadDataDoAnNhanh()
        {
            List<SanPhamDTO> dsUser = BUSINESS.SanPhamBUS.DoAnNhanh();
            dataFastFood.DataSource = dsUser;
            DataGridViewImageColumn pic = new DataGridViewImageColumn();
            pic = (DataGridViewImageColumn)dataFastFood.Columns[0];
            pic.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }
        private void LoadDataNuocGiaiKhat()
        {
            List<SanPhamDTO> dsUser = BUSINESS.SanPhamBUS.NuocGiaiKhat();
            dataGVNuocGiaiKhat.DataSource = dsUser;
            DataGridViewImageColumn pic = new DataGridViewImageColumn();
            pic = (DataGridViewImageColumn)dataGVNuocGiaiKhat.Columns[0];
            pic.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }
        private void LoadDataDoDungThietYeu()
        {
            List<SanPhamDTO> dsUser = BUSINESS.SanPhamBUS.DoDungThietYeu();
            dataGVdoDungThietYeu.DataSource = dsUser;
            DataGridViewImageColumn pic = new DataGridViewImageColumn();
            pic = (DataGridViewImageColumn)dataGVdoDungThietYeu.Columns[0];
            pic.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }
        private void LoadDataThucPham()
        {
            List<SanPhamDTO> dsUser = BUSINESS.SanPhamBUS.ThucPham();
            dataGVFood.DataSource = dsUser;
            DataGridViewImageColumn pic = new DataGridViewImageColumn();
            pic = (DataGridViewImageColumn)dataGVFood.Columns[0];
            pic.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }
        private void LoadDataSPKhac()
        {
            List<SanPhamDTO> dsUser = BUSINESS.SanPhamBUS.SPKhac();
            dataGVKhac.DataSource = dsUser;
            DataGridViewImageColumn pic = new DataGridViewImageColumn();
            pic = (DataGridViewImageColumn)dataGVKhac.Columns[0];
            pic.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }

        private void dataGridViewHienThiSanPhamQLSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = e.RowIndex;
            DataGridViewRow select = dataGridViewHienThiSanPhamQLSP.Rows[id];
            //Ảnh sản phẩm
            if (select.Cells[0].Value != null)
            {
                MemoryStream memoryStream = new MemoryStream((byte[])select.Cells[0].Value);
                pictureBoxHienAnhSP.Image = Image.FromStream(memoryStream);
            }
            else
            {
                pictureBoxHienAnhSP.Image = null;
            }
            txtMaSPQLSP.Text = select.Cells[1].Value.ToString();
            txtTenSPQLSP.Text = select.Cells[2].Value.ToString();
            comboBoxLoáianPham.Text = select.Cells[3].Value.ToString();
            txtNguonGocXuatXu.Text = select.Cells[4].Value.ToString();
            dateTimePickerNgayNhap.Text = select.Cells[5].Value.ToString();
            txtSoLuongNhap.Text = select.Cells[6].Value.ToString();
            txtSoLuongConLai.Text = select.Cells[7].Value.ToString();
            dtpNSX.Text = select.Cells[8].Value.ToString();
            dtpHSD.Text = select.Cells[9].Value.ToString();
            txtGiaNhapVao.Text = select.Cells[11].Value.ToString();
            txtDonGiaQLSP.Text = select.Cells[12].Value.ToString();
        }

        private void txtTimKiemQLSP_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiemQLSP.Text != "")
            {
                List<SanPhamDTO> dsUser = BUSINESS.SanPhamBUS.FindAllProduct(txtTimKiemQLSP.Text);
                dataGridViewHienThiSanPhamQLSP.DataSource = dsUser;
            }
            else
            {
                LoadDataAllSP();
            }
        }

        private void pictureBoxHienAnhSP_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string imgLocation = "";//tạo biến để lưu đường dẫ cho ảnh
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.ShowDialog();
                //khi mình chọn 1 file thì đường dẫn của file sẽ được lưu lại
                imgLocation = dialog.FileName;//FileName là thuộc tính lưu lại đường dẫn
                pictureBoxHienAnhSP.Image = Image.FromFile(imgLocation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxLoáianPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLoáianPham.SelectedIndex == 0)
            {
                txtMaSPQLSP.Text = "BE" + CreateMaHD(8);
            }
            else if (comboBoxLoáianPham.SelectedIndex == 1)
            {
                txtMaSPQLSP.Text = "FA" + CreateMaHD(8);
            }
            else if (comboBoxLoáianPham.SelectedIndex == 2)
            {
                txtMaSPQLSP.Text = "FO" + CreateMaHD(8);
            }
            else if (comboBoxLoáianPham.SelectedIndex == 3)
            {
                txtMaSPQLSP.Text = "NE" + CreateMaHD(8);
            }
            else if (comboBoxLoáianPham.SelectedIndex == 4)
            {
                txtMaSPQLSP.Text = "OT" + CreateMaHD(8);
            }
        }

        private void txtSoLuongNhap_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtSoLuongConLai_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtDonGiaQLSP_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtGiaNhapVao_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnThemm_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckLoiNull() == true && CheckLoiTenSP() == true
                    && CheckloiAnhSP() == true && CheckLoisoLuong() == true)
                {
                    if (MessageBox.Show("Bạn chắc chắn muốn Thêm ?", "N Shop Flower",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        byte[] anh = ImagesToBySP(pictureBoxHienAnhSP);
                        if (BUSINESS.SanPhamBUS.ThemSanPham(txtMaSPQLSP.Text, txtTenSPQLSP.Text, txtNguonGocXuatXu.Text, dateTimePickerNgayNhap.Value,
                            Convert.ToSingle(txtGiaNhapVao.Text), Convert.ToInt32(txtSoLuongNhap.Text), Convert.ToInt32(txtSoLuongConLai.Text),
                            Convert.ToSingle(txtDonGiaQLSP.Text), anh, dtpNSX.Value, dtpHSD.Value,
                            comboBoxLoáianPham.Text, txtMoTa.Text, txtMaGach.Text) == true)
                        {
                            MessageBox.Show("Thêm thành công sản phẩm vào gian hàng");
                        }
                        else
                        {
                            if (MessageBox.Show("Sản phẩm này đã tồn tại trong gian hàng\nBạn có muốn tăng thêm số lượng" +
                                " cho sản phẩm này không ?", "N Shop Flower",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                if (BUSINESS.SanPhamBUS.CongThemSoLuongSP(txtMaSPQLSP.Text, txtTenSPQLSP.Text,
                                    Convert.ToInt32(txtSoLuongNhap.Text), Convert.ToInt32(txtSoLuongConLai.Text)) == true)
                                {
                                    MessageBox.Show("Đã thêm số lượng sản phẩm thành công vào gian hàng");
                                }
                                else
                                {
                                    MessageBox.Show("Thêm Không thành công");
                                }
                            }
                        }
                        LoadDataAllSP();
                        LoadDataDoAnNhanh();
                        LoadDataDoDungThietYeu();
                        LoadDataNuocGiaiKhat();
                        LoadDataThucPham();
                        LoadDataSPKhac();
                        ClearData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "N Shop Flower");
            }
        }

        private void btnSuaa_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckLoiNull() == true && CheckLoiTenSP() == true
                    && CheckloiAnhSP() == true)
                {
                    if (MessageBox.Show("Bạn chắc chắn muốn Sửa ?", "N Shop Flower",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        byte[] anh = ImagesToBySP(pictureBoxHienAnhSP);
                        if (BUSINESS.SanPhamBUS.SuaSanPham(txtMaSPQLSP.Text, txtTenSPQLSP.Text, txtNguonGocXuatXu.Text, dateTimePickerNgayNhap.Value,
                            Convert.ToSingle(txtGiaNhapVao.Text), Convert.ToInt32(txtSoLuongNhap.Text), Convert.ToInt32(txtSoLuongConLai.Text),
                            Convert.ToSingle(txtDonGiaQLSP.Text), anh, dtpNSX.Value, dtpHSD.Value,
                            comboBoxLoáianPham.Text, txtMoTa.Text) == true)
                        {
                            MessageBox.Show("Sửa thành công");
                        }
                        else
                        {
                            MessageBox.Show("Sửa Không thành công");
                        }
                        LoadDataAllSP();
                        LoadDataDoAnNhanh();
                        LoadDataDoDungThietYeu();
                        LoadDataNuocGiaiKhat();
                        LoadDataThucPham();
                        LoadDataSPKhac();
                        ClearData();
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
            ClearData();
        }

        private void txtTimKiemFastFood_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiemFastFood.Text != "")
            {
                List<SanPhamDTO> dsUser = BUSINESS.SanPhamBUS.FinđoAnNhanh(txtTimKiemFastFood.Text);
                dataFastFood.DataSource = dsUser;
            }
            else
            {
                LoadDataDoAnNhanh();
            }
        }

        private void txtTimKiemNuocGiaiKhat_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiemNuocGiaiKhat.Text != "")
            {
                List<SanPhamDTO> dsUser = BUSINESS.SanPhamBUS.FindNuocGiaiKhat(txtTimKiemNuocGiaiKhat.Text);
                dataGVNuocGiaiKhat.DataSource = dsUser;
            }
            else
            {
                LoadDataNuocGiaiKhat();
            }
        }

        private void txtTimKiemFood_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiemFood.Text != "")
            {
                List<SanPhamDTO> dsUser = BUSINESS.SanPhamBUS.FindThucPham(txtTimKiemFood.Text);
                dataGVFood.DataSource = dsUser;
            }
            else
            {
                LoadDataThucPham();
            }
        }

        private void txtTimKiemDodungThietYeu_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiemDodungThietYeu.Text != "")
            {
                List<SanPhamDTO> dsUser = BUSINESS.SanPhamBUS.FindoDungThietYeu(txtTimKiemDodungThietYeu.Text);
                dataGVdoDungThietYeu.DataSource = dsUser;
            }
            else
            {
                LoadDataDoDungThietYeu();
            }
        }

        private void txtTimKiemKhac_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiemKhac.Text != "")
            {
                List<SanPhamDTO> dsUser = BUSINESS.SanPhamBUS.FindSPKhac(txtTimKiemKhac.Text);
                dataGVdoDungThietYeu.DataSource = dsUser;
            }
            else
            {
                LoadDataSPKhac();
            }
        }

        private void dataFastFood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = e.RowIndex;
            DataGridViewRow select = dataFastFood.Rows[id];
            //Ảnh sản phẩm
            if (select.Cells[0].Value != null)
            {
                MemoryStream memoryStream = new MemoryStream((byte[])select.Cells[0].Value);
                pictureBoxHienAnhSP.Image = Image.FromStream(memoryStream);
            }
            else
            {
                pictureBoxHienAnhSP.Image = null;
            }
            txtMaSPQLSP.Text = select.Cells[1].Value.ToString();
            txtTenSPQLSP.Text = select.Cells[2].Value.ToString();
            comboBoxLoáianPham.Text = select.Cells[3].Value.ToString();
            txtNguonGocXuatXu.Text = select.Cells[4].Value.ToString();
            dateTimePickerNgayNhap.Text = select.Cells[5].Value.ToString();
            txtSoLuongNhap.Text = select.Cells[6].Value.ToString();
            txtSoLuongConLai.Text = select.Cells[7].Value.ToString();
            dtpNSX.Text = select.Cells[8].Value.ToString();
            dtpHSD.Text = select.Cells[9].Value.ToString();
            txtGiaNhapVao.Text = select.Cells[11].Value.ToString();
            txtDonGiaQLSP.Text = select.Cells[12].Value.ToString();
        }

        private void dataGVNuocGiaiKhat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = e.RowIndex;
            DataGridViewRow select = dataGVNuocGiaiKhat.Rows[id];
            //Ảnh sản phẩm
            if (select.Cells[0].Value != null)
            {
                MemoryStream memoryStream = new MemoryStream((byte[])select.Cells[0].Value);
                pictureBoxHienAnhSP.Image = Image.FromStream(memoryStream);
            }
            else
            {
                pictureBoxHienAnhSP.Image = null;
            }
            txtMaSPQLSP.Text = select.Cells[1].Value.ToString();
            txtTenSPQLSP.Text = select.Cells[2].Value.ToString();
            comboBoxLoáianPham.Text = select.Cells[3].Value.ToString();
            txtNguonGocXuatXu.Text = select.Cells[4].Value.ToString();
            dateTimePickerNgayNhap.Text = select.Cells[5].Value.ToString();
            txtSoLuongNhap.Text = select.Cells[6].Value.ToString();
            txtSoLuongConLai.Text = select.Cells[7].Value.ToString();
            dtpNSX.Text = select.Cells[8].Value.ToString();
            dtpHSD.Text = select.Cells[9].Value.ToString();
            txtGiaNhapVao.Text = select.Cells[11].Value.ToString();
            txtDonGiaQLSP.Text = select.Cells[12].Value.ToString();
        }

        private void dataGVFood_CellBorderStyleChanged(object sender, EventArgs e)
        {

        }

        private void dataGVFood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = e.RowIndex;
            DataGridViewRow select = dataGVFood.Rows[id];
            //Ảnh sản phẩm
            if (select.Cells[0].Value != null)
            {
                MemoryStream memoryStream = new MemoryStream((byte[])select.Cells[0].Value);
                pictureBoxHienAnhSP.Image = Image.FromStream(memoryStream);
            }
            else
            {
                pictureBoxHienAnhSP.Image = null;
            }
            txtMaSPQLSP.Text = select.Cells[1].Value.ToString();
            txtTenSPQLSP.Text = select.Cells[2].Value.ToString();
            comboBoxLoáianPham.Text = select.Cells[3].Value.ToString();
            txtNguonGocXuatXu.Text = select.Cells[4].Value.ToString();
            dateTimePickerNgayNhap.Text = select.Cells[5].Value.ToString();
            txtSoLuongNhap.Text = select.Cells[6].Value.ToString();
            txtSoLuongConLai.Text = select.Cells[7].Value.ToString();
            dtpNSX.Text = select.Cells[8].Value.ToString();
            dtpHSD.Text = select.Cells[9].Value.ToString();
            txtGiaNhapVao.Text = select.Cells[11].Value.ToString();
            txtDonGiaQLSP.Text = select.Cells[12].Value.ToString();
        }

        private void dataGVdoDungThietYeu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = e.RowIndex;
            DataGridViewRow select = dataGVdoDungThietYeu.Rows[id];
            //Ảnh sản phẩm
            if (select.Cells[0].Value != null)
            {
                MemoryStream memoryStream = new MemoryStream((byte[])select.Cells[0].Value);
                pictureBoxHienAnhSP.Image = Image.FromStream(memoryStream);
            }
            else
            {
                pictureBoxHienAnhSP.Image = null;
            }
            txtMaSPQLSP.Text = select.Cells[1].Value.ToString();
            txtTenSPQLSP.Text = select.Cells[2].Value.ToString();
            comboBoxLoáianPham.Text = select.Cells[3].Value.ToString();
            txtNguonGocXuatXu.Text = select.Cells[4].Value.ToString();
            dateTimePickerNgayNhap.Text = select.Cells[5].Value.ToString();
            txtSoLuongNhap.Text = select.Cells[6].Value.ToString();
            txtSoLuongConLai.Text = select.Cells[7].Value.ToString();
            dtpNSX.Text = select.Cells[8].Value.ToString();
            dtpHSD.Text = select.Cells[9].Value.ToString();
            txtGiaNhapVao.Text = select.Cells[11].Value.ToString();
            txtDonGiaQLSP.Text = select.Cells[12].Value.ToString();
        }

        private void dataGVKhac_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = e.RowIndex;
            DataGridViewRow select = dataGVKhac.Rows[id];
            //Ảnh sản phẩm
            if (select.Cells[0].Value != null)
            {
                MemoryStream memoryStream = new MemoryStream((byte[])select.Cells[0].Value);
                pictureBoxHienAnhSP.Image = Image.FromStream(memoryStream);
            }
            else
            {
                pictureBoxHienAnhSP.Image = null;
            }
            txtMaSPQLSP.Text = select.Cells[1].Value.ToString();
            txtTenSPQLSP.Text = select.Cells[2].Value.ToString();
            comboBoxLoáianPham.Text = select.Cells[3].Value.ToString();
            txtNguonGocXuatXu.Text = select.Cells[4].Value.ToString();
            dateTimePickerNgayNhap.Text = select.Cells[5].Value.ToString();
            txtSoLuongNhap.Text = select.Cells[6].Value.ToString();
            txtSoLuongConLai.Text = select.Cells[7].Value.ToString();
            dtpNSX.Text = select.Cells[8].Value.ToString();
            dtpHSD.Text = select.Cells[9].Value.ToString();
            txtGiaNhapVao.Text = select.Cells[11].Value.ToString();
            txtDonGiaQLSP.Text = select.Cells[12].Value.ToString();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            video = new VideoCaptureDevice(fill[cbWebCam.SelectedIndex].MonikerString);
            video.NewFrame += Video_NewFrame;
            video.Start();
        }
        private void Video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
                BarcodeReader reader = new BarcodeReader();
                var result = reader.Decode(bitmap);
                pcWebCam.Image = bitmap;
                if (result != null)
                {
                    txtMaGach.Invoke(new MethodInvoker(delegate ()
                    {
                        txtMaGach.Text = result.ToString();
                    }));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (video != null)
            {
                video.Stop();
                pcWebCam.Image = null;
            }
            else
            {
                MessageBox.Show("Camera hiện đang không bật");
            }
        }
        private void dtpNSX_ValueChanged(object sender, EventArgs e)
        {
            if (dtpNSX.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày sản xuất không hợp lệ");
                dtpNSX.Value = DateTime.Now;
            }
        }

        private void dtpHSD_ValueChanged(object sender, EventArgs e)
        {
            if (dtpNSX.Value > dtpHSD.Value)
            {
                MessageBox.Show("Hạn sử dụng không được lớn hơn ngày sản xuất");
                dtpHSD.Value = DateTime.Now;
            }
        }

        private void dateTimePickerNgayNhap_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerNgayNhap.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày nhập không được lớn hơn ngày hiện tại");
                dateTimePickerNgayNhap.Value = DateTime.Now;
            }
        }

        private void txtSoLuongNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Số lượng nhập không hợp lệ");
                e.Handled = true;
            }
        }

        private void txtSoLuongConLai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Số lượng còn lại không hợp lệ");
                e.Handled = true;
            }
        }

        private void txtGiaNhapVao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Số lượng vào không hợp lệ");
                e.Handled = true;
            }
        }

        private void txtDonGiaQLSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Đơn giá không hợp lệ");
                e.Handled = true;
            }
        }

        private void txtMoTa_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void txtMoTa_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnImport_Excel_Click(object sender, EventArgs e)
        {
            Import_Product i = new Import_Product();
            i.ShowDialog();
            LoadDataAllSP();
            LoadDataDoAnNhanh();
            LoadDataDoDungThietYeu();
            LoadDataNuocGiaiKhat();
            LoadDataThucPham();
            LoadDataSPKhac();
        }
    }
}
