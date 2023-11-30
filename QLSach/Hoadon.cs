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
    public partial class Hoadon : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=DESKTOP-TT;Initial Catalog=Sach;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from Hoadon";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            show.DataSource = table;
        }

        public Hoadon()
        {
            InitializeComponent();
        }

        private void Hoadon_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "insert into Hoadon " +
                    "values('" + id_HD.Text + "', N'" + id_NV.Text + "', '" + id_KH.Text + "', '" + id_S.Text + "'," +
                    " '" + Quantity.Text + "',N'" + Price.Text + "','" + Date.Text + "','" + Total.Text + "')";
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

        private void show_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = show.CurrentRow.Index;
            id_HD.Text = show.Rows[i].Cells[0].Value.ToString();
            id_NV.Text = show.Rows[i].Cells[1].Value.ToString();
            id_KH.Text = show.Rows[i].Cells[2].Value.ToString();
            id_S.Text = show.Rows[i].Cells[3].Value.ToString();
            Quantity.Text = show.Rows[i].Cells[4].Value.ToString();
            Price.Text = show.Rows[i].Cells[5].Value.ToString();
            Date.Text = show.Rows[i].Cells[6].Value.ToString();
            Total.Text = show.Rows[i].Cells[7].Value.ToString();
           
        }

        private void Modify_Click(object sender, EventArgs e)
        {
            if (id_S.Text == "")
            {
                MessageBox.Show("Chưa nhập mã hóa đơn");
                id_S.Focus();
            }
            else
            {
                DialogResult lenh = MessageBox.Show("Bạn có chắc muốn sửa hóa đơn ? ",
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

                        string sql_insert = "UPDATE Hoadon SET MaHD ='" + id_HD.Text + "', MaNV= N'" + id_NV.Text + "',MaKH= '" + id_KH.Text + "',MaSach= N'" + id_S.Text + "'," +
                            "Soluong='" + Quantity.Text + "',Dongia=N'" + Price.Text + "',NgayBan='" + Date.Text + "' where MaHD = '" + id_HD.Text + "'";
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
            DialogResult lenh = MessageBox.Show("Bạn có chắc muốn xóa hóa đơn  " + id_HD.Text + "? ",
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

                    string sql_insert = "DELETE Hoadon where MaHD ='" + id_HD.Text + "'";

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
                MessageBox.Show("Chưa nhập mã hóa đơn cần tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //Kết nối => thành công?

                connection = new SqlConnection(str);
                try
                {
                    //mở kết nối
                    connection.Open();
                    string sql_in = "select * from  Hoadon where MaHD ='" + txtSearch.Text + "'";
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
