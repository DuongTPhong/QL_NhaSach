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
    public partial class Sach : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=DESKTOP-TT;Initial Catalog=Sach;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();


        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from Sach";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            show.DataSource = table;
        }

        public Sach()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, EventArgs e)
        {
            
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "insert into Sach " +
                    "values('" + id_S.Text + "', N'" + name_S.Text + "', '" + Category.Text + "', N'" + NXB.Text + "'," +
                    " '" + Date.Text + "',N'" + Author.Text + "','" + Supplier.Text + "','" + Buy.Text + "','" + Sell.Text + "'," +
                    "'" + Quantity.Text + "' )";
                int n = command.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show("Thêm thành công","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void Sach_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void show_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = show.CurrentRow.Index;
            id_S.Text = show.Rows[i].Cells[0].Value.ToString();
            name_S.Text = show.Rows[i].Cells[1].Value.ToString();
            Category.Text = show.Rows[i].Cells[2].Value.ToString();
            NXB.Text = show.Rows[i].Cells[3].Value.ToString();
            Date.Text = show.Rows[i].Cells[4].Value.ToString();
            Author.Text = show.Rows[i].Cells[5].Value.ToString();
            Supplier.Text = show.Rows[i].Cells[6].Value.ToString();
            Buy.Text = show.Rows[i].Cells[7].Value.ToString();
            Sell.Text = show.Rows[i].Cells[8].Value.ToString();
            Quantity.Text = show.Rows[i].Cells[9].Value.ToString();
        }

        private void Modify_Click(object sender, EventArgs e)
        {
            if (id_S.Text == "")
            {
                MessageBox.Show("Chưa nhập mã sách ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                id_S.Focus();
            }
            else
            {
                DialogResult lenh = MessageBox.Show("Bạn có chắc muốn sửa sách ? ",
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

                        string sql_insert = "UPDATE Sach SET MaSach ='" + id_S.Text + "', Tensach= N'" + name_S.Text + "',MaLoaiSach= '" + Category.Text + "',TenNXB= N'" + NXB.Text + "'," +
                            "NamXB='" + Date.Text + "',Tacgia=N'" + Author.Text + "',MaNCC='" + Supplier.Text + "',GiaNhap='" + Buy.Text + "',GiaBan='" + Sell.Text + "',Soluong='" + Quantity.Text +
                            "'where MaSach = '" + id_S.Text + "'";
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
            DialogResult lenh = MessageBox.Show("Bạn có chắc muốn xóa sách " + name_S.Text + "? ",
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

                    string sql_insert = "DELETE Sach where MaSach ='" + id_S.Text + "'";

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
                MessageBox.Show("Chưa nhập mã sách cần tìm kiếm","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                //Kết nối => thành công?

                connection = new SqlConnection(str);
                try
                {
                    //mở kết nối
                    connection.Open();
                    string sql_in = "select * from  Sach where MaSach ='" + txtSearch.Text + "'";
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