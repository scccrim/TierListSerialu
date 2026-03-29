using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
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
        class SerialItem
        {
            public string Tier { get; set; }
            public string ImagePath { get; set; }
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
            flowLayoutPanelSerialy.AllowDrop = true;
            flowLayoutPanelSerialy.DragEnter += Panel_DragEnter;
            flowLayoutPanelSerialy.DragDrop += Panel_DragDrop;
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
                pb.Tag = soubor; 

                flowLayoutPanelSerialy.Controls.Add(pb);
            }
        }
        private void Pb_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PictureBox pb = sender as PictureBox;
                if (pb != null)
                {
                    pb.DoDragDrop(pb, DragDropEffects.Move);
                }
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
            FlowLayoutPanel cilovyPanel = sender as FlowLayoutPanel;

            if (pb != null && cilovyPanel != null)
            {
                if (pb.Parent == cilovyPanel) return;

                cilovyPanel.Controls.Add(pb);
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

        private void ResetTierList()
        {
            FlowLayoutPanel[] panely = {
        flowLayoutPanelS,
        flowLayoutPanelA,
        flowLayoutPanelB,
        flowLayoutPanelC,
        flowLayoutPanelD
    };

            foreach (FlowLayoutPanel panel in panely)
            {
                var controls = panel.Controls.Cast<Control>().ToList();

                foreach (Control c in controls)
                {
                    flowLayoutPanelSerialy.Controls.Add(c);
                }
            }
        }
        private void resetovatTierlistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetTierList();
        }

        private void toolStripMenuItemNapoveda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tento program umožňuje uživatelům vytvářet a upravovat tierlisty pro seriály. Uživatelé mohou přetahovat obrázky seriálů mezi různými tier panely (S, A, B, C, D) a hlavním panelem pro seriály. Program také nabízí možnost přepínat mezi světlým a tmavým tématem a resetovat tierlist zpět do výchozího stavu.", "Nápověda", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void OtevritReadme()
        {
            string cesta = Path.Combine(Application.StartupPath, "README.md");

            if (File.Exists(cesta))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = cesta,
                    UseShellExecute = true
                });
            }
            else
            {
                MessageBox.Show("Soubor README.md nebyl nalezen!");
            }
        }
        private void toolStripMenuItemAplikace_Click(object sender, EventArgs e)
        {
            OtevritReadme();
        }
        private void PridatSerial()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Obrázky (*.jpg;*.png*.jfif)|*.jpg;*.png;*.jfif";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string cilovaSlozka = Path.Combine(Application.StartupPath, "Images");

                if (!Directory.Exists(cilovaSlozka))
                {
                    Directory.CreateDirectory(cilovaSlozka);
                }

                string nazevSouboru = Path.GetFileName(ofd.FileName);
                string cilovaCesta = Path.Combine(cilovaSlozka, nazevSouboru);

                try
                {
                    File.Copy(ofd.FileName, cilovaCesta, true);

                    PictureBox pb = new PictureBox();
                    pb.Width = 150;
                    pb.Height = 126;
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                    pb.Image = Image.FromFile(cilovaCesta);
                    pb.MouseDown += Pb_MouseDown;
                    pb.Tag = cilovaCesta;

                    flowLayoutPanelSerialy.Controls.Add(pb);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Chyba: " + ex.Message);
                }
            }
        }
        private void přidatSerialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PridatSerial();
        }
        private void UlozitTierListJSON()
        {
            
            string slozka = Path.Combine(Application.StartupPath, "tierlist");

            if (!Directory.Exists(slozka))
            {
                Directory.CreateDirectory(slozka);
            }

            string cesta = Path.Combine(slozka, "tierlist.json");

            List<SerialItem> data = new List<SerialItem>();

            void UlozPanel(FlowLayoutPanel panel, string tier)
            {
                foreach (PictureBox pb in panel.Controls)
                {
                    if (pb.Tag != null)
                    {
                        data.Add(new SerialItem
                        {
                            Tier = tier,
                            ImagePath = pb.Tag.ToString()
                        });
                    }
                }
            }

            UlozPanel(flowLayoutPanelS, "S");
            UlozPanel(flowLayoutPanelA, "A");
            UlozPanel(flowLayoutPanelB, "B");
            UlozPanel(flowLayoutPanelC, "C");
            UlozPanel(flowLayoutPanelD, "D");
            UlozPanel(flowLayoutPanelSerialy, "X");

            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(cesta, json);

            MessageBox.Show("Tier list uložen do JSON!");
        }

        private void itemUlozit_Click(object sender, EventArgs e)
        {
            UlozitTierListJSON();
        }
        private void NacistTierListJSON()
        {
            string cesta = Path.Combine(Application.StartupPath, "tierlist", "tierlist.json");

            if (!File.Exists(cesta))
            {
                MessageBox.Show("Soubor neexistuje!");
                return;
            }

            string json = File.ReadAllText(cesta);

            List<SerialItem> data = JsonSerializer.Deserialize<List<SerialItem>>(json);

            ResetTierList();

            foreach (var item in data)
            {
                if (!File.Exists(item.ImagePath)) continue;

                PictureBox pb = new PictureBox();
                pb.Width = 150;
                pb.Height = 126;
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Image = Image.FromFile(item.ImagePath);
                pb.Tag = item.ImagePath;
                pb.MouseDown += Pb_MouseDown;

                FlowLayoutPanel cil;

                switch (item.Tier)
                {
                    case "S": cil = flowLayoutPanelS; break;
                    case "A": cil = flowLayoutPanelA; break;
                    case "B": cil = flowLayoutPanelB; break;
                    case "C": cil = flowLayoutPanelC; break;
                    case "D": cil = flowLayoutPanelD; break;
                    default: cil = flowLayoutPanelSerialy; break;
                }

                cil.Controls.Add(pb);
            }
        }

        private void nacistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NacistTierListJSON();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            UlozitTierListJSON();
            base.OnFormClosing(e);
        }
    }

}
