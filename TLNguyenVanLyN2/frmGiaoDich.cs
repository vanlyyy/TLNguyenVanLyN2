using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TLNguyenVanLyN2.DAL;
using TLNguyenVanLyN2.BLL;
using TLNguyenVanLyN2.ViewModel;

namespace TLNguyenVanLyN2
{
    public partial class frmGiaoDich : Form
    {
        public frmGiaoDich()
        {
            InitializeComponent();
            var idvi = ViBLL.getListVi(BienToanCuc.id);
            cbvi.DataSource = idvi;
            cbvi.DisplayMember = "TenVi";
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var vi = cbvi.SelectedItem as ViViewModel;
            if (vi != null)
            {
                var idvi = vi.IdVi;
                var ls = GiaoDichBLL.getListGd(idvi);
                lbTienVao.Text = vi.SoTien.ToString();
                giaoDichBindingSource.DataSource = ls;
                dataGridView1.DataSource = giaoDichBindingSource;
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            var gd = giaoDichBindingSource.Current as GDViewModel;
            if (gd != null)
            {
                var rs = MessageBox.Show("Bạn có chắc muốn giao dịch này không?", "Thông báo", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    GiaoDichBLL.XoaGD(gd.IdGD);
                    giaoDichBindingSource.RemoveCurrent();
                    MessageBox.Show("Đã xóa thành công", "Thông báo");
                }
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            var f = new frmChiTietGD();
            var rs = f.ShowDialog();
            if (rs == DialogResult.OK)
                MessageBox.Show("Đã thêm thành công", "Thông báo");
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            var gd = giaoDichBindingSource.Current as GDViewModel;
            var f = new frmChiTietGD(gd);
            if (gd != null)
            {
                var rs = f.ShowDialog();
                if (rs == DialogResult.OK)
                {
                    MessageBox.Show("Đã sửa thành công", "Thông báo");
                }
            }
        }
    }
}
