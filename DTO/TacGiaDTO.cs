using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TacGiaDTO
    {
        private string matacgia;
        private string tentacgia;
        private string quequan;

        public string Matacgia { get => matacgia; set => matacgia = value; }
        public string Tentacgia { get => tentacgia; set => tentacgia = value; }
        public string Quequan { get => quequan; set => quequan = value; }
    }
}
