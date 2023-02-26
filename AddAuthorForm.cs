using BookShopApp.Autofac;
using BookShopApp.Domain.Entities;
using BookShopApp.Interfaces;
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
    public partial class AddAuthorForm : Form
    {
        public BookShopForm _bookShopForm;
        IAddAuthorService _addAuthorService;
        public AddAuthorForm(BookShopForm bookShopForm)
        {
            InitializeComponent();
            _bookShopForm = bookShopForm;
            _addAuthorService= InstanceFactory.GetInstance<IAddAuthorService>();
        }

        private void btnOkAddAuthor_Click(object sender, EventArgs e)
        {
            bool result = _addAuthorService.AddAuthor(textBoxAddAuthor.Text);
            if (result)
            {
                this.Close();
                _bookShopForm.Enabled = true;
            }
        }

        private void btnCancelAddAuthor_Click(object sender, EventArgs e)
        {
            this.Close();
            _bookShopForm.Enabled = true;
        }

        private void AddAuthorForm_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void AddAuthorForm_Load(object sender, EventArgs e)
        {

        }

        private void AddAuthorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _bookShopForm.Enabled = true;
        }
    }
}
