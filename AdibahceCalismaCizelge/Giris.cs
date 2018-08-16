using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdibahceCalismaCizelge
{
    public partial class Giris : MaterialSkin.Controls.MaterialForm
    {
      
        public Giris()
        {
            InitializeComponent();
        }
        public static KullaniciBilgi k = new KullaniciBilgi();
        private void Giris_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {   
            AdibahceContainer adibahce = new AdibahceContainer();
           
            var deneme = adibahce.Kullanici.Where(x=>x.KullaniciAdi==textBox1.Text&&x.KullaniciSifre==textBox2.Text).ToList();
            foreach (var item in deneme)
            {
                k.KullaniciAdi = item.KullaniciAdi;
                k.Sifre = item.KullaniciSifre;
                k.AdminMi = Convert.ToBoolean(item.AdminMi);

            }
            if(deneme.Count==1)
            {
                MessageBox.Show("Başarıyla Giriş Yaptınız sayın:" + textBox1.Text, "Mesaj");
                Form1 frm1 = new Form1();
                frm1.KullaniciAdi(textBox1.Text);
                
             
                this.Visible=false;
                frm1.Show();
           
             
               
              
              
               
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şİfreyi Yanlış Girdiniz","Uyarı");
            }
            
        }
    }
}
