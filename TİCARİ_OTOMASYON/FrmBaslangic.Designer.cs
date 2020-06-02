namespace TİCARİ_OTOMASYON
{
    partial class FrmBaslangic
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBaslangic));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.BtnAnaSayfa = new DevExpress.XtraBars.BarButtonItem();
            this.BtnUrunler = new DevExpress.XtraBars.BarButtonItem();
            this.BtnSatis = new DevExpress.XtraBars.BarButtonItem();
            this.BtnMusteriler = new DevExpress.XtraBars.BarButtonItem();
            this.BtnRaporlar = new DevExpress.XtraBars.BarButtonItem();
            this.BtnStok = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.BtnBankalar = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.AllowMdiChildButtons = false;
            this.ribbonControl1.BackColor = System.Drawing.SystemColors.Control;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.BtnAnaSayfa,
            this.BtnUrunler,
            this.BtnSatis,
            this.BtnMusteriler,
            this.BtnRaporlar,
            this.BtnStok,
            this.barSubItem1,
            this.BtnBankalar});
            resources.ApplyResources(this.ribbonControl1, "ribbonControl1");
            this.ribbonControl1.MaxItemId = 3;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.ShowOnMultiplePages;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // BtnAnaSayfa
            // 
            resources.ApplyResources(this.BtnAnaSayfa, "BtnAnaSayfa");
            this.BtnAnaSayfa.Id = 1;
            this.BtnAnaSayfa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnAnaSayfa.ImageOptions.Image")));
            this.BtnAnaSayfa.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnAnaSayfa.ImageOptions.LargeImage")));
            this.BtnAnaSayfa.ItemAppearance.Normal.Font = ((System.Drawing.Font)(resources.GetObject("BtnAnaSayfa.ItemAppearance.Normal.Font")));
            this.BtnAnaSayfa.ItemAppearance.Normal.Options.UseFont = true;
            this.BtnAnaSayfa.Name = "BtnAnaSayfa";
            this.BtnAnaSayfa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnAnaSayfa_ItemClick);
            // 
            // BtnUrunler
            // 
            resources.ApplyResources(this.BtnUrunler, "BtnUrunler");
            this.BtnUrunler.Id = 2;
            this.BtnUrunler.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnUrunler.ImageOptions.Image")));
            this.BtnUrunler.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnUrunler.ImageOptions.LargeImage")));
            this.BtnUrunler.ItemAppearance.Normal.Font = ((System.Drawing.Font)(resources.GetObject("BtnUrunler.ItemAppearance.Normal.Font")));
            this.BtnUrunler.ItemAppearance.Normal.Options.UseFont = true;
            this.BtnUrunler.Name = "BtnUrunler";
            this.BtnUrunler.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnUrunler_ItemClick);
            // 
            // BtnSatis
            // 
            resources.ApplyResources(this.BtnSatis, "BtnSatis");
            this.BtnSatis.Id = 3;
            this.BtnSatis.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnSatis.ImageOptions.Image")));
            this.BtnSatis.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnSatis.ImageOptions.LargeImage")));
            this.BtnSatis.ItemAppearance.Normal.Font = ((System.Drawing.Font)(resources.GetObject("BtnSatis.ItemAppearance.Normal.Font")));
            this.BtnSatis.ItemAppearance.Normal.Options.UseFont = true;
            this.BtnSatis.Name = "BtnSatis";
            this.BtnSatis.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnSatis_ItemClick);
            // 
            // BtnMusteriler
            // 
            resources.ApplyResources(this.BtnMusteriler, "BtnMusteriler");
            this.BtnMusteriler.Id = 4;
            this.BtnMusteriler.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnMusteriler.ImageOptions.Image")));
            this.BtnMusteriler.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnMusteriler.ImageOptions.LargeImage")));
            this.BtnMusteriler.ItemAppearance.Normal.Font = ((System.Drawing.Font)(resources.GetObject("BtnMusteriler.ItemAppearance.Normal.Font")));
            this.BtnMusteriler.ItemAppearance.Normal.Options.UseFont = true;
            this.BtnMusteriler.Name = "BtnMusteriler";
            this.BtnMusteriler.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnMusteriler_ItemClick);
            // 
            // BtnRaporlar
            // 
            resources.ApplyResources(this.BtnRaporlar, "BtnRaporlar");
            this.BtnRaporlar.Id = 5;
            this.BtnRaporlar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnRaporlar.ImageOptions.Image")));
            this.BtnRaporlar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnRaporlar.ImageOptions.LargeImage")));
            this.BtnRaporlar.ItemAppearance.Normal.Font = ((System.Drawing.Font)(resources.GetObject("BtnRaporlar.ItemAppearance.Normal.Font")));
            this.BtnRaporlar.ItemAppearance.Normal.Options.UseFont = true;
            this.BtnRaporlar.Name = "BtnRaporlar";
            this.BtnRaporlar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnRaporlar_ItemClick);
            // 
            // BtnStok
            // 
            resources.ApplyResources(this.BtnStok, "BtnStok");
            this.BtnStok.Id = 6;
            this.BtnStok.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnStok.ImageOptions.Image")));
            this.BtnStok.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnStok.ImageOptions.LargeImage")));
            this.BtnStok.ItemAppearance.Normal.Font = ((System.Drawing.Font)(resources.GetObject("BtnStok.ItemAppearance.Normal.Font")));
            this.BtnStok.ItemAppearance.Normal.Options.UseFont = true;
            this.BtnStok.Name = "BtnStok";
            this.BtnStok.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnStok_ItemClick);
            // 
            // barSubItem1
            // 
            resources.ApplyResources(this.barSubItem1, "barSubItem1");
            this.barSubItem1.Id = 1;
            this.barSubItem1.Name = "barSubItem1";
            // 
            // BtnBankalar
            // 
            resources.ApplyResources(this.BtnBankalar, "BtnBankalar");
            this.BtnBankalar.Id = 2;
            this.BtnBankalar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnBankalar.ImageOptions.Image")));
            this.BtnBankalar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnBankalar.ImageOptions.LargeImage")));
            this.BtnBankalar.ItemAppearance.Normal.Font = ((System.Drawing.Font)(resources.GetObject("BtnBankalar.ItemAppearance.Normal.Font")));
            this.BtnBankalar.ItemAppearance.Normal.Options.UseFont = true;
            this.BtnBankalar.Name = "BtnBankalar";
            this.BtnBankalar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnBankalar_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnAnaSayfa);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnSatis);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnUrunler);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnMusteriler);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnStok);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnBankalar);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnRaporlar);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // FrmBaslangic
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Name = "FrmBaslangic";
            this.ShowIcon = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmBaslangic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.BarButtonItem BtnAnaSayfa;
        private DevExpress.XtraBars.BarButtonItem BtnUrunler;
        private DevExpress.XtraBars.BarButtonItem BtnSatis;
        private DevExpress.XtraBars.BarButtonItem BtnMusteriler;
        private DevExpress.XtraBars.BarButtonItem BtnRaporlar;
        private DevExpress.XtraBars.BarButtonItem BtnStok;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem BtnBankalar;
    }
}

