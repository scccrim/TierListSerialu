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
            this.KeyPreview = true;

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
            this.KeyDown += FormTierList_KeyDown;
            string cesta = Path.Combine(Application.StartupPath, "images");

            if (!Directory.Exists(cesta))
            {
                MessageBox.Show("Složka 'images' nebyla nalezena!", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string[] soubory = Directory.GetFiles(cesta);

                foreach (string soubor in soubory)
                {
                    // validace formátu
                    if (!(soubor.EndsWith(".jpg") || soubor.EndsWith(".png") || soubor.EndsWith(".jfif")))
                        continue;

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
            catch (Exception ex)
            {
                MessageBox.Show("Chyba při načítání obrázků:\n" + ex.Message, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ofd.Filter = "Obrázky (*.jpg;*.png;*.jfif)|*.jpg;*.png;*.jfif";

            if (ofd.ShowDialog() != DialogResult.OK) return;

            // validace souboru
            if (!File.Exists(ofd.FileName))
            {
                MessageBox.Show("Vybraný soubor neexistuje!", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            string cilovaSlozka = Path.Combine(Application.StartupPath, "Images");
            string cilovaCesta = Path.Combine(cilovaSlozka, Path.GetFileName(ofd.FileName));
            // ❗ kontrola duplicity názvu souboru
            if (File.Exists(cilovaCesta))
            {
                MessageBox.Show(
                    "Snaha o přidání serialu se stejným názvem obrazku jako jiny serial",
                    "Chyba",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            try
            {
                File.Copy(ofd.FileName, cilovaCesta);

                PictureBox pb = new PictureBox();
                pb.Width = 150;
                pb.Height = 126;
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Image = Image.FromFile(cilovaCesta);
                pb.MouseDown += Pb_MouseDown;
                pb.Tag = cilovaCesta;

                flowLayoutPanelSerialy.Controls.Add(pb);
            }
            catch (IOException)
            {
                MessageBox.Show(
                    "Snaha o přidání serialu se stejným názvem obrazku jako jiny serial",
                    "Chyba",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Neočekávaná chyba:\n" + ex.Message,
                    "Chyba",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void přidatSerialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PridatSerial();
        }
        private void UlozitTierListJSON()
        {
            bool jeNecoZarazeno =
    flowLayoutPanelS.Controls.Count > 0 ||
    flowLayoutPanelA.Controls.Count > 0 ||
    flowLayoutPanelB.Controls.Count > 0 ||
    flowLayoutPanelC.Controls.Count > 0 ||
    flowLayoutPanelD.Controls.Count > 0;

            if (!jeNecoZarazeno)
            {
                MessageBox.Show("Nejdříve zařaď alespoň jeden seriál, potom můžeš uložit!",
                    "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                string slozka = Path.Combine(Application.StartupPath, "tierlist");

                if (!Directory.Exists(slozka))
                    Directory.CreateDirectory(slozka);

                string cesta = Path.Combine(slozka, "tierlist.json");

                List<SerialItem> data = new List<SerialItem>();

                void UlozPanel(FlowLayoutPanel panel, string tier)
                {
                    foreach (PictureBox pb in panel.Controls)
                    {
                        if (pb.Tag == null) continue;

                        data.Add(new SerialItem
                        {
                            Tier = tier,
                            ImagePath = pb.Tag.ToString()
                        });
                    }
                }

                UlozPanel(flowLayoutPanelS, "S");
                UlozPanel(flowLayoutPanelA, "A");
                UlozPanel(flowLayoutPanelB, "B");
                UlozPanel(flowLayoutPanelC, "C");
                UlozPanel(flowLayoutPanelD, "D");

                string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });

                File.WriteAllText(cesta, json);

                MessageBox.Show("Tier list byl úspěšně uložen.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba při ukládání:\n" + ex.Message, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void itemUlozit_Click(object sender, EventArgs e)
        {
            UlozitTierListJSON();
        }
        private void NacistTierListJSON()
        {
            try
            {
                string cesta = Path.Combine(Application.StartupPath, "tierlist", "tierlist.json");

                if (!File.Exists(cesta))
                {
                    MessageBox.Show("Soubor tierlist.json nebyl nalezen!", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string json = File.ReadAllText(cesta);

                var data = JsonSerializer.Deserialize<List<SerialItem>>(json);

                if (data == null)
                {
                    MessageBox.Show("Soubor je prázdný nebo poškozený!", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                flowLayoutPanelS.Controls.Clear();
                flowLayoutPanelA.Controls.Clear();
                flowLayoutPanelB.Controls.Clear();
                flowLayoutPanelC.Controls.Clear();
                flowLayoutPanelD.Controls.Clear();

                foreach (PictureBox pb in flowLayoutPanelSerialy.Controls.Cast<PictureBox>().ToList())
                {
                    if (pb.Tag != null && data.Any(d => d.ImagePath == pb.Tag.ToString()))
                    {
                        flowLayoutPanelSerialy.Controls.Remove(pb);
                    }
                }

                foreach (var item in data)
                {
                    if (flowLayoutPanelS.Controls.Cast<PictureBox>().Any(p => p.Tag.ToString() == item.ImagePath) ||
    flowLayoutPanelA.Controls.Cast<PictureBox>().Any(p => p.Tag.ToString() == item.ImagePath) ||
    flowLayoutPanelB.Controls.Cast<PictureBox>().Any(p => p.Tag.ToString() == item.ImagePath) ||
    flowLayoutPanelC.Controls.Cast<PictureBox>().Any(p => p.Tag.ToString() == item.ImagePath) ||
    flowLayoutPanelD.Controls.Cast<PictureBox>().Any(p => p.Tag.ToString() == item.ImagePath))
                    {
                        continue;
                    }
                    if (!File.Exists(item.ImagePath)) continue;

                    PictureBox pb = new PictureBox();
                    pb.Width = 150;
                    pb.Height = 126;
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                    pb.Image = Image.FromFile(item.ImagePath);
                    pb.Tag = item.ImagePath;
                    pb.MouseDown += Pb_MouseDown;

                    FlowLayoutPanel cil = item.Tier switch
                    {
                        "S" => flowLayoutPanelS,
                        "A" => flowLayoutPanelA,
                        "B" => flowLayoutPanelB,
                        "C" => flowLayoutPanelC,
                        "D" => flowLayoutPanelD,
                        _ => null
                    };

                    if (cil != null)
                    {
                        cil.Controls.Add(pb);
                    }
                }
            }
            catch (JsonException)
            {
                MessageBox.Show("Soubor JSON je poškozený!", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba při načítání:\n" + ex.Message, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void FormTierList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.S)
                    UlozitTierListJSON();

                if (e.KeyCode == Keys.O)
                    NacistTierListJSON();

                if (e.KeyCode == Keys.R)
                    ResetTierList();

                if (e.KeyCode == Keys.N)
                    PridatSerial();

                if (e.KeyCode == Keys.D)
                    NastavDarkTema();

                if (e.KeyCode == Keys.L)
                    NastavTema(SystemColors.Control, Color.Black);
            }
        }
    }

}
