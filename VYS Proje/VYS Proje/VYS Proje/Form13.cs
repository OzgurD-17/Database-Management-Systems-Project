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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            int beslenmeId = int.Parse(maskedTextBeslenmeId.Text);
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
                    string query = "INSERT INTO AntrenmanProgrami (beslenme_id, hedef, baslangic_tarihi, bitis_tarihi) VALUES (@beslenme_id, @hedef, @baslangic_tarihi, @bitis_tarihi)";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        // Parametreleri ekliyoruz.
                        command.Parameters.AddWithValue("@beslenme_id", beslenmeId);
                        command.Parameters.AddWithValue("@hedef", hedef);
                        command.Parameters.AddWithValue("@baslangic_tarihi", baslangicTarihi);
                        command.Parameters.AddWithValue("@bitis_tarihi", bitisTarihi);

                        // Sorguyu çalıştırıyoruz.
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Antrenman programı başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int programId = int.Parse(maskedTextProgramId.Text);

            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123123;Database=proje";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"
                DELETE FROM Uye WHERE program_id = @program_id;
                DELETE FROM AntrenmanProgrami WHERE program_id = @program_id";
                    
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@program_id", programId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Antrenman programı ve ilişkili veriler başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int programId = int.Parse(maskedTextProgramId.Text);
            int beslenmeId = int.Parse(maskedTextBeslenmeId.Text);
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

                    string query = "UPDATE AntrenmanProgrami SET beslenme_id = @beslenme_id, hedef = @hedef, baslangic_tarihi = @baslangic_tarihi, bitis_tarihi = @bitis_tarihi WHERE program_id = @program_id";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@program_id", programId);
                        command.Parameters.AddWithValue("@beslenme_id", beslenmeId);
                        command.Parameters.AddWithValue("@hedef", hedef);
                        command.Parameters.AddWithValue("@baslangic_tarihi", baslangicTarihi);
                        command.Parameters.AddWithValue("@bitis_tarihi", bitisTarihi);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Antrenman programı başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                "AntrenmanProgrami",
                @"
                 SELECT 
                    program_id,
                    hedef,
                    baslangic_tarihi,
                    bitis_tarihi,
                    beslenme_id
                FROM AntrenmanProgrami;"
            );
            ara.ShowDialog();
        }
    }
}
