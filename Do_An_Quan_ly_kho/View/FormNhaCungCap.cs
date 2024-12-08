using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Do_An_Quan_ly_kho.Controller;
using Do_An_Quan_ly_kho.Model;

namespace Do_An_Quan_ly_kho
{
    public partial class FormNhaCungCap : Form
    {
        private DatabaseDataContext db = new DatabaseDataContext();

        private NhaCungCapController nccController = new NhaCungCapController();

        public FormNhaCungCap()
        {
            InitializeComponent();
        }

        private void FormNhaCungCap_Load(object sender, EventArgs e)
        {
            LoadData();

            dgvSupplier.ClearSelection();

            btnEdit.Enabled = false;
            btnDelete.Enabled = false;

            dgvSupplier.SelectionChanged += dgvSupplier_SelectionChanged;

            dgvSupplier.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvSupplier.ReadOnly = true;
        }
        private void dgvSupplier_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSupplier.SelectedRows.Count == 0)
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
            if (dgvSupplier.SelectedRows.Count > 0)
            {
                var row = dgvSupplier.SelectedRows[0]; // Dòng đang được chọn
                txtSupplierId.Text = row.Cells["MaNhaCungCap"].Value?.ToString();
                txtSupplierName.Text = row.Cells["TenNhaCungCap"].Value?.ToString();
                txtSupplierNumber.Text = row.Cells["SoDienThoai"].Value?.ToString();
                txtSupplierAddress.Text = row.Cells["DiaChi"].Value?.ToString();
            }
        }
        private void LoadData()
        {
            try
            {
                dgvSupplier.DataSource = nccController.GetSuppliers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearInput()
        {
            txtSupplierId.Clear();
            txtSupplierName.Clear();
            txtSupplierNumber.Clear();
            txtSupplierAddress.Clear();
            txtSearch.Clear();
            LoadData();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string tenNCC = txtSupplierName.Text;
                string soDienThoai = txtSupplierNumber.Text;
                string diaChi = txtSupplierAddress.Text;
                

                if (string.IsNullOrEmpty(tenNCC) || string.IsNullOrEmpty(soDienThoai) || string.IsNullOrEmpty(diaChi))
                {
                    MessageBox.Show("Vui lòng điền đủ các trường bắt buộc!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                nccController.AddSupplier(tenNCC, soDienThoai, diaChi);
                MessageBox.Show("Thêm nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInput();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nhà cung cấp: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSupplier.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn nhà cung cấp cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int maNCC = int.Parse(dgvSupplier.CurrentRow.Cells["MaNhaCungCap"].Value.ToString());
                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa nhà cung cấp này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    bool result = nccController.DeleteSupplier(maNCC);
                    if (result)
                    {
                        MessageBox.Show("Xóa nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhà cung cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa nhà cung cấp: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSupplier.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn nhà cung cấp cần sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int maNCC = int.Parse(dgvSupplier.CurrentRow.Cells["MaNhaCungCap"].Value.ToString());
                string tenNCC = txtSupplierName.Text;
                string soDienThoai = txtSupplierNumber.Text;
                string diaChi = txtSupplierAddress.Text;
                

                bool result = nccController.UpdateSupplier(maNCC, tenNCC, soDienThoai, diaChi);
                if (result)
                {
                    MessageBox.Show("Cập nhật nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInput();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhà cung cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật nhà cung cấp: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBoxId_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxId.Checked)
            {
                   
                checkBoxName.Checked = false; // Tắt checkbox tìm kiếm theo tên
                
            }
            
        }

        private void checkBoxName_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxName.Checked)
            {

                checkBoxId.Checked = false; // Tắt checkbox tìm kiếm theo Id
                
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtSearch.Text;

                if (string.IsNullOrEmpty(keyword))
                {
                    LoadData();
                    return;
                }

                if (checkBoxId.Checked)
                {
                    int maNCC = int.Parse(keyword);
                    dgvSupplier.DataSource = nccController.SearchSupplierById(maNCC);
                }
                else if (checkBoxName.Checked)
                {
                    dgvSupplier.DataSource = nccController.SearchSupplierByName(keyword);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn phương thức tìm kiếm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
    

