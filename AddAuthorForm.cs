using BookShopApp.Domain.Entities;
using BookShopApp.Domain.Repositories.Interfaces;
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
        IDataManager _dataManager;
        public BookShopForm _bookShopForm;
        public AddAuthorForm(IDataManager dataManager, BookShopForm bookShopForm)
        {
            _dataManager = dataManager;
            InitializeComponent();
            _bookShopForm = bookShopForm;
        }

        private void btnOkAddAuthor_Click(object sender, EventArgs e)
        {
            string name = textBoxAddAuthor.Text;
            var author = new Author
            {
                Name = name,
            };
            bool result = _dataManager.AddAuthor(author);
            this.Close();
            _bookShopForm.Enabled = true;
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
