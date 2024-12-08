using Do_An_Quan_ly_kho.Controller;
using Do_An_Quan_ly_kho.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_An_Quan_ly_kho.View.PhieuNhap
{
    public partial class FormSuaPhieu : Form
    {
        public FormSuaPhieu()
        {
            InitializeComponent();
            dgvReceiptEdit.CellClick += dgvReceiptEdit_CellContentClick;
            this.Load += FormSuaPhieu_Load;
            
        }
        PhieuNhapController pn = new PhieuNhapController();
        private void LoadData()
        {
            var result = pn.GetAllPhieuNhap();

            if (result.ErrCode == EnumErrCode.Success)
            {

                dgvReceiptEdit.DataSource = result.Data;
            }
            else
            {
                MessageBox.Show(result.ErrDesc, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadNhanVien()
        {
            var result = pn.GetAllNguoiDung();

            if (result.ErrCode == EnumErrCode.Success)
            {
                cbNhanvien.DataSource = result.Data;
                cbNhanvien.DisplayMember = "HoTen";
                cbNhanvien.ValueMember = "MaNguoiDung";
            }
            else
            {
                MessageBox.Show(result.ErrDesc, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadSanPham()
        {
            var result = pn.GetAllLoaiSanPham();

            if (result.ErrCode == EnumErrCode.Success)
            {
                cbSanpham.DataSource = result.Data;
                cbSanpham.DisplayMember = "TenDanhMuc";
                cbSanpham.ValueMember = "MaDanhMuc";
            }
            else
            {
                MessageBox.Show(result.ErrDesc, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadNhaCungCap()
        {
            var result = pn.GetAllNhaCungCap();

            if (result.ErrCode == EnumErrCode.Success)
            {
                cbSanpham.DataSource = result.Data;
                cbSanpham.DisplayMember = "TenNhaCungCap";
                cbSanpham.ValueMember = "MaNhaCungCap";
            }
            else
            {
                MessageBox.Show(result.ErrDesc, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FormSuaPhieu_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadNhanVien();
            LoadSanPham();

            txt_Tongtien.ReadOnly = true;
            txt_Tongtien.Enabled = false;
            dgvReceiptEdit.AutoGenerateColumns = true;
            dgvReceiptEdit.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReceiptEdit.RowTemplate.Height = 30;
            text_MaPhieuNhap.Enabled = false;
            //dgvReceiptEdit.ReadOnly = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(text_Tennhacungcap.Text) ||
                string.IsNullOrWhiteSpace(text_Sdt.Text) ||
                string.IsNullOrWhiteSpace(text_Diachi.Text) ||
                cbSanpham.SelectedValue == null ||
                cbNhanvien.SelectedValue == null ||
                string.IsNullOrWhiteSpace(text_giasp.Text) ||
                string.IsNullOrWhiteSpace(txtSoluong.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtSoluong.Text, out int soLuong) || !decimal.TryParse(text_giasp.Text, out decimal giaNhap))
            {
                MessageBox.Show("Số lượng và giá phải là số hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenNhaCungCap = text_Tennhacungcap.Text;
            string soDienThoai = text_Sdt.Text;
            string diaChi = text_Diachi.Text;
            int loaiHangHoa = (int)cbSanpham.SelectedValue;
            string tenHangHoa = text_tenhanghoa.Text;
            DateTime ngayNhap = DateTime.Now;
            int maNguoiDung = (int)cbNhanvien.SelectedValue;
            decimal tongTien = giaNhap * soLuong;

            var result = pn.UpdatePhieuNhap(selectedMaPhieuNhap, tenNhaCungCap, soDienThoai, diaChi, loaiHangHoa, tenHangHoa, giaNhap, soLuong, tongTien, ngayNhap, maNguoiDung);

            if (result.ErrCode == EnumErrCode.Success)
            {
                MessageBox.Show("Cập nhật phiếu nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearInputs();
            }
            else
            {
                MessageBox.Show(result.ErrDesc, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void text_Tennhacungcap_TextChanged(object sender, EventArgs e)
        {

        }

        private void text_Sdt_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Tongtien_TextChanged(object sender, EventArgs e)
        {

        }

        private void text_giasp_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(text_giasp.Text, out decimal giaNhap) && int.TryParse(txtSoluong.Text, out int soLuong))
            {
                txt_Tongtien.Text = (giaNhap * soLuong).ToString();
            }

        }

        private void txtSoluong_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(text_giasp.Text, out decimal giaNhap) && int.TryParse(txtSoluong.Text, out int soLuong))
            {
                txt_Tongtien.Text = (giaNhap * soLuong).ToString();
            }

        }

        private void text_tenhanghoa_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbSanpham_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbNhanvien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private int selectedMaPhieuNhap; 

        private void dgvReceiptEdit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvReceiptEdit.Rows[e.RowIndex];

                selectedMaPhieuNhap = Convert.ToInt32(row.Cells["MaPhieuNhap"].Value);
                text_MaPhieuNhap.Text = Convert.ToString(row.Cells["MaPhieuNhap"].Value);
                text_Tennhacungcap.Text = row.Cells["TenNhaCungCap"].Value?.ToString();
                text_Sdt.Text = row.Cells["SoDienThoaiNCC"].Value?.ToString();
                text_Diachi.Text = row.Cells["DiaChiNCC"].Value?.ToString();
                cbSanpham.SelectedValue = row.Cells["LoaiHangHoa"].Value;
                cbNhanvien.SelectedValue = row.Cells["MaNguoiDung"].Value;
                text_tenhanghoa.Text = row.Cells["TenHangHoa"].Value?.ToString();
                text_giasp.Text = row.Cells["GiaHangHoa"].Value?.ToString();
                txtSoluong.Text = row.Cells["SoLuong"].Value?.ToString();
                txt_Tongtien.Text = row.Cells["TongSoTien"].Value?.ToString();
            }
        }
        private void ClearInputs()
        {

            text_MaPhieuNhap.Clear();
            text_Tennhacungcap.Clear();
            text_Sdt.Clear();
            text_Diachi.Clear();
            text_tenhanghoa.Clear();
            text_giasp.Clear();
            txtSoluong.Clear();
            txt_Tongtien.Clear();

            cbSanpham.SelectedIndex = -1; 
            cbNhanvien.SelectedIndex = -1; 
            selectedMaPhieuNhap = 0;
        }

        private void text_MaPhieuNhap_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmPhieuNhap frm = new frmPhieuNhap();
            frm.ShowDialog();

            this.Close();
        }
    }
}
