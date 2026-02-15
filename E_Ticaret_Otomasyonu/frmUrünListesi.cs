using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace E_Ticaret_Otomasyonu
{
    public partial class frmUrünListesi : Form
    {
        public frmUrünListesi()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_URUNLER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }

        private void frmUrünListesi_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr == null) return;

            gorsellerdenyukle(dr);
        }
        private void gorsellerdenyukle(DataRow dr)
        {
            pctr11.Image = null;
            pctr21.Image = null;
            pctr31.Image = null;

            if (dr["GORSEL1"] != DBNull.Value)
            {
                byte[] görsel1 = (byte[])dr["GORSEL1"];
                using (MemoryStream ms = new MemoryStream(görsel1))
                {
                    pctr11.Image = Image.FromStream(ms);
                }
            }

            if (dr["GORSEL2"] != DBNull.Value)
            {
                byte[] görsel2 = (byte[])dr["GORSEL2"];
                using (MemoryStream ms = new MemoryStream(görsel2))
                {
                    pctr21.Image = Image.FromStream(ms);
                }
            }

            if (dr["GORSEL3"] != DBNull.Value)
            {
                byte[] görsel3 = (byte[])dr["GORSEL3"];
                using (MemoryStream ms = new MemoryStream(görsel3))
                {
                    pctr31.Image = Image.FromStream(ms);
                }
            }

        }
    }
}
    
    
