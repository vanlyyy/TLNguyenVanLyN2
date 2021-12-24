using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLNguyenVanLyN2.ViewModel;
using TLNguyenVanLyN2.DAL;

namespace TLNguyenVanLyN2.BLL
{
    internal class LoaiGDBLL
    {
        public static List<LoaiViewModel> getListLoai()
        {
            QLChiTieuModel model = new QLChiTieuModel();
            var ls = model.LoaiGDs.Select(e => new LoaiViewModel
            {
                IdLoai = e.IdLoaiGD,
                TenLoai = e.TenLoai,
            }).ToList();
            return ls;
        }
    }
}
