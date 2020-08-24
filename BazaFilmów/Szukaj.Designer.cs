namespace BazaFilmów
{
    partial class Szukaj
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
            this.textBoxTytul = new System.Windows.Forms.TextBox();
            this.textBoxRezyser = new System.Windows.Forms.TextBox();
            this.textBoxRok = new System.Windows.Forms.TextBox();
            this.textBoxGatunek = new System.Windows.Forms.TextBox();
            this.buttonSzukaj = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxTytul
            // 
            this.textBoxTytul.Location = new System.Drawing.Point(172, 12);
            this.textBoxTytul.Name = "textBoxTytul";
            this.textBoxTytul.Size = new System.Drawing.Size(100, 20);
            this.textBoxTytul.TabIndex = 0;
            // 
            // textBoxRezyser
            // 
            this.textBoxRezyser.Location = new System.Drawing.Point(172, 38);
            this.textBoxRezyser.Name = "textBoxRezyser";
            this.textBoxRezyser.Size = new System.Drawing.Size(100, 20);
            this.textBoxRezyser.TabIndex = 1;
            // 
            // textBoxRok
            // 
            this.textBoxRok.Location = new System.Drawing.Point(172, 90);
            this.textBoxRok.Name = "textBoxRok";
            this.textBoxRok.Size = new System.Drawing.Size(100, 20);
            this.textBoxRok.TabIndex = 3;
            // 
            // textBoxGatunek
            // 
            this.textBoxGatunek.Location = new System.Drawing.Point(172, 64);
            this.textBoxGatunek.Name = "textBoxGatunek";
            this.textBoxGatunek.Size = new System.Drawing.Size(100, 20);
            this.textBoxGatunek.TabIndex = 2;
            // 
            // buttonSzukaj
            // 
            this.buttonSzukaj.Location = new System.Drawing.Point(12, 187);
            this.buttonSzukaj.Name = "buttonSzukaj";
            this.buttonSzukaj.Size = new System.Drawing.Size(75, 23);
            this.buttonSzukaj.TabIndex = 4;
            this.buttonSzukaj.Text = "Szukaj";
            this.buttonSzukaj.UseVisualStyleBackColor = true;
            this.buttonSzukaj.Click += new System.EventHandler(this.buttonSzukaj_Click);
            // 
            // Szukaj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.buttonSzukaj);
            this.Controls.Add(this.textBoxRok);
            this.Controls.Add(this.textBoxGatunek);
            this.Controls.Add(this.textBoxRezyser);
            this.Controls.Add(this.textBoxTytul);
            this.Name = "Szukaj";
            this.Text = "Szukaj";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTytul;
        private System.Windows.Forms.TextBox textBoxRezyser;
        private System.Windows.Forms.TextBox textBoxRok;
        private System.Windows.Forms.TextBox textBoxGatunek;
        private System.Windows.Forms.Button buttonSzukaj;
    }
}