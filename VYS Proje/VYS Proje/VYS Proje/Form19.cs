using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VYS_Proje
{
    public partial class Form19 : Form
    {
        public Form19()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            int kisiId = int.Parse(maskedTextKisiId.Text);
            int ekipmanId = int.Parse(maskedTextEkipmanId.Text);
            DateTime kullanimTarihi = DateTime.Parse(maskedTextKullanimTarihi.Text);

            if (!DateTime.TryParse(maskedTextKullanimTarihi.Text, out kullanimTarihi))
            {
                MessageBox.Show("Geçerli bir kullanım tarihi giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    string query = "INSERT INTO UyeEkipman (kisi_id, ekipman_id, kullanim_tarihi) VALUES (@kisi_id, @ekipman_id, @kullanim_tarihi)";

                    // Komut oluşturma
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        // Parametreleri ekleme
                        command.Parameters.AddWithValue("kisi_id", kisiId);
                        command.Parameters.AddWithValue("ekipman_id", ekipmanId);
                        command.Parameters.AddWithValue("kullanim_tarihi", kullanimTarihi);

                        // Komutu çalıştırma
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Kayıt başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int uyeEkipmanId = int.Parse(maskedTextUyeEkipmanId.Text);

            // PostgreSQL bağlantı dizesi
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // SQL sorgusu: İlişkili tüm tablolardan sil
                    string query = @"
                DELETE FROM UyeEkipman WHERE uye_ekipman_id = @uye_ekipman_id RETURNING uye_ekipman_id;";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        // Parametre ekleme
                        command.Parameters.AddWithValue("uye_ekipman_id", uyeEkipmanId);

                        // Komutu çalıştırma
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Kayıt başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int uyeEkipmanId = int.Parse(maskedTextUyeEkipmanId.Text);
            int ekipmanId = int.Parse(maskedTextEkipmanId.Text);
            int kisiId = int.Parse(maskedTextKisiId.Text);
            DateTime kullanimTarihi = DateTime.Parse(maskedTextKullanimTarihi.Text);

            if (!DateTime.TryParse(maskedTextKullanimTarihi.Text, out kullanimTarihi))
            {
                MessageBox.Show("Geçerli bir tarih giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // PostgreSQL bağlantı dizesi
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // SQL sorgusu: Güncelleme
                    string query = "UPDATE UyeEkipman SET ekipman_id = @ekipman_id, kisi_id = @kisi_id, kullanim_tarihi = @kullanim_tarihi WHERE uye_ekipman_id = @uye_ekipman_id";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        // Parametre ekleme
                        command.Parameters.AddWithValue("uye_ekipman_id", uyeEkipmanId);
                        command.Parameters.AddWithValue("ekipman_id", ekipmanId);
                        command.Parameters.AddWithValue("kisi_id", kisiId);
                        command.Parameters.AddWithValue("kullanim_tarihi", kullanimTarihi);

                        // Komutu çalıştırma
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Kayıt başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                 "UyeEkipman",
                 @"
                 SELECT 
                    uye_ekipman_id,
                    kisi_id,
                    ekipman_id,
                    kullanim_tarihi
                FROM UyeEkipman;"
             );
            ara.ShowDialog();
        }
    }
}
