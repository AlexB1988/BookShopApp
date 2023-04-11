using Autofac;
using Autofac.Features.OwnedInstances;
using BookShopApp.Autofac;
using BookShopApp.Domain.Entities;
using BookShopApp.Interfaces;
using BookShopApp.Logging;
using BookShopApp.Validation;
using DevExpress.Office.Services;
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
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShopApp
{
    public partial class AddBookForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly IGetAuthorsService _getAuthorsService;
        private readonly IGetPublishersService _getPublishersService;
        private readonly IAddBookService _addBookService;
        private readonly IGetPublisherByNameService _getPublisherByNameService;
        private readonly ILifetimeScope _lifetimeScope;
        private readonly ILoggerService<AddBookForm> _loggerService;
        public AddBookForm(IGetAuthorsService getAuthorsService, IGetPublishersService getPublishersService, IAddBookService addBookService, IGetPublisherByNameService getPublisherByNameService, ILifetimeScope lifetimeScope, ILoggerService<AddBookForm> loggerService)
        {
            InitializeComponent();
            _getAuthorsService = getAuthorsService;
            _getPublishersService = getPublishersService;
            _addBookService = addBookService;
            _getPublisherByNameService = getPublisherByNameService;
            _lifetimeScope = lifetimeScope;
            _loggerService = loggerService;
        }

        private void AddBookForm_Load(object sender, EventArgs e)
        {
            var publishers = _getPublishersService.GetPublishers();
            foreach (var publisher in publishers)
            {
                comboBoxAddBookPublisher.Properties.Items.Add(publisher.Name);
            }

            checkedComboBoxAddBookAuthors.Properties.DataSource = _getAuthorsService.GetAuthors();
            checkedComboBoxAddBookAuthors.Properties.ValueMember = "Id";
            checkedComboBoxAddBookAuthors.Properties.DisplayMember = "Name";
        }
        private void btnOkAddBook_Click(object sender, EventArgs e)
        {
            try
            {
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
                            var book = new Book
                            {
                                Name = newBook.Name,
                                Year = int.Parse(newBook.Year),
                                Isbn = newBook.Isbn,
                                PublisherId = publisher.Id
                            };

                            var bookQuantity = new BookQuantity
                            {
                                Book = book,
                                Quantity = int.Parse(newBook.Quantity)
                            };

                            var bookPrice = new BookPrice
                            {
                                Books = book,
                                Price = decimal.Parse(newBook.Price),
                                DateBegin = DateTime.UtcNow
                            };
                            var authorList = newBook.AuthorListString.ToString().Split(",").ToList();
                            var result = _addBookService.AddBook(book, bookQuantity, bookPrice, authorList);

                            this.Close();
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
                _loggerService.Error(ex);
                MessageBox.Show(
                $"{ex.Message}\n",
                $"{ex.GetType()}",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void btnAddPublisherInBookForm_Click(object sender, EventArgs e)
        {
            using(var form = _lifetimeScope.Resolve<Owned<AddPublisherForm>>())
            {
                form.Value.ShowDialog();
                var publishers = _getPublishersService.GetPublishers();
                foreach (var publisher in publishers)
                {
                    comboBoxAddBookPublisher.Properties.Items.Add(publisher.Name);
                }
            }
        }

        private void btnAddAuthorInBookForm_Click(object sender, EventArgs e)
        {
            using(var form =_lifetimeScope.Resolve<Owned<AddAuthorForm>>())
            {
                form.Value.ShowDialog();
                checkedComboBoxAddBookAuthors.Properties.DataSource = _getAuthorsService.GetAuthors();
                checkedComboBoxAddBookAuthors.Properties.ValueMember = "Id";
                checkedComboBoxAddBookAuthors.Properties.DisplayMember = "Name";
            }
        }

        private void btnCancelAddBook_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}