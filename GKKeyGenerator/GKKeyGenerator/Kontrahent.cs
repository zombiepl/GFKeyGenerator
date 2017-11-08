using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GKKeyGenerator.Interfaces.Models;
using GKKeyGenerator.Models;
using System.Data.SqlClient;

namespace GKKeyGenerator
{
    
    public partial class Kontrahent : Form
    {
        public Kontrahent()
        

        {
            InitializeComponent();
        }
        public string CompanyId { get; set; }

        private void button3_Click(object sender, EventArgs e) //anuluj
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e) //ok
        {

            Close();
        }

        private void button1_Click(object sender, EventArgs e)// zapisz
            //nazwa,nip,adres,kod,miasto
        {

            Company company = new Company();
            company.companyName = this.textBox1.Text;
            company.companyNIP = this.textBox2.Text;
            company.companyAdress = this.textBox3.Text;
            company.companyPCode = this.textBox4.Text;
            company.companyCity = this.textBox5.Text;
            

            String _connectionString="Data Source=(local);Initial Catalog=KeyGeneratorTest;Persist Security Info=True;User ID=sa;Password=sa";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                String query = "insert into dbo.Company (id_company, CompanyName,NIP,Adress,City,PostCode) values (587, @companyName, @companyNIP, @companyAdress, @CompanyCity, @companyPCode)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@companyName", company.companyName);
                    command.Parameters.AddWithValue("@companyNIP", company.companyNIP);
                    command.Parameters.AddWithValue("@companyAdress", company.companyAdress);
                    command.Parameters.AddWithValue("@companyPCode", company.companyPCode);
                    command.Parameters.AddWithValue("@CompanyCity", company.companyCity);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    // Check Error
                    if (result < 0)
                        MessageBox.Show("Blad ladowania do bazy!");
                }
            }
         
             //   using (SqlCommand commSelId = SqlCommand((SELECT MAX(id_company)FROM dbo.Company),connection);
             //   label2.Text =commSel
            //listview1 odswierz-refresh










        }

    }
}
