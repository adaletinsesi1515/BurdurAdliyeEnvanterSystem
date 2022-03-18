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
        Formlar.FrmYaziciKayit frmYaziciKayit;
        Formlar.FrmTarayiciKayit frmTarayiciKayit;
        Formlar.FrmMarkaKayit frmMarkaKayit;
        Formlar.FrmModelKayit frmModelKayit;
        Formlar.FrmBirimKayit frmBirimKayit;
        Formlar.FrmUnvanKayit frmUnvanKayit;
        Formlar.FrmPersonelIslemleri frmPersonelIslemleri;


        private void BtnBilgisayarKaydi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmBilgisayarKayit== null || frmBilgisayarKayit.IsDisposed)
            {
                frmBilgisayarKayit = new Formlar.FrmBilgisayarKayit();
                frmBilgisayarKayit.MdiParent = this;
                frmBilgisayarKayit.Show();
            }
        }

        private void BtnYaziciKaydi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmYaziciKayit == null || frmYaziciKayit.IsDisposed)
            {
                frmYaziciKayit = new Formlar.FrmYaziciKayit();
                frmYaziciKayit.MdiParent = this;
                frmYaziciKayit.Show();
            }
        }

        private void btnTarayiciKaydi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmTarayiciKayit == null || frmTarayiciKayit.IsDisposed)
            {
                frmTarayiciKayit = new Formlar.FrmTarayiciKayit();
                frmTarayiciKayit.MdiParent = this;
                frmTarayiciKayit.Show();
            }
        }

        private void FullForm_Load(object sender, EventArgs e)
        {

        }

        private void btnMarkaKayit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmMarkaKayit == null || frmMarkaKayit.IsDisposed)
            {
                frmMarkaKayit = new Formlar.FrmMarkaKayit();
                frmMarkaKayit.MdiParent = this;
                frmMarkaKayit.Show();
            }
        }

        private void btnModelKayit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmModelKayit == null || frmModelKayit.IsDisposed)
            {
                frmModelKayit = new Formlar.FrmModelKayit();
                frmModelKayit.MdiParent = this;
                frmModelKayit.Show();
            }
        }

        private void btnBirimKayit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmBirimKayit== null || frmBirimKayit.IsDisposed)
            {
                frmBirimKayit = new Formlar.FrmBirimKayit();
                frmBirimKayit.MdiParent = this;
                frmBirimKayit.Show();
            }


        }

        private void btnUnvanKayit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmUnvanKayit == null || frmUnvanKayit.IsDisposed)
            {
                frmUnvanKayit = new Formlar.FrmUnvanKayit();
                frmUnvanKayit.MdiParent = this;
                frmUnvanKayit.Show();
            }
        }

        private void btnPersonelIslemleri_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmPersonelIslemleri == null || frmUnvanKayit.IsDisposed)
            {
                frmPersonelIslemleri = new Formlar.FrmPersonelIslemleri();
                frmPersonelIslemleri.MdiParent = this;
                frmPersonelIslemleri.Show();
            }
        }
    }
}
