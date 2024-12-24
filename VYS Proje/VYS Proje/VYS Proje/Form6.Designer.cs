namespace VYS_Proje
{
    partial class Form6
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
            this.maskedTextKisiId = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextOdemeId = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextOdemeTarihi = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextTutar = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextUyelikId = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAra = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(389, 217);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(225, 70);
            this.btnGuncelle.TabIndex = 33;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(389, 123);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(225, 70);
            this.btnSil.TabIndex = 32;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(389, 29);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(225, 70);
            this.btnEkle.TabIndex = 31;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 23);
            this.label1.TabIndex = 34;
            this.label1.Text = "Kişi ID :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 23);
            this.label2.TabIndex = 35;
            this.label2.Text = "Ödeme ID :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 23);
            this.label3.TabIndex = 36;
            this.label3.Text = "Tutar(TL) :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 23);
            this.label4.TabIndex = 37;
            this.label4.Text = "Ödeme Tarihi :";
            // 
            // maskedTextKisiId
            // 
            this.maskedTextKisiId.Location = new System.Drawing.Point(193, 150);
            this.maskedTextKisiId.Mask = "00000";
            this.maskedTextKisiId.Name = "maskedTextKisiId";
            this.maskedTextKisiId.Size = new System.Drawing.Size(125, 29);
            this.maskedTextKisiId.TabIndex = 38;
            this.maskedTextKisiId.ValidatingType = typeof(int);
            // 
            // maskedTextOdemeId
            // 
            this.maskedTextOdemeId.Location = new System.Drawing.Point(193, 50);
            this.maskedTextOdemeId.Mask = "00000";
            this.maskedTextOdemeId.Name = "maskedTextOdemeId";
            this.maskedTextOdemeId.Size = new System.Drawing.Size(125, 29);
            this.maskedTextOdemeId.TabIndex = 39;
            this.maskedTextOdemeId.ValidatingType = typeof(int);
            // 
            // maskedTextOdemeTarihi
            // 
            this.maskedTextOdemeTarihi.Location = new System.Drawing.Point(193, 250);
            this.maskedTextOdemeTarihi.Mask = "00/00/0000";
            this.maskedTextOdemeTarihi.Name = "maskedTextOdemeTarihi";
            this.maskedTextOdemeTarihi.Size = new System.Drawing.Size(125, 29);
            this.maskedTextOdemeTarihi.TabIndex = 40;
            this.maskedTextOdemeTarihi.ValidatingType = typeof(System.DateTime);
            // 
            // maskedTextTutar
            // 
            this.maskedTextTutar.Location = new System.Drawing.Point(193, 200);
            this.maskedTextTutar.Mask = "00000";
            this.maskedTextTutar.Name = "maskedTextTutar";
            this.maskedTextTutar.Size = new System.Drawing.Size(125, 29);
            this.maskedTextTutar.TabIndex = 41;
            this.maskedTextTutar.ValidatingType = typeof(int);
            // 
            // maskedTextUyelikId
            // 
            this.maskedTextUyelikId.Location = new System.Drawing.Point(193, 100);
            this.maskedTextUyelikId.Mask = "00000";
            this.maskedTextUyelikId.Name = "maskedTextUyelikId";
            this.maskedTextUyelikId.Size = new System.Drawing.Size(125, 29);
            this.maskedTextUyelikId.TabIndex = 43;
            this.maskedTextUyelikId.ValidatingType = typeof(int);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 42;
            this.label5.Text = "Üyelik ID :";
            // 
            // btnAra
            // 
            this.btnAra.Location = new System.Drawing.Point(389, 311);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(225, 70);
            this.btnAra.TabIndex = 57;
            this.btnAra.Text = "Ara";
            this.btnAra.UseVisualStyleBackColor = true;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(656, 416);
            this.Controls.Add(this.btnAra);
            this.Controls.Add(this.maskedTextUyelikId);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.maskedTextTutar);
            this.Controls.Add(this.maskedTextOdemeTarihi);
            this.Controls.Add(this.maskedTextOdemeId);
            this.Controls.Add(this.maskedTextKisiId);
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
            this.Name = "Form6";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ödeme";
            this.Load += new System.EventHandler(this.Form6_Load);
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
        private System.Windows.Forms.MaskedTextBox maskedTextKisiId;
        private System.Windows.Forms.MaskedTextBox maskedTextOdemeId;
        private System.Windows.Forms.MaskedTextBox maskedTextOdemeTarihi;
        private System.Windows.Forms.MaskedTextBox maskedTextTutar;
        private System.Windows.Forms.MaskedTextBox maskedTextUyelikId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAra;
    }
}