using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using DTO;
namespace BUS
{
    public class DauSachBUS
    {
        private DauSachDAL DauSach;
        public DauSachBUS()
        {
            DauSach = new DauSachDAL();
        }
        public bool add(DauSachDTO ds)
        {
            bool re = DauSach.ADD(ds);
            return re;
        }
        public bool delete(DauSachDTO ds)
        {
            bool re = DauSach.DELETE(ds);
            return re;
        }
        public bool alter(DauSachDTO ds)
        {
            bool re = DauSach.ALTER(ds);
            return re;
        }
        public bool check(string nhaxb, string namxb)
        {
            bool re = DauSach.check(nhaxb, namxb);
            return re;
        }
        public int GetMaSach(string nxb, string namxb)
        {
            int ma = DauSach.GetMaSach(nxb, namxb);
            return ma;
        }
        public int getds()
        {
            int n = DauSach.soluongDauSach();
            return n;
        }
        public void gettacgia(DataGridView dataGridView, string info)
        {
            DauSach.gettacgia(dataGridView, info);
        }
        public void gettheloai(DataGridView dataGridView, string info)
        {
            DauSach.gettheloai(dataGridView, info);
        }
    }
}
