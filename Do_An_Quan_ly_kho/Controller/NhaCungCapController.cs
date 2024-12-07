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
    internal class NhaCungCapController
    {
        private DatabaseDataContext db = new DatabaseDataContext();

        public object GetSuppliers()
        {
            try
            {
                return db.NhaCungCaps.Select(ncc => new
                {
                    ncc.MaNhaCungCap,
                    ncc.TenNhaCungCap,
                    ncc.SoDienThoai,
                    ncc.DiaChi,
                    
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tải danh sách nhà cung cấp: " + ex.Message);
            }
        }

        public void AddSupplier(string tenNCC, string soDienThoai, string diaChi)
        {
            try
            {
                var ncc = new NhaCungCap
                {
                    TenNhaCungCap = tenNCC,
                    SoDienThoai = soDienThoai,
                    DiaChi = diaChi
                    
                };

                db.NhaCungCaps.InsertOnSubmit(ncc);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm nhà cung cấp: " + ex.Message);
            }
        }

        public bool UpdateSupplier(int maNCC, string tenNCC, string soDienThoai, string diaChi)
        {
            try
            {
                var ncc = db.NhaCungCaps.SingleOrDefault(x => x.MaNhaCungCap == maNCC);
                if (ncc == null) return false;

                ncc.TenNhaCungCap = string.IsNullOrEmpty(tenNCC) ? ncc.TenNhaCungCap : tenNCC;
                ncc.SoDienThoai = string.IsNullOrEmpty(soDienThoai) ? ncc.SoDienThoai : soDienThoai;
                ncc.DiaChi = string.IsNullOrEmpty(diaChi) ? ncc.DiaChi : diaChi;
                

                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật nhà cung cấp: " + ex.Message);
            }
        }

        public bool DeleteSupplier(int maNCC)
        {
            try
            {
                var ncc = db.NhaCungCaps.SingleOrDefault(x => x.MaNhaCungCap == maNCC);
                if (ncc == null) return false;

                db.NhaCungCaps.DeleteOnSubmit(ncc);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa nhà cung cấp: " + ex.Message);
            }
        }

        public object SearchSupplierById(int maNCC)
        {
            try
            {
                return db.NhaCungCaps
                    .Where(ncc => ncc.MaNhaCungCap == maNCC)
                    .Select(ncc => new
                    {
                        ncc.MaNhaCungCap,
                        ncc.TenNhaCungCap,
                        ncc.SoDienThoai,
                        ncc.DiaChi,
                        
                    }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm nhà cung cấp theo mã: " + ex.Message);
            }
        }

        public object SearchSupplierByName(string tenNCC)
        {
            try
            {
                return db.NhaCungCaps
                    .Where(ncc => ncc.TenNhaCungCap.Contains(tenNCC))
                    .Select(ncc => new
                    {
                        ncc.MaNhaCungCap,
                        ncc.TenNhaCungCap,
                        ncc.SoDienThoai,
                        ncc.DiaChi,
                        
                    }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm nhà cung cấp theo tên: " + ex.Message);
            }
        }
    }
}

