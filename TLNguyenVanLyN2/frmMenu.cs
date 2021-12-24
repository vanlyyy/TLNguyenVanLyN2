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

namespace TLNguyenVanLyN2
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
            lbHoTen.Text = BienToanCuc.hoten;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmVi f = new frmVi();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmGiaoDich f = new frmGiaoDich();
            f.ShowDialog();
        }
    }
}
