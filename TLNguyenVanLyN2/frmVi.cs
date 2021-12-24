using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TLNguyenVanLyN2.BLL;
using TLNguyenVanLyN2.ViewModel;

namespace TLNguyenVanLyN2
{
    public partial class frmVi : Form
    {
        public frmVi()
        {
            InitializeComponent();
            LoadVi(BienToanCuc.id);
        }
        void LoadVi(long idPerson)
        {
            var vi = ViBLL.getListVi(idPerson);
            viBindingSource.DataSource = vi;
            dataGridView1.DataSource = viBindingSource;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            var f = new frmViChiTiet();
            var rs = f.ShowDialog();
            if (rs == DialogResult.OK)
                LoadVi(BienToanCuc.id);
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            var vi = viBindingSource.Current as ViViewModel;
            var f = new frmViChiTiet(vi);
            if (vi != null)
            {
                var rs = f.ShowDialog();
                if (rs == DialogResult.OK)
                    LoadVi(BienToanCuc.id);
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            var vi = viBindingSource.Current as ViViewModel;
            if (vi != null)
            {
                var rs = MessageBox.Show("Bạn có muốn xóa ví này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    if (ViBLL.DeleteVi(vi.IdVi))
                    {
                        viBindingSource.RemoveCurrent();
                        MessageBox.Show("Đã xóa thành công", "Thông báo");
                    }
                    else MessageBox.Show("Xóa thất bại", "Thông báo");
                }
            }
        }
    }
}
