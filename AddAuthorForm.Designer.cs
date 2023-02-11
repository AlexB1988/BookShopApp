namespace BookShopApp
{
    partial class AddAuthorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAuthorForm));
            this.textBoxAddAuthor = new System.Windows.Forms.TextBox();
            this.labelAddAuthor = new System.Windows.Forms.Label();
            this.btnOkAddAuthor = new System.Windows.Forms.Button();
            this.btnCancelAddAuthor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxAddAuthor
            // 
            this.textBoxAddAuthor.Location = new System.Drawing.Point(86, 24);
            this.textBoxAddAuthor.Name = "textBoxAddAuthor";
            this.textBoxAddAuthor.Size = new System.Drawing.Size(310, 23);
            this.textBoxAddAuthor.TabIndex = 0;
            // 
            // labelAddAuthor
            // 
            this.labelAddAuthor.AutoSize = true;
            this.labelAddAuthor.Location = new System.Drawing.Point(2, 27);
            this.labelAddAuthor.Name = "labelAddAuthor";
            this.labelAddAuthor.Size = new System.Drawing.Size(37, 15);
            this.labelAddAuthor.TabIndex = 1;
            this.labelAddAuthor.Text = "Имя: ";
            // 
            // btnOkAddAuthor
            // 
            this.btnOkAddAuthor.FlatAppearance.BorderSize = 0;
            this.btnOkAddAuthor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOkAddAuthor.Image = ((System.Drawing.Image)(resources.GetObject("btnOkAddAuthor.Image")));
            this.btnOkAddAuthor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOkAddAuthor.Location = new System.Drawing.Point(219, 63);
            this.btnOkAddAuthor.Name = "btnOkAddAuthor";
            this.btnOkAddAuthor.Size = new System.Drawing.Size(92, 23);
            this.btnOkAddAuthor.TabIndex = 2;
            this.btnOkAddAuthor.Text = "Сохранить";
            this.btnOkAddAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOkAddAuthor.UseVisualStyleBackColor = true;
            this.btnOkAddAuthor.Click += new System.EventHandler(this.btnOkAddAuthor_Click);
            // 
            // btnCancelAddAuthor
            // 
            this.btnCancelAddAuthor.FlatAppearance.BorderSize = 0;
            this.btnCancelAddAuthor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelAddAuthor.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelAddAuthor.Image")));
            this.btnCancelAddAuthor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelAddAuthor.Location = new System.Drawing.Point(317, 63);
            this.btnCancelAddAuthor.Name = "btnCancelAddAuthor";
            this.btnCancelAddAuthor.Size = new System.Drawing.Size(79, 23);
            this.btnCancelAddAuthor.TabIndex = 3;
            this.btnCancelAddAuthor.Text = "Отмена";
            this.btnCancelAddAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelAddAuthor.UseVisualStyleBackColor = true;
            this.btnCancelAddAuthor.Click += new System.EventHandler(this.btnCancelAddAuthor_Click);
            // 
            // AddAuthorForm
            // 
            this.AcceptButton = this.btnOkAddAuthor;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 98);
            this.Controls.Add(this.btnCancelAddAuthor);
            this.Controls.Add(this.btnOkAddAuthor);
            this.Controls.Add(this.labelAddAuthor);
            this.Controls.Add(this.textBoxAddAuthor);
            this.Name = "AddAuthorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление автора";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AddAuthorForm_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBoxAddAuthor;
        private Label labelAddAuthor;
        private Button btnOkAddAuthor;
        private Button btnCancelAddAuthor;
    }
}