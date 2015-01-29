using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Søylediagram
{
    public partial class Form1 : Form
    {

        // Lager en array som skal inneholde søylenes høyde (0..1)
        double[] yr = new double[4];
        // Lager en array med farger for søylene
        Color[] sfarge = new Color[] { 
            Color.Red, Color.Blue, Color.Orange, Color.Green };
        // Setter opp en generator for tilfeldige tall
        Random random = new Random(DateTime.Now.Millisecond);

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int w, h, x1, sb;
            w = panel1.Width;
            h = panel1.Height;
            //Det skal være fire søyler med mellomrom 12,5-15-5-15-5-15-5-15-12,5
            sb = Convert.ToInt32((0.15) * w);   //Søylebredde
            x1 = Convert.ToInt32((0.125) * w);  // Startpunkt på x-aksen
            for (int i = 0; i < 4; i++)
            {
                // Genererer søyle
                Rectangle rect =
                    new Rectangle(x1, Convert.ToInt32(h - (yr[i] * h)), sb, h);
                SolidBrush brush = new SolidBrush(Color.Empty);
                brush.Color = sfarge[i];
                g.FillRectangle(brush, rect);
                // Finner startposisjon for neste søyle
                x1 = Convert.ToInt32(x1 + 0.2 * w);
            }
            g.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                yr[i] = random.NextDouble();
                Console.WriteLine("Y" + i + "=" + yr[i]);
            }
            panel1.Refresh();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                yr[i] = random.NextDouble();
                Console.WriteLine("Y" + i + "=" + yr[i]);
            }
            panel1.BorderStyle = BorderStyle.Fixed3D;
            button1.Text = "Nye søyler";

        }
    }
}
