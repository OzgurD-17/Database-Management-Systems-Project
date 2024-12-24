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
    public partial class Form18 : Form
    {
        public Form18()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            int sinifId = int.Parse(maskedTextSinifId.Text);
            int dersId = int.Parse(maskedTextDersId.Text);

            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // SQL INSERT sorgusu
                    string query = "INSERT INTO SinifDers (sinif_id, ders_id) VALUES (@sinif_id, @ders_id);";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        // Parametreleri tanımlama
                        command.Parameters.AddWithValue("@sinif_id", sinifId);
                        command.Parameters.AddWithValue("@ders_id", dersId);

                        // Komutu çalıştır
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
            int sinifDersId = int.Parse(maskedTextSinifDersId.Text);

            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Silme işlemi için SQL sorgusu
                    string query = @"
                    DELETE FROM SinifDers WHERE sinif_ders_id = @sinif_ders_id;";
                    
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@sinif_ders_id", sinifDersId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Kayıt ve ilişkili veriler başarıyla silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int sinifDersId = int.Parse(maskedTextSinifDersId.Text);
            int sinifId = int.Parse(maskedTextSinifId.Text);
            int dersId = int.Parse(maskedTextDersId.Text);

            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Güncelleme işlemi için SQL sorgusu
                    string query = "UPDATE SinifDers SET sinif_id = @sinif_id, ders_id = @ders_id WHERE sinif_ders_id = @sinif_ders_id;";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@sinif_ders_id", sinifDersId);
                        command.Parameters.AddWithValue("@sinif_id", sinifId);
                        command.Parameters.AddWithValue("@ders_id", dersId);

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
                "SinifDers",
                @"
                 SELECT 
                    sinifders_id,
                    sinif_id,
                    ders_id
                FROM SinifDers;"
            );
            ara.ShowDialog();
        }
    }
}
