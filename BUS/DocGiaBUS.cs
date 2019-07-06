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
    public class DocGiaBUS
    {
        private DocGiaDAL DgDAL;
        public DocGiaBUS()
        {
            DgDAL = new DocGiaDAL();
        }
        public bool Them(DocGiaDTO dg)
        {
            bool re = DgDAL.Them(dg);
            return re;
        }
        public bool Xoa(DocGiaDTO kn)
        {
            bool re = DgDAL.Xoa(kn);
            return re;
        }

        public bool Sua(DocGiaDTO kn)
        {
            bool re = DgDAL.Sua(kn);
            return re;
        }
        public List<DocGiaDTO> select()
        {
            return DgDAL.select();
        }

        public void Getlistreader(DataGridView dataGridView1 )
        {
            DgDAL.GetListReader(dataGridView1);
        }

        public void Getlistma(DataGridView dataGridView, string ma)
        {
            DgDAL.listreaderMa(dataGridView, ma);
        }

        public void getlistten(DataGridView dataGridView, string ten)
        {
            DgDAL.listreaderTen(dataGridView, ten);
        }
    }
}
