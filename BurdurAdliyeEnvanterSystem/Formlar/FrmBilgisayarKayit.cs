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

        void Listeleme ()
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
        }
    }
}
