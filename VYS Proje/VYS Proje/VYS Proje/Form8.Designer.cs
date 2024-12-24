namespace VYS_Proje
{
    partial class Form8
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
            this.maskedTextSinifId = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextEgitmenId = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextKapasite = new System.Windows.Forms.MaskedTextBox();
            this.textSinifAdi = new System.Windows.Forms.TextBox();
            this.btnAra = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(391, 224);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(225, 70);
            this.btnGuncelle.TabIndex = 39;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(391, 133);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(225, 70);
            this.btnSil.TabIndex = 38;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(391, 42);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(225, 70);
            this.btnEkle.TabIndex = 37;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 23);
            this.label1.TabIndex = 40;
            this.label1.Text = "Sınıf ID :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 23);
            this.label2.TabIndex = 41;
            this.label2.Text = "Sınıf Adı :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 23);
            this.label3.TabIndex = 42;
            this.label3.Text = "Kapasite :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 23);
            this.label4.TabIndex = 43;
            this.label4.Text = "Eğitmen ID :";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // maskedTextSinifId
            // 
            this.maskedTextSinifId.Location = new System.Drawing.Point(190, 59);
            this.maskedTextSinifId.Mask = "00000";
            this.maskedTextSinifId.Name = "maskedTextSinifId";
            this.maskedTextSinifId.Size = new System.Drawing.Size(125, 29);
            this.maskedTextSinifId.TabIndex = 45;
            this.maskedTextSinifId.ValidatingType = typeof(int);
            // 
            // maskedTextEgitmenId
            // 
            this.maskedTextEgitmenId.Location = new System.Drawing.Point(190, 248);
            this.maskedTextEgitmenId.Mask = "00000";
            this.maskedTextEgitmenId.Name = "maskedTextEgitmenId";
            this.maskedTextEgitmenId.Size = new System.Drawing.Size(125, 29);
            this.maskedTextEgitmenId.TabIndex = 46;
            this.maskedTextEgitmenId.ValidatingType = typeof(int);
            // 
            // maskedTextKapasite
            // 
            this.maskedTextKapasite.Location = new System.Drawing.Point(190, 185);
            this.maskedTextKapasite.Mask = "000";
            this.maskedTextKapasite.Name = "maskedTextKapasite";
            this.maskedTextKapasite.Size = new System.Drawing.Size(125, 29);
            this.maskedTextKapasite.TabIndex = 48;
            this.maskedTextKapasite.ValidatingType = typeof(int);
            // 
            // textSinifAdi
            // 
            this.textSinifAdi.Location = new System.Drawing.Point(190, 122);
            this.textSinifAdi.Name = "textSinifAdi";
            this.textSinifAdi.Size = new System.Drawing.Size(125, 29);
            this.textSinifAdi.TabIndex = 49;
            // 
            // btnAra
            // 
            this.btnAra.Location = new System.Drawing.Point(391, 315);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(225, 70);
            this.btnAra.TabIndex = 57;
            this.btnAra.Text = "Ara";
            this.btnAra.UseVisualStyleBackColor = true;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(661, 412);
            this.Controls.Add(this.btnAra);
            this.Controls.Add(this.textSinifAdi);
            this.Controls.Add(this.maskedTextKapasite);
            this.Controls.Add(this.maskedTextEgitmenId);
            this.Controls.Add(this.maskedTextSinifId);
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
            this.Name = "Form8";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sınıf";
            this.Load += new System.EventHandler(this.Form8_Load);
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
        private System.Windows.Forms.MaskedTextBox maskedTextSinifId;
        private System.Windows.Forms.MaskedTextBox maskedTextEgitmenId;
        private System.Windows.Forms.MaskedTextBox maskedTextKapasite;
        private System.Windows.Forms.TextBox textSinifAdi;
        private System.Windows.Forms.Button btnAra;
    }
}