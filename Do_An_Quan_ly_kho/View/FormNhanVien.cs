using Do_An_Quan_ly_kho.Controller;
using Do_An_Quan_ly_kho.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_An_Quan_ly_kho
{
    public partial class FormNhanVien : Form
    {
        private DatabaseDataContext db = new DatabaseDataContext();
        public FormNhanVien()
        {
            InitializeComponent();
        }
        
        public void clearInput()
        {
            txtUserId.Text = "";
            txtUsername.Text = "";
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            txtUserNumber.Text = "";
            txtAddress.Text = "";
            txtNote.Text = "";
        }
        NhanVienController nv = new NhanVienController();
        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            
            var rs = nv.GetAll();
            switch (rs.ErrCode)
            {
                case Model.EnumErrCode.Error:
                    MessageBox.Show(rs.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case Model.EnumErrCode.Empty:
                    MessageBox.Show(rs.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case Model.EnumErrCode.Success:
                    dgvUser.DataSource = rs.Data;
                    break;
            }

            dgvUser.ClearSelection();

            btnEdit.Enabled = false;
            btnDelete.Enabled = false;

            dgvUser.SelectionChanged += dgvUser_SelectionChanged;

            dgvUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvUser.ReadOnly = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string MaNV = txtUserId.Text;
            string TenNV = txtUsername.Text;
            string tk = txtTaiKhoan.Text;   
            string mk = txtMatKhau.Text;
            string sdt = txtUserNumber.Text;
            string diachi = txtAddress.Text;
            string ghichu = txtNote.Text;

            var rs = nv.Create(MaNV, TenNV, tk, mk, sdt, diachi, ghichu);

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
                    FormNhanVien_Load(rs, e);
                    break;
                case Model.EnumErrCode.InvalidInput:
                    MessageBox.Show(rs.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    break;
            }
            clearInput();
        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvUser_Click(object sender, EventArgs e)
        {
             if (dgvUser.SelectedRows.Count > 0)
            {
                var selectRow = dgvUser.SelectedRows[0];
                txtUserId.Text = selectRow.Cells[0].Value.ToString();
                txtTaiKhoan.Text = selectRow.Cells[1].Value.ToString();
                txtMatKhau.Text = selectRow.Cells[2].Value.ToString();
                txtUserNumber.Text = selectRow.Cells[3].Value?.ToString();
                txtAddress.Text = selectRow.Cells[4].Value?.ToString();
                txtUsername.Text = selectRow.Cells[5].Value.ToString();
                txtNote.Text = selectRow.Cells[6].Value?.ToString();
            }    
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string MaNV = txtUserId.Text;
            string TenNV = txtUsername.Text;
            string tk = txtTaiKhoan.Text;
            string mk = txtMatKhau.Text;
            string sdt = txtUserNumber.Text;
            string diachi = txtAddress.Text;
            string ghichu = txtNote.Text;

            var rs = nv.Update(MaNV, TenNV, tk, mk, sdt, diachi, ghichu);

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
                    FormNhanVien_Load(rs, e);
                    break;
                case Model.EnumErrCode.InvalidInput:
                    MessageBox.Show(rs.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    break;
            }
            clearInput();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
               "Bạn có chắc chắn muốn xóa người dùng này?",
               "Xác nhận xóa",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);

            if (result == DialogResult.No) return;

            string MaNV = txtUserId.Text;

            var rs = nv.Delete(MaNV);

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
                    FormNhanVien_Load(rs, e);
                    break;
                case Model.EnumErrCode.InvalidInput:
                    MessageBox.Show(rs.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    break;
            }
            clearInput();
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            FormNhanVien_Load(sender, e);
            clearInput();
        }

        private void checkBoxId_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxId.Checked) {
                checkBoxName.Checked = false;
            }
        }

        private void checkBoxName_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxName.Checked)
            {
                checkBoxId.Checked = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string key = txtSearch.Text;
            bool theoMa = checkBoxId.Checked;
            bool theoTen = checkBoxName.Checked;

            if (!theoMa && !theoTen) {
                MessageBox.Show("Vui lòng chọn tiêu chí tìm kiếm", "Thông báo lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var rs = nv.Search(key, theoMa, theoTen);

            switch (rs.ErrCode)
            {
                case Model.EnumErrCode.Success:
                    MessageBox.Show(rs.ErrDesc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvUser.DataSource = rs.Data;
                    break;
                case Model.EnumErrCode.InvalidInput:
                    MessageBox.Show(rs.ErrDesc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvUser.DataSource = rs.Data;
                    break;
                case Model.EnumErrCode.Empty:
                    MessageBox.Show(rs.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case Model.EnumErrCode.Error:
                    MessageBox.Show(rs.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            txtSearch.Text = "";
        }

        private void dgvUser_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUser.SelectedRows.Count == 0) {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUserId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
