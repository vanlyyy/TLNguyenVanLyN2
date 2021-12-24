using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLNguyenVanLyN2.DAL;
using TLNguyenVanLyN2.ViewModel;

namespace TLNguyenVanLyN2.BLL
{
    internal class GiaoDichBLL
    {
        public static List<GDViewModel> getListGd(long idVi)
        {
            QLChiTieuModel model = new QLChiTieuModel();
            var gd = model.GiaoDiches.Where(e => e.IdVi == idVi).Select(e => new GDViewModel
            {
                IdGD = e.IdGD,
                SoTien = (long)e.SoTien,
                MoTa = e.MoTa,
                NgayGD = (DateTime)e.NgayGD,
                IdVi = idVi,
                IdLoai = e.IdLoai,
            }).ToList();
            return gd;
        }
        public static void XoaGD(long idgd)
        {
            QLChiTieuModel model = new QLChiTieuModel();
            var gd = model.GiaoDiches.Where(e => e.IdGD == idgd).FirstOrDefault();
            model.GiaoDiches.Remove(gd);
            model.SaveChanges();
        }
    }
}
