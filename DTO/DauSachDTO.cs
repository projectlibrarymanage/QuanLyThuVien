using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DauSachDTO
    {
        private int madausach;
        private int matuasach;
        private string nxb;
        private string namxb;
        private float trigia;
        private int soluong;

        public int Madausach { get => madausach; set => madausach = value; }
        public int Matuasach { get => matuasach; set => matuasach = value; }
        public string Nxb { get => nxb; set => nxb = value; }
        public string Namxb { get => namxb; set => namxb = value; }
        public float Trigia { get => trigia; set => trigia = value; }
        public int Soluong { get => soluong; set => soluong = value; }
    }
}
