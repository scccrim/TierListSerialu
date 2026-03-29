namespace TierListSerialu
{
    public partial class FormStartujiciOkno : Form
    {
        public FormStartujiciOkno()
        {
            InitializeComponent();
        }

        private void buttonTierList_Click(object sender, EventArgs e)
        {
            FormTierList f2 = new FormTierList();
            f2.Show();
            this.Hide();
        }
    }
}
