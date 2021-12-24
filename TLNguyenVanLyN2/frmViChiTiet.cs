using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TLNguyenVanLyN2.ViewModel;
using TLNguyenVanLyN2.BLL;
using TLNguyenVanLyN2.DAL;

namespace TLNguyenVanLyN2
{
    public partial class frmViChiTiet : Form
    {
        ViViewModel vimodel;
        public frmViChiTiet(ViViewModel vimodel=null)
        {
            InitializeComponent();
            this.vimodel = vimodel;
            if (vimodel != null)
            {
                this.Text = "Cập nhật ví";
                txtSoTien.Text = vimodel.SoTien.ToString();
                txtTenVi.Text = vimodel.TenVi;
            }
            else this.Text = "Thêm mới ví";
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            QLChiTieuModel model = new QLChiTieuModel();
            errorProvider1.Clear();
            var tienvao = txtSoTien.Text;
            var tenvi = txtTenVi.Text;
            DateTime ngaytao = DateTime.Now;
            if (string.IsNullOrEmpty(tienvao))
            {
                errorProvider1.SetError(txtSoTien, "Vui lòng nhập vào số tiền");
                return;
            }
            if (string.IsNullOrEmpty(tenvi))
            {
                errorProvider1.SetError(txtTenVi, "Vui lòng nhập vào tên ví");
                return;
            }
            if (vimodel != null)
            {
                var vi = model.Vis.Where(t => t.IdVi == vimodel.IdVi).FirstOrDefault();
                vi.SoTien = long.Parse(tienvao);
                vi.TenVi = tenvi;
                vi.NgayTao = ngaytao;
                model.SaveChanges();
                DialogResult = DialogResult.OK;
            }
            else
            {
                var vi = new Vi
                {
                    SoTien = long.Parse(tienvao),
                    TenVi = tenvi,
                    NgayTao = ngaytao,
                    IdPerson = BienToanCuc.id,
                };
                model.Vis.Add(vi);
                model.SaveChanges();
                DialogResult = DialogResult.OK;
            }
        }
    }
}
