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
    public partial class FormKhachHang : Form
    {
        private DatabaseDataContext db = new DatabaseDataContext();
        public FormKhachHang()
        {
            InitializeComponent();

        }
        public void clearInput()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            
        }
        KhachHangController khController = new KhachHangController();
        private void FormKhachHang_Load(object sender, EventArgs e)
        {



            // Cấu hình ComboBox cột sắp xếp
            cbSortBy.Items.Add("MaKhachHang");
            cbSortBy.SelectedIndex = 0;
            cbSortBy.Enabled = false; // Khóa ComboBox để ngăn người dùng thay đổi

            // Load dữ liệu ban đầu
            LoadKhachHangData();

            // Đảm bảo chỉ một CheckBox được chọn lúc khởi tạo
            chkAscending.Checked = true;
            chkDescending.Checked = false;




        }

        private void LoadKhachHangData()
        {
            var rs = khController.GetAll();
            switch (rs.ErrCode)
            {
                case Model.EnumErrCode.Success:
                    dgvKhachHang.DataSource = rs.Data;
                    break;
                case Model.EnumErrCode.Empty:
                    MessageBox.Show(rs.ErrDesc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvKhachHang.DataSource = null;
                    break;
                case Model.EnumErrCode.Error:
                    MessageBox.Show(rs.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvKhachHang.DataSource = null;
                    break;
            }
        }


        private void btAdd_Click(object sender, EventArgs e)
        {
            string MaKH = txtMaKH.Text;
            string TenKH = txtTenKH.Text;
            string SDT = txtSDT.Text;
            string DiaChi = txtDiaChi.Text;

            var rs = khController.Create(MaKH, TenKH, SDT, DiaChi);

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
                    FormKhachHang_Load(sender, e); // Load lại dữ liệu
                    break;
                case Model.EnumErrCode.InvalidInput:
                    MessageBox.Show(rs.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            clearInput();

        }
        private void dgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvKhachHang_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count > 0)
            {
                var selectRow = dgvKhachHang.SelectedRows[0];
                txtMaKH.Text = selectRow.Cells[0].Value.ToString();
                txtTenKH.Text = selectRow.Cells[1].Value.ToString();
                txtSDT.Text = selectRow.Cells[2].Value?.ToString();
                txtDiaChi.Text = selectRow.Cells[3].Value?.ToString();
            }
        }

        private void txtSearchById_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearchByName_TextChanged(object sender, EventArgs e)
        {

        }
        private void dgvKhachHang_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count == 0)
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string MaKH = txtMaKH.Text;
            string TenKH = txtTenKH.Text;
            string SDT = txtSDT.Text;
            string DiaChi = txtDiaChi.Text;

            var rs = khController.Update(MaKH, TenKH, SDT, DiaChi);

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
                    FormKhachHang_Load(sender, e); // Load lại dữ liệu
                    break;
                case Model.EnumErrCode.InvalidInput:
                    MessageBox.Show(rs.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            clearInput();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa khách hàng này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No) return;

            string MaKH = txtMaKH.Text;

            var rs = khController.Delete(MaKH);

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
                    FormKhachHang_Load(sender, e); // Load lại dữ liệu
                    break;
                case Model.EnumErrCode.InvalidInput:
                    MessageBox.Show(rs.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            clearInput();
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            FormKhachHang_Load(sender, e);
            clearInput();
        }

        private void checkBoxName_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxName.Checked)
            {
                checkBoxId.Checked = false;
            }
        }

        private void checkBoxId_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxId.Checked)
            {
                checkBoxName.Checked = false;
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string key = txtSearch.Text;
            bool theoMa = checkBoxId.Checked;
            bool theoTen = checkBoxName.Checked;

            if (!theoMa && !theoTen)
            {
                MessageBox.Show("Vui lòng chọn tiêu chí tìm kiếm", "Thông báo lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var rs = khController.Search(key, theoMa, theoTen);

            switch (rs.ErrCode)
            {
                case Model.EnumErrCode.Success:
                    MessageBox.Show(rs.ErrDesc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvKhachHang.DataSource = rs.Data;
                    break;
                case Model.EnumErrCode.InvalidInput:
                    MessageBox.Show(rs.ErrDesc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvKhachHang.DataSource = rs.Data;
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

        private void btnSort_Click(object sender, EventArgs e)
        {
            // Xác định thứ tự sắp xếp dựa trên CheckBox
            bool isAscending = chkAscending.Checked;

            // Gọi Controller để lấy dữ liệu sắp xếp theo MaKhachHang
            var rs = khController.GetSortedData("MaKhachHang", isAscending);
            switch (rs.ErrCode)
            {
                case Model.EnumErrCode.Success:
                    dgvKhachHang.DataSource = rs.Data;
                    MessageBox.Show("Dữ liệu đã được sắp xếp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case Model.EnumErrCode.InvalidInput:
                    MessageBox.Show(rs.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case Model.EnumErrCode.Error:
                    MessageBox.Show(rs.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void cbSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chkAscending_CheckedChanged(object sender, EventArgs e)
        {
            // Nếu chọn "Tăng dần", bỏ chọn "Giảm dần"
            if (chkAscending.Checked)
                chkDescending.Checked = false;
        }

        private void chkDescending_CheckedChanged(object sender, EventArgs e)
        {
            // Nếu chọn "Giảm dần", bỏ chọn "Tăng dần"
            if (chkDescending.Checked)
                chkAscending.Checked = false;
        }
    }
}
