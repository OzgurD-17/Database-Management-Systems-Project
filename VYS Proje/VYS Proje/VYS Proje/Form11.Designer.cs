namespace VYS_Proje
{
    partial class Form11
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.maskedTextYarismaId = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextTarih = new System.Windows.Forms.MaskedTextBox();
            this.textAd = new System.Windows.Forms.TextBox();
            this.textKazanan = new System.Windows.Forms.TextBox();
            this.textSponsor = new System.Windows.Forms.TextBox();
            this.textYer = new System.Windows.Forms.TextBox();
            this.textOdul = new System.Windows.Forms.TextBox();
            this.btnAra = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(418, 250);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(225, 70);
            this.btnGuncelle.TabIndex = 48;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(418, 149);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(225, 70);
            this.btnSil.TabIndex = 47;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(418, 48);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(225, 70);
            this.btnEkle.TabIndex = 46;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 23);
            this.label1.TabIndex = 49;
            this.label1.Text = "Yarışma ID :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 23);
            this.label2.TabIndex = 50;
            this.label2.Text = "Ad :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 23);
            this.label3.TabIndex = 51;
            this.label3.Text = "Tarih :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 23);
            this.label4.TabIndex = 52;
            this.label4.Text = "Yer :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 23);
            this.label5.TabIndex = 53;
            this.label5.Text = "Ödül :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(64, 305);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 23);
            this.label6.TabIndex = 54;
            this.label6.Text = "Kazanan :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(64, 354);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 23);
            this.label7.TabIndex = 55;
            this.label7.Text = "Sponsor :";
            // 
            // maskedTextYarismaId
            // 
            this.maskedTextYarismaId.Location = new System.Drawing.Point(209, 57);
            this.maskedTextYarismaId.Mask = "00000";
            this.maskedTextYarismaId.Name = "maskedTextYarismaId";
            this.maskedTextYarismaId.Size = new System.Drawing.Size(125, 29);
            this.maskedTextYarismaId.TabIndex = 56;
            this.maskedTextYarismaId.ValidatingType = typeof(int);
            // 
            // maskedTextTarih
            // 
            this.maskedTextTarih.Location = new System.Drawing.Point(209, 155);
            this.maskedTextTarih.Mask = "00/00/0000";
            this.maskedTextTarih.Name = "maskedTextTarih";
            this.maskedTextTarih.Size = new System.Drawing.Size(125, 29);
            this.maskedTextTarih.TabIndex = 57;
            this.maskedTextTarih.ValidatingType = typeof(System.DateTime);
            // 
            // textAd
            // 
            this.textAd.Location = new System.Drawing.Point(209, 106);
            this.textAd.Name = "textAd";
            this.textAd.Size = new System.Drawing.Size(125, 29);
            this.textAd.TabIndex = 58;
            // 
            // textKazanan
            // 
            this.textKazanan.Location = new System.Drawing.Point(209, 302);
            this.textKazanan.Name = "textKazanan";
            this.textKazanan.Size = new System.Drawing.Size(125, 29);
            this.textKazanan.TabIndex = 59;
            // 
            // textSponsor
            // 
            this.textSponsor.Location = new System.Drawing.Point(209, 351);
            this.textSponsor.Name = "textSponsor";
            this.textSponsor.Size = new System.Drawing.Size(125, 29);
            this.textSponsor.TabIndex = 60;
            // 
            // textYer
            // 
            this.textYer.Location = new System.Drawing.Point(209, 204);
            this.textYer.Name = "textYer";
            this.textYer.Size = new System.Drawing.Size(125, 29);
            this.textYer.TabIndex = 61;
            // 
            // textOdul
            // 
            this.textOdul.Location = new System.Drawing.Point(209, 253);
            this.textOdul.Name = "textOdul";
            this.textOdul.Size = new System.Drawing.Size(125, 29);
            this.textOdul.TabIndex = 62;
            // 
            // btnAra
            // 
            this.btnAra.Location = new System.Drawing.Point(418, 351);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(225, 70);
            this.btnAra.TabIndex = 63;
            this.btnAra.Text = "Ara";
            this.btnAra.UseVisualStyleBackColor = true;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // Form11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(692, 452);
            this.Controls.Add(this.btnAra);
            this.Controls.Add(this.textOdul);
            this.Controls.Add(this.textYer);
            this.Controls.Add(this.textSponsor);
            this.Controls.Add(this.textKazanan);
            this.Controls.Add(this.textAd);
            this.Controls.Add(this.maskedTextTarih);
            this.Controls.Add(this.maskedTextYarismaId);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnEkle);
            this.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "Form11";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yarışma";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox maskedTextYarismaId;
        private System.Windows.Forms.MaskedTextBox maskedTextTarih;
        private System.Windows.Forms.TextBox textAd;
        private System.Windows.Forms.TextBox textKazanan;
        private System.Windows.Forms.TextBox textSponsor;
        private System.Windows.Forms.TextBox textYer;
        private System.Windows.Forms.TextBox textOdul;
        private System.Windows.Forms.Button btnAra;
    }
}