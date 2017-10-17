using System.Windows.Forms;

namespace GKKeyGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            // TODO: This line of code loads data into the 'eRPXL_LASKOMEXDataSet.KntKarty' table. You can move, or remove it, as needed.
            this.kntKartyTableAdapter.Fill(this.eRPXL_LASKOMEXDataSet.KntKarty);

        }
    }
}
