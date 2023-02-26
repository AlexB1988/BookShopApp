using BookShopApp.Autofac;
using BookShopApp.Domain.Entities;
using BookShopApp.Interfaces;
using BookShopApp.Validation;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using FluentValidation.Results;
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
        BookShopForm _bookShopForm;
        IGetAuthorsService _getAuthorsService;
        IGetPublishersService _getPublishersService;
        IAddBookService _addBookService;
        IGetPublisherByNameService _getPublisherByNameService;
        public AddBookForm(BookShopForm bookShopForm)
        {
            InitializeComponent();
            _bookShopForm = bookShopForm;
        }

        private void AddBookForm_Load(object sender, EventArgs e)
        {
            _getPublishersService = InstanceFactory.GetInstance<IGetPublishersService>();
            var publishers = _getPublishersService.GetPublishers();
            foreach (var publisher in publishers)
            {
                comboBoxAddBookPublisher.Properties.Items.Add(publisher.Name);
            }

            _getAuthorsService = InstanceFactory.GetInstance<IGetAuthorsService>();
            checkedComboBoxAddBookAuthors.Properties.DataSource = _getAuthorsService.GetAuthors();
            checkedComboBoxAddBookAuthors.Properties.ValueMember = "Id";
            checkedComboBoxAddBookAuthors.Properties.DisplayMember = "Name";
        }
        private void btnOkAddBook_Click(object sender, EventArgs e)
        {
            try
            {
                _addBookService = InstanceFactory.GetInstance<IAddBookService>();
                _getPublisherByNameService = InstanceFactory.GetInstance<IGetPublisherByNameService>();
                Book book = new Book();
                BookQuantity bookQuantity = new BookQuantity();
                BookPrice bookPrice = new BookPrice();
                if (comboBoxAddBookPublisher.SelectedItem is not null)
                {
                    var publisher = _getPublisherByNameService.GetPublisherByName(comboBoxAddBookPublisher.SelectedItem.ToString());
                    var newBook = new BookValid
                    {
                        Name = textBoxAddBookName.Text,
                        Year = textBoxAddBookYear.Text,
                        Isbn = textBoxAddBookIsbn.Text,
                        Quantity=textBoxAddBookQuantity.Text,
                        Price=textBoxAddBookPrice.Text,
                        AuthorListString = checkedComboBoxAddBookAuthors.Properties.GetCheckedItems()
                    };
                    if (newBook is not null)
                    {
                        var bookValidator = new BookValidator();
                        var results = bookValidator.Validate(newBook);
                        IList<ValidationFailure> failures = results.Errors;
                        if (!results.IsValid)
                        {
                            foreach (var failure in failures)
                            {
                                MessageBox.Show(failure.ErrorMessage, 
                                    "Сообщение", 
                                    MessageBoxButtons.OK, 
                                    MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else
                        {
                            book.Name = newBook.Name;
                            book.Year = int.Parse(newBook.Year);
                            book.Isbn = newBook.Isbn;
                            book.PublisherId = publisher.Id;
                            bookQuantity.Book = book;
                            bookQuantity.Quantity = int.Parse(newBook.Quantity);
                            bookPrice.Books = book;
                            bookPrice.Price = decimal.Parse(newBook.Price);
                            bookPrice.DateBegin = DateTime.UtcNow;
                            var authorList = newBook.AuthorListString.ToString().Split(",").ToList();
                            var result = _addBookService.AddBook(book, bookQuantity, bookPrice, authorList);

                            this.Close();
                            _bookShopForm.Enabled = true;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show(
                    $"Некорректные данные\n" +
                    $"Нужно выбрать издателя",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(
                $"{ex.Message}\n",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void btnAddPublisherInBookForm_Click(object sender, EventArgs e)
        {
            AddPublisherForm addPublisherForm = new AddPublisherForm(_bookShopForm);
            addPublisherForm.Show();
        }

        private void btnAddAuthorInBookForm_Click(object sender, EventArgs e)
        {
            AddAuthorForm addAuthorForm = new AddAuthorForm(_bookShopForm);
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