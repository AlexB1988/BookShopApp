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
        public AddAuthorForm(IDataManager dataManager)
        {
            _dataManager= dataManager;
            InitializeComponent();
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
        }

        private void btnCancelAddAuthor_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddAuthorForm_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
