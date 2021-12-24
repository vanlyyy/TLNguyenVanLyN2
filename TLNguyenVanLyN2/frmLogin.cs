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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            string un = txtUsername.Text;
            String pas = txtPassword.Text;
            Console.WriteLine(un);
            if (PersonBLL.Ktdn(un, pas) == false)
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng", "Thông báo");
            else
            {
                frmMenu f = new frmMenu();
                f.ShowDialog();
            }
        }
    }
}
