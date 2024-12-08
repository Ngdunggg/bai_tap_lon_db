using Do_An_Quan_ly_kho.Model;
using Do_An_Quan_ly_kho.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Quan_ly_kho.Controller
{
    internal class PhieuNhapController
    {
        private DatabaseDataContext db = new DatabaseDataContext();
        public FunctResult<List<PhieuNhapHang>> GetAll()
        {
            FunctResult<List<PhieuNhapHang>> rs = new FunctResult<List<PhieuNhapHang>>();
            try
            {
                var phieuhang = db.PhieuNhapHangs.ToList();
                if (phieuhang.Any())
                {
                    rs.Data = phieuhang;
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
                rs.ErrDesc = "Có lỗi xảy ra trong qúa trình lấy dữ liệu phiếu nhập. Chi tiết lỗi: " + ex.Message;
                rs.Data = null;
            }
            return rs;
        }
        public FunctResult<List<ChiTietPhieuNhap>> GetChiTietByPhieuNhapID(int phieuNhapID)
        {
            FunctResult<List<ChiTietPhieuNhap>> rs = new FunctResult<List<ChiTietPhieuNhap>>();
            try
            {
                var chiTiet = db.ChiTietPhieuNhaps.Where(ct => ct.MaPhieuNhap == phieuNhapID).ToList();
                if (chiTiet.Any())
                {
                    rs.Data = chiTiet;
                    rs.ErrCode = EnumErrCode.Success;
                    rs.ErrDesc = "Lấy dữ liệu chi tiết thành công";
                }
                else
                {
                    rs.Data = null;
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.ErrDesc = "Không có dữ liệu chi tiết.";
                }
            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Lỗi khi lấy dữ liệu chi tiết. Chi tiết lỗi: " + ex.Message;
                rs.Data = null;
            }
            return rs;
        }
        public FunctResult<List<PhieuNhapHang>> SearchByDateRange(DateTime fromDate, DateTime toDate)
        {
            FunctResult<List<PhieuNhapHang>> rs = new FunctResult<List<PhieuNhapHang>>();
            try
            {
                var phieuhang = db.PhieuNhapHangs
                    .Where(p => p.NgayNhap >= fromDate && p.NgayNhap <= toDate)
                    .ToList();

                if (phieuhang.Any())
                {
                    rs.Data = phieuhang;
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
        
        public FunctResult<List<PhieuNhapHangViewModel>> GetAllPhieuNhap()
        {
            FunctResult<List<PhieuNhapHangViewModel>> rs = new FunctResult<List<PhieuNhapHangViewModel>>();
            try
            {
                var phieuNhapQuery = from phieu in db.PhieuNhapHangs
                                     join nhaCungCap in db.NhaCungCaps on phieu.MaNhaCungCap equals nhaCungCap.MaNhaCungCap
                                     join chiTiet in db.ChiTietPhieuNhaps on phieu.MaPhieuNhap equals chiTiet.MaPhieuNhap
                                     join sanPham in db.SanPhams on chiTiet.MaSanPham equals sanPham.MaSanPham
                                     select new PhieuNhapHangViewModel
                                     {
                                         MaPhieuNhap = phieu.MaPhieuNhap,
                                         NgayNhap = phieu.NgayNhap,
                                         MaNguoiDung = phieu.MaNguoiDung,
                                         TenNhaCungCap = nhaCungCap.TenNhaCungCap,
                                         SoDienThoaiNCC = nhaCungCap.SoDienThoai,
                                         DiaChiNCC = nhaCungCap.DiaChi,
                                         TenHangHoa = sanPham.TenSanPham,
                                         LoaiHangHoa = sanPham.MaDanhMuc,
                                         GiaHangHoa = sanPham.Gia,
                                         SoLuong = chiTiet.SoLuong,
                                         TongSoTien = (decimal)phieu.TongTien
                                     };

                var resultList = phieuNhapQuery.ToList();

                if (resultList.Any())
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
                rs.ErrDesc = "Có lỗi xảy ra trong quá trình lấy dữ liệu. Chi tiết lỗi: " + ex.Message;
                rs.Data = null;
            }
            return rs;
        }
        public FunctResult<bool> AddPhieuNhap(string tenNhaCungCap, string soDienThoai, string diaChi,
                                int loaiHangHoa, string tenHangHoa, decimal giaHangHoa, int soLuong, decimal giaNhap, DateTime ngayNhap,
                                int maNguoiDung)
        {
            FunctResult<bool> rs = new FunctResult<bool>();
            try
            {

                var nhaCungCap = db.NhaCungCaps.FirstOrDefault(ncc => ncc.TenNhaCungCap == tenNhaCungCap);
                if (nhaCungCap == null)
                {

                    nhaCungCap = new NhaCungCap
                    {
                        TenNhaCungCap = tenNhaCungCap,
                        SoDienThoai = soDienThoai,
                        DiaChi = diaChi
                    };
                    db.NhaCungCaps.InsertOnSubmit(nhaCungCap);
                    db.SubmitChanges(); 
                }


                var sanPham = db.SanPhams.FirstOrDefault(sp => sp.TenSanPham == tenHangHoa);
                if (sanPham == null)
                {
  
                    sanPham = new SanPham
                    {
                        TenSanPham = tenHangHoa,
                        MaDanhMuc = loaiHangHoa,
                        SoLuongTonKho = soLuong,    
                        Gia = giaHangHoa
                    };
                    db.SanPhams.InsertOnSubmit(sanPham);
                    db.SubmitChanges(); 
                }


                var phieuNhap = new PhieuNhapHang
                {
                    NgayNhap = ngayNhap,
                    MaNguoiDung = maNguoiDung,
                    MaNhaCungCap = nhaCungCap.MaNhaCungCap, 
                    TongTien = giaNhap * soLuong 
                };
                db.PhieuNhapHangs.InsertOnSubmit(phieuNhap);
                db.SubmitChanges(); 


                var chiTiet = new ChiTietPhieuNhap
                {
                    MaPhieuNhap = phieuNhap.MaPhieuNhap,
                    MaSanPham = sanPham.MaSanPham, 
                    SoLuong = soLuong,
                    GiaNhap = giaNhap 
                };
                db.ChiTietPhieuNhaps.InsertOnSubmit(chiTiet);
                db.SubmitChanges(); 

                rs.Data = true;
                rs.ErrCode = EnumErrCode.Success;
                rs.ErrDesc = "Thêm phiếu nhập thành công!";
            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Có lỗi xảy ra trong quá trình thêm phiếu nhập. Chi tiết lỗi: " + ex.Message;
                rs.Data = false;
            }
            return rs;
        }



        public FunctResult<List<NguoiDung>> GetAllNguoiDung()
        {
            FunctResult<List<NguoiDung>> result = new FunctResult<List<NguoiDung>>();

            try
            {
                var data = db.NguoiDungs.ToList();
                result.Data = data;
                result.ErrCode = EnumErrCode.Success;
            }
            catch (Exception ex)
            {
                result.ErrCode = EnumErrCode.Error;
                result.ErrDesc = "Lỗi khi lấy danh sách người dùng: " + ex.Message;
            }

            return result;
        }


        public FunctResult<List<DanhMucSanPham>> GetAllLoaiSanPham()
        {
            FunctResult<List<DanhMucSanPham>> result = new FunctResult<List<DanhMucSanPham>>();

            try
            {
                var data = db.DanhMucSanPhams.ToList();
                result.Data = data;
                result.ErrCode = EnumErrCode.Success;
            }
            catch (Exception ex)
            {
                result.ErrCode = EnumErrCode.Error;
                result.ErrDesc = "Lỗi khi lấy danh sách sản phẩm: " + ex.Message;
            }

            return result;
        }
        public FunctResult<List<NhaCungCap>> GetAllNhaCungCap()
        {
            FunctResult<List<NhaCungCap>> result = new FunctResult<List<NhaCungCap>>();

            try
            {
                var data = db.NhaCungCaps.ToList();
                result.Data = data;
                result.ErrCode = EnumErrCode.Success;
            }
            catch (Exception ex)
            {
                result.ErrCode = EnumErrCode.Error;
                result.ErrDesc = "Lỗi khi lấy danh sách sản phẩm: " + ex.Message;
            }

            return result;
        }
        public FunctResult<bool> UpdatePhieuNhap(int maPhieuNhap, string tenNhaCungCap, string soDienThoai, string diaChi,int loaiHangHoa, string tenHangHoa, decimal giaHangHoa, int soLuong,decimal tongTien, DateTime ngayNhap, int maNguoiDung)
        {
            FunctResult<bool> rs = new FunctResult<bool>();

            try
            {
                var phieuNhap = db.PhieuNhapHangs.FirstOrDefault(pn => pn.MaPhieuNhap == maPhieuNhap);
                if (phieuNhap == null)
                {
                    rs.ErrCode = EnumErrCode.Error;
                    rs.ErrDesc = "Không tìm thấy phiếu nhập cần sửa!";
                    rs.Data = false;
                    return rs;
                }

        
                var nhaCungCap = db.NhaCungCaps.FirstOrDefault(ncc => ncc.TenNhaCungCap == tenNhaCungCap);
                if (nhaCungCap == null)
                {
                    rs.ErrCode = EnumErrCode.Error;
                    rs.ErrDesc = "Nhà cung cấp không tồn tại!";
                    rs.Data = false;
                    return rs;
                }

               
                var sanPham = db.SanPhams.FirstOrDefault(sp => sp.MaSanPham == loaiHangHoa);
                if (sanPham == null)
                {
                    rs.ErrCode = EnumErrCode.Error;
                    rs.ErrDesc = "Sản phẩm không tồn tại!";
                    rs.Data = false;
                    return rs;
                }
                sanPham.TenSanPham = tenHangHoa;


                phieuNhap.TongTien = tongTien;
                phieuNhap.MaNguoiDung = maNguoiDung;
                phieuNhap.NgayNhap = ngayNhap;
                
               
                var chiTietPhieuNhap = db.ChiTietPhieuNhaps.FirstOrDefault(ct => ct.MaPhieuNhap == maPhieuNhap && ct.MaSanPham == loaiHangHoa);
                if (chiTietPhieuNhap != null)
                {
                    chiTietPhieuNhap.SoLuong = soLuong;
                    chiTietPhieuNhap.GiaNhap = giaHangHoa;
                    
                }
                else
                {
                    chiTietPhieuNhap = new ChiTietPhieuNhap
                    {
                        MaPhieuNhap = maPhieuNhap,
                        MaSanPham = loaiHangHoa,
                        SoLuong = soLuong,
                        GiaNhap = giaHangHoa
                    };
                    db.ChiTietPhieuNhaps.InsertOnSubmit(chiTietPhieuNhap);
                }

               
                nhaCungCap.SoDienThoai = soDienThoai;
                nhaCungCap.DiaChi = diaChi;

                db.SubmitChanges();

                rs.ErrCode = EnumErrCode.Success;
                rs.ErrDesc = "Cập nhật phiếu nhập thành công!";
                rs.Data = true;
            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Có lỗi xảy ra trong quá trình cập nhật: " + ex.Message;
                rs.Data = false;
            }

            return rs;
        }






    }

}
