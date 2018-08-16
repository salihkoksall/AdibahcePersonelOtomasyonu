namespace AdibahceCalismaCizelge
{
    partial class PersonelEkleForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.MaasTbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.GirisTarihi = new System.Windows.Forms.DateTimePicker();
            this.PersonelEkleTbox = new System.Windows.Forms.TextBox();
            this.Kaydet = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.MaasTbox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.GirisTarihi);
            this.panel1.Controls.Add(this.PersonelEkleTbox);
            this.panel1.Controls.Add(this.Kaydet);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(398, 386);
            this.panel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(356, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 31);
            this.label5.TabIndex = 8;
            this.label5.Text = "₺";
            // 
            // MaasTbox
            // 
            this.MaasTbox.Location = new System.Drawing.Point(150, 141);
            this.MaasTbox.Name = "MaasTbox";
            this.MaasTbox.Size = new System.Drawing.Size(200, 20);
            this.MaasTbox.TabIndex = 7;
            this.MaasTbox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(11, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Maaş:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // GirisTarihi
            // 
            this.GirisTarihi.Location = new System.Drawing.Point(150, 84);
            this.GirisTarihi.Name = "GirisTarihi";
            this.GirisTarihi.Size = new System.Drawing.Size(200, 20);
            this.GirisTarihi.TabIndex = 5;
            // 
            // PersonelEkleTbox
            // 
            this.PersonelEkleTbox.Location = new System.Drawing.Point(150, 34);
            this.PersonelEkleTbox.Name = "PersonelEkleTbox";
            this.PersonelEkleTbox.Size = new System.Drawing.Size(200, 20);
            this.PersonelEkleTbox.TabIndex = 4;
            // 
            // Kaydet
            // 
            this.Kaydet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Kaydet.BackColor = System.Drawing.Color.Lime;
            this.Kaydet.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Kaydet.ForeColor = System.Drawing.Color.White;
            this.Kaydet.Location = new System.Drawing.Point(275, 211);
            this.Kaydet.Name = "Kaydet";
            this.Kaydet.Size = new System.Drawing.Size(75, 35);
            this.Kaydet.TabIndex = 3;
            this.Kaydet.Text = "Kaydet";
            this.Kaydet.UseVisualStyleBackColor = false;
            this.Kaydet.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(11, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Giriş Tarihi :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(11, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Adı Soyadı:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // PersonelEkleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(400, 450);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.MaximumSize = new System.Drawing.Size(400, 450);
            this.MinimumSize = new System.Drawing.Size(400, 450);
            this.Name = "PersonelEkleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personel Ekleme Formu";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PersonelEkleForm_KeyPress);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Kaydet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker GirisTarihi;
        private System.Windows.Forms.TextBox PersonelEkleTbox;
        private System.Windows.Forms.TextBox MaasTbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}