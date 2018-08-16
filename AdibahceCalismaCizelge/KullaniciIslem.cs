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
    public partial class KullaniciIslem : MaterialSkin.Controls.MaterialForm
    {
        public KullaniciIslem()
        {
            InitializeComponent();
        }

        private void KullaniciIslem_Load(object sender, EventArgs e)
        {

            Yenile();
        }
        public void Yenile()
        {
            comboBox1.Items.Clear();
            AdibahceContainer adb = new AdibahceContainer();
            var model = adb.Kullanici.ToList();
            foreach (var item in model)
            {
                comboBox1.Items.Add(item.KullaniciAdi);
            }

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            AdibahceContainer adb = new AdibahceContainer();
            var model = adb.Kullanici.Where(x => x.KullaniciAdi == comboBox1.Text).ToList();
            foreach (var item in model)
            {
                textBox1.Text = item.KullaniciAdi;
                textBox2.Text = item.KullaniciSifre;
                textBox3.Text = Convert.ToString(item.AdminMi);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdibahceContainer adb = new AdibahceContainer();
            var model = adb.Kullanici.Where(x => x.KullaniciAdi == comboBox1.Text).Select(x => x.Id).ToList().FirstOrDefault();
            Kullanici k = adb.Kullanici.First(x => x.Id == model);
            k.KullaniciAdi = textBox1.Text;
            k.KullaniciSifre = textBox2.Text;
            k.AdminMi = Convert.ToBoolean(textBox3.Text);
            adb.SaveChanges();
            MessageBox.Show("Güncelleme İşlemi Başarıyla Tamamlandı", "Mesaj");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdibahceContainer adb = new AdibahceContainer();
            var model = adb.Kullanici.Where(x => x.KullaniciAdi == comboBox1.Text).Select(x => x.Id).ToList().FirstOrDefault();
            Kullanici k = adb.Kullanici.First(x => x.Id == model);
            adb.Kullanici.Remove(k);
            DialogResult d = MessageBox.Show("Silmek İstediğinize Eminmisiniz?", "Uyarı", MessageBoxButtons.YesNo);
            if(d==DialogResult.Yes)
            {
                adb.SaveChanges();
                Yenile();
            }
            else
            {
                MessageBox.Show("Silme İşlemi İptal Edildi", "Mesaj");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdibahceContainer adb = new AdibahceContainer();
            
            if (textBox5.Text==textBox7.Text)
            {
                Kullanici k = new Kullanici();
                k.Id = adb.Kullanici.Count() + 1;
                k.KullaniciAdi = textBox6.Text;
                k.KullaniciSifre = textBox5.Text;
                k.AdminMi = Convert.ToBoolean(textBox4.Text);
                adb.Kullanici.Add(k);
                adb.SaveChanges();
                MessageBox.Show("Yeni Kullanıcı Tanımlandı", "Mesaj");

                Yenile();

            }
            else
            {
                MessageBox.Show("Parolalar Eşleşmiyor,Lütfen Doğru Yazdığınızdan Emin Olun", "Uyarı");
            }
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }
    }
}
