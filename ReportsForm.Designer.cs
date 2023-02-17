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
            this.btnAuthorBooksReport = new System.Windows.Forms.Button();
            this.btnPurchasesReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAuthorBooksReport
            // 
            this.btnAuthorBooksReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnAuthorBooksReport.FlatAppearance.BorderSize = 0;
            this.btnAuthorBooksReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuthorBooksReport.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAuthorBooksReport.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnAuthorBooksReport.Location = new System.Drawing.Point(38, 21);
            this.btnAuthorBooksReport.MinimumSize = new System.Drawing.Size(91, 80);
            this.btnAuthorBooksReport.Name = "btnAuthorBooksReport";
            this.btnAuthorBooksReport.Size = new System.Drawing.Size(137, 80);
            this.btnAuthorBooksReport.TabIndex = 0;
            this.btnAuthorBooksReport.Text = "Список книг по автору";
            this.btnAuthorBooksReport.UseVisualStyleBackColor = false;
            this.btnAuthorBooksReport.Click += new System.EventHandler(this.btnAuthorBooks_Click);
            // 
            // btnPurchasesReport
            // 
            this.btnPurchasesReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnPurchasesReport.FlatAppearance.BorderSize = 0;
            this.btnPurchasesReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPurchasesReport.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPurchasesReport.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnPurchasesReport.Location = new System.Drawing.Point(204, 21);
            this.btnPurchasesReport.Name = "btnPurchasesReport";
            this.btnPurchasesReport.Size = new System.Drawing.Size(137, 80);
            this.btnPurchasesReport.TabIndex = 1;
            this.btnPurchasesReport.Text = "Отчёт по продажам";
            this.btnPurchasesReport.UseVisualStyleBackColor = false;
            this.btnPurchasesReport.Click += new System.EventHandler(this.btnPurchasesReport_Click);
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 332);
            this.Controls.Add(this.btnPurchasesReport);
            this.Controls.Add(this.btnAuthorBooksReport);
            this.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Name = "ReportsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отчёты";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReportsForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnAuthorBooksReport;
        private Button btnPurchasesReport;
    }
}