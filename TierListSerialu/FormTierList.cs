using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TierListSerialu
{
    public partial class FormTierList : Form
    {
        public FormTierList()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void formTierList_Load(object sender, EventArgs e)
        {
            string cesta = Path.Combine(Application.StartupPath, "images");

            string[] soubory = Directory.GetFiles(cesta);
            foreach (string soubor in soubory)
            {
                PictureBox pb = new PictureBox();
                pb.Width = 150;
                pb.Height = 200;
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Image = Image.FromFile(soubor);

                flowLayoutPanelSerialy.Controls.Add(pb);
            }
        }
    }
}
