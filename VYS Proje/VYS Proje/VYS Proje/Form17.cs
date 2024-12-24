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
    public partial class Form17 : Form
    {
        public Form17()
        {
            InitializeComponent();
        }

        private void Form17_Load(object sender, EventArgs e)
        {

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            // Kullanıcıdan alınan veriler
            int kisiId = int.Parse(maskedTextKisiId.Text);
            int programId = int.Parse(maskedTextProgramId.Text);

            // PostgreSQL bağlantı bilgileri
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // SQL sorgusu
                    string query = "INSERT INTO Uye (kisi_id, program_id) VALUES (@kisi_id, @program_id);";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        // Parametrelerin atanması
                        command.Parameters.AddWithValue("@kisi_id", kisiId);
                        command.Parameters.AddWithValue("@program_id", programId);

                        // Sorgunun çalıştırılması
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
                    // Hata mesajı göster
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
            int programId = int.Parse(maskedTextProgramId.Text);

            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Güncelleme sorgusu
                    string query = "UPDATE Uye SET program_id = @program_id WHERE kisi_id = @kisi_id;";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@kisi_id", kisiId);
                        command.Parameters.AddWithValue("@program_id", programId);

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
                "Uye",
                @"
                 SELECT 
                    kisi_id,
                    program_id
                FROM Uye;"
            );
            ara.ShowDialog();
        }
    }
}
