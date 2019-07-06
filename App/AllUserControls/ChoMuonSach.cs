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
    public partial class ChoMuonSach : UserControl
    {
        MuonBUS muon = new MuonBUS();
        SachBUS sach = new SachBUS();

        public ChoMuonSach()
        {
            InitializeComponent();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void SaveEditButton_Click(object sender, EventArgs e)
        {
            if (KiemTra() == true)
            {
                MuonDTO muonDTO = new MuonDTO();               
                muonDTO.Masach = Convert.ToInt32(Masachtxt.Text);
                muonDTO.Madocgia = Convert.ToInt32(Madocgiatxt.Text);
                muonDTO.Madausach = 1;
                muonDTO.Ngaymuon = Ngaymuondate.Value;
                muonDTO.Ngayhethan = ngaytradate.Value;
                bool kthan = muon.Kiemtraconhan(muonDTO.Madocgia);
              
                
           
            
                bool result = muon.Them(muonDTO);
                if (result == false)
                {
                    MessageBox.Show("Thêm sách thất bại vui lòng kiểm tra lại", "Message");
                }
                if (result == true)
                {
                    MessageBox.Show("Thêm sách thành công", "Message");
                    
                   
                }
            }
            else
            {
                MessageBox.Show("Có giá trị trống", "Message");
            }
        }

        private bool KiemTra()
        {
            if ((Madocgiatxt.Text == "") || (Masachtxt.Text == "") || (Ngaymuondate.Text == "")
                || ngaytradate.Text == "" )
                return false;
            return true;
        }

        private void AddBt_Click(object sender, EventArgs e)
        {
           
            dataGridViewMuon.Rows.Clear();
            string a = Tensachtxt.Text;
            string b = theloaicombo.Text;
            string c = tacgiatxt.Text;
            
           
            sach.TimSach(dataGridViewMuon, a, b, c);
            foreach (DataGridViewRow row in dataGridViewMuon.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }

        private void dataGridViewMuon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridViewMuon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }
        int index;
        private void dataGridViewMuon_Click(object sender, EventArgs e)
        {
            //index = dataGridViewMuon.CurrentRow.Index;          
            //Tensachtxt.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            //theloaicombo.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            //tacgiatxt.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
        }

        private void dataGridViewMuon_SelectionChanged(object sender, EventArgs e)
        {
            Tensachtxt.Text = dataGridViewMuon[ 1 , dataGridViewMuon.CurrentRow.Index].Value.ToString();
            theloaicombo.Text = dataGridViewMuon[2, dataGridViewMuon.CurrentRow.Index].Value.ToString();
            tacgiatxt.Text = dataGridViewMuon[3, dataGridViewMuon.CurrentRow.Index].Value.ToString();
            Masachtxt.Text= dataGridViewMuon[0, dataGridViewMuon.CurrentRow.Index].Value.ToString();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

       

        private void Ngaymuondate_ValueChanged(object sender, EventArgs e)
        {
            DateTime gioihangiatri = Ngaymuondate.Value.AddDays(4);

            ngaytradate.Value = new DateTime(gioihangiatri.Year, gioihangiatri.Month, gioihangiatri.Day);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridViewMuon.Rows.Clear();
            sach.LoadSach(dataGridViewMuon);
            foreach (DataGridViewRow row in dataGridViewMuon.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }
    }
}
