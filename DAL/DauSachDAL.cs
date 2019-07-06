using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
namespace DAL
{
    public class DauSachDAL
    {
        private string connectionString;

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }
        public DauSachDAL()
        {
            connectionString = ConfigurationSettings.AppSettings["ConnectionString"];
        }
        public bool ADD(DauSachDTO dauSach)
        {
            string query = string.Empty;
            query += "INSERT [dbo].[DauSach] ([MaDauSach], [MaTuaSach], [NhaXB], [NamXB], [TriGia], [SoLuong]) " +
                "VALUES (@madausach, @matuasach, @nhaxb, @namxb, @trigia, @soluong)";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@madausach", dauSach.Madausach);
                    cmd.Parameters.AddWithValue("@matuasach", dauSach.Matuasach);
                    cmd.Parameters.AddWithValue("@nhaxb", dauSach.Nxb);
                    cmd.Parameters.AddWithValue("@namxb", dauSach.Namxb);
                    cmd.Parameters.AddWithValue("@trigia", dauSach.Trigia);
                    cmd.Parameters.AddWithValue("@soluong", dauSach.Soluong);
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
        public bool DELETE(DauSachDTO dauSach)
        {
            string query = string.Empty;
            query += "DELETE FROM DocGia WHERE [MaDauSach] = @madausach";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@madausach", dauSach.Madausach);
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
        public bool ALTER(DauSachDTO dauSach)
        {
            string query = string.Empty;

            query += "UPDATE [dbo].[DauSach] SET [MaDauSach] = @madausach, [MaTuaSach] = @matuasach , [NhaXB] = @nhaxb, [NamXB] = @namxb, [TriGia] =@trigia ";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@madausach", dauSach.Madausach);
                    cmd.Parameters.AddWithValue("@matuasach", dauSach.Matuasach);
                    cmd.Parameters.AddWithValue("@nhaxb", dauSach.Nxb);
                    cmd.Parameters.AddWithValue("@namxb", dauSach.Namxb);
                    cmd.Parameters.AddWithValue("@trigia", dauSach.Trigia);

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
        public bool check(string nxb, string namxb)
        {
            DataTable dataTable = new DataTable();
            string query = "select * from DauSach where DauSach.NhaXB = @nhaxb or DauSach.NamXB = @namxb";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@nhaxb", nxb);
                    cmd.Parameters.AddWithValue("@namxb", namxb);
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
                return false;
            }
            return true;
        }
        public int GetMaSach(string nhaxb, string nxb)
        {
            int matheloai = new int();
            string query = string.Empty;
            query = "select * from DauSach where DauSach.NhaXB = @nhaxb or DauSach.NamXB = @namxb";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@nhaxb", nxb);
                    cmd.Parameters.AddWithValue("@namxb", nxb);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(query, con); //c.con is the connection string
                        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                        DataTable table = new DataTable();
                        table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                        object a = table.Rows[0]["MaDauSach"];
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
        public int soluongDauSach()
        {
            DataTable dataTable = new DataTable();
            string query = "select * from DauSach";
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
            int soluongDauSach = dataTable.Rows.Count;
            return soluongDauSach;
        }
        public void gettacgia(DataGridView dataGridView, string info)
        {
            string query = "select TuaSach.MaTuaSach as 'Mã Tựa Sách',TuaSach.TuaSach as 'Tên Sách', DauSach.NhaXB as 'Nhà Xuất Bản', DauSach.NamXB as 'Năm Xuất Bản',DauSach.TriGia as 'Giá',DauSach.SoLuong as 'Số lượng',Sach.ngaynhap as 'Ngày nhập'from TuaSach, DauSach, Sach where TuaSach.TacGia = @tentacgia AND TuaSach.MaTuaSach = DauSach.MaTuaSach AND Sach.MaDauSach = DauSach.MaDauSach";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@tentacgia", info);
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
        public void gettheloai(DataGridView dataGridView, string info)
        {
            string query = "select TuaSach.MaTuaSach as 'Mã Tựa Sách',TuaSach.TuaSach as 'Tên Sách', DauSach.NhaXB as 'Nhà Xuất Bản', DauSach.NamXB as 'Năm Xuất Bản',DauSach.TriGia as 'Giá',DauSach.SoLuong as 'Số lượng',Sach.ngaynhap as 'Ngày nhập'from TuaSach, DauSach, Sach where TuaSach.TheLoai = @tentheloai AND AND TuaSach.MaTuaSach = DauSach.MaTuaSach AND Sach.MaDauSach = DauSach.MaDauSach";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@tentheloai", info);
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
    }
}
