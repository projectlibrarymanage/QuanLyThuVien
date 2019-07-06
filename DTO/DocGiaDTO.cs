using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DocGiaDTO
    {
        //public DocGiaDTO (string madocgia, string hoten, DateTime ngaysinh, string diachi, string email, string loaidocgia, DateTime ngaylapthe, DateTime cogiatri)
        //{
        //    this.Madocgia = madocgia;
        //    this.Hoten = hoten;
        //    this.Ngaysinh = ngaysinh;
        //    this.Diachi = diachi;
        //    this.Email = email;
        //    this.Loaidocgia = loaidocgia;
        //    this.Ngaylapthe = ngaylapthe;
        //    this.Cogiatri = cogiatri;
        //}

        //public DocGiaDTO(DataRow row )
        //{
        //    this.Madocgia = row["Mã độc giả"].ToString();
        //    this.Hoten = row["Họ tên"].ToString();
        //    this.Ngaysinh = (DateTime)Convert.ToDateTime(row["Ngày sinh"].ToString());
        //    this.Diachi = row["Địa chỉ"].ToString();
        //    this.Email = row["Email"].ToString();
        //    this.Loaidocgia = row["Loại độc giả"].ToString();
        //    this.Ngaylapthe = (DateTime)Convert.ToDateTime(row["Ngày lập thẻ"].ToString());
        //    this.Cogiatri = (DateTime)Convert.ToDateTime(row["Có giá trị đến"].ToString());
        //}

        private string madocgia;
        private string hoten;
        private DateTime ngaysinh;
        private string diachi;
        private string email;
        private string loaidocgia;
        private DateTime ngaylapthe;
        private DateTime cogiatri;

        public string Madocgia
        {
            get { return madocgia; }
            set { madocgia = value; }
        }
        public string Hoten
        {
            get { return hoten; }
            set { hoten = value; }
        }
        public DateTime Ngaysinh
        {
            get { return ngaysinh; }
            set { ngaysinh = value; }
        }
        public string Diachi
        {
            get { return diachi; }
            set { diachi = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Loaidocgia
        {
            get { return loaidocgia; }
            set { loaidocgia = value; }
        }
        public DateTime Ngaylapthe
        {
            get { return ngaylapthe; }
            set { ngaylapthe = value; }
        }
        public DateTime Cogiatri
        {
            get { return cogiatri; }
            set { cogiatri = value; }
        }
    }
}
