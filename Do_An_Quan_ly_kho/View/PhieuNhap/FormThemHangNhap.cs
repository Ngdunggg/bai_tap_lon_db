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

namespace Do_An_Quan_ly_kho
{
    public partial class FormThemHangNhap : Form
    {
        public FormThemHangNhap()
        {
            InitializeComponent();
            
        }
        PhieuNhapController pn = new PhieuNhapController();
        private void LoadData()
        {
            var result = pn.GetAllPhieuNhap();

            if (result.ErrCode == EnumErrCode.Success)
            {
             
                dgvReceiptAdd.DataSource = result.Data;
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
        private void LoadLoaiSanPham()
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void FormThemHangNhapNhap_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadNhanVien();
            LoadLoaiSanPham();
           
            txt_Tongtien.ReadOnly = true;
            txt_Tongtien.Enabled = false;
            dgvReceiptAdd.AutoGenerateColumns = true;
            dgvReceiptAdd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReceiptAdd.RowTemplate.Height = 30;
            dgvReceiptAdd.ReadOnly = true;
        }

        private void cbProductor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtPn_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void text_Sdt_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            
            if (!int.TryParse(txtSoluong.Text, out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            if (!int.TryParse(text_giasp.Text, out int giaNhapInt) || giaNhapInt <= 0)
            {
                MessageBox.Show("Giá nhập không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

         
            decimal giaNhap = Convert.ToDecimal(giaNhapInt);

            string tenHangHoa = text_tenhanghoa.Text;
            string tenNhaCungCap = text_Tennhacungcap.Text;
            string soDienThoai = text_Sdt.Text;
            string diaChi = text_Diachi.Text;
            int loaiHangHoa = (int)cbSanpham.SelectedValue;
            DateTime ngayNhap = DateTime.Now;

            int maNguoiDung = (int)cbNhanvien.SelectedValue;

            
            var result = pn.AddPhieuNhap(tenNhaCungCap, soDienThoai, diaChi, loaiHangHoa, tenHangHoa, giaNhap, soLuong, giaNhap, ngayNhap, maNguoiDung);

            if (result.ErrCode == EnumErrCode.Success)
            {
                MessageBox.Show("Thêm phiếu nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show(result.ErrDesc, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txt_Tongtien_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void text_giasp_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu người dùng nhập giá hợp lệ (int)
            if (int.TryParse(text_giasp.Text, out int giaNhapInt) && giaNhapInt > 0)
            {
                // Kiểm tra số lượng có hợp lệ không
                if (int.TryParse(txtSoluong.Text, out int soLuong) && soLuong > 0)
                {
                    // Chuyển giá nhập từ int sang decimal
                    decimal giaNhap = Convert.ToDecimal(giaNhapInt);

                    // Tính tổng tiền
                    decimal tongTien = giaNhap * soLuong;

                    // Cập nhật tổng tiền
                    txt_Tongtien.Text = tongTien.ToString();
                }
                else
                {
                    txt_Tongtien.Text = "Số lượng không hợp lệ!";
                }
            }
            else
            {
                txt_Tongtien.Text = "Giá nhập không hợp lệ!";
            }
        }


        private void txtSoluong_TextChanged(object sender, EventArgs e)
        {
           
            if (int.TryParse(txtSoluong.Text, out int soLuong) && soLuong > 0)
            {
               
                if (int.TryParse(text_giasp.Text, out int giaNhapInt) && giaNhapInt > 0)
                {
                   
                    decimal giaNhap = Convert.ToDecimal(giaNhapInt);

                    
                    decimal tongTien = giaNhap * soLuong;

                   
                    txt_Tongtien.Text = tongTien.ToString();
                }
                else
                {
                    txt_Tongtien.Text = "Giá nhập không hợp lệ!";
                }
            }
            else
            {
                txt_Tongtien.Text = "Số lượng không hợp lệ!";
            }
        }

        private void dgvReceiptAdd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
