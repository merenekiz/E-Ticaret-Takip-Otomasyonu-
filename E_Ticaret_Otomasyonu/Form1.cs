using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;



namespace E_Ticaret_Otomasyonu
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        frmUrünListesi fr;
        frmUrunYükle fru;
        frmUrünS frs;
        frmUrunG frg;
        frmFirmalar frf;
        frmPersoneller frp;
        frmGiderler frgi;
        frmFatura frfa;
        NOTLAR frn;
        frmSiparişListesi frsl;
        frmStoklar frst;
        frmFinans360 fr360;

                    
        private void btnÜrünListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fr = new frmUrünListesi();
            fr.MdiParent = this;
            fr.Show();

        }

        private void btnÜrünYükle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fru = new frmUrunYükle();
            fru.MdiParent = this;
            fru.Show();

        }

        private void btnÜrünSil_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frs = new frmUrünS();
            frs.MdiParent = this;
            frs.Show();

        }

        private void btnÜrünDüzenle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frg = new frmUrunG();
            frg.MdiParent = this;
            frg.Show();

        }
        frmMusteriler frm;
        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm = new frmMusteriler();
            frm.MdiParent = this;
            frm.Show();
        }

        private void FİR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frf == null || frf.IsDisposed)
            {
                frf = new frmFirmalar();
                frf.MdiParent = this;
                frf.Show();
            }

        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frp == null || frp.IsDisposed)
            {
                frp = new frmPersoneller();
                frp.MdiParent = this;
                frp.Show();
            }
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frgi == null || frgi.IsDisposed)
            {
                frgi = new frmGiderler();
                frgi.MdiParent = this;
                frgi.Show();
            }
        }

        private void FATUR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frfa == null || frfa.IsDisposed)
            {
                frfa = new frmFatura();
                frfa.MdiParent = this;
                frfa.Show();
            }
        }

        private void NOTLAR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frn == null || frn.IsDisposed)
            {
                frn = new NOTLAR();
                frn.MdiParent = this;
                frn.Show();
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frsl == null || frsl.IsDisposed)
            {
                frsl = new frmSiparişListesi();
                frsl.MdiParent = this;
                frsl.Show();
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            frmMusteriRaporları report = new frmMusteriRaporları();

            
            ReportPrintTool printTool = new ReportPrintTool(report);

            
            Form previewForm = printTool.PreviewForm;

            
            if (previewForm != null)
            {
                
                previewForm.FormBorderStyle = FormBorderStyle.None; 
                previewForm.StartPosition = FormStartPosition.Manual; 
                previewForm.Location = new Point(0, 0); 
                previewForm.Size = new Size(1942, 1102); 
                previewForm.WindowState = FormWindowState.Normal; 
            }

            
            printTool.ShowPreviewDialog();
        }

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmFirmaRaporları report = new frmFirmaRaporları();


            ReportPrintTool printTool = new ReportPrintTool(report);


            Form previewForm = printTool.PreviewForm;


            if (previewForm != null)
            {

                previewForm.FormBorderStyle = FormBorderStyle.None;
                previewForm.StartPosition = FormStartPosition.Manual;
                previewForm.Location = new Point(0, 0);
                previewForm.Size = new Size(1942, 1102);
                previewForm.WindowState = FormWindowState.Normal;
            }


            printTool.ShowPreviewDialog();
        }

        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmgiderraporları report = new frmgiderraporları();


            ReportPrintTool printTool = new ReportPrintTool(report);


            Form previewForm = printTool.PreviewForm;


            if (previewForm != null)
            {

                previewForm.FormBorderStyle = FormBorderStyle.None;
                previewForm.StartPosition = FormStartPosition.Manual;
                previewForm.Location = new Point(0, 0);
                previewForm.Size = new Size(1942, 1102);
                previewForm.WindowState = FormWindowState.Normal;
            }


            printTool.ShowPreviewDialog();
        }

        private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmpersonelrapoları report = new frmpersonelrapoları();


            ReportPrintTool printTool = new ReportPrintTool(report);


            Form previewForm = printTool.PreviewForm;


            if (previewForm != null)
            {

                previewForm.FormBorderStyle = FormBorderStyle.None;
                previewForm.StartPosition = FormStartPosition.Manual;
                previewForm.Location = new Point(0, 0);
                previewForm.Size = new Size(1942, 1102);
                previewForm.WindowState = FormWindowState.Normal;
            }


            printTool.ShowPreviewDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fr = new frmUrünListesi();
            fr.MdiParent = this;
            fr.Show();
        }

        private void barButtonItem22_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frst == null || frst.IsDisposed)
            {
                frst = new frmStoklar();
                frst.MdiParent = this;
                frst.Show();
            }
        }

        private void barButtonItem23_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr360 == null || fr360.IsDisposed)
            {
                fr360 = new frmFinans360();
                fr360.MdiParent = this;
                fr360.Show();
            }
        }

       
    }           
}
