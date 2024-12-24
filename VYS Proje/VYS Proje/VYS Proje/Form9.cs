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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            int kisiId = int.Parse(maskedTextKisiId.Text);
            int sinifId = int.Parse(maskedTextSinifId.Text);
            DateTime baslangicTarihi = DateTime.Parse(maskedTextBaslangicTarihi.Text);
            DateTime bitisTarihi = DateTime.Parse(maskedTextBitisTarihi.Text);

            if (!DateTime.TryParse(maskedTextBaslangicTarihi.Text, out baslangicTarihi))
            {
                MessageBox.Show("Geçerli bir başlangıç tarihi giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!DateTime.TryParse(maskedTextBitisTarihi.Text, out bitisTarihi))
            {
                MessageBox.Show("Geçerli bir bitiş tarihi giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Bitiş tarihinin başlangıç tarihinden önce olup olmadığını kontrol et
            if (bitisTarihi <= baslangicTarihi)
            {
                MessageBox.Show("Bitiş tarihi, başlangıç tarihinden sonra olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // PostgreSQL bağlantı dizesi (kendi bilgilerinize göre düzenleyin)
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // SQL sorgusu
                    string query = "INSERT INTO SinifRezervasyon (kisi_id, sinif_id, baslangic_tarihi, bitis_tarihi) VALUES (@kisi_id, @sinif_id, @baslangic_tarihi, @bitis_tarihi);";

                    // Komut oluştur
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        // Parametreleri ekle
                        command.Parameters.AddWithValue("@kisi_id", kisiId);
                        command.Parameters.AddWithValue("@sinif_id", sinifId);
                        command.Parameters.AddWithValue("@baslangic_tarihi", baslangicTarihi);
                        command.Parameters.AddWithValue("@bitis_tarihi", bitisTarihi);

                        // Komutu çalıştır
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Rezervasyon başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int rezervasyonId = int.Parse(maskedTextRezervasyonId.Text);

            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"          
                DELETE FROM SinifRezervasyon WHERE rezervasyon_id = @rezervasyon_id;";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@rezervasyon_id", rezervasyonId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Rezervasyon ve ilişkili veriler başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int rezervasyonId = int.Parse(maskedTextRezervasyonId.Text);
            int sinifId = int.Parse(maskedTextSinifId.Text);
            int kisiId = int.Parse(this.maskedTextKisiId.Text);
            DateTime baslangicTarihi = DateTime.Parse(maskedTextBaslangicTarihi.Text);
            DateTime bitisTarihi = DateTime.Parse(maskedTextBitisTarihi.Text);

            // NOT NULL kontrolü
            if (!int.TryParse(maskedTextRezervasyonId.Text, out rezervasyonId))
            {
                MessageBox.Show("Geçerli bir Rezervasyon ID giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!DateTime.TryParse(maskedTextBaslangicTarihi.Text, out baslangicTarihi))
            {
                MessageBox.Show("Geçerli bir başlangıç tarihi giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!DateTime.TryParse(maskedTextBitisTarihi.Text, out bitisTarihi))
            {
                MessageBox.Show("Geçerli bir bitiş tarihi giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Bitiş tarihinin başlangıç tarihinden önce olup olmadığını kontrol et
            if (bitisTarihi <= baslangicTarihi)
            {
                MessageBox.Show("Bitiş tarihi, başlangıç tarihinden sonra olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "UPDATE SinifRezervasyon SET sinif_id = @sinif_id, kisi_id = @kisi_id, baslangic_tarihi = @baslangic_tarihi, bitis_tarihi = @bitis_tarihi WHERE rezervasyon_id = @rezervasyon_id;";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@sinif_id", sinifId);
                        command.Parameters.AddWithValue("@kisi_id", kisiId);
                        command.Parameters.AddWithValue("@baslangic_tarihi", baslangicTarihi);
                        command.Parameters.AddWithValue("@bitis_tarihi", bitisTarihi);
                        command.Parameters.AddWithValue("@rezervasyon_id", rezervasyonId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Rezervasyon başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                "SinifRezervasyon",
                @"
                 SELECT 
                    rezervasyon_id,
                    kisi_id,
                    sinif_id,
                    baslangic_tarihi,
                    bitis_tarihi
                FROM SinifRezervasyon;"
            );
            ara.ShowDialog();
        }
    }
}

