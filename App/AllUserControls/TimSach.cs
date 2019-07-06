using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.AllUserControls
{
    public partial class TimSach : UserControl
    {
        public TimSach()
        {
            InitializeComponent();
           
        }
        

        //int delta = 9, min, max;

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    panel1.Top -= delta;
        //    panel2.Top -= delta;
        //    if (panel2.Top <= min)
        //    {
        //        panel2.Top = min;
        //        panel1.Hide();
        //        timer1.Stop();
        //    }
        //}

        //private void timer2_Tick(object sender, EventArgs e)
        //{
        //    panel1.Top += delta;
        //    panel2.Top += delta;
        //    if (panel1.Top >= max)
        //    {
        //        panel1.Top = max;
        //        panel2.Hide();
        //        timer2.Stop();
        //    }
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    timer2.Interval = 15;
        //    panel1.Show();
        //    max = panel2.Top;
        //    timer2.Start();
        //}



        //private void circleButton1_Click(object sender, EventArgs e)
        //{
        //    panel2.Left = panel1.Left;
        //    panel2.Top = panel1.Top + panel1.Width + delta;
        //    timer1.Interval = 15;
        //    panel2.Show();
        //    min = panel1.Top;
        //    timer1.Start();
        //}


    }
}
