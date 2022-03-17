using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
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

        void MarkaEkle()
        {
            var deger = db.TBLMARKALAR.ToList();
            cmbmarka.DataSource = deger;
            cmbmarka.DisplayMember = "MARKAADI";
        }
        private void FrmBilgisayarKayit_Load(object sender, EventArgs e)
        {

            Listeleme();
            MarkaEkle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            txtid.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtserino.Text = gridView1.GetFocusedRowCellValue("SERINO").ToString();
            cmbmarka.Text = gridView1.GetFocusedRowCellValue("MARKA").ToString();
            cmbModel.Text = gridView1.GetFocusedRowCellValue("MODEL").ToString();
            textEdit1.Text = gridView1.GetFocusedRowCellValue("ZIMMET").ToString();
            textEdit1.Visible = false;
            if ((textEdit1.Text == "True")) chkzimmet.Checked = true;
            if ((textEdit1.Text == "False")) chkzimmet.Checked = false;


        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            txtserino.Text = "";
            cmbmarka.Text = "";
            cmbModel.Text = "";
            chkzimmet.Checked = false;

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLBILGISAYARLAR t = new TBLBILGISAYARLAR();

            t.MARKAID = (cmbmarka.SelectedItem as TBLMARKALAR).ID;

            t.MODELID = (cmbModel.SelectedItem as TBLMODELLER).ID;
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
            deger.MARKAID = (cmbmarka.SelectedItem as TBLMARKALAR).ID;
            deger.MODELID = (cmbModel.SelectedItem as TBLMODELLER).ID;
            deger.SERINO = txtserino.Text;
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

        private void cmbmarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            var deger = db.TBLMODELLER.Where(x => x.MARKAID == cmbmarka.SelectedIndex + 1).ToList();
            cmbModel.DataSource = deger;
            cmbModel.DisplayMember = "MODELADI";
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtid.Text);
            var deger = db.TBLBILGISAYARLAR.Find(id);
            deger.STATUS = false;
            deger.ZIMMET = false;
            db.SaveChanges();
            MessageBox.Show("Bilgisayar pasif duruma alındı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Listeleme();
        }

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            
            
            bool deger = Convert.ToBoolean(view.GetRowCellValue(e.RowHandle, "STATUS"));
            if (deger == false)
            {
                e.Appearance.BackColor = Color.Red;
            }
            

        }
    }
}

