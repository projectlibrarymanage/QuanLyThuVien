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
    public class TacGiaDAL
    {
        private string connectionString;

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        public TacGiaDAL()
        {
            connectionString = ConfigurationSettings.AppSettings["ConnectionString"];
        }
        //public string ConnectionString { get => connectionString; set => connectionString = value; }

        public bool Them(TacGiaDTO add)
        {
            string query = string.Empty;
            query += "INSERT INTO TacGia ([Matacgia], [Tentacgia], [Quenquan])";
            query += "VALUES (@Matacgia,@Hoten,@Quenquan)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@Matacgia", add.Matacgia);
                    cmd.Parameters.AddWithValue("@Hoten", add.Tentacgia);
                    cmd.Parameters.AddWithValue("@Quenquan", add.Quequan);              
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

        public bool Xoa(TacGiaDTO del)
        {
            string query = string.Empty;
            query += "DELETE FROM TacGia WHERE [Matacgia] = @Matacgia";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@Matacgia", del.Matacgia);
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

        public bool Sua(TacGiaDTO edit)
        {
            string query = string.Empty;
            query += "UPDATE TacGia SET [Tentacgia] = @Tentacgia, [Quequan] = @Quequan WHERE [Matacgia] = @Matacgia";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@Matacgia", edit.Matacgia);
                    cmd.Parameters.AddWithValue("@Tentacgia", edit.Tentacgia);
                    cmd.Parameters.AddWithValue("@Quequan", edit.Quequan);
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
        public int GetMaTacGia(string tentacgia)
        {
            int matacgia = new int();
            string query = string.Empty;
            query = "select TacGia.MaTacGia from TacGia where TacGia.TenTacGia = N@tentacgia";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue(@tentacgia, tentacgia);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(query, con); //c.con is the connection string
                        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                        DataTable table = new DataTable();
                        table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                        object a = table.Rows[0]["MaTacGia"];
                        matacgia = Convert.ToInt32(a);
                        dataAdapter.Fill(table);
                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                    }
                }
                return matacgia;
            }
        }
        public void Loaddanhsachtg(ComboBox comboBox)
        {
            string query = "select * from TacGia";
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
                        SqlDataReader drd = cmd.ExecuteReader();

                        while (drd.Read())
                        {
                            comboBox.Items.Add(drd.GetString(1).ToString());
                        }
                        //cbSupportID.DisplayMember = "supportID";
                        //cmd.ExecuteNonQuery();
                        
                        
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
