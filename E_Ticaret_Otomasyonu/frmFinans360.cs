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
using DevExpress.Charts;
using DevExpress.XtraCharts;

namespace E_Ticaret_Otomasyonu
{
    public partial class frmFinans360 : Form
    {
        public frmFinans360()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void musterihareket()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Execute MusteriHareketler", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void firmahareket()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Execute FirmaHareketler", bgl.baglanti());
            da2.Fill(dt2);
            gridControl3.DataSource = dt2;
        }

        void giderlistele()
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_GIDERLER", bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;

        }

        private void frmFinans360_Load(object sender, EventArgs e)
        {
            musterihareket();
            firmahareket();
            giderlistele();

            SqlCommand komut = new SqlCommand("Select Sum(TUTAR) from TBL_FATURADETAY", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                labelToplamTutar.Text = dr[0].ToString()+ " ₺";

            }
            bgl.baglanti().Close();

            SqlCommand komut3 = new SqlCommand("Select (ELEKTRIK+SU+DOGALGAZ+INTERNET+MAZOT+CAMUR+MUHASEBE+EKSTRALAR) from TBL_GIDERLER order by ID asc", bgl.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                labelÖdemeler.Text = dr3[0].ToString() + " ₺";

            }
            bgl.baglanti().Close();

            SqlCommand komut4 = new SqlCommand("Select MAASLAR from TBL_GIDERLER order by ID asc", bgl.baglanti());
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                labelPersonelMaaş.Text = dr4[0].ToString() + " ₺";

            }
            bgl.baglanti().Close();

            SqlCommand komut5 = new SqlCommand("Select Count(*) from TBL_MUSTERILER", bgl.baglanti());
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                labelMüşterisay.Text = dr5[0].ToString();

            }
            bgl.baglanti().Close();

            SqlCommand komut6 = new SqlCommand("Select Count(*) from TBL_FIRMALAR", bgl.baglanti());
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                labelFirmasay.Text = dr6[0].ToString();

            }
            bgl.baglanti().Close();

            SqlCommand komut7 = new SqlCommand("Select Count(*) from TBL_PERSONELLER", bgl.baglanti());
            SqlDataReader dr7 = komut7.ExecuteReader();
            while (dr7.Read())
            {
                labelPersonelsay.Text = dr7[0].ToString();

            }
            bgl.baglanti().Close();

            SqlCommand komut8 = new SqlCommand("Select Sum(STOK) from TBL_URUNLER", bgl.baglanti());
            SqlDataReader dr8 = komut8.ExecuteReader();
            while (dr8.Read())
            {
                labelStoksay.Text = dr8[0].ToString();

            }
            bgl.baglanti().Close();

            

            

        }

        int sayac = 0;
            
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;

            if(sayac>0 && sayac <= 5)
            {
                SqlCommand komut9 = new SqlCommand("Select Top 4 AY , ELEKTRIK from TBL_GIDERLER order by ID Desc", bgl.baglanti());
                SqlDataReader dr9 = komut9.ExecuteReader();
                while (dr9.Read())
                {
                    chartControl1.Series["Series 1"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr9[0], dr9[1]));

                }
                bgl.baglanti().Close();
            }

            if (sayac > 6 && sayac <= 10)
            {
                chartControl1.Series["Series 1"].Points.Clear();
                SqlCommand komut10 = new SqlCommand("Select Top 4 AY , SU from TBL_GIDERLER order by ID Desc", bgl.baglanti());
                SqlDataReader dr10 = komut10.ExecuteReader();
                while (dr10.Read())
                {
                    chartControl1.Series["Series 1"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));

                }
                bgl.baglanti().Close();
            }
            if (sayac > 11 && sayac <= 15)
            {
                chartControl1.Series["Series 1"].Points.Clear();
                SqlCommand komut11 = new SqlCommand("Select Top 4 AY , DOGALGAZ from TBL_GIDERLER order by ID Desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl1.Series["Series 1"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));

                }
                bgl.baglanti().Close();
            }
            if (sayac > 16 && sayac <=20)
            {
                chartControl1.Series["Series 1"].Points.Clear();
                SqlCommand komut12 = new SqlCommand("Select Top 4 AY , INTERNET from TBL_GIDERLER order by ID Desc", bgl.baglanti());
                SqlDataReader dr12 = komut12.ExecuteReader();
                while (dr12.Read())
                {
                    chartControl1.Series["Series 1"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr12[0], dr12[1]));

                }
                bgl.baglanti().Close();
            }
            if (sayac > 21 && sayac <= 25)
            {
                chartControl1.Series["Series 1"].Points.Clear();
                SqlCommand komut13 = new SqlCommand("Select Top 4 AY , MAZOT from TBL_GIDERLER order by ID Desc", bgl.baglanti());
                SqlDataReader dr13 = komut13.ExecuteReader();
                while (dr13.Read())
                {
                    chartControl1.Series["Series 1"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr13[0], dr13[1]));

                }
                bgl.baglanti().Close();
            }
            if (sayac > 26 && sayac <= 30)
            {
                chartControl1.Series["Series 1"].Points.Clear();
                SqlCommand komut14 = new SqlCommand("Select Top 4 AY , CAMUR from TBL_GIDERLER order by ID Desc", bgl.baglanti());
                SqlDataReader dr14 = komut14.ExecuteReader();
                while (dr14.Read())
                {
                    chartControl1.Series["Series 1"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr14[0], dr14[1]));

                }
                bgl.baglanti().Close();
            }
            if (sayac > 31 && sayac <= 35)
            {
                chartControl1.Series["Series 1"].Points.Clear();
                SqlCommand komut15 = new SqlCommand("Select Top 4 AY , MUHASEBE from TBL_GIDERLER order by ID Desc", bgl.baglanti());
                SqlDataReader dr15 = komut15.ExecuteReader();
                while (dr15.Read())
                {
                    chartControl1.Series["Series 1"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr15[0], dr15[1]));

                }
                bgl.baglanti().Close();
            }
            if (sayac > 36 && sayac <= 40)
            {
                chartControl1.Series["Series 1"].Points.Clear();
                SqlCommand komut16 = new SqlCommand("Select Top 4 AY , EKSTRALAR from TBL_GIDERLER order by ID Desc", bgl.baglanti());
                SqlDataReader dr16 = komut16.ExecuteReader();
                while (dr16.Read())
                {
                    chartControl1.Series["Series 1"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr16[0], dr16[1]));

                }
                bgl.baglanti().Close();
            }
            if (sayac == 41)
            {
                sayac = 0;
            }
        }
        int sayac2 = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            sayac2++;

            if (sayac2 > 0 && sayac2 <= 5)
            {
                SqlCommand komut9 = new SqlCommand("Select Top 6 AY , ELEKTRIK from TBL_GIDERLER order by ID Desc", bgl.baglanti());
                SqlDataReader dr9 = komut9.ExecuteReader();
                while (dr9.Read())
                {
                    chartControl2.Series["Series 2"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr9[0], dr9[1]));

                }
                bgl.baglanti().Close();
            }

            if (sayac2 > 6 && sayac2 <= 10)
            {
                chartControl2.Series["Series 2"].Points.Clear();
                SqlCommand komut10 = new SqlCommand("Select Top 6 AY , SU from TBL_GIDERLER order by ID Desc", bgl.baglanti());
                SqlDataReader dr10 = komut10.ExecuteReader();
                while (dr10.Read())
                {
                    chartControl2.Series["Series 2"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));

                }
                bgl.baglanti().Close();
            }
            if (sayac2 > 11 && sayac2 <= 15)
            {
                chartControl2.Series["Series 2"].Points.Clear();
                SqlCommand komut11 = new SqlCommand("Select Top 6 AY , DOGALGAZ from TBL_GIDERLER order by ID Desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl2.Series["Series 2"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));

                }
                bgl.baglanti().Close();
            }
            if (sayac2 > 16 && sayac2 <= 20)
            {
                chartControl2.Series["Series 2"].Points.Clear();
                SqlCommand komut12 = new SqlCommand("Select Top 6 AY , INTERNET from TBL_GIDERLER order by ID Desc", bgl.baglanti());
                SqlDataReader dr12 = komut12.ExecuteReader();
                while (dr12.Read())
                {
                    chartControl2.Series["Series 2"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr12[0], dr12[1]));

                }
                bgl.baglanti().Close();
            }
            if (sayac2 > 21 && sayac2 <= 25)
            {
                chartControl2.Series["Series 2"].Points.Clear();
                SqlCommand komut13 = new SqlCommand("Select Top 6 AY , MAZOT from TBL_GIDERLER order by ID Desc", bgl.baglanti());
                SqlDataReader dr13 = komut13.ExecuteReader();
                while (dr13.Read())
                {
                    chartControl2.Series["Series 2"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr13[0], dr13[1]));

                }
                bgl.baglanti().Close();
            }
            if (sayac2 > 26 && sayac2 <= 30)
            {
                chartControl2.Series["Series 2"].Points.Clear();
                SqlCommand komut14 = new SqlCommand("Select Top 6 AY , CAMUR from TBL_GIDERLER order by ID Desc", bgl.baglanti());
                SqlDataReader dr14 = komut14.ExecuteReader();
                while (dr14.Read())
                {
                    chartControl2.Series["Series 2"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr14[0], dr14[1]));

                }
                bgl.baglanti().Close();
            }
            if (sayac2 > 31 && sayac2 <= 35)
            {
                chartControl2.Series["Series 2"].Points.Clear();
                SqlCommand komut15 = new SqlCommand("Select Top 6 AY , MUHASEBE from TBL_GIDERLER order by ID Desc", bgl.baglanti());
                SqlDataReader dr15 = komut15.ExecuteReader();
                while (dr15.Read())
                {
                    chartControl2.Series["Series 2"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr15[0], dr15[1]));

                }
                bgl.baglanti().Close();
            }
            if (sayac2 > 36 && sayac2 <= 40)
            {
                chartControl2.Series["Series 2"].Points.Clear();
                SqlCommand komut16 = new SqlCommand("Select Top 6 AY , EKSTRALAR from TBL_GIDERLER order by ID Desc", bgl.baglanti());
                SqlDataReader dr16 = komut16.ExecuteReader();
                while (dr16.Read())
                {
                    chartControl2.Series["Series 2"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr16[0], dr16[1]));

                }
                bgl.baglanti().Close();
            }
            if (sayac2 == 41)
            {
                sayac2 = 0;
            }
        }

        
    }
}
