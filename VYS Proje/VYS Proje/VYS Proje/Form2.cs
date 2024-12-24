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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string ad = textAd.Text;
            string soyad = textSoyad.Text;
            string eposta = textEposta.Text;
            int telefon = int.Parse(maskedTextTelefon.Text);
            string adres = textAdres.Text;
            string saglikDurumu = textSaglikDurumu.Text;
            bool uye = checkUye.Checked;
            bool calisan = checkCalisan.Checked;

            // Alanların boş olup olmadığını kontrol et
            if (string.IsNullOrEmpty(ad))
            {
                MessageBox.Show("Geçerli bir ad giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(soyad))
            {
                MessageBox.Show("Geçerli bir soyad giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(eposta))
            {
                MessageBox.Show("Geçerli bir E-posta giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"
                INSERT INTO Kisi (ad, soyad, eposta, telefon, adres, saglik_durumu, uye, calisan) 
                VALUES (@ad, @soyad, @eposta, @telefon, @adres, @saglik_durumu, @uye, @calisan)";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        // Parametreleri ekle
                        command.Parameters.AddWithValue("@ad", ad);
                        command.Parameters.AddWithValue("@soyad", soyad);
                        command.Parameters.AddWithValue("@eposta", eposta);
                        command.Parameters.AddWithValue("@telefon", telefon);
                        command.Parameters.AddWithValue("@adres", adres);
                        command.Parameters.AddWithValue("@saglik_durumu", saglikDurumu);
                        command.Parameters.AddWithValue("@uye", uye);
                        command.Parameters.AddWithValue("@calisan", calisan);

                        // Sorguyu çalıştır
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Kayıt başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int kisiId = int.Parse(maskedTextKisiId.Text);          

            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();                  
                    
                        // Tüm ilişkili kayıtları sil
                        string query = @"
                    DELETE FROM Degerlendirme WHERE kisi_id = @kisi_id;
                    DELETE FROM SinifRezervasyon WHERE kisi_id = @kisi_id;
                    DELETE FROM UyeEkipman WHERE kisi_id = @kisi_id;
                    DELETE FROM Odeme WHERE kisi_id = @kisi_id;
                    DELETE FROM Uyelik WHERE kisi_id = @kisi_id;
                    DELETE FROM Uye WHERE kisi_id = @kisi_id;
                    DELETE FROM BeslenmeProgrami WHERE kisi_id = @kisi_id;
                    DELETE FROM YarismayaKatilim WHERE kisi_id = @kisi_id;
                    DELETE FROM Egitmen WHERE kisi_id = @kisi_id;
                    DELETE FROM Isci WHERE kisi_id = @kisi_id;
                    DELETE FROM Calisan WHERE kisi_id = @kisi_id;
                    DELETE FROM Kisi WHERE kisi_id = @kisi_id;";

                        using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@kisi_id", kisiId);

                        // Sorguları çalıştır
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Kayıt ve ilişkili veriler başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int kisiId = int.Parse(maskedTextKisiId.Text);
            string ad = textAd.Text.Trim();
            string soyad = textSoyad.Text.Trim();
            string eposta = textEposta.Text.Trim();
            string telefon = maskedTextTelefon.Text.Trim();
            string adres = textAdres.Text.Trim();
            string saglikDurumu = textSaglikDurumu.Text.Trim();
            bool uye = checkUye.Checked;
            bool calisan = checkCalisan.Checked;

            // Alanların boş olup olmadığını kontrol et
            if (!int.TryParse(maskedTextKisiId.Text, out kisiId))
            {
                MessageBox.Show("Geçerli bir Kişi ID giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(ad))
            {
                MessageBox.Show("Geçerli bir ad giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(soyad))
            {
                MessageBox.Show("Geçerli bir soyad giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(eposta))
            {
                MessageBox.Show("Geçerli bir E-posta giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "UPDATE Kisi SET ad = @ad, soyad = @soyad, eposta = @eposta, telefon = @telefon, adres = @adres, saglik_durumu = @saglik_durumu, uye = @uye, calisan = @calisan WHERE kisi_id = @kisi_id";        

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        // Parametreleri ekle
                        command.Parameters.AddWithValue("@ad", ad);
                        command.Parameters.AddWithValue("@soyad", soyad);
                        command.Parameters.AddWithValue("@eposta", eposta);
                        command.Parameters.AddWithValue("@telefon", telefon);
                        command.Parameters.AddWithValue("@adres", adres);
                        command.Parameters.AddWithValue("@saglik_durumu", saglikDurumu);
                        command.Parameters.AddWithValue("@uye", uye);
                        command.Parameters.AddWithValue("@calisan", calisan);
                        command.Parameters.AddWithValue("@kisi_id", kisiId);

                        // Sorguyu çalıştır
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Kayıt başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                "Kisi",
                @"
                 SELECT 
                    kisi_id,
                    ad,
                    soyad,
                    eposta,
                    telefon,
                    adres,
                    saglik_durumu,
                    uye,
                    calisan
                FROM Kisi;"
            );
            ara.ShowDialog();
        }
    }
}
