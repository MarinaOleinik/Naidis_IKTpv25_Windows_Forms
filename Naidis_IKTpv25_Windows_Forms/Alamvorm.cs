using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Naidis_IKTpv25_Windows_Forms
{
    public class AlamVorm : Form
    {
        // Konstruktor, mis võtab vastu atribuutide väärtused
        public AlamVorm(string pealkiri, int laius, int korgus, Color taustavarv)
        {
            // Määrame vormi omadused edastatud parameetrite põhjal
            this.Text = pealkiri;
            this.Size = new Size(laius, korgus);
            this.BackColor = taustavarv;
            this.StartPosition = FormStartPosition.CenterParent;

            // Lisame vormile sildi (Label), mis näitab parameetreid
            Label infoSilt = new Label();
            infoSilt.Text = $"Mõõtmed: {laius}x{korgus}";
            infoSilt.Dock = DockStyle.Fill;
            infoSilt.TextAlign = ContentAlignment.MiddleCenter;
            infoSilt.Font = new Font("Arial", 12, FontStyle.Bold);

            this.Controls.Add(infoSilt);
        }
    }
}
