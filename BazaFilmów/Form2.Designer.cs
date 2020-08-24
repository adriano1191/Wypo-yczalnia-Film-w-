namespace BazaFilmów
{
    partial class Terminy
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
            this.buttonZwrot = new System.Windows.Forms.Button();
            this.textBoxIle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(543, 237);
            this.dataGridView1.TabIndex = 0;
            // 
            // buttonZwrot
            // 
            this.buttonZwrot.Location = new System.Drawing.Point(12, 255);
            this.buttonZwrot.Name = "buttonZwrot";
            this.buttonZwrot.Size = new System.Drawing.Size(75, 23);
            this.buttonZwrot.TabIndex = 1;
            this.buttonZwrot.Text = "Zwrot";
            this.buttonZwrot.UseVisualStyleBackColor = true;
            this.buttonZwrot.Click += new System.EventHandler(this.buttonZwrot_Click);
            // 
            // textBoxIle
            // 
            this.textBoxIle.Location = new System.Drawing.Point(93, 258);
            this.textBoxIle.Name = "textBoxIle";
            this.textBoxIle.Size = new System.Drawing.Size(40, 20);
            this.textBoxIle.TabIndex = 2;
            this.textBoxIle.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(172, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // Terminy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 287);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxIle);
            this.Controls.Add(this.buttonZwrot);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Terminy";
            this.Text = "Terminy";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonZwrot;
        private System.Windows.Forms.TextBox textBoxIle;
        private System.Windows.Forms.Label label1;
    }
}