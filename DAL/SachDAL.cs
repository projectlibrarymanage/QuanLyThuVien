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
    public class SachDAL
    {
        private string connectionString;

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        public SachDAL()
        {
            connectionString = ConfigurationSettings.AppSettings["ConnectionString"];
        }
        public bool Them(SachDTO add)
        {
            string query = string.Empty;
            query += "INSERT INTO Sach ([MaSach], [MaDauSach], [TinhTrang], [ngaynhap]) ";
            query += "VALUES (@MaSach,@MaDauSach,@TinhTrang,@ngaynhap)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@MaSach", add.Masach);
                    cmd.Parameters.AddWithValue("@MaDauSach", add.Madausach);
                    cmd.Parameters.AddWithValue("@TinhTrang", add.Tinhtrang);
                    cmd.Parameters.AddWithValue("@ngaynhap", add.Ngaynhap);
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
        public bool Xoa(SachDTO del)
        {
            string query = string.Empty;
            query += "DELETE FROM Sach WHERE [MaSach] = @Masach";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@MaSach", del.Masach);
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
        public bool Sua(SachDTO edit)
        {
            string query = string.Empty;
            query += "UPDATE DocGia SET [MaSach] = @MaSach, [MaDauSach] = @MaDauSach, [TinhTrang] = @TinhTrang";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@MaSach", edit.Masach);
                    cmd.Parameters.AddWithValue("@MaDauSach", edit.Madausach);
                    cmd.Parameters.AddWithValue("@TinhTrang", edit.Tinhtrang);
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
        public bool TimSach(DataGridView dataGridView1, string keyTensach, string keyTenTheLoai, string keyTenTacGia)
        {
            string query = string.Empty;
            //query += "SELECT * FROM Sach";
            query += "SELECT s.MaSach, ts.TuaSach, tg.TenTheLoai, tl.TenTacGia, s.TinhTrang ";
            query += "FROM Sach s, TuaSach ts, TacGia tg, TheLoai tl, DauSach ds";
            query += " WHERE s.MaDauSach=ds.MaDauSach AND ds.MaTuaSach=ts.MaTuaSach AND ts.MaTacGia=tg.MaTacGia AND tl.MaTheLoai=ts.MaTheLoai";
            query += " AND ( ts.TuaSach = @TenSach";
            query += " OR tl.TenTheLoai = @TenTheLoai";
            query += " OR tg.TenTacGia = @TenTacGia)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {

                    command.Connection = con;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@TenSach", keyTensach);
                    command.Parameters.AddWithValue("@TenTheLoai", keyTenTheLoai);
                    command.Parameters.AddWithValue("@TenTacGia", keyTenTacGia);
                    try
                    {
                        con.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.HasRows)//con dong du lieu thi doc tiep
                        {
                            if (reader.Read() == false) return false;//doc ko duoc thi return
                                                                     //xu ly khi da doc du lieu len
                            dataGridView1.Rows.Add(reader.GetInt32(0), reader.GetString(1),
                                                    reader.GetString(2), reader.GetString(3));

                        }
                        con.Close();
                        con.Dispose();
                    }
                    catch (SqlException)
                    {
                        con.Close();
                        return false;
                    }
                }
            }
            return true;
        }

        public bool LoadSach(DataGridView dataGridView1)
        {
            string query = string.Empty;
            //query += "SELECT * FROM Sach";
            query += "SELECT s.MaSach, ts.TuaSach, tl.TenTheLoai, tg.TenTacGia,s.TinhTrang ";
            query += "FROM Sach s, TuaSach ts, TacGia tg, TheLoai tl, DauSach ds";
            query += " WHERE s.MaDauSach=ds.MaDauSach AND ds.MaTuaSach=ts.MaTuaSach AND ts.MaTacGia=tg.MaTacGia AND tl.MaTheLoai=ts.MaTheLoai";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {

                    command.Connection = con;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = query;
                    try
                    {
                        con.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.HasRows)//con dong du lieu thi doc tiep
                        {
                            if (reader.Read() == false) return false;//doc ko duoc thi return
                                                                     //xu ly khi da doc du lieu len
                            dataGridView1.Rows.Add(reader.GetInt32(0), reader.GetString(1),
                                                    reader.GetString(2), reader.GetString(3),
                                                    reader.GetString(4));

                        }
                        con.Close();
                        con.Dispose();
                    }
                    catch (SqlException)
                    {
                        con.Close();
                        return false;
                    }
                }
            }
            return true;
        }
        public bool thongkesachmuon(DataGridView dataGridView1, int thangthongke)
        {
            string query = string.Empty;
            //query += "SELECT * FROM Sach";
            query += "SELECT tl.TenTheLoai, count (tk.MaSach) ";
            query += "from TheLoai tl, Sach s, ThongKe tk, TuaSach ts, DauSach ds ";
            query += " WHERE s.MaSach=tk.MaSach ";
            query += " AND s.MaDauSach=ds.MaDauSach ";    
            query += " AND ds.MaTuaSach=ts.MaTuaSach ";
            query += " AND ts.MaTheLoai=tl.MaTheLoai ";
            query += " AND MONTH(tk.NgayMuon) = @Thang ";
            query += " Group By tl.TenTheLoai";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {

                    command.Connection = con;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = query;              
                    command.Parameters.AddWithValue("@Thang", thangthongke);
                    try
                    {
                        con.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.HasRows)//con dong du lieu thi doc tiep
                        {
                            if (reader.Read() == false) return false;//doc ko duoc thi return
                                                                     //xu ly khi da doc du lieu len
                            dataGridView1.Rows.Add(reader.GetString(0), reader.GetInt32(1));

                        }
                        con.Close();
                        con.Dispose();
                    }
                    catch (SqlException)
                    {
                        con.Close();
                        return false;
                    }
                }
            }
            return true;
        }
        public void GetListSach(DataGridView datagridview)
        {
            string query = string.Empty;
            query = "select Sach.MaSach , DauSach.NhaXB , DauSach.NamXB, DauSach.TriGia ," +
                " TuaSach.TuaSach , TheLoai.TenTheLoai, TacGia.TenTacGia " +
                " FROM Sach, DauSach, TuaSach, TheLoai, TacGia " +
                "WHERE Sach.MaDauSach = DauSach.MaDauSach AND DauSach.MaTuaSach = TuaSach.MaTuaSach " +
                "AND TuaSach.MaTheLoai = TheLoai.MaTheLoai AND TuaSach.MaTacGia = TacGia.MaTacGia ";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = con;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = query;
                    try
                    {
                        con.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.HasRows)//con dong du lieu thi doc tiep
                        {
                            if (reader.Read() == false) return;//doc ko duoc thi return
                                                               //xu ly khi da doc du lieu len
                            datagridview.Rows.Add(reader.GetString(0), reader.GetString(4),
                                                    reader.GetString(5), reader.GetString(6),
                                                    reader.GetString(1), reader.GetString(2),
                                                    reader.GetString(6), reader.GetDateTime(3));

                        }
                        con.Close();
                        con.Dispose();
                    }
                    catch (SqlException)
                    {
                        con.Close();
                        return;
                    }
                }
            }
            return;
        }
        public int soluongsach()
        {
            DataTable dataTable = new DataTable();
            string query = "select * from Sach";
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
            int soluongsach = dataTable.Rows.Count;
            return soluongsach;
        }
    }
}

