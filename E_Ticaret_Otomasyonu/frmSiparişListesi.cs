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
    public partial class frmSiparişListesi : Form
    {
        public frmSiparişListesi()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void firmalistele()
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("Exec FirmaHareketler", bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;
        }
        void musterilistele()
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("Exec MusteriHareketler", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void frmSiparişListesi_Load(object sender, EventArgs e)
        {
            musterilistele();
            firmalistele();
            
        }
    }
}
