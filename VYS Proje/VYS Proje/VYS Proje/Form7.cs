using Npgsql;
using System;
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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string dersAdi = textDersAdi.Text;
            int baslangicSaati = int.Parse(maskedTextBaslangicSaati.Text);
            int bitisSaati = int.Parse(maskedTextBitisSaati.Text);

            // NOT NULL kontrolleri
            if (string.IsNullOrWhiteSpace(dersAdi))
            {
                MessageBox.Show("Geçerli bir ders adı giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(maskedTextBaslangicSaati.Text, out baslangicSaati))
            {
                MessageBox.Show("Geçerli bir başlangıç saati giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(maskedTextBitisSaati.Text, out bitisSaati))
            {
                MessageBox.Show("Geçerli bir bitiş saati giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Veritabanı bağlantı dizesi
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
               
            {
                try
                {
                    connection.Open();

                    // SQL sorgusu ve parametrelerle veri ekleme
                    string query = "INSERT INTO Ders (ders_adi, baslangic_saati, bitis_saati) VALUES (@dersAdi, @baslangicSaati, @bitisSaati)";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@dersAdi", dersAdi);
                        command.Parameters.AddWithValue("@baslangicSaati", baslangicSaati);
                        command.Parameters.AddWithValue("@bitisSaati", bitisSaati);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Ders başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int dersId = int.Parse(maskedTextDersId.Text);

            if (!int.TryParse(maskedTextDersId.Text, out dersId))
            {
                MessageBox.Show("Ders id boş bırakılamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Veritabanı bağlantı dizesi
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // İlişkili kayıtları ve ders kaydını sil
                    string query = @"
                DELETE FROM SinifDers WHERE ders_id = @dersId;
                DELETE FROM Yoklama WHERE ders_id = @dersId;
                DELETE FROM Ders WHERE ders_id = @dersId;";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@dersId", dersId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Ders ve ilişkili kayıtlar başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int dersId = int.Parse(maskedTextDersId.Text);
            string dersAdi = textDersAdi.Text;
            int baslangicSaati = int.Parse(maskedTextBaslangicSaati.Text);
            int bitisSaati = int.Parse(maskedTextBitisSaati.Text);

            // NOT NULL kontrolleri
            if (!int.TryParse(maskedTextDersId.Text, out dersId))
            {
                MessageBox.Show("Geçerli bir Ders ID giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(dersAdi))
            {
                MessageBox.Show("Geçerli bir ders adı giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(maskedTextBaslangicSaati.Text, out baslangicSaati))
            {
                MessageBox.Show("Geçerli bir başlangıç saati giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(maskedTextBitisSaati.Text, out bitisSaati))
            {
                MessageBox.Show("Geçerli bir bitiş saati giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Veritabanı bağlantı dizesi
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // SQL sorgusu ve parametrelerle veri güncelleme
                    string query = "UPDATE Ders SET ders_adi = @dersAdi, baslangic_saati = @baslangicSaati, bitis_saati = @bitisSaati WHERE ders_id = @dersId;";
              
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@dersAdi", dersAdi);
                        command.Parameters.AddWithValue("@baslangicSaati", baslangicSaati);
                        command.Parameters.AddWithValue("@bitisSaati", bitisSaati);
                        command.Parameters.AddWithValue("@dersId", dersId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Ders başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                "Ders",
                @"
                 SELECT 
                    ders_id,
                    ders_adi,
                    baslangic_saati,
                    bitis_saati
                FROM Ders;"
            );
            ara.ShowDialog();
        }
    }
}
