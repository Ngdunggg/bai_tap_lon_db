using Do_An_Quan_ly_kho.Model;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_An_Quan_ly_kho.Controller
{
    internal class NhanVienController
    {
        private DatabaseDataContext db = new DatabaseDataContext();
        public FunctResult<List<NguoiDung>> GetAll()
        {
            FunctResult<List<NguoiDung>> rs = new FunctResult<List<NguoiDung>>();
            try
            {
                var nv = db.NguoiDungs.ToList();
                if (nv.Any()) {
                    rs.Data = nv;
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
            catch (Exception ex) {
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Có lỗi xảy ra trong qúa trình lấy dữ liệu tài khoản. Chi tiết lỗi: " + ex.Message;
                rs.Data = null;
            }
            return rs;
        }
        public FunctResult<NguoiDung> Create(string MaNV, string TenNV, string tk, string mk, string sdt, string diachi, string ghichu)
        {
            FunctResult<NguoiDung> rs = new FunctResult<NguoiDung>();
            try
            {
                if (string.IsNullOrEmpty(MaNV) ||
                    string.IsNullOrEmpty(TenNV) ||
                    string.IsNullOrEmpty(tk) ||
                    string.IsNullOrEmpty(mk))
                {
                    rs.ErrCode = EnumErrCode.InvalidInput;
                    rs.ErrDesc = "Vui lòng nhập đầy đủ các trường dữ liệu";
                    rs.Data = null;
                    return rs;
                }
                if (db.NguoiDungs.FirstOrDefault(x => x.TenDangNhap == tk ||
                                                x.MaNguoiDung == int.Parse(MaNV)) != null)
                {
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.ErrDesc = "Thông tin tài khoản đã tồn tại vui lòng nhập lại ";
                    rs.Data = null;
                    return rs;
                }
                else
                {
                    var obj = new NguoiDung
                    {
                        MaNguoiDung = int.Parse(MaNV),
                        TenDangNhap = tk,
                        MatKhau = mk,
                        HoTen = TenNV,
                        DiaChi = diachi,
                        SoDienThoai = sdt,
                        MoTa = ghichu
                    };


                    db.NguoiDungs.InsertOnSubmit(obj);
                    db.SubmitChanges();

                    rs.Data = obj;
                    rs.ErrCode = EnumErrCode.Success;
                    rs.ErrDesc = "Thêm mới tài khoản thành công.";
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Có lỗi xảy ra trong quá trình thêm mới tài khoản. Chi tiết lỗi: " + ex.Message;
                rs.Data = null;
            }

            return rs; // Trả về kết quả
        }
        public FunctResult<NguoiDung> Update(string MaNV, string TenNV, string tk, string mk, string sdt, string diachi, string ghichu)
        {
            FunctResult<NguoiDung> rs = new FunctResult<NguoiDung>();
            try
            {
                if (string.IsNullOrEmpty(MaNV) ||
                    string.IsNullOrEmpty(TenNV) ||
                    string.IsNullOrEmpty(tk) ||
                    string.IsNullOrEmpty(mk))
                {
                    rs.ErrCode = EnumErrCode.InvalidInput;
                    rs.ErrDesc = "Vui lòng nhập đầy đủ các trường dữ liệu";
                    rs.Data = null;
                    return rs;
                }
                var u = db.NguoiDungs.FirstOrDefault(x => x.MaNguoiDung == int.Parse(MaNV));
                if (u == null)
                {
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.ErrDesc = "Không tìm thấy tài khoản với mã đã cung cấp.";
                    return rs;
                }

                u.TenDangNhap = tk;
                u.HoTen = TenNV;
                u.MatKhau = mk;
                u.SoDienThoai = sdt;
                u.DiaChi = diachi;
                u.MoTa = ghichu;

                db.SubmitChanges();

                rs.Data = u;
                rs.ErrCode = EnumErrCode.Success;
                rs.ErrDesc = "Cập nhật thông tin tài khoản thành công";
            }
            catch(Exception ex)
            {
                // Xử lý ngoại lệ
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Có lỗi xảy ra trong quá trình cập nhật tài khoản. Chi tiết lỗi: " + ex.Message;
                rs.Data = null;
            }
            return rs;
        } 
        public FunctResult<bool> Delete(string MaNV)
        {
            FunctResult<bool> rs = new FunctResult<bool>();
            try
            {
                if (string.IsNullOrEmpty(MaNV))
                {
                    rs.ErrCode = EnumErrCode.InvalidInput;
                    rs.ErrDesc = "Vui lòng nhập mã người dùng cần xóa.";
                    rs.Data = false;
                    return rs;
                }

                var nguoiDung = db.NguoiDungs.FirstOrDefault(x => x.MaNguoiDung == int.Parse(MaNV));
                
                if (nguoiDung == null)
                {
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.ErrDesc = "Không tìm thấy tài khoản với mã đã cung cấp.";
                    rs.Data = false;
                    return rs;
                }

                db.NguoiDungs.DeleteOnSubmit(nguoiDung);
                db.SubmitChanges();

                rs.ErrCode = EnumErrCode.Success;
                rs.ErrDesc = "Xóa người dùng thành công.";
                rs.Data = true;
            }
            catch (Exception ex) 
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Có lỗi xảy ra trong quá trình xóa tài khoản. Chi tiết lỗi: " + ex.Message;
                rs.Data = false;
            }
            return rs;
        }
        public FunctResult<List<NguoiDung>> Search(string key, bool theoMa, bool theoTen)
        {
            FunctResult<List<NguoiDung>> rs = new FunctResult<List<NguoiDung>>();

            try
            {
                if (string.IsNullOrEmpty(key))
                {
                    rs.Data = db.NguoiDungs.ToList();
                    rs.ErrCode = EnumErrCode.InvalidInput;
                    rs.ErrDesc = "Lấy toàn bộ dữ liệu";
                    return rs;
                }
                List<NguoiDung> result = new List<NguoiDung>();

                if (theoMa)
                {
                    result = db.NguoiDungs
                        .Where(x => x.MaNguoiDung.ToString().Contains(key))
                        .ToList();

                }else if (theoTen)
                {
                    result = db.NguoiDungs
                        .Where(x => x.HoTen.ToString().Contains(key))
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
            }catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Có lỗi xảy ra trong quá trình tìm kiếm: " + ex.Message;
                rs.Data = null;
            }
            return rs;
        }
    }
}
