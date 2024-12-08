using Do_An_Quan_ly_kho.Controller;
using Do_An_Quan_ly_kho.View.PhieuNhap;
using Do_An_Quan_ly_kho.View.PhieuXuat;
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
            var selectedItem = (Tuple<int, string>)cbProduct.SelectedItem;            
            int maSp = selectedItem.Item1;  
            string soLuong = txtCount.Text;
            string giaBan = textBoxGia.Text;
            string tongKho = textBoxSoluongKho.Text;

            int soluong = int.Parse(soLuong);
            int tongkho = int.Parse(tongKho);

            if(soluong <= tongkho)
            {
                var rs = pb.CreateChiTietPhieu(maPx, maSp.ToString(), soLuong, giaBan);

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

                int maPhieu = Convert.ToInt32(textMaphieuXuat.Text);
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

                dgvExport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
                        txtTotal.Text = Total.Data.Value.ToString();
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
            btnAddChiTietPhieuBan.Enabled = true;
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

                    cbProduct.DisplayMember = "Item2";  
                    cbProduct.ValueMember = "Item1";    
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
                    break;
            }



        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddPhieuBan_Click(object sender, EventArgs e)
        {
            string makh = customerName.Text;
            string msnd = LoginController.userId.ToString();
            string sdt = customerPhone.Text;
            string address = customerAddress.Text;

            string date = cbDateTime.Text;

            var rs = pb.CreatePhieuBan( makh, msnd,date, sdt, address);

            var newPhieuBan = pb.getNewest();

            textMaphieuXuat.Text = newPhieuBan.MaPhieuBan.ToString();



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


        private void cbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbProduct.SelectedIndex != -1)
            {
/*                var selectValue = cbProduct.SelectedItem;
                int selectvalue = Convert.ToInt32(selectValue);*/
                var selectedItem = (Tuple<int, string>)cbProduct.SelectedItem;
                int selectvalue = selectedItem.Item1;  // Mã sản phẩm là Item1 trong Tuple


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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmPhieuXuat frm = new frmPhieuXuat();
            frm.ShowDialog();
            this.Close();
        }
    }
}
