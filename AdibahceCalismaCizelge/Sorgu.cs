using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdibahceCalismaCizelge
{
    public class Sorgu
    {
        public AdibahceContainer Adibahce;


        public void PersonelSecimPaneli(Panel panel,  Label label)
        {

            panel.Controls.Clear();
            AdibahceContainer Adibahce = new AdibahceContainer();
            label.Text = DateTime.Now.ToShortDateString();

            var sorgu1 = Adibahce.Personel.Select(x => x.PersonelAdSoyad);
            int i = 0;

            foreach (var item in sorgu1)
            {

           
                Button btn = new System.Windows.Forms.Button();
                btn.Location = new System.Drawing.Point(0, 50 * i);
                btn.Size = new System.Drawing.Size(panel.Width, 50);
                btn.Text = item;
                btn.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                btn.BackColor = System.Drawing.Color.Transparent;
                panel.Controls.Add(btn);
              
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
    }
}
