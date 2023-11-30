using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLSach
{
    public partial class Dangnhap : Form
    {
        public Dangnhap()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Query_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-TT;Initial Catalog=Sach;Integrated Security=True");
            try
            {
                conn.Open();
                String taikhoan = username.Text;
                String matkhau = password.Text;
                String sql = " select * from Dangnhap where Tennguoidung ='" + taikhoan + "'and Matkhau = '" + matkhau + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read() == true)
                {
                    Hyper hy = new Hyper();
                    hy.Show();
                    this.Hide();
                    MessageBox.Show("Đăng nhập thành công");
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối");
            }
        }

        private void Dangnhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void hide_Click(object sender, EventArgs e)
        {
            if (password.PasswordChar == '*')
            {
                show.BringToFront();
                password.PasswordChar = '\0';
            }
        }

        private void show_Click(object sender, EventArgs e)
        {
            if (password.PasswordChar == '\0')
            {
                hide.BringToFront();
                password.PasswordChar = '*';
            }
        }

        private void Dangnhap_Load(object sender, EventArgs e)
        {

        }
    }
}
