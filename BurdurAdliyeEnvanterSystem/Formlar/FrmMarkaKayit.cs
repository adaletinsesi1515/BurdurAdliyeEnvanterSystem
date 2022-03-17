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
    public partial class FrmMarkaKayit : Form
    {
        public FrmMarkaKayit()
        {
            InitializeComponent();
        }

        DbBurdurAdliyeEntities db = new DbBurdurAdliyeEntities();

        void Listeleme ()
        {
            var deger = from x in db.TBLMARKALAR
                        select new
                        {
                            x.ID,
                            MARKA = x.MARKAADI,
                            DURUM = x.STATUS
                        };
            gridControl1.DataSource = deger.ToList();
        }
        private void FrmMarkaKayit_Load(object sender, EventArgs e)
        {
            Listeleme();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLMARKALAR t = new TBLMARKALAR();
            t.MARKAADI = txtmarka.Text;
            t.STATUS = true;
            db.TBLMARKALAR.Add(t);
            db.SaveChanges();
            MessageBox.Show("Marka Kayıt Edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listeleme();

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtid.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtmarka.Text = gridView1.GetFocusedRowCellValue("MARKA").ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtid.Text);
            var deger = db.TBLMARKALAR.Find(id);
            deger.MARKAADI = txtmarka.Text;
            db.SaveChanges();
            MessageBox.Show("Marka Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listeleme();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            txtmarka.Text = "";
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtid.Text);
            var deger = db.TBLMARKALAR.Find(id);
            deger.STATUS = false;
            db.SaveChanges();
            MessageBox.Show("Marka Pasif hale getirildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Listeleme();
        }

        private void BtnAktifYap_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtid.Text);
            var deger = db.TBLMARKALAR.Find(id);
            deger.STATUS = true;
            db.SaveChanges();
            MessageBox.Show("Marka Aktif hale getirildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listeleme();
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
