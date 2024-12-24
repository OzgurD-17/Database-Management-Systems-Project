using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VYS_Proje
{
    public partial class Form22 : Form
    {
        private string tabloIsmi;
        private string query;

        public Form22(string tabloIsmi, string query)
        {
            InitializeComponent();
            this.tabloIsmi = tabloIsmi;
            this.query = query;

        }
        private void Form22_Load(object sender, EventArgs e)
        {      
            LoadTableData();
        }
        private void LoadTableData()
        {
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))              
            {
                try
                {
                    connection.Open();

                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridViewAra.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }           
        }
    }
}

    

