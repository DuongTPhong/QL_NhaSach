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
    public partial class Nhacungcap : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=DESKTOP-TT;Initial Catalog=Sach;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();


        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from Nhacungcap";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            show.DataSource = table;
        }

        public Nhacungcap()
        {
            InitializeComponent();
        }

        private void Nhacungcap_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void show_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = show.CurrentRow.Index;
            id_NCC.Text = show.Rows[i].Cells[0].Value.ToString();
            name_NCC.Text = show.Rows[i].Cells[1].Value.ToString();
            Address.Text = show.Rows[i].Cells[2].Value.ToString();
            Telephone.Text = show.Rows[i].Cells[3].Value.ToString();
            id_S.Text = show.Rows[i].Cells[4].Value.ToString();
            Buy.Text = show.Rows[i].Cells[5].Value.ToString();
            Quantity.Text = show.Rows[i].Cells[6].Value.ToString();
            Date.Text = show.Rows[i].Cells[7].Value.ToString();
        }

        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "insert into Nhacungcap " +
                    "values('" + id_NCC.Text + "', N'" + name_NCC.Text + "', N'" + Address.Text + "',N'" + Telephone.Text + "'," +
                    " '" + id_S.Text + "','" + Buy.Text + "','" + Quantity.Text + "','" + Date.Text + "')";
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
            if (id_NCC.Text == "")
            {
                MessageBox.Show("Chưa nhập mã nhà cung cấp");
                id_NCC.Focus();
            }
            else
            {
                DialogResult lenh = MessageBox.Show("Bạn có chắc muốn sửa nhà cung cấp ? ",
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

                        string sql_insert = "UPDATE Nhacungcap SET MaNCC ='" + id_NCC.Text + "', TenNCC= N'" + name_NCC.Text + "',Diachi= N'" + Address.Text + "',SDT= N'" + Telephone.Text + "'," +
                            "MaSach='" + id_S.Text + "',Dongia='" + Buy.Text + "',Soluong='" + Quantity.Text + "',Ngaynhap='" + Date.Text + "' where MaNCC = '" + id_NCC.Text + "'";
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
            DialogResult lenh = MessageBox.Show("Bạn có chắc muốn xóa nhà cung cấp  " + id_NCC.Text + "? ",
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

                    string sql_insert = "DELETE Nhacungcap where MaNCC ='" + id_NCC.Text + "'";

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
                MessageBox.Show("Chưa nhập mã nhà cung cấp cần tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                //Kết nối => thành công?
                connection = new SqlConnection(str);
                try
                {
                    //mở kết nối
                    connection.Open();
                    string sql_in = "select * from  Nhacungcap where MaNCC ='" + txtSearch.Text + "'";
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
