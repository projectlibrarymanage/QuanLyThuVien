using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class DocGiaDAL
    {
        private string connectionString;

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        public DocGiaDAL()
        {
            connectionString = ConfigurationSettings.AppSettings["ConnectionString"];
        }
        //public string ConnectionString { get => connectionString; set => connectionString = value; }

        public bool Them(DocGiaDTO add)
        {
            string query = string.Empty;
            query += "INSERT INTO DocGia ([MaDocGia], [TenDocGia], [MaLoaiDocGia],[NgaySinh], [DiaChi], [Email],  [Ngaylapthe])";
            query += "VALUES (@Madocgia,@Hoten,@Maloaidocgia,@Ngaysinh,@Diachi,@Email,@Ngaylapthe)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@Madocgia", add.Madocgia);
                    cmd.Parameters.AddWithValue("@Hoten", add.Hoten);
                    cmd.Parameters.AddWithValue("@Ngaysinh", add.Ngaysinh);
                    cmd.Parameters.AddWithValue("@Diachi", add.Diachi);
                    cmd.Parameters.AddWithValue("@Email", add.Email);
                    cmd.Parameters.AddWithValue("@Maloaidocgia", add.Loaidocgia);
                    cmd.Parameters.AddWithValue("@Ngaylapthe", add.Ngaylapthe);                    
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return false;
                    }
                }
            }
            return true;
        }

        public bool Xoa(DocGiaDTO del)
        {
            string query = string.Empty;
            query += "DELETE FROM DocGia WHERE [Madocgia] = @Madocgia";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@Madocgia", del.Madocgia);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return false;
                    }
                }
            }
            return true;
        }

        public bool Sua(DocGiaDTO edit)
        {
            string query = string.Empty;
            query += "UPDATE DocGia SET [TenDocGia] = @Hoten, [NgaySinh] = @Ngaysinh, [DiaChi] = @Diachi, [Email] = @Email, [MaLoaiDocGia] = @Loaidocgia, [NgayLapThe] = @Ngaylapthe WHERE [Madocgia] = @Madocgia";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@Madocgia", edit.Madocgia);
                    cmd.Parameters.AddWithValue("@Hoten", edit.Hoten);
                    cmd.Parameters.AddWithValue("@Ngaysinh", edit.Ngaysinh);
                    cmd.Parameters.AddWithValue("@Diachi", edit.Diachi);
                    cmd.Parameters.AddWithValue("@Email", edit.Email);
                    cmd.Parameters.AddWithValue("@Loaidocgia", edit.Loaidocgia);
                    cmd.Parameters.AddWithValue("@Ngaylapthe", edit.Ngaylapthe);
                    cmd.Parameters.AddWithValue("@Cogiatri", edit.Cogiatri);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return false;
                    }
                }
            }
            return true;
        }


        public List<DocGiaDTO> select()
        {
            string query = string.Empty;
            query += "SELECT [Madocgia], [Hoten], [Ngaysinh], [Diachi], [Email], [Loaidocgia], [Ngaylapthe], [Cogiatri]";
            query += "FROM DocGia";

            List<DocGiaDTO> listDocGia = new List<DocGiaDTO>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;

                    try
                    {
                        con.Open();
                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                DocGiaDTO dg = new DocGiaDTO();
                                dg.Madocgia = reader["Madocgia"].ToString();
                                dg.Hoten = reader["Hoten"].ToString();
                                dg.Ngaysinh = DateTime.Parse(reader["Ngaysinh"].ToString());
                                dg.Diachi = reader["Diachi"].ToString();
                                dg.Email = reader["Email"].ToString();
                                dg.Loaidocgia = reader["Loaidocgia"].ToString();
                                dg.Ngaylapthe = DateTime.Parse(reader["Ngaylapthe"].ToString());
                                dg.Cogiatri = DateTime.Parse(reader["Cogiatri"].ToString());
                                listDocGia.Add(dg);
                            }
                        }

                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return null;
                    }
                }
            }
            return listDocGia;
        }    

        public void GetListReader(DataGridView dataGridView1)
        {
            try
            {
                SqlConnection Con = new SqlConnection(ConnectionString);
                Con.Open();
                string DocgiaDgv = "select * from DocGia";
                SqlCommand commandDocGia = new SqlCommand(DocgiaDgv, Con);
                SqlDataAdapter adapterDocGia = new SqlDataAdapter(commandDocGia);
                DataTable table = new DataTable();
                adapterDocGia.Fill(table);
                dataGridView1.DataSource = table;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridView1.Columns[6].DefaultCellStyle.Format = "dd/MM/yyyy";
              
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối hệ thống", " ERROR ");
            }
            finally
            {
                SqlConnection Con = new SqlConnection(ConnectionString);
                Con.Close();
            }
        }
        public void listreaderMa(DataGridView dataGridView1, string ma)
        {
            try
            {
                SqlConnection Con = new SqlConnection(ConnectionString);
                Con.Open();
                string DocgiaDgv = "select * from DocGia where Madocgia like '%" + ma + "%'";
                SqlCommand commandDocGia = new SqlCommand(DocgiaDgv, Con);
                SqlDataAdapter adapterDocGia = new SqlDataAdapter(commandDocGia);
                DataTable table = new DataTable();
                adapterDocGia.Fill(table);
                dataGridView1.DataSource = table;
                Con.Close();

            }
            catch
            {
                MessageBox.Show("Lỗi kết nối hệ thống", " ERROR ");
            }
            finally
            {
                SqlConnection Con = new SqlConnection(ConnectionString);
                Con.Close();
            }
        }
        public void listreaderTen(DataGridView dataGridView, string ten)
        {
            try
            {
                SqlConnection Con = new SqlConnection(ConnectionString);
                Con.Open();
                string DocgiaDgv = "select * from DocGia where TenDocGia like N'%" + ten + "%'";
                SqlCommand commandDocGia = new SqlCommand(DocgiaDgv, Con);
                SqlDataAdapter adapterDocGia = new SqlDataAdapter(commandDocGia);
                DataTable table = new DataTable();
                adapterDocGia.Fill(table);
                dataGridView.DataSource = table;
                Con.Close();

            }
            catch
            {
                MessageBox.Show("Lỗi kết nối hệ thống", " ERROR ");
            }
            finally
            {
                SqlConnection Con = new SqlConnection(ConnectionString);
                Con.Close();
            }
        }

    }
}
