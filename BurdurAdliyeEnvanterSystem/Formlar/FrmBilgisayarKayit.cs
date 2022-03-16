using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BurdurAdliyeEnvanterSystem.Formlar
{
    public partial class FrmBilgisayarKayit : Form
    {
        public FrmBilgisayarKayit()
        {
            InitializeComponent();
        }

        DbBurdurAdliyeEntities db = new DbBurdurAdliyeEntities();

        void Listeleme()
        {
            var deger = from x in db.TBLBILGISAYARLAR
                        select new
                        {
                            x.ID,
                            MARKA = x.TBLMARKALAR.MARKAADI,
                            MODEL = x.TBLMODELLER.MODELADI,
                            x.SERINO,
                            x.STATUS,
                            x.ZIMMET
                        };

            gridControl1.DataSource = deger.ToList();
        }
        private void FrmBilgisayarKayit_Load(object sender, EventArgs e)
        {
            
            Listeleme();
            lookmarka.Properties.DataSource = (from x in db.TBLMARKALAR
                                               select new
                                               {
                                                   x.ID,
                                                   x.MARKAADI
                                               }).ToList();

            lookmodel.Properties.DataSource = (from x in db.TBLMODELLER
                                               select new
                                               {
                                                   x.ID,
                                                   MARKA = x.TBLMARKALAR.MARKAADI,
                                                   x.MODELADI
                                               }).ToList();
            lookmarka.Properties.NullText = "Marka Seçiniz";
            lookmodel.Properties.NullText = "Model Seçiniz";
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            txtid.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtserino.Text = gridView1.GetFocusedRowCellValue("SERINO").ToString();
            textEdit1.Text = gridView1.GetFocusedRowCellValue("ZIMMET").ToString();
            textEdit1.Visible = false;
            if ((textEdit1.Text == "True")) chkzimmet.Checked = true;
            if ((textEdit1.Text == "False")) chkzimmet.Checked = false;


        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            txtserino.Text = "";
            lookmarka.Text = "";
            lookmodel.Text = "";
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLBILGISAYARLAR t = new TBLBILGISAYARLAR();

            t.MARKAID = byte.Parse(lookmarka.EditValue.ToString());
            t.MODELID = byte.Parse(lookmodel.EditValue.ToString());
            t.SERINO = txtserino.Text;
            t.STATUS = true;
            if (chkzimmet.Checked == true)
            {
                t.ZIMMET = true;
            }
            else
            {
                t.ZIMMET = false;
            }

            db.TBLBILGISAYARLAR.Add(t);
            db.SaveChanges();
            MessageBox.Show("Bilgisayar başarıyla kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listeleme();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtid.Text);
            var deger = db.TBLBILGISAYARLAR.Find(id);
            deger.MARKAID = byte.Parse(cmbmarka.Text);
            deger.MODELID= byte.Parse(lookmodel.EditValue.ToString());
            deger.SERINO= txtserino.Text;
            if (chkzimmet.Checked == true)
            {
                deger.ZIMMET = true;
            }
            else
            {
                deger.ZIMMET = false;
            }
            db.SaveChanges();
            MessageBox.Show("Bilgisayar kaydı güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listeleme();
        }
    }
}

