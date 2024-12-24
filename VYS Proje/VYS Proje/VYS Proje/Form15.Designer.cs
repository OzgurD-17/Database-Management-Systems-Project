namespace VYS_Proje
{
    partial class Form15
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
            this.maskedTextFiyat = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textPaketAdi = new System.Windows.Forms.TextBox();
            this.maskedTextPaketId = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.maskedTextSure = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAra = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(403, 218);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(225, 70);
            this.btnGuncelle.TabIndex = 33;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(403, 127);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(225, 70);
            this.btnSil.TabIndex = 32;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(403, 36);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(225, 70);
            this.btnEkle.TabIndex = 31;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // maskedTextFiyat
            // 
            this.maskedTextFiyat.Location = new System.Drawing.Point(205, 210);
            this.maskedTextFiyat.Mask = "00000";
            this.maskedTextFiyat.Name = "maskedTextFiyat";
            this.maskedTextFiyat.Size = new System.Drawing.Size(125, 29);
            this.maskedTextFiyat.TabIndex = 45;
            this.maskedTextFiyat.ValidatingType = typeof(int);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 23);
            this.label5.TabIndex = 44;
            this.label5.Text = "Fiyat(TL) :";
            // 
            // textPaketAdi
            // 
            this.textPaketAdi.Location = new System.Drawing.Point(205, 109);
            this.textPaketAdi.Name = "textPaketAdi";
            this.textPaketAdi.Size = new System.Drawing.Size(125, 29);
            this.textPaketAdi.TabIndex = 51;
            // 
            // maskedTextPaketId
            // 
            this.maskedTextPaketId.Location = new System.Drawing.Point(205, 57);
            this.maskedTextPaketId.Mask = "00000";
            this.maskedTextPaketId.Name = "maskedTextPaketId";
            this.maskedTextPaketId.Size = new System.Drawing.Size(125, 29);
            this.maskedTextPaketId.TabIndex = 50;
            this.maskedTextPaketId.ValidatingType = typeof(int);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 23);
            this.label3.TabIndex = 49;
            this.label3.Text = "Paket Adı :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 23);
            this.label2.TabIndex = 48;
            this.label2.Text = "Paket ID :";
            // 
            // maskedTextSure
            // 
            this.maskedTextSure.Location = new System.Drawing.Point(205, 161);
            this.maskedTextSure.Mask = "00";
            this.maskedTextSure.Name = "maskedTextSure";
            this.maskedTextSure.Size = new System.Drawing.Size(125, 29);
            this.maskedTextSure.TabIndex = 53;
            this.maskedTextSure.ValidatingType = typeof(int);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 23);
            this.label4.TabIndex = 52;
            this.label4.Text = "Süre(Ay)  :";
            // 
            // btnAra
            // 
            this.btnAra.Location = new System.Drawing.Point(403, 309);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(225, 70);
            this.btnAra.TabIndex = 57;
            this.btnAra.Text = "Ara";
            this.btnAra.UseVisualStyleBackColor = true;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // Form15
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(687, 408);
            this.Controls.Add(this.btnAra);
            this.Controls.Add(this.maskedTextSure);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textPaketAdi);
            this.Controls.Add(this.maskedTextPaketId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.maskedTextFiyat);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnEkle);
            this.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "Form15";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Üyelik Paketi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.MaskedTextBox maskedTextFiyat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textPaketAdi;
        private System.Windows.Forms.MaskedTextBox maskedTextPaketId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox maskedTextSure;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAra;
    }
}