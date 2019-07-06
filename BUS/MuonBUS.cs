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
    public class MuonBUS
    {
        private MuonDAL DgDAL;

        public MuonBUS()
        {
            DgDAL = new MuonDAL();
        }
        public bool Them(MuonDTO dg)
        {
            bool re = DgDAL.Them(dg);
            return re;
        }
        public bool Xoa(int a, int s)
        {
            bool re = DgDAL.Xoa(a,s);
            return re;
        }
        public bool Kiemtraconhan(int madocgia)
        {
            bool re = DgDAL.kiemtraconhan(madocgia);
            return re;
                
        }
        public bool thongkesachtratre(DataGridView dt)
        {
            bool re = DgDAL.thongkesachtratre(dt);
            return re;
        }
        public bool TimSachMuon(DataGridView dataGridView1, int keymadocgia)
        {
            bool re = DgDAL.TimSachMuon(dataGridView1, keymadocgia);
            return re;
        }









}
    
       
    
}
