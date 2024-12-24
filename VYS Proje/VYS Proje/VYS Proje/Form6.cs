using Npgsql;
using System;
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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            int kisiId = int.Parse(maskedTextKisiId.Text);
            int uyelikId = int.Parse(maskedTextUyelikId.Text);
            int tutar = int.Parse(maskedTextTutar.Text);
            DateTime odemeTarihi = DateTime.Parse(maskedTextOdemeTarihi.Text);

            // Veri giriş kontrolleri          

            if (!DateTime.TryParse(maskedTextOdemeTarihi.Text, out odemeTarihi))
            {
                MessageBox.Show("Geçerli bir ödeme tarihi giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (tutar <= 0)
            {
                MessageBox.Show("Tutar sıfırdan büyük olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // PostgreSQL bağlantısı
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {              

                try
                {
                    connection.Open();

                    string query = "INSERT INTO Odeme (kisi_id, uyelik_id, tutar, odeme_tarihi) VALUES (@kisi_id, @uyelik_id, @tutar, @odeme_tarihi)";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@kisi_id", kisiId);
                        command.Parameters.AddWithValue("@uyelik_id", uyelikId);
                        command.Parameters.AddWithValue("@tutar", tutar);
                        command.Parameters.AddWithValue("@odeme_tarihi", odemeTarihi);

                        // Sorguyu çalıştır
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Ödeme başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int odemeId = int.Parse(maskedTextOdemeId.Text);

            // PostgreSQL bağlantısı
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"
                DELETE FROM Odeme WHERE odeme_id = @odeme_id;";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@odeme_id", odemeId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Ödeme ve ilişkili veriler başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int odemeId = int.Parse(maskedTextOdemeId.Text);
            int uyelikId = int.Parse(maskedTextUyelikId.Text);
            int kisiId = int.Parse(maskedTextKisiId.Text); 
            int tutar = int.Parse(maskedTextTutar.Text);
            DateTime odemeTarihi = DateTime.Parse(maskedTextOdemeTarihi.Text);

            if (!int.TryParse(maskedTextOdemeId.Text, out odemeId))
            {
                MessageBox.Show("Geçerli bir Ödeme ID giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!DateTime.TryParse(maskedTextOdemeTarihi.Text, out odemeTarihi))
            {
                MessageBox.Show("Geçerli bir ödeme tarihi giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (tutar <= 0)
            {
                MessageBox.Show("Tutar sıfırdan büyük olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // PostgreSQL bağlantısı
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "UPDATE Odeme SET uyelik_id = @uyelik_id, kisi_id = @kisi_id, tutar = @tutar, odeme_tarihi = @odeme_tarihi WHERE odeme_id = @odeme_id";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@odeme_id", odemeId);
                        command.Parameters.AddWithValue("@uyelik_id", uyelikId);
                        command.Parameters.AddWithValue("@kisi_id", kisiId);
                        command.Parameters.AddWithValue("@tutar", tutar);
                        command.Parameters.AddWithValue("@odeme_tarihi", odemeTarihi);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Ödeme başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                "Odeme",
                @"
                 SELECT 
                    odeme_id,
                    kisi_id,
                    tutar,
                    odeme_tarihi,
                    uyelik_id
                FROM Odeme;"
            );
            ara.ShowDialog();
        }
    }
}
