using BookShopApp.Domain.Repositories.Interfaces;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShopApp
{
    public partial class AddBookForm : DevExpress.XtraEditors.XtraForm
    {
        IDataManager _dataManager;
        BookShopForm _bookShopForm;
        public AddBookForm(IDataManager dataManager, BookShopForm bookShopForm)
        {
            _dataManager = dataManager;
            InitializeComponent();
            _bookShopForm = bookShopForm;
        }

        private void btnOkAddBook_Click(object sender, EventArgs e)
        {
            string bookName=textBoxAddBookName.Text;
            string bookYear = textBoxAddBookYear.Text;
            string bookIsbn = textBoxAddBookIsbn.Text;
            string bookQuantity=textBoxAddBookQuantity.Text;
            string bookPrice = textBoxAddBookPrice.Text;
            var selectedPublisher = comboBoxAddBookPublisher.SelectedItem.ToString();
            var authorListString=checkedComboBoxAddBookAuthors.Properties.GetCheckedItems();
            var authorList = authorListString.ToString().Split(",").ToList();
            _dataManager.AddBook(bookName,bookYear,bookIsbn,bookQuantity,bookPrice,selectedPublisher,authorList);
            this.Close();
            _bookShopForm.Enabled = true;
        }

        private void AddBookForm_Load(object sender, EventArgs e)
        {
            var publishers = _dataManager.GetPublishers();
            foreach (var publisher in publishers)
            {
                comboBoxAddBookPublisher.Properties.Items.Add(publisher.Name);
            }

            checkedComboBoxAddBookAuthors.Properties.DataSource = _dataManager.GetAuthors();
            checkedComboBoxAddBookAuthors.Properties.ValueMember = "Id";
            checkedComboBoxAddBookAuthors.Properties.DisplayMember = "Name";
        }

        private void btnAddPublisherInBookForm_Click(object sender, EventArgs e)
        {
            AddPublisherForm addPublisherForm = new AddPublisherForm(_dataManager,_bookShopForm);
            addPublisherForm.Show();
        }

        private void btnAddAuthorInBookForm_Click(object sender, EventArgs e)
        {
            AddAuthorForm addAuthorForm = new AddAuthorForm(_dataManager,_bookShopForm);
            addAuthorForm.Show();
        }

        private void btnCancelAddBook_Click(object sender, EventArgs e)
        {
            this.Close();
            _bookShopForm.Enabled = true;
        }

        private void AddBookForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _bookShopForm.Enabled = true;
        }
    }
}