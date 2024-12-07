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
    public partial class frmLoaiHangHoa : Form
    {
        public DatabaseDataContext db = new DatabaseDataContext();
        public frmLoaiHangHoa()
        {
            InitializeComponent();
        }
        public void clearInput()
        {
            txtSearch.Text = "";
            txtTypeName.Text = "";
        }
        LoaiHangHoaController danhmuc = new LoaiHangHoaController();
        private void dgvType_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvType.SelectedRows.Count == 0)
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
            if (dgvType.SelectedRows.Count > 0)
            {
                var selectedRow = dgvType.SelectedRows[0];
                txtTypeName.Text = selectedRow.Cells["TenDanhMuc"].Value.ToString();
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string TenHangHoa = txtTypeName.Text.Trim();
            if (string.IsNullOrEmpty(TenHangHoa))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var rs = danhmuc.Create(TenHangHoa);
            switch (rs.ErrCode)
            {
                case EnumErrCode.Error:
                    MessageBox.Show(rs.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case EnumErrCode.InvalidInput:
                    MessageBox.Show(rs.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case EnumErrCode.Success:
                    MessageBox.Show(rs.ErrDesc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearInput();
                    frmLoaiHangHoa_Load(sender, e);
                    break;
            }
            clearInput();
        }

        private void frmLoaiHangHoa_Load(object sender, EventArgs e)
        {
            var rs = danhmuc.GetAll();
            switch (rs.ErrCode)
            {
                case EnumErrCode.Error:
                    MessageBox.Show(rs.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case EnumErrCode.Empty:
                    MessageBox.Show(rs.ErrDesc, "Không có dữ liệu để hiển thị.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case EnumErrCode.Success:
                    dgvType.AutoGenerateColumns = true;
                    dgvType.DataSource = rs.Data;

                    dgvType.Columns["MaDanhMuc"].HeaderText = "Mã danh mục";
                    dgvType.Columns["TenDanhMuc"].HeaderText = "Tên danh mục";

                    dgvType.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvType.RowTemplate.Height = 30;
                    dgvType.ReadOnly = true;
                    dgvType.ClearSelection();

                    dgvType.SelectionChanged += dgvType_SelectionChanged;

                    break;
            }

            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void dgvType_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvType.SelectedRows.Count > 0)
            {
                var selectRow = dgvType.SelectedRows[0];
                txtTypeName.Text = selectRow.Cells["TenDanhMuc"].Value.ToString();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string TenHangHoa = txtTypeName.Text.Trim();

            if (string.IsNullOrEmpty(TenHangHoa))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dgvType.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng để chỉnh sửa", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedRow = dgvType.SelectedRows[0];
            int id = (int)selectedRow.Cells["MaDanhMuc"].Value;
            var rs = danhmuc.Update(id, TenHangHoa);
            switch (rs.ErrCode)
            {
                case EnumErrCode.Error:
                    MessageBox.Show(rs.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case EnumErrCode.InvalidInput:
                    MessageBox.Show(rs.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case EnumErrCode.Success:
                    MessageBox.Show(rs.ErrDesc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmLoaiHangHoa_Load(sender, e);
                    clearInput();
                    break;
            }
            clearInput();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string TenHangHoa = txtTypeName.Text.Trim();
            if (string.IsNullOrEmpty(TenHangHoa))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dgvType.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var selectedRow = dgvType.SelectedRows[0];
            int id = (int)selectedRow.Cells["MaDanhMuc"].Value;
            var rs = danhmuc.Delete(id);
            if (rs != null)
            {
                switch (rs.ErrCode)
                {
                    case EnumErrCode.Error:
                        MessageBox.Show(rs.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case EnumErrCode.InvalidInput:
                        MessageBox.Show(rs.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case EnumErrCode.Success:
                        MessageBox.Show(rs.ErrDesc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmLoaiHangHoa_Load(sender, e);
                        clearInput();
                        break;
                }
            }
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            frmLoaiHangHoa_Load(sender, e);
            clearInput();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            object key;

            if (checkBoxId.Checked && int.TryParse(txtSearch.Text, out int intKey))
            {
                key = intKey;
            }
            else if (checkBoxName.Checked)
            {
                key = txtSearch.Text.Trim();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tiêu chí tìm kiếm và nhập thông tin hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var rs = danhmuc.Search(key, checkBoxName.Checked, checkBoxId.Checked);

            switch (rs.ErrCode)
            {
                case EnumErrCode.Error:
                    MessageBox.Show(rs.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case EnumErrCode.Empty:
                    MessageBox.Show(rs.ErrDesc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case EnumErrCode.Success:
                    dgvType.DataSource = rs.Data;
                    clearInput();
                    break;
            }
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
    }
}
