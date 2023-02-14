namespace BookShopApp
{
    partial class ReportsForm
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
            this.btnAuthorBooks = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAuthorBooks
            // 
            this.btnAuthorBooks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnAuthorBooks.FlatAppearance.BorderSize = 0;
            this.btnAuthorBooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuthorBooks.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAuthorBooks.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnAuthorBooks.Location = new System.Drawing.Point(38, 21);
            this.btnAuthorBooks.MinimumSize = new System.Drawing.Size(91, 80);
            this.btnAuthorBooks.Name = "btnAuthorBooks";
            this.btnAuthorBooks.Size = new System.Drawing.Size(137, 80);
            this.btnAuthorBooks.TabIndex = 0;
            this.btnAuthorBooks.Text = "Список книг по автору";
            this.btnAuthorBooks.UseVisualStyleBackColor = false;
            this.btnAuthorBooks.Click += new System.EventHandler(this.btnAuthorBooks_Click);
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 332);
            this.Controls.Add(this.btnAuthorBooks);
            this.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Name = "ReportsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отчёты";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReportsForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnAuthorBooks;
    }
}