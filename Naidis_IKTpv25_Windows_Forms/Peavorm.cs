using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Naidis_IKTpv25_Windows_Forms
{
    public class PeaVorm : Form
    {
        private Button nuppVike;
        private Button nuppKeskmine;
        private Button nuppSuur;

        public PeaVorm()
        {
            Text = "Peaaken - Valikud";
            Size = new Size(400, 250);
            StartPosition = FormStartPosition.CenterScreen;

            // 1. Nupp: Väike aken
            nuppVike = new Button();
            nuppVike.Text = "Ava väike aken";
            nuppVike.Location = new Point(50, 30);
            nuppVike.Size = new Size(280, 40);
            nuppVike.Click += NuppVike_Click;

            // 2. Nupp: Keskmine aken
            nuppKeskmine = new Button();
            nuppKeskmine.Text = "Ava keskmine aken";
            nuppKeskmine.Location = new Point(50, 80);
            nuppKeskmine.Size = new Size(280, 40);
            nuppKeskmine.Click += NuppKeskmine_Click;

            // 3. Nupp: Suur aken
            nuppSuur = new Button();
            nuppSuur.Text = "Ava suur aken";
            nuppSuur.Location = new Point(50, 130);
            nuppSuur.Size = new Size(280, 40);
            nuppSuur.Click += NuppSuur_Click;

            // Lisame nupud avavormile
            Controls.Add(nuppVike);
            Controls.Add(nuppKeskmine);
            Controls.Add(nuppSuur);
        }

        private void NuppVike_Click(object sender, EventArgs e)
        {
            // Edastame konstruktorile: pealkiri, laius, kõrgus, värv
            AlamVorm vikeVorm = new AlamVorm ("Väike Aken", 300, 200, Color.LightGreen);
            vikeVorm.Show();
        }

        private void NuppKeskmine_Click(object sender, EventArgs e)
        {
            AlamVorm keskmineVorm = new AlamVorm("Keskmine Aken", 500, 350, Color.LightSkyBlue);
            keskmineVorm.Show();
        }

        private void NuppSuur_Click(object sender, EventArgs e)
        {
            AlamVorm suurVorm = new AlamVorm("Suur Aken", 700, 500, Color.LightCoral);
            suurVorm.Show();
        }
    }
}
