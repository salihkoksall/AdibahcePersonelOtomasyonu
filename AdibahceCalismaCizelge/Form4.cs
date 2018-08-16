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
    public partial class Form4 : MaterialSkin.Controls.MaterialForm
    {
        public Form4()
        {
            InitializeComponent();
        }

        public void OrtalamaAl(DateTime Baslangic, DateTime Bitis)
        {
            try
            {
              
                double ispat = 0;

                var item1 = Form1.Adibahce.Shift.Where(x => x.Tarih >= Baslangic.Date && x.Tarih <= Bitis.Date).Select(x => x.PersonelAdSoyad).Distinct();
                foreach (var deneme in item1)
                {
                    Double mesai = 0;
                    int gun = Bitis.Day - Baslangic.Day;
                    var item = Form1.Adibahce.Shift.Where(x => x.Tarih >= Baslangic.Date && x.Tarih <= Bitis.Date && x.PersonelAdSoyad == deneme && x.Izinli == false).Select(x => x.Fark).ToList();
                    foreach (var item2 in item)
                    {
                        mesai += item2.Value.TotalHours;
                    }

                    ispat = mesai / gun;
                    try
                    {
                        var ekle = Form1.Adibahce.Shift.Where(x => x.Tarih >= Baslangic.Date && x.Tarih <= Bitis.Date && x.PersonelAdSoyad == deneme && x.Izinli == true).Select(x => x.Shift_ID).FirstOrDefault();

                        Shift s = Form1.Adibahce.Shift.FirstOrDefault(x => x.Shift_ID == ekle);
                        Personel p = Form1.Adibahce.Personel.Where(x => x.PersonelAdSoyad == s.PersonelAdSoyad).FirstOrDefault();
                        s.Fark = TimeSpan.FromHours(ispat);
                        p.PersonelMesaiSaat = p.PersonelMesaiSaat + s.Fark.Value.TotalHours;
                        listBox1.Visible = true;
                        label1.Visible = true;
                        listBox1.Items.Add(s.PersonelAdSoyad);
                    }
                    catch (Exception)
                    {

                        MessageBox.Show(deneme + " Adlı Kişide Belirtilen Tarihlerde İzin Bulunamadı,Diğer Kişiler İçin tarama devam edecek");
                    }
                  
                    
                        

                    

                }
                Form1.Adibahce.SaveChanges();

                MessageBox.Show("Ortalama Alma işlemi Başarıyla Tamamlanmıştır..", "Mesaj");
            }
            catch (Exception)
            {

                MessageBox.Show("Bir hata ile Karşılaşıldı,lütfen Belirtilen tarihler arasında veri olduğundan emin olunuz!", "Uyarı");
            }
          
        }

        private void Form4_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ortalama almak içinbir Haftada ,Personelin Sadece 1 kere izinli olması gerekir,Yok veya Raporlu olunan durumda Ortalama alınamaz .Ortalama alma işlemi İstenilen hafta aralığında izin günününe diğer günlerin ortalaması alınarak ,izin gününün fark sütununa yazılır.  ", "Ortalama Alma Talimatları", MessageBoxButtons.OK);
            OrtalamaAl(dateTimePicker1.Value, dateTimePicker2.Value);
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Form1 frm1 = (Form1)Application.OpenForms["Form1"];

                frm1.Yenile();
            }
            catch (Exception)
            {

             
            }
            
        }
    }
}
