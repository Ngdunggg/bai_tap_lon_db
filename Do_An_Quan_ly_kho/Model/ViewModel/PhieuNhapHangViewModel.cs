using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Quan_ly_kho.Model.ViewModel
{
    internal class PhieuNhapHangViewModel
    {
        public int MaPhieuNhap { get; set; }
        public DateTime NgayNhap { get; set; }
        public int MaNguoiDung { get; set; }
        public string TenNhaCungCap { get; set; }
        public string SoDienThoaiNCC { get; set; }
        public string DiaChiNCC { get; set; }
        public string TenHangHoa { get; set; }
        public int LoaiHangHoa { get; set; }
        public int SoLuong { get; set; }
        public decimal GiaHangHoa { get; set; }
        public decimal TongSoTien { get; set; }
        
    }
}
