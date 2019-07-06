using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace App
{
    public partial class RegisterForm : Form
    {
        private void TextBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text.Length == 0)
            {
                errorProvider1.SetError(textBox6, "không được để trống");
                errorProvider2.Clear();
                errorProvider3.Clear();
                RegexVerify(@"^(([UC]{2}){1})+(([0-9]{3,4}){1})$", textBox6, label20, "mã tài khoản.");
                label19.Show();
                label20.Show();
            }
            if (textBox6.Text.Length > 0)
            {                
                errorProvider1.Clear();
                label19.Hide();
                label20.Hide();
                if (!Regex.IsMatch(textBox6.Text, @"^(([UC]{2}){1})+(([0-9]{3,4}){1})$"))
                {
                    RegexVerify(@"^(([UC]{2}){1})+(([0-9]{3,4}){1})$", textBox6, label20, "mã tài khoản.");
                    errorProvider2.SetError(textBox6, "Hãy gõ theo cú pháp UC + 3~4 số, ví dụ: UC001,UC0002 !");
                    errorProvider3.Clear();
                    
                }
                else
                {                    
                    RegexVerify(@"^(([UC]{2}){1})+(([0-9]{3,4}){1})$", textBox6, label20, "mã tài khoản. ");
                    errorProvider2.Clear();
                    errorProvider3.SetError(textBox6, "OK");
                }
            }
        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text.Length == 0)
            {
                errorProvider1.SetError(textBox5, "không được để trống");
                errorProvider2.Clear();
                errorProvider3.Clear();
                RegexVerify(@"^([\w]+)+@([a-zA-Z]+)\.([a-zA-Z]+)$", textBox5, label11, "email.");
                label6.Show();
                label11.Show();
            }
            if (textBox5.Text.Length > 0)
            {
                errorProvider1.Clear();
                label6.Hide();
                label11.Hide();
                if (!Regex.IsMatch(textBox5.Text, @"^([\w]+)+@([a-zA-Z]+)\.([a-zA-Z]+)$"))
                {
                    RegexVerify(@"^([\w]+)+@([a-zA-Z]+)\.([a-zA-Z]+)$", textBox5, label11, "email.");
                    errorProvider2.SetError(textBox5, "Hãy gõ theo cú pháp XYZ@gmail.com !");
                    errorProvider3.Clear();
                }
                else
                {
                    RegexVerify(@"^([\w]+)+@([a-zA-Z]+)\.([a-zA-Z]+)$", textBox5, label11, "email. ");
                    errorProvider2.Clear();
                    errorProvider3.SetError(textBox5, "OK");
                }
            }
        }
        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.Length == 0)
            {
                errorProvider1.SetError(textBox4, "không được để trống");
                errorProvider2.Clear();
                errorProvider3.Clear();
                RegexVerify(@"^([\w]+)\z", textBox4, label10, "mật khẩu. ");
                label5.Show();
                label10.Show();
            }
            if (textBox4.Text.Length > 0)
            {
                errorProvider1.Clear();
                label5.Hide();
                label10.Hide();
                if (!Regex.IsMatch(textBox4.Text, @"^([\w]+)\z"))
                {                    
                    RegexVerify(@"^([\w]+)\z", textBox4, label10, "mật khẩu. ");
                    errorProvider2.SetError(textBox4, "Xin lỗi, không được sử dụng khoảng cách !");
                    errorProvider3.Clear();
                }
                else
                {                    
                    RegexVerify(@"^([\w]+)\z", textBox4, label10, "mật khẩu. ");
                    errorProvider2.Clear();
                    errorProvider3.SetError(textBox4, "OK");
                }
            }
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length == 0)
            {
                errorProvider1.SetError(textBox3, "không được để trống");
                errorProvider2.Clear();
                errorProvider3.Clear();
                RegexVerify(@"^([\w]+)\z", textBox3, label9, "tài khoản .");
                label4.Show();
                label9.Show();
            }
            if (textBox3.Text.Length > 0)
            {
                errorProvider1.Clear();
                label4.Hide();
                label9.Hide();
                if (!Regex.IsMatch(textBox3.Text, @"^([\w]+)\z"))
                {
                    RegexVerify(@"^([\w]+)\z", textBox3, label9, "tài khoản. ");
                    errorProvider2.SetError(textBox3, "Xin lỗi, không được sử dụng khoảng cách !");
                    errorProvider3.Clear();
                }
                else
                {
                    RegexVerify(@"^([\w]+)\z", textBox3, label9, "tài khoản. ");
                    errorProvider2.Clear();
                    errorProvider3.SetError(textBox3, "OK");
                }
            }
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0)
            {
                errorProvider1.SetError(textBox2, "không được để trống");
                errorProvider2.Clear();
                errorProvider3.Clear();
                RegexVerify(@"([\D]+)$", textBox2, label8, "tên.");
                label3.Show();
                label8.Show();
            }
            if (textBox2.Text.Length > 0)
            {
                errorProvider1.Clear();
                label3.Hide();
                label8.Hide();
                if (!Regex.IsMatch(textBox2.Text, @"([\D]+)$"))
                {
                    RegexVerify(@"([\D]+)$", textBox2, label8, "tên.");
                    errorProvider2.SetError(textBox2, "Xin lỗi, chỉ được phép sử dụng các chữ cái (a-z) !");
                    errorProvider3.Clear();
                }
                else
                {
                    RegexVerify(@"([\D]+)$", textBox2, label8, "tên.");
                    errorProvider2.Clear();
                    errorProvider3.SetError(textBox2, "OK");
                }
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                errorProvider1.SetError(textBox1, "không được để trống");
                errorProvider2.Clear();
                errorProvider3.Clear();
                RegexVerify(@"([\D]+)$", textBox1, label7, "họ.");
                label2.Show();
                label7.Show();
            }
            if (textBox1.Text.Length > 0)
            {
                errorProvider1.Clear();
                label2.Hide();
                label7.Hide();
                if (!Regex.IsMatch(textBox1.Text, @"([\D]+)$"))
                {
                    RegexVerify(@"([\D]+)$", textBox1, label7, "họ.");
                    errorProvider2.SetError(textBox1, "Xin lỗi, chỉ được phép sử dụng các chữ cái (a-z) !");
                    errorProvider3.Clear();                   
                }
                else
                {
                    RegexVerify(@"([\D]+)$", textBox1, label7, "họ.");
                    errorProvider2.Clear();
                    errorProvider3.SetError(textBox1, "OK");
                }
            }
        }

        //int index;
      
    }
}
