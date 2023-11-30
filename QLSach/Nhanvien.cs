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
    public partial class Nhanvien : Form
    {

        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=DESKTOP-TT;Initial Catalog=Sach;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from Nhanvien";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            show.DataSource = table;
        }
        public Nhanvien()
        {
            InitializeComponent();
        }

        private void Nhanvien_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void show_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = show.CurrentRow.Index;
            id_NV.Text = show.Rows[i].Cells[0].Value.ToString();
            name_NV.Text = show.Rows[i].Cells[1].Value.ToString();
            Sex.Text = show.Rows[i].Cells[2].Value.ToString();
            Address.Text = show.Rows[i].Cells[3].Value.ToString();
            Date.Text = show.Rows[i].Cells[4].Value.ToString();
            Telephone.Text = show.Rows[i].Cells[5].Value.ToString();
            Mail.Text = show.Rows[i].Cells[6].Value.ToString();
        }

        private void add_Click(object sender, EventArgs e)
        {
            
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "insert into Nhanvien(MaNV,Hoten,GioiTinh,Diachi,ngaysinh,SDT,Email) " +
                    "values('" + id_NV.Text + "', N'" + name_NV.Text + "', N'" + Sex.Text + "', N'" + Address.Text + "', '" + Date.Text + "','" + Telephone.Text + "','" + Mail.Text + "')";
                int n = command.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show("Thêm thành công","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm thất bại","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);

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
            if (id_NV.Text == "")
            {
                MessageBox.Show("Chưa nhập mã nhân viên");
                id_NV.Focus();
            }
            else
            {
                DialogResult lenh = MessageBox.Show("Bạn có chắc muốn sửa thông tin nhân viên ? ",
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

                        string sql_insert = "UPDATE Nhanvien SET MaNV ='" + id_NV.Text + "', Hoten= N'" + name_NV.Text + "',Gioitinh= N'" + Sex.Text + "',Diachi= N'" + Address.Text + "'," +
                            "ngaysinh='" + Date.Text + "',SDT='" + Telephone.Text + "',Email='" + Mail.Text + "'where MaNV = '" + id_NV.Text + "'";
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
            DialogResult lenh = MessageBox.Show("Bạn có chắc muốn xóa nhân viên  " + id_NV.Text + "? ",
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

                    string sql_insert = "DELETE Nhanvien where MaNV ='" + id_NV.Text + "'";

                    //Khởi tạo đối tượng command
                    command = new SqlCommand(sql_insert, connection);
                    command.ExecuteNonQuery();
                    loaddata();
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Chưa nhập mã nhân viên cần tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //Kết nối => thành công?

                connection = new SqlConnection(str);
                try
                {
                    //mở kết nối
                    connection.Open();
                    string sql_in = "select * from  Nhanvien where MaNV ='" + txtSearch.Text + "'";
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
