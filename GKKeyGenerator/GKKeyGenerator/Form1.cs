using System.Windows.Forms;

namespace GKKeyGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string CompanyId { get; set; }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            // TODO: This line of code loads data into the 'products._Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.products._Products);
            // TODO: This line of code loads data into the 'keyGeneratorTestDataSet.Company' table. You can move, or remove it, as needed.
            this.companyTableAdapter.Fill(this.keyGeneratorTestDataSet.Company);
            // TODO: This line of code loads data into the 'keyGeneratorTestDataSet1.Products' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'keyGeneratorTestDataSet.Company' table. You can move, or remove it, as needed.

            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = new DataGridView();
            //CompanyId = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["id_company"].Value.ToString();
           var CompanyId = dataGridView1.CurrentRow.Index+1;//datagrid numerowany od0
            label2.Text = CompanyId.ToString();
        }



        private void companyBindingSource_CurrentChanged(object sender, System.EventArgs e)
        {

        }
    }
}
