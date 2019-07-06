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
    public class MuonDAL
    {
        private string connectionString;

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        public MuonDAL()
        {

            connectionString = ConfigurationSettings.AppSettings["ConnectionString"];

        }
        //public string ConnectionString { get => connectionString; set => connectionString = value; }

        public bool Them(MuonDTO add)
        {
            string query = string.Empty;           
            query += "INSERT INTO Muon (MaSach, MaDauSach, MaDocGia, NgayMuon, NgayHetHan) ";
            query += "VALUES (@MaSach,@MaDauSach,@MaDocGia,@NgayMuon,@NgayHetHan)";
            string queryup = string.Empty;
            queryup += "UPDATE Sach Set TinhTrang = N'Hết' Where MaSach = @MaSach";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@MaSach", add.Masach);
                    cmd.Parameters.AddWithValue("@MaDauSach", add.Madausach);
                    cmd.Parameters.AddWithValue("@MaDocGia", add.Madocgia);
                    cmd.Parameters.AddWithValue("@NgayMuon", add.Ngaymuon);
                    cmd.Parameters.AddWithValue("@NgayHetHan", add.Ngayhethan);
                    if (kiemtraconhan(add.Madocgia) == false)
                    {
                        MessageBox.Show("Thẻ độc giả hết hạn", "Message");
                        return false;
                    }
                    if (kiemtrasoluongsachmuon(add.Madocgia) == false)
                    {
                        MessageBox.Show("Số sách mượn hiện tài lớn hơn 5", "Message");
                        return false;
                    }
                    if (kiemtratinhtrangsach(add.Masach) == false)
                    {
                        MessageBox.Show("Sách đang có người mượn ", "Message");
                        return false;
                    }
                    if (CapNhatBangThongKe(add)==false)
                    {
                        MessageBox.Show("Cập nhật không thành công ", "Message");
                        return false;
                    }
                    //if (kiemtrasachmuonquahan(add.Madocgia)==false)
                    //{
                    //    MessageBox.Show("Độc giả chưa trả sách ", "Message");
                    //    return false;
                    //}
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
                using (SqlConnection con1 = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd1 = new SqlCommand())
                    {
                        cmd1.Connection = con1;
                        cmd1.CommandType = System.Data.CommandType.Text;
                        cmd1.CommandText = queryup;
                        cmd1.Parameters.AddWithValue("@MaSach", add.Masach);
                        try
                        {
                            con1.Open();
                            cmd1.ExecuteNonQuery();
                            con1.Close();
                            con1.Dispose();
                        }
                        catch (Exception ex)
                        {
                            con1.Close();
                            return false;
                        }
                    }
                }
                return true;




            }
        }

        public bool Xoa (int madocgia, int masach)
        {
            string query = string.Empty;
            query += "DELETE FROM Muon WHERE [MaDocGia] = @MaDocGia AND [MaSach] = @MaSach " ;
            string queryup = string.Empty;
            queryup += "UPDATE Sach Set TinhTrang = N'Còn' Where MaSach = @MaSach";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@MaDocGia", madocgia);
                    cmd.Parameters.AddWithValue("@MaSach", masach);
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
                using (SqlConnection con1 = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd1 = new SqlCommand())
                    {
                        cmd1.Connection = con1;
                        cmd1.CommandType = System.Data.CommandType.Text;
                        cmd1.CommandText = queryup;
                        cmd1.Parameters.AddWithValue("@MaSach", masach);
                        try
                        {
                            con1.Open();
                            cmd1.ExecuteNonQuery();
                            con1.Close();
                            con1.Dispose();
                        }
                        catch (Exception ex)
                        {
                            con1.Close();
                            return false;
                        }
                    }
                }
                return true;
            }
            return true;
        }
        public bool kiemtraconhan (int madocgia)
        {
            DataTable dataTable = new DataTable();
            string query = string.Empty;
            query += "Select* from DocGia where MaDocGia = @MaDocGia AND((DATEDIFF(MONTH, DocGia.NgayLapThe, GETDATE()))>6)";           
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@MaDocGia", madocgia);                  
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
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

        public bool kiemtrasoluongsachmuon(int madocgia)
        {
            DataTable dataTable = new DataTable();
            string query = string.Empty;
            query += "Select * from Muon where MaDocGia = @MaDocGia";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@MaDocGia", madocgia);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
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
            if (dataTable.Rows.Count < 5)
            {
                return true;
            }
            return false;
        }
        public bool kiemtratinhtrangsach(int masach)
        {
            DataTable dataTable = new DataTable();
            string query = string.Empty;
            query += "Select * from Sach where MaSach = @MaSach AND TinhTrang= N'Còn'" ;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@MaSach", masach);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
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

        public bool kiemtrasachmuonquahan(int madocgia)
        {
            DataTable dataTable = new DataTable();
            string query = string.Empty;
            query += "Select * from Muon where MaDocGia = @MaDocGia AND DATEDIFF(DAY,Muon.NgayHetHan,GETDATE())>4 ";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@MaDocGia", madocgia);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
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
            if (dataTable.Rows.Count > 0)
            {
                return false;
            }
            return true;
        }
        public bool CapNhatBangThongKe(MuonDTO add)
        {
            string query = string.Empty;
            query += "INSERT INTO ThongKe (Thang, MaSach, NgayMuon, NgayHetHan) VALUES(@Thang, @MaSach, @NgayMuon, @NgayHetHan)";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@Thang", add.Ngaymuon.Month);
                    cmd.Parameters.AddWithValue("@MaSach", add.Masach);
                    cmd.Parameters.AddWithValue("@NgayMuon", add.Ngaymuon);
                    cmd.Parameters.AddWithValue("@NgayHetHan", add.Ngayhethan);
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
        public bool thongkesachtratre(DataGridView dataGridView1)
        {
            string query = string.Empty;
            //query += "SELECT * FROM Sach";
            query += "SELECT ts.TuaSach, m.NgayMuon, ((day(GETDATE()-m.NgayMuon))-4) ";
            query += "from TheLoai tl, Sach s, Muon m, TuaSach ts, DauSach ds  ";
            query += " WHERE s.MaSach=m.MaSach  ";
            query += " AND s.MaDauSach=ds.MaDauSach ";
            query += " AND ds.MaTuaSach=ts.MaTuaSach ";
            query += " AND ts.MaTheLoai=tl.MaTheLoai ";
            query += " AND (day(GETDATE()-m.NgayMuon) > 4) ";
            
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
                            dataGridView1.Rows.Add(reader.GetString(0), Convert.ToDateTime(reader.GetDateTime(1)), reader.GetInt32(2));

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
        public bool TimSachMuon (DataGridView dataGridView1, int keymadocgia)
        {
            string query = string.Empty;
            //query += "SELECT * FROM Sach";
            query += "SELECT m.MaSach, ts.TuaSach ";
            query += "FROM Sach s, TuaSach ts, TacGia tg, TheLoai tl, DauSach ds, Muon m ";
            query += " WHERE m.MaSach=s.MaSach AND s.MaDauSach=ds.MaDauSach AND ds.MaTuaSach=ts.MaTuaSach AND ts.MaTacGia=tg.MaTacGia AND tl.MaTheLoai=ts.MaTheLoai";
            query += " AND  m.MaDocGia = @Madocgia ";          
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {

                    command.Connection = con;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@MaDocGia", keymadocgia);                 
                    try
                    {
                        con.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.HasRows)//con dong du lieu thi doc tiep
                        {
                            if (reader.Read() == false) return false;//doc ko duoc thi return
                                                                     //xu ly khi da doc du lieu len
                            dataGridView1.Rows.Add(reader.GetInt32(0), reader.GetString(1));

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

        ///dataGridView1.Rows.Add(reader.GetString(0), reader.GetDateTime(1), reader.GetDateTime(2));
        //        Convert.ToDateTime(reader.GetDateTime(1))





    }
}
