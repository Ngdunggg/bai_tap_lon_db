using Do_An_Quan_ly_kho.Controller;
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
    public partial class frmPhieuNhap : Form
    {
        public frmPhieuNhap()
        {
            InitializeComponent();
            dgvReceiptInfor.CellClick += dgvReceiptInfor_CellContentClick;
            this.Load += FormPhieuNhap;
        }
        PhieuNhapController pn = new PhieuNhapController();
        public void FormPhieuNhap(object sender, EventArgs e)
        {
            var rs = pn.GetAll();
            switch (rs.ErrCode)
            {
                case Model.EnumErrCode.Error:
                    MessageBox.Show(rs.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case Model.EnumErrCode.Empty:
                    MessageBox.Show(rs.ErrDesc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case Model.EnumErrCode.Success:
                    dgvReceiptInfor.DataSource = rs.Data;
                    break;
            }

            dgvReceiptInfor.ClearSelection();

            //dgvReceiptInfor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvReceiptInfor.AutoGenerateColumns = true;
            dgvReceiptInfor.DataSource = rs.Data;

            dgvReceiptInfor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReceiptInfor.RowTemplate.Height = 30;
            dgvReceiptInfor.ReadOnly = true;
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printPhieuNhap phieuNhap = new printPhieuNhap();
            phieuNhap.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormThemHangNhap frm = new FormThemHangNhap();
            frm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FormSuaPhieu frm = new FormSuaPhieu();
            frm.ShowDialog();
        }

        private void dgvReceiptInfor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                int phieuNhapID = (int)dgvReceiptInfor.Rows[e.RowIndex].Cells["MaPhieuNhap"].Value; 
                LoadChiTietPhieuNhap(phieuNhapID);
            }


        }
        private void LoadChiTietPhieuNhap(int phieuNhapID)
        {
            var rs = pn.GetChiTietByPhieuNhapID(phieuNhapID);
            switch (rs.ErrCode)
            {
                case Model.EnumErrCode.Error:
                    MessageBox.Show(rs.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case Model.EnumErrCode.Empty:
                    dgvReceiptInSite.DataSource = null; 
                    break;
                case Model.EnumErrCode.Success:
                    dgvReceiptInSite.DataSource = rs.Data;
                    break;
            }

            dgvReceiptInSite.ClearSelection();

            btnEdit.Enabled = false;

            //dgvReceiptInfor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvReceiptInSite.AutoGenerateColumns = true;
            dgvReceiptInSite.DataSource = rs.Data;

            dgvReceiptInSite.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReceiptInSite.RowTemplate.Height = 30;
            dgvReceiptInSite.ReadOnly = true;
        }


        private void dgvReceiptInSite_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dateTimePicker2.Value.Date; 
            DateTime toDate = dateTimePicker1.Value.Date;   

            if (fromDate > toDate) 
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var rs = pn.SearchByDateRange(fromDate, toDate); 
            switch (rs.ErrCode)
            {
                case Model.EnumErrCode.Error:
                    MessageBox.Show(rs.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case Model.EnumErrCode.Empty:
                    MessageBox.Show(rs.ErrDesc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvReceiptInfor.DataSource = null; 
                    break;
                case Model.EnumErrCode.Success:
                    dgvReceiptInfor.DataSource = rs.Data; 
                    break;
            }

            dgvReceiptInfor.ClearSelection();

        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            FormPhieuNhap(sender, e);

            btnEdit.Enabled = true;

            dgvReceiptInSite.DataSource = null;
        }
    }
}
