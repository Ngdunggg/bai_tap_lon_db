using Do_An_Quan_ly_kho.Model;
using Microsoft.Azure.WebJobs.Host.Executors;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_An_Quan_ly_kho.Controller
{
    internal class PhieuBanController
    {

        private DatabaseDataContext db = new DatabaseDataContext();

        public FunctResult<List<dynamic>> GetAll()
        {
            FunctResult<List<dynamic>> rs = new FunctResult<List<dynamic>>();
            try
            {
                var phieuban = from pb in db.PhieuBanHangs 
                join kh in db.KhachHangs on pb.MaKhachHang equals kh.MaKhachHang
                join nd in db.NguoiDungs on pb.MaNguoiDung equals nd.MaNguoiDung
                select new
                {
                    MaPhieuBan = pb.MaPhieuBan,
                    NgayBan = pb.NgayBan,
                    MaNguoiDung = pb.MaNguoiDung,
                    MaKhachHang = pb.MaKhachHang,
                    TongTien = pb.TongTien,
                    TenKhachHang = kh.TenKhachHang,
                    TenNguoiDung = nd.HoTen
                }
                ;


                var resultList = phieuban.Cast<dynamic>().ToList();

                if (phieuban.Any())
                {
                    rs.Data = resultList;
                    rs.ErrCode = EnumErrCode.Success;
                    rs.ErrDesc = "Lấy dữ liệu thành công";
                }
                else
                {
                    rs.Data = null;
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.ErrDesc = "Không tìm thấy dữ liệu.";
                }
            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Có lỗi xảy ra trong qúa trình lấy dữ liệu tài khoản. Chi tiết lỗi: " + ex.Message;
                rs.Data = null;
            };


            return rs;
        }

        public FunctResult<List<dynamic>> GetDetail(int MaPhieuBan)
        {
            FunctResult<List<dynamic>> rs = new FunctResult<List<dynamic>>();
            try
            {
                var chitietphieuban = from ct in db.ChiTietPhieuBans 
                join sp in db.SanPhams on ct.MaSanPham equals sp.MaSanPham
                where ct.MaPhieuBan == MaPhieuBan
                select new 
                {
                    MaPhieuBan = ct.MaPhieuBan,
                    MaSanPham = ct.MaSanPham,
                    SoLuong = ct.SoLuong,
                    GiaBan = ct.GiaBan,
                    TenSanPham = sp.TenSanPham,
                    TongGia = ct.SoLuong * ct.GiaBan
                };
                var resultList = chitietphieuban.Cast<dynamic>().ToList();

                if (chitietphieuban.Any())
                {
                    rs.Data = resultList;
                    rs.ErrCode = EnumErrCode.Success;
                    rs.ErrDesc = "Lấy dữ liệu thành công";
                }
                else
                {
                    rs.Data = null;
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.ErrDesc = "Không tìm thấy dữ liệu.";
                }
            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Có lỗi xảy ra trong qúa trình lấy dữ liệu tài khoản. Chi tiết lỗi: " + ex.Message;
                rs.Data = null;
            };


            return rs;
        }

        public FunctResult<List<Tuple<int, string>>> GetSanPham()
        {
            FunctResult<List<Tuple<int, string>>> rs = new FunctResult<List<Tuple<int, string>>>();

            try
            {
                // Lấy danh sách mã sản phẩm và tên sản phẩm
                var sanPhams = db.SanPhams
                                 .Select(sp => new Tuple<int, string>(sp.MaSanPham, sp.TenSanPham)) // MaSanPham và TenHangHoa
                                 .ToList();

                if (sanPhams.Any())
                {
                    rs.Data = sanPhams;
                    rs.ErrCode = EnumErrCode.Success;
                    rs.ErrDesc = "Lấy dữ liệu thành công";
                }
                else
                {
                    rs.Data = null;
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.ErrDesc = "Không tìm thấy dữ liệu.";
                }
            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Có lỗi xảy ra trong quá trình lấy dữ liệu sản phẩm. Chi tiết lỗi: " + ex.Message;
                rs.Data = null;
            }

            return rs;
        }

        public FunctResult<List<int>> GetKhachHang()
        {
            FunctResult<List<int>> rs = new FunctResult<List<int>>();

            try
            {
                var maKhachHang = db.KhachHangs.Select(kh => kh.MaKhachHang).ToList();

                if (maKhachHang.Any())
                {
                    rs.Data = maKhachHang;
                    rs.ErrCode = EnumErrCode.Success;
                    rs.ErrDesc = "Lấy dữ liệu thành công";
                }
                else
                {
                    rs.Data = null;
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.ErrDesc = "Không tìm thấy dữ liệu.";
                }
            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Có lỗi xảy ra trong qúa trình lấy dữ liệu tài khoản. Chi tiết lỗi: " + ex.Message;
                rs.Data = null;
            };


            return rs;
        }
        public FunctResult<List<string>> GetNguoiDung()
        {
            FunctResult<List<string>> rs = new FunctResult<List<string>>();
            int userId = LoginController.userId;
            try
            {
                var maNguoiDung = db.NguoiDungs
                    .Where(nd => nd.MaNguoiDung == userId) 
                    .Select(nd => nd.HoTen)                       
                    .ToList();                            


                if (maNguoiDung.Any())
                {
                    rs.Data = maNguoiDung;
                    rs.ErrCode = EnumErrCode.Success;
                    rs.ErrDesc = "Lấy dữ liệu thành công";
                }
                else
                {
                    rs.Data = null;
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.ErrDesc = "Bạn chưa đăng nhập";
                }
            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Có lỗi xảy ra trong qúa trình lấy dữ liệu tài khoản. Chi tiết lỗi: " + ex.Message;
                rs.Data = null;
            };


            return rs;
        }

        public PhieuBanHang getNewest()
        {
            var maxPhieuBan = this.db.PhieuBanHangs
            .OrderByDescending(e => e.MaPhieuBan)
            .FirstOrDefault();

            return maxPhieuBan;

        }


        public FunctResult<List<PhieuBanHang>> CreatePhieuBan(string tenKh, string maNd, string date, string sdt, string address)
        {
            FunctResult<List<PhieuBanHang>> rs = new FunctResult<List<PhieuBanHang>>();
            decimal tongtien = 0;

            try
            {
                if (string.IsNullOrEmpty(tenKh) ||
                    string.IsNullOrEmpty(maNd) ||
                    string.IsNullOrEmpty(date) ||
                    string.IsNullOrEmpty(sdt) ||
                    string.IsNullOrEmpty(address))
                {
                    rs.ErrCode = EnumErrCode.InvalidInput;
                    rs.ErrDesc = "Vui lòng nhập đầy đủ các trường dữ liệu";
                    rs.Data = null;
                    return rs;
                }

                var newCustomer = new KhachHang
                {
                    TenKhachHang = tenKh,
                    SoDienThoai = sdt,
                    DiaChi = address
                };

                db.KhachHangs.InsertOnSubmit(newCustomer);

                db.SubmitChanges();

                int generatedCustomerId = newCustomer.MaKhachHang;


                var newInvoice = new PhieuBanHang
                {
                    MaNguoiDung = int.Parse(maNd),
                    MaKhachHang = generatedCustomerId,
                    NgayBan = DateTime.Parse(date),
                    TongTien = tongtien
                };

                db.PhieuBanHangs.InsertOnSubmit(newInvoice);
                db.SubmitChanges();

                // Trả về kết quả thành công
                rs.Data = new List<PhieuBanHang> { newInvoice };
                rs.ErrCode = EnumErrCode.Success;
                rs.ErrDesc = "Thêm phiếu bán thành công. Vui lòng chọn sản phẩm";
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Có lỗi xảy ra trong quá trình thêm mới phiếu bán. Chi tiết lỗi: " + ex.Message;
                rs.Data = null;
            }

            return rs;
        }



        public FunctResult<decimal?> GetGiaSp(int id)
        {
            FunctResult<decimal?> rs = new FunctResult<decimal?>();

            try
            {
                var giaSP = db.SanPhams.Where(sp => sp.MaSanPham == id).Select(sp => sp.Gia).FirstOrDefault();


                if (giaSP != null)
                {
                    rs.Data = giaSP;
                    rs.ErrCode = EnumErrCode.Success;
                    rs.ErrDesc = "Lấy dữ liệu thành công";
                }
                else
                {
                    rs.Data = null;
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.ErrDesc = "Không tìm thấy dữ liệu.";
                }
            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Có lỗi xảy ra trong qúa trình lấy dữ liệu tài khoản. Chi tiết lỗi: " + ex.Message;
                rs.Data = null;
            };


            return rs;
        }

        public FunctResult<int?> GetSoluong(int id)
        {
            FunctResult<int?> rs = new FunctResult<int?>();

            try
            {
                var soluongSp = db.SanPhams.Where(sp => sp.MaSanPham == id).Select(sp => sp.SoLuongTonKho.GetValueOrDefault()).FirstOrDefault();


                if (soluongSp != null)
                {
                    rs.Data = soluongSp;
                    rs.ErrCode = EnumErrCode.Success;
                    rs.ErrDesc = "Lấy dữ liệu thành công";
                }
                else
                {
                    rs.Data = null;
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.ErrDesc = "Không tìm thấy dữ liệu.";
                }
            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Có lỗi xảy ra trong qúa trình lấy dữ liệu tài khoản. Chi tiết lỗi: " + ex.Message;
                rs.Data = null;
            };


            return rs;
        }


        public FunctResult<List<ChiTietPhieuBan>> CreateChiTietPhieu(string maPhieuBan, string maSp, string soLuong, string giaBan)
        {
            FunctResult<List<ChiTietPhieuBan>> rs = new FunctResult<List<ChiTietPhieuBan>>();
            try
            {
                if (string.IsNullOrEmpty(maPhieuBan) ||
                    string.IsNullOrEmpty(maSp) ||
                    string.IsNullOrEmpty(soLuong) ||
                    string.IsNullOrEmpty(giaBan) )
                {
                    rs.ErrCode = EnumErrCode.InvalidInput;
                    rs.ErrDesc = "Vui lòng nhập đầy đủ các trường dữ liệu";
                    rs.Data = null;
                    return rs;
                }
                else
                {
                    var obj = new ChiTietPhieuBan
                    {
                        MaPhieuBan = int.Parse(maPhieuBan),
                        MaSanPham = int.Parse(maSp),
                        SoLuong = int.Parse(soLuong),
                        GiaBan = decimal.Parse(giaBan),

                    };

                    rs.Data = new List<ChiTietPhieuBan> { obj };
                    db.ChiTietPhieuBans.InsertOnSubmit(obj);
                    db.SubmitChanges();

                    rs.ErrCode = EnumErrCode.Success;
                    rs.ErrDesc = "Thêm chi tiết phiếu bán thành công thành công.";
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Có lỗi xảy ra trong quá trình thêm mới tài khoản. Chi tiết lỗi: " + ex.Message;
                rs.Data = null;
            }


            return rs;
        }



        public FunctResult<decimal?> GetTongTien(int maPhieuBan)
        {
            FunctResult<decimal?> rs = new FunctResult<decimal?>();

            try
            {
                var tongTien = db.ChiTietPhieuBans
                                 .Where(ct => ct.MaPhieuBan == maPhieuBan)
                                 .Select(ct => (decimal?)ct.SoLuong * ct.GiaBan) // Ép kiểu để tránh lỗi null
                                 .Sum();

                if (tongTien.HasValue && tongTien > 0)
                {
                    rs.Data = tongTien;
                    rs.ErrCode = EnumErrCode.Success;
                    rs.ErrDesc = "Lấy tổng tiền thành công";
                }
                else
                {
                    rs.Data = null;
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.ErrDesc = "Không tìm thấy dữ liệu.";
                }
            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Có lỗi xảy ra trong quá trình lấy tổng tiền. Chi tiết lỗi: " + ex.Message;
                rs.Data = null;
            }

            return rs;
        }



        public FunctResult<List<dynamic>> SearchByDateRange(DateTime fromDate, DateTime toDate)
        {
            FunctResult<List<dynamic>> rs = new FunctResult<List<dynamic>>();
            try
            {
                var phieuban = db.PhieuBanHangs
                    .Where(p => p.NgayBan >= fromDate && p.NgayBan <= toDate)
                    .Select(p => new
                    {
                        p.MaPhieuBan,
                        p.NgayBan,
                        p.MaKhachHang,
                        p.MaNguoiDung,
                        p.TongTien,
                        TenKhachHang = p.KhachHang.TenKhachHang,
                        TenNguoiDung = p.NguoiDung.HoTen,
                    }).ToList();
                var resultList = phieuban.Cast<dynamic>().ToList();
                if (phieuban.Any())
                {
                    rs.Data = resultList;
                    rs.ErrCode = EnumErrCode.Success;
                    rs.ErrDesc = "Tìm kiếm thành công.";
                }
                else
                {
                    rs.Data = null;
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.ErrDesc = "Không tìm thấy dữ liệu trong khoảng ngày này.";
                }
            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Có lỗi xảy ra trong quá trình tìm kiếm. Chi tiết: " + ex.Message;
                rs.Data = null;
            }
            return rs;
        }

        public FunctResult<PhieuBanHang> UpdatePhieuBan(int maPhieuBan, string maKh, string maNd, string date)
        {
            FunctResult<PhieuBanHang> rs = new FunctResult<PhieuBanHang>();

            try
            {
                // Kiểm tra đầu vào
                if (string.IsNullOrEmpty(maKh) ||
                    string.IsNullOrEmpty(maNd) ||
                    string.IsNullOrEmpty(date) ||
                    maPhieuBan <= 0)
                {
                    rs.ErrCode = EnumErrCode.InvalidInput;
                    rs.ErrDesc = "Vui lòng nhập đầy đủ các trường dữ liệu";
                    rs.Data = null;
                    return rs;
                }

                // Tìm phiếu bán hàng theo mã phiếu bán (MaPhieuBan)
                var phieuBan = db.PhieuBanHangs.FirstOrDefault(p => p.MaPhieuBan == maPhieuBan);

                if (phieuBan != null) // Nếu tìm thấy phiếu bán
                {
                    // Cập nhật thông tin của phiếu bán
                    phieuBan.MaKhachHang = int.Parse(maKh);
                    phieuBan.MaNguoiDung = int.Parse(maNd);
                    phieuBan.NgayBan = DateTime.Parse(date);
      

                    // Lưu các thay đổi vào cơ sở dữ liệu
                    db.SubmitChanges();

                    rs.Data = phieuBan;
                    rs.ErrCode = EnumErrCode.Success;
                    rs.ErrDesc = "Cập nhật phiếu bán thành công.";
                }
                else
                {
                    rs.Data = null;
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.ErrDesc = "Không tìm thấy phiếu bán cần cập nhật.";
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Có lỗi xảy ra trong quá trình cập nhật phiếu bán. Chi tiết lỗi: " + ex.Message;
                rs.Data = null;
            }

            return rs;
        }










    }
}