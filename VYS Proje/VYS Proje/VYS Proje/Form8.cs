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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string sinifAdi = textSinifAdi.Text;
            int kapasite = int.Parse(maskedTextKapasite.Text);
            int egitmenId = int.Parse(maskedTextEgitmenId.Text);

            // NOT NULL kontrolü
            if (string.IsNullOrWhiteSpace(sinifAdi))
            {
                MessageBox.Show("Geçerli bir sınıf adı giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kapasite kontrolü (ek kontrol)
            if (kapasite <= 0)
            {
                MessageBox.Show("Kapasite sıfırdan büyük olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // SQL komutu
                    string query = "INSERT INTO Sinif (sinif_adi, kapasite, egitmen_id) VALUES (@sinif_adi, @kapasite, @egitmen_id)";                   

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        // Parametreleri ekliyoruz
                        command.Parameters.AddWithValue("@sinifAdi", sinifAdi);
                        command.Parameters.AddWithValue("@kapasite", kapasite);
                        command.Parameters.AddWithValue("@egitmenId", egitmenId);                        

                        // Komut çalıştırılıyor
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Sınıf başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int sinifId = int.Parse(maskedTextSinifId.Text);

            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();                 

                    string query = @"
                DELETE FROM Sinif WHERE sinif_id = @sinifId;
                DELETE FROM SinifRezervasyon WHERE sinif_id = @sinifId;
                DELETE FROM Degerlendirme WHERE sinif_id = @sinifId;
                DELETE FROM Yoklama WHERE sinif_id = @sinifId;
                DELETE FROM SinifDers WHERE sinif_id = @sinifId;";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@sinif_id", sinifId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Sınıf ve ilişkili kayıtlar başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int sinifId = int.Parse(maskedTextSinifId.Text);
            string sinifAdi = textSinifAdi.Text;
            int kapasite = int.Parse(maskedTextKapasite.Text);
            int egitmenId = int.Parse(maskedTextEgitmenId.Text);

            // NOT NULL kontrolü
            if (!int.TryParse(maskedTextSinifId.Text, out sinifId))
            {
                MessageBox.Show("Geçerli bir Sınıf ID giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(sinifAdi))
            {
                MessageBox.Show("Geçerli bir sınıf adı giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kapasite kontrolü (ek kontrol)
            if (kapasite <= 0)
            {
                MessageBox.Show("Kapasite sıfırdan büyük olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "UPDATE Sinif SET sinif_adi = @sinif_adi, kapasite = @kapasite, egitmen_id = @egitmen_id WHERE sinif_id = @sinif_id";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@sinif_id", sinifId);
                        command.Parameters.AddWithValue("@sinif_adi", sinifAdi);
                        command.Parameters.AddWithValue("@kapasite", kapasite);
                        command.Parameters.AddWithValue("@egitmen_id", egitmenId);                        

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Kayıt başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                "Sinif",
                @"
                 SELECT 
                    sinif_id,
                    sinif_adi,
                    kapasite,
                    egitmen_id
                FROM Sinif;"
            );
            ara.ShowDialog();
        }
    }
}
