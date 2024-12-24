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
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            int kisiId = int.Parse(maskedTextKisiId.Text);
            int sinifId = int.Parse(maskedTextSinifId.Text);
            int dersId = int.Parse(maskedTextDersId.Text);
            DateTime tarih = DateTime.Parse(maskedTextTarih.Text);
            bool katilim;

            // Veri giriş kontrolleri          
            if (radioKatildi.Checked)
            {
                katilim = true;
            }
            else if (radioKatilmadi.Checked)
            {
                katilim = false;
            }
            else
            {
                MessageBox.Show("Lütfen 'Katıldı' veya 'Katılmadı' seçeneğini işaretleyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!DateTime.TryParse(maskedTextTarih.Text, out tarih))
            {
                MessageBox.Show("Geçerli bir tarih giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // PostgreSQL bağlantısı
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {

                try
                {
                    connection.Open();

                    string query = "INSERT INTO Yoklama (kisi_id, sinif_id, ders_id, tarih, katilim) VALUES (@kisi_id, @sinif_id, @ders_id, @tarih, @katilim)";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@kisi_id", kisiId);
                        command.Parameters.AddWithValue("@sinif_id", sinifId);
                        command.Parameters.AddWithValue("@ders_id", dersId);
                        command.Parameters.AddWithValue("@tarih", tarih);
                        command.Parameters.AddWithValue("@katilim", katilim);

                        // Sorguyu çalıştır
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Yoklama başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int yoklamaId = int.Parse(maskedTextYoklamaId.Text);

            // PostgreSQL bağlantısı
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Silme işlemi için sorgu
                    string query = @"
                DELETE FROM Yoklama WHERE yoklama_id = @yoklama_id;";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@yoklama_id", yoklamaId);

                        // Sorguyu çalıştır
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Yoklama ve ilişkili veriler başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int yoklamaId = int.Parse(maskedTextYoklamaId.Text);
            int kisiId = int.Parse(maskedTextKisiId.Text);
            int sinifId = int.Parse(maskedTextSinifId.Text);
            int dersId = int.Parse(maskedTextDersId.Text);
            DateTime tarih = DateTime.Parse(maskedTextTarih.Text);
            bool katilim;

            if (!DateTime.TryParse(maskedTextTarih.Text, out tarih))
            {
                MessageBox.Show("Geçerli bir tarih giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (radioKatildi.Checked)
            {
                katilim = true;
            }
            else if (radioKatilmadi.Checked)
            {
                katilim = false;
            }
            else
            {
                MessageBox.Show("Lütfen 'Katıldı' veya 'Katılmadı' seçeneğini işaretleyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // PostgreSQL bağlantısı
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "UPDATE Yoklama SET kisi_id = @kisi_id, sinif_id = @sinif_id, ders_id = @ders_id, tarih = @tarih, katilim = @katilim WHERE yoklama_id = @yoklama_id";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@kisi_id", kisiId);
                        command.Parameters.AddWithValue("@sinif_id", sinifId);
                        command.Parameters.AddWithValue("@ders_id", dersId);
                        command.Parameters.AddWithValue("@tarih", tarih);
                        command.Parameters.AddWithValue("@katilim", katilim);
                        command.Parameters.AddWithValue("@yoklama_id", yoklamaId);

                        // Sorguyu çalıştır
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Yoklama başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                "Yoklama",
                @"
                 SELECT 
                    yoklama_id,
                    ders_id,
                    kisi_id,
                    sinif_id,
                    katilim,
                    tarih
                FROM Yoklama;"
            );
            ara.ShowDialog();
        }
    }
}
