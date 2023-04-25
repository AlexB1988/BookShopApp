using BookShopApp.Interfaces;
using DevExpress.XtraEditors;
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
    public partial class AddCountBooksForm : DevExpress.XtraEditors.XtraForm
    {

        private readonly IGetBooksToChangeService _getBooksToChangeService;
        private readonly IRemoveUnchangedBooksService _removeUnchangedBooksService;
        public AddCountBooksForm(IGetBooksToChangeService getBooksToChangeService, IRemoveUnchangedBooksService removeUnchangedBooksService)
        {
            InitializeComponent();
            _getBooksToChangeService = getBooksToChangeService;
            _removeUnchangedBooksService = removeUnchangedBooksService;
        }

        private void AddCountBooksForm_Load(object sender, EventArgs e)
        {
            ChangeQuantityBooksGridControl.DataSource = _getBooksToChangeService.GetBooksToChange();
        }

        private void btnCancelChangeCountBooks_Click(object sender, EventArgs e)
        {
            _removeUnchangedBooksService.RemoveUnchangedBooks();
            this.Close();
        }
        private void AddCountBooksForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _removeUnchangedBooksService.RemoveUnchangedBooks();
        }

    }
}