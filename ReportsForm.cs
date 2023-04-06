using Autofac;
using Autofac.Features.OwnedInstances;
using DevExpress.XtraReports.UI;
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
    public partial class ReportsForm : Form
    {
        ILifetimeScope _lifetimeScope;
        public ReportsForm(ILifetimeScope lifetimeScope)
        {
            InitializeComponent();
            _lifetimeScope = lifetimeScope;
        }

        private void btnAuthorBooks_Click(object sender, EventArgs e)
        {
            using (var scope=_lifetimeScope.BeginLifetimeScope())
            {
                var report = scope.Resolve<Owned<BooksOfAuthorReport>>();
                report.Value.ShowPreview();
            }
        }

        private void btnPurchasesReport_Click(object sender, EventArgs e)
        {
            using (var scope=_lifetimeScope.BeginLifetimeScope())
            {
                var report = scope.Resolve<Owned<PurchaseBooksReport>>();
                report.Value.ShowPreview();
            }
        }
    }
}
