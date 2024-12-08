using Do_An_Quan_ly_kho.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Quan_ly_kho.Controller
{
    internal class HangHoaController
    {
        DatabaseDataContext db = new DatabaseDataContext();
        public FunctResult<List<SanPham>> GetAll()
        {
            FunctResult<List<SanPham>> rs = new FunctResult<List<SanPham>>();
            try
            {
                var sp = db.SanPhams.ToList();
                if (sp.Any())
                {
                    rs.Data = sp;
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
                rs.ErrDesc = "Có lỗi xảy ra trong qúa trình lấy dữ liệu hàng hóa. Chi tiết lỗi: " + ex.Message;
                rs.Data = null;
            }
            return rs;
        }
        public FunctResult<SanPham> Create(string MaSP, string TenSP, string MaDM, string SL, string Gia)
        {
            FunctResult<SanPham> rs = new FunctResult<SanPham>();
            try
            {
                if (string.IsNullOrEmpty(MaSP) ||
                    string.IsNullOrEmpty(TenSP) ||
                    string.IsNullOrEmpty(MaDM) ||
                    string.IsNullOrEmpty(Gia))
                {
                    rs.ErrCode = EnumErrCode.InvalidInput;
                    rs.ErrDesc = "Vui lòng nhập đầy đủ các trường dữ liệu";
                    rs.Data = null;
                    return rs;
                }
                if (db.SanPhams.FirstOrDefault(x => x.TenSanPham == TenSP ||
                                                x.MaSanPham == int.Parse(MaSP)) != null)
                {
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.ErrDesc = "Mặt hàng này đã tồn tại vui lòng nhập lại ";
                    rs.Data = null;
                    return rs;
                }
                else
                {
                    var obj = new SanPham
                    {
                        MaSanPham = int.Parse(MaSP),
                        TenSanPham = TenSP,
                        MaDanhMuc = int.Parse(MaDM),
                        SoLuongTonKho = int.Parse(SL),
                        Gia = decimal.Parse(Gia)
                    };


                    db.SanPhams.InsertOnSubmit(obj);
                    db.SubmitChanges();

                    rs.Data = obj;
                    rs.ErrCode = EnumErrCode.Success;
                    rs.ErrDesc = "Thêm mới mặt hàng thành công.";
                }
            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Có lỗi xảy ra trong quá trình thêm mới mặt hàng. Chi tiết lỗi: " + ex.Message;
                rs.Data = null;
            }

            return rs;
        }
        public FunctResult<SanPham> Update(string MaSP, string TenSP, string MaDM, string SL, string Gia)
        {
            FunctResult<SanPham> rs = new FunctResult<SanPham>();
            try
            {
                if (string.IsNullOrEmpty(MaSP) ||
                    string.IsNullOrEmpty(TenSP) ||
                    string.IsNullOrEmpty(MaDM) ||
                    string.IsNullOrEmpty(Gia))
                {
                    rs.ErrCode = EnumErrCode.InvalidInput;
                    rs.ErrDesc = "Vui lòng nhập đầy đủ các trường dữ liệu";
                    rs.Data = null;
                    return rs;
                }

                var sanpham = db.SanPhams.FirstOrDefault(x => x.MaSanPham == int.Parse(MaSP));
                if (sanpham == null)
                {
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.ErrDesc = "Không tìm thấy mặt hàng với mã đã cung cấp.";
                    return rs;
                }

                sanpham.TenSanPham = TenSP;
                sanpham.MaDanhMuc = int.Parse(MaDM);
                sanpham.SoLuongTonKho = int.Parse(SL);
                sanpham.Gia = decimal.Parse(Gia);

                db.SubmitChanges();

                rs.Data = sanpham;
                rs.ErrCode = EnumErrCode.Success;
                rs.ErrDesc = "Cập nhật thông tin mặt hàng thành công";
            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Có lỗi xảy ra trong quá trình cập nhật mặt hàng. Chi tiết lỗi: " + ex.Message;
                rs.Data = null;
            }
            return rs;
        }
        public FunctResult<bool> Delete(string MaSP)
        {
            FunctResult<bool> rs = new FunctResult<bool>();
            try
            {
                if (string.IsNullOrEmpty(MaSP))
                {
                    rs.ErrCode = EnumErrCode.InvalidInput;
                    rs.ErrDesc = "Vui lòng nhập mã mặt hàng cần xóa.";
                    rs.Data = false;
                    return rs;
                }

                var sanPham = db.SanPhams.FirstOrDefault(x => x.MaSanPham == int.Parse(MaSP));

                if (sanPham == null)
                {
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.ErrDesc = "Không tìm thấy mặt hàng với mã đã cung cấp.";
                    rs.Data = false;
                    return rs;
                }

                db.SanPhams.DeleteOnSubmit(sanPham);
                db.SubmitChanges();

                rs.ErrCode = EnumErrCode.Success;
                rs.ErrDesc = "Xóa mặt hàng thành công.";
                rs.Data = true;
            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Có lỗi xảy ra trong quá trình xóa mặt hàng. Chi tiết lỗi: " + ex.Message;
                rs.Data = false;
            }
            return rs;
        }
        public FunctResult<List<SanPham>> Search(string key, bool theoMa, bool theoTen)
        {
            FunctResult<List<SanPham>> rs = new FunctResult<List<SanPham>>();

            try
            {
                if (string.IsNullOrEmpty(key))
                {
                    rs.Data = db.SanPhams.ToList();
                    rs.ErrCode = EnumErrCode.InvalidInput;
                    rs.ErrDesc = "Lấy toàn bộ dữ liệu";
                    return rs;
                }
                List<SanPham> result = new List<SanPham>();

                if (theoMa)
                {
                    result = db.SanPhams
                        .Where(x => x.MaSanPham.ToString().Contains(key))
                        .ToList();

                }
                else if (theoTen)
                {
                    result = db.SanPhams
                        .Where(x => x.TenSanPham.ToString().Contains(key))
                        .ToList();
                }

                if (result.Any())
                {
                    rs.Data = result;
                    rs.ErrCode = EnumErrCode.Success;
                    rs.ErrDesc = "Tìm kiếm kết quả thành công";
                }
                else
                {
                    rs.Data = null;
                    rs.ErrCode = EnumErrCode.Error;
                    rs.ErrDesc = "Không tìm thấy kết quả";
                }
            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Có lỗi xảy ra trong quá trình tìm kiếm: " + ex.Message;
                rs.Data = null;
            }
            return rs;
        }
    }
}
