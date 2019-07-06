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
    public class TheLoaiDAL
    {
        private string connectionString;

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        public TheLoaiDAL()
        {
            connectionString = ConfigurationSettings.AppSettings["ConnectionString"];
        }
        //public string ConnectionString { get => connectionString; set => connectionString = value; }

        public bool Them(TheLoaiDTO add)
        {
            string query = string.Empty;
            query += "INSERT INTO TheLoai ([Matheloai], [Tentheloai])";
            query += "VALUES (@Matheloai,@Tentheloai)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@Matheloai", add.Matheloai);
                    cmd.Parameters.AddWithValue("@Tentheloai", add.Matheloai);

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

        public bool Xoa(TheLoaiDTO del)
        {
            string query = string.Empty;
            query += "DELETE FROM TheLoai WHERE [Matheloai] = @Matheloai";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@Matheloai", del.Matheloai);
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

        public bool Sua(TheLoaiDTO edit)
        {
            string query = string.Empty;
            query += "UPDATE TacGia SET [MaTheLoai] = @matheloai, [TenTheLoai] = @Tentheloai WHERE [MaTheLoai] = @MaTheLoai";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@MaTheLoai", edit.Matheloai);
                    cmd.Parameters.AddWithValue("@Tentheloai", edit.Tentheloai);
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
        public int GetMaTheLoai(string tenheloai)
        {
            int matheloai = new int();
            string query = string.Empty;
            query = "select TheLoai.MaTheLoai from TheLoai where TheLoai.TenTheLoai = N@matheloai";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@matheloai", tenheloai);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(query, con); //c.con is the connection string
                        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                        DataTable table = new DataTable();
                        table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                        object a = table.Rows[0]["MaTheLoai"];
                        matheloai = Convert.ToInt32(a);
                        dataAdapter.Fill(table);
                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                    }
                }
                return matheloai;
            }
        }
        public void gettheloai(DataGridView dataGridView)
        {
            string query = "select TheLoai.MaTheLoai as 'Mã thể loại', TheLoai.TenTheLoai as 'Tên thể loại' from TheLoai" ;

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
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter sqlDataAdap = new SqlDataAdapter(cmd);

                        DataTable dtRecord = new DataTable();
                        sqlDataAdap.Fill(dtRecord);
                        dataGridView.DataSource = dtRecord;
                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                    }
                }
            }
        }
        public bool kiemtra(string theloai)
        {
            DataTable dataTable = new DataTable();
            string query = "select * from TheLoai where TheLoai.TenTheLoai = @Theloai";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@theloai", theloai);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        // this will query your database and return the result to your datatable
                        da.Fill(dataTable);
                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                    }
                }
            }
            if (dataTable.Rows.Count == 0)
            {
                return true;
            }
            return false;
        }
        public int soluongtuasach()
        {
            DataTable dataTable = new DataTable();
            string query = "select * from TheLoai";
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
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        // this will query your database and return the result to your datatable
                        da.Fill(dataTable);
                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                    }
                }
            }
            int soluongtuasach = dataTable.Rows.Count;
            return soluongtuasach;
        }
    }
}
