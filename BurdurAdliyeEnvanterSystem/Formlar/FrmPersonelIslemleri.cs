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
    public partial class FrmPersonelIslemleri : Form
    {
        public FrmPersonelIslemleri()
        {
            InitializeComponent();
        }

        DbBurdurAdliyeEntities db = new DbBurdurAdliyeEntities();

        void Listemele()
        {
            var deger = from x in db.TBLPERSONELLER
                        select new
                        {
                            x.ID,
                            SICIL = x.SICIL,
                            ADI = x.AD,
                            SOYADI = x.SOYAD,
                            UNVAN = x.TBLUNVANLAR.UNVAN,
                            BIRIM = x.TBLBIRIMLER.BIRIMADI,
                            DAHILI = x.DAHILITEL,
                            CEP = x.CEPTEL,
                            DURUM = x.STATUS
                        };
            gridControl1.DataSource = deger.ToList();
        }
        private void FrmPersonelIslemleri_Load(object sender, EventArgs e)
        {
            Listemele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtId.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtSicil.Text = gridView1.GetFocusedRowCellValue("SICIL").ToString();
            txtAd.Text = gridView1.GetFocusedRowCellValue("ADI").ToString();
            txtSoyad.Text = gridView1.GetFocusedRowCellValue("SOYADI").ToString();
            cmbUnvan.Text = txtAd.Text = gridView1.GetFocusedRowCellValue("UNVAN").ToString();
            cmbBirim.Text = txtAd.Text = gridView1.GetFocusedRowCellValue("BIRIM").ToString();
            txtDahili.Text = gridView1.GetFocusedRowCellValue("DAHILI").ToString();
            txtCepTel.Text = gridView1.GetFocusedRowCellValue("CEP").ToString();
            textEdit1.Text = gridView1.GetFocusedRowCellValue("DURUM").ToString();
            textEdit1.Visible = false;
            if ((textEdit1.Text == "True")) chkGorevdemi.Checked = true;
            if ((textEdit1.Text == "False")) chkGorevdemi.Checked = false;

        }
    }
}
