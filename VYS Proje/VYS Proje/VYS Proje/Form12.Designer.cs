namespace VYS_Proje
{
    partial class Form12
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
            this.maskedTextKatilimId = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextKisiId = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextYarismaId = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextKatilimTarihi = new System.Windows.Forms.MaskedTextBox();
            this.btnAra = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(423, 225);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(225, 70);
            this.btnGuncelle.TabIndex = 51;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(423, 134);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(225, 70);
            this.btnSil.TabIndex = 50;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(423, 43);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(225, 70);
            this.btnEkle.TabIndex = 49;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 23);
            this.label1.TabIndex = 52;
            this.label1.Text = "Katılım ID :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 23);
            this.label2.TabIndex = 53;
            this.label2.Text = "Kişi ID :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 23);
            this.label3.TabIndex = 54;
            this.label3.Text = "Yarışma ID :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 23);
            this.label4.TabIndex = 55;
            this.label4.Text = "Katılım Tarihi :";
            // 
            // maskedTextKatilimId
            // 
            this.maskedTextKatilimId.Location = new System.Drawing.Point(225, 64);
            this.maskedTextKatilimId.Mask = "00000";
            this.maskedTextKatilimId.Name = "maskedTextKatilimId";
            this.maskedTextKatilimId.Size = new System.Drawing.Size(125, 29);
            this.maskedTextKatilimId.TabIndex = 56;
            this.maskedTextKatilimId.ValidatingType = typeof(int);
            // 
            // maskedTextKisiId
            // 
            this.maskedTextKisiId.Location = new System.Drawing.Point(225, 119);
            this.maskedTextKisiId.Mask = "00000";
            this.maskedTextKisiId.Name = "maskedTextKisiId";
            this.maskedTextKisiId.Size = new System.Drawing.Size(125, 29);
            this.maskedTextKisiId.TabIndex = 57;
            this.maskedTextKisiId.ValidatingType = typeof(int);
            // 
            // maskedTextYarismaId
            // 
            this.maskedTextYarismaId.Location = new System.Drawing.Point(225, 174);
            this.maskedTextYarismaId.Mask = "00000";
            this.maskedTextYarismaId.Name = "maskedTextYarismaId";
            this.maskedTextYarismaId.Size = new System.Drawing.Size(125, 29);
            this.maskedTextYarismaId.TabIndex = 58;
            this.maskedTextYarismaId.ValidatingType = typeof(int);
            // 
            // maskedTextKatilimTarihi
            // 
            this.maskedTextKatilimTarihi.Location = new System.Drawing.Point(225, 229);
            this.maskedTextKatilimTarihi.Mask = "00/00/0000";
            this.maskedTextKatilimTarihi.Name = "maskedTextKatilimTarihi";
            this.maskedTextKatilimTarihi.Size = new System.Drawing.Size(125, 29);
            this.maskedTextKatilimTarihi.TabIndex = 59;
            this.maskedTextKatilimTarihi.ValidatingType = typeof(System.DateTime);
            // 
            // btnAra
            // 
            this.btnAra.Location = new System.Drawing.Point(423, 316);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(225, 70);
            this.btnAra.TabIndex = 60;
            this.btnAra.Text = "Ara";
            this.btnAra.UseVisualStyleBackColor = true;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // Form12
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(685, 400);
            this.Controls.Add(this.btnAra);
            this.Controls.Add(this.maskedTextKatilimTarihi);
            this.Controls.Add(this.maskedTextYarismaId);
            this.Controls.Add(this.maskedTextKisiId);
            this.Controls.Add(this.maskedTextKatilimId);
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
            this.Name = "Form12";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yarışmaya Katılım";
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
        private System.Windows.Forms.MaskedTextBox maskedTextKatilimId;
        private System.Windows.Forms.MaskedTextBox maskedTextKisiId;
        private System.Windows.Forms.MaskedTextBox maskedTextYarismaId;
        private System.Windows.Forms.MaskedTextBox maskedTextKatilimTarihi;
        private System.Windows.Forms.Button btnAra;
    }
}