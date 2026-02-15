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
    public partial class frmUrünS : Form
    {
        public frmUrünS()
        {
            InitializeComponent();
        }

       

        sqlbaglantisi bgls = new sqlbaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_URUNLER", bgls.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }
        void temizle()
        {
            Txtid.Text = "";
            


        }



        private void frmUrünListesi_Load(object sender, EventArgs e)
        {
            

        }

        private void frmUrünS_Load(object sender, EventArgs e)
        {
            listele();
            temizle();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand ürünsil = new SqlCommand("Delete From TBL_URUNLER where ID=@p1", bgls.baglanti());
            ürünsil.Parameters.AddWithValue("@p1", Txtid.Text);
            ürünsil.ExecuteNonQuery();
            bgls.baglanti().Close();
            MessageBox.Show("Ürün Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            listele();
            temizle();

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                int focusedRowHandle = gridView1.FocusedRowHandle;
                if (focusedRowHandle >= 0)
                {
                    DataRow dr = gridView1.GetDataRow(focusedRowHandle);
                    if (dr != null && dr.Table.Columns.Contains("ID"))
                    {
                        Txtid.Text = dr["ID"].ToString();
                    }
                    else
                    {
                        Txtid.Text = string.Empty;
                    }
                }
                else
                {
                    Txtid.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }

        }
    }
}
