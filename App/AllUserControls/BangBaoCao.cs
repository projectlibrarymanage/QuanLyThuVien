using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;

namespace App
{
    public partial class BangBaoCao : UserControl
    {
        MuonBUS muon = new MuonBUS();
        SachBUS sach = new SachBUS();
        public BangBaoCao()
        {
            InitializeComponent();
        }

        private void SaveAddBt_Click(object sender, EventArgs e)
        {
            dataGridThongke.Rows.Clear();
            int a = Convert.ToInt32(thangbaocaotxt.Text);


            sach.thongkesachmuon(dataGridThongke, a);
            foreach (DataGridViewRow row in dataGridThongke.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }
    }
}
