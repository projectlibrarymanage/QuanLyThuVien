using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThongKeDTO
    {
        private int masach;
        private int thang;
        private DateTime ngaymuon;
        private DateTime ngayhethan;
        private int soluong;

        public int Masach { get => masach; set => masach = value; }     
        public DateTime Ngaymuon { get => ngaymuon; set => ngaymuon = value; }
        public DateTime Ngayhethan { get => ngayhethan; set => ngayhethan = value; }
        public int Thang { get => thang; set => thang = value; }
        public int Soluong { get => soluong; set => soluong = value; }
    }
}
