using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdibahceCalismaCizelge
{
    public partial class PersonelEkleForm :MaterialSkin.Controls.MaterialForm
    {
       
        public PersonelEkleForm()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               
                Personel p = new Personel();
                p.Personel_ID = Form1.Adibahce.Personel.Count() + 1;
                p.PersonelAdSoyad = PersonelEkleTbox.Text;
                p.PersonelGirisTarihi = GirisTarihi.Value;
                p.PersonelMaas = Convert.ToInt32(MaasTbox.Text);
                p.PersonelMesaiSaat = 0;

                Form1.Adibahce.Personel.Add(p);
                Form1.Adibahce.SaveChanges();
                MessageBox.Show("Personel Ekleme İşlemi Başarıyla Tamamlandı", "Mesaj");
                Form1 form1 = (Form1)Application.OpenForms["Form1"];
                form1.PanelTemizle();
                form1.PersonelOlustur();
                form1.Yenile();


                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen Verileri Doğru Biçimde Girdiğinize Emin Olun", "Uyarı");
            }
            

           
            







        }

        private void PersonelEkleForm_KeyPress(object sender, KeyPressEventArgs e)
        {
      
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
