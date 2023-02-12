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
using System.Windows.Controls;
using BookShopApp.Domain.Repositories.Interfaces;

namespace BookShopApp
{
    public partial class CreatePurchaseForm : DevExpress.XtraEditors.XtraForm
    {
        IDataManager _dataManager;
        List<object> _selectedBooksList;
        public CreatePurchaseForm(IDataManager dataManager,List<object> list)
        {
            _dataManager= dataManager;
            _selectedBooksList = list;
            InitializeComponent();
        }
        private void CreatePurchaseForm_Load(object sender, EventArgs e)
        {
            var selectedBooks=_dataManager.GetPurchasedBooks(_selectedBooksList);
            gridControlPurchaseBook.DataSource = selectedBooks;
        }
        private void btnOkPuchaseBook_Click(object sender, EventArgs e)
        {
            //GridView gridViewPurchaseBook = gridControlPurchaseBook.MainView as GridView;
            ////var  getAllPurchases=
        }

        private void btnCancelPurchaseBook_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}