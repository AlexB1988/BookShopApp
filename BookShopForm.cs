using BookShopApp.Domain.Repositories.Interfaces;
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
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookShopApp
{
    public partial class BookShopForm : DevExpress.XtraEditors.XtraForm
    {
        IDataManager _dataManager;
        public BookShopForm(IDataManager dataManager)
        {
            InitializeComponent();
            _dataManager = dataManager;
        }

        private void BookShop_Load(object sender, EventArgs e)
        {
            gridGetBookList.DataSource = _dataManager.GetBooks();
        }

        private void btnBookList_Click(object sender, EventArgs e)
        {
            gridGetBookList.DataSource = _dataManager.GetBooks();
        }

        private void btnAddPublisher_Click(object sender, EventArgs e)
        {
            AddPublisherForm addPublisherForm = new AddPublisherForm(_dataManager);
            addPublisherForm.Show();
        }

        private void btnAddAuthor_Click(object sender, EventArgs e)
        {
            AddAuthorForm addAuthorForm = new AddAuthorForm(_dataManager);
            addAuthorForm.Show();
        }
    }
}