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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            int kisiId = int.Parse(maskedTextKisiId.Text);
            int yarismaId = int.Parse(maskedTextYarismaId.Text);
            DateTime katilimTarihi = DateTime.Parse(maskedTextKatilimTarihi.Text);

            if (!DateTime.TryParse(maskedTextKatilimTarihi.Text, out katilimTarihi))
            {
                MessageBox.Show("Geçerli bir katılım tarih giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))            
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO YarismayaKatilim (kisi_id, yarisma_id, katilim_tarihi) VALUES (@kisi_id, @yarisma_id, @katilim_tarihi)";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@kisi_id", kisiId);
                        command.Parameters.AddWithValue("@yarisma_id", yarismaId);
                        command.Parameters.AddWithValue("@katilim_tarihi", katilimTarihi);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Yarışmaya katılım başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int katilimId = int.Parse(maskedTextKatilimId.Text);

            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Silme işlemi için SQL sorgusu
                    string query = @"              
                        DELETE FROM YarismayaKatilim WHERE katilim_id = @katilim_id;";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@katilim_id", katilimId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Yarışmaya katılım ve ilgili tüm bağlantılı veriler başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int katilimId = int.Parse(maskedTextKatilimId.Text);
            int kisiId = int.Parse(maskedTextKisiId.Text);
            int yarismaId = int.Parse(maskedTextYarismaId.Text);
            DateTime katilimTarihi = DateTime.Parse(maskedTextKatilimTarihi.Text);

            if (!DateTime.TryParse(maskedTextKatilimTarihi.Text, out katilimTarihi))
            {
                MessageBox.Show("Geçerli bir katılım tarih giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Güncelleme işlemi için SQL sorgusu
                    string query = "UPDATE YarismayaKatilim SET kisi_id = @kisi_id, yarisma_id = @yarisma_id, katilim_tarihi = @katilim_tarihi WHERE katilim_id = @katilim_id";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@kisi_id", kisiId);
                        command.Parameters.AddWithValue("@yarisma_id", yarismaId);
                        command.Parameters.AddWithValue("@katilim_tarihi", katilimTarihi);
                        command.Parameters.AddWithValue("@katilim_id", katilimId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Yarışmaya katılım başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                "YarismayaKatilim",
                @"
                 SELECT 
                    katilim_id,
                    kisi_id,
                    yarisma_id,
                    katilim_tarihi
                FROM YarismayaKatilim;"
            );
            ara.ShowDialog();
        }
    }
}
