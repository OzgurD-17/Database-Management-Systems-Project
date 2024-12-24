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
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }

        private void Form14_Load(object sender, EventArgs e)
        {

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            int kisiId = int.Parse(maskedTextKisiId.Text);
            string hedef = textHedef.Text;
            DateTime baslangicTarihi = DateTime.Parse(maskedTextBaslangicTarihi.Text);
            DateTime bitisTarihi = DateTime.Parse(maskedTextBitisTarihi.Text);

            // Tarih formatlarını kontrol ediyoruz.
            if (!DateTime.TryParse(maskedTextBaslangicTarihi.Text, out baslangicTarihi))
            {
                MessageBox.Show("Geçerli bir başlangıç tarihi giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!DateTime.TryParse(maskedTextBitisTarihi.Text, out bitisTarihi))
            {
                MessageBox.Show("Geçerli bir bitiş tarihi giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Bitiş tarihinin başlangıç tarihinden önce olup olmadığını kontrol et
            if (bitisTarihi <= baslangicTarihi)
            {
                MessageBox.Show("Bitiş tarihi, başlangıç tarihinden sonra olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // PostgreSQL bağlantı bilgileri.
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))            
            {
                try             
                {
                    connection.Open();

                    // SQL sorgusu.
                    string query = "INSERT INTO BeslenmeProgrami (kisi_id, hedef, baslangic_tarihi, bitis_tarihi) VALUES (@kisi_id, @hedef, @baslangic_tarihi, @bitis_tarihi)";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        // Parametreleri ekliyoruz.
                        command.Parameters.AddWithValue("@kisi_id", kisiId);
                        command.Parameters.AddWithValue("@hedef", hedef);
                        command.Parameters.AddWithValue("@baslangic_tarihi", baslangicTarihi);
                        command.Parameters.AddWithValue("@bitis_tarihi", bitisTarihi);

                        // Sorguyu çalıştırıyoruz.
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Beslenme programı başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int beslenmeId = int.Parse(maskedTextBeslenmeId.Text);

            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"
                DELETE FROM AntrenmanProgrami WHERE beslenme_id = @beslenme_id;
                DELETE FROM BeslenmeProgrami WHERE beslenme_id = @beslenme_id;";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@beslenme_id", beslenmeId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Beslenme programı ve ilişkili veriler başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            int beslenmeId = int.Parse(maskedTextBeslenmeId.Text);
            int kisiId = int.Parse(maskedTextKisiId.Text);
            string hedef = textHedef.Text;
            DateTime baslangicTarihi = DateTime.Parse(maskedTextBaslangicTarihi.Text);
            DateTime bitisTarihi = DateTime.Parse(maskedTextBitisTarihi.Text);

            if (!DateTime.TryParse(maskedTextBaslangicTarihi.Text, out baslangicTarihi))
            {
                MessageBox.Show("Geçerli bir başlangıç tarihi giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!DateTime.TryParse(maskedTextBitisTarihi.Text, out bitisTarihi))
            {
                MessageBox.Show("Geçerli bir bitiş tarihi giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Bitiş tarihinin başlangıç tarihinden önce olup olmadığını kontrol et
            if (bitisTarihi <= baslangicTarihi)
            {
                MessageBox.Show("Bitiş tarihi, başlangıç tarihinden sonra olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                
            {
                try
                {
                    connection.Open();

                    string query = "UPDATE BeslenmeProgrami SET kisi_id = @kisi_id, hedef = @hedef, baslangic_tarihi = @baslangic_tarihi, bitis_tarihi = @bitis_tarihi WHERE beslenme_id = @beslenme_id";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@beslenme_id", beslenmeId);
                        command.Parameters.AddWithValue("@kisi_id", kisiId);
                        command.Parameters.AddWithValue("@hedef", hedef);
                        command.Parameters.AddWithValue("@baslangic_tarihi", baslangicTarihi);
                        command.Parameters.AddWithValue("@bitis_tarihi", bitisTarihi);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Beslenme programı  başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                "BeslenmeProgrami",
                @"
                 SELECT 
                    beslenme_id,
                    hedef,
                    baslangic_tarihi,
                    bitis_tarihi,
                    kisi_id                  
                FROM BeslenmeProgrami;"
            );
            ara.ShowDialog();
        }
    }
}
