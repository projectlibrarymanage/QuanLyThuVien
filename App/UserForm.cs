using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App;
using App.AllUserControls;

namespace App
{
    public partial class UserForm : Form
    {

        public UserForm()
        {
            InitializeComponent();
        }

        //
        // Ẩn, mở lớn/thu nhỏ, tắt app
        private void CloseBt_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void HideBt_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //

        //
        // Drag control (Kéo di chuyển app)
        int move;
        int moveX;
        int moveY;

        private void gradientPanel1_MouseUp(object sender, MouseEventArgs e)
        {
            move = 0;
        }

        private void gradientPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            move = 1;
            moveX = e.X;
            moveY = e.Y;
        }

        private void gradientPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == 1)
                this.SetDesktopLocation(MousePosition.X - moveX, MousePosition.Y - moveY);
        }
        //        

        //
        // Chức năng của các buttons
        private void button1_Click(object sender, EventArgs e)
        {
            QLStimer.Stop();
            BaoCaoTimer.Stop();
            LapPhieuTimer.Stop();
            ThayDoiTimer.Stop();
            DocGiaTimer.Start();
            DocGia uc = new DocGia();
            panel2.Controls.Add(uc);            
            uc.BringToFront();
            uc.Dock = DockStyle.Fill;            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SachMoi uc1 = new SachMoi();
            panel2.Controls.Add(uc1);
            uc1.BringToFront();
            uc1.Dock = DockStyle.Fill;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TimSach uc2 = new TimSach();
            panel2.Controls.Add(uc2);
            uc2.BringToFront();
            uc2.Dock = DockStyle.Fill;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChoMuonSach uc3 = new ChoMuonSach();
            panel2.Controls.Add(uc3);
            uc3.BringToFront();
            uc3.Dock = DockStyle.Fill;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TraSach uc4 = new TraSach();
            panel2.Controls.Add(uc4);
            uc4.BringToFront();
            uc4.Dock = DockStyle.Fill;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            BangBaoCao uc5 = new BangBaoCao();
            panel2.Controls.Add(uc5);
            uc5.BringToFront();
            uc5.Dock = DockStyle.Fill;
        }
        //

        //
        // Thả panel (Mệt v~)
        // Cái này là thả panel của quản lý sách
        private bool isCollapsed, isCollapsed2, isCollapsed3, isCollapsed4;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed || !isCollapsed2 || !isCollapsed3 || !isCollapsed4)
            {
                panel1.Height += 10;
                if (panel1.Size == panel1.MaximumSize)
                {
                    QLStimer.Stop();
                    isCollapsed = false;
                }
                panel4.Height -= 10;
                if (panel4.Size == panel4.MinimumSize)
                {
                    isCollapsed2 = true;
                }
                panel5.Height -= 10;
                if (panel5.Size == panel5.MinimumSize)
                {
                    isCollapsed3 = true;
                }
                panel7.Height -= 10;
                if (panel7.Size == panel7.MinimumSize)
                {
                    isCollapsed4 = true;
                }
            }
            else
            {
                panel1.Height -= 10;
                if (panel1.Size == panel1.MinimumSize)
                {
                    QLStimer.Stop();
                    isCollapsed = true;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            BaoCaoTimer.Stop();
            DocGiaTimer.Stop();
            LapPhieuTimer.Stop();
            ThayDoiTimer.Stop();
            QLStimer.Start();
        }

        // Thả panel của báo cáo
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (!isCollapsed || isCollapsed2 || !isCollapsed3 || !isCollapsed4)
            {
                panel1.Height -= 20;
                if (panel1.Size == panel1.MinimumSize)
                {
                    isCollapsed = true;
                }
                panel4.Height += 10;
                if (panel4.Size == panel4.MaximumSize)
                {
                    BaoCaoTimer.Stop();
                    isCollapsed2 = false;
                }
                panel5.Height -= 10;
                if (panel5.Size == panel5.MinimumSize)
                {
                    isCollapsed3 = true;
                }
                panel7.Height -= 10;
                if (panel7.Size == panel7.MinimumSize)
                {
                    isCollapsed4 = true;
                }
            }
            else
            {
                panel4.Height -= 10;
                if (panel4.Size == panel4.MinimumSize)
                {
                    BaoCaoTimer.Stop();
                    isCollapsed2 = true;
                }
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            QLStimer.Stop();
            DocGiaTimer.Stop();
            LapPhieuTimer.Stop();
            ThayDoiTimer.Stop();
            BaoCaoTimer.Start();
        }
        //

        // Thả panel của lập phiếu
        private void timer4_Tick(object sender, EventArgs e)
        {
            if (!isCollapsed || !isCollapsed2 || isCollapsed3 || !isCollapsed4)
            {
                panel1.Height -= 20;
                if (panel1.Size == panel1.MinimumSize)
                {                    
                    isCollapsed = true;
                }
                panel4.Height -= 10;
                if (panel4.Size == panel4.MinimumSize)
                {
                    isCollapsed2 = true;
                }
                panel5.Height += 10;
                if (panel5.Size == panel5.MaximumSize)
                {
                    LapPhieuTimer.Stop();
                    isCollapsed3 = false;
                }
                panel7.Height -= 10;
                if (panel7.Size == panel7.MinimumSize)
                {
                    isCollapsed4 = true;
                }
            }
            else
            {
                panel5.Height -= 10;
                if (panel5.Size == panel5.MinimumSize)
                {
                    LapPhieuTimer.Stop();
                    isCollapsed3 = true;
                }
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            QLStimer.Stop();
            DocGiaTimer.Stop();
            BaoCaoTimer.Stop();
            ThayDoiTimer.Stop();
            LapPhieuTimer.Start();
        }
        //

        //Thu panel thay đổi
        private void ThayDoiTimer_Tick(object sender, EventArgs e)
        {
            if (!isCollapsed || !isCollapsed2 || !isCollapsed3 || isCollapsed4)
            {
                panel1.Height -= 20;
                if (panel1.Size == panel1.MinimumSize)
                {
                    isCollapsed = true;
                }
                panel4.Height -= 10;
                if (panel4.Size == panel4.MinimumSize)
                {
                    isCollapsed2 = true;
                }
                panel5.Height -= 10;
                if (panel5.Size == panel5.MinimumSize)
                {
                    isCollapsed3 = true;
                }
                panel7.Height += 10;
                if (panel7.Size == panel7.MaximumSize)
                {
                    ThayDoiTimer.Stop();
                    isCollapsed4 = false;
                }
            }
            else
            {
                panel7.Height -= 10;
                if (panel7.Size == panel7.MinimumSize)
                {
                    ThayDoiTimer.Stop();
                    isCollapsed4 = true;
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            QLStimer.Stop();
            DocGiaTimer.Stop();
            LapPhieuTimer.Stop();
            BaoCaoTimer.Stop();
            ThayDoiTimer.Start();
        }


        // Này là thu panel của độc giả
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (!isCollapsed )            
            {
                QLStimer.Stop();
                BaoCaoTimer.Stop();
                LapPhieuTimer.Stop();
                ThayDoiTimer.Stop();
                panel1.Height -= 10;
                if (panel1.Size == panel1.MinimumSize)
                {
                    DocGiaTimer.Stop();
                    isCollapsed = true;
                }
            }
            if (!isCollapsed2)
            {
                QLStimer.Stop();
                BaoCaoTimer.Stop();
                LapPhieuTimer.Stop();
                ThayDoiTimer.Stop();
                panel4.Height -= 10;
                if (panel4.Size == panel4.MinimumSize)
                {
                    DocGiaTimer.Stop();
                    isCollapsed2 = true;
                }
            }
            if (!isCollapsed3)
            {
                QLStimer.Stop();
                BaoCaoTimer.Stop();
                LapPhieuTimer.Stop();
                ThayDoiTimer.Stop();
                panel5.Height -= 10;
                if (panel5.Size == panel5.MinimumSize)
                {
                    DocGiaTimer.Stop();
                    isCollapsed3 = true;
                }
            }
            if (!isCollapsed4)
            {
                QLStimer.Stop();
                BaoCaoTimer.Stop();
                LapPhieuTimer.Stop();
                ThayDoiTimer.Stop();
                panel7.Height -= 10;
                if (panel7.Size == panel7.MinimumSize)
                {
                    DocGiaTimer.Stop();
                    isCollapsed4 = true;
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SAch uc6 = new SAch();
            panel2.Controls.Add(uc6);
            uc6.BringToFront();
            uc6.Dock = DockStyle.Fill;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            ThaydoiDocGia uc7 = new ThaydoiDocGia();
            panel2.Controls.Add(uc7);
            uc7.BringToFront();
            uc7.Dock = DockStyle.Fill;
        }

        private void ThayDoiPhieuMuonBt_Click(object sender, EventArgs e)
        {
            ThaydoiPhieuMuon uc = new ThaydoiPhieuMuon();
            panel2.Controls.Add(uc);
            uc.BringToFront();
            uc.Dock = DockStyle.Fill;
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            BangThongKe uc8 = new BangThongKe();
            panel2.Controls.Add(uc8);
            uc8.BringToFront();
            uc8.Dock = DockStyle.Fill;

        }

        private void TrangChuBt_Click(object sender, EventArgs e)
        {
            pictureBox1.BringToFront();
        }       

        private void UserForm_Load(object sender, EventArgs e)
        {
            DocGiaTimer.Start();
        }        

             
    }
}
