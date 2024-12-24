namespace VYS_Proje
{
    partial class Form16
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
            this.maskedTextKisiId = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextSinifId = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.maskedTextDersId = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.maskedTextYoklamaId = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.maskedTextTarih = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.radioKatildi = new System.Windows.Forms.RadioButton();
            this.radioKatilmadi = new System.Windows.Forms.RadioButton();
            this.btnAra = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(425, 227);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(225, 70);
            this.btnGuncelle.TabIndex = 36;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(425, 139);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(225, 70);
            this.btnSil.TabIndex = 35;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(425, 51);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(225, 70);
            this.btnEkle.TabIndex = 34;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // maskedTextKisiId
            // 
            this.maskedTextKisiId.Location = new System.Drawing.Point(193, 118);
            this.maskedTextKisiId.Mask = "00000";
            this.maskedTextKisiId.Name = "maskedTextKisiId";
            this.maskedTextKisiId.Size = new System.Drawing.Size(125, 29);
            this.maskedTextKisiId.TabIndex = 54;
            this.maskedTextKisiId.ValidatingType = typeof(int);
            // 
            // maskedTextSinifId
            // 
            this.maskedTextSinifId.Location = new System.Drawing.Point(193, 176);
            this.maskedTextSinifId.Mask = "00000";
            this.maskedTextSinifId.Name = "maskedTextSinifId";
            this.maskedTextSinifId.Size = new System.Drawing.Size(125, 29);
            this.maskedTextSinifId.TabIndex = 53;
            this.maskedTextSinifId.ValidatingType = typeof(int);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 23);
            this.label5.TabIndex = 52;
            this.label5.Text = "Sınıf ID :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 23);
            this.label4.TabIndex = 51;
            this.label4.Text = "Kişi ID :";
            // 
            // maskedTextDersId
            // 
            this.maskedTextDersId.Location = new System.Drawing.Point(193, 234);
            this.maskedTextDersId.Mask = "00000";
            this.maskedTextDersId.Name = "maskedTextDersId";
            this.maskedTextDersId.Size = new System.Drawing.Size(125, 29);
            this.maskedTextDersId.TabIndex = 56;
            this.maskedTextDersId.ValidatingType = typeof(int);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 237);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 23);
            this.label1.TabIndex = 55;
            this.label1.Text = "Ders ID :";
            // 
            // maskedTextYoklamaId
            // 
            this.maskedTextYoklamaId.Location = new System.Drawing.Point(193, 63);
            this.maskedTextYoklamaId.Mask = "00000";
            this.maskedTextYoklamaId.Name = "maskedTextYoklamaId";
            this.maskedTextYoklamaId.Size = new System.Drawing.Size(125, 29);
            this.maskedTextYoklamaId.TabIndex = 58;
            this.maskedTextYoklamaId.ValidatingType = typeof(int);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 23);
            this.label2.TabIndex = 57;
            this.label2.Text = "Yoklama ID :";
            // 
            // maskedTextTarih
            // 
            this.maskedTextTarih.Location = new System.Drawing.Point(193, 292);
            this.maskedTextTarih.Mask = "00/00/0000";
            this.maskedTextTarih.Name = "maskedTextTarih";
            this.maskedTextTarih.Size = new System.Drawing.Size(125, 29);
            this.maskedTextTarih.TabIndex = 60;
            this.maskedTextTarih.ValidatingType = typeof(System.DateTime);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 295);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 23);
            this.label3.TabIndex = 59;
            this.label3.Text = "Tarih :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(54, 353);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 23);
            this.label6.TabIndex = 61;
            this.label6.Text = "Katılım :";
            // 
            // radioKatildi
            // 
            this.radioKatildi.AutoSize = true;
            this.radioKatildi.Location = new System.Drawing.Point(172, 353);
            this.radioKatildi.Name = "radioKatildi";
            this.radioKatildi.Size = new System.Drawing.Size(86, 27);
            this.radioKatildi.TabIndex = 62;
            this.radioKatildi.TabStop = true;
            this.radioKatildi.Text = "Katıldı";
            this.radioKatildi.UseVisualStyleBackColor = true;
            // 
            // radioKatilmadi
            // 
            this.radioKatilmadi.AutoSize = true;
            this.radioKatilmadi.Location = new System.Drawing.Point(278, 353);
            this.radioKatilmadi.Name = "radioKatilmadi";
            this.radioKatilmadi.Size = new System.Drawing.Size(113, 27);
            this.radioKatilmadi.TabIndex = 63;
            this.radioKatilmadi.TabStop = true;
            this.radioKatilmadi.Text = "Katılmadı";
            this.radioKatilmadi.UseVisualStyleBackColor = true;
            // 
            // btnAra
            // 
            this.btnAra.Location = new System.Drawing.Point(425, 315);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(225, 70);
            this.btnAra.TabIndex = 64;
            this.btnAra.Text = "Ara";
            this.btnAra.UseVisualStyleBackColor = true;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // Form16
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(697, 423);
            this.Controls.Add(this.btnAra);
            this.Controls.Add(this.radioKatilmadi);
            this.Controls.Add(this.radioKatildi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.maskedTextTarih);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.maskedTextYoklamaId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.maskedTextDersId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maskedTextKisiId);
            this.Controls.Add(this.maskedTextSinifId);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnEkle);
            this.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form16";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yoklama";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.MaskedTextBox maskedTextKisiId;
        private System.Windows.Forms.MaskedTextBox maskedTextSinifId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox maskedTextDersId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox maskedTextYoklamaId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox maskedTextTarih;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radioKatildi;
        private System.Windows.Forms.RadioButton radioKatilmadi;
        private System.Windows.Forms.Button btnAra;
    }
}