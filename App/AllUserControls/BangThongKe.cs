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

namespace App.AllUserControls
{
    public partial class BangThongKe : UserControl
    {
        MuonBUS muon = new MuonBUS();
       

        public BangThongKe()
        {
            InitializeComponent();
        }
        
        private void SaveAddBt_Click(object sender, EventArgs e)
        {
            dataGridThongke.Rows.Clear();
          


            muon.thongkesachtratre(dataGridThongke);
            foreach (DataGridViewRow row in dataGridThongke.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }
    }
}
