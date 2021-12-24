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
    public partial class frmChiTietGD : Form
    {
        GDViewModel gdmodel;
        public frmChiTietGD(GDViewModel gdmodel =null)
        {
            InitializeComponent();
            this.gdmodel = gdmodel;
            var vi = ViBLL.getListVi(BienToanCuc.id);
            cbVi.DataSource = vi;
            cbVi.DisplayMember = "SoTien";
            var loai = LoaiGDBLL.getListLoai();
            cbLoai.DataSource = loai;
            cbLoai.DisplayMember = "TenLoai";
            if (gdmodel == null) this.Text = "Thêm giao dịch mới";
            else
            {
                this.Text = "Sửa thông tin giao dịch";
                lbIdGD.Text = gdmodel.IdGD.ToString();
                txtSoTien.Text = gdmodel.SoTien.ToString();
                txtMoTa.Text = gdmodel.MoTa;
                lbIdVi.Text = gdmodel.IdVi.ToString();
                lbIdLoai.Text = gdmodel.IdLoai.ToString();
            }
        }

        private void cbLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            var loai = cbLoai.SelectedItem as LoaiViewModel;
            if (loai != null)
            {
                lbIdLoai.Text = loai.IdLoai.ToString();
            }
        }

        private void cbVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            var vi = cbVi.SelectedItem as ViViewModel;
            if (vi != null)
                lbIdVi.Text = vi.IdVi.ToString();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            var sotien = txtSoTien.Text;
            var ngaychi = dtNgayChi.Value;
            var mota = txtMoTa.Text;
            var idloai = lbIdLoai.Text;
            var idvi = lbIdVi.Text;
            if (string.IsNullOrEmpty(sotien))
            {
                errorProvider1.SetError(txtSoTien, "Vui lòng nhập số tiền chi");
                return;
            }
             QLChiTieuModel model = new QLChiTieuModel();
            if (gdmodel == null)
            {
                var gd = new GiaoDich
                {
                    SoTien = long.Parse(sotien),
                    MoTa = mota,
                    NgayGD = ngaychi,
                    IdLoai = idloai,
                    IdVi = long.Parse(idvi),
                };
                model.GiaoDiches.Add(gd);
                model.SaveChanges();
                DialogResult = DialogResult.OK;
            }
            else
            {
                var MaGD = long.Parse(lbIdGD.Text);
                var gd = model.GiaoDiches.Where(t => t.IdGD == MaGD).FirstOrDefault();
                if (gd != null)
                {
                    gd.SoTien = long.Parse(sotien);
                    gd.NgayGD = ngaychi;
                    gd.MoTa = mota;
                    gd.IdLoai = idloai;
                    gd.IdVi = long.Parse(idvi);
                    model.SaveChanges();
                    DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
