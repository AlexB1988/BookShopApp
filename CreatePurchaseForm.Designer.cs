namespace BookShopApp
{
    partial class CreatePurchaseForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreatePurchaseForm));
            this.gridControlPurchaseBook = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBookQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrentPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.authorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnOkPuchaseBook = new System.Windows.Forms.Button();
            this.btnCancelPurchaseBook = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPurchaseBook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.authorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlPurchaseBook
            // 
            this.gridControlPurchaseBook.DataSource = typeof(BookShopApp.Domain.Entities.Book);
            this.gridControlPurchaseBook.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridControlPurchaseBook.Location = new System.Drawing.Point(0, 56);
            this.gridControlPurchaseBook.MainView = this.gridView1;
            this.gridControlPurchaseBook.Name = "gridControlPurchaseBook";
            this.gridControlPurchaseBook.Size = new System.Drawing.Size(862, 337);
            this.gridControlPurchaseBook.TabIndex = 0;
            this.gridControlPurchaseBook.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colBookQuantity,
            this.colCurrentPrice});
            this.gridView1.GridControl = this.gridControlPurchaseBook;
            this.gridView1.Name = "gridView1";
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            // 
            // colBookQuantity
            // 
            this.colBookQuantity.FieldName = "BookQuantity.Quantity";
            this.colBookQuantity.Name = "colBookQuantity";
            this.colBookQuantity.Visible = true;
            this.colBookQuantity.VisibleIndex = 1;
            // 
            // colCurrentPrice
            // 
            this.colCurrentPrice.FieldName = "CurrentPrice.Price";
            this.colCurrentPrice.Name = "colCurrentPrice";
            this.colCurrentPrice.Visible = true;
            this.colCurrentPrice.VisibleIndex = 2;
            // 
            // authorBindingSource
            // 
            this.authorBindingSource.DataSource = typeof(BookShopApp.Domain.Entities.Author);
            // 
            // btnOkPuchaseBook
            // 
            this.btnOkPuchaseBook.FlatAppearance.BorderSize = 0;
            this.btnOkPuchaseBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOkPuchaseBook.Image = ((System.Drawing.Image)(resources.GetObject("btnOkPuchaseBook.Image")));
            this.btnOkPuchaseBook.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOkPuchaseBook.Location = new System.Drawing.Point(640, 12);
            this.btnOkPuchaseBook.Name = "btnOkPuchaseBook";
            this.btnOkPuchaseBook.Size = new System.Drawing.Size(111, 23);
            this.btnOkPuchaseBook.TabIndex = 1;
            this.btnOkPuchaseBook.Text = "Оформить чек";
            this.btnOkPuchaseBook.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOkPuchaseBook.UseVisualStyleBackColor = true;
            this.btnOkPuchaseBook.Click += new System.EventHandler(this.btnOkPuchaseBook_Click);
            // 
            // btnCancelPurchaseBook
            // 
            this.btnCancelPurchaseBook.FlatAppearance.BorderSize = 0;
            this.btnCancelPurchaseBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelPurchaseBook.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelPurchaseBook.Image")));
            this.btnCancelPurchaseBook.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelPurchaseBook.Location = new System.Drawing.Point(770, 12);
            this.btnCancelPurchaseBook.Name = "btnCancelPurchaseBook";
            this.btnCancelPurchaseBook.Size = new System.Drawing.Size(80, 23);
            this.btnCancelPurchaseBook.TabIndex = 2;
            this.btnCancelPurchaseBook.Text = "Отмена";
            this.btnCancelPurchaseBook.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelPurchaseBook.UseVisualStyleBackColor = true;
            this.btnCancelPurchaseBook.Click += new System.EventHandler(this.btnCancelPurchaseBook_Click);
            // 
            // CreatePurchaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 393);
            this.Controls.Add(this.btnCancelPurchaseBook);
            this.Controls.Add(this.btnOkPuchaseBook);
            this.Controls.Add(this.gridControlPurchaseBook);
            this.Name = "CreatePurchaseForm";
            this.Text = "Оформить покупку";
            this.Load += new System.EventHandler(this.CreatePurchaseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPurchaseBook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.authorBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlPurchaseBook;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private Button btnOkPuchaseBook;
        private Button btnCancelPurchaseBook;
        private BindingSource authorBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colBookQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentPrice;
    }
}