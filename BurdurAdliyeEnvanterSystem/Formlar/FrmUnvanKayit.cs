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
    public partial class FrmUnvanKayit : Form
    {
        public FrmUnvanKayit()
        {
            InitializeComponent();
        }

        DbBurdurAdliyeEntities db = new DbBurdurAdliyeEntities();

        void Listele ()
        {
            var deger = from x in db.TBLUNVANLAR
                        select new
                        {
                            x.ID,
                            UNVAN = x.UNVAN,
                            DURUM = x.STATUS
                        };
            gridControl1.DataSource = deger.ToList();
        }

        private void FrmUnvanKayit_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLUNVANLAR t = new TBLUNVANLAR();
            t.UNVAN = txtunvan.Text;
            t.STATUS = true;
            db.TBLUNVANLAR.Add(t);
            db.SaveChanges();
            MessageBox.Show("Unvan kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtid.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtunvan.Text = gridView1.GetFocusedRowCellValue("UNVAN").ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtid.Text);
            var deger = db.TBLUNVANLAR.Find(id);
            deger.UNVAN = txtunvan.Text;
            db.SaveChanges();
            MessageBox.Show("Unvan güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtid.Text);
            var deger = db.TBLUNVANLAR.Find(id);
            deger.STATUS = false;
            db.SaveChanges();
            MessageBox.Show("Unvan PASİF hale getirildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Listele();
        }

        private void BtnAktifYap_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtid.Text);
            var deger = db.TBLUNVANLAR.Find(id);
            deger.STATUS = true;
            db.SaveChanges();
            MessageBox.Show("Unvan AKTİF hale getirildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Listele();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            txtunvan.Text = "";
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
