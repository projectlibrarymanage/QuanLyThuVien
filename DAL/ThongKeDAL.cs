using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DAL
{
    class ThongKeDAL
    {
        private string connectionString;

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        public ThongKeDAL()
        {
            connectionString = ConfigurationSettings.AppSettings["ConnectionString"];
        }
        //public bool Them( add)
        //{
        //    string query = string.Empty;
        //    query += "INSERT INTO DocGia ([MaSach], [MaDauSach], [TinhTrang])";
        //    query += "VALUES (@MaSach,@MaDauSach,@TinhTrang)";
        //    using (SqlConnection con = new SqlConnection(ConnectionString))
        //    {

        //        using (SqlCommand cmd = new SqlCommand())
        //        {
        //            cmd.Connection = con;
        //            cmd.CommandType = System.Data.CommandType.Text;
        //            cmd.CommandText = query;
        //            cmd.Parameters.AddWithValue("@MaSach", add.Masach);
        //            cmd.Parameters.AddWithValue("@MaDauSach", add.Madausach);
        //            cmd.Parameters.AddWithValue("@TinhTrang", add.Tinhtrang);
        //            try
        //            {
        //                con.Open();
        //                cmd.ExecuteNonQuery();
        //                con.Close();
        //                con.Dispose();
        //            }
        //            catch (Exception ex)
        //            {
        //                con.Close();
        //                return false;
        //            }
        //        }
        //    }
        //    return true;
        //}
    }
}
