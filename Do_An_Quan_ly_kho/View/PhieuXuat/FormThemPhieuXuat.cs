using Do_An_Quan_ly_kho.Controller;
using Microsoft.Azure.WebJobs.Host;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Do_An_Quan_ly_kho
{
    public partial class FormThemPhieuXuat : Form
    {
        public FormThemPhieuXuat()
        {
            InitializeComponent();
        }

        PhieuBanController pb = new PhieuBanController();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string maPx = textMaphieuXuat.Text;
            string maSp = cbProduct.Text;
            string soLuong = txtCount.Text;
            string giaBan = textBoxGia.Text;
            string tongKho = textBoxSoluongKho.Text;

            int soluong = int.Parse(soLuong);
            int tongkho = int.Parse(tongKho);

            if(soluong <= tongkho)
            {
                var rs = pb.CreateChiTietPhieu(maPx, maSp, soLuong, giaBan);

                switch (rs.ErrCode)
                {
                    case Model.EnumErrCode.Error:
                        MessageBox.Show(rs.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case Model.EnumErrCode.Empty:
                        MessageBox.Show(rs.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case Model.EnumErrCode.Success:
                        MessageBox.Show(rs.ErrDesc, "Thông báo thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case Model.EnumErrCode.InvalidInput:
                        MessageBox.Show(rs.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("S luong trong kho khong du");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtCount_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormThemPhieuXuat_Load(object sender, EventArgs e)
        {
            btnAddChiTietPhieuBan.Enabled = false;
            btnEdit.Enabled = false;
            var rs = pb.GetSanPham();
            switch (rs.ErrCode)
            {
                case Model.EnumErrCode.Error:
                    MessageBox.Show(rs.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case Model.EnumErrCode.Empty:
                    MessageBox.Show(rs.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case Model.EnumErrCode.Success:
                    cbProduct.DataSource = rs.Data;
                    break;
            }
            var kh = pb.GetKhachHang();
            switch (kh.ErrCode)
            {
                case Model.EnumErrCode.Error:
                    MessageBox.Show(kh.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case Model.EnumErrCode.Empty:
                    MessageBox.Show(kh.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case Model.EnumErrCode.Success:
                    cbCustomerName.DataSource = kh.Data;
                    break;
            }

            var nd = pb.GetNguoiDung();
            switch (nd.ErrCode)
            {
                case Model.EnumErrCode.Error:
                    MessageBox.Show(nd.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case Model.EnumErrCode.Empty:
                    MessageBox.Show(nd.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case Model.EnumErrCode.Success:
                    cbTenNguoiLap.DataSource = nd.Data;
                    break;
            }



            var phieuban = pb.GetAll();
            switch (phieuban.ErrCode)
            {
                case Model.EnumErrCode.Error:
                    MessageBox.Show(phieuban.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case Model.EnumErrCode.Empty:
                    MessageBox.Show(phieuban.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case Model.EnumErrCode.Success:
                    dgvCateList.DataSource = phieuban.Data;
                    break;
            }

            dgvCateList.ClearSelection();


            //dtvPhieuBan.SelectionChanged += dtvPhieuBan_Select;

            dgvCateList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvCateList.ReadOnly = true;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddPhieuBan_Click(object sender, EventArgs e)
        {
            string maPhieuban = txtPx_id.Text;
            string makh = cbCustomerName.Text;
            string msnd = cbTenNguoiLap.Text;

            string date = cbDateTime.Text;

            var rs = pb.CreatePhieuBan( makh, msnd,date);

            switch (rs.ErrCode)
            {
                case Model.EnumErrCode.Error:
                    MessageBox.Show(rs.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case Model.EnumErrCode.Empty:
                    MessageBox.Show(rs.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case Model.EnumErrCode.Success:
                    MessageBox.Show(rs.ErrDesc, "Thông báo thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //dgvCateList.DataSource = rs.Data;
                    
                    break;
                case Model.EnumErrCode.InvalidInput:
                    MessageBox.Show(rs.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    break;
            }

        }

        private void dgvCateList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex  >= 0)
            {
                btnAddChiTietPhieuBan.Enabled = true;
                btnEdit.Enabled = true;
                var  Maphieuxuat = dgvCateList.Rows[e.RowIndex].Cells[0].Value;


                DataGridViewRow row = dgvCateList.Rows[e.RowIndex];
                txtPx_id.Text = row.Cells[0].Value?.ToString() ?? "";
                cbCustomerName.Text = row.Cells[3].Value?.ToString() ?? "";
                cbTenNguoiLap.Text = row.Cells[2].Value?.ToString() ?? "";
                cbDateTime.Text = row.Cells[1].Value?.ToString() ?? "";



                //txtPx_id.Text = dgvCateList.Rows[e.RowIndex].Cells[0].Value.ToString();
                //cbCustomerName.Text = dgvCateList.Rows[e.RowIndex].Cells[0].Value.ToString();
                textMaphieuXuat.Text = Maphieuxuat.ToString();


                int maPhieu = Convert.ToInt32(Maphieuxuat);
                var chiTietPhieu = pb.GetDetail(maPhieu);
                switch (chiTietPhieu.ErrCode)
                {
                    case Model.EnumErrCode.Error:
                        MessageBox.Show(chiTietPhieu.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case Model.EnumErrCode.Empty:
                        MessageBox.Show(chiTietPhieu.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvExport.DataSource = null;
                        break;
                    case Model.EnumErrCode.Success:
                        dgvExport.DataSource = chiTietPhieu.Data;
                        break;
                }
                dgvExport.ClearSelection();
                //btnEdit.Enabled = true;
                btnDelete.Enabled = true;

                //dtvPhieuBan.SelectionChanged += dtvPhieuBan_Select;

                dgvExport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dgvExport.ReadOnly = true;


                var Total = pb.GetTongTien(maPhieu);
                switch (Total.ErrCode)
                {
                    case Model.EnumErrCode.Error:
                        MessageBox.Show(Total.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case Model.EnumErrCode.Empty:
                        txtTotal.Text = null; 
                        break;
                    case Model.EnumErrCode.Success:
                        txtTotal.Text  = Total.Data.Value.ToString();
                        break;
                }

            }
        }

        private void cbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbProduct.SelectedIndex != -1)
            {
                var selectValue = cbProduct.SelectedItem;
                int selectvalue = Convert.ToInt32(selectValue);

                var rs = pb.GetGiaSp(selectvalue);

                switch (rs.ErrCode)
                {
                    case Model.EnumErrCode.Error:
                        MessageBox.Show(rs.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case Model.EnumErrCode.Empty:
                        MessageBox.Show(rs.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case Model.EnumErrCode.Success:
                        textBoxGia.Text = rs.Data.Value.ToString("F2");
                        break;
                }

                var rs1 = pb.GetSoluong(selectvalue);

                switch (rs1.ErrCode)
                {
                    case Model.EnumErrCode.Error:
                        MessageBox.Show(rs1.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case Model.EnumErrCode.Empty:
                        MessageBox.Show(rs1.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case Model.EnumErrCode.Success:
                        textBoxSoluongKho.Text = rs1.Data.Value.ToString();
                        break;
                }
            }
        }

        private void dgvCateList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtPx_id.Text);
            string maKh = cbCustomerName.Text;
            string maNd = cbTenNguoiLap.Text;
            string date = cbDateTime.Text;
            var rs = pb.UpdatePhieuBan(id, maKh, maNd, date);


            switch (rs.ErrCode)
            {
                case Model.EnumErrCode.Error:
                    MessageBox.Show(rs.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case Model.EnumErrCode.Empty:
                    MessageBox.Show(rs.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case Model.EnumErrCode.Success:
                    FormThemPhieuXuat_Load(rs, e);
                    break;
            }

        }
    }
}
