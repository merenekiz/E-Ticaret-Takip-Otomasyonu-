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
    public partial class frmFatura : Form
    {
        public frmFatura()
        {
            InitializeComponent();
        }
        sqlbaglantisi bglfa = new sqlbaglantisi();

        void faturalistele()
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_FATURABILGI", bglfa.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }

        void temizle()
        {
            mskdTarih.Text = "";
            mskdSaat.Text = "";
            txtVergidaire.Text = "";
            txtAlıcı.Text = "";
            txtTeslimeden.Text = "";
            txtTeslimalan.Text = "";
            


        }
        
        private void frmFatura_Load(object sender, EventArgs e)
        {
            faturalistele();
            temizle();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (textFaturaİid.Text == "" )
            {


                SqlCommand komut1 = new SqlCommand("insert into TBL_FATURABILGI (TARIH,SAAT,VERGIDAIRE,ALICI,TESLIMEDEN,TESLIMALAN) values (@p1,@p2,@p3,@p4,@p5,@p6)", bglfa.baglanti());

                komut1.Parameters.AddWithValue("@p1", mskdTarih.Text);
                komut1.Parameters.AddWithValue("@p2", mskdSaat.Text);
                komut1.Parameters.AddWithValue("@p3", txtVergidaire.Text);
                komut1.Parameters.AddWithValue("@p4", txtAlıcı.Text);
                komut1.Parameters.AddWithValue("@p5", txtTeslimeden.Text);
                komut1.Parameters.AddWithValue("@p6", txtTeslimalan.Text);
                komut1.ExecuteNonQuery();
                bglfa.baglanti().Close();
                MessageBox.Show("Fatura Bilgileri Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                faturalistele();
                temizle();
            }
            if (textFaturaİid.Text != "" && comboBox1.Text == "FİRMA")
            {


                double miktar, tutar, fiyat;
                fiyat = Convert.ToDouble(textFiyat.Text);
                miktar = Convert.ToDouble(textMiktar.Text);
                tutar = miktar * fiyat;
                textTutar.Text = tutar.ToString();
                SqlCommand komut2 = new SqlCommand("insert into TBL_FATURADETAY (URUNAD,MIKTAR,FIYAT,TUTAR,FATURAID) values (@p1,@p2,@p3,@p4,@p5)", bglfa.baglanti());

                komut2.Parameters.AddWithValue("@p1", textÜrnadı.Text);
                komut2.Parameters.AddWithValue("@p2", textMiktar.Text);
                komut2.Parameters.AddWithValue("@p3", decimal.Parse(textFiyat.Text));
                komut2.Parameters.AddWithValue("@p4", decimal.Parse(textTutar.Text));
                komut2.Parameters.AddWithValue("@p5", textFaturaİid.Text);
                komut2.ExecuteNonQuery();
                bglfa.baglanti().Close();

                SqlCommand komut3 = new SqlCommand("insert into TBL_FIRMAHAREKETLER (URUNID,ADET,PERSONEL,FIRMA,FIYAT,TOPLAM,FATURAID,TARIH) values (@h1,@h2,@h3,@h4,@h5,@h6,@h7,@h8)", bglfa.baglanti());
                komut3.Parameters.AddWithValue("@h1", textÜürnid.Text);
                komut3.Parameters.AddWithValue("@h2", textMiktar.Text);
                komut3.Parameters.AddWithValue("@h3", TxtPersonel.Text);
                komut3.Parameters.AddWithValue("@h4", TxtFirma.Text);
                komut3.Parameters.AddWithValue("@h5", decimal.Parse(textFiyat.Text));
                komut3.Parameters.AddWithValue("@h6", decimal.Parse(textTutar.Text));
                komut3.Parameters.AddWithValue("@h7", textFaturaİid.Text);
                komut3.Parameters.AddWithValue("@h8", mskdTarih.Text);
                komut3.ExecuteNonQuery();
                bglfa.baglanti().Close();

                SqlCommand komut4 = new SqlCommand("update TBL_URUNLER set STOK=STOK-@s1 where ID=@s2", bglfa.baglanti());
                komut4.Parameters.AddWithValue("@s1", textMiktar.Text);
                komut4.Parameters.AddWithValue("@s2", textÜürnid.Text);
                komut4.ExecuteNonQuery();
                bglfa.baglanti().Close();




                MessageBox.Show("Faturaya Ait Bilgileri Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                faturalistele();
                temizle();
            }
            
            if (textFaturaİid.Text != "" && comboBox1.Text == "MÜŞTERİ")
            {


                double miktar, tutar, fiyat;
                fiyat = Convert.ToDouble(textFiyat.Text);
                miktar = Convert.ToDouble(textMiktar.Text);
                tutar = miktar * fiyat;
                textTutar.Text = tutar.ToString();
                SqlCommand komut2 = new SqlCommand("insert into TBL_FATURADETAY (URUNAD,MIKTAR,FIYAT,TUTAR,FATURAID) values (@p1,@p2,@p3,@p4,@p5)", bglfa.baglanti());

                komut2.Parameters.AddWithValue("@p1", textÜrnadı.Text);
                komut2.Parameters.AddWithValue("@p2", textMiktar.Text);
                komut2.Parameters.AddWithValue("@p3", decimal.Parse(textFiyat.Text));
                komut2.Parameters.AddWithValue("@p4", decimal.Parse(textTutar.Text));
                komut2.Parameters.AddWithValue("@p5", textFaturaİid.Text);
                komut2.ExecuteNonQuery();
                bglfa.baglanti().Close();

                SqlCommand komut3 = new SqlCommand("insert into TBL_MUSTERIHAREKETLER (URUNID,ADET,PERSONEL,MUSTERI,FIYAT,TOPLAM,FATURAID,TARIH) values (@h1,@h2,@h3,@h4,@h5,@h6,@h7,@h8)", bglfa.baglanti());
                komut3.Parameters.AddWithValue("@h1", textÜürnid.Text);
                komut3.Parameters.AddWithValue("@h2", textMiktar.Text);
                komut3.Parameters.AddWithValue("@h3", TxtPersonel.Text);
                komut3.Parameters.AddWithValue("@h4", TxtFirma.Text);
                komut3.Parameters.AddWithValue("@h5", decimal.Parse(textFiyat.Text));
                komut3.Parameters.AddWithValue("@h6", decimal.Parse(textTutar.Text));
                komut3.Parameters.AddWithValue("@h7", textFaturaİid.Text);
                komut3.Parameters.AddWithValue("@h8", mskdTarih.Text);
                komut3.ExecuteNonQuery();
                bglfa.baglanti().Close();

                SqlCommand komut4 = new SqlCommand("update TBL_URUNLER set STOK=STOK-@s1 where ID=@s2", bglfa.baglanti());
                komut4.Parameters.AddWithValue("@s1", textMiktar.Text);
                komut4.Parameters.AddWithValue("@s2", textÜürnid.Text);
                komut4.ExecuteNonQuery();
                bglfa.baglanti().Close();




                MessageBox.Show("Faturaya Ait Bilgileri Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                faturalistele();
                temizle();



            }
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                Txtid.Text = dr["FATURABILGIID"].ToString();
                mskdTarih.Text = dr["TARIH"].ToString();
                mskdSaat.Text = dr["SAAT"].ToString();
                txtVergidaire.Text = dr["VERGIDAIRE"].ToString();
                txtAlıcı.Text = dr["ALICI"].ToString();
                txtTeslimeden.Text = dr["TESLIMEDEN"].ToString();
                txtTeslimalan.Text = dr["TESLIMALAN"].ToString();
            }
        }


        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            SqlCommand fasil = new SqlCommand("Delete From TBL_FATURABILGI where FATURABILGIID=@p1", bglfa.baglanti());
            fasil.Parameters.AddWithValue("@p1", Txtid.Text);
            fasil.ExecuteNonQuery();
            bglfa.baglanti().Close();
            MessageBox.Show("Fatura Bilgileri Sistemden Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Question);
            faturalistele();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_FATURABILGI set TARIH=@P1, SAAT=@P2, VERGIDAIRE=@P3, ALICI=@P4, TESLIMEDEN=@P5, TESLIMALAN=@P6 where FATURABILGIID=@P7", bglfa.baglanti());
            komut.Parameters.AddWithValue("@p1", mskdTarih.Text);
            komut.Parameters.AddWithValue("@p2", mskdSaat.Text);
            komut.Parameters.AddWithValue("@p3", txtVergidaire.Text);
            komut.Parameters.AddWithValue("@p4", txtAlıcı.Text);
            komut.Parameters.AddWithValue("@p5", txtTeslimeden.Text);
            komut.Parameters.AddWithValue("@p6", txtTeslimalan.Text);
            komut.Parameters.AddWithValue("@p7", Txtid.Text);
            komut.ExecuteNonQuery();
            bglfa.baglanti().Close();
            MessageBox.Show("Fatura Bilgileri Sistemde Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            faturalistele();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            frmFaturaÜrünler fr = new frmFaturaÜrünler();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                fr.id = dr["FATURABILGIID"].ToString();
            }
            fr.Show();
        }

        private void btnbul_Click(object sender, EventArgs e)
        {
            SqlCommand bul = new SqlCommand("Select URUNAD,SATISFIYAT from TBL_URUNLER where ID=@p1", bglfa.baglanti());
            bul.Parameters.AddWithValue("@p1", textÜürnid.Text);
            SqlDataReader dr = bul.ExecuteReader();
            while (dr.Read())
            {
                textÜrnadı.Text = dr[0].ToString();
                textFiyat.Text = dr[1].ToString();
            }
            bglfa.baglanti().Close();

        }
    }
}
