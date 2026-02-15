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
    public partial class frmUrunYükle : Form
    {
        public frmUrunYükle()
        {
            InitializeComponent();
        }

        sqlbaglantisi bglu = new sqlbaglantisi();

        void listele()
        {
            DataTable dtu = new DataTable();

            SqlDataAdapter dau = new SqlDataAdapter("Select * From TBL_URUNLER", bglu.baglanti());
            dau.Fill(dtu);
            gridControl1.DataSource = dtu;

        }
        void temizle()
        {

            TxtAd.Text = "";
            TxtMarka.Text = "";
            NudStok.Text = "";
            TxtAlis.Text = "";

            TxtSatis.Text = "";


            RchAciklama.Text = "";


        }



        private byte[] GorselToByteArray(Image gorsel)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                if (gorsel != null)
                {
                    gorsel.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    return ms.ToArray();
                }
                else
                {
                    return null;
                }
            }
        }

        private DevExpress.XtraEditors.PictureEdit tıklanan;

        private void gorselyükle(string gorselyolu)
        {
            if (tıklanan != null)
            {
                tıklanan.EditValue = Image.FromFile(gorselyolu);
            }
        }

        private void pctr1_Click(object sender, EventArgs e)
        {
            tıklanan = pctr1;
            gorselsec_Click(sender, e);

        }

        private void pctr2_Click(object sender, EventArgs e)
        {
            tıklanan = pctr2;
            gorselsec_Click(sender, e);
        }

        private void pctr3_Click(object sender, EventArgs e)
        {
            tıklanan = pctr3;
            gorselsec_Click(sender, e);
        }





        private void frmUrünListesi_Load(object sender, EventArgs e)
        {


        }

        private void frmUrunYükle_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
        }

       

        

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SqlCommand ürünyükle = new SqlCommand("insert into TBL_URUNLER (URUNAD,MARKA,STOK,ALISFIYAT,SATISFIYAT,AÇIKLAMA,GORSEL1,GORSEL2,GORSEL3) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", bglu.baglanti());
            ürünyükle.Parameters.AddWithValue("@p1", TxtAd.Text);
            ürünyükle.Parameters.AddWithValue("@p2", TxtMarka.Text);
            ürünyükle.Parameters.AddWithValue("@p3", int.Parse((NudStok.Value).ToString()));
            ürünyükle.Parameters.AddWithValue("@p4", decimal.Parse(TxtAlis.Text));
            ürünyükle.Parameters.AddWithValue("@p5", decimal.Parse(TxtSatis.Text));
            ürünyükle.Parameters.AddWithValue("@p6", RchAciklama.Text);
            ürünyükle.Parameters.AddWithValue("@p7", GorselToByteArray(pctr1.Image));
            ürünyükle.Parameters.AddWithValue("@p8", GorselToByteArray(pctr2.Image));
            ürünyükle.Parameters.AddWithValue("@p9", GorselToByteArray(pctr3.Image));
            ürünyükle.ExecuteNonQuery();
            bglu.baglanti().Close();
            MessageBox.Show("Ürün Sisteme Yüklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();

            try
            {
                if (pctr1.Image == null || pctr2.Image==null || pctr3.Image==null)
                {
                    throw new Exception("Görsellerin Hepsini Eklemeniz Gerekiyor");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                simpleButton1.Enabled = true;
            }
                

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            TxtAd.Text = dr["URUNAD"].ToString();
            TxtMarka.Text = dr["MARKA"].ToString();
            NudStok.Value = decimal.Parse( dr["STOK"].ToString());
            TxtAlis.Text = dr["ALISFIYAT"].ToString();
            TxtSatis.Text = dr["SATISFIYAT"].ToString();
            RchAciklama.Text = dr["AÇIKLAMA"].ToString();
        }

        private void gorselsec_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Resim Dosyaları (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif";

            openFileDialog.InitialDirectory = @"C:\Kullanıcılar\Mustafa Eren EKİZ\Masaüstü\Gorseller";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string gorselyolu = openFileDialog.FileName;

                if (tıklanan != null)
                {
                    tıklanan.EditValue = Image.FromFile(gorselyolu);
                }
            }
        }
    }
}
