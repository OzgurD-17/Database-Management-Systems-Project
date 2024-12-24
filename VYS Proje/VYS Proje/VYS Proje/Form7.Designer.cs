namespace VYS_Proje
{
    partial class Form7
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
            this.maskedTextDersId = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBaslangicSaati = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBitisSaati = new System.Windows.Forms.MaskedTextBox();
            this.textDersAdi = new System.Windows.Forms.TextBox();
            this.btnAra = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(410, 229);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(225, 70);
            this.btnGuncelle.TabIndex = 36;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(410, 137);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(225, 70);
            this.btnSil.TabIndex = 35;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(410, 45);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(225, 70);
            this.btnEkle.TabIndex = 34;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 23);
            this.label1.TabIndex = 37;
            this.label1.Text = "Ders ID :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 23);
            this.label2.TabIndex = 38;
            this.label2.Text = "Ders Adı :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 23);
            this.label3.TabIndex = 39;
            this.label3.Text = "Başlangıç Saati :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 23);
            this.label4.TabIndex = 40;
            this.label4.Text = "Bitiş Saati :";
            // 
            // maskedTextDersId
            // 
            this.maskedTextDersId.Location = new System.Drawing.Point(212, 66);
            this.maskedTextDersId.Mask = "00000";
            this.maskedTextDersId.Name = "maskedTextDersId";
            this.maskedTextDersId.Size = new System.Drawing.Size(125, 29);
            this.maskedTextDersId.TabIndex = 42;
            this.maskedTextDersId.ValidatingType = typeof(int);
            // 
            // maskedTextBaslangicSaati
            // 
            this.maskedTextBaslangicSaati.Location = new System.Drawing.Point(212, 174);
            this.maskedTextBaslangicSaati.Mask = "00:00";
            this.maskedTextBaslangicSaati.Name = "maskedTextBaslangicSaati";
            this.maskedTextBaslangicSaati.Size = new System.Drawing.Size(125, 29);
            this.maskedTextBaslangicSaati.TabIndex = 43;
            this.maskedTextBaslangicSaati.ValidatingType = typeof(System.DateTime);
            // 
            // maskedTextBitisSaati
            // 
            this.maskedTextBitisSaati.Location = new System.Drawing.Point(212, 228);
            this.maskedTextBitisSaati.Mask = "00:00";
            this.maskedTextBitisSaati.Name = "maskedTextBitisSaati";
            this.maskedTextBitisSaati.Size = new System.Drawing.Size(125, 29);
            this.maskedTextBitisSaati.TabIndex = 44;
            this.maskedTextBitisSaati.ValidatingType = typeof(System.DateTime);
            // 
            // textDersAdi
            // 
            this.textDersAdi.Location = new System.Drawing.Point(212, 120);
            this.textDersAdi.Name = "textDersAdi";
            this.textDersAdi.Size = new System.Drawing.Size(125, 29);
            this.textDersAdi.TabIndex = 45;
            // 
            // btnAra
            // 
            this.btnAra.Location = new System.Drawing.Point(410, 321);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(225, 70);
            this.btnAra.TabIndex = 57;
            this.btnAra.Text = "Ara";
            this.btnAra.UseVisualStyleBackColor = true;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(676, 419);
            this.Controls.Add(this.btnAra);
            this.Controls.Add(this.textDersAdi);
            this.Controls.Add(this.maskedTextBitisSaati);
            this.Controls.Add(this.maskedTextBaslangicSaati);
            this.Controls.Add(this.maskedTextDersId);
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
            this.Name = "Form7";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ders";
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
        private System.Windows.Forms.MaskedTextBox maskedTextDersId;
        private System.Windows.Forms.MaskedTextBox maskedTextBaslangicSaati;
        private System.Windows.Forms.MaskedTextBox maskedTextBitisSaati;
        private System.Windows.Forms.TextBox textDersAdi;
        private System.Windows.Forms.Button btnAra;
    }
}