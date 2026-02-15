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

namespace E_Ticaret_Otomasyonu
{
    public partial class frmFaturaÜrünler : Form
    {
        public frmFaturaÜrünler()
        {
            InitializeComponent();
        }

        public string id;
        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_FATURADETAY where FATURAID=' " + id + "'", bgl.baglanti());
            DataTable dk = new DataTable();
            da.Fill(dk);
            gridControl1.DataSource = dk;

        }
        private void frmFaturaÜrünler_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            frmFaturaÜrünDüzenleme fr = new frmFaturaÜrünDüzenleme();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                fr.urunid = dr["FATURAURUNID"].ToString();
            }
            fr.Show();
        }
    }
}
