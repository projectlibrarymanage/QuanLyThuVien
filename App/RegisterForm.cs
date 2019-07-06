using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;
using System.Globalization;
using App;

namespace App
{
    public partial class RegisterForm : Form
    {
        int move;
        int moveX;
        int moveY;
        public RegisterForm()
        {            
            InitializeComponent();
            textBox4.PasswordChar = '*';
            textBox1.TextChanged += TextBox1_TextChanged;
            textBox2.TextChanged += TextBox2_TextChanged;
            textBox3.TextChanged += TextBox3_TextChanged;
            textBox4.TextChanged += TextBox4_TextChanged;
            textBox5.TextChanged += TextBox5_TextChanged;
            textBox6.TextChanged += TextBox6_TextChanged;
            //dataGridView1.Hide();
        }

        private void Connection()
        {
            try
            {
                SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-TUJ6O4P\SQLEXPRESS;Initial Catalog=QLTV;Integrated Security=True");
                Con.Open();
                string sql = "select * from Users";
                SqlCommand commandsql = new SqlCommand(sql, Con);
                SqlDataAdapter adaptersql = new SqlDataAdapter(commandsql);
                DataTable table = new DataTable();
                adaptersql.Fill(table);
                dataGridView1.DataSource = table;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (DivideByZeroException e)
            {
                MessageBox.Show(e.ToString());
            } 
            finally
            {
                SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-TUJ6O4P\SQLEXPRESS;Initial Catalog=QLTV;Integrated Security=True");
                Con.Close();
            }
        }

        public void RegexVerify(string re, TextBox tb, Label lb, string s)
        {
            Regex regex = new Regex(re);
            
            if (regex.IsMatch(tb.Text))
            {
                lb.ForeColor = Color.Green;
                lb.Text = "";
            }           
            if (tb.Text.Length == 0)
            {
                lb.ForeColor = Color.Red;
                lb.Text = "Vui lòng nhập " + s;                
            }
        }
       

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            this.Close();
        }

        string save;
        public void button1_Click(object sender, EventArgs e)
        {
            this.AcceptButton = button1; 
                if (textBox6.Text.Length == 0)
                {
                    errorProvider1.SetError(textBox6, "không được để trống");
                    errorProvider2.Clear();
                    errorProvider3.Clear();
                    RegexVerify(@"^(([UC]{2}){1})+(([0-9]{3,4}){1}\z)", textBox6, label13, "mã tài khoản. ");
                    label19.Show();
                    textBox6.Focus();                   
                }
                else if (textBox6.Text.Length > 0 && textBox1.Text.Length == 0)
                {                    
                    errorProvider1.SetError(textBox1, "không được để trống");
                    errorProvider2.Clear();
                    errorProvider3.Clear();
                    RegexVerify(@"([\D]+)$", textBox1, label7, "họ. ");
                    label2.Show();
                    textBox1.Focus();
                }
                else if (textBox6.Text.Length > 0 && textBox1.Text.Length > 0 && textBox2.Text.Length == 0)
                {
                    errorProvider1.SetError(textBox2, "không được để trống");
                    errorProvider2.Clear();
                    errorProvider3.Clear();
                    RegexVerify(@"([\D]+)$", textBox2, label8, "tên. ");
                    label3.Show();
                    textBox2.Focus();
                }
                else if (textBox6.Text.Length > 0 && textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox3.Text.Length == 0)
                {
                    errorProvider1.SetError(textBox3, "không được để trống");
                    errorProvider2.Clear();
                    errorProvider3.Clear();
                    RegexVerify(@"^[\S]([\w]+)$", textBox3, label9, "tài khoản. ");
                    label4.Show();
                    textBox3.Focus();
                }
                else if (textBox6.Text.Length > 0 && textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox3.Text.Length > 0 && textBox4.Text.Length == 0)
                {
                    errorProvider1.SetError(textBox4, "không được để trống");
                    errorProvider2.Clear();
                    errorProvider3.Clear();
                    RegexVerify(@"^([\w]+)\z", textBox4, label10, "mật khẩu. ");
                    label5.Show();
                    textBox4.Focus();
                }
                else if (textBox6.Text.Length > 0 && textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox3.Text.Length > 0 && textBox4.Text.Length > 0 && textBox5.Text.Length == 0)
                {
                        errorProvider1.SetError(textBox5, "không được để trống");
                    errorProvider2.Clear();
                    errorProvider3.Clear();
                    RegexVerify(@"^([\w]+)+@([a-zA-Z]+)\.([a-zA-Z]+)$", textBox5, label11, "email. ");
                    label6.Show();
                    textBox5.Focus();                     
                }
                else
                  {
                      SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-TUJ6O4P\SQLEXPRESS;Initial Catalog=QLTV;Integrated Security=True");
                      Con.Open();
                      save = "insert into Users values ('"+textBox6.Text+"',N'" + textBox1.Text + "',N'" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";

                      SqlCommand commandsaveAdd = new SqlCommand(save, Con);
                      commandsaveAdd.ExecuteNonQuery();
                      Connection();
                   }


            //if (textBox1.Text.Length != 0 && textBox2.Text.Length != 0 && textBox3.Text.Length != 0 && textBox4.Text.Length != 0 && textBox5.Text.Length != 0)
            //{

            /* if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox3.Text.Length > 0 && textBox4.Text.Length > 0 && textBox5.Text.Length > 0)
             {
                 SqlConnection Con1 = new SqlConnection(@"Data Source=DESKTOP-TUJ6O4P\SQLEXPRESS;Initial Catalog=QLTV;Integrated Security=True");

                 Con1.Close();
                 MessageBox.Show("Đăng Ký Thành Công");
             }  */
            //    MessageBox.Show("Đăng Ký Thành Công");
            //    //DialogResult Result = MessageBox.Show("Đăng Ký Tài Khoản Thành Công", "Thông Báo", MessageBoxButtons.OK);
            //    //if (Result == DialogResult.OK)
            //    //{
            //    //    this.Close();
            //    //    textBox1.Clear();
            //    //    textBox2.Clear();
            //    //    textBox3.Clear();
            //    //    textBox4.Clear();
            //    //    textBox5.Clear();
            //    //    textBox6.Clear();
            //    //}
            //}

        }


        private void RegisterForm_Load(object sender, EventArgs e)
        {
            Connection();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox4.UseSystemPasswordChar = true;
            }
            else
            {
                textBox4.UseSystemPasswordChar = false;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            move = 0;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            move = 1;
            moveX = e.X;
            moveY = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == 1)
                this.SetDesktopLocation(MousePosition.X - moveX, MousePosition.Y - moveY);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }



        //private void dataGridView1_Click_1(object sender, EventArgs e)
        //{
        //    index = dataGridView1.CurrentRow.Index;
        //    textBox1.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
        //    textBox2.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
        //    textBox3.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
        //    textBox4.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
        //    textBox5.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();
        //}      
    }    
}
