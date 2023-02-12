namespace BookShopApp
{
    partial class BookShopForm
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookShopForm));
            this.gridControlGetBookList = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPublisher = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrentPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBookQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsbn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.windowsuiButtonPanel1 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.btnBookList = new System.Windows.Forms.Button();
            this.btnAddPublisher = new System.Windows.Forms.Button();
            this.btnAddAuthor = new System.Windows.Forms.Button();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.btnCreatePurchase = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlGetBookList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlGetBookList
            // 
            this.gridControlGetBookList.DataSource = typeof(BookShopApp.Domain.Entities.Book);
            this.gridControlGetBookList.Dock = System.Windows.Forms.DockStyle.Bottom;
            gridLevelNode1.RelationName = "Level1";
            gridLevelNode2.RelationName = "Level2";
            this.gridControlGetBookList.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1,
            gridLevelNode2});
            this.gridControlGetBookList.Location = new System.Drawing.Point(0, 125);
            this.gridControlGetBookList.MainView = this.gridView1;
            this.gridControlGetBookList.Name = "gridControlGetBookList";
            this.gridControlGetBookList.Size = new System.Drawing.Size(884, 387);
            this.gridControlGetBookList.TabIndex = 0;
            this.gridControlGetBookList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colPublisher,
            this.colYear,
            this.colCurrentPrice,
            this.colBookQuantity,
            this.colIsbn});
            this.gridView1.GridControl = this.gridControlGetBookList;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            // 
            // colName
            // 
            this.colName.AccessibleName = "";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            // 
            // colPublisher
            // 
            this.colPublisher.FieldName = "Publisher.Name";
            this.colPublisher.Name = "colPublisher";
            this.colPublisher.OptionsColumn.AllowEdit = false;
            this.colPublisher.Visible = true;
            this.colPublisher.VisibleIndex = 2;
            // 
            // colYear
            // 
            this.colYear.FieldName = "Year";
            this.colYear.Name = "colYear";
            this.colYear.OptionsColumn.AllowEdit = false;
            this.colYear.Visible = true;
            this.colYear.VisibleIndex = 3;
            // 
            // colCurrentPrice
            // 
            this.colCurrentPrice.FieldName = "CurrentPrice.Price";
            this.colCurrentPrice.Name = "colCurrentPrice";
            this.colCurrentPrice.OptionsColumn.AllowEdit = false;
            this.colCurrentPrice.Visible = true;
            this.colCurrentPrice.VisibleIndex = 4;
            // 
            // colBookQuantity
            // 
            this.colBookQuantity.FieldName = "BookQuantity.Quantity";
            this.colBookQuantity.Name = "colBookQuantity";
            this.colBookQuantity.OptionsColumn.AllowEdit = false;
            this.colBookQuantity.Visible = true;
            this.colBookQuantity.VisibleIndex = 5;
            // 
            // colIsbn
            // 
            this.colIsbn.FieldName = "Isbn";
            this.colIsbn.Name = "colIsbn";
            this.colIsbn.OptionsColumn.AllowEdit = false;
            this.colIsbn.Visible = true;
            this.colIsbn.VisibleIndex = 6;
            // 
            // windowsuiButtonPanel1
            // 
            this.windowsuiButtonPanel1.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton(),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton()});
            this.windowsuiButtonPanel1.Location = new System.Drawing.Point(794, 111);
            this.windowsuiButtonPanel1.Name = "windowsuiButtonPanel1";
            this.windowsuiButtonPanel1.Size = new System.Drawing.Size(8, 8);
            this.windowsuiButtonPanel1.TabIndex = 1;
            this.windowsuiButtonPanel1.Text = "windowsuiButtonPanel1";
            // 
            // btnBookList
            // 
            this.btnBookList.FlatAppearance.BorderSize = 0;
            this.btnBookList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookList.Image = global::BookShopApp.Properties.Resources._301699_1_;
            this.btnBookList.Location = new System.Drawing.Point(12, -2);
            this.btnBookList.Name = "btnBookList";
            this.btnBookList.Size = new System.Drawing.Size(104, 99);
            this.btnBookList.TabIndex = 2;
            this.btnBookList.Text = "Список книг";
            this.btnBookList.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBookList.UseVisualStyleBackColor = true;
            this.btnBookList.Click += new System.EventHandler(this.btnBookList_Click);
            // 
            // btnAddPublisher
            // 
            this.btnAddPublisher.FlatAppearance.BorderSize = 0;
            this.btnAddPublisher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPublisher.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPublisher.Image")));
            this.btnAddPublisher.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddPublisher.Location = new System.Drawing.Point(122, 2);
            this.btnAddPublisher.Name = "btnAddPublisher";
            this.btnAddPublisher.Size = new System.Drawing.Size(133, 31);
            this.btnAddPublisher.TabIndex = 3;
            this.btnAddPublisher.Text = "Добавить издателя";
            this.btnAddPublisher.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddPublisher.UseVisualStyleBackColor = true;
            this.btnAddPublisher.Click += new System.EventHandler(this.btnAddPublisher_Click);
            // 
            // btnAddAuthor
            // 
            this.btnAddAuthor.FlatAppearance.BorderSize = 0;
            this.btnAddAuthor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAuthor.Image = ((System.Drawing.Image)(resources.GetObject("btnAddAuthor.Image")));
            this.btnAddAuthor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddAuthor.Location = new System.Drawing.Point(122, 36);
            this.btnAddAuthor.Name = "btnAddAuthor";
            this.btnAddAuthor.Size = new System.Drawing.Size(133, 31);
            this.btnAddAuthor.TabIndex = 4;
            this.btnAddAuthor.Text = "Добавить автора";
            this.btnAddAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddAuthor.UseVisualStyleBackColor = true;
            this.btnAddAuthor.Click += new System.EventHandler(this.btnAddAuthor_Click);
            // 
            // btnAddBook
            // 
            this.btnAddBook.FlatAppearance.BorderSize = 0;
            this.btnAddBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddBook.Image = ((System.Drawing.Image)(resources.GetObject("btnAddBook.Image")));
            this.btnAddBook.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddBook.Location = new System.Drawing.Point(122, 70);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(133, 31);
            this.btnAddBook.TabIndex = 5;
            this.btnAddBook.Text = "Добавить книгу";
            this.btnAddBook.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddBook.UseVisualStyleBackColor = true;
            this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);
            // 
            // btnCreatePurchase
            // 
            this.btnCreatePurchase.FlatAppearance.BorderSize = 0;
            this.btnCreatePurchase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreatePurchase.Image = ((System.Drawing.Image)(resources.GetObject("btnCreatePurchase.Image")));
            this.btnCreatePurchase.Location = new System.Drawing.Point(285, -2);
            this.btnCreatePurchase.Name = "btnCreatePurchase";
            this.btnCreatePurchase.Size = new System.Drawing.Size(119, 99);
            this.btnCreatePurchase.TabIndex = 6;
            this.btnCreatePurchase.Text = "Оформить покупку";
            this.btnCreatePurchase.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCreatePurchase.UseVisualStyleBackColor = true;
            this.btnCreatePurchase.Click += new System.EventHandler(this.btnCreatePurchase_Click);
            // 
            // BookShopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 512);
            this.Controls.Add(this.btnCreatePurchase);
            this.Controls.Add(this.btnAddBook);
            this.Controls.Add(this.btnAddAuthor);
            this.Controls.Add(this.btnAddPublisher);
            this.Controls.Add(this.btnBookList);
            this.Controls.Add(this.windowsuiButtonPanel1);
            this.Controls.Add(this.gridControlGetBookList);
            this.Name = "BookShopForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Книжный склад";
            this.Load += new System.EventHandler(this.BookShop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlGetBookList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlGetBookList;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel windowsuiButtonPanel1;
        private DevExpress.XtraGrid.GridControl gridGetBooks;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colPublisher;
        private DevExpress.XtraGrid.Columns.GridColumn colYear;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colBookQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colIsbn;
        private Button btnBookList;
        private Button btnAddPublisher;
        private Button btnAddAuthor;
        private Button btnAddBook;
        private Button btnCreatePurchase;
    }
}