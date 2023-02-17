using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShopApp
{
    public partial class ReportsForm : Form
    {
        BookShopForm _bookShopForm;
        public ReportsForm(BookShopForm booksShopForm)
        {
            _bookShopForm = booksShopForm;
            InitializeComponent();
        }

        private void btnAuthorBooks_Click(object sender, EventArgs e)
        {
            BooksOfAuthorReport booksOfAuthor = new BooksOfAuthorReport();
            booksOfAuthor.ShowPreview();
        }

        private void ReportsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _bookShopForm.Enabled=true;
        }

        private void btnPurchasesReport_Click(object sender, EventArgs e)
        {
            PurchaseBooksReport purchaseBooksReport = new PurchaseBooksReport();
            purchaseBooksReport.ShowPreview();
        }
    }
}
