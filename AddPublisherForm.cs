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
    public partial class AddPublisherForm : Form
    {
        public IDataManager _dataManager;
        public AddPublisherForm(IDataManager dataManager)
        {
            _dataManager = dataManager;
            InitializeComponent();
        }

        private void btnOkAddPublisher_Click(object sender, EventArgs e)
        {
            string name=textBoxAddPublisher.Text;
            var publisher = new Publisher
            {
                Name = name,
            };
            bool result =_dataManager.AddPublisher(publisher);
            this.Close();
        }

        private void AddPublisherForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelAddPublisher_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddPublisherForm_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
