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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            int kisiId = int.Parse(maskedKisiId.Text);
            int sinifId = int.Parse(maskedSinifId.Text);
            int egitmenId = int.Parse(maskedEgitmenId.Text);
            int puan = int.Parse(maskedPuan.Text);
            string yorum = richTextYorum.Text;
            DateTime tarih= DateTime.Parse(maskedTarih.Text);

            // Puan kontrolü
            if (!int.TryParse(maskedPuan.Text, out puan) || !(puan >= 0 && puan <= 10))
            {
                MessageBox.Show("Puan 0 ile 10 arasında bir değer olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tarih kontrolü
            if (!DateTime.TryParse(maskedTarih.Text, out tarih))
            {
                MessageBox.Show("Geçerli bir tarih giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // PostgreSQL bağlantı dizesi
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            // PostgreSQL bağlantısı
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))               
            {
                try
                {
                    connection.Open();

                    // SQL sorgusu
                    string query = "INSERT INTO Degerlendirme (kisi_id, sinif_id, egitmen_id, puan, yorum, tarih) " +
                           "VALUES (@kisi_id, @sinif_id, @egitmen_id, @puan, @yorum, @tarih)";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        // Parametreleri ekle
                        command.Parameters.AddWithValue("@kisi_id", kisiId);
                        command.Parameters.AddWithValue("@sinif_id", sinifId);
                        command.Parameters.AddWithValue("@egitmen_id", egitmenId);
                        command.Parameters.AddWithValue("@puan", puan);
                        command.Parameters.AddWithValue("@yorum", yorum);
                        command.Parameters.AddWithValue("@tarih", tarih);

                        // Sorguyu çalıştır
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Değerlendirme başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }                       
                    }
                }
                catch (Exception ex)
                {
                    // Hata mesajı göster
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
            int degerlendirmeId = int.Parse(maskedDegerlendirmeId.Text);            

            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Silme işlemi için SQL sorguları
                    string query = @"               
                DELETE FROM Degerlendirme WHERE degerlendirme_id = @degerlendirme_id;";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@degerlendirme_id", degerlendirmeId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Değerlendirme başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int degerlendirmeId = int.Parse(maskedDegerlendirmeId.Text);
            int puan = int.Parse(maskedPuan.Text);
            int kisiId = int.Parse(maskedKisiId.Text);
            int sinifId = int.Parse(maskedSinifId.Text);
            int egitmenId = int.Parse (maskedEgitmenId.Text);
            string yorum = richTextYorum.Text;
            DateTime tarih = DateTime.Parse(maskedTarih.Text);

            if (!int.TryParse(maskedDegerlendirmeId.Text, out degerlendirmeId))
            {
                MessageBox.Show("Geçerli bir Değerlendirme ID giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(maskedPuan.Text, out puan) || !(puan >= 0 && puan <= 10))
            {
                MessageBox.Show("Puan 0 ile 10 arasında bir değer olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!DateTime.TryParse(maskedTarih.Text, out tarih))
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

                    // Güncelleme işlemi için SQL sorgusu
                    string query = "UPDATE Degerlendirme SET puan = @puan, yorum = @yorum, kisi_id = @kisi_id, sinif_id = @sinif_id, egitmen_id = @egitmen_id, tarih = @tarih WHERE degerlendirme_id = @degerlendirme_id";
               
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@degerlendirme_id", degerlendirmeId);
                        command.Parameters.AddWithValue("@puan", puan);
                        command.Parameters.AddWithValue("@yorum", yorum);
                        command.Parameters.AddWithValue("@kisi_id", kisiId);
                        command.Parameters.AddWithValue("@sinif_id", sinifId);
                        command.Parameters.AddWithValue("@egitmen_id", egitmenId);
                        command.Parameters.AddWithValue("@tarih", tarih);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Değerlendirme başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                "Degerlendirme",
                @"
                 SELECT 
                    degerlendirme_id,
                    kisi_id,
                    sinif_id,
                    egitmen_id,
                    puan,
                    yorum,
                    tarih
                FROM Degerlendirme;"
            );
            ara.ShowDialog();
        }
    }
}
