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
    public partial class frmUrunG : Form
    {
        public frmUrunG()
        {
            InitializeComponent();
        }
        sqlbaglantisi bglg = new sqlbaglantisi();

        void listele()
        {
            DataTable dtg = new DataTable();

            SqlDataAdapter dag = new SqlDataAdapter("Select * From TBL_URUNLER", bglg.baglanti());
            dag.Fill(dtg);
            gridControl1.DataSource = dtg;

        }
        void temizle()
        {
            Txtid.Text = "";
            TxtAd.Text = "";
            TxtMarka.Text = "";
            nudStok.Text = "";
            TxtAlis.Text = "";

            TxtSatis.Text = "";

           
            RchAciklama.Text = "";


        }

        private void frmUrunG_Load(object sender, EventArgs e)
        {
            listele();

            temizle();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (string.IsNullOrWhiteSpace(TxtAlis.Text))
                {
                    throw new Exception("Alış fiyatı girmek zorunludur.");
                }

                
                if (string.IsNullOrWhiteSpace(TxtSatis.Text))
                {
                    throw new Exception("Satış fiyatı girmek zorunludur.");
                }

                // Veritabanı güncelleme işlemi
                SqlCommand komut = new SqlCommand("UPDATE TBL_URUNLER SET URUNAD=@P2, MARKA=@P3, STOK=@P4, ALISFIYAT=@P5, SATISFIYAT=@P6, AÇIKLAMA=@P7 WHERE ID=@P1",bglg.baglanti() );

                komut.Parameters.AddWithValue("@p1", Txtid.Text);
                komut.Parameters.AddWithValue("@p2", TxtAd.Text);
                komut.Parameters.AddWithValue("@p3", TxtMarka.Text);
                komut.Parameters.AddWithValue("@p4", int.Parse(nudStok.Value.ToString()));
                komut.Parameters.AddWithValue("@p5", decimal.Parse(TxtAlis.Text));
                komut.Parameters.AddWithValue("@p6", decimal.Parse(TxtSatis.Text));
                komut.Parameters.AddWithValue("@p7", RchAciklama.Text);

                komut.ExecuteNonQuery();
                bglg.baglanti().Close();

                MessageBox.Show("Ürün bilgisi güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                listele();
                temizle();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            Txtid.Text = dr["ID"].ToString();
            TxtAd.Text = dr["URUNAD"].ToString();
            TxtMarka.Text = dr["MARKA"].ToString();
            nudStok.Value = decimal.Parse(dr["STOK"].ToString());
            TxtAlis.Text = dr["ALISFIYAT"].ToString();
            TxtSatis.Text = dr["SATISFIYAT"].ToString();
            RchAciklama.Text = dr["AÇIKLAMA"].ToString();
        }

        
    }
}
