using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdibahceCalismaCizelge
{
    public partial class Form3 : MaterialSkin.Controls.MaterialForm
    {
        public Form3()
        {
            InitializeComponent();
            
            
        }
        public bool Control(TextBox t1, TextBox t2, TextBox t3,CheckBox check1,CheckBox check2 ,CheckBox check3)
        {
            bool kontrol=false;
            if (t1.Text != "" && t2.Text != "" && t3.Text != ""&&check1.Checked==false)
            {
                TimeSpan saat = new TimeSpan();
              
                if (true)
                {
                    try
                    {
                        saat = TimeSpan.Parse(t1.Text);
                        saat = TimeSpan.Parse(t2.Text);
                        saat = TimeSpan.Parse(t3.Text);
                      
                        return true;

                    }
                    catch (Exception)
                    {
                        kontrol = false;
                        MessageBox.Show("Lütfen Saat Tipinde bir veri Giriniz!!", "Uyarı");
                    }
                }
                

            }
            else if (t1.Text == "" && t2.Text == "" && t3.Text == "" && check1.Checked)
            {
                kontrol = true;
                return kontrol;
            }
            else if(t1.Text!=""&&t2.Text==""&&t3.Text==""&& check1.Checked == false)
            {
                return true;
            }
            else if (t1.Text == "" && t2.Text == "" && t3.Text == "" && check2.Checked )
            {
                return true;
            }
            else if (t1.Text == "" && t2.Text == "" && t3.Text == "" && check3.Checked )
            {
                return true;
            }
            else
            {
                MessageBox.Show("Bir Hata Oluştu veri Kaydedilemiyor");
            }

            return kontrol;
        }
        public bool GuncelControl(TextBox t1, TextBox t2, TextBox t3)
        {
            bool kontrol = true;
            if (t1.Text != "" && t2.Text != "" && t3.Text != "")
            {
                TimeSpan saat = new TimeSpan();

                if (true)
                {
                    try
                    {
                        saat = TimeSpan.Parse(t1.Text);
                        saat = TimeSpan.Parse(t2.Text);
                        saat = TimeSpan.Parse(t3.Text);

                    }
                    catch (Exception)
                    {
                        kontrol = false;
                        MessageBox.Show("Lütfen Saat Tipinde bir veri Giriniz!!", "Uyarı");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Saat Tipinde bir veri Giriniz!!", "Uyarı");
                }

            }
            else if (t1.Text != "" || t2.Text != "" || t3.Text != "")
            {
                MessageBox.Show("Lütfen Alanları Boş Bırakmayınız...", "Uyarı");
            }
            return kontrol;
        }
        public void ToplamMesai()
        {
            var query = Form1.Adibahce.Personel.Where(x => x.PersonelAdSoyad== label1.Text.ToString()).Select(x => x.Personel_ID).ToList();
            var query1 = Form1.Adibahce.Shift.Where(x => x.PersonelAdSoyad == label1.Text.ToString()&&x.Ay_ID==GunTarihi.Value.Month).Select(x => x.Fark).ToList();
           
              
            int id = query.FirstOrDefault();
            Personel p = Form1.Adibahce.Personel.FirstOrDefault(x => x.Personel_ID == id);

            
                p.PersonelMesaiSaat = 0;
            foreach (var item in query1)
            {
                if(item!=null)
                p.PersonelMesaiSaat += item.Value.TotalHours;

            }




            Form1.Adibahce.SaveChanges();
        }
        public bool TextBoxControl(TextBox t1,TextBox t2,TextBox t3)
        {
            bool kontrol = true;
            if (Convert.ToDateTime(t1.Text) >= Convert.ToDateTime("00:00") && Convert.ToDateTime(t1.Text) <= Convert.ToDateTime("05:00"))
                return kontrol;
           else if (Convert.ToDateTime(t2.Text) >= Convert.ToDateTime("00:00") && Convert.ToDateTime(t2.Text) <=Convert.ToDateTime("05:00"))
            {
                DateTime date = Convert.ToDateTime(t2.Text);
                DateTime yeni = new DateTime(date.Year, date.Month,date.AddDays(1).Day,date.Hour,date.Minute,date.Second);
                
          

        
                
                var a = yeni -Convert.ToDateTime(t1.Text);
                t3.Text = Convert.ToString(a).Substring(0, 5);
                kontrol = false;
            }


            return kontrol;
        }
        public bool NullKontrol(TextBox tbx)
        {
            DateTime deneme = DateTime.Now ;
            bool kontrol = false;
            if (Object.ReferenceEquals(tbx.GetType(),deneme))
            {
                kontrol = true;
            }
            return kontrol;
        }

        public void ResetTextValue()
        {
            textBox1.ResetText();
            textBox2.ResetText();
            textBox3.ResetText();
            textBox4.ResetText();
            textBox5.ResetText();
            textBox6.ResetText();
            textBox7.ResetText();
            textBox8.ResetText();
           
            checkBox1.Checked=false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
        }
    
        public void FormDoldur(Label label1,DateTime d)
        {
            try
            {
                ResetTextValue();
                ToplamMesai();
           
                if (Giris.k.AdminMi == false)
                {
                    comboBox1.Visible = true;

                    button5.Visible = false;
                    GunTarihi.Visible = false;
                    button3.Visible = false;
                   

                    var query1 = Form1.Adibahce.Shift.Where(x => x.PersonelAdSoyad == label1.Text.ToString()).Where(x => x.Yil_ID == d.Year).Where(x => x.Ay_ID == d.Month).Where(x => x.Gun_ID == d.Day).ToList();

                    foreach (var item in query1)
                    {
                        if (item.Antre == true)
                        {
                            checkBox7.Checked = true;
                            ResetTextValue();
                            AntreDoldur(d.Date);
                        }
                        if (item.GirisSaati.ToString() != "")
                            textBox1.Text = item.GirisSaati.ToString().Substring(0, 5);
                        if (item.CikisSaati.ToString() != "")
                            textBox2.Text = item.CikisSaati.ToString().Substring(0, 5);
                        if (item.Fark.ToString() != "")
                            textBox3.Text = item.Fark.ToString().Substring(0, 5);
                        checkBox1.Checked = item.Izinli;
                        checkBox2.Checked = item.Yok;
                        checkBox3.Checked = item.Raporlu;
                    }
                }
                else if (Giris.k.AdminMi == true)
                {
                    button3.Visible = true;
                    button4.Visible = true;
                    var query = Form1.Adibahce.Shift.Where(x => x.PersonelAdSoyad == label1.Text.ToString()).Where(x => x.Yil_ID == d.Year).Where(x => x.Ay_ID == d.Month).Where(x => x.Gun_ID == d.Day).ToList();
                    foreach (var item in query)
                    {
                        if (item.Antre == true)
                        {
                            checkBox7.Checked = true;
                            ResetTextValue();
                            AntreDoldur(d.Date);
                        }
                        if (item.GirisSaati.ToString() != "")
                            textBox1.Text = item.GirisSaati.ToString().Substring(0, 5);
                        if (item.CikisSaati.ToString() != "")
                            textBox2.Text = item.CikisSaati.ToString().Substring(0, 5);
                        if (item.Fark.ToString() != "")
                            textBox3.Text = item.Fark.ToString().Substring(0, 5);
                        checkBox1.Checked = item.Izinli;
                        checkBox2.Checked = item.Yok;
                        checkBox3.Checked = item.Raporlu;
                    }
                    var queryPersonel = Form1.Adibahce.Personel.Where(x => x.PersonelAdSoyad == label1.Text.ToString()).ToList();
                    foreach (var item in queryPersonel)
                    {
                        PersonelEkleTbox.Text = item.PersonelAdSoyad;
                        GirisTarihi.Value = item.PersonelGirisTarihi;
                        MaasTbox.Text = item.PersonelMaas.ToString();
                        MesaiTbx.Text = Convert.ToString(Math.Round(Convert.ToDouble(item.PersonelMesaiSaat), 4));

                    }
                }

            }
            catch (Exception e)
            {
               
            }

           
        }
        private void Form3_Load(object sender, EventArgs e)
        {
           
           
            label1.Text = this.Text;
            if (Form1.Adibahce.Shift.Where(x => x.PersonelAdSoyad == label1.Text).ToList().Count() != 0)
            {
                comboBox1.Items.Clear();
                var sontarih = Form1.Adibahce.Shift.Where(x => x.PersonelAdSoyad == label1.Text.ToString()).Select(x => x.Tarih).ToList().Last();
                comboBox1.Items.Add(sontarih.Value.ToShortDateString());
            }

            FormDoldur(label1,DateTime.Now.Date);
            this.ResetText();
            ToplamMesai();

        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Now.ToShortTimeString();
        }

        private void textBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox2.Text = GunTarihi.Value.ToShortTimeString();
            TextBoxControl(textBox1, textBox2, textBox3);
        }                     
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    if (NullKontrol(textBox1))
                        MessageBox.Show("Lütfen Giriş ve Çıkış Saati Giriniz!!!!", "Uyarı");
                    else
                    {
                        var a = Convert.ToDateTime(textBox2.Text).Subtract(Convert.ToDateTime(textBox1.Text));
                        textBox3.Text = Convert.ToString(a).Substring(0, 5);
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen Giriş Saatini Düzgün Biçimde Giriniz...!!!!!","Uyarı");
            }
            
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (Control(textBox1, textBox2, textBox3,checkBox1,checkBox2,checkBox3))
                {
                 
                    Shift s = new Shift();
                    var item1 =Form1.Adibahce.Shift.ToList();
                    s.Tarih = GunTarihi.Value.Date;

                    s.Shift_ID =Form1.Adibahce.Shift.Count() + 1;
                    s.Yil_ID = GunTarihi.Value.Year;
                    s.Ay_ID = GunTarihi.Value.Month;
                    s.Gun_ID = GunTarihi.Value.Day;
                    s.PersonelAdSoyad = label1.Text;
                    if(textBox1.Text!="")
                    {
                        s.GirisSaati = TimeSpan.Parse(textBox1.Text);
                    }
                   
                    if (textBox2.Text != "")
                    {
                        s.CikisSaati = TimeSpan.Parse(textBox2.Text);
                    }
                   
                    if (textBox3.Text != "")
                    {
                        s.Fark = TimeSpan.Parse(textBox3.Text);
                    }


                    s.Izinli = Convert.ToBoolean(checkBox1.Checked);
                    s.Yok = Convert.ToBoolean(checkBox2.Checked);
                    s.Raporlu = Convert.ToBoolean(checkBox3.Checked);
                    bool kontrol = false;
                    foreach (var item in item1)
                    {
                        if (item.Yil_ID == GunTarihi.Value.Year && item.Ay_ID == GunTarihi.Value.Month && item.Gun_ID == GunTarihi.Value.Day && item.PersonelAdSoyad == label1.Text)
                        {
                            MessageBox.Show("Aynı Tarihe Aynı kişi için veri kaydedilemez!!!", "Uyarı");
                            kontrol = true;
                        }
                    }

                    if (kontrol == false)
                    {
                     Form1.Adibahce.Shift.Add(s);
                    Form1.Adibahce.SaveChanges();
                        MessageBox.Show("Veri Başarıyla Kaydedildi", "Mesaj");
                        FormDoldur(label1,GunTarihi.Value);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Veri Kaydetmeden önce ,İlk olarak Giriş/Çıkış saatini eğer Personel İzinli/Yok/Raporlu Durumunu Doldurunuz.", "Uyarı");
                }
               
            }
            catch (Exception)
            {

                MessageBox.Show("Veri Kaydedilirken Bir Hata Oluştu Lütfen Tekrar Deneyiniz.", "Uyarı");
            }
            
            
            

        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Form1 frm1 = (Form1)Application.OpenForms["Form1"];



                frm1.PanelTemizle();
                frm1.PersonelOlustur();
                frm1.Yenile();
            }
            catch (Exception)
            {

               
            }
            
      



        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime d;
            if (comboBox1.Text != "")
            {
                d = Convert.ToDateTime(comboBox1.Text).Date;
            }
            else
            {
                d = GunTarihi.Value;
            }
            if (GuncelControl(textBox1, textBox2, textBox3))
            {
                try
                {
                 
                    var query = Form1.Adibahce.Shift.Where(x => x.PersonelAdSoyad == label1.Text.ToString()).Where(x => x.Yil_ID == d.Year).Where(x => x.Ay_ID == d.Month).Where(x => x.Gun_ID == d.Day).Select(x => x.Shift_ID).FirstOrDefault();
                 
                    Shift s = Form1.Adibahce.Shift.First(x => x.Shift_ID == query);
                    s.GirisSaati = TimeSpan.Parse(textBox1.Text);
                    s.CikisSaati = TimeSpan.Parse(textBox2.Text);
                    s.Fark = TimeSpan.Parse(textBox3.Text);
                    s.Izinli = Convert.ToBoolean(checkBox1.Checked);
                    s.Yok = Convert.ToBoolean(checkBox2.Checked);
                    s.Raporlu = Convert.ToBoolean(checkBox3.Checked);
                  Form1.Adibahce.SaveChanges();
                    MessageBox.Show("Güncelleme işlemi Başarıyla Tamamlanmıştır..", "Mesaj");
                    FormDoldur(label1,d);
                }
                catch (Exception)
                {
                    MessageBox.Show("LÜtfen veri Güncellemek için Önce veri Ekleyiniz!!!", "Uyarı");
                    
                }
                


            }





        }

      
        private void GunTarihi_ValueChanged(object sender, EventArgs e)
        {
            checkBox7.Checked = false;
            panel3.Visible = false;
            FormDoldur(label1,GunTarihi.Value);
        }

        private void textBox2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13 || e.KeyValue == 9)
                {
                    if (textBox2.Text == "" && textBox2.Text == "")
                        MessageBox.Show("Lütfen Giriş ve Çıkış Saati Giriniz!!!!", "Uyarı");
                    else
                    {
                        if (textBox1.Text.Length.Equals(5) && textBox2.Text.Length.Equals(5))
                        {
                            if (textBox1.Text == "24:00" || textBox2.Text == "24:00")
                            {
                                MessageBox.Show("Lütfen Saat dilimini 00:00 ile 23:59 aralığında giriniz ", "Uyarı");
                            }
                            else
                            {
                                        if (TextBoxControl(textBox1, textBox2, textBox3))
                                {
                                    var a = Convert.ToDateTime(textBox2.Text).Subtract(Convert.ToDateTime(textBox1.Text));
                                    textBox3.Text = Convert.ToString(a).Substring(0, 5);
                                }
                                



                            }

                        }
                        else
                        {
                            MessageBox.Show("Saati yanlış girdiniz,Lütfen düzeltiniz!!!", "Uyarı");
                        }

                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen Giriş Saatini Düzgün Biçimde Giriniz...!!!!!", "Uyarı");
            }
            
        }

       

        private void textBox3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {

                if (TextBoxControl(textBox1, textBox2, textBox3))
                {
                    var a = Convert.ToDateTime(textBox2.Text).Subtract(Convert.ToDateTime(textBox1.Text));
                    textBox3.Text = Convert.ToString(a).Substring(0, 5);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Giriş/Çıkış verisini Yanlış Girdiniz!!", "Uyarı");
            }
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show(label1.Text + " Adlı Kişiyi Silmek İstediğinize Eminmisiniz?", "Personel Silme", MessageBoxButtons.YesNoCancel);
            if(d==DialogResult.Yes)
            {
              
                var asa = Form1.Adibahce.Personel.Where(x => x.PersonelAdSoyad == label1.Text).Select(x => x.Personel_ID).ToList().FirstOrDefault();

                Personel p = Form1.Adibahce.Personel.First(x => x.Personel_ID == asa);
                Form1.Adibahce.Personel.Remove(p);
                Form1.Adibahce.SaveChanges();
                MessageBox.Show("Personel Silme İşlemi Başarıyla Tamamlandı", "Mesaj");
            }
            else
            {
                MessageBox.Show("Personel Silme İşlemiminden Vazgeçildi", "Mesaj");
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
              
                var PersonelGun = Form1.Adibahce.Personel.Where(x => x.PersonelAdSoyad == label1.Text).Select(x => x.Personel_ID).FirstOrDefault();
                Personel p = Form1.Adibahce.Personel.FirstOrDefault(x => x.Personel_ID == PersonelGun);
                p.PersonelAdSoyad = PersonelEkleTbox.Text;
                p.PersonelGirisTarihi = GirisTarihi.Value;
                p.PersonelMaas = Convert.ToDouble(MaasTbox.Text);
                Form1.Adibahce.SaveChanges();
                MessageBox.Show("Güncelleme İşlemi Başarıyla Tamamlandı", "Mesaj");
                FormDoldur(label1,GunTarihi.Value);
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen Verileri Doğru Girdiğinizden emin olun", "Uyarı");
            }
           
        }

        private void button5_Click(object sender, EventArgs e)

        {
            DateTime d;
            if (comboBox1.Text != "")
            {
                d = Convert.ToDateTime(comboBox1.Text).Date;
            }
            else
            {
                d = GunTarihi.Value;
            }
            DialogResult dr = MessageBox.Show("Veriyi Silmek İstediğinize Eminmisiniz", "Uyarı", MessageBoxButtons.YesNo);
            if(dr==DialogResult.Yes)
            {
                try
                {
              
                    var query = Form1.Adibahce.Shift.Where(x => x.PersonelAdSoyad == label1.Text.ToString()).Where(x => x.Yil_ID == d.Year).Where(x => x.Ay_ID ==d.Month).Where(x => x.Gun_ID == d.Day).Select(x => x.Shift_ID).FirstOrDefault();
                    var query1 = Form1.Adibahce.Antre.Where(x => x.PersonelAdSoyad == label1.Text && x.Tarih == d.Date).Select(x => x.Id).FirstOrDefault();
                  
                    Shift s = Form1.Adibahce.Shift.First(x => x.Shift_ID == query);
                    Form1.Adibahce.Shift.Remove(s);
                    try
                    {
                        Antre a = Form1.Adibahce.Antre.FirstOrDefault(x => x.Id == query1);
                        Form1.Adibahce.Antre.Remove(a);
                    }
                    catch (Exception)
                    {

                     
                    }
                   
                    

                    Form1.Adibahce.SaveChanges();
                    MessageBox.Show("Veri Başarıyla Silindi", "Mesaj");
                    FormDoldur(label1,GunTarihi.Value);
                }
                catch (Exception)
                {

                    MessageBox.Show("Lütfen Belirtilen Tarih Aralığında Veri Olduğundan Emin Olunuz", "Veri Silinemedi");
                }
              
            }
            else
            {
                MessageBox.Show("Veri Silme İşleminden Vazgeçildi", "Mesaj");
            }
           
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            DateTime d = Convert.ToDateTime(comboBox1.Text);
           
            FormDoldur(label1, d.Date);
           
           
        }

        private void textBox6_DoubleClick(object sender, EventArgs e)
        {
            textBox6.Text =DateTime.Now.ToShortTimeString();
        }

        private void textBox5_DoubleClick(object sender, EventArgs e)
        {
            textBox5.Text = DateTime.Now.ToShortTimeString();
        }

        private void textBox8_DoubleClick(object sender, EventArgs e)
        {
            if (textBox4.Text == "24:00" || textBox5.Text == "24:00" && textBox6.Text == "24:00" || textBox7.Text == "24:00")
            {
                MessageBox.Show("Lütfen Saat dilimini 00:00 ile 23:59 aralığında giriniz ", "Uyarı");
            }
            bool kontrol = true;
            TimeSpan t = new TimeSpan();
            try
            {
                if (textBox4.Text != "")
                    t = TimeSpan.Parse(textBox4.Text);
                if (textBox5.Text != "")
                    t = TimeSpan.Parse(textBox5.Text);
                if (textBox6.Text != "")
                    t = TimeSpan.Parse(textBox6.Text);
                if (textBox7.Text != "")
                    t = TimeSpan.Parse(textBox7.Text);

            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen Saat Formatında veri giriniz!!", "Uyarı");
                kontrol = false;
            }
            if (TextBoxControl(textBox6, textBox7, textBox8))
            {
                var a = Convert.ToDateTime(textBox7.Text).Subtract(Convert.ToDateTime(textBox6.Text));
                textBox8.Text = Convert.ToString(a).Substring(0, 5);
            }
            textBox8.Text = Convert.ToString(Convert.ToDateTime(textBox5.Text).Subtract(Convert.ToDateTime(textBox4.Text)) + TimeSpan.Parse(textBox8.Text));
        }

        private void textBox7_DoubleClick(object sender, EventArgs e)
        {
            textBox7.Text = DateTime.Now.ToShortTimeString();
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    if (NullKontrol(textBox6))
                        MessageBox.Show("Lütfen Giriş ve Çıkış Saati Giriniz!!!!", "Uyarı");
                    else
                    {
                        var a = Convert.ToDateTime(textBox2.Text).Subtract(Convert.ToDateTime(textBox6.Text));
                        textBox6.Text = Convert.ToString(a).Substring(0, 5);
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen Giriş Saatini Düzgün Biçimde Giriniz...!!!!!", "Uyarı");
            }

        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            panel3.Visible = true;
        }
       
        private void button8_Click(object sender, EventArgs e)
        {
            DateTime d;
            if (comboBox1.Text!="")
            {
                  d = Convert.ToDateTime(comboBox1.Text);
            }
          
            else
            {
                d = GunTarihi.Value.Date;
            }
            try
            {
                bool kontrol = true;
                TimeSpan t = new TimeSpan();
                try
                {
                    if (textBox4.Text != "")
                        t = TimeSpan.Parse(textBox4.Text);
                    if (textBox5.Text != "")
                        t = TimeSpan.Parse(textBox5.Text);
                    if (textBox6.Text != "")
                        t = TimeSpan.Parse(textBox6.Text);
                    if (textBox7.Text != "")
                        t = TimeSpan.Parse(textBox7.Text);

                }
                catch (Exception)
                {

                    MessageBox.Show("Lütfen Saat Formatında veri giriniz!!", "Uyarı");
                    kontrol = false;
                }

                if (kontrol)
                {
                   
                    Antre a = new Antre();
                    var sorgu = Form1.Adibahce.Antre.ToList();
                    a.Id = Form1.Adibahce.Antre.Count() + 1;
                    a.PersonelAdSoyad = label1.Text;
                    a.Tarih =GunTarihi.Value.Date;
                    if (textBox4.Text != "")
                        a.BirinciGiris = TimeSpan.Parse(textBox4.Text);
                    if (textBox5.Text != "")
                        a.BirinciCikis = TimeSpan.Parse(textBox5.Text);
                    if (textBox6.Text != "")
                        a.İkinciGiris = TimeSpan.Parse(textBox6.Text);
                    if (textBox7.Text != "")
                        a.İkinciCikis = TimeSpan.Parse(textBox7.Text);
                    if (textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
                        a.Fark = TimeSpan.Parse(textBox8.Text);
                   
                    Shift s = new Shift();
                    s.Shift_ID = Form1.Adibahce.Shift.Count() + 1;
                    s.PersonelAdSoyad = label1.Text;
                    s.Tarih = GunTarihi.Value.Date;
                    s.Yil_ID = GunTarihi.Value.Year;
                    s.Ay_ID = GunTarihi.Value.Month;
                    s.Gun_ID = GunTarihi.Value.Day;
                    s.Antre = true;
                    bool veri = false;
                    foreach (var item in  sorgu )
                    {
                      
                        if(item.PersonelAdSoyad==label1.Text&&item.Tarih==GunTarihi.Value.Date)
                        {
                            MessageBox.Show("Aynı Tarihe Aynı Kişi için veri Kaydedilemez!!", "Uyarı");
                            veri = true;
                        }
                    }
                    if(veri==false)
                    {
                        
                        Form1.Adibahce.Shift.Add(s);

                        Form1.Adibahce.Antre.Add(a);
                        Form1.Adibahce.SaveChanges();
                        if (textBox8.Text != "")
                        {
                            var query = Form1.Adibahce.Shift.Where(x => x.PersonelAdSoyad == label1.Text.ToString()).Where(x => x.Yil_ID == GunTarihi.Value.Year).Where(x => x.Ay_ID == GunTarihi.Value.Month).Where(x => x.Gun_ID == GunTarihi.Value.Day).Select(x => x.Shift_ID).FirstOrDefault();
                            Shift sh = Form1.Adibahce.Shift.FirstOrDefault(x => x.Shift_ID == query);
                            sh.Fark = a.Fark;
                            Form1.Adibahce.SaveChanges();
                        }
                        
                        MessageBox.Show("Veri Başarıyla Kaydedildi", "Mesaj");
                        FormDoldur(label1,d.Date); 
                        
                    }
                    

                   
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Veri Kaydedilirken Bir Hata Oluştu,Veri Kaydedilemedi", "Uyarı ");
            }
            
        }

        private void textBox7_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyValue == 13 || e.KeyValue == 9)
            {
                if (textBox4.Text == "24:00" || textBox5.Text == "24:00"&&textBox6.Text == "24:00" || textBox7.Text == "24:00")
                {
                    MessageBox.Show("Lütfen Saat dilimini 00:00 ile 23:59 aralığında giriniz ", "Uyarı");
                }
              
                TimeSpan t = new TimeSpan();
                try
                {
                    if (textBox4.Text != "")
                        t = TimeSpan.Parse(textBox4.Text);
                    if (textBox5.Text != "")
                        t = TimeSpan.Parse(textBox5.Text);
                    if (textBox6.Text != "")
                        t = TimeSpan.Parse(textBox6.Text);
                    if (textBox7.Text != "")
                        t = TimeSpan.Parse(textBox7.Text);
                    if (TextBoxControl(textBox6, textBox7, textBox8))
                    {
                        var a = Convert.ToDateTime(textBox7.Text).Subtract(Convert.ToDateTime(textBox6.Text));
                        textBox8.Text = Convert.ToString(a).Substring(0, 5);
                    }
                    textBox8.Text = Convert.ToString(Convert.ToDateTime(textBox5.Text).Subtract(Convert.ToDateTime(textBox4.Text)) + TimeSpan.Parse(textBox8.Text)).Substring(0,5);
                }
                catch (Exception)
                {

                    MessageBox.Show("Lütfen Saat Formatında veri giriniz!!", "Uyarı");
                    
                }
                


            }
        }

        private void textBox4_DoubleClick(object sender, EventArgs e)
        {
            textBox4.Text= DateTime.Now.ToShortTimeString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DateTime d;
            if(comboBox1.Text!="")
            {
                d = Convert.ToDateTime(comboBox1.Text).Date;
            }
            else
            {
                d = GunTarihi.Value.Date;
            }
            
            if (Form1.Adibahce.Antre.Where(x=>x.Tarih==d&&x.PersonelAdSoyad==label1.Text).ToList().Count()!=0)
            {

                TimeSpan t = new TimeSpan();
                try
                {
                    if (textBox4.Text != "")
                        t = TimeSpan.Parse(textBox4.Text);
                    if (textBox5.Text != "")
                        t = TimeSpan.Parse(textBox5.Text);
                    if (textBox6.Text != "")
                        t = TimeSpan.Parse(textBox6.Text);
                    if (textBox7.Text != "")
                        t = TimeSpan.Parse(textBox7.Text);

                    var adb = Form1.Adibahce.Antre.Where(x => x.Tarih == d&& x.PersonelAdSoyad == label1.Text).Select(x => x.Id).FirstOrDefault();
                    Antre a = Form1.Adibahce.Antre.First(x => x.Id == adb);
                    if (textBox4.Text != "")
                        a.BirinciGiris = TimeSpan.Parse(textBox4.Text);
                    if (textBox5.Text != "")
                        a.BirinciCikis = TimeSpan.Parse(textBox5.Text);
                    if (textBox6.Text != "")
                        a.İkinciGiris = TimeSpan.Parse(textBox6.Text);
                    if (textBox7.Text != "")
                        a.İkinciCikis = TimeSpan.Parse(textBox7.Text);
                    if (textBox8.Text != "")
                        a.Fark = TimeSpan.Parse(textBox8.Text);
                    if(textBox8.Text != "")
                    {
                        var query = Form1.Adibahce.Shift.Where(x => x.PersonelAdSoyad == label1.Text.ToString()).Where(x => x.Yil_ID == d.Year).Where(x => x.Ay_ID == d.Month).Where(x => x.Gun_ID == d.Day).Select(x => x.Shift_ID).FirstOrDefault();
                        Shift s = Form1.Adibahce.Shift.FirstOrDefault(x => x.Shift_ID == query);
                        s.Fark = a.Fark;
                    }
                    Form1.Adibahce.SaveChanges();
                    MessageBox.Show("Güncelleme İşlemi Başarıyla Tamamlandı", "Mesaj");
                    FormDoldur(label1, d);


                }
                catch (Exception)
                {

                    MessageBox.Show("Lütfen Saat Formatında veri giriniz!!", "Uyarı");

                }
            }
            else
            {
                MessageBox.Show("Veri Güncellemek İçin ,Önce Veri Eklemelisiniz ", "Uyarı");
            }
           
            
        }
        public void AntreDoldur(DateTime d)
        {
            ResetTextValue();
          
            var query = Form1.Adibahce.Antre.Where(x => x.PersonelAdSoyad == label1.Text && x.Tarih ==d.Date).ToList();
            foreach (var item in query)
            {
                if (item.BirinciGiris.ToString() != "")
                    textBox4.Text = item.BirinciGiris.ToString().Substring(0,5);
                if (item.BirinciCikis.ToString() != "")
                    textBox5.Text = item.BirinciCikis.ToString().Substring(0,5);
                if (item.İkinciGiris.ToString() != "")
                    textBox6.Text = item.İkinciGiris.ToString().Substring(0,5);
                if (item.İkinciCikis.ToString() != "")
                    textBox7.Text = item.İkinciCikis.ToString().Substring(0,5);
                if (item.Fark.ToString() != "")
                    textBox8.Text = item.Fark.ToString().Substring(0,5);
            }
        }
    }
}
