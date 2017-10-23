using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using GKKeyGenerator.Interfaces.Models;
using GKKeyGenerator.Models;

namespace GKKeyGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string CompanyId { get; set; }
        SqlCommand command1 = new SqlCommand();

        DataTable data1 = new DataTable();

        SqlConnection connect =
                new SqlConnection(
                    "Data Source=(local);Initial Catalog=KeyGeneratorTest;Persist Security Info=True;User ID=sa;Password=sa");

        private void Form1_Load(object sender, System.EventArgs e)
        {
            
            command1.Connection = connect;
            command1.CommandText = "select * from dbo.company";

            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(command1);
            dataAdapter1.Fill(data1);
            dataGridView1.DataSource = data1;
            //label3.Text = connect.State.ToString();
            // TODO: This line of code loads data into the 'products._Products' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'keyGeneratorTestDataSet.Company' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'keyGeneratorTestDataSet1.Products' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'keyGeneratorTestDataSet.Company' table. You can move, or remove it, as needed.

            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //dataGridView2.Rows.Clear();

            var CompanyId = dataGridView1.CurrentRow.Index + 1; //datagrid numerowany od0
            //label2.Text = CompanyId.ToString();

            SqlCommand command2 = new SqlCommand();
            command2.CommandText =
                "select  p.id_product, p.ProductName, p.ProductVersion from dbo.products p";
            
            // dataGridView2.Refresh();
            command2.Connection = connect;
            SqlDataAdapter dataAdapter2 = new SqlDataAdapter(command2);
            DataTable data2 = new DataTable();
            dataGridView2.DataSource = data2;
            dataAdapter2.Fill(data2);
            command2.Parameters.Clear();
            if (dataGridView2.Columns.Count==4)
            {
                dataGridView2.Columns[1].ReadOnly = true;
                dataGridView2.Columns[2].ReadOnly = true;
                dataGridView2.Columns[3].ReadOnly = true;
            }
            



            // dataGridView2.Refresh();

        }
        

        private void companyBindingSource_CurrentChanged(object sender, System.EventArgs e)
        {
   
        }

        private void button1_Click(object sender, System.EventArgs e)
        {

            Company company = new Company();
            company.companyNIP = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            company.ProductList = new List<IProduct>();

            foreach (DataGridViewRow item in dataGridView2.Rows)
            {
                if (Convert.ToBoolean(item.Cells[Zaznacz.Name].Value))
                {
                    //company.ProductList.Add(item.Cells[2].Value.ToString());
                    company.ProductList.Add(new Product());
                    {
                        
                    }
                }
                
            }
        }

        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView3.DataSource = null;
            this.dataGridView3.Rows.Clear();
            //this.dataGridView3.DataSource = this.getnew
            var ProductId = dataGridView2.CurrentRow.Index + 1; //datagrid numerowany od0
            SqlCommand command3 = new SqlCommand();
            DataTable data3 = new DataTable();
            command3.Connection = connect;
            
            SqlDataAdapter dataAdapter3 = new SqlDataAdapter(command3);
            
            
            

            command3.Parameters.AddWithValue("@ProductId", ProductId);
            command3.CommandText =
                "select distinct m.id_module, m.Module_name from dbo.modules m, dbo.customerModules cm, dbo.Products p where m.id_module = cm.Id_module and m.id_product = @ProductId";
            
            
            dataAdapter3.Fill(data3);
            dataGridView3.DataSource = data3;
            command3.Parameters.Clear();
            if (dataGridView3.Columns.Count == 3)
            {
                dataGridView3.Columns[1].ReadOnly = true;
                dataGridView3.Columns[2].ReadOnly = true;
            }
        }
        
    }
}
