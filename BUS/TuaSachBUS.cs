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
    public class TuaSachBUS
    {
        private TuaSachDAL TsDAL;
        public TuaSachBUS()
        {
            TsDAL = new TuaSachDAL();
        }
        public bool Them(TuaSachDTO dg)
        {
            bool re = TsDAL.Them(dg);
            return re;
        }
        public bool Xoa(TuaSachDTO kn)
        {
            bool re = TsDAL.Xoa(kn);
            return re;
        }

        public bool Sua(TuaSachDTO kn)
        {
            bool re = TsDAL.Sua(kn);
            return re;
        }    
        public bool kiemtra(string tuasach)
        {
            bool re = TsDAL.kiemtra(tuasach);
            return re;
        }
        public int soluong()
        {
            int sl = TsDAL.soluongtuasach();
            return sl;
        }
        public int getmatuasach(string ten)
        {
            int matua = TsDAL.GetTuaSach(ten);
            return matua;
        }
        public void getdata(DataGridView dataGridView, string ten)
        {
            TsDAL.getdata(dataGridView, ten);
        }
    }
}
