using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace App.AllUserControls
{
    public partial class TraSach : UserControl
    {
        MuonBUS muon = new MuonBUS();
        MuonDTO muonDTO = new MuonDTO();
        public TraSach()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(textBox6.Text);
            dataGridTraSach.Rows.Clear();
            muon.TimSachMuon(dataGridTraSach, a);
            foreach (DataGridViewRow row in dataGridTraSach.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }

        private void dataGridTraSach_SelectionChanged(object sender, EventArgs e)
        {
            textBox7.Text = dataGridTraSach[0, dataGridTraSach.CurrentRow.Index].Value.ToString();
            tensachtxt.Text = dataGridTraSach[1, dataGridTraSach.CurrentRow.Index].Value.ToString();
        
        }

        private void SaveAddBt_Click(object sender, EventArgs e)
        {
           
            int masach = Convert.ToInt32(textBox7.Text);
            int madocgia = Convert.ToInt32(textBox6.Text);                      
            bool kthan = muon.Kiemtraconhan(muonDTO.Madocgia);
            bool result = muon.Xoa(madocgia,masach);
            if (result == false)
            {
                MessageBox.Show("Xóa thất bại", "Message");
            }
            if (result == true)
            {
                MessageBox.Show("Xoa thành công", "Message");


            }
        }
          
    }
}


