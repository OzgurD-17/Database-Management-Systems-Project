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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            int kisiId = int.Parse(maskedTextKisiId.Text);
            int paketId = int.Parse(maskedTextPaketId.Text);
            DateTime baslangicTarihi = DateTime.Parse(maskedTextBaslangicTarihi.Text);
            DateTime bitisTarihi = DateTime.Parse(maskedTextBitisTarihi.Text);

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
                    string query = "INSERT INTO Uyelik (kisi_id, paket_id, baslangic_tarihi, bitis_tarihi) VALUES (@kisi_id, @paket_id, @baslangic_tarihi, @bitis_tarihi);";

                    // Komut oluştur
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        // Parametreleri ekle
                        command.Parameters.AddWithValue("@kisi_id", kisiId);
                        command.Parameters.AddWithValue("@paket_id", paketId);
                        command.Parameters.AddWithValue("@baslangic_tarihi", baslangicTarihi);
                        command.Parameters.AddWithValue("@bitis_tarihi", bitisTarihi);

                        // Komutu çalıştır
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Üyelik başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int uyelikId = int.Parse(maskedTextUyelikId.Text);

            // PostgreSQL bağlantı dizesi (kendi bilgilerinize göre düzenleyin)
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"
                DELETE FROM Odeme WHERE uyelik_id = @uyelik_id;
                DELETE FROM Uyelik WHERE uyelik_id = @uyelik_id;";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@uyelik_id", uyelikId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Üyelik ve ilişkili veriler başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int uyelikId = int.Parse(maskedTextUyelikId.Text);
            int paketId = int.Parse(maskedTextPaketId.Text);
            int kisiId = int.Parse(maskedTextKisiId.Text);
            DateTime baslangicTarihi = DateTime.Parse(maskedTextBaslangicTarihi.Text);
            DateTime bitisTarihi = DateTime.Parse(maskedTextBitisTarihi.Text);

            if (!int.TryParse(maskedTextUyelikId.Text, out uyelikId))
            {
                MessageBox.Show("Geçerli bir Üyelik ID giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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

                    string query = "UPDATE Uyelik SET paket_id = @paket_id, kisi_id = @kisi_id, baslangic_tarihi = @baslangic_tarihi, bitis_tarihi = @bitis_tarihi WHERE uyelik_id = @uyelik_id;";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        // Parametreleri ekle
                        command.Parameters.AddWithValue("@uyelik_id", uyelikId);
                        command.Parameters.AddWithValue("@paket_id", paketId);
                        command.Parameters.AddWithValue("@kisi_id", kisiId);
                        command.Parameters.AddWithValue("@baslangic_tarihi", baslangicTarihi);
                        command.Parameters.AddWithValue("@bitis_tarihi", bitisTarihi);

                        // Komutu çalıştır
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Üyelik başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                "Uyelik",
                @"
                 SELECT 
                    uyelik_id,
                    kisi_id,
                    paket_id,
                    baslangic_tarihi,
                    bitis_tarihi
                FROM Uyelik;"
            );
            ara.ShowDialog();
        }
    }
}
