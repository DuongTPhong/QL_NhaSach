using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSach
{
    public partial class Hyper : Form
    {
        bool thoat = true;

        public Hyper()
        {
            InitializeComponent();
        }

        private void Logoutt_Click(object sender, EventArgs e)
        {
            thoat = false;
            this.Close();
            Dangnhap lg = new Dangnhap();
            lg.Show();
        }

        private void Hyper_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (thoat)
                Application.Exit();
        }

        private void Exitt_Click(object sender, EventArgs e)
        {
            if (thoat)
                Application.Exit();
        }

        private void NV_Click(object sender, EventArgs e)
        { 
            Nhanvien NV = new Nhanvien();
            NV.MdiParent= this;
            NV.Show();
        }

        private void S_Click(object sender, EventArgs e)
        {
            Sach S = new Sach();
            S.MdiParent = this;
            S.Show();
        }

        private void CategoryS_Click(object sender, EventArgs e)
        {
            Loaisach LS = new Loaisach();
            LS.MdiParent = this;
            LS.Show();
        }

        private void Provide_Click(object sender, EventArgs e)
        {
            Nhacungcap NCC = new Nhacungcap();
            NCC.MdiParent = this;
            NCC.Show();
        }

        private void Bill_Click(object sender, EventArgs e)
        {
            Hoadon B = new Hoadon();
            B.MdiParent = this;
            B.Show();
        }

        private void Hyper_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
