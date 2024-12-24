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
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string paketAdi = textPaketAdi.Text;
            int sure = int.Parse(maskedTextSure.Text);
            int fiyat = int.Parse(maskedTextFiyat.Text);

            if (!int.TryParse(maskedTextSure.Text, out sure) || sure <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir süre giriniz (0'dan büyük bir sayı).", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(maskedTextFiyat.Text, out  fiyat) || fiyat < 0)
            {
                MessageBox.Show("Lütfen geçerli bir fiyat giriniz (0 veya daha büyük bir sayı).", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try                              
                {
                    connection.Open();

                    // SQL sorgusu
                    string query = "INSERT INTO UyelikPaket (paket_adi, sure, fiyat) VALUES (@paket_adi, @sure, @fiyat)";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        // Parametreleri ekle
                        command.Parameters.AddWithValue("@paket_adi", paketAdi);
                        command.Parameters.AddWithValue("@sure", sure);
                        command.Parameters.AddWithValue("@fiyat", fiyat);

                        // Sorguyu çalıştır
                        int rowsAffected = command.ExecuteNonQuery();

                        // Kullanıcıya geri bildirim
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Üyelik paketi başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int paketId = int.Parse(maskedTextPaketId.Text);

            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";         

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Silme işlemi
                    string query = @"
                DELETE FROM UyelikPaket WHERE paket_id = @paket_id;                
                DELETE FROM Uyelik WHERE paket_id = @paket_id;";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@paket_id", paketId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Üyelik paketi başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int paketId = int.Parse(maskedTextPaketId.Text);
            string paketAdi = textPaketAdi.Text;
            int sure = int.Parse(maskedTextSure.Text);
            int fiyat = int.Parse(maskedTextFiyat.Text);

            if (!int.TryParse(maskedTextPaketId.Text, out paketId))
            {
                MessageBox.Show("Geçerli bir Paket ID giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }           

            if (!int.TryParse(maskedTextSure.Text, out sure) || sure <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir süre giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(maskedTextFiyat.Text, out fiyat) || fiyat < 0)
            {
                MessageBox.Show("Lütfen geçerli bir fiyat giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "UPDATE UyelikPaket SET paket_adi = @paket_adi, sure = @sure, fiyat = @fiyat WHERE paket_id = @paket_id";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@paket_adi", paketAdi);
                        command.Parameters.AddWithValue("@sure", sure);
                        command.Parameters.AddWithValue("@fiyat", fiyat);
                        command.Parameters.AddWithValue("@paket_id", paketId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Üyelik paketi başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                "UyelikPaket",
                @"
                 SELECT 
                    paket_id,
                    paket_adi,
                    sure,
                    fiyat
                FROM UyelikPaket;"
            );
            ara.ShowDialog();
        }
    }
    
}
