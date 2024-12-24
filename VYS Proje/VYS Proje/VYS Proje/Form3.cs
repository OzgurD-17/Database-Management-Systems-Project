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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            int kisiId = int.Parse(maskedTextKisiId.Text);
            string uzmanlik = textUzmanlik.Text;
            int deneyim = int.Parse(maskedTextDeneyim.Text);
            int maas = int.Parse(maskedTextMaas.Text);

            if (string.IsNullOrWhiteSpace(uzmanlik))
            {
                MessageBox.Show("Geçerli bir uzmanlık giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(maskedTextDeneyim.Text, out deneyim) || deneyim < 0)
            {
                MessageBox.Show("Deneyim sıfır veya daha büyük bir sayı olmalıdır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(maskedTextMaas.Text, out maas) || maas <= 0)
            {
                MessageBox.Show("Maaş sıfırdan büyük bir değer olmalıdır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))                
            {
                try
                {
                    connection.Open();

                    // Veritabanına ekleme sorgusu
                    string query = "INSERT INTO Calisan (kisi_id, uzmanlik, deneyim, maas) VALUES (@kisi_id, @uzmanlik, @deneyim, @maas)";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@kisi_id", kisiId);
                        command.Parameters.AddWithValue("@uzmanlik", uzmanlik);
                        command.Parameters.AddWithValue("@deneyim", deneyim);
                        command.Parameters.AddWithValue("@maas", maas);

                        int result = command.ExecuteNonQuery();

                        if (result > 0)
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

        private void btnSil_Click(object sender, EventArgs e)
        {
            int kisiId = int.Parse(maskedTextKisiId.Text);

            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";           

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Tüm ilişkili kayıtlardan silmek için sorgu
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
            string uzmanlik = textUzmanlik.Text;
            int deneyim = int.Parse(maskedTextDeneyim.Text);
            int maas = int.Parse(maskedTextMaas.Text);

            if (!int.TryParse(maskedTextKisiId.Text, out kisiId))
            {
                MessageBox.Show("Geçerli bir Kişi ID giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(uzmanlik))
            {
                MessageBox.Show("Geçerli bir uzmanlık giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(maskedTextDeneyim.Text, out deneyim) || deneyim < 0)
            {
                MessageBox.Show("Deneyim sıfır veya daha büyük bir sayı olmalıdır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(maskedTextMaas.Text, out maas) || maas <= 0)
            {
                MessageBox.Show("Maaş sıfırdan büyük bir değer olmalıdır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Güncelleme sorgusu
                    string query = "UPDATE Calisan SET uzmanlik = @uzmanlik, deneyim = @deneyim, maas = @maas WHERE kisi_id = @kisi_id";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@kisi_id", kisiId);
                        command.Parameters.AddWithValue("@uzmanlik", uzmanlik);
                        command.Parameters.AddWithValue("@deneyim", deneyim);
                        command.Parameters.AddWithValue("@maas", maas);

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
                "Calisan",
                @"
                 SELECT 
                    kisi_id,
                    uzmanlik,
                    deneyim,
                    maas
                FROM Calisan;"
            );
            ara.ShowDialog();
        }
    }
}
