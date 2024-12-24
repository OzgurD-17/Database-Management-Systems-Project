namespace VYS_Proje
{
    partial class Form19
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
            this.label1 = new System.Windows.Forms.Label();
            this.maskedTextKullanimTarihi = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.maskedTextUyeEkipmanId = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.maskedTextEkipmanId = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAra = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(387, 214);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(225, 70);
            this.btnGuncelle.TabIndex = 45;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(387, 124);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(225, 70);
            this.btnSil.TabIndex = 44;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(387, 34);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(225, 70);
            this.btnEkle.TabIndex = 43;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // maskedTextKisiId
            // 
            this.maskedTextKisiId.Location = new System.Drawing.Point(217, 104);
            this.maskedTextKisiId.Mask = "00000";
            this.maskedTextKisiId.Name = "maskedTextKisiId";
            this.maskedTextKisiId.Size = new System.Drawing.Size(125, 29);
            this.maskedTextKisiId.TabIndex = 47;
            this.maskedTextKisiId.ValidatingType = typeof(int);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 23);
            this.label1.TabIndex = 46;
            this.label1.Text = "Kişi ID :";
            // 
            // maskedTextKullanimTarihi
            // 
            this.maskedTextKullanimTarihi.Location = new System.Drawing.Point(217, 202);
            this.maskedTextKullanimTarihi.Mask = "00/00/0000";
            this.maskedTextKullanimTarihi.Name = "maskedTextKullanimTarihi";
            this.maskedTextKullanimTarihi.Size = new System.Drawing.Size(125, 29);
            this.maskedTextKullanimTarihi.TabIndex = 49;
            this.maskedTextKullanimTarihi.ValidatingType = typeof(System.DateTime);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 23);
            this.label6.TabIndex = 48;
            this.label6.Text = "Kullanım Tarihi :";
            // 
            // maskedTextUyeEkipmanId
            // 
            this.maskedTextUyeEkipmanId.Location = new System.Drawing.Point(217, 55);
            this.maskedTextUyeEkipmanId.Mask = "00000";
            this.maskedTextUyeEkipmanId.Name = "maskedTextUyeEkipmanId";
            this.maskedTextUyeEkipmanId.Size = new System.Drawing.Size(125, 29);
            this.maskedTextUyeEkipmanId.TabIndex = 51;
            this.maskedTextUyeEkipmanId.ValidatingType = typeof(int);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 23);
            this.label2.TabIndex = 50;
            this.label2.Text = "ÜyeEkipman ID :";
            // 
            // maskedTextEkipmanId
            // 
            this.maskedTextEkipmanId.Location = new System.Drawing.Point(217, 153);
            this.maskedTextEkipmanId.Mask = "00000";
            this.maskedTextEkipmanId.Name = "maskedTextEkipmanId";
            this.maskedTextEkipmanId.Size = new System.Drawing.Size(125, 29);
            this.maskedTextEkipmanId.TabIndex = 53;
            this.maskedTextEkipmanId.ValidatingType = typeof(int);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 23);
            this.label3.TabIndex = 52;
            this.label3.Text = "Ekipman ID :";
            // 
            // btnAra
            // 
            this.btnAra.Location = new System.Drawing.Point(387, 304);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(225, 70);
            this.btnAra.TabIndex = 57;
            this.btnAra.Text = "Ara";
            this.btnAra.UseVisualStyleBackColor = true;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // Form19
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(668, 387);
            this.Controls.Add(this.btnAra);
            this.Controls.Add(this.maskedTextEkipmanId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.maskedTextUyeEkipmanId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.maskedTextKullanimTarihi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.maskedTextKisiId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnEkle);
            this.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "Form19";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Üye Ekipman";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.MaskedTextBox maskedTextKisiId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox maskedTextKullanimTarihi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox maskedTextUyeEkipmanId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox maskedTextEkipmanId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAra;
    }
}