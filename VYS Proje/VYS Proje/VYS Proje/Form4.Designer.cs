namespace VYS_Proje
{
    partial class Form4
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.maskedTextBakimTarihi = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextEkipmanId = new System.Windows.Forms.MaskedTextBox();
            this.textEkipmanAdi = new System.Windows.Forms.TextBox();
            this.comboDurum = new System.Windows.Forms.ComboBox();
            this.btnAra = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(384, 208);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(225, 70);
            this.btnGuncelle.TabIndex = 27;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(384, 119);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(225, 70);
            this.btnSil.TabIndex = 26;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(384, 30);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(225, 70);
            this.btnEkle.TabIndex = 25;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 23);
            this.label2.TabIndex = 29;
            this.label2.Text = "Ekipman ID :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 23);
            this.label3.TabIndex = 30;
            this.label3.Text = "Ekipman Adı :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 23);
            this.label4.TabIndex = 31;
            this.label4.Text = "Bakım Tarihi :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 23);
            this.label5.TabIndex = 32;
            this.label5.Text = "Durum :";
            // 
            // maskedTextBakimTarihi
            // 
            this.maskedTextBakimTarihi.Location = new System.Drawing.Point(208, 161);
            this.maskedTextBakimTarihi.Mask = "00/00/0000";
            this.maskedTextBakimTarihi.Name = "maskedTextBakimTarihi";
            this.maskedTextBakimTarihi.Size = new System.Drawing.Size(125, 29);
            this.maskedTextBakimTarihi.TabIndex = 34;
            this.maskedTextBakimTarihi.ValidatingType = typeof(System.DateTime);
            // 
            // maskedTextEkipmanId
            // 
            this.maskedTextEkipmanId.Location = new System.Drawing.Point(208, 51);
            this.maskedTextEkipmanId.Mask = "00000";
            this.maskedTextEkipmanId.Name = "maskedTextEkipmanId";
            this.maskedTextEkipmanId.Size = new System.Drawing.Size(125, 29);
            this.maskedTextEkipmanId.TabIndex = 35;
            this.maskedTextEkipmanId.ValidatingType = typeof(int);
            // 
            // textEkipmanAdi
            // 
            this.textEkipmanAdi.Location = new System.Drawing.Point(208, 106);
            this.textEkipmanAdi.Name = "textEkipmanAdi";
            this.textEkipmanAdi.Size = new System.Drawing.Size(125, 29);
            this.textEkipmanAdi.TabIndex = 36;
            // 
            // comboDurum
            // 
            this.comboDurum.FormattingEnabled = true;
            this.comboDurum.Items.AddRange(new object[] {
            "Kullanılabilir",
            "Bakımda",
            "Bozuk"});
            this.comboDurum.Location = new System.Drawing.Point(208, 219);
            this.comboDurum.Name = "comboDurum";
            this.comboDurum.Size = new System.Drawing.Size(125, 31);
            this.comboDurum.TabIndex = 38;
            // 
            // btnAra
            // 
            this.btnAra.Location = new System.Drawing.Point(384, 297);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(225, 70);
            this.btnAra.TabIndex = 57;
            this.btnAra.Text = "Ara";
            this.btnAra.UseVisualStyleBackColor = true;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(655, 391);
            this.Controls.Add(this.btnAra);
            this.Controls.Add(this.comboDurum);
            this.Controls.Add(this.textEkipmanAdi);
            this.Controls.Add(this.maskedTextEkipmanId);
            this.Controls.Add(this.maskedTextBakimTarihi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnEkle);
            this.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ekipman";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox maskedTextBakimTarihi;
        private System.Windows.Forms.MaskedTextBox maskedTextEkipmanId;
        private System.Windows.Forms.TextBox textEkipmanAdi;
        private System.Windows.Forms.ComboBox comboDurum;
        private System.Windows.Forms.Button btnAra;
    }
}