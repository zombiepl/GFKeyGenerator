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
    
    public partial class Kontrahent : Form //zmiana z Form
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
            SaveDataToDatabase();
            Close();
        }

       // private Form1 _form1; //kompozycja... or not... ?

        private void SaveDataToDatabase()
        {
             //dopisac obsługe zdublowanych danych formatka->obiekt->baza (porównanie obiektów)
                Company company = new Company();
            company.companyName = this.textBox1.Text;
            company.companyNIP = this.textBox2.Text;
            company.companyAdress = this.textBox3.Text;
            company.companyPCode = this.textBox4.Text;
            company.companyCity = this.textBox5.Text;


            String _connectionString = "Data Source=(local);Initial Catalog=KeyGeneratorTest;Persist Security Info=True;User ID=sa;Password=sa";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                String query = "insert into dbo.Company (id_company, CompanyName,NIP,Adress,City,PostCode) values ((select max (id_company) from dbo.Company)+1, @companyName, @companyNIP, @companyAdress, @CompanyCity, @companyPCode)";

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
                    {
                        MessageBox.Show("Blad ladowania do bazy!");
                    }
                    // _form1.RefreshDataGridV1(); //publiczna z klasy form1 - 
                    //RefreshDataGridV1(); //dziedziczona po Form1

                }
            }
        
             //   using (SqlCommand commSelId = SqlCommand((SELECT MAX(id_company)FROM dbo.Company),connection);
             //   label2.Text =commSel
            //listview1 odswierz-refresh

        }

        private void PokazDane()
        {
            textBox1.Enabled = false;
        }

        private void button1_Click_1(object sender, EventArgs e)//zapisz
        { //dopisac obsługe zdublowanych danych formatka->obiekt->baza (porównanie obiektów)
            SaveDataToDatabase();
        }
    }
}
