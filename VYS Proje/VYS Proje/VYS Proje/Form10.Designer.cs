namespace VYS_Proje
{
    partial class Form10
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
            this.maskedDegerlendirmeId = new System.Windows.Forms.MaskedTextBox();
            this.maskedEgitmenId = new System.Windows.Forms.MaskedTextBox();
            this.maskedKisiId = new System.Windows.Forms.MaskedTextBox();
            this.maskedSinifId = new System.Windows.Forms.MaskedTextBox();
            this.maskedTarih = new System.Windows.Forms.MaskedTextBox();
            this.maskedPuan = new System.Windows.Forms.MaskedTextBox();
            this.richTextYorum = new System.Windows.Forms.RichTextBox();
            this.btnAra = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(442, 234);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(225, 70);
            this.btnGuncelle.TabIndex = 45;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(442, 143);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(225, 70);
            this.btnSil.TabIndex = 44;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(442, 52);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(225, 70);
            this.btnEkle.TabIndex = 43;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 23);
            this.label1.TabIndex = 46;
            this.label1.Text = "Değerlendirme ID :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 23);
            this.label2.TabIndex = 47;
            this.label2.Text = "Puan :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 23);
            this.label3.TabIndex = 48;
            this.label3.Text = "Yorum :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 23);
            this.label4.TabIndex = 49;
            this.label4.Text = "Kişi ID :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 23);
            this.label5.TabIndex = 50;
            this.label5.Text = "Tarih :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(54, 303);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 23);
            this.label6.TabIndex = 51;
            this.label6.Text = "Eğitmen ID :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(54, 350);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 23);
            this.label7.TabIndex = 52;
            this.label7.Text = "Sınıf ID :";
            // 
            // maskedDegerlendirmeId
            // 
            this.maskedDegerlendirmeId.Location = new System.Drawing.Point(246, 65);
            this.maskedDegerlendirmeId.Mask = "00000";
            this.maskedDegerlendirmeId.Name = "maskedDegerlendirmeId";
            this.maskedDegerlendirmeId.Size = new System.Drawing.Size(125, 29);
            this.maskedDegerlendirmeId.TabIndex = 53;
            this.maskedDegerlendirmeId.ValidatingType = typeof(int);
            // 
            // maskedEgitmenId
            // 
            this.maskedEgitmenId.Location = new System.Drawing.Point(246, 300);
            this.maskedEgitmenId.Mask = "00000";
            this.maskedEgitmenId.Name = "maskedEgitmenId";
            this.maskedEgitmenId.Size = new System.Drawing.Size(125, 29);
            this.maskedEgitmenId.TabIndex = 54;
            this.maskedEgitmenId.ValidatingType = typeof(int);
            // 
            // maskedKisiId
            // 
            this.maskedKisiId.Location = new System.Drawing.Point(246, 253);
            this.maskedKisiId.Mask = "00000";
            this.maskedKisiId.Name = "maskedKisiId";
            this.maskedKisiId.Size = new System.Drawing.Size(125, 29);
            this.maskedKisiId.TabIndex = 55;
            this.maskedKisiId.ValidatingType = typeof(int);
            // 
            // maskedSinifId
            // 
            this.maskedSinifId.Location = new System.Drawing.Point(246, 347);
            this.maskedSinifId.Mask = "00000";
            this.maskedSinifId.Name = "maskedSinifId";
            this.maskedSinifId.Size = new System.Drawing.Size(125, 29);
            this.maskedSinifId.TabIndex = 56;
            this.maskedSinifId.ValidatingType = typeof(int);
            // 
            // maskedTarih
            // 
            this.maskedTarih.Location = new System.Drawing.Point(246, 206);
            this.maskedTarih.Mask = "00/00/0000";
            this.maskedTarih.Name = "maskedTarih";
            this.maskedTarih.Size = new System.Drawing.Size(125, 29);
            this.maskedTarih.TabIndex = 57;
            this.maskedTarih.ValidatingType = typeof(System.DateTime);
            // 
            // maskedPuan
            // 
            this.maskedPuan.Location = new System.Drawing.Point(246, 112);
            this.maskedPuan.Mask = "00";
            this.maskedPuan.Name = "maskedPuan";
            this.maskedPuan.Size = new System.Drawing.Size(125, 29);
            this.maskedPuan.TabIndex = 58;
            this.maskedPuan.ValidatingType = typeof(int);
            // 
            // richTextYorum
            // 
            this.richTextYorum.Location = new System.Drawing.Point(246, 159);
            this.richTextYorum.Name = "richTextYorum";
            this.richTextYorum.Size = new System.Drawing.Size(125, 29);
            this.richTextYorum.TabIndex = 59;
            this.richTextYorum.Text = "";
            // 
            // btnAra
            // 
            this.btnAra.Location = new System.Drawing.Point(442, 325);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(225, 70);
            this.btnAra.TabIndex = 60;
            this.btnAra.Text = "Ara";
            this.btnAra.UseVisualStyleBackColor = true;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // Form10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(707, 439);
            this.Controls.Add(this.btnAra);
            this.Controls.Add(this.richTextYorum);
            this.Controls.Add(this.maskedPuan);
            this.Controls.Add(this.maskedTarih);
            this.Controls.Add(this.maskedSinifId);
            this.Controls.Add(this.maskedKisiId);
            this.Controls.Add(this.maskedEgitmenId);
            this.Controls.Add(this.maskedDegerlendirmeId);
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
            this.Name = "Form10";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Değerlendirme";
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
        private System.Windows.Forms.MaskedTextBox maskedDegerlendirmeId;
        private System.Windows.Forms.MaskedTextBox maskedEgitmenId;
        private System.Windows.Forms.MaskedTextBox maskedKisiId;
        private System.Windows.Forms.MaskedTextBox maskedSinifId;
        private System.Windows.Forms.MaskedTextBox maskedTarih;
        private System.Windows.Forms.MaskedTextBox maskedPuan;
        private System.Windows.Forms.RichTextBox richTextYorum;
        private System.Windows.Forms.Button btnAra;
    }
}