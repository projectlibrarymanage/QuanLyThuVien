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
    public class SachBUS
    {
        private SachDAL sachDAL;
        public SachBUS()
        {
            sachDAL = new SachDAL();
        }
        public bool Them(SachDTO dg)
        {
            bool re = sachDAL.Them(dg);
            return re;
        }
        public bool Xoa(SachDTO kn)
        {
            bool re = sachDAL.Xoa(kn);
            return re;
        }

        public bool Sua(SachDTO kn)
        {
            bool re = sachDAL.Sua(kn);
            return re;
        }
        public bool TimSach(DataGridView dataGridView1,string skeyTenSach, string skeyTenTheLoai, string skeyTenTacGia)
        {
            bool result = sachDAL.TimSach(dataGridView1,skeyTenSach,skeyTenTheLoai,skeyTenTacGia);
            return result;
        }
        public bool LoadSach(DataGridView dataGridView1)
        {
            bool result = sachDAL.LoadSach(dataGridView1);
            return result;
        }
        public bool thongkesachmuon(DataGridView dataGridView1, int thangthongke)
        {
            bool re = sachDAL.thongkesachmuon(dataGridView1, thangthongke);
            return re;
        }
        public void GetListSach(DataGridView dataGridView)
        {
            sachDAL.GetListSach(dataGridView);
        }
        public int soluongsach()
        {
            int n = sachDAL.soluongsach();
            return n;
        }
    }
}
