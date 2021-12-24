using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLNguyenVanLyN2.DAL;
using TLNguyenVanLyN2.ViewModel;

namespace TLNguyenVanLyN2.BLL
{
    internal class ViBLL
    {
        public static List<ViViewModel> getListVi(long idPerson)
        {
            QLChiTieuModel model = new QLChiTieuModel();
            var vi = model.Vis.Where(e => e.IdPerson == idPerson).Select(e => new ViViewModel
            {
                IdVi = e.IdVi,
                TenVi = e.TenVi,
                SoTien = (long) e.SoTien,
                NgayTao = (DateTime) e.NgayTao,
                IdPerson = (long) idPerson,

            }).ToList();
            return vi;
        }
        public static bool DeleteVi(long idVi)
        {
            QLChiTieuModel model = new QLChiTieuModel();
            var vi = model.Vis.Where(e => e.IdVi == idVi).FirstOrDefault();
            if (vi.GiaoDiches.Count() == 0)
            {
                model.Vis.Remove(vi);
                model.SaveChanges();
                return true;
            }
            else return false;
        }
    }
}
