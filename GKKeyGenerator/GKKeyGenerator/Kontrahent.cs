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
using Validators;


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
            Close();//przeniesc zapis do bazy do innej motody i zrobić zabezpieczenie zamkniecia jak zły nip
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
            if (Validator.IsValid(company.companyNIP))
            {
                String _connectionString = "Data Source=(local);Initial Catalog=KeyGeneratorTest;Persist Security Info=True;User ID=sa;Password=sa";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    String query =
                        "insert into dbo.Company (id_company, CompanyName,NIP,Adress,City,PostCode) values ((select max (id_company) from dbo.Company)+1, @companyName, @companyNIP, @companyAdress, @CompanyCity, @companyPCode)";

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
                            MessageBox.Show("Blad ladowania do bazy!","Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }

                    }
                }
            }


            else
            {
                MessageBox.Show("Błędny NIP","Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
           


        }
        
        
    

        public void PokazDane(Company company)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            label2.Text = company.companyId;
            textBox1.Text = company.companyName;
            textBox2.Text = company.companyNIP;
            textBox3.Text = company.companyAdress;
            textBox4.Text = company.companyPCode;
            textBox5.Text = company.companyCity;
        }

        public void EdytujDane(Company company)
        {
            label2.Text = company.companyId;
            textBox1.Text = company.companyName;
            textBox2.Text = company.companyNIP;
            textBox3.Text = company.companyAdress;
            textBox4.Text = company.companyPCode;
            textBox5.Text = company.companyCity;
        }

        private void button1_Click_1(object sender, EventArgs e)//zapisz
        { //dopisac obsługe zdublowanych danych formatka->obiekt->baza (porównanie obiektów)
            SaveDataToDatabase();
        }
    }
}
