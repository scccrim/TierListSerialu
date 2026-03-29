namespace TierListSerialu
{
    partial class FormTierList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            itemUlozit = new ToolStripMenuItem();
            toolStripMenuItemAplikace = new ToolStripMenuItem();
            toolStripMenuItemNapoveda = new ToolStripMenuItem();
            toolStripMenuItemRezim = new ToolStripMenuItem();
            toolStripMenuItemTmavy = new ToolStripMenuItem();
            toolStripMenuItemSvetly = new ToolStripMenuItem();
            resetovatTierlistToolStripMenuItem = new ToolStripMenuItem();
            přidatSerialToolStripMenuItem = new ToolStripMenuItem();
            flowLayoutPanelS = new FlowLayoutPanel();
            labelS = new Label();
            labelA = new Label();
            flowLayoutPanelA = new FlowLayoutPanel();
            labelB = new Label();
            flowLayoutPanelB = new FlowLayoutPanel();
            labelC = new Label();
            flowLayoutPanelC = new FlowLayoutPanel();
            labelD = new Label();
            flowLayoutPanelD = new FlowLayoutPanel();
            flowLayoutPanelSerialy = new FlowLayoutPanel();
            pb = new PictureBox();
            nacistToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            flowLayoutPanelSerialy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { itemUlozit, toolStripMenuItemAplikace, toolStripMenuItemNapoveda, toolStripMenuItemRezim, resetovatTierlistToolStripMenuItem, přidatSerialToolStripMenuItem, nacistToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1904, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // itemUlozit
            // 
            itemUlozit.Name = "itemUlozit";
            itemUlozit.Size = new Size(49, 20);
            itemUlozit.Text = "Uložit";
            itemUlozit.Click += itemUlozit_Click;
            // 
            // toolStripMenuItemAplikace
            // 
            toolStripMenuItemAplikace.Name = "toolStripMenuItemAplikace";
            toolStripMenuItemAplikace.Size = new Size(71, 20);
            toolStripMenuItemAplikace.Text = "O aplikaci";
            toolStripMenuItemAplikace.Click += toolStripMenuItemAplikace_Click;
            // 
            // toolStripMenuItemNapoveda
            // 
            toolStripMenuItemNapoveda.Name = "toolStripMenuItemNapoveda";
            toolStripMenuItemNapoveda.Size = new Size(73, 20);
            toolStripMenuItemNapoveda.Text = "Nápověda";
            toolStripMenuItemNapoveda.Click += toolStripMenuItemNapoveda_Click;
            // 
            // toolStripMenuItemRezim
            // 
            toolStripMenuItemRezim.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItemTmavy, toolStripMenuItemSvetly });
            toolStripMenuItemRezim.Name = "toolStripMenuItemRezim";
            toolStripMenuItemRezim.Size = new Size(51, 20);
            toolStripMenuItemRezim.Text = "Režim";
            // 
            // toolStripMenuItemTmavy
            // 
            toolStripMenuItemTmavy.Name = "toolStripMenuItemTmavy";
            toolStripMenuItemTmavy.Size = new Size(108, 22);
            toolStripMenuItemTmavy.Text = "Tmavý";
            toolStripMenuItemTmavy.Click += toolStripMenuItemTmavy_Click;
            // 
            // toolStripMenuItemSvetly
            // 
            toolStripMenuItemSvetly.Name = "toolStripMenuItemSvetly";
            toolStripMenuItemSvetly.Size = new Size(108, 22);
            toolStripMenuItemSvetly.Text = "Světlý";
            toolStripMenuItemSvetly.Click += toolStripMenuItemSvetly_Click;
            // 
            // resetovatTierlistToolStripMenuItem
            // 
            resetovatTierlistToolStripMenuItem.Name = "resetovatTierlistToolStripMenuItem";
            resetovatTierlistToolStripMenuItem.Size = new Size(107, 20);
            resetovatTierlistToolStripMenuItem.Text = "Resetovat Tierlist";
            resetovatTierlistToolStripMenuItem.Click += resetovatTierlistToolStripMenuItem_Click;
            // 
            // přidatSerialToolStripMenuItem
            // 
            přidatSerialToolStripMenuItem.Name = "přidatSerialToolStripMenuItem";
            přidatSerialToolStripMenuItem.Size = new Size(80, 20);
            přidatSerialToolStripMenuItem.Text = "Přidat serial";
            přidatSerialToolStripMenuItem.Click += přidatSerialToolStripMenuItem_Click;
            // 
            // flowLayoutPanelS
            // 
            flowLayoutPanelS.Location = new Point(104, 116);
            flowLayoutPanelS.Name = "flowLayoutPanelS";
            flowLayoutPanelS.Size = new Size(1023, 126);
            flowLayoutPanelS.TabIndex = 1;
            // 
            // labelS
            // 
            labelS.AutoSize = true;
            labelS.Font = new Font("Segoe UI", 56F, FontStyle.Bold);
            labelS.ForeColor = Color.Lime;
            labelS.Location = new Point(14, 129);
            labelS.Name = "labelS";
            labelS.Size = new Size(84, 100);
            labelS.TabIndex = 2;
            labelS.Text = "S";
            labelS.Click += label1_Click;
            // 
            // labelA
            // 
            labelA.Font = new Font("Segoe UI", 56F, FontStyle.Bold);
            labelA.ForeColor = Color.Cyan;
            labelA.Location = new Point(12, 258);
            labelA.Name = "labelA";
            labelA.Size = new Size(84, 100);
            labelA.TabIndex = 3;
            labelA.Text = "A";
            // 
            // flowLayoutPanelA
            // 
            flowLayoutPanelA.Location = new Point(104, 248);
            flowLayoutPanelA.Name = "flowLayoutPanelA";
            flowLayoutPanelA.Size = new Size(1023, 126);
            flowLayoutPanelA.TabIndex = 2;
            // 
            // labelB
            // 
            labelB.Font = new Font("Segoe UI", 56F, FontStyle.Bold);
            labelB.ForeColor = Color.Yellow;
            labelB.Location = new Point(14, 390);
            labelB.Name = "labelB";
            labelB.Size = new Size(84, 100);
            labelB.TabIndex = 4;
            labelB.Text = "B";
            // 
            // flowLayoutPanelB
            // 
            flowLayoutPanelB.Location = new Point(104, 380);
            flowLayoutPanelB.Name = "flowLayoutPanelB";
            flowLayoutPanelB.Size = new Size(1023, 126);
            flowLayoutPanelB.TabIndex = 3;
            // 
            // labelC
            // 
            labelC.Font = new Font("Segoe UI", 56F, FontStyle.Bold);
            labelC.ForeColor = Color.DarkGoldenrod;
            labelC.Location = new Point(14, 528);
            labelC.Name = "labelC";
            labelC.Size = new Size(84, 100);
            labelC.TabIndex = 5;
            labelC.Text = "C";
            // 
            // flowLayoutPanelC
            // 
            flowLayoutPanelC.Location = new Point(104, 512);
            flowLayoutPanelC.Name = "flowLayoutPanelC";
            flowLayoutPanelC.Size = new Size(1023, 126);
            flowLayoutPanelC.TabIndex = 4;
            // 
            // labelD
            // 
            labelD.Font = new Font("Segoe UI", 56F, FontStyle.Bold);
            labelD.ForeColor = Color.Red;
            labelD.Location = new Point(14, 655);
            labelD.Name = "labelD";
            labelD.Size = new Size(84, 100);
            labelD.TabIndex = 6;
            labelD.Text = "D";
            // 
            // flowLayoutPanelD
            // 
            flowLayoutPanelD.Location = new Point(104, 645);
            flowLayoutPanelD.Name = "flowLayoutPanelD";
            flowLayoutPanelD.Size = new Size(1023, 126);
            flowLayoutPanelD.TabIndex = 5;
            // 
            // flowLayoutPanelSerialy
            // 
            flowLayoutPanelSerialy.Controls.Add(pb);
            flowLayoutPanelSerialy.Location = new Point(12, 777);
            flowLayoutPanelSerialy.Name = "flowLayoutPanelSerialy";
            flowLayoutPanelSerialy.Size = new Size(1489, 252);
            flowLayoutPanelSerialy.TabIndex = 6;
            // 
            // pb
            // 
            pb.Location = new Point(3, 3);
            pb.Name = "pb";
            pb.Size = new Size(100, 50);
            pb.TabIndex = 0;
            pb.TabStop = false;
            // 
            // nacistToolStripMenuItem
            // 
            nacistToolStripMenuItem.Name = "nacistToolStripMenuItem";
            nacistToolStripMenuItem.Size = new Size(52, 20);
            nacistToolStripMenuItem.Text = "Nacist";
            nacistToolStripMenuItem.Click += nacistToolStripMenuItem_Click;
            // 
            // FormTierList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1904, 1041);
            Controls.Add(flowLayoutPanelSerialy);
            Controls.Add(flowLayoutPanelD);
            Controls.Add(labelD);
            Controls.Add(flowLayoutPanelC);
            Controls.Add(labelC);
            Controls.Add(flowLayoutPanelB);
            Controls.Add(labelB);
            Controls.Add(flowLayoutPanelA);
            Controls.Add(labelA);
            Controls.Add(labelS);
            Controls.Add(flowLayoutPanelS);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FormTierList";
            Text = "FormTierList";
            Load += formTierList_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            flowLayoutPanelSerialy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pb).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem itemUlozit;
        private ToolStripMenuItem toolStripMenuItemAplikace;
        private ToolStripMenuItem toolStripMenuItemNapoveda;
        private ToolStripMenuItem toolStripMenuItemRezim;
        private ToolStripMenuItem toolStripMenuItemTmavy;
        private ToolStripMenuItem toolStripMenuItemSvetly;
        private FlowLayoutPanel flowLayoutPanelS;
        private Label labelS;
        private Label labelA;
        private FlowLayoutPanel flowLayoutPanelA;
        private Label labelB;
        private FlowLayoutPanel flowLayoutPanelB;
        private Label labelC;
        private FlowLayoutPanel flowLayoutPanelC;
        private Label labelD;
        private FlowLayoutPanel flowLayoutPanelD;
        private FlowLayoutPanel flowLayoutPanelSerialy;
        private PictureBox pb;
        private ToolStripMenuItem resetovatTierlistToolStripMenuItem;
        private ToolStripMenuItem přidatSerialToolStripMenuItem;
        private ToolStripMenuItem nacistToolStripMenuItem;
    }
}