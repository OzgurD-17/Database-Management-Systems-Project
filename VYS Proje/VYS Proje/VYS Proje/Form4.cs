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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string ekipmanAdi = textEkipmanAdi.Text;
            DateTime bakimTarihi = DateTime.Parse(maskedTextBakimTarihi.Text);
            string durum = comboDurum.SelectedItem.ToString();

            // Girişlerin boş olup olmadığını kontrol et
            if (string.IsNullOrWhiteSpace(textEkipmanAdi.Text))
            {
                throw new ArgumentException("Geçerli bir ekipman adı giriniz.");
            }

            if (comboDurum.SelectedItem == null || string.IsNullOrWhiteSpace(comboDurum.SelectedItem.ToString()))
            {
                throw new ArgumentException("Geçerli bir durum seçiniz");
            }

            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {                  
                    connection.Open();

                    string query = "INSERT INTO Ekipman (ekipman_adi, bakim_tarihi, durum) VALUES (@ekipman_adi, @bakim_tarihi, @durum)";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {                       
                        // Parametreleri ata
                        command.Parameters.AddWithValue("@ekipman_adi", ekipmanAdi);
                        command.Parameters.AddWithValue("@bakim_tarihi", bakimTarihi);
                        command.Parameters.AddWithValue("@durum", durum);

                        // Sorguyu çalıştır
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Ekipman başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int ekipmanId = int.Parse(maskedTextEkipmanId.Text);

            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Ekipman ID'yi kullanan diğer tablolardaki kayıtları sil
                    string query = @"
                DELETE FROM UyeEkipman WHERE ekipman_id = @ekipman_id;
                DELETE FROM Ekipman WHERE ekipman_id = @ekipman_id;";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ekipman_id", ekipmanId);

                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Ekipman ve ilişkili veriler başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int ekipmanId = int.Parse(maskedTextEkipmanId.Text);
            string ekipmanAdi = textEkipmanAdi.Text;
            DateTime bakimTarihi = DateTime.Parse(maskedTextBakimTarihi.Text);
            string durum = comboDurum.SelectedItem.ToString();

            // Girişlerin boş olup olmadığını kontrol et
            if (!int.TryParse(maskedTextEkipmanId.Text, out ekipmanId))
            {
                MessageBox.Show("Geçerli bir Ekipman ID giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(textEkipmanAdi.Text))
            {
                throw new ArgumentException("Geçerli bir ekipman adı giriniz.");
            }

            if (comboDurum.SelectedItem == null || string.IsNullOrWhiteSpace(comboDurum.SelectedItem.ToString()))
            {
                throw new ArgumentException("Geçerli bir durum seçiniz");
            }

            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "UPDATE Ekipman SET ekipman_adi = @ekipman_adi, bakim_tarihi = @bakim_tarihi, durum = @durum WHERE ekipman_id = @ekipman_id";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {                                            
                        // Parametreleri ata
                        command.Parameters.AddWithValue("@ekipman_id", ekipmanId);
                        command.Parameters.AddWithValue("@ekipman_adi", ekipmanAdi);
                        command.Parameters.AddWithValue("@bakim_tarihi", bakimTarihi);
                        command.Parameters.AddWithValue("@durum", durum);

                        // Sorguyu çalıştır
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Ekipman başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                "Ekipman",
                @"
                 SELECT 
                    ekipman_id,
                    ekipman_adi,
                    bakim_tarihi,
                    durum
                FROM Ekipman;"
            );
            ara.ShowDialog();
        }
    }
}
