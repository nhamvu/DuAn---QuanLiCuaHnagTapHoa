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
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Threading;
using System.Diagnostics;
using Data_Transfer_Object;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using DuAnBanHang_Winforms_DBFirst.Views;

namespace WindowsFormsApp4
{
    public partial class QLBANHANGService : Form
    {
        //2 biến để quét mã gạch
        FilterInfoCollection fill;
        VideoCaptureDevice video;
        private string tentk, mk;
        public QLBANHANGService()
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
        #region Load Data SP
        private void LoadDataAllSP()
        {
            var dsUser = from x in BUSINESS.SanPhamBUS.TatcaSP()
                         where x.Remain_Amount > 0
                         orderby x.Product_Type descending
                         select new
                         {
                             Prd_Image = x.Images,
                             Prd_Id = x.Product_Id,
                             Prd_Name = x.Product_Name,
                             Prd_Type = x.Product_Type,
                             DOM = x.DOM,
                             Expiry = x.Expiry,
                             Remain_Amount = x.Remain_Amount,
                             Price = x.Price
                         };
            dataGridViewHienThiSanPhamQLSP.DataSource = dsUser.ToList();
            DataGridViewImageColumn pic = new DataGridViewImageColumn();
            pic = (DataGridViewImageColumn)dataGridViewHienThiSanPhamQLSP.Columns[0];
            pic.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }
        private void LoadDataDoAnNhanh()
        {
            var dsUser = from x in BUSINESS.SanPhamBUS.DoAnNhanh()
                         where x.Remain_Amount > 0
                         orderby x.Product_Type descending
                         select new
                         {
                             Prd_Image = x.Images,
                             Prd_Id = x.Product_Id,
                             Prd_Name = x.Product_Name,
                             Prd_Type = x.Product_Type,
                             DOM = x.DOM,
                             Expiry = x.Expiry,
                             Remain_Amount = x.Remain_Amount,
                             Price = x.Price
                         };
            dataFastFood.DataSource = dsUser.ToList();
            DataGridViewImageColumn pic = new DataGridViewImageColumn();
            pic = (DataGridViewImageColumn)dataFastFood.Columns[0];
            pic.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }
        private void LoadDataNuocGiaiKhat()
        {
            var dsUser = from x in BUSINESS.SanPhamBUS.NuocGiaiKhat()
                         where x.Remain_Amount > 0
                         select new
                         {
                             Prd_Image = x.Images,
                             Prd_Id = x.Product_Id,
                             Prd_Name = x.Product_Name,
                             Prd_Type = x.Product_Type,
                             DOM = x.DOM,
                             Expiry = x.Expiry,
                             Remain_Amount = x.Remain_Amount,
                             Price = x.Price
                         };
            dataGVNuocGiaiKhat.DataSource = dsUser.ToList();
            DataGridViewImageColumn pic = new DataGridViewImageColumn();
            pic = (DataGridViewImageColumn)dataGVNuocGiaiKhat.Columns[0];
            pic.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }
        private void LoadDataDoDungThietYeu()
        {
            var dsUser = from x in BUSINESS.SanPhamBUS.DoDungThietYeu()
                         where x.Remain_Amount > 0
                         select new
                         {
                             Prd_Image = x.Images,
                             Prd_Id = x.Product_Id,
                             Prd_Name = x.Product_Name,
                             Prd_Type = x.Product_Type,
                             DOM = x.DOM,
                             Expiry = x.Expiry,
                             Remain_Amount = x.Remain_Amount,
                             Price = x.Price
                         };
            dataGVdoDungThietYeu.DataSource = dsUser.ToList();
            DataGridViewImageColumn pic = new DataGridViewImageColumn();
            pic = (DataGridViewImageColumn)dataGVdoDungThietYeu.Columns[0];
            pic.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }
        private void LoadDataThucPham()
        {
            var dsUser = from x in BUSINESS.SanPhamBUS.ThucPham()
                         where x.Remain_Amount > 0
                         select new
                         {
                             Prd_Image = x.Images,
                             Prd_Id = x.Product_Id,
                             Prd_Name = x.Product_Name,
                             Prd_Type = x.Product_Type,
                             DOM = x.DOM,
                             Expiry = x.Expiry,
                             Remain_Amount = x.Remain_Amount,
                             Price = x.Price
                         };
            dataGVFood.DataSource = dsUser.ToList();
            DataGridViewImageColumn pic = new DataGridViewImageColumn();
            pic = (DataGridViewImageColumn)dataGVFood.Columns[0];
            pic.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }
        private void LoadDataSPKhac()
        {
            var dsUser = from x in BUSINESS.SanPhamBUS.SPKhac()
                         where x.Remain_Amount > 0
                         select new
                         {
                             Prd_Image = x.Images,
                             Prd_Id = x.Product_Id,
                             Prd_Name = x.Product_Name,
                             Prd_Type = x.Product_Type,
                             DOM = x.DOM,
                             Expiry = x.Expiry,
                             Remain_Amount = x.Remain_Amount,
                             Price = x.Price
                         };
            dataGVKhac.DataSource = dsUser.ToList();
            DataGridViewImageColumn pic = new DataGridViewImageColumn();
            pic = (DataGridViewImageColumn)dataGVKhac.Columns[0];
            pic.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }
        #endregion
        private void LoadGioHang()
        {
            if (txtTenKH.Text != "")
            {
                List<GioHangDTO> dsUser = BUSINESS.HoaDonBUS.LoadGiohang();
                dataGridViewDanhSachDatHang.DataSource = dsUser;
                var layThongTin = from x in BUSINESS.HoaDonBUS.LoadGiohang()
                                  where x.Customer_Name == txtTenKH.Text
                                  select new
                                  {
                                      TutolMoney = x.Quantily * x.Price
                                  };
                txtThanhTien.Text = Convert.ToString(layThongTin.Sum(c => c.TutolMoney));
                if (Convert.ToDouble(txtThanhTien.Text) <= 100000)
                {
                    txtTienTruDi.Text = "0";
                }
                else if (Convert.ToDouble(txtThanhTien.Text) > 100000 && Convert.ToDouble(txtThanhTien.Text) <= 200000)
                {
                    txtTienTruDi.Text = "4000";
                }
                else if (Convert.ToDouble(txtThanhTien.Text) > 200000 && Convert.ToDouble(txtThanhTien.Text) <= 400000)
                {
                    txtTienTruDi.Text = "8000";
                }
                else
                {
                    txtTienTruDi.Text = "10000";
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng");
            }
        }
        public QLBANHANGService(string ten, string mkhau)
        {
            InitializeComponent();
            this.tentk = ten;
            this.mk = mkhau;
        }

        private void dataGridViewHienThiSanPhamQLSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (txtTenKH.Text != "")
                {
                    int id = e.RowIndex;
                    DataGridViewRow select = dataGridViewHienThiSanPhamQLSP.Rows[id];
                    ChiTietSanPhamServices ct = new ChiTietSanPhamServices();
                    if (select.Cells[0].Value.ToString() != "")
                    {
                        MemoryStream memoryStream = new MemoryStream((byte[])select.Cells[0].Value);
                        System.Drawing.Image imgs = System.Drawing.Image.FromStream(memoryStream);
                        if (imgs != null)
                        {
                            ct.pc = imgs;
                        }
                    }
                    ct.masp = select.Cells[1].Value.ToString();
                    ct.tensp = select.Cells[2].Value.ToString();
                    ct.dongia = select.Cells[7].Value.ToString();
                    ct.soluongcon = select.Cells[6].Value.ToString();
                    ct.tenkh = txtTenKH.Text;
                    ct.ShowDialog();
                    LoadGioHang();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập tên khách hàng");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtTimKiemQLSP_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiemQLSP.Text != "")
            {
                List<SanPhamDTO> dsUser = BUSINESS.SanPhamBUS.FindAllProduct(txtTimKiemQLSP.Text);
                dataGridViewHienThiSanPhamQLSP.DataSource = dsUser;
                DataGridViewImageColumn pic = new DataGridViewImageColumn();
                pic = (DataGridViewImageColumn)dataGridViewHienThiSanPhamQLSP.Columns[0];
                pic.ImageLayout = DataGridViewImageCellLayout.Stretch;
            }
            else
            {
                LoadDataAllSP();
            }
        }

        private void txtTimKiemFastFood_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiemFastFood.Text != "")
            {
                List<SanPhamDTO> dsUser = BUSINESS.SanPhamBUS.FinđoAnNhanh(txtTimKiemFastFood.Text);
                dataFastFood.DataSource = dsUser;
                DataGridViewImageColumn pic = new DataGridViewImageColumn();
                pic = (DataGridViewImageColumn)dataFastFood.Columns[0];
                pic.ImageLayout = DataGridViewImageCellLayout.Stretch;
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
                DataGridViewImageColumn pic = new DataGridViewImageColumn();
                pic = (DataGridViewImageColumn)dataGVNuocGiaiKhat.Columns[0];
                pic.ImageLayout = DataGridViewImageCellLayout.Stretch;
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
                DataGridViewImageColumn pic = new DataGridViewImageColumn();
                pic = (DataGridViewImageColumn)dataGVFood.Columns[0];
                pic.ImageLayout = DataGridViewImageCellLayout.Stretch;
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
                DataGridViewImageColumn pic = new DataGridViewImageColumn();
                pic = (DataGridViewImageColumn)dataGVdoDungThietYeu.Columns[0];
                pic.ImageLayout = DataGridViewImageCellLayout.Stretch;
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
                dataGVKhac.DataSource = dsUser;
                DataGridViewImageColumn pic = new DataGridViewImageColumn();
                pic = (DataGridViewImageColumn)dataGVKhac.Columns[0];
                pic.ImageLayout = DataGridViewImageCellLayout.Stretch;
            }
            else
            {
                LoadDataSPKhac();
            }
        }

        private void btnHoanThanhDonHang_Click(object sender, EventArgs e)
        {
            try
            {
                string mahd = DateTime.Now.ToString("yyMMdd") + CreateMaHD(9);
                for (int i = 0; i < dataGridViewDanhSachDatHang.RowCount; i++)
                {
                    DataGridViewRow r = dataGridViewDanhSachDatHang.Rows[i];
                    BUSINESS.HoaDonBUS.ThemHoaDon(mahd, txtMaNhanSuQLBH.Text.Trim(), txtTenKH.Text, txtSDT.Text,
                        DateTime.Now, cbLoaiThanhToan.Text, cbTrangThai.Text, txtGhiChu.Text,
                        dataGridViewDanhSachDatHang.Rows[i].Cells[0].Value.ToString(),
                        Convert.ToInt32(dataGridViewDanhSachDatHang.Rows[i].Cells[2].Value.ToString()),
                        Convert.ToSingle(dataGridViewDanhSachDatHang.Rows[i].Cells[4].Value.ToString()));
                }

                //Sau khi tạo hóa đơn song xóa hóa đơn chờ
                var kiemtra = (from x in BUSINESS.HoaDonBUS.LoadHoaDonCho()
                               where x.Customer_Name == txtTenKH.Text
                               select x).FirstOrDefault();
                if (kiemtra != null)
                {
                    BUSINESS.HoaDonBUS.XoaHoaDonCho(txtTenKH.Text);
                }
                txtTenKH.Clear(); txtSDT.Clear(); txtThanhTien.Clear(); txtGhiChu.Clear(); txtTienKhachDua.Clear(); txtTienTruDi.Clear();
                if (MessageBox.Show("Bạn có muốn in hóa đơn này không ?", "Thông báo!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    XuaHoaDon xuat = new XuaHoaDon();
                    xuat.mahd = mahd;
                    xuat.ShowDialog();
                }
                LoadDataAllSP();
                LoadHoaDonCho();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa1_Click(object sender, EventArgs e)
        {
            if (dataGridViewDanhSachDatHang.RowCount != 0)
            {
                string masp = dataGridViewDanhSachDatHang.CurrentRow.Cells[0].Value.ToString();
                string soLuong = dataGridViewDanhSachDatHang.CurrentRow.Cells[2].Value.ToString();
                if (masp != "")
                {
                    if (MessageBox.Show("Bạn chắc chắn muốn hủy đơn này,số lượng sẽ được hoàn lại vào kho?", "N Shop Flower",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (BUSINESS.HoaDonBUS.XoaGioHang(masp, Convert.ToInt32(soLuong), txtTenKH.Text) == true)
                        {
                            LoadGioHang();
                            MessageBox.Show("Đã gỡ khỏi giỏ hàng");
                        }
                        else
                        {
                            MessageBox.Show("Gỡ không thành công khỏi giỏ hàng");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn hàng để hủy");
                }
            }
            else
            {
                MessageBox.Show("Hiện tại giỏ hàng không có gì");
            }
            
        }

        private void designButtonClass1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewDanhSachDatHang.RowCount != 0)
                {
                    if (MessageBox.Show("Bạn chắc chắn muốn xóa tất cả,số lượng sẽ được hoàn lại vào kho?", "N Shop Flower",
                               MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        for (int i = 0; i < dataGridViewDanhSachDatHang.RowCount; i++)
                        {
                            BUSINESS.HoaDonBUS.XoaGioHang(dataGridViewDanhSachDatHang.Rows[i].Cells[0].Value.ToString(), Convert.ToInt32(dataGridViewDanhSachDatHang.Rows[i].Cells[2].Value.ToString()), txtTenKH.Text);
                        }
                        LoadGioHang();
                        MessageBox.Show("Đã tất cả khỏi giỏ hàng");
                    }
                }
                else
                {
                    MessageBox.Show("Giỏ hàng hiện đang trống");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTenKH.Clear(); txtSDT.Clear(); txtThanhTien.Clear(); txtGhiChu.Clear(); txtTienKhachDua.Clear(); txtTienTruDi.Clear();
        }

        private void txtThanhTien_TextChanged(object sender, EventArgs e)
        {
            if (txtThanhTien.Text != "" && txtTenKH.Text != "" && txtThanhTien.Text != "0")
            {
                btnHoanThanhDonHang.BackColor = Color.LimeGreen;
                btnHoanThanhDonHang.Enabled = true;
            }
            else
            {
                btnHoanThanhDonHang.BackColor = Color.Red;
                btnHoanThanhDonHang.Enabled = false;
            }
        }

        private void txtTienKhachDua_TextChanged(object sender, EventArgs e)
        {
            if (txtTienKhachDua.Text != "")
            {
                if (!Regex.Match(txtTienKhachDua.Text, @"^\d+$").Success)
                {
                    MessageBox.Show("Tiền khách đưa không hợp lệ");
                }
                else
                {
                    txttienThuaTraKhach.Text = Convert.ToString(Convert.ToDouble(txtTienKhachDua.Text) - (Convert.ToDouble(txtThanhTien.Text) - Convert.ToDouble(txtTienTruDi.Text)));
                }
            }
        }

        #region Data Cell Click
        private void dataFastFood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (txtTenKH.Text != "")
            {
                int id = e.RowIndex;
                DataGridViewRow select = dataFastFood.Rows[id];
                ChiTietSanPhamServices ct = new ChiTietSanPhamServices();
                if (select.Cells[0].Value.ToString() != "")
                {
                    MemoryStream memoryStream = new MemoryStream((byte[])select.Cells[0].Value);
                    System.Drawing.Image imgs = System.Drawing.Image.FromStream(memoryStream);
                    if (imgs != null)
                    {
                        ct.pc = imgs;
                    }
                }
                ct.masp = select.Cells[1].Value.ToString();
                ct.tensp = select.Cells[2].Value.ToString();
                ct.dongia = select.Cells[7].Value.ToString();
                ct.soluongcon = select.Cells[6].Value.ToString(); ct.tenkh = txtTenKH.Text;
                ct.ShowDialog();
                LoadGioHang();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng");
            }
        }

        private void dataGVNuocGiaiKhat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (txtTenKH.Text != "")
            {
                int id = e.RowIndex;
                DataGridViewRow select = dataGVNuocGiaiKhat.Rows[id];
                ChiTietSanPhamServices ct = new ChiTietSanPhamServices();
                if (select.Cells[0].Value.ToString() != "")
                {
                    MemoryStream memoryStream = new MemoryStream((byte[])select.Cells[0].Value);
                    System.Drawing.Image imgs = System.Drawing.Image.FromStream(memoryStream);
                    if (imgs != null)
                    {
                        ct.pc = imgs;
                    }
                }
                ct.masp = select.Cells[1].Value.ToString();
                ct.tensp = select.Cells[2].Value.ToString();
                ct.dongia = select.Cells[7].Value.ToString();
                ct.soluongcon = select.Cells[6].Value.ToString(); ct.tenkh = txtTenKH.Text;
                ct.ShowDialog();
                LoadGioHang();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng");
            }
        }

        private void dataGVFood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (txtTenKH.Text != "")
            {
                int id = e.RowIndex;
                DataGridViewRow select = dataGVFood.Rows[id];
                ChiTietSanPhamServices ct = new ChiTietSanPhamServices();
                if (select.Cells[0].Value.ToString() != "")
                {
                    MemoryStream memoryStream = new MemoryStream((byte[])select.Cells[0].Value);
                    System.Drawing.Image imgs = System.Drawing.Image.FromStream(memoryStream);
                    if (imgs != null)
                    {
                        ct.pc = imgs;
                    }
                }
                ct.masp = select.Cells[1].Value.ToString();
                ct.tensp = select.Cells[2].Value.ToString();
                ct.dongia = select.Cells[7].Value.ToString();
                ct.soluongcon = select.Cells[6].Value.ToString(); ct.tenkh = txtTenKH.Text;
                ct.ShowDialog();
                LoadGioHang();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng");
            }
        }

        private void dataGVdoDungThietYeu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (txtTenKH.Text != "")
            {
                int id = e.RowIndex;
                DataGridViewRow select = dataGVdoDungThietYeu.Rows[id];
                ChiTietSanPhamServices ct = new ChiTietSanPhamServices();
                if (select.Cells[0].Value.ToString() != "")
                {
                    MemoryStream memoryStream = new MemoryStream((byte[])select.Cells[0].Value);
                    System.Drawing.Image imgs = System.Drawing.Image.FromStream(memoryStream);
                    if (imgs != null)
                    {
                        ct.pc = imgs;
                    }
                }
                ct.masp = select.Cells[1].Value.ToString();
                ct.tensp = select.Cells[2].Value.ToString();
                ct.dongia = select.Cells[7].Value.ToString();
                ct.soluongcon = select.Cells[6].Value.ToString(); ct.tenkh = txtTenKH.Text;
                ct.ShowDialog();
                LoadGioHang();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng");
            }
        }

        private void dataGVKhac_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (txtTenKH.Text != "")
            {
                int id = e.RowIndex;
                DataGridViewRow select = dataGVKhac.Rows[id];
                ChiTietSanPhamServices ct = new ChiTietSanPhamServices();
                if (select.Cells[0].Value.ToString() != "")
                {
                    MemoryStream memoryStream = new MemoryStream((byte[])select.Cells[0].Value);
                    System.Drawing.Image imgs = System.Drawing.Image.FromStream(memoryStream);
                    if (imgs != null)
                    {
                        ct.pc = imgs;
                    }
                }
                ct.masp = select.Cells[1].Value.ToString();
                ct.tensp = select.Cells[2].Value.ToString();
                ct.dongia = select.Cells[7].Value.ToString();
                ct.soluongcon = select.Cells[6].Value.ToString(); ct.tenkh = txtTenKH.Text;
                ct.ShowDialog();
                LoadGioHang();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng");
            }
        }
        #endregion
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
                txtMaGach.Clear();
            }
            else
            {
                MessageBox.Show("Camera hiện đang không bật");
            }
        }

        private void QLBANHANGService_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (video != null && video.IsRunning)
            {
                video.Stop();
            }
        }
        private void LoadHoaDonCho()
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            List<HoaDonChoDTO> dsUser = BUSINESS.HoaDonBUS.LoadHoaDonCho();
            for (int j = 0; j < dsUser.ToList().Count; j++)
            {
                DesignButtonClass bt = new DesignButtonClass();
                bt.BackColor = Color.LightGreen;
                bt.BorderRadius = 12;
                bt.BorderSize = 0;
                bt.Margin = new Padding(10, 0, 0, 0);
                bt.Size = new Size(260, 40);
                bt.Text = dsUser[j].Customer_Name;
                bt.Font = new System.Drawing.Font("Arial", 15, FontStyle.Regular);
                bt.TextImageRelation = TextImageRelation.ImageAboveText;
                flowLayoutPanel1.Controls.Add(bt);
                bt.Click += new System.EventHandler(this.btClick);
            }
        }
        void btClick(object sender, EventArgs e)
        {
            Button pc = (Button)sender;
            txtTenKH.Text = pc.Text;
            if (txtTenKH.Text != "")
            {
                List<GioHangDTO> dsUser = BUSINESS.HoaDonBUS.LoadGiohang();
                var laygioHang = from x in BUSINESS.HoaDonBUS.LoadGiohang() where x.Customer_Name == pc.Text select x;
                dataGridViewDanhSachDatHang.DataSource = laygioHang.ToList();
                var layThongTin = from x in BUSINESS.HoaDonBUS.LoadGiohang()
                                  where x.Customer_Name == pc.Text
                                  select new
                                  {
                                      TutolMoney = x.Quantily * x.Price
                                  };
                txtThanhTien.Text = Convert.ToString(layThongTin.Sum(c => c.TutolMoney));
                if (Convert.ToDouble(txtThanhTien.Text) <= 100000)
                {
                    txtTienTruDi.Text = "0";
                }
                else if (Convert.ToDouble(txtThanhTien.Text) > 100000 && Convert.ToDouble(txtThanhTien.Text) <= 200000)
                {
                    txtTienTruDi.Text = "4000";
                }
                else if (Convert.ToDouble(txtThanhTien.Text) > 200000 && Convert.ToDouble(txtThanhTien.Text) <= 400000)
                {
                    txtTienTruDi.Text = "8000";
                }
                else
                {
                    txtTienTruDi.Text = "10000";
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng");
            }
        }

        private void btnThemHoaDonCho_Click(object sender, EventArgs e)
        {
            HoaDonChoService ct = new HoaDonChoService();
            ct.manv = txtMaNhanSuQLBH.Text;
            ct.ShowDialog();
            LoadHoaDonCho();
        }

        private void designButtonClass2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTenKH.Text))
            {
                if (BUSINESS.HoaDonBUS.XoaHoaDonCho(txtTenKH.Text) == true)
                {
                    if (dataGridViewDanhSachDatHang.RowCount > 0)
                    {
                        for (int i = 0; i < dataGridViewDanhSachDatHang.RowCount; i++)
                        {
                            BUSINESS.HoaDonBUS.XoaGioHang(dataGridViewDanhSachDatHang.Rows[i].Cells[0].Value.ToString(), Convert.ToInt32(dataGridViewDanhSachDatHang.Rows[i].Cells[2].Value.ToString()), txtTenKH.Text);
                        }
                    }
                    MessageBox.Show("Đã xóa khỏi danh sách Hóa đơn chờ");
                    LoadHoaDonCho();
                    txtTenKH.Clear();
                }
                else
                {
                    MessageBox.Show("Xóa không thành công");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn Hóa đơn chờ để xóa");
            }
        }

        private void txtMaGach_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtMaGach.Text != "")
                {
                    if (txtTenKH.Text != "")
                    {
                        ChiTietSanPhamServices ct = new ChiTietSanPhamServices();
                        DB__4Entities db = new DB__4Entities();
                        var dsUser = (from x in db.SanPhams.ToList()
                                      where x.MaGach.Trim() == txtMaGach.Text.Trim()
                                      select x).FirstOrDefault();
                        if (dsUser != null)
                        {
                            if (dsUser.Images.ToString() != "")
                            {
                                MemoryStream memoryStream = new MemoryStream((byte[])dsUser.Images);
                                System.Drawing.Image imgs = System.Drawing.Image.FromStream(memoryStream);
                                if (imgs != null)
                                {
                                    ct.pc = imgs;
                                }
                            }
                            ct.masp = dsUser.MaSP.ToString();
                            ct.tensp = dsUser.TenSanPham.ToString();
                            ct.dongia = dsUser.GiaBan.ToString();
                            ct.soluongcon = dsUser.SoLuongCon.ToString(); ct.tenkh = txtTenKH.Text;
                            ct.ShowDialog();
                            LoadGioHang();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy sản phẩm đang quét");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui Lòng nhập tên khách hàng");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtTienKhachDua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Tiền khách đưa không hợp lệ");
                e.Handled = true;
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Số điện thoại không hợp lệ");
                e.Handled = true;
            }
        }

        private void txtTienTruDi_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbLoaiThanhToan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void QLBANHANGService_Load(object sender, EventArgs e)
        {
            cbTrangThai.SelectedIndex = 0;
            cbLoaiThanhToan.SelectedIndex = 0;
            dataGridViewHienThiSanPhamQLSP.EnableHeadersVisualStyles = false;
            dataGridViewHienThiSanPhamQLSP.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkTurquoise;
            dataGridViewDanhSachDatHang.EnableHeadersVisualStyles = false;
            dataGridViewDanhSachDatHang.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkTurquoise;
            dataFastFood.EnableHeadersVisualStyles = false;
            dataFastFood.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkTurquoise;
            dataGVdoDungThietYeu.EnableHeadersVisualStyles = false;
            dataGVdoDungThietYeu.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkTurquoise;
            dataGVFood.EnableHeadersVisualStyles = false;
            dataGVFood.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkTurquoise;
            dataGVKhac.EnableHeadersVisualStyles = false;
            dataGVKhac.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkTurquoise;
            dataGVNuocGiaiKhat.EnableHeadersVisualStyles = false;
            dataGVNuocGiaiKhat.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkTurquoise;
            LoadDataAllSP();
            LoadDataDoAnNhanh();
            LoadDataDoDungThietYeu();
            LoadDataNuocGiaiKhat();
            LoadDataThucPham();
            LoadDataSPKhac();
            LoadHoaDonCho();
            //Load Mã NV
            try
            {
                DB__4Entities du = new DB__4Entities();
                var maNS = from x in du.NhanViens
                           where x.TenTaiKhoan == tentk && x.MatKhau == mk
                           select new
                           {
                               x.MaNV
                           };
                txtMaNhanSuQLBH.Text = maNS.FirstOrDefault().ToString().Trim().Split('=')[1].Replace("}", "");
                var nv = (from x in du.NhanViens
                          where x.TenTaiKhoan == tentk && x.MatKhau == mk
                          select x).FirstOrDefault();
                MemoryStream memoryStream = new MemoryStream(nv.Images.ToArray());
                System.Drawing.Image imgs = System.Drawing.Image.FromStream(memoryStream);
                if (imgs != null)
                {
                    designPictureboxClass1.Image = imgs;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //Load WEBCAM
            fill = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in fill)
                cbWebCam.Items.Add(device.Name);
            cbWebCam.SelectedIndex = 0;
        }
    }
}
