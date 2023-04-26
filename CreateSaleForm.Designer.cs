namespace BookShopApp
{
    partial class CreateSaleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateSaleForm));
            this.gridControlPurchaseBook = new DevExpress.XtraGrid.GridControl();
            this.GetBookListView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBookQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrentPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCountBooksToSell = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.authorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnOkPuchaseBook = new System.Windows.Forms.Button();
            this.btnCancelPurchaseBook = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPurchaseBook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GetBookListView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.authorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlPurchaseBook
            // 
            this.gridControlPurchaseBook.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlPurchaseBook.DataSource = typeof(BookShopApp.Domain.Entities.Book);
            this.gridControlPurchaseBook.Location = new System.Drawing.Point(0, 56);
            this.gridControlPurchaseBook.MainView = this.GetBookListView;
            this.gridControlPurchaseBook.Name = "gridControlPurchaseBook";
            this.gridControlPurchaseBook.Size = new System.Drawing.Size(862, 337);
            this.gridControlPurchaseBook.TabIndex = 0;
            this.gridControlPurchaseBook.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GetBookListView,
            this.gridView2});
            // 
            // GetBookListView
            // 
            this.GetBookListView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colCurrentPrice,
            this.colBookQuantity,
            this.colCountBooksToSell});
            this.GetBookListView.GridControl = this.gridControlPurchaseBook;
            this.GetBookListView.Name = "GetBookListView";
            // 
            // colName
            // 
            this.colName.Caption = "Наименование книги";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            // 
            // colBookQuantity
            // 
            this.colBookQuantity.Caption = "Кол-во на складе";
            this.colBookQuantity.FieldName = "BookQuantity.Quantity";
            this.colBookQuantity.Name = "colBookQuantity";
            this.colBookQuantity.OptionsColumn.AllowEdit = false;
            this.colBookQuantity.Visible = true;
            this.colBookQuantity.VisibleIndex = 1;
            // 
            // colCurrentPrice
            // 
            this.colCurrentPrice.Caption = "Цена";
            this.colCurrentPrice.FieldName = "CurrentPrice.Price";
            this.colCurrentPrice.Name = "colCurrentPrice";
            this.colCurrentPrice.OptionsColumn.AllowEdit = false;
            this.colCurrentPrice.Visible = true;
            this.colCurrentPrice.VisibleIndex = 2;
            // 
            // colCountBooksToSell
            // 
            this.colCountBooksToSell.Caption = "Кол-во книг для покупки";
            this.colCountBooksToSell.FieldName = "CountBooksToSell";
            this.colCountBooksToSell.Name = "colCountBooksToSell";
            this.colCountBooksToSell.Visible = true;
            this.colCountBooksToSell.VisibleIndex = 3;
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridView2.GridControl = this.gridControlPurchaseBook;
            this.gridView2.Name = "gridView2";
            // 
            // gridColumn1
            // 
            this.gridColumn1.FieldName = "Name";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.FieldName = "BookQuantity.Quantity";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.FieldName = "CurrentPrice.Price";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // authorBindingSource
            // 
            this.authorBindingSource.DataSource = typeof(BookShopApp.Domain.Entities.Author);
            // 
            // btnOkPuchaseBook
            // 
            this.btnOkPuchaseBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnCancelPurchaseBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            // CreateSaleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 393);
            this.Controls.Add(this.btnCancelPurchaseBook);
            this.Controls.Add(this.btnOkPuchaseBook);
            this.Controls.Add(this.gridControlPurchaseBook);
            this.Name = "CreateSaleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Оформить покупку";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreateSaleForm_FormClosing);
            this.Load += new System.EventHandler(this.CreatePurchaseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPurchaseBook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GetBookListView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.authorBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlPurchaseBook;
        private DevExpress.XtraGrid.Views.Grid.GridView GetBookListView;
        private Button btnOkPuchaseBook;
        private Button btnCancelPurchaseBook;
        private BindingSource authorBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colBookQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentPrice;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn colCountBooksToSell;
    }
}