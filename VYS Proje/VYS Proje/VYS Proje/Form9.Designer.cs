namespace VYS_Proje
{
    partial class Form9
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
            this.maskedTextRezervasyonId = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextSinifId = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextKisiId = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBitisTarihi = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBaslangicTarihi = new System.Windows.Forms.MaskedTextBox();
            this.btnAra = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(418, 205);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(225, 70);
            this.btnGuncelle.TabIndex = 42;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(418, 117);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(225, 70);
            this.btnSil.TabIndex = 41;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(418, 29);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(225, 70);
            this.btnEkle.TabIndex = 40;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 23);
            this.label1.TabIndex = 43;
            this.label1.Text = "Rezervasyon ID :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 23);
            this.label2.TabIndex = 44;
            this.label2.Text = "Başlangıç Tarihi :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 23);
            this.label3.TabIndex = 45;
            this.label3.Text = "Bitiş Tarihi :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 23);
            this.label4.TabIndex = 46;
            this.label4.Text = "Kişi ID :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 265);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 23);
            this.label5.TabIndex = 47;
            this.label5.Text = "Sınıf ID :";
            // 
            // maskedTextRezervasyonId
            // 
            this.maskedTextRezervasyonId.Location = new System.Drawing.Point(223, 50);
            this.maskedTextRezervasyonId.Mask = "00000";
            this.maskedTextRezervasyonId.Name = "maskedTextRezervasyonId";
            this.maskedTextRezervasyonId.Size = new System.Drawing.Size(125, 29);
            this.maskedTextRezervasyonId.TabIndex = 48;
            this.maskedTextRezervasyonId.ValidatingType = typeof(int);
            // 
            // maskedTextSinifId
            // 
            this.maskedTextSinifId.Location = new System.Drawing.Point(223, 262);
            this.maskedTextSinifId.Mask = "00000";
            this.maskedTextSinifId.Name = "maskedTextSinifId";
            this.maskedTextSinifId.Size = new System.Drawing.Size(125, 29);
            this.maskedTextSinifId.TabIndex = 49;
            this.maskedTextSinifId.ValidatingType = typeof(int);
            // 
            // maskedTextKisiId
            // 
            this.maskedTextKisiId.Location = new System.Drawing.Point(223, 209);
            this.maskedTextKisiId.Mask = "00000";
            this.maskedTextKisiId.Name = "maskedTextKisiId";
            this.maskedTextKisiId.Size = new System.Drawing.Size(125, 29);
            this.maskedTextKisiId.TabIndex = 50;
            this.maskedTextKisiId.ValidatingType = typeof(int);
            // 
            // maskedTextBitisTarihi
            // 
            this.maskedTextBitisTarihi.Location = new System.Drawing.Point(223, 156);
            this.maskedTextBitisTarihi.Mask = "00/00/0000";
            this.maskedTextBitisTarihi.Name = "maskedTextBitisTarihi";
            this.maskedTextBitisTarihi.Size = new System.Drawing.Size(125, 29);
            this.maskedTextBitisTarihi.TabIndex = 51;
            this.maskedTextBitisTarihi.ValidatingType = typeof(System.DateTime);
            // 
            // maskedTextBaslangicTarihi
            // 
            this.maskedTextBaslangicTarihi.Location = new System.Drawing.Point(223, 103);
            this.maskedTextBaslangicTarihi.Mask = "00/00/0000";
            this.maskedTextBaslangicTarihi.Name = "maskedTextBaslangicTarihi";
            this.maskedTextBaslangicTarihi.Size = new System.Drawing.Size(125, 29);
            this.maskedTextBaslangicTarihi.TabIndex = 52;
            this.maskedTextBaslangicTarihi.ValidatingType = typeof(System.DateTime);
            // 
            // btnAra
            // 
            this.btnAra.Location = new System.Drawing.Point(418, 293);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(225, 70);
            this.btnAra.TabIndex = 57;
            this.btnAra.Text = "Ara";
            this.btnAra.UseVisualStyleBackColor = true;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // Form9
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(683, 396);
            this.Controls.Add(this.btnAra);
            this.Controls.Add(this.maskedTextBaslangicTarihi);
            this.Controls.Add(this.maskedTextBitisTarihi);
            this.Controls.Add(this.maskedTextKisiId);
            this.Controls.Add(this.maskedTextSinifId);
            this.Controls.Add(this.maskedTextRezervasyonId);
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
            this.Name = "Form9";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sınıf Rezervasyon";
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
        private System.Windows.Forms.MaskedTextBox maskedTextRezervasyonId;
        private System.Windows.Forms.MaskedTextBox maskedTextSinifId;
        private System.Windows.Forms.MaskedTextBox maskedTextKisiId;
        private System.Windows.Forms.MaskedTextBox maskedTextBitisTarihi;
        private System.Windows.Forms.MaskedTextBox maskedTextBaslangicTarihi;
        private System.Windows.Forms.Button btnAra;
    }
}