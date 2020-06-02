using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TİCARİ_OTOMASYON
{
    public partial class FrmBaslangic : Form
    {
        public FrmBaslangic()
        {
            InitializeComponent();
        }

        FrmUrunler fr;
        private void BtnUrunler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr == null || fr.IsDisposed)
            {
                fr = new FrmUrunler();
                fr.MdiParent = this;
                fr.Show();
            }

        }

        FrmMusteriler fr2;
        private void BtnMusteriler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr2 == null || fr2.IsDisposed)
            {
                fr2 = new FrmMusteriler();
                fr2.MdiParent = this;
                fr2.Show();
            }
        }

        FrmBankalar fr3;
        private void BtnBankalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr3 == null || fr3.IsDisposed)
            {
                fr3 = new FrmBankalar();
                fr3.MdiParent = this;
                fr3.Show();
            }

        }

        FrmAnasayfa fr4;
        private void BtnAnaSayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr4 == null || fr4.IsDisposed)
            {
                fr4 = new FrmAnasayfa();
                fr4.MdiParent = this;
                fr4.Show();
            }
        }

        private void FrmBaslangic_Load(object sender, EventArgs e)
        {
            if (fr4 == null)
            {
                fr4 = new FrmAnasayfa();
                fr4.MdiParent = this;
                fr4.Show();
            }
        }

        FrmStoklar fr5;
        private void BtnStok_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr5 == null || fr5.IsDisposed)
            {
                fr5 = new FrmStoklar();
                fr5.MdiParent = this;
                fr5.Show();
            }
        }

        FrmSatislar fr6;
        private void BtnSatis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr6 == null || fr6.IsDisposed)
            {
                fr6 = new FrmSatislar();
                fr6.MdiParent = this;
                fr6.Show();
            }
        }

        FrmRaporlar fr7;
        private void BtnRaporlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr7 == null || fr7.IsDisposed)
            {
                fr7 = new FrmRaporlar();
                fr7.MdiParent = this;
                fr7.Show();
            }
        }
    }
}
