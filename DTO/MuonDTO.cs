using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MuonDTO
    {
        private int masach;
        private int madausach;
        private int madocgia;
        private DateTime ngaymuon;
        private DateTime ngayhethan;

        public int Masach { get => masach; set => masach = value; }
        public int Madausach { get => madausach; set => madausach = value; }
        public int Madocgia { get => madocgia; set => madocgia = value; }
        public DateTime Ngaymuon { get => ngaymuon; set => ngaymuon = value; }
        public DateTime Ngayhethan { get => ngayhethan; set => ngayhethan = value; }
    }
}
