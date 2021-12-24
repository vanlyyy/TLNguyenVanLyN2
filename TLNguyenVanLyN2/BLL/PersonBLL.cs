using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLNguyenVanLyN2.DAL;
namespace TLNguyenVanLyN2.BLL
{
    internal class PersonBLL
    {
        public static bool Ktdn(string username, string pass)
        {
            QLChiTieuModel model = new QLChiTieuModel();
            var p = model.People.Where(e => e.username == username && e.password == pass).FirstOrDefault();
            if (p != null)
            {
                BienToanCuc.id = p.Id;
                BienToanCuc.hoten = p.FullName;
                return true;
            }
            else
                return false;
        }
    }
}
