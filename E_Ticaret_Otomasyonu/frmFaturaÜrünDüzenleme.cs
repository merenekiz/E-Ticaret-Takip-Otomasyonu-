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
    public partial class frmFaturaÜrünDüzenleme : Form
    {
        public frmFaturaÜrünDüzenleme()
        {
            InitializeComponent();
        }

        public string urunid;
        sqlbaglantisi bgl = new sqlbaglantisi();
         private void frmFaturaÜrünDüzenleme_Load(object sender, EventArgs e)
        {
            textÜürnid.Text = urunid;
            SqlCommand komut = new SqlCommand("Select* From TBL_FATURADETAY where FATURAURUNID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", urunid);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                textFiyat.Text = dr[3].ToString();
                textMiktar.Text = dr[2].ToString();
                textTutar.Text = dr[4].ToString();
                textÜrnadı.Text = dr[1].ToString();
                bgl.baglanti().Close();


            }
        
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_FATURADETAY set URUNAD=@P1, MIKTAR=@P2, FIYAT=@P3, TUTAR=@P4 where FATURAURUNID=@P5", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textÜrnadı.Text);
            komut.Parameters.AddWithValue("@p2", textMiktar.Text);
            komut.Parameters.AddWithValue("@p3", decimal.Parse(textFiyat.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse(textTutar.Text));
            komut.Parameters.AddWithValue("@p5", textÜürnid.Text);
            
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Değişiklikler Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            SqlCommand detaysil = new SqlCommand("Delete From TBL_FATURADETAY where FATURAURUNID=@p1", bgl.baglanti());
            detaysil.Parameters.AddWithValue("@p1", textÜürnid.Text);
            detaysil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Question);
            
        }
    }
}
