using BookShopApp.Domain.Entities;
using BookShopApp.Domain.Repositories.Interfaces;
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
    public partial class AddPublisherForm : Form
    {
        public BookShopForm _bookShopForm;
        IAddPublisherService _addPublisherService;
        public AddPublisherForm(IAddPublisherService addPublisherService,BookShopForm bookShopForm)
        {
            InitializeComponent();
            _bookShopForm= bookShopForm;
            _addPublisherService= addPublisherService;
        }

        private void btnOkAddPublisher_Click(object sender, EventArgs e)
        {
            string name=textBoxAddPublisher.Text;
            bool result =_addPublisherService.AddPublisher(name);
            if (result)
            {
                this.Close();
                _bookShopForm.Enabled = true;
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
