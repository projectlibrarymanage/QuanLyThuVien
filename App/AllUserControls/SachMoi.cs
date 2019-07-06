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
namespace App
{
    public partial class SachMoi : UserControl
    {
        TuaSachBUS tuasach = new TuaSachBUS();
        SachBUS list = new SachBUS();
        TheLoaiBUS theLoai = new TheLoaiBUS();
        TacGiaBUS tacGia = new TacGiaBUS();
        SachBUS sach = new SachBUS();
        DauSachBUS DauSach = new DauSachBUS();
        public SachMoi()
        {           
            InitializeComponent();
            tacGia.load(tacgia_cb);
        }

        private void SaveAddBt_Click(object sender, EventArgs e)
        {
        }
        public int MaTuDongTuaSach(string ts)
        {
            int maTuDong = new int();
            if (tuasach.kiemtra(ts) == true)
            {
                int n = tuasach.soluong();
                maTuDong = n + 1;
            }
            if (tuasach.kiemtra(ts) == false)
            {
                maTuDong = tuasach.getmatuasach(ts);
            }
            return maTuDong;
        }
        public int MaTuDongSach()
        {
            int maTuDongsach;
            {
                int n = sach.soluongsach();
                maTuDongsach = n + 1;
            }
            return maTuDongsach;
        }


        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Themsach_pn.Visible = false;

        }

        private void Them_bt_Click(object sender, EventArgs e)
        {

        }

        private void Them_bt_Click_1(object sender, EventArgs e)
        {
            if (DauSach.check(nxb_tb.Text, namxb_tb.Text) == true && tuasach.kiemtra(tensach_tb.Text) == false)
            {
                MessageBox.Show("Đã tồn tại");
            }
            else
            {
                TuaSachDTO tuaSach = new TuaSachDTO();
                tuaSach.Matacgia = Convert.ToString(tacGia.mathetacgia(tacgia_cb.Text) + 1);
                tuaSach.Matheloai = Convert.ToString(theLoai.matheloai(theloai_cb.Text) + 1);
                tuaSach.Matuasach = MaTuDongTuaSach(tensach_tb.Text);
                tuaSach.Tuasach = tensach_tb.Text;

                DauSachDTO dauSach = new DauSachDTO();
                dauSach.Namxb = namxb_tb.Text;
                dauSach.Nxb = nxb_tb.Text;
                dauSach.Soluong = Convert.ToInt32(soluong_tb.Text);
                dauSach.Madausach = DauSach.getds() + 1;
                dauSach.Matuasach = tuaSach.Matuasach;
                dauSach.Trigia = float.Parse(namxb_tb.Text);

                SachDTO sach = new SachDTO();
                sach.Madausach = dauSach.Madausach;
                //sach.Masach = MaTuDongSach();
                sach.Tinhtrang = "Còn";
                sach.Ngaynhap = Convert.ToDateTime(DateTime.Now);
                ngaynhap.Value = DateTime.Now;
                // neu tua sach khac thi them tat ca
                int soluongsach = list.soluongsach();               
                int year = sach.Ngaynhap.Year - Convert.ToInt32(namxb_tb.Text);
                if (year > sach.Nam)
                {
                    MessageBox.Show("Chỉ nhập sách trong vòng 8 năm", "Lỗi", MessageBoxButtons.OK);
                }
                else
                {
                    if (tuasach.kiemtra(tensach_tb.Text) == true)
                    {
                        tuasach.Them(tuaSach);
                        DauSach.add(dauSach);
                        for (int i = soluongsach; i < soluongsach + dauSach.Soluong; i++)
                        {
                            sach.Masach = i;
                            list.Them(sach);
                        }
                        MessageBox.Show("Thêm Thành Công", "Thông Báo", MessageBoxButtons.OK);
                    }
                }
                 
            }

        }

        private void tensach_tb_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void namxb_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Vui lòng nhập số", "Lỗi", MessageBoxButtons.OK);
                e.Handled = true;
            }
        }

        private void trigia_tb_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void trigia_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Vui lòng nhập số", "Lỗi", MessageBoxButtons.OK);
                e.Handled = true;
            }
        }

        private void soluong_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Vui lòng nhập số", "Lỗi", MessageBoxButtons.OK);
                e.Handled = true;
            }
        }
    }
}
