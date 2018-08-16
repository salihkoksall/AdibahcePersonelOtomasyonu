using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AdibahceCalismaCizelge
{
    public partial class Form1 : MaterialSkin.Controls.MaterialForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static Sorgu sorgu = new Sorgu();
        public static AdibahceContainer Adibahce = new AdibahceContainer();
        public void KullaniciAdi(string text)
        {
            label3.Text = text;
        }
        public void PersonelOlustur()
        {


        
            label1.Text = DateTime.Now.ToShortDateString();

            var sorgu1 = Adibahce.Personel.Select(x => x.PersonelAdSoyad);
            int i = 0;

            foreach (var item in sorgu1)
            {

              
                Button btn = new System.Windows.Forms.Button();
               
                btn.Location = new System.Drawing.Point(0, 50 * i);
                btn.Size = new System.Drawing.Size(panel1.Width, 50);
                btn.Text = item;
                btn.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                btn.BackColor = System.Drawing.Color.Transparent;
                panel1.Controls.Add(btn);

                i++;

                btn.Click += new EventHandler(btn_Click);
                void btn_Click(object sender, EventArgs e)
                {
                    Form3 personelform = new Form3();
                    personelform.Text = item;
                    personelform.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    personelform.Show();

                }
               

            }
        }
        
        
    private void Form1_Load(object sender, EventArgs e)
        {
           

            PersonelOlustur();
            label2.Text = DateTime.Now.ToShortDateString();
            ToplamMesai(DateTime.Now.Month.ToString());
            Yenile();
           

            
           
           
           
        }
        public void Yenile()
        {

            #region PersonelComboBoxYenile
            PersonelCbx.Items.Clear();
            
            var combobox = Adibahce.Personel.Select(x => x.PersonelAdSoyad);
                foreach (var query in combobox)
                {
                    PersonelCbx.Items.Add(query);
                }
           
           
            #endregion
            #region YılTarihiYenile
            GuncelYil.Items.Clear();
          
            var deneme = Adibahce.Shift.Select(x => new { x.Yil_ID }).Distinct();
            foreach (var model in deneme)
            {
                GuncelYil.Items.Add(model.Yil_ID);

            }
            #endregion
            #region DataGridViewYenile
          
            var item = Adibahce.Shift.Where(x => x.Ay_ID == DateTime.Now.Month).ToList();

            Yil.DataSource = item;
            
            
            Yil.Refresh();


            #endregion
            #region Ozet



           
            
                    var model1 = Adibahce.Personel.Select(x => new { İsim = x.PersonelAdSoyad,Maaş=x.PersonelMaas, SaatÜcreti = x.PersonelMaas / 300,GüncelMesaiSaati =x.PersonelMesaiSaat, GüncelTutar = (x.PersonelMaas / 300) *x.PersonelMesaiSaat }).ToList();

                    Ozet.DataSource = model1;

                    Ozet.Refresh();
                
               
            
            


            
            #endregion




        }

        public void PanelTemizle()
        {
            panel1.Controls.Clear();
            sorgu.PersonelSecimPaneli(panel1, label1);

        }

        
        public void OrtalamaAl(DateTime Baslangic,DateTime Bitis)
        {
            
            var item = Adibahce.Shift.Where(x => x.Tarih >= Baslangic.Date && x.Tarih <= Bitis.Date).ToList();
        }
        
        private void PersonelEkle_Click(object sender, EventArgs e)
        {
            PersonelEkleForm frm = new PersonelEkleForm();
            frm.Show();
        }

       
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GuncelYil_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToplamMesai(GuncelYil.Text);

            Ay.Items.Clear();
            Ay.Text = null;
         
            int deneme = int.Parse(GuncelYil.SelectedItem.ToString());
            var item = Adibahce.Shift.Where(x => x.Yil_ID ==deneme ).ToList();
            Yil.DataSource = item;
            Yil.Refresh();
           
            var query = Adibahce.Shift.Where(x => x.Yil_ID == deneme).Select(x=>x.Ay_ID).Distinct();
           

            foreach (var model in query)
            {
                Ay.Items.Add(model);

            }
            #region Ozet




     
            var model1 = Adibahce.Personel.Select(x => new { İsim = x.PersonelAdSoyad, Maaş = x.PersonelMaas, SaatÜcreti = x.PersonelMaas / 300, GüncelMesaiSaati = x.PersonelMesaiSaat, GüncelTutar = (x.PersonelMaas / 300) * x.PersonelMesaiSaat }).ToList();

            Ozet.DataSource = model1;

            Ozet.Refresh();







            #endregion


        }

        private void Ay_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToplamMesai(Ay.Text);
            Gun.Items.Clear();

            int a = int.Parse(Ay.SelectedItem.ToString());
            if(PersonelCbx.SelectedItem==null)
            {
                var item = Adibahce.Shift.Where(x => x.Ay_ID == a).ToList();
                Yil.DataSource = item;
                Yil.Refresh();

            }
            else
            {
                var item = Adibahce.Shift.Where(x => x.PersonelAdSoyad == PersonelCbx.SelectedItem.ToString()).Where(x => x.Ay_ID == a).ToList();
                Yil.DataSource = item;
                Yil.Refresh();
            }

            #region Ozet




         
            var model1 = Adibahce.Personel.Select(x => new { İsim = x.PersonelAdSoyad, Maaş = x.PersonelMaas, SaatÜcreti = x.PersonelMaas / 300, GüncelMesaiSaati = x.PersonelMesaiSaat, GüncelTutar = (x.PersonelMaas / 300) * x.PersonelMesaiSaat }).ToList();

            Ozet.DataSource = model1;

            Ozet.Refresh();







            #endregion
            int yiltext = int.Parse(GuncelYil.Text);
            int aytext = int.Parse(Ay.Text);
            var deneme = Adibahce.Shift.Where(x => x.Yil_ID == yiltext && x.Ay_ID == aytext).Select(x => x.Gun_ID).Distinct().ToList();
            foreach (var item in deneme)
            {
                Gun.Items.Add(item);

            }


        }

        private void PersonelCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToplamMesai(PersonelCbx.Text);
            int a=0;
            int deneme = 0;
            if(Ay.SelectedItem!=null&& GuncelYil.SelectedItem != null)
            {
                deneme = int.Parse(GuncelYil.SelectedItem.ToString());
                a = int.Parse(Ay.SelectedItem.ToString());
                var item = Adibahce.Shift.Where(x => x.PersonelAdSoyad == PersonelCbx.SelectedItem.ToString()).Where(x => x.Yil_ID == deneme).Where(x => x.Ay_ID == a).ToList();
                Yil.DataSource = item;
                Yil.Refresh();
            }
            else if (GuncelYil.SelectedItem == null && Ay.SelectedItem == null)
            {
                var item = Adibahce.Shift.Where(x => x.PersonelAdSoyad == PersonelCbx.SelectedItem.ToString()).ToList();
                Yil.DataSource = item;
                Yil.Refresh();
            }
            else if(Ay.SelectedItem == null||GuncelYil.SelectedItem!=null)
            {
                deneme = int.Parse(GuncelYil.SelectedItem.ToString());
                var item = Adibahce.Shift.Where(x => x.PersonelAdSoyad == PersonelCbx.SelectedItem.ToString()).Where(x => x.Yil_ID == deneme).ToList();
                Yil.DataSource = item;
                Yil.Refresh();
            }
            else if(GuncelYil.SelectedItem == null || Ay.SelectedItem != null)
            {
                a = int.Parse(Ay.SelectedItem.ToString());
                var item = Adibahce.Shift.Where(x => x.PersonelAdSoyad == PersonelCbx.SelectedItem.ToString()).Where(x => x.Ay_ID == a).ToList();
                Yil.DataSource = item;
                Yil.Refresh();
            }


         


        }

        private void button5_Click(object sender, EventArgs e)
        {
            var item = Adibahce.Shift.ToList();

            Yil.DataSource = item;
            Yil.Refresh();
            Adibahce.SaveChanges();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           string saat = DateTime.Now.ToLongTimeString();
            label1.Text = saat;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.instagram.com/slhkoksal/");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.facebook.com/salihkoksall");
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void kullanıcıDeğiştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
           

        }

        private void çıkışToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
           
            this.Close();
            
        }

        private void çıkışToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void kullanıcıİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
            var item = Adibahce.Kullanici.Where(x => x.KullaniciAdi == label3.Text).Select(x => x.AdminMi).FirstOrDefault();
            if(item==false)
            {
                MessageBox.Show("Bu Sayfayı Açmaya Yetkiniz Yok!!!", "Uyarı");
            }
            else
            {
                KullaniciIslem k = new KullaniciIslem();
                k.Show();
            }
        }
        
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
                Giris grs = (Giris)Application.OpenForms["Giris"];
                grs.Visible = true;
            
            
        }
           

        private void tabPage2_Click(object sender, EventArgs e)
        {
            var model = Adibahce.Personel.Select(x => new { AdSoyad = x.PersonelAdSoyad, GüncelTutar = x.PersonelMaas / 300 }).ToList();
            foreach (var item in model)
            {
                Ozet.DataSource = item;


            }
            Adibahce.SaveChanges();
        }

        public void ToplamMesai(String Text)
        {
            try
            {
                int kontrol = Convert.ToInt32(Text);
       
                var query = Adibahce.Personel.ToList();
                if (Ay.Text != "")
                    foreach (var item in query)
                    {
                        var query1 = Adibahce.Shift.Where(x => x.PersonelAdSoyad == item.PersonelAdSoyad && x.Ay_ID == kontrol).Select(x => x.Fark).ToList();
                        Personel p = Adibahce.Personel.First(x => x.Personel_ID == item.Personel_ID);
                        p.PersonelMesaiSaat = 0;
                        foreach (var item1 in query1)
                        {
                            if (item1 != null)
                                p.PersonelMesaiSaat += item1.Value.TotalHours;

                        }




                        Adibahce.SaveChanges();
                    }
                else if (GuncelYil.Text != "")
                    foreach (var item in query)
                    {
                        var query1 = Adibahce.Shift.Where(x => x.PersonelAdSoyad == item.PersonelAdSoyad && x.Yil_ID == kontrol).Select(x => x.Fark).ToList();
                        Personel p = Adibahce.Personel.First(x => x.Personel_ID == item.Personel_ID);
                        p.PersonelMesaiSaat = 0;
                        foreach (var item1 in query1)
                        {
                            if (item1 != null)
                                p.PersonelMesaiSaat += item1.Value.TotalHours;

                        }




                        Adibahce.SaveChanges();
                    }
                else if (PersonelCbx.Text != "")
                    foreach (var item in query)
                    {
                        var query1 = Adibahce.Shift.Where(x => x.PersonelAdSoyad == item.PersonelAdSoyad).Select(x => x.Fark).ToList();
                        Personel p = Adibahce.Personel.First(x => x.Personel_ID == item.Personel_ID);
                        p.PersonelMesaiSaat = 0;
                        foreach (var item1 in query1)
                        {
                            if (item1 != null)
                                p.PersonelMesaiSaat += item1.Value.TotalHours;

                        }




                        Adibahce.SaveChanges();
                    }
                else
                    foreach (var item in query)
                    {
                        var query1 = Adibahce.Shift.Where(x => x.PersonelAdSoyad == item.PersonelAdSoyad && x.Ay_ID == kontrol).Select(x => x.Fark).ToList();
                        Personel p = Adibahce.Personel.First(x => x.Personel_ID == item.Personel_ID);
                        p.PersonelMesaiSaat = 0;
                        foreach (var item1 in query1)
                        {
                            if (item1 != null)
                                p.PersonelMesaiSaat += item1.Value.TotalHours;

                        }




                        Adibahce.SaveChanges();
                    }

            }
            catch (Exception)
            {

                String Ad = Text;
         
                var query = Adibahce.Personel.Where(x=>x.PersonelAdSoyad==Ad).ToList();
               
           
                    foreach (var item in query)
                    {
                        var query1 = Adibahce.Shift.Where(x => x.PersonelAdSoyad == item.PersonelAdSoyad).Select(x => x.Fark).ToList();
                        Personel p = Adibahce.Personel.First(x => x.Personel_ID == item.Personel_ID);
                        p.PersonelMesaiSaat = 0;
                        foreach (var item1 in query1)
                        {
                            if (item1 != null)
                                p.PersonelMesaiSaat += item1.Value.TotalHours;

                        }




                        Adibahce.SaveChanges();
                    }

            }
            Adibahce.SaveChanges();














        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
             
                int yiltext = int.Parse(GuncelYil.Text);
                int aytext = int.Parse(Ay.Text);
                int guntext = int.Parse(Gun.Text);
                var deneme = Adibahce.Shift.Where(x => x.Yil_ID == yiltext && x.Ay_ID == aytext && x.Gun_ID == guntext).ToList();
                
                
                    Yil.DataSource = deneme;
                    Yil.Refresh();
                
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen Ay-Yıl Seçimi Yapınız", "Uyarı");
            }
            
        }
    }
}
