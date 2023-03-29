using BookShopApp.Autofac;
using BookShopApp.Domain.Entities;
using BookShopApp.Interfaces;
using BookShopApp.Validation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.Xpo.Helpers.CannotLoadObjectsHelper;

namespace BookShopApp
{
    public partial class AddAuthorForm : Form
    {
        private readonly IAddAuthorService _addAuthorService;
        public AddAuthorForm(IAddAuthorService addAuthorService)
        {
            InitializeComponent();
            _addAuthorService = addAuthorService;
        }
        private void btnOkAddAuthor_Click(object sender, EventArgs e)
        {
            try
            {
                var author = new Author
                {
                    Name = textBoxAddAuthor.Text
                };
                var authorValidator = new AuthorValidator();
                var results = authorValidator.Validate(author);
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
                    bool result = _addAuthorService.AddAuthor(author);
                    if (result)
                    {
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                $"{ex.Message}\n",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
                return;
            }
        }

        private void btnCancelAddAuthor_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
