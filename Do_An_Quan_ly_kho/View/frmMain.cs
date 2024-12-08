using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Do_An_Quan_ly_kho.Controller;
using Do_An_Quan_ly_kho.Model.DTOs;
using Do_An_Quan_ly_kho.View.PhieuNhap;
using Do_An_Quan_ly_kho.View.PhieuXuat;
using WinFormDemo;
namespace Do_An_Quan_ly_kho
{
    public partial class frmMain : Form
    {
        private DashboardController dashboardController = new DashboardController();
        public frmMain()
        {
            InitializeComponent();
            updateTotalUser();
            updateChart(selectYear.Text, cbb_select_type.Text);
        }

        public void updateTotalUser()
        {
            userTotal.Text = dashboardController.getTotalUsers().ToString();
            productIn.Text = dashboardController.getTotalProductIn().ToString();  
            productOut.Text = dashboardController.getTotalProductOut().ToString();
            totalVendor.Text = dashboardController.getTotalVendor().ToString();
            moneyOut.Text = dashboardController.getMoneyOut().ToString() + " VNĐ" ;
            moneyIn.Text = dashboardController.getMoneyIn().ToString() + " VNĐ";
            selectYear.Text = DateTime.Now.Year.ToString();

        }

        private void thôngTinHàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormHangHoa frm = new FormHangHoa();
            frm.Show();
            this.Close();
        }

        private void thôngTinNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormNhaCungCap frm = new FormNhaCungCap();
            frm.Show();
            this.Close();
        }

        private void thôngTinNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(LoginController.role == "admin")
            {
                this.Hide();
                FormNhanVien frm = new FormNhanVien();
                frm.Show();
                this.Close();
            } else
            {
                MessageBox.Show("Bạn không phải admin không có quyền truy cập");
            }
            
        }

        private void phiếuNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmPhieuNhap frm = new frmPhieuNhap();
            frm.Show();
            this.Close();
        }

        private void phiếuXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmPhieuXuat frm = new frmPhieuXuat();
            frm.Show();
            this.Close();
        }

        private void thôngTinKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormKhachHang frm = new FormKhachHang();
            frm.Show();
            this.Close();
        }

        private void thôngTinLoạiHàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLoaiHangHoa frm = new frmLoaiHangHoa();
            frm.Show();
            this.Close();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbb_năm_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbb_select_type_DropDown(object sender, EventArgs e)
        {
            cbb_select_type.Items.Clear();
            cbb_select_type.Items.Add("Khách Hàng");
            cbb_select_type.Items.Add("Số lượng hàng vào");
            cbb_select_type.Items.Add("Số lượng hàng ra");
            cbb_select_type.Items.Add("Tiền nhập hàng");
            cbb_select_type.Items.Add("Tiền xuất hàng");
            cbb_select_type.Items.Add("Nhà cung cấp");
        }

        private void cbb_select_type_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void updateChart(string year, string type)
        {
            foreach (var series in Bieudo.Series)
            {
                series.Points.Clear(); 
            }

            Bieudo.Titles.Clear();

            switch (type)
            {
                case "Nhà cung cấp":
                    {
                        Bieudo.Titles.Add(cbb_select_type.Text + "trong năm " + selectYear.Text);
                        int i = 0;
                        var ngon = dashboardController.SupplierCountByMonths(year);
                        foreach (var item in ngon)
                        {
                            Bieudo.Series["User"].Points.Add(item.SupplierCount);
                            Bieudo.Series["User"].Points[i].Label = item.SupplierCount.ToString();
                            Color gradientColor = Color.FromArgb((i * 40) % 256, (i * 80) % 256, (i * 120) % 256);
                            Bieudo.Series["User"].Points[i].Color = gradientColor;
                            Bieudo.Series["User"].Points[i].AxisLabel = "T" + item.Month;
                            i++;
                        }
                        break;
                    }

                case "Khách Hàng":
                    {
                        Bieudo.Titles.Add(cbb_select_type.Text + "trong năm " + selectYear.Text);
                        int i = 0;
                        var ngon = dashboardController.CustomerCountByMonths(year);
                        foreach (var item in ngon)
                        {
                            Bieudo.Series["User"].Points.Add(item.CustomerCount);
                            Bieudo.Series["User"].Points[i].Label = item.CustomerCount.ToString();
                            Color gradientColor = Color.FromArgb((i * 40) % 256, (i * 80) % 256, (i * 120) % 256);
                            Bieudo.Series["User"].Points[i].Color = gradientColor;
                            Bieudo.Series["User"].Points[i].AxisLabel = "T" + item.Month;
                            i++;
                        }
                        break;
                    }

                case "Số lượng hàng vào":
                    {
                        Bieudo.Titles.Add(cbb_select_type.Text + "trong năm " + selectYear.Text);
                        int i = 0;
                        var ngon = dashboardController.CountProductIns(year);
                        foreach (var item in ngon)
                        {
                            Bieudo.Series["User"].Points.Add(item.ProductCount);
                            Bieudo.Series["User"].Points[i].Label = item.ProductCount.ToString();
                            Color gradientColor = Color.FromArgb((i * 40) % 256, (i * 80) % 256, (i * 120) % 256);
                            Bieudo.Series["User"].Points[i].Color = gradientColor;
                            Bieudo.Series["User"].Points[i].AxisLabel = "T" + item.Month;
                            i++;
                        }
                        break;
                    }

                case "Số lượng hàng ra":
                    {
                        Bieudo.Titles.Add(cbb_select_type.Text + "trong năm " + selectYear.Text);
                        int i = 0;
                        var ngon = dashboardController.CountProductOuts(year);
                        foreach (var item in ngon)
                        {
                            Bieudo.Series["User"].Points.Add(item.ProductCount);
                            Bieudo.Series["User"].Points[i].Label = item.ProductCount.ToString();
                            Color gradientColor = Color.FromArgb((i * 40) % 256, (i * 80) % 256, (i * 120) % 256);
                            Bieudo.Series["User"].Points[i].Color = gradientColor;
                            Bieudo.Series["User"].Points[i].AxisLabel = "T" + item.Month;
                            i++;
                        }
                        break;
                    }

                case "Tiền xuất hàng":
                    {
                        Bieudo.Titles.Add(cbb_select_type.Text + "trong năm " + selectYear.Text);
                        int i = 0;
                        var ngon = dashboardController.getMoneyOutByMonth(year);
                        foreach (var item in ngon)
                        {
                            Bieudo.Series["User"].Points.Add((double)item.Money);
                            Bieudo.Series["User"].Points[i].Label = item.Money.ToString();
                            Color gradientColor = Color.FromArgb((i * 40) % 256, (i * 80) % 256, (i * 120) % 256);
                            Bieudo.Series["User"].Points[i].Color = gradientColor;
                            Bieudo.Series["User"].Points[i].AxisLabel = "T" + item.Month;
                            i++;
                        }
                        break;
                    }

                case "Tiền nhập hàng":
                    {
                        Bieudo.Titles.Add(cbb_select_type.Text + "trong năm " + selectYear.Text);
                        int i = 0;
                        var ngon = dashboardController.getMoneyOutByIn(year);
                        foreach (var item in ngon)
                        {
                            Bieudo.Series["User"].Points.Add((double)item.Money);
                            Bieudo.Series["User"].Points[i].Label = item.Money.ToString();
                            Color gradientColor = Color.FromArgb((i * 40) % 256, (i * 80) % 256, (i * 120) % 256);
                            Bieudo.Series["User"].Points[i].Color = gradientColor;
                            Bieudo.Series["User"].Points[i].AxisLabel = "T" + item.Month;
                            i++;
                        }
                        break;
                    }
                default:
                    MessageBox.Show("lựa chọn không phù hợp");
                    break;
            }
        }

        private void cbb_select_type_SelectedValueChanged(object sender, EventArgs e)
        {
            Bieudo.Titles.Clear();
            updateChart(selectYear.Text, cbb_select_type.Text);
/*            MessageBox.Show(sender + " " + e + " " + cbb_select_type.SelectedItem);*/
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void selectYear_SelectedValueChanged(object sender, EventArgs e)
        {
            updateChart(selectYear.Text, cbb_select_type.Text);
        }

        private void selectYear_DropDown(object sender, EventArgs e)
        {
            selectYear.Items.Clear();
            int startYear = 2000;
            int endYear = DateTime.Now.Year;

            for (int year = startYear; year <= endYear; year++)
            {
                selectYear.Items.Add(year);
            }

            selectYear.SelectedIndex = selectYear.Items.Count - 1;
        }

        private void totalUser_Click(object sender, EventArgs e)
        {

        }
    }
}
