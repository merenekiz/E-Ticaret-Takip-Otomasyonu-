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
    public partial class NOTLAR : Form
    {
        public NOTLAR()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgln = new sqlbaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_NOTLAR", bgln.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }
        void temizle()
        {
            Txtid.Text = "";
            TxtBaşlık.Text = "";
            TxtOluşturan.Text = "";
            MskdSaat.Text = "";
            MskdTarih.Text = "";
            RchDetay.Text = "";
            textKime.Text = "";
        }

        private void frmNotlar_Load(object sender, EventArgs e)
        {
            listele();
            temizle();


        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_NOTLAR (NOTTARIH,NOTSAAT,NOTBASLIK,NOTOLUSTURAN,NOTKIME,NOTDETAY) values (@p1,@p2,@p3,@p4,@p5,@p6)", bgln.baglanti());

            komut.Parameters.AddWithValue("@p1", MskdTarih.Text);
            komut.Parameters.AddWithValue("@p2", MskdSaat.Text);
            komut.Parameters.AddWithValue("@p3", TxtBaşlık.Text);
            komut.Parameters.AddWithValue("@p4", TxtOluşturan.Text);
            komut.Parameters.AddWithValue("@p5", textKime.Text);
            komut.Parameters.AddWithValue("@p6", RchDetay.Text);
            komut.ExecuteNonQuery();
            bgln.baglanti().Close();
            MessageBox.Show("Notlar Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                Txtid.Text = dr["NOTID"].ToString();
                MskdTarih.Text = dr["NOTTARIH"].ToString();
                MskdSaat.Text = dr["NOTSAAT"].ToString();
                TxtBaşlık.Text = dr["NOTBASLIK"].ToString();
                TxtOluşturan.Text = dr["NOTOLUSTURAN"].ToString();              
                RchDetay.Text = dr["NOTDETAY"].ToString();
                textKime.Text = dr["NOTKIME"].ToString();
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand notsil = new SqlCommand("Delete From TBL_NOTLAR where NOTID=@p1", bgln.baglanti());
            notsil.Parameters.AddWithValue("@p1", Txtid.Text);
            notsil.ExecuteNonQuery();
            bgln.baglanti().Close();
            MessageBox.Show("Notlar Sistemden Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            listele();
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_NOTLAR set NOTTARIH=@P1, NOTSAAT=@P2, NOTBASLIK=@P3, NOTDETAY=@P4, NOTOLUSTURAN=@P5, NOTKIME=@P6 where NOTID=@P7", bgln.baglanti());
            komut.Parameters.AddWithValue("@p1", MskdTarih.Text);
            komut.Parameters.AddWithValue("@p2", MskdSaat.Text);
            komut.Parameters.AddWithValue("@p3", TxtBaşlık.Text);
            komut.Parameters.AddWithValue("@p4", TxtOluşturan.Text);
            komut.Parameters.AddWithValue("@p5", textKime.Text);
            komut.Parameters.AddWithValue("@p6", RchDetay.Text);
            komut.Parameters.AddWithValue("@p7", Txtid.Text);
            komut.ExecuteNonQuery();
            bgln.baglanti().Close();
            MessageBox.Show("Notlar Sistemde Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            frmNotDetay fn = new frmNotDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                fn.metin = dr["NOTDETAY"].ToString();
            }
            fn.Show();
        }
    }
}
