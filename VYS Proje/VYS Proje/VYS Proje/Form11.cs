using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VYS_Proje
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string ad = textAd.Text;           
            string yer = textYer.Text;
            string odul = textOdul.Text;
            string kazanan = textKazanan.Text;
            string sponsor = textSponsor.Text;
            DateTime tarih = DateTime.Parse(maskedTextTarih.Text);

            if (string.IsNullOrWhiteSpace(ad))
            {
                MessageBox.Show("Geçerli bir ad giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!DateTime.TryParse(maskedTextTarih.Text, out tarih))
            {
                MessageBox.Show("Geçerli bir tarih giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {                                     
                    connection.Open();

                    string query = "INSERT INTO Yarisma (ad, tarih, yer, odul, kazanan, sponsor) VALUES (@ad, @tarih, @yer, @odul, @kazanan, @sponsor)";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ad", ad);
                        command.Parameters.AddWithValue("@tarih", tarih);
                        command.Parameters.AddWithValue("@yer", yer);
                        command.Parameters.AddWithValue("@odul", odul);
                        command.Parameters.AddWithValue("@kazanan", kazanan);
                        command.Parameters.AddWithValue("@sponsor", sponsor);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Yarışma başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
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

        private void btnSil_Click(object sender, EventArgs e)
        {
            int yarismaId = int.Parse(maskedTextYarismaId.Text);
          
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"
                DELETE FROM Yarisma WHERE yarisma_id = @yarisma_id;
                DELETE FROM YarismayaKatilim WHERE yarisma_id = @yarisma_id;";                

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@yarisma_id", yarismaId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Yarışma başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }                       
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

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int yarismaId = int.Parse(maskedTextYarismaId.Text);
            string ad = textAd.Text;
            string yer = textYer.Text;
            string odul = textOdul.Text;
            string kazanan = textKazanan.Text;
            string sponsor = textSponsor.Text;
            DateTime tarih = DateTime.Parse(maskedTextTarih.Text);

            if (!int.TryParse(maskedTextYarismaId.Text, out yarismaId))
            {
                MessageBox.Show("Geçerli bir Yarışma ID giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(ad))
            {
                MessageBox.Show("Geçerli bir ad giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!DateTime.TryParse(maskedTextTarih.Text, out tarih))
            {
                MessageBox.Show("Geçerli bir tarih giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"UPDATE Yarisma SET ad = @ad, tarih = @tarih, yer = @yer, odul = @odul, kazanan = @kazanan, sponsor = @sponsor WHERE yarisma_id = @yarisma_id";              

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ad", ad);
                        command.Parameters.AddWithValue("@tarih", tarih);
                        command.Parameters.AddWithValue("@yer", yer);
                        command.Parameters.AddWithValue("@odul", odul);
                        command.Parameters.AddWithValue("@kazanan", kazanan);
                        command.Parameters.AddWithValue("@sponsor", sponsor);
                        command.Parameters.AddWithValue("@yarisma_id", yarismaId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Yarışma başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }                      
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

        private void btnAra_Click(object sender, EventArgs e)
        {
            Form22 ara = new Form22(
                "Yarisma",
                @"
                 SELECT 
                    yarisma_id,
                    ad,
                    tarih,
                    yer,
                    odul,
                    kazanan,
                    sponsor
                FROM Yarisma;"
            );
            ara.ShowDialog();
        }
    }
}
