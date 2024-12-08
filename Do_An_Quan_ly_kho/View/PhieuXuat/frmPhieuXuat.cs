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
using Do_An_Quan_ly_kho.View.PhieuXuat;

namespace Do_An_Quan_ly_kho.View.PhieuXuat
{
    public partial class frmPhieuXuat : Form
    {
        public frmPhieuXuat()
        {
            InitializeComponent();
        }

        PhieuBanController phieuBan = new PhieuBanController();
        private void frmPhieuXuat_Load(object sender, EventArgs e)
        {
            var pb = phieuBan.GetAll();

            switch (pb.ErrCode)
            {
                case Model.EnumErrCode.Error:
                    MessageBox.Show(pb.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case Model.EnumErrCode.Empty:
                    MessageBox.Show(pb.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case Model.EnumErrCode.Success:
                    dtvPhieuBan.DataSource = pb.Data;
                    break;
            }

            dtvPhieuBan.ClearSelection();
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;

            //dtvPhieuBan.SelectionChanged += dtvPhieuBan_Select;

            dtvPhieuBan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dtvPhieuBan.ReadOnly = true;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormThemPhieuXuat frm = new FormThemPhieuXuat();
            frm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FormSuaPhieuXuat frm = new FormSuaPhieuXuat();
            frm.ShowDialog();
        }

        private void dtvPhieuBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                var  maPhieuBan = dtvPhieuBan.Rows[e.RowIndex].Cells[0].Value;

                if (maPhieuBan != DBNull.Value)
                {
                    // Chuyển đổi giá trị nếu cần thiết (ví dụ như int)
                    int MaPhieuBan = Convert.ToInt32(maPhieuBan);
                    var pbdetail = phieuBan.GetDetail(MaPhieuBan);


                    switch (pbdetail.ErrCode)
                    {
                        case Model.EnumErrCode.Error:
                            MessageBox.Show(pbdetail.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case Model.EnumErrCode.Empty:
                            MessageBox.Show(pbdetail.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case Model.EnumErrCode.Success:
                            dtvChitiet.DataSource = pbdetail.Data;
                            break;
                    }
                    dtvChitiet.ClearSelection();
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;

                    //dtvPhieuBan.SelectionChanged += dtvPhieuBan_Select;

                    dtvChitiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    dtvChitiet.ReadOnly = true;
                    //MessageBox.Show("Mã phiếu bán: " + MaPhieuBan.ToString());
                }
            }
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

            var rs = phieuBan.SearchByDateRange(fromDate, toDate);

            switch (rs.ErrCode)
            {
                case Model.EnumErrCode.Error:
                    MessageBox.Show(rs.ErrDesc, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case Model.EnumErrCode.Empty:
                    MessageBox.Show(rs.ErrDesc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtvPhieuBan.DataSource = null;
                    break;
                case Model.EnumErrCode.Success:
                    dtvPhieuBan.DataSource = rs.Data;
                    break;
            }

            dtvPhieuBan.ClearSelection();
        }
    }
}
