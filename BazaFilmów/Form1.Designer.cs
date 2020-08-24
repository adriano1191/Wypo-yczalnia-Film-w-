namespace BazaFilmów
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonDodaj = new System.Windows.Forms.Button();
            this.buttonUsun = new System.Windows.Forms.Button();
            this.buttonEdutuj = new System.Windows.Forms.Button();
            this.buttonZamknij = new System.Windows.Forms.Button();
            this.buttonSzukaj = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.test3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aktorzyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bazaAktorówToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nowyAktorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelCount = new System.Windows.Forms.Label();
            this.textBoxSzukaj = new System.Windows.Forms.TextBox();
            this.raportBazyFilmowejToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.Size = new System.Drawing.Size(708, 250);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            // 
            // buttonDodaj
            // 
            this.buttonDodaj.Location = new System.Drawing.Point(26, 298);
            this.buttonDodaj.Name = "buttonDodaj";
            this.buttonDodaj.Size = new System.Drawing.Size(75, 23);
            this.buttonDodaj.TabIndex = 1;
            this.buttonDodaj.Text = "Dodaj";
            this.buttonDodaj.UseVisualStyleBackColor = true;
            this.buttonDodaj.Click += new System.EventHandler(this.buttonDodaj_Click);
            // 
            // buttonUsun
            // 
            this.buttonUsun.Location = new System.Drawing.Point(188, 298);
            this.buttonUsun.Name = "buttonUsun";
            this.buttonUsun.Size = new System.Drawing.Size(75, 23);
            this.buttonUsun.TabIndex = 2;
            this.buttonUsun.Text = "Usuń";
            this.buttonUsun.UseVisualStyleBackColor = true;
            this.buttonUsun.Click += new System.EventHandler(this.buttonUsun_Click);
            // 
            // buttonEdutuj
            // 
            this.buttonEdutuj.Location = new System.Drawing.Point(107, 298);
            this.buttonEdutuj.Name = "buttonEdutuj";
            this.buttonEdutuj.Size = new System.Drawing.Size(75, 23);
            this.buttonEdutuj.TabIndex = 3;
            this.buttonEdutuj.Text = "Edutuj";
            this.buttonEdutuj.UseVisualStyleBackColor = true;
            this.buttonEdutuj.Click += new System.EventHandler(this.buttonEdutuj_Click);
            // 
            // buttonZamknij
            // 
            this.buttonZamknij.Location = new System.Drawing.Point(636, 298);
            this.buttonZamknij.Name = "buttonZamknij";
            this.buttonZamknij.Size = new System.Drawing.Size(75, 23);
            this.buttonZamknij.TabIndex = 4;
            this.buttonZamknij.Text = "Zamknij";
            this.buttonZamknij.UseVisualStyleBackColor = true;
            this.buttonZamknij.Click += new System.EventHandler(this.buttonZamknij_Click);
            // 
            // buttonSzukaj
            // 
            this.buttonSzukaj.Location = new System.Drawing.Point(300, 298);
            this.buttonSzukaj.Name = "buttonSzukaj";
            this.buttonSzukaj.Size = new System.Drawing.Size(75, 23);
            this.buttonSzukaj.TabIndex = 5;
            this.buttonSzukaj.Text = "Szukaj";
            this.buttonSzukaj.UseVisualStyleBackColor = true;
            this.buttonSzukaj.Click += new System.EventHandler(this.buttonSzukaj_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.aktorzyToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(731, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem,
            this.test3ToolStripMenuItem});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.testToolStripMenuItem.Text = "Terminy";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // test3ToolStripMenuItem
            // 
            this.test3ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.raportBazyFilmowejToolStripMenuItem});
            this.test3ToolStripMenuItem.Name = "test3ToolStripMenuItem";
            this.test3ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.test3ToolStripMenuItem.Text = "Raport";
            // 
            // aktorzyToolStripMenuItem
            // 
            this.aktorzyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bazaAktorówToolStripMenuItem,
            this.nowyAktorToolStripMenuItem});
            this.aktorzyToolStripMenuItem.Name = "aktorzyToolStripMenuItem";
            this.aktorzyToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.aktorzyToolStripMenuItem.Text = "Aktorzy";
            // 
            // bazaAktorówToolStripMenuItem
            // 
            this.bazaAktorówToolStripMenuItem.Name = "bazaAktorówToolStripMenuItem";
            this.bazaAktorówToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.bazaAktorówToolStripMenuItem.Text = "Baza Aktorów";
            this.bazaAktorówToolStripMenuItem.Click += new System.EventHandler(this.bazaAktorówToolStripMenuItem_Click);
            // 
            // nowyAktorToolStripMenuItem
            // 
            this.nowyAktorToolStripMenuItem.Name = "nowyAktorToolStripMenuItem";
            this.nowyAktorToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.nowyAktorToolStripMenuItem.Text = "Dodaj Aktora";
            this.nowyAktorToolStripMenuItem.Click += new System.EventHandler(this.nowyAktorToolStripMenuItem_Click);
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(601, 304);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(35, 13);
            this.labelCount.TabIndex = 8;
            this.labelCount.Text = "Count";
            this.labelCount.Visible = false;
            // 
            // textBoxSzukaj
            // 
            this.textBoxSzukaj.Location = new System.Drawing.Point(381, 300);
            this.textBoxSzukaj.Name = "textBoxSzukaj";
            this.textBoxSzukaj.Size = new System.Drawing.Size(100, 20);
            this.textBoxSzukaj.TabIndex = 9;
            this.textBoxSzukaj.Text = "Szukaj";
            // 
            // raportBazyFilmowejToolStripMenuItem
            // 
            this.raportBazyFilmowejToolStripMenuItem.Name = "raportBazyFilmowejToolStripMenuItem";
            this.raportBazyFilmowejToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.raportBazyFilmowejToolStripMenuItem.Text = "Raport Bazy Filmowej";
            this.raportBazyFilmowejToolStripMenuItem.Click += new System.EventHandler(this.raportBazyFilmowejToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 361);
            this.Controls.Add(this.textBoxSzukaj);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.buttonSzukaj);
            this.Controls.Add(this.buttonZamknij);
            this.Controls.Add(this.buttonEdutuj);
            this.Controls.Add(this.buttonUsun);
            this.Controls.Add(this.buttonDodaj);
            this.Controls.Add(this.dataGridView1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Baza Filmów Lievego";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Click += new System.EventHandler(this.Form1_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDodaj;
        private System.Windows.Forms.Button buttonUsun;
        private System.Windows.Forms.Button buttonZamknij;
        private System.Windows.Forms.Button buttonSzukaj;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem test3ToolStripMenuItem;
        private System.Windows.Forms.Label labelCount;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBoxSzukaj;
        public System.Windows.Forms.Button buttonEdutuj;
        private System.Windows.Forms.ToolStripMenuItem aktorzyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bazaAktorówToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nowyAktorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem raportBazyFilmowejToolStripMenuItem;
    }
}

