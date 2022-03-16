using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BurdurAdliyeEnvanterSystem
{
    public partial class FullForm : Form
    {
        public FullForm()
        {
            InitializeComponent();
        }

        Formlar.FrmBilgisayarKayit frmBilgisayarKayit;

        private void BtnBilgisayarKaydi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmBilgisayarKayit== null || frmBilgisayarKayit.IsDisposed)
            {
                frmBilgisayarKayit = new Formlar.FrmBilgisayarKayit();
                frmBilgisayarKayit.MdiParent = this;
                frmBilgisayarKayit.Show();
            }
        }
    }
}
