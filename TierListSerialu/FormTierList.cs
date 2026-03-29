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
            flowLayoutPanelS.AllowDrop = true;
            flowLayoutPanelA.AllowDrop = true;
            flowLayoutPanelB.AllowDrop = true;
            flowLayoutPanelC.AllowDrop = true;
            flowLayoutPanelD.AllowDrop = true;
            flowLayoutPanelS.DragEnter += Panel_DragEnter;
            flowLayoutPanelS.DragDrop += Panel_DragDrop;

            flowLayoutPanelA.DragEnter += Panel_DragEnter;
            flowLayoutPanelA.DragDrop += Panel_DragDrop;

            flowLayoutPanelB.DragEnter += Panel_DragEnter;
            flowLayoutPanelB.DragDrop += Panel_DragDrop;

            flowLayoutPanelC.DragEnter += Panel_DragEnter;
            flowLayoutPanelC.DragDrop += Panel_DragDrop;

            flowLayoutPanelD.DragEnter += Panel_DragEnter;
            flowLayoutPanelD.DragDrop += Panel_DragDrop;
            string cesta = Path.Combine(Application.StartupPath, "images");

            string[] soubory = Directory.GetFiles(cesta);
            foreach (string soubor in soubory)
            {
                PictureBox pb = new PictureBox();
                pb.Width = 150;
                pb.Height = 126;
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.MouseDown += Pb_MouseDown;
                pb.Image = Image.FromFile(soubor);

                flowLayoutPanelSerialy.Controls.Add(pb);
            }
        }
        private void Pb_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            if (pb != null)
            {
                pb.DoDragDrop(pb, DragDropEffects.Move);
            }
        }
        private void Panel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(PictureBox)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }
        private void Panel_DragDrop(object sender, DragEventArgs e)
        {
            PictureBox pb = (PictureBox)e.Data.GetData(typeof(PictureBox));
            FlowLayoutPanel panel = sender as FlowLayoutPanel;

            if (pb != null && panel != null)
            {
                panel.Controls.Add(pb);
            }
        }

        private void NastavBarvyRekurzivne(Control c, Color backColor, Color foreColor)
        {
            if (c == labelS)
            {
                c.BackColor = Color.White;
                c.ForeColor = Color.Lime;
                return;
            }
            if (c == labelA)
            {
                c.BackColor = Color.White;
                c.ForeColor = Color.Cyan;
                return;
            }
            if (c == labelB)
            {
                c.BackColor = Color.White;
                c.ForeColor = Color.Yellow;
                return;
            }
            if (c == labelC)
            {
                c.BackColor = Color.White;
                c.ForeColor = Color.DarkGoldenrod;
                return;
            }
            if (c == labelD)
            {
                c.BackColor = Color.White;
                c.ForeColor = Color.Red;
                return;
            }

            c.BackColor = backColor;
            c.ForeColor = foreColor;

            foreach (Control child in c.Controls)
            {
                NastavBarvyRekurzivne(child, backColor, foreColor);
            }
        }
        private void NastavDarkRekurzivne(Control c)
        {
            if (c == labelS)
            {
                c.ForeColor = Color.Lime;
                c.BackColor = Color.Black;
                return;
            }
            if (c == labelA)
            {
                c.ForeColor = Color.Cyan;
                c.BackColor = Color.Black;
                return;
            }
            if (c == labelB)
            {
                c.ForeColor = Color.Yellow;
                c.BackColor = Color.Black;
                return;
            }
            if (c == labelC)
            {
                c.ForeColor = Color.DarkGoldenrod;
                c.BackColor = Color.Black;
                return;
            }
            if (c == labelD)
            {
                c.ForeColor = Color.Red;
                c.BackColor = Color.Black;
                return;
            }

            if (c is FlowLayoutPanel)
            {
                c.BackColor = Color.Black;
            }
            else
            {
                c.BackColor = Color.Black;
                c.ForeColor = Color.White;
            }

            foreach (Control child in c.Controls)
            {
                NastavDarkRekurzivne(child);
            }
        }
        private void NastavTema(Color backColor, Color foreColor)
        {
            this.BackColor = backColor;

            foreach (Control c in this.Controls)
            {
                NastavBarvyRekurzivne(c, backColor, foreColor);
            }
        }
        private void NastavDarkTema()
        {
            this.BackColor = Color.Black;

            foreach (Control c in this.Controls)
            {
                NastavDarkRekurzivne(c);
            }

            menuStrip1.BackColor = Color.White;
            menuStrip1.ForeColor = Color.Black;
        }

        private void toolStripMenuItemTmavy_Click(object sender, EventArgs e)
        {
            NastavDarkTema();
        }

        private void toolStripMenuItemSvetly_Click(object sender, EventArgs e)
        {
            NastavTema(SystemColors.Control, Color.Black);
        }
    }
}
