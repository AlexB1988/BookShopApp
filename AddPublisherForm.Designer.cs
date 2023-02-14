namespace BookShopApp
{
    partial class AddPublisherForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPublisherForm));
            this.textBoxAddPublisher = new System.Windows.Forms.TextBox();
            this.labelAddPublisher = new System.Windows.Forms.Label();
            this.btnOkAddPublisher = new System.Windows.Forms.Button();
            this.btnCancelAddPublisher = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxAddPublisher
            // 
            this.textBoxAddPublisher.Location = new System.Drawing.Point(86, 24);
            this.textBoxAddPublisher.Name = "textBoxAddPublisher";
            this.textBoxAddPublisher.Size = new System.Drawing.Size(310, 23);
            this.textBoxAddPublisher.TabIndex = 0;
            // 
            // labelAddPublisher
            // 
            this.labelAddPublisher.AutoSize = true;
            this.labelAddPublisher.Location = new System.Drawing.Point(2, 27);
            this.labelAddPublisher.Name = "labelAddPublisher";
            this.labelAddPublisher.Size = new System.Drawing.Size(84, 15);
            this.labelAddPublisher.TabIndex = 1;
            this.labelAddPublisher.Text = "Издательство:";
            // 
            // btnOkAddPublisher
            // 
            this.btnOkAddPublisher.FlatAppearance.BorderSize = 0;
            this.btnOkAddPublisher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOkAddPublisher.Image = ((System.Drawing.Image)(resources.GetObject("btnOkAddPublisher.Image")));
            this.btnOkAddPublisher.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOkAddPublisher.Location = new System.Drawing.Point(219, 63);
            this.btnOkAddPublisher.Name = "btnOkAddPublisher";
            this.btnOkAddPublisher.Size = new System.Drawing.Size(92, 23);
            this.btnOkAddPublisher.TabIndex = 2;
            this.btnOkAddPublisher.Text = "Сохранить";
            this.btnOkAddPublisher.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOkAddPublisher.UseVisualStyleBackColor = true;
            this.btnOkAddPublisher.Click += new System.EventHandler(this.btnOkAddPublisher_Click);
            // 
            // btnCancelAddPublisher
            // 
            this.btnCancelAddPublisher.FlatAppearance.BorderSize = 0;
            this.btnCancelAddPublisher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelAddPublisher.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelAddPublisher.Image")));
            this.btnCancelAddPublisher.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelAddPublisher.Location = new System.Drawing.Point(317, 63);
            this.btnCancelAddPublisher.Name = "btnCancelAddPublisher";
            this.btnCancelAddPublisher.Size = new System.Drawing.Size(79, 23);
            this.btnCancelAddPublisher.TabIndex = 3;
            this.btnCancelAddPublisher.Text = "Отмена";
            this.btnCancelAddPublisher.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelAddPublisher.UseVisualStyleBackColor = true;
            this.btnCancelAddPublisher.Click += new System.EventHandler(this.btnCancelAddPublisher_Click);
            // 
            // AddPublisherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 98);
            this.Controls.Add(this.btnCancelAddPublisher);
            this.Controls.Add(this.btnOkAddPublisher);
            this.Controls.Add(this.labelAddPublisher);
            this.Controls.Add(this.textBoxAddPublisher);
            this.KeyPreview = true;
            this.Name = "AddPublisherForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление издательства";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddPublisherForm_FormClosed);
            this.Load += new System.EventHandler(this.AddPublisherForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AddPublisherForm_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBoxAddPublisher;
        private Label labelAddPublisher;
        private Button btnOkAddPublisher;
        private Button btnCancelAddPublisher;
    }
}