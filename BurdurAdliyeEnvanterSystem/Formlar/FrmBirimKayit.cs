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
    public partial class FrmBirimKayit : Form
    {
        public FrmBirimKayit()
        {
            InitializeComponent();
        }

        DbBurdurAdliyeEntities db = new DbBurdurAdliyeEntities();

        void Listeleme()
        {
            var deger = from x in db.TBLBIRIMLER
                        select new
                        {
                            x.ID,
                            BIRIM = x.BIRIMADI,                            
                            DURUM = x.STATUS
                        };
            
            gridControl1.DataSource = deger.ToList();
        }
        private void FrmBirimKayit_Load(object sender, EventArgs e)
        {
            Listeleme();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLBIRIMLER t= new TBLBIRIMLER();
            t.BIRIMADI= txtbirim.Text;
            t.STATUS = true;

            db.TBLBIRIMLER.Add(t);
            db.SaveChanges();
            MessageBox.Show("Birim başarıyla kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listeleme();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtid.Text);
            var deger = db.TBLBIRIMLER.Find(id);
            deger.BIRIMADI = txtbirim.Text;
            db.SaveChanges();
            MessageBox.Show("Birim başarıyla güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listeleme();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtid.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtbirim.Text = gridView1.GetFocusedRowCellValue("BIRIM").ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtid.Text);
            var deger = db.TBLBIRIMLER.Find(id);
            deger.STATUS = false; 
            db.SaveChanges();
            MessageBox.Show("Birim PASİFE alınmıştır", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Listeleme();
        }

        private void BtnAktifYap_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtid.Text);
            var deger = db.TBLBIRIMLER.Find(id);
            deger.STATUS = true;
            db.SaveChanges();
            MessageBox.Show("Birim AKTİFE alınmıştır", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            txtbirim.Text = "";
        }
    }
}
