using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class TacGiaBUS
    {
        private TacGiaDAL TgDAL;
        public TacGiaBUS()
        {
            TgDAL = new TacGiaDAL();
        }
        public bool Them(TacGiaDTO tg)
        {
            bool re = TgDAL.Them(tg);
            return re;
        }
        public bool Xoa(TacGiaDTO kn)
        {
            bool re = TgDAL.Xoa(kn);
            return re;
        }

        public bool Sua(TacGiaDTO kn)
        {
            bool re = TgDAL.Sua(kn);
            return re;
        }
        public int mathetacgia(string tentacgia)
        {
            int matacgia;
            matacgia = TgDAL.GetMaTacGia(tentacgia);
            return matacgia;
        }
        public void load(ComboBox comboBox)
        {
            TgDAL.Loaddanhsachtg(comboBox);
        }
    }
}
