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
    public partial class FrmModelKayit : Form
    {
        public FrmModelKayit()
        {
            InitializeComponent();
        }
        DbBurdurAdliyeEntities db = new DbBurdurAdliyeEntities();

        void Listeleme()
        {
            var deger = from x in db.TBLMODELLER
                        select new
                        {
                            x.ID,
                            MARKA = x.TBLMARKALAR.MARKAADI,
                            MODEL = x.MODELADI,
                            DURUM = x.STATUS
                        };
            gridControl1.DataSource = deger.ToList();
        }
        void MarkaEkle()
        {
            var deger = db.TBLMARKALAR.ToList();
            cmbmarka.DataSource = deger;
            cmbmarka.DisplayMember = "MARKAADI";
        }

        private void FrmModelKayit_Load(object sender, EventArgs e)
        {
            Listeleme();
            MarkaEkle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLMODELLER t = new TBLMODELLER();
            t.MARKAID = (cmbmarka.SelectedItem as TBLMARKALAR).ID;

            t.MODELADI= txtmodel.Text;            
            t.STATUS = true;
            
            db.TBLMODELLER.Add(t);
            db.SaveChanges();
            MessageBox.Show("Model başarıyla kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listeleme();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtid.Text);
            var deger = db.TBLMODELLER.Find(id);
            deger.MARKAID = (cmbmarka.SelectedItem as TBLMARKALAR).ID;
            deger.MODELADI = txtmodel.Text;            
            db.SaveChanges();
            MessageBox.Show("Model kaydı güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listeleme();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtid.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            cmbmarka.Text = gridView1.GetFocusedRowCellValue("MARKA").ToString();
            txtmodel.Text= gridView1.GetFocusedRowCellValue("MODEL").ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtid.Text);
            var deger = db.TBLMODELLER.Find(id);
            deger.STATUS = false;
            db.SaveChanges();
            MessageBox.Show("Model pasif edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listeleme();
        }

        private void BtnAktifYap_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtid.Text);
            var deger = db.TBLMODELLER.Find(id);
            deger.STATUS = true;
            db.SaveChanges();
            MessageBox.Show("Model aktif edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listeleme();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            cmbmarka.Text = "";
            txtmodel.Text = "";
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;


            bool deger = Convert.ToBoolean(view.GetRowCellValue(e.RowHandle, "DURUM"));
            if (deger == false)
            {
                e.Appearance.BackColor = Color.Red;
            }
        }
    }
}
