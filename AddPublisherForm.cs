using BookShopApp.Autofac;
using BookShopApp.Domain.Entities;
using BookShopApp.Interfaces;
using BookShopApp.Services;
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

namespace BookShopApp
{
    public partial class AddPublisherForm : Form
    {
        public BookShopForm _bookShopForm;
        IAddPublisherService _addPublisherService;
        public AddPublisherForm(BookShopForm bookShopForm)
        {
            InitializeComponent();
            _bookShopForm= bookShopForm;
            _addPublisherService= InstanceFactory.GetInstance<IAddPublisherService>();
        }

        private void btnOkAddPublisher_Click(object sender, EventArgs e)
        {
            try
            {
                var publisher = new Publisher
                {
                    Name = textBoxAddPublisher.Text
                };
                var publisherValidator = new PublisherValidator();
                var results = publisherValidator.Validate(publisher);
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
                    bool result = _addPublisherService.AddPublisher(publisher);
                    if (result)
                    {
                        this.Close();
                        _bookShopForm.Enabled = true;
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

        private void AddPublisherForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelAddPublisher_Click(object sender, EventArgs e)
        {
            this.Close();
            _bookShopForm.Enabled = true;
        }

        private void AddPublisherForm_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void AddPublisherForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _bookShopForm.Enabled = true;
        }
    }
}
