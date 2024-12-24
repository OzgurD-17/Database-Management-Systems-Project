namespace VYS_Proje
{
    partial class Form18
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
            this.maskedTextSinifId = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.maskedTextSinifDersId = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.maskedTextDersId = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAra = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(353, 204);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(225, 70);
            this.btnGuncelle.TabIndex = 42;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(353, 114);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(225, 70);
            this.btnSil.TabIndex = 41;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(353, 24);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(225, 70);
            this.btnEkle.TabIndex = 40;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // maskedTextSinifId
            // 
            this.maskedTextSinifId.Location = new System.Drawing.Point(180, 161);
            this.maskedTextSinifId.Mask = "00000";
            this.maskedTextSinifId.Name = "maskedTextSinifId";
            this.maskedTextSinifId.Size = new System.Drawing.Size(125, 29);
            this.maskedTextSinifId.TabIndex = 47;
            this.maskedTextSinifId.ValidatingType = typeof(int);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 23);
            this.label1.TabIndex = 46;
            this.label1.Text = "Sınıf ID :";
            // 
            // maskedTextSinifDersId
            // 
            this.maskedTextSinifDersId.Location = new System.Drawing.Point(180, 45);
            this.maskedTextSinifDersId.Mask = "00000";
            this.maskedTextSinifDersId.Name = "maskedTextSinifDersId";
            this.maskedTextSinifDersId.Size = new System.Drawing.Size(125, 29);
            this.maskedTextSinifDersId.TabIndex = 49;
            this.maskedTextSinifDersId.ValidatingType = typeof(int);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 23);
            this.label2.TabIndex = 48;
            this.label2.Text = "SınıfDers ID :";
            // 
            // maskedTextDersId
            // 
            this.maskedTextDersId.Location = new System.Drawing.Point(180, 103);
            this.maskedTextDersId.Mask = "00000";
            this.maskedTextDersId.Name = "maskedTextDersId";
            this.maskedTextDersId.Size = new System.Drawing.Size(125, 29);
            this.maskedTextDersId.TabIndex = 51;
            this.maskedTextDersId.ValidatingType = typeof(int);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 23);
            this.label3.TabIndex = 50;
            this.label3.Text = "Ders ID :";
            // 
            // btnAra
            // 
            this.btnAra.Location = new System.Drawing.Point(353, 294);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(225, 70);
            this.btnAra.TabIndex = 57;
            this.btnAra.Text = "Ara";
            this.btnAra.UseVisualStyleBackColor = true;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // Form18
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(630, 387);
            this.Controls.Add(this.btnAra);
            this.Controls.Add(this.maskedTextDersId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.maskedTextSinifDersId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.maskedTextSinifId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnEkle);
            this.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "Form18";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sınıf Ders";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.MaskedTextBox maskedTextSinifId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox maskedTextSinifDersId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox maskedTextDersId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAra;
    }
}