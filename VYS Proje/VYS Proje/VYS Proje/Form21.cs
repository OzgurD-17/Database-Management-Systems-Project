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
    public partial class Form21 : Form
    {
        public Form21()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            int kisiId = int.Parse(maskedTextKisiId.Text);

            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            // Veritabanına bağlanma ve veri ekleme
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open(); // Bağlantıyı aç

                    // SQL sorgusu
                    string query = "INSERT INTO Isci (kisi_id) VALUES (@kisi_id);";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        // Parametre ekleme
                        command.Parameters.AddWithValue("@kisi_id", kisiId);

                        // Sorguyu çalıştır
                        int rowsAffected = command.ExecuteNonQuery();

                        // Kullanıcıya bilgi ver
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Kayıt başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int kisiId = int.Parse(maskedTextKisiId.Text);

            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Silme işlemi için SQL sorguları
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
                        // Parametre ekleme
                        command.Parameters.AddWithValue("@kisi_id", kisiId);

                        // Sorguyu çalıştır
                        int rowsAffected = command.ExecuteNonQuery();

                        // Kullanıcıya bilgi ver
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Kayıt ve ilgili veriler başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                "Isci", 
                @"
                 SELECT 
                    kisi_id                  
                FROM Isci;"
            );
            ara.ShowDialog();
        }
    }   
}


