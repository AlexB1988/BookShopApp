namespace BookShopApp
{
    partial class ChangePriceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePriceForm));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            this.btnCancelChangePrice = new System.Windows.Forms.Button();
            this.btnOkChangePrice = new System.Windows.Forms.Button();
            this.gridControlChangePrice = new DevExpress.XtraGrid.GridControl();
            this.bookBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1_1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBookQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrentPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPriceOfBooksToChange = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlChangePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1_1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelChangePrice
            // 
            this.btnCancelChangePrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelChangePrice.FlatAppearance.BorderSize = 0;
            this.btnCancelChangePrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelChangePrice.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelChangePrice.Image")));
            this.btnCancelChangePrice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelChangePrice.Location = new System.Drawing.Point(770, 12);
            this.btnCancelChangePrice.Name = "btnCancelChangePrice";
            this.btnCancelChangePrice.Size = new System.Drawing.Size(80, 23);
            this.btnCancelChangePrice.TabIndex = 0;
            this.btnCancelChangePrice.Text = "Отмена";
            this.btnCancelChangePrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelChangePrice.UseVisualStyleBackColor = true;
            this.btnCancelChangePrice.Click += new System.EventHandler(this.btnCancelChangePrice_Click);
            // 
            // btnOkChangePrice
            // 
            this.btnOkChangePrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOkChangePrice.FlatAppearance.BorderSize = 0;
            this.btnOkChangePrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOkChangePrice.Image = ((System.Drawing.Image)(resources.GetObject("btnOkChangePrice.Image")));
            this.btnOkChangePrice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOkChangePrice.Location = new System.Drawing.Point(665, 12);
            this.btnOkChangePrice.Name = "btnOkChangePrice";
            this.btnOkChangePrice.Size = new System.Drawing.Size(86, 23);
            this.btnOkChangePrice.TabIndex = 1;
            this.btnOkChangePrice.Text = "Изменить";
            this.btnOkChangePrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOkChangePrice.UseVisualStyleBackColor = true;
            this.btnOkChangePrice.Click += new System.EventHandler(this.btnOkChangePrice_Click);
            // 
            // gridControlChangePrice
            // 
            this.gridControlChangePrice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlChangePrice.DataSource = this.bookBindingSource;
            gridLevelNode2.RelationName = "Level1";
            this.gridControlChangePrice.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.gridControlChangePrice.Location = new System.Drawing.Point(-2, 57);
            this.gridControlChangePrice.MainView = this.gridView1_1;
            this.gridControlChangePrice.Name = "gridControlChangePrice";
            this.gridControlChangePrice.Size = new System.Drawing.Size(864, 336);
            this.gridControlChangePrice.TabIndex = 2;
            this.gridControlChangePrice.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1_1});
            // 
            // bookBindingSource
            // 
            this.bookBindingSource.DataSource = typeof(BookShopApp.Domain.Entities.Book);
            // 
            // gridView1_1
            // 
            this.gridView1_1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colBookQuantity,
            this.colCurrentPrice,
            this.colPriceOfBooksToChange});
            this.gridView1_1.GridControl = this.gridControlChangePrice;
            this.gridView1_1.Name = "gridView1_1";
            //this.gridView1_1.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gridView1_ValidatingEditor);
            //this.gridView1_1.InvalidValueException += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(this.gridView1_InvalidValueException);
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
            this.colCurrentPrice.Caption = "Текущая цена";
            this.colCurrentPrice.FieldName = "CurrentPrice.Price";
            this.colCurrentPrice.Name = "colCurrentPrice";
            this.colCurrentPrice.OptionsColumn.AllowEdit = false;
            this.colCurrentPrice.Visible = true;
            this.colCurrentPrice.VisibleIndex = 2;
            // 
            // colPriceOfBooksToChange
            // 
            this.colPriceOfBooksToChange.Caption = "Новая цена";
            this.colPriceOfBooksToChange.FieldName = "PriceOfBooksToChange";
            this.colPriceOfBooksToChange.Name = "colPriceOfBooksToChange";
            this.colPriceOfBooksToChange.Visible = true;
            this.colPriceOfBooksToChange.VisibleIndex = 3;
            // 
            // ChangePriceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 393);
            this.Controls.Add(this.gridControlChangePrice);
            this.Controls.Add(this.btnOkChangePrice);
            this.Controls.Add(this.btnCancelChangePrice);
            this.Name = "ChangePriceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Изменение цены";
            this.Load += new System.EventHandler(this.ChangePriceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlChangePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1_1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnCancelChangePrice;
        private Button btnOkChangePrice;
        private DevExpress.XtraGrid.GridControl gridControlChangePrice;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1_1;
        private BindingSource bookBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colBookQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colPriceOfBooksToChange;
    }
}