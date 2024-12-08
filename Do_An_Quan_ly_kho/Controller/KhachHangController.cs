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
    internal class KhachHangController
    {
        private DatabaseDataContext db = new DatabaseDataContext();

        public FunctResult<List<KhachHang>> GetAll()
        {
            FunctResult<List<KhachHang>> rs = new FunctResult<List<KhachHang>>();
            try
            {
                var khachHangs = db.KhachHangs.ToList();
                if (khachHangs.Any())
                {
                    rs.Data = khachHangs;
                    rs.ErrCode = EnumErrCode.Success;
                    rs.ErrDesc = "Lấy dữ liệu thành công.";
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
                rs.ErrDesc = "Có lỗi xảy ra trong quá trình lấy dữ liệu: " + ex.Message;
                rs.Data = null;
            }
            return rs;
        }

        public FunctResult<KhachHang> Create(string MaKH, string TenKH, string sdt, string diachi)
        {
            FunctResult<KhachHang> rs = new FunctResult<KhachHang>();
            try
            {
                
                if (string.IsNullOrEmpty(MaKH) || string.IsNullOrEmpty(TenKH))
                {
                    rs.ErrCode = EnumErrCode.InvalidInput;
                    rs.ErrDesc = "Vui lòng nhập đầy đủ thông tin: Mã và Tên khách hàng.";
                    rs.Data = null;
                    return rs;
                }

                
                if (!int.TryParse(MaKH, out int parsedMaKH))
                {
                    rs.ErrCode = EnumErrCode.InvalidInput;
                    rs.ErrDesc = "Mã khách hàng phải là một số nguyên.";
                    rs.Data = null;
                    return rs;
                }

                
                if (db.KhachHangs.FirstOrDefault(x => x.MaKhachHang == parsedMaKH) != null)
                {
                    rs.ErrCode = EnumErrCode.Error;
                    rs.ErrDesc = "Khách hàng với mã này đã tồn tại.";
                    rs.Data = null;
                    return rs;
                }

                
                var obj = new KhachHang
                {
                    MaKhachHang = parsedMaKH,
                    TenKhachHang = TenKH,
                    SoDienThoai = sdt,
                    DiaChi = diachi
                };

                db.KhachHangs.InsertOnSubmit(obj);
                db.SubmitChanges();

                rs.Data = obj;
                rs.ErrCode = EnumErrCode.Success;
                rs.ErrDesc = "Thêm mới khách hàng thành công.";
            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Có lỗi xảy ra trong quá trình thêm mới: " + ex.Message;
                rs.Data = null;
            }
            return rs;
        }

        public FunctResult<KhachHang> Update(string MaKH, string TenKH, string sdt, string diachi)
        {
            FunctResult<KhachHang> rs = new FunctResult<KhachHang>();
            try
            {
                if (string.IsNullOrEmpty(MaKH) || string.IsNullOrEmpty(TenKH))
                {
                    rs.ErrCode = EnumErrCode.InvalidInput;
                    rs.ErrDesc = "Vui lòng nhập đầy đủ thông tin: Mã và Tên khách hàng.";
                    rs.Data = null;
                    return rs;
                }

                
                if (!int.TryParse(MaKH, out int parsedMaKH))
                {
                    rs.ErrCode = EnumErrCode.InvalidInput;
                    rs.ErrDesc = "Mã khách hàng phải là một số nguyên.";
                    rs.Data = null;
                    return rs;
                }

                
                var khachHang = db.KhachHangs.FirstOrDefault(x => x.MaKhachHang == parsedMaKH);
                if (khachHang == null)
                {
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.ErrDesc = "Không tìm thấy khách hàng với mã đã cung cấp.";
                    rs.Data = null;
                    return rs;
                }

                
                khachHang.TenKhachHang = TenKH;
                khachHang.SoDienThoai = sdt;
                khachHang.DiaChi = diachi;

                db.SubmitChanges();

                rs.Data = khachHang;
                rs.ErrCode = EnumErrCode.Success;
                rs.ErrDesc = "Cập nhật thông tin thành công.";
            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Có lỗi xảy ra trong quá trình cập nhật: " + ex.Message;
                rs.Data = null;
            }
            return rs;
        }

        
        public FunctResult<bool> Delete(string MaKH)
        {
            FunctResult<bool> rs = new FunctResult<bool>();
            try
            {
                if (string.IsNullOrEmpty(MaKH))
                {
                    rs.ErrCode = EnumErrCode.InvalidInput;
                    rs.ErrDesc = "Vui lòng nhập mã khách hàng cần xóa.";
                    rs.Data = false;
                    return rs;
                }

                
                if (!int.TryParse(MaKH, out int parsedMaKH))
                {
                    rs.ErrCode = EnumErrCode.InvalidInput;
                    rs.ErrDesc = "Mã khách hàng phải là một số nguyên.";
                    rs.Data = false;
                    return rs;
                }

                var khachHang = db.KhachHangs.FirstOrDefault(x => x.MaKhachHang == parsedMaKH);
                if (khachHang == null)
                {
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.ErrDesc = "Không tìm thấy khách hàng với mã đã cung cấp.";
                    rs.Data = false;
                    return rs;
                }

                db.KhachHangs.DeleteOnSubmit(khachHang);
                db.SubmitChanges();

                rs.ErrCode = EnumErrCode.Success;
                rs.ErrDesc = "Xóa khách hàng thành công.";
                rs.Data = true;
            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Có lỗi xảy ra trong quá trình xóa: " + ex.Message;
                rs.Data = false;
            }
            return rs;
        }

        
        public FunctResult<List<KhachHang>> Search(string key, bool theoMa, bool theoTen)
        {
            FunctResult<List<KhachHang>> rs = new FunctResult<List<KhachHang>>();
            try
            {
                List<KhachHang> result;

                if (int.TryParse(key, out int parsedKey))
                {
                    
                    result = db.KhachHangs.Where(x => x.MaKhachHang == parsedKey).ToList();
                }
                else
                {
                    
                    result = db.KhachHangs.Where(x => x.TenKhachHang.Contains(key)).ToList();
                }

                if (result.Any())
                {
                    rs.Data = result;
                    rs.ErrCode = EnumErrCode.Success;
                    rs.ErrDesc = "Tìm kiếm thành công.";
                }
                else
                {
                    rs.Data = null;
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.ErrDesc = "Không tìm thấy kết quả.";
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
        
        
        public FunctResult<List<KhachHang>> GetSortedData(string sortBy, bool isAscending)
        {
            FunctResult<List<KhachHang>> rs = new FunctResult<List<KhachHang>>();
            try
            {
                
                if (sortBy != "MaKhachHang")
                {
                    rs.ErrCode = EnumErrCode.InvalidInput;
                    rs.ErrDesc = "Chỉ hỗ trợ sắp xếp theo Mã Khách Hàng.";
                    rs.Data = null;
                    return rs;
                }

                
                var data = isAscending
                    ? db.KhachHangs.OrderBy(x => x.MaKhachHang).ToList()
                    : db.KhachHangs.OrderByDescending(x => x.MaKhachHang).ToList();

                rs.Data = data;
                rs.ErrCode = EnumErrCode.Success;
                rs.ErrDesc = "Sắp xếp thành công.";
            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Có lỗi xảy ra trong quá trình sắp xếp: " + ex.Message;
                rs.Data = null;
            }
            return rs;
        }




    }
}
