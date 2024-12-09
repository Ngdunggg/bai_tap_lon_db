using Do_An_Quan_ly_kho.Model;
using Do_An_Quan_ly_kho.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Quan_ly_kho.Controller
{
    internal class DashboardController
    {
        private DatabaseDataContext _db = new DatabaseDataContext();
        public int getTotalUsers()
        {
            var totalUser = this._db.KhachHangs.Count();
            return totalUser;
        }

        public int? getTotalProductIn()
        {
            var totalProduct = this._db.SanPhams.Sum(e => e.SoLuongTonKho);
            if (totalProduct == null)
            {
                return 0;
            }
            return totalProduct;
        }

        public int getTotalProductOut()
        {
            var totalProduct = this._db.ChiTietPhieuBans
                .Select(e => (int?)e.SoLuong) 
                .Sum() ?? 0; 
            return totalProduct;
        }

        public int getTotalVendor()
        {
            var totalVendor = this._db.NhaCungCaps.Count();
            if ((totalVendor == null))
            {
                return 0;
            }
            return totalVendor;
        }

        public decimal? getMoneyOut()
        {
            var result = this._db.PhieuBanHangs.Sum(e => e.TongTien);
            if (result == null)
            {
                return 0;
            }
            return result;
        }

        public List<MoneyCountByMonth> getMoneyOutByMonth(string year)
        {
            var allMonths = Enumerable.Range(1, 12); 

            var result = allMonths
                .GroupJoin(
                    _db.PhieuBanHangs.Where(p => p.NgayBan.Year == int.Parse(year)),
                    month => month, 
                    p => p.NgayBan.Month, 
                    (month, sales) => new MoneyCountByMonth
                    {
                        Month = month,
                        Money = sales.Select(p => p.TongTien).Distinct().Sum() 
                    })
                .OrderBy(r => r.Month)
                .ToList();

            return result;


        }

        public List<MoneyCountByMonth> getMoneyOutByIn(string year)
        {
            var allMonths = Enumerable.Range(1, 12); 

            var result = allMonths
                .GroupJoin(
                    _db.PhieuNhapHangs.Where(p => p.NgayNhap.Year == int.Parse(year)),
                    month => month, 
                    p => p.NgayNhap.Month,
                    (month, sales) => new MoneyCountByMonth
                    {
                        Month = month,
                        Money = sales.Select(p => p.TongTien).Distinct().Sum() 
                    })
                .OrderBy(r => r.Month)
                .ToList();

            return result;


        }

        public decimal? getMoneyIn()
        {
            var result = this._db.PhieuNhapHangs.Sum(e => e.TongTien);
            if (result == null)
            {
                return 0;
            }
            return result;
        }

        public List<SupplierCountByMonth> SupplierCountByMonths(string year)
        {
            var allMonths = Enumerable.Range(1, 12); 

            var result = allMonths
                .GroupJoin(
                    _db.PhieuNhapHangs.Where(p => p.NgayNhap.Year == int.Parse(year)),
                    month => month,
                    p => p.NgayNhap.Month, 
                    (month, entries) => new SupplierCountByMonth
                    {
                        Month = month,
                        SupplierCount = entries.Select(p => p.MaNhaCungCap).Distinct().Count() 
                    })
                .OrderBy(r => r.Month)
                .ToList();

            return result;

        }

        public List<Customer> CustomerCountByMonths(string year)
        {
            var allMonths = Enumerable.Range(1, 12); 

            var results = allMonths
                .GroupJoin(
                    _db.PhieuBanHangs.Where(p => p.NgayBan.Year == int.Parse(year)),
                    month => month,
                    p => p.NgayBan.Month,
                    (month, sales) => new Customer
                    {
                        Month = month,
                        CustomerCount = sales.Select(p => p.MaKhachHang).Distinct().Count() 
                    })
                .OrderBy(r => r.Month)
                .ToList();

            return results;

        }

        public List<countProductIn> CountProductIns(string year)
        {

            var allMonths = Enumerable.Range(1, 12); 

            try
            {
                var results = allMonths
                    .GroupJoin(
                        _db.PhieuNhapHangs.Where(p => p.NgayNhap.Year == int.Parse(year)),
                        month => month,
                        p => p.NgayNhap.Month,
                        (month, phieuNhapGroup) => new countProductIn
                        {
                            Month = month,
                            ProductCount = phieuNhapGroup
                                .SelectMany(
                                    pn => _db.ChiTietPhieuNhaps.Where(ctpn => ctpn.MaPhieuNhap == pn.MaPhieuNhap).DefaultIfEmpty(),
                                    (pn, ctpn) => ctpn?.SoLuong ?? 0
                                )
                                .Sum()
                        })
                    .OrderBy(r => r.Month)
                    .ToList();

                return results;
            }
            catch (Exception ex)
            {
                return allMonths
                    .Select(month => new countProductIn
                    {
                        Month = month,
                        ProductCount = 0
                    })
                    .ToList();
            }


        }

        public List<countProductIn> CountProductOuts(string year)
        {

            var allMonths = Enumerable.Range(1, 12); 

            try
            {
                var results = allMonths
                    .GroupJoin(
                        _db.PhieuBanHangs.Where(p => p.NgayBan.Year == int.Parse(year)),
                        month => month,
                        p => p.NgayBan.Month,
                        (month, phieuBanGroup) => new countProductIn
                        {
                            Month = month,
                            ProductCount = phieuBanGroup
                                .SelectMany(
                                    pn => _db.ChiTietPhieuBans.Where(ctpn => ctpn.MaPhieuBan == pn.MaPhieuBan).DefaultIfEmpty(),
                                    (pn, ctpn) => ctpn?.SoLuong ?? 0
                                )
                                .Sum()
                        })
                    .OrderBy(r => r.Month)
                    .ToList();

                return results;
            }
            catch (Exception ex)
            {
                return allMonths
                    .Select(month => new countProductIn
                    {
                        Month = month,
                        ProductCount = 0
                    })
                    .ToList();
            }


        }
    }
}
