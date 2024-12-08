using Do_An_Quan_ly_kho.Controller;
using Do_An_Quan_ly_kho.Model;
using System;
using System.Collections;
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
    public partial class FormHangHoa : Form
    {
        private DatabaseDataContext db = new DatabaseDataContext();
        public FormHangHoa()
        {
            InitializeComponent();
        }

        public void clearInput()
        {
            txtCategoryId.Clear();
            txtCategoryName.Clear();
            cbTypeOfCategory.SelectedIndex = cbTypeOfCategory.Items.Count > 0 ? 0 : -1;
            textBox4.Clear();
            textBox5.Clear();
        }
        HangHoaController sp = new HangHoaController();
        private void FormHangHoa_Load(object sender, EventArgs e)
        {
            var rs = sp.GetAll();
            switch (rs.ErrCode)
            {
                case Model.EnumErrCode.Error:
                    MessageBox.Show(rs.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case Model.EnumErrCode.Empty:
                    MessageBox.Show(rs.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case Model.EnumErrCode.Success:
                    dgvCategory.DataSource = rs.Data;
                    break;
            }

            dgvCategory.ClearSelection();

            btnEdit.Enabled = false;
            btnDelete.Enabled = false;

            dgvCategory.SelectionChanged += dgvCategory_SelectionChanged;

            dgvCategory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvCategory.ReadOnly = true;

            var categories = db.DanhMucSanPhams.ToList();
            //dgvCategory.Columns["DanhMucSanPham"].Visible = false;
            if (categories.Count > 0)
            {
                cbTypeOfCategory.DataSource = categories;
                cbTypeOfCategory.DisplayMember = "TenDanhMuc";
                cbTypeOfCategory.ValueMember = "MaDanhMuc";
                cbTypeOfCategory.Text = "- Chọn danh mục -";
            }
            else
            {
                MessageBox.Show("Không có danh mục sản phẩm nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbTypeOfCategory.DataSource = null;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string MaSP = txtCategoryId.Text.Trim();
            string TenSP = txtCategoryName.Text.Trim();
            string MaDM = cbTypeOfCategory.SelectedValue?.ToString();
            string SL = textBox4.Text.Trim();
            string Gia = textBox5.Text.Trim();

            var rs = sp.Update(MaSP, TenSP, MaDM, SL, Gia);

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
                    FormHangHoa_Load(rs, e);
                    break;
                case Model.EnumErrCode.InvalidInput:
                    MessageBox.Show(rs.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    break;
            }
            clearInput();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string MaSP = txtCategoryId.Text.Trim();
                string TenSP = txtCategoryName.Text.Trim();
                string MaDM = cbTypeOfCategory.SelectedValue?.ToString();
                string SL = textBox4.Text.Trim();
                string Gia = textBox5.Text.Trim();

                var rs = sp.Create(MaSP, TenSP, MaDM, SL, Gia);

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
                        FormHangHoa_Load(rs, e);
                        break;
                    case Model.EnumErrCode.InvalidInput:
                        MessageBox.Show(rs.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng số cho Số lượng và Giá.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                clearInput();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
               "Bạn có chắc chắn muốn xóa người dùng này?",
               "Xác nhận xóa",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);

            if (result == DialogResult.No) return;

            string MaSP = txtCategoryId.Text;

            var rs = sp.Delete(MaSP);

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
                    FormHangHoa_Load(rs, e);
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
            FormHangHoa_Load(sender, e);
            clearInput();
        }

        private void checkBoxId_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxId.Checked)
            {
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

            if (!theoMa && !theoTen)
            {
                MessageBox.Show("Vui lòng chọn tiêu chí tìm kiếm", "Thông báo lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var rs = sp.Search(key, theoMa, theoTen);

            switch (rs.ErrCode)
            {
                case Model.EnumErrCode.Success:
                    MessageBox.Show(rs.ErrDesc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvCategory.DataSource = rs.Data;
                    break;
                case Model.EnumErrCode.InvalidInput:
                    MessageBox.Show(rs.ErrDesc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvCategory.DataSource = rs.Data;
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

        private void dgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvCategory_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategory.SelectedRows.Count == 0)
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

        private void dgvCategory_Click(object sender, EventArgs e)
        {
            if (dgvCategory.SelectedRows.Count > 0)
            {
                var categories = db.DanhMucSanPhams.ToList();

                if (categories.Count > 0)
                {
                    cbTypeOfCategory.DataSource = categories;
                    cbTypeOfCategory.DisplayMember = "TenDanhMuc";
                    cbTypeOfCategory.ValueMember = "MaDanhMuc";
                }
                var selectRow = dgvCategory.SelectedRows[0];
                txtCategoryId.Text = selectRow.Cells[0].Value.ToString();
                txtCategoryName.Text = selectRow.Cells[1].Value.ToString();
                textBox4.Text = selectRow.Cells[3].Value?.ToString();
                textBox5.Text = selectRow.Cells[4].Value?.ToString();

                string MaSP = selectRow.Cells[2].Value.ToString();
                int id = int.Parse(MaSP);
                string name = db.DanhMucSanPhams.FirstOrDefault(x => x.MaDanhMuc == id)?.TenDanhMuc;
                cbTypeOfCategory.Text = name;
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Hide(); 

            frmMain frm = new frmMain();
            frm.ShowDialog(); 

            this.Close(); 
        }
    }
}
