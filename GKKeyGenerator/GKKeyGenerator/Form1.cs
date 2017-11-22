using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;
using GKKeyGenerator.Interfaces.Models;
using GKKeyGenerator.Models;

namespace GKKeyGenerator
{
    public partial class Form1 : Form
    {
        //private Kontrahent _kontrahent;
        private int ProductId;
        public Form1()
        {
            InitializeComponent();
        }

        public int CompanyId { get; set; }
        SqlCommand command1 = new SqlCommand();
        DataTable data1 = new DataTable();
        SqlConnection connect = new SqlConnection("Data Source=(local);Initial Catalog=KeyGeneratorTest;Persist Security Info=True;User ID=sa;Password=sa");

        public void ProductListFill()
        {
            SqlDataAdapter PLda = new SqlDataAdapter("select productname from dbo.products",connect);
            DataTable PLdt = new DataTable();
            PLda.Fill(PLdt);
            foreach (DataRow row in PLdt.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    // Debug.WriteLine(item);
                    listBox1.Items.Add(item);
                }

            }

        }

        public void ModulesListFill()
        {
            SqlDataAdapter PLda = new SqlDataAdapter("select module_name from dbo.modules",connect);
            DataTable PLdt = new DataTable();
            PLda.Fill(PLdt);
            foreach (DataRow row in PLdt.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    // Debug.WriteLine(item);
                    listBox2.Items.Add(item);
                }

            }

        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
         
            
            DataGrid1Fill();
            ProductListFill();
            ModulesListFill();

            //label3.Text = connect.State.ToString();
            // TODO: This line of code loads data into the 'products._Products' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'keyGeneratorTestDataSet.Company' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'keyGeneratorTestDataSet1.Products' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'keyGeneratorTestDataSet.Company' table. You can move, or remove it, as needed.

            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) //zanaczenie w datagrid1
        {
            CompanyId = dataGridView1.CurrentRow.Index + 1; //datagrid numerowany od0
            //SqlCommand command2 = new SqlCommand();
            //command2.CommandText ="select  p.id_product, p.ProductName, p.ProductVersion from dbo.products p";
           // command2.Connection = connect;
           // SqlDataAdapter dataAdapter2 = new SqlDataAdapter(command2);
           // DataTable data2 = new DataTable();
           // dataGridView2.DataSource = data2;
           // dataAdapter2.Fill(data2);
           // command2.Parameters.Clear();
            if (dataGridView2.Columns.Count == 4)
            {
                  dataGridView2.Columns[1].ReadOnly = true;
                  dataGridView2.Columns[2].ReadOnly = true;
                  dataGridView2.Columns[3].ReadOnly = true;
            }
            command3.Parameters.AddWithValue("@CompanyId", CompanyId);
            DataGrid2Fill(DataGrid2Query);
            command3.Parameters.AddWithValue("@CompanyId", CompanyId);
            command3.Parameters.AddWithValue("@ProductId", ProductId); //"@ProductId", ProductId
            DataGrid3Fill(DataGrid3Query); //wypełnienie listą modułow
        }
        

        private void button1_Click(object sender, System.EventArgs e)//generuj
        {

            Company company = new Company();
            company.companyNIP = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            company.ProductList = new List<IProduct>();

            foreach (DataGridViewRow item in dataGridView2.Rows)
            {
                if (Convert.ToBoolean(item.Cells[Zaznacz.Name].Value))
                {
                 company.ProductList.Add(new Product());
                }
                
            }
        }

        public void DataGrid1Fill()//wypenilenie grida1
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();

            command1.Connection = connect;
            command1.CommandText = "select * from dbo.company";

            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(command1);
            dataAdapter1.Fill(data1);
            dataGridView1.DataSource = data1;
        }

        SqlCommand command3 = new SqlCommand();
       
        private string DataGrid2Query = ("select distinct p.id_product, p.productName, p.productVersion from products p, customermodules cm where p.id_product=cm.id_Product and cm.id_company=@CompanyId");
        public void DataGrid2Fill(string query)//wypelnienie grida2
        {
            
            this.dataGridView2.DataSource = null;
            this.dataGridView2.Rows.Clear();
            
            DataTable data3 = new DataTable();
            command3.CommandText = query;
            command3.Connection = connect;

            SqlDataAdapter dataAdapter2 = new SqlDataAdapter(command3);//new SqlDataAdapter(command3);
            
            dataAdapter2.Fill(data3);
            dataGridView2.DataSource = data3;
            command3.Parameters.Clear();

            //ProductId = dataGridView2.CurrentRow.Index + 1; //datagrid numerowany od0
          //  ProductId = dataGridView2.CurrentRow.Cells[2]
            var DataGrid2RowId = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[1].Value.ToString();
            ProductId = Int32.Parse(DataGrid2RowId);
        }


        private string DataGrid3Query = ("select m.module_name from modules m, customermodules cm where m.id_module = cm.Id_module and cm.id_company = @CompanyId");
        public void DataGrid3Fill(string query)//wypelnienie grida3
        {
            
            this.dataGridView3.DataSource = null;
            this.dataGridView3.Rows.Clear();
            
            DataTable data3 = new DataTable();
            command3.CommandText = query;
            command3.Connection = connect;

            SqlDataAdapter dataAdapter3 = new SqlDataAdapter(command3);//new SqlDataAdapter(command3);
            
            dataAdapter3.Fill(data3);
            dataGridView3.DataSource = data3;
            command3.Parameters.Clear();

           // var DataGrid3RowId = dataGridView3.Rows[dataGridView2.CurrentRow.Index].Cells[1].Value.ToString();
            //ProductId = Int32.Parse(DataGrid3RowId);
        }

        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)//zaznaczenie wiersza w datagrid2
        {
            command3.Parameters.AddWithValue("@CompanyId", CompanyId);
            command3.Parameters.AddWithValue("@ProductId", ProductId); //"@ProductId", ProductId
            DataGrid3Fill(DataGrid3Query); //wypełnienie listą modułow


            if (dataGridView3.Columns.Count == 3)
            {
                dataGridView3.Columns[1].ReadOnly = true;
                dataGridView3.Columns[2].ReadOnly = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)//edytuj
        {
            //company.companyNIP = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            Kontrahent kontrahent = new Kontrahent();
            kontrahent.EdytujDane(FillCompanyO());
            kontrahent.Show();
        }

        private void button4_Click(object sender, EventArgs e)//dodaj
        {
            new Kontrahent().Show();
        }

        private void button13_Click(object sender, EventArgs e)//refresh
        {
            DataGrid1Fill();
        }

        public Company FillCompanyO()
        {
            Company company = new Company();
            int SCompanyId = dataGridView1.CurrentRow.Index + 1;
            company.companyId = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            company.companyName = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            company.companyNIP = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            company.companyAdress = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            company.companyCity = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            company.companyPCode = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            return company;
        }

        private void button14_Click(object sender, EventArgs e)//pokaż
        {
            Kontrahent P_kontrahent = new Kontrahent();//formatka
            P_kontrahent.PokazDane(FillCompanyO());   
            P_kontrahent.Show();
        }

        private void button8_Click(object sender, EventArgs e)//-> products remove
        {
            //ProductId
            
        }

        private void button11_Click(object sender, EventArgs e)//-> modules remove UPDATE NULL
        {
            command3.Parameters.AddWithValue("@CompanyId", CompanyId); 
            DataGrid2Fill("update CustomerModules set id_module=null where id_company = @CompanyId"); //zabezpieczyć na productID
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)//->
        {
            command3.Parameters.AddWithValue("@CompanyId", CompanyId); 
            DataGrid3Fill(DataGrid3Query); 
        }
    }
}
