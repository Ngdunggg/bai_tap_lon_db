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
            var result = _db.PhieuBanHangs
               .Where(p => p.NgayBan.Year == int.Parse(year)) 
               .GroupBy(p => p.NgayBan.Month) 
               .Select(g => new MoneyCountByMonth
               {
                   Month = g.Key,
                   Money = g.Select(p => p.TongTien).Distinct().Sum() 
               })
               .OrderBy(r => r.Month) 
               .ToList();

            return result;

        }

        public List<MoneyCountByMonth> getMoneyOutByIn(string year)
        {
            var result = _db.PhieuNhapHangs
               .Where(p => p.NgayNhap.Year == int.Parse(year))
               .GroupBy(p => p.NgayNhap.Month)
               .Select(g => new MoneyCountByMonth
               {
                   Month = g.Key,
                   Money = g.Select(p => p.TongTien).Distinct().Sum()
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
            var result = _db.PhieuNhapHangs
                            .Where(p => p.NgayNhap.Year == int.Parse(year))
                            .GroupBy(p => p.NgayNhap.Month)
                            .Select(g => new SupplierCountByMonth
                            {
                                Month = g.Key,
                                SupplierCount = g.Select(p => p.MaNhaCungCap).Distinct().Count()
                            })
                            .OrderBy(r => r.Month)
                            .ToList();
            return result;
        }

        public List<Customer> CustomerCountByMonths(string year)
        {
            var results = _db.PhieuBanHangs
                .Where(p => p.NgayBan.Year == int.Parse(year))
                .GroupBy(p => p.NgayBan.Month)
                .Select(g => new Customer
                {
                    Month = g.Key,
                    CustomerCount = g.Select(p => p.MaKhachHang).Distinct().Count()
                })
                .ToList();
            return results;
        }

        public List<countProductIn> CountProductIns(string year)
        {

            try
            {
                var results = _db.PhieuNhapHangs
                    .Where(p => p.NgayNhap.Year == int.Parse(year)) 
                    .GroupBy(p => p.NgayNhap.Month) 
                    .Select(g => new countProductIn
                    {
                        Month = g.Key,
                        ProductCount = g
                            .GroupJoin(_db.ChiTietPhieuNhaps, pn => pn.MaPhieuNhap, ctpn => ctpn.MaPhieuNhap, (pn, ctpnGroup) => new { pn, ctpnGroup })
                            .SelectMany(
                                x => x.ctpnGroup.DefaultIfEmpty(), 
                                (x, ctpn) => ctpn
                            )
                            .Sum(ctpn => ctpn != null ? ctpn.SoLuong : 0) 
                    })
                    .ToList();

            return results;


            }
            catch (Exception ex)
            {
                var result = new List<countProductIn>();

                for (int month = 1; month <= 12; month++)
                {

                    result.Add(new countProductIn
                    {
                        Month = month,
                        ProductCount = 0
                    });
                }
                return result;
            }

        }

        public List<countProductIn> CountProductOuts(string year)
        {

            try
            {
                var results = _db.PhieuBanHangs
                    .Where(p => p.NgayBan.Year == int.Parse(year))
                    .GroupBy(p => p.NgayBan.Month)
                    .Select(g => new countProductIn
                    {
                        Month = g.Key,
                        ProductCount = g
                            .GroupJoin(_db.ChiTietPhieuBans, pn => pn.MaPhieuBan, ctpn => ctpn.MaPhieuBan, (pn, ctpnGroup) => new { pn, ctpnGroup })
                            .SelectMany(
                                x => x.ctpnGroup.DefaultIfEmpty(),
                                (x, ctpn) => ctpn
                            )
                            .Sum(ctpn => ctpn != null ? ctpn.SoLuong : 0)
                    })
                    .ToList();
                return results ;
            }
            catch (Exception ex)
            {
                var result = new List<countProductIn>();

                for (int month = 1; month <= 12; month++)
                {

                    result.Add(new countProductIn
                    {
                        Month = month,
                        ProductCount = 0
                    });
                }
                return result;
            }

            var result1 = new List<countProductIn>();

            for (int month = 1; month <= 12; month++)
            {

                result1.Add(new countProductIn
                {
                    Month = month,
                    ProductCount = 0
                });
            }
            return result1;

        }
    }
}
