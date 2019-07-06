namespace App
{
    partial class BangBaoCao
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BangBaoCao));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.SaveAddBt = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.thangbaocaotxt = new System.Windows.Forms.TextBox();
            this.dataGridThongke = new System.Windows.Forms.DataGridView();
            this.tl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sln = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridThongke)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1229, 625);
            this.panel1.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(9, 7);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1211, 609);
            this.panel3.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Consolas", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.label9.Location = new System.Drawing.Point(33, 9);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(381, 49);
            this.label9.TabIndex = 3;
            this.label9.Text = "Tình Hình Mượn Sách ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.SaveAddBt);
            this.panel4.Controls.Add(this.label16);
            this.panel4.Controls.Add(this.thangbaocaotxt);
            this.panel4.Controls.Add(this.dataGridThongke);
            this.panel4.Location = new System.Drawing.Point(12, 32);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1186, 566);
            this.panel4.TabIndex = 31;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(424, 85);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 2);
            this.label12.TabIndex = 56;
            // 
            // SaveAddBt
            // 
            this.SaveAddBt.AutoSize = true;
            this.SaveAddBt.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveAddBt.Image = ((System.Drawing.Image)(resources.GetObject("SaveAddBt.Image")));
            this.SaveAddBt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaveAddBt.Location = new System.Drawing.Point(782, 43);
            this.SaveAddBt.Margin = new System.Windows.Forms.Padding(4);
            this.SaveAddBt.Name = "SaveAddBt";
            this.SaveAddBt.Size = new System.Drawing.Size(124, 50);
            this.SaveAddBt.TabIndex = 44;
            this.SaveAddBt.Text = "Xuất";
            this.SaveAddBt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SaveAddBt.UseVisualStyleBackColor = true;
            this.SaveAddBt.Click += new System.EventHandler(this.SaveAddBt_Click);
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(418, 46);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(94, 41);
            this.label16.TabIndex = 53;
            this.label16.Text = "Tháng:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // thangbaocaotxt
            // 
            this.thangbaocaotxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thangbaocaotxt.Location = new System.Drawing.Point(520, 50);
            this.thangbaocaotxt.Margin = new System.Windows.Forms.Padding(4);
            this.thangbaocaotxt.Multiline = true;
            this.thangbaocaotxt.Name = "thangbaocaotxt";
            this.thangbaocaotxt.Size = new System.Drawing.Size(215, 37);
            this.thangbaocaotxt.TabIndex = 51;
            // 
            // dataGridThongke
            // 
            this.dataGridThongke.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridThongke.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridThongke.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tl,
            this.sln});
            this.dataGridThongke.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridThongke.Location = new System.Drawing.Point(0, 142);
            this.dataGridThongke.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridThongke.Name = "dataGridThongke";
            this.dataGridThongke.ReadOnly = true;
            this.dataGridThongke.Size = new System.Drawing.Size(1184, 422);
            this.dataGridThongke.TabIndex = 34;
            // 
            // tl
            // 
            this.tl.HeaderText = "Thể Loại";
            this.tl.Name = "tl";
            this.tl.ReadOnly = true;
            // 
            // sln
            // 
            this.sln.HeaderText = "Số Lần Mượn";
            this.sln.Name = "sln";
            this.sln.ReadOnly = true;
            // 
            // BangBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BangBaoCao";
            this.Size = new System.Drawing.Size(1229, 625);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridThongke)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button SaveAddBt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox thangbaocaotxt;
        private System.Windows.Forms.DataGridView dataGridThongke;
        private System.Windows.Forms.DataGridViewTextBoxColumn tl;
        private System.Windows.Forms.DataGridViewTextBoxColumn sln;
    }
}
