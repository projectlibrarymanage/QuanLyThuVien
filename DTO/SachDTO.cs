using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SachDTO
    {
        private int masach;
        private int madausach;
        private string tinhtrang;

        public int Masach { get => masach; set => masach = value; }
        public int Madausach { get => madausach; set => madausach = value; }
        public string Tinhtrang { get => tinhtrang; set => tinhtrang = value; }
        public DateTime Ngaynhap { get => ngaynhap; set => ngaynhap = value; }
        public int Nam { get => nam; set => nam = value; }

        private int nam  = 8;
        private DateTime ngaynhap;
    }
}
