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
    public partial class SAch : UserControl
    {
        TheLoaiBUS theLoai = new TheLoaiBUS();
        TheLoaiDTO TheLoaiDTO = new TheLoaiDTO();
        public SAch()
        {
            InitializeComponent();
            theLoai.getlist(dataGridView1);
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (theLoai.kiemtra(theloai_tb.Text) == true)
            {
                // them the loai
                TheLoaiDTO.Matheloai = Convert.ToString(theLoai.soluong() + 1);
                TheLoaiDTO.Tentheloai = theloai_tb.Text;
                theLoai.Them(TheLoaiDTO);
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Thể Loại Đã Tồn Tại", "Lỗi", MessageBoxButtons.OK);
            }
                
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            ma.Text = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            ten.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            TheLoaiDTO.Matheloai = ma.Text;
            TheLoaiDTO.Tentheloai = ten.Text;
            ten.Enabled = true;
            theLoai.Sua(TheLoaiDTO);
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            
        }
    }
}
