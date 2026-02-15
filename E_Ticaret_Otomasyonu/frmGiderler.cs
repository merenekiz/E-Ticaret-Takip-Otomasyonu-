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
    public partial class frmGiderler : Form
    {
        public frmGiderler()
        {
            InitializeComponent();
        }

        sqlbaglantisi bglgi = new sqlbaglantisi();

        void giderlistele()
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_GIDERLER", bglgi.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }

        void temizle()
        {
            Txtid.Text = "";
            cmbAy.Text = "";
            cmbYil.Text = "";
            txtElektrik.Text = "";
            txtSu.Text = "";
            txtDogalgaz.Text = "";
            txtInternet.Text = "";
            txtMazot.Text = "";
            txtCamur.Text = "";
            txtMuhasabe.Text = "";
            txtMaaşlar.Text = "";
            txtEkstralar.Text = "";
            RchDetay.Text = "";


        }
        private void frmGiderler_Load(object sender, EventArgs e)
        {
            giderlistele();
            temizle();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_GIDERLER (AY,YIL,ELEKTRIK,SU,DOGALGAZ,INTERNET,MAZOT,CAMUR,MUHASEBE,MAASLAR,EKSTRALAR,DETAY) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12)", bglgi.baglanti());

            komut.Parameters.AddWithValue("@p1", cmbAy.Text);
            komut.Parameters.AddWithValue("@p2", cmbYil.Text);
            komut.Parameters.AddWithValue("@p3", decimal.Parse(txtElektrik.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse(txtSu.Text));
            komut.Parameters.AddWithValue("@p5", decimal.Parse(txtDogalgaz.Text));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(txtInternet.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(txtMazot.Text));
            komut.Parameters.AddWithValue("@p8", decimal.Parse(txtCamur.Text));
            komut.Parameters.AddWithValue("@p9", decimal.Parse(txtMuhasabe.Text));
            komut.Parameters.AddWithValue("@p10", decimal.Parse(txtMaaşlar.Text));
            komut.Parameters.AddWithValue("@p11", decimal.Parse(txtEkstralar.Text));
            komut.Parameters.AddWithValue("@p12", RchDetay.Text);
            komut.ExecuteNonQuery();
            bglgi.baglanti().Close();
            MessageBox.Show("Gider Bilgileri Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            giderlistele();
            temizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand gidersil = new SqlCommand("Delete From TBL_GIDERLER where ID=@p1", bglgi.baglanti());
            gidersil.Parameters.AddWithValue("@p1", Txtid.Text);
            gidersil.ExecuteNonQuery();
            bglgi.baglanti().Close();
            MessageBox.Show("Gider Bilgileri Sistemden Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            giderlistele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                Txtid.Text = dr["ID"].ToString();
                cmbAy.Text = dr["AY"].ToString();
                cmbYil.Text = dr["YIL"].ToString();
                txtElektrik.Text = dr["ELEKTRIK"].ToString();
                txtSu.Text = dr["SU"].ToString();
                txtDogalgaz.Text = dr["DOGALGAZ"].ToString();
                txtInternet.Text = dr["INTERNET"].ToString();
                txtMazot.Text = dr["MAZOT"].ToString();
                txtCamur.Text = dr["CAMUR"].ToString();
                txtMuhasabe.Text = dr["MUHASEBE"].ToString();
                txtMaaşlar.Text = dr["MAASLAR"].ToString();
                txtEkstralar.Text = dr["EKSTRALAR"].ToString();
                RchDetay.Text = dr["DETAY"].ToString();


            }
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_GIDERLER set AY=@P1, YIL=@P2, ELEKTRIK=@P3, SU=@P4, DOGALGAZ=@P5, INTERNET=@P6, MAZOT=@P7, CAMUR=@P8, MUHASEBE=@P9, MAASLAR=@P10, EKSTRALAR=@P11, DETAY=@P12 where ID=@P13", bglgi.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbAy.Text);
            komut.Parameters.AddWithValue("@p2", cmbYil.Text);
            komut.Parameters.AddWithValue("@p3", decimal.Parse(txtElektrik.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse(txtSu.Text));
            komut.Parameters.AddWithValue("@p5", decimal.Parse(txtDogalgaz.Text));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(txtInternet.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(txtMazot.Text));
            komut.Parameters.AddWithValue("@p8", decimal.Parse(txtCamur.Text));
            komut.Parameters.AddWithValue("@p9", decimal.Parse(txtMuhasabe.Text));
            komut.Parameters.AddWithValue("@p10", decimal.Parse(txtMaaşlar.Text));
            komut.Parameters.AddWithValue("@p11", decimal.Parse(txtEkstralar.Text));
            komut.Parameters.AddWithValue("@p12", RchDetay.Text);
            komut.Parameters.AddWithValue("@p13", Txtid.Text);
            komut.ExecuteNonQuery();
            bglgi.baglanti().Close();
            MessageBox.Show("Gider Bilgileri Sistemde Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            giderlistele();
        }

        
    }
}
