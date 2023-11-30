using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSach
{
    public partial class Loaisach : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=DESKTOP-TT;Initial Catalog=Sach;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from Loaisach";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            show.DataSource = table;
        }
        public Loaisach()
        {
            InitializeComponent();
        }

        private void Loaisach_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void show_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = show.CurrentRow.Index;
            id_CT.Text = show.Rows[i].Cells[0].Value.ToString();
            name_CT.Text = show.Rows[i].Cells[1].Value.ToString();
        }

        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "insert into Loaisach values('" + id_CT.Text + "', N'" + name_CT.Text + "')";
                int n = command.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                loaddata();
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi kết nối", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Modify_Click(object sender, EventArgs e)
        {
            if (id_CT.Text == "")
            {
                MessageBox.Show("Chua nhap mã nhan vien");
                id_CT.Focus();
            }
            else
            {
                DialogResult lenh = MessageBox.Show("Bạn có chắc muốn sửa thông tin loại sách ? ",
              "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (lenh == DialogResult.Yes)
                {
                    //thêm dữ liệu => CSDL
                    //Kết nối => thành công?
                    connection = new SqlConnection(str);
                    try
                    {
                        //mở kết nối
                        connection.Open();
                        //thêm => Command => thực thiện câu lệnh => chuỗi SQL
                        //lấy dữ liệu trên Form

                        string sql_insert = "UPDATE Loaisach SET Maloaisach ='" + id_CT.Text + "', TenLoaisach= N'" + name_CT.Text + "' where MaLoaisach = '" + id_CT.Text + "'";
                        //Khởi tạo đối tượng command
                        command = new SqlCommand(sql_insert, connection);
                        command.ExecuteNonQuery();
                        connection.Close();
                        MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loaddata();
                    }
                    catch (Exception)
                    {
                        //lỗi xảy ra => Kết nối ko thành công
                        MessageBox.Show("Lỗi kết nối", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                    
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            DialogResult lenh = MessageBox.Show("Bạn có chắc muốn xóa loại sách  " + id_CT.Text + "? ",
               "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (lenh == DialogResult.Yes)
            {
                //thêm dữ liệu => CSDL
                //Kết nối => thành công?
                connection = new SqlConnection(str);
                try
                {
                    //mở kết nối
                    connection.Open();
                    //thêm => Command => thực thiện câu lệnh => chuỗi SQL
                    //lấy dữ liệu trên Form

                    string sql_insert = "DELETE LoaiSach where MaLoaiSach ='" + id_CT.Text + "'";

                    //Khởi tạo đối tượng command
                    command = new SqlCommand(sql_insert, connection);
                    command.ExecuteNonQuery();
                    
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loaddata();
                }
                catch
                {
                    //lỗi xảy ra => Kết nối ko thành công
                    MessageBox.Show("Lỗi kết nối", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Search_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                MessageBox.Show("Chưa nhập mã loại sách cần tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                //Kết nối => thành công?

                connection = new SqlConnection(str);
                try
                {
                    //mở kết nối
                    connection.Open();
                    string sql_in = "select * from  LoaiSach where MaLoaisach ='" + txtSearch.Text + "'";
                    //Khởi tạo đối tượng command
                    command = new SqlCommand(sql_in, connection);
                    command.ExecuteNonQuery();
                    table = new DataTable();
                    SqlDataReader dr = command.ExecuteReader();
                    table.Load(dr);
                    show.DataSource = table;
                    //MessageBox.Show("Thêm thành công");
                }
                catch (Exception)
                {
                    //lỗi xảy ra => Kết nối ko thành công
                    MessageBox.Show("Lỗi kết nối");
                }
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
