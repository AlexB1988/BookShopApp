namespace BookShopApp
{
    partial class AddCountBooksForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCountBooksForm));
            this.ChangeQuantityBooksGridControl = new DevExpress.XtraGrid.GridControl();
            this.bookBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GetBookListView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrentPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBookQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCountBooksToSell = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnOkChangeCountBooks = new System.Windows.Forms.Button();
            this.btnCancelChangeCountBooks = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ChangeQuantityBooksGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GetBookListView)).BeginInit();
            this.SuspendLayout();
            // 
            // ChangeQuantityBooksGridControl
            // 
            this.ChangeQuantityBooksGridControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChangeQuantityBooksGridControl.DataSource = this.bookBindingSource;
            this.ChangeQuantityBooksGridControl.Location = new System.Drawing.Point(-2, 57);
            this.ChangeQuantityBooksGridControl.MainView = this.GetBookListView;
            this.ChangeQuantityBooksGridControl.Name = "ChangeQuantityBooksGridControl";
            this.ChangeQuantityBooksGridControl.Size = new System.Drawing.Size(864, 336);
            this.ChangeQuantityBooksGridControl.TabIndex = 2;
            this.ChangeQuantityBooksGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GetBookListView});
            // 
            // bookBindingSource
            // 
            this.bookBindingSource.DataSource = typeof(BookShopApp.Domain.Entities.Book);
            // 
            // GetBookListView
            // 
            this.GetBookListView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colCurrentPrice,
            this.colBookQuantity,
            this.colCountBooksToSell});
            this.GetBookListView.GridControl = this.ChangeQuantityBooksGridControl;
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
            // colCurrentPrice
            // 
            this.colCurrentPrice.Caption = "Текущая цена";
            this.colCurrentPrice.FieldName = "CurrentPrice.Price";
            this.colCurrentPrice.Name = "colCurrentPrice";
            this.colCurrentPrice.OptionsColumn.AllowEdit = false;
            this.colCurrentPrice.Visible = true;
            this.colCurrentPrice.VisibleIndex = 1;
            // 
            // colBookQuantity
            // 
            this.colBookQuantity.Caption = "Кол-во на складе";
            this.colBookQuantity.FieldName = "BookQuantity.Quantity";
            this.colBookQuantity.Name = "colBookQuantity";
            this.colBookQuantity.OptionsColumn.AllowEdit = false;
            this.colBookQuantity.Visible = true;
            this.colBookQuantity.VisibleIndex = 2;
            // 
            // colCountBooksToSell
            // 
            this.colCountBooksToSell.Caption = "Приход";
            this.colCountBooksToSell.FieldName = "CountBooksToSell";
            this.colCountBooksToSell.Name = "colCountBooksToSell";
            this.colCountBooksToSell.Visible = true;
            this.colCountBooksToSell.VisibleIndex = 3;
            // 
            // btnOkChangeCountBooks
            // 
            this.btnOkChangeCountBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOkChangeCountBooks.FlatAppearance.BorderSize = 0;
            this.btnOkChangeCountBooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOkChangeCountBooks.Image = ((System.Drawing.Image)(resources.GetObject("btnOkChangeCountBooks.Image")));
            this.btnOkChangeCountBooks.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOkChangeCountBooks.Location = new System.Drawing.Point(665, 12);
            this.btnOkChangeCountBooks.Name = "btnOkChangeCountBooks";
            this.btnOkChangeCountBooks.Size = new System.Drawing.Size(86, 23);
            this.btnOkChangeCountBooks.TabIndex = 3;
            this.btnOkChangeCountBooks.Text = "Изменить";
            this.btnOkChangeCountBooks.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOkChangeCountBooks.UseVisualStyleBackColor = true;
            // 
            // btnCancelChangeCountBooks
            // 
            this.btnCancelChangeCountBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelChangeCountBooks.FlatAppearance.BorderSize = 0;
            this.btnCancelChangeCountBooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelChangeCountBooks.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelChangeCountBooks.Image")));
            this.btnCancelChangeCountBooks.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelChangeCountBooks.Location = new System.Drawing.Point(770, 12);
            this.btnCancelChangeCountBooks.Name = "btnCancelChangeCountBooks";
            this.btnCancelChangeCountBooks.Size = new System.Drawing.Size(80, 23);
            this.btnCancelChangeCountBooks.TabIndex = 4;
            this.btnCancelChangeCountBooks.Text = "Отмена";
            this.btnCancelChangeCountBooks.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelChangeCountBooks.UseVisualStyleBackColor = true;
            this.btnCancelChangeCountBooks.Click += new System.EventHandler(this.btnCancelChangeCountBooks_Click);
            // 
            // AddCountBooksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 393);
            this.Controls.Add(this.btnCancelChangeCountBooks);
            this.Controls.Add(this.btnOkChangeCountBooks);
            this.Controls.Add(this.ChangeQuantityBooksGridControl);
            this.Name = "AddCountBooksForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление кол-ва книг";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddCountBooksForm_FormClosing);
            this.Load += new System.EventHandler(this.AddCountBooksForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ChangeQuantityBooksGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GetBookListView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl ChangeQuantityBooksGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView GetBookListView;
        private BindingSource bookBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colBookQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colCountBooksToSell;
        private Button btnOkChangeCountBooks;
        private Button btnCancelChangeCountBooks;
    }
}