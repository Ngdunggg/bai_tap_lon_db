using Do_An_Quan_ly_kho.Model;
using Microsoft.Azure.WebJobs.Host.Executors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Quan_ly_kho.Controller
{
    internal class LoaiHangHoaController
    {
        private DatabaseDataContext db = new DatabaseDataContext();
        public FunctResult<List<DanhMucSanPham>> GetAll()
        {
            FunctResult<List<DanhMucSanPham>> rs = new FunctResult<List<DanhMucSanPham>>();
            try
            {
                var loaihanghoa = db.DanhMucSanPhams.ToList();
                if (loaihanghoa.Any())
                {
                    rs.Data = loaihanghoa;
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
                rs.ErrDesc = "Có lỗi xảy ra trong qúa trình lấy dữ liệu loại hàng hóa. Chi tiết lỗi: " + ex.Message;
                rs.Data = null;
            }
            return rs;
        }
        public FunctResult<DanhMucSanPham> Create(string TenLoaiHang)
        {
            FunctResult<DanhMucSanPham> rs = new FunctResult<DanhMucSanPham>();
            try
            {
                if(string.IsNullOrEmpty(TenLoaiHang))
                {
                    rs.ErrCode = EnumErrCode.InvalidInput;
                    rs.ErrDesc = "Vui lòng nhập đầy đủ các trường dữ liệu";
                    rs.Data = null;
                    return rs;
                }
                if (db.DanhMucSanPhams.FirstOrDefault(x => x.TenDanhMuc == TenLoaiHang) != null)
                {
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.ErrDesc = "Loại hàng hóa đã tồn tại vui lòng nhập lại ";
                    rs.Data = null;
                    return rs;
                }
                DanhMucSanPham loaihanghoa = new DanhMucSanPham();
                loaihanghoa.TenDanhMuc = TenLoaiHang;
                db.DanhMucSanPhams.InsertOnSubmit(loaihanghoa);
                db.SubmitChanges();
                rs.Data = loaihanghoa;
                rs.ErrCode = EnumErrCode.Success;
                rs.ErrDesc = "Thêm mới danh mục thành công.";
            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Có lỗi xảy ra trong quá trình thêm mới loại hàng hóa. Chi tiết lỗi: " + ex.Message;
                rs.Data = null;
            }
            return rs;
        }
        public FunctResult<bool> Update(int id, string tenDanhMuc)
        {
            FunctResult<bool> rs = new FunctResult<bool>();
            try
            {
                var danhMuc = db.DanhMucSanPhams.FirstOrDefault(x => x.MaDanhMuc == id);
                if (danhMuc == null)
                {
                    rs.ErrCode = EnumErrCode.InvalidInput;
                    rs.ErrDesc = "Không tìm thấy danh mục.";
                    return rs;
                }

                danhMuc.TenDanhMuc = tenDanhMuc;
                db.SubmitChanges();

                rs.ErrCode = EnumErrCode.Success;
                rs.ErrDesc = "Cập nhật danh mục thành công.";
                rs.Data = true;
            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Có lỗi xảy ra trong quá trình cập nhật. Chi tiết: " + ex.Message;
                rs.Data = false;
            }
            return rs;
        }
        public FunctResult<bool> Delete(int id)
        {
            FunctResult<bool> rs = new FunctResult<bool>();
            try
            {
                var danhMuc = db.DanhMucSanPhams.FirstOrDefault(x => x.MaDanhMuc == id);
                if (danhMuc == null)
                {
                    rs.ErrCode = EnumErrCode.InvalidInput;
                    rs.ErrDesc = "Không tìm thấy danh mục.";
                    return rs;
                }

                db.DanhMucSanPhams.DeleteOnSubmit(danhMuc);
                db.SubmitChanges();

                rs.ErrCode = EnumErrCode.Success;
                rs.ErrDesc = "Xóa danh mục thành công.";
                rs.Data = true;
            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Có lỗi xảy ra trong quá trình xóa. Chi tiết: " + ex.Message;
                rs.Data = false;
            }
            return rs;
        }

        public FunctResult<List<DanhMucSanPham>> Search(object key, bool checkBoxName, bool checkBoxId)
        {
            FunctResult<List<DanhMucSanPham>> rs = new FunctResult<List<DanhMucSanPham>>();
            try
            {
                List<DanhMucSanPham> loaihanghoa;

                if (checkBoxId && key is int intKey)
                {
                    loaihanghoa = db.DanhMucSanPhams
                        .Where(x => x.MaDanhMuc == intKey)
                        .ToList();
                }
                else if (checkBoxName && key is string strKey)
                {
                    loaihanghoa = db.DanhMucSanPhams
                        .Where(x => x.TenDanhMuc.Contains(strKey))
                        .ToList();
                }
                else
                {
                    rs.Data = null;
                    rs.ErrCode = EnumErrCode.InvalidInput;
                    rs.ErrDesc = "Tham số tìm kiếm không hợp lệ.";
                    return rs;
                }

                if (loaihanghoa.Any())
                {
                    rs.Data = loaihanghoa;
                    rs.ErrCode = EnumErrCode.Success;
                    rs.ErrDesc = "Tìm kiếm thành công";
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
                rs.ErrDesc = "Có lỗi xảy ra trong quá trình tìm kiếm loại hàng hóa. Chi tiết lỗi: " + ex.Message;
                rs.Data = null;
            }
            return rs;
        }

    }
}
