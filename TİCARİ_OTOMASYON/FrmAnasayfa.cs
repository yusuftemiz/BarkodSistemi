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

namespace TİCARİ_OTOMASYON
{
    public partial class FrmAnasayfa : Form
    {
        public FrmAnasayfa()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();
        
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Sepet", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            gridView1.Columns["Kazanc"].Visible = false;
            gridView1.Columns["Kazancım"].Visible = false;
        }

        void temizle()
        {
            TxtBarkod.Text = "";
            LblFiyat.Text = "0,00";
            TxtAd.Text = "";
            TxtAdet.Text = "1";
            TxtID.Text = "";
            TxtMAd.Text = "";
            TxtSoyad.Text = "";
            MskTel.Text = "";
            RchAdres.Text = "";
        }

        void hesapla()
        {
            SqlCommand komut = new SqlCommand("select sum(ToplamFiyat) from SEPET", bgl.baglanti());
            lblTFiyat.Text = komut.ExecuteScalar() + " TL";
            bgl.baglanti().Close();
        }

        void stoklistele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select UrunAdı,Adet from STOK where Adet<=10 order by Adet", bgl.baglanti());
            da.Fill(dt);
            gridStok.DataSource = dt;
            
        }
        
        void bankalistele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select BankaAd,Tutar,VerimTarihi from BANKALAR where VerimTarihi >= '"+ DateTime.Now.ToString("s") + "' order by VerimTarihi", bgl.baglanti());
            da.Fill(dt);
            gridBanka.DataSource = dt;
            SqlCommand komut = new SqlCommand("select *from BANKALAR where VerimTarihi='" + DateTime.Today.AddDays(1).ToString("s") + "'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                MessageBox.Show("YARIN ÖDEME VAR!", "Yaklaşan Banka Ödemesi!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            bgl.baglanti().Close();
        }

        void istatistik()
        {
            SqlCommand komut = new SqlCommand("select sum(Adet),sum(ToplamFiyat),sum(Kazancım) from SATİSLİSTESİ where Tarih>'" + DateTime.Now.AddDays(-1).ToString("s") + "'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                BugunStok.Text = dr[0].ToString();
                BugunTSatis.Text = dr[1].ToString();
                BugunKazanc.Text = dr[2].ToString();
            }
            bgl.baglanti().Close();
        }

        private void FrmAnasayfa_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
            stoklistele();
            bankalistele();
            istatistik();
            SqlCommand komut = new SqlCommand("select *from STOK where Adet<4", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                MessageBox.Show("3'ten Az Ürün Var.Stok Durumunu Kontrol et!", "Stok Uyarısı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            bgl.baglanti().Close();
        }

        private void TxtBarkod_EditValueChanged(object sender, EventArgs e)
        {
            if (TxtBarkod.Text == "")
            {
                TxtAd.Text = "";
                LblFiyat.Text = "0,00";
            }
            SqlCommand komut = new SqlCommand("select * From URUNLER where BARKOD like '" + TxtBarkod.Text + "'", bgl.baglanti());
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                TxtAd.Text = read["URUNAD"].ToString();
                LblFiyat.Text = read["SATIŞFİYAT"].ToString();
                lblKazanc.Text = read["KAZANC"].ToString();
            }
            bgl.baglanti().Close();
        }

        private void TxtMAd_EditValueChanged(object sender, EventArgs e)
        {
            if(TxtMAd.Text == "")
            {
                TxtMAd.Text = "";
                TxtID.Text = "";
                TxtSoyad.Text = "";
                MskTel.Text = "";
                RchAdres.Text = "";
            }
            SqlCommand komut = new SqlCommand("select * From MUSTERİLER where Ad like '" + TxtMAd.Text + "'", bgl.baglanti());
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                TxtMAd.Text = read["Ad"].ToString();
                TxtID.Text = read["ID"].ToString();
                TxtSoyad.Text = read["Soyad"].ToString();
                MskTel.Text = read["Telefon"].ToString();
                RchAdres.Text = read["Adres"].ToString();
            }
            bgl.baglanti().Close();
        }

        private void TxtSoyad_EditValueChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * From MUSTERİLER where Soyad like '" + TxtSoyad.Text + "'", bgl.baglanti());
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                TxtID.Text = read["ID"].ToString();
                TxtSoyad.Text = read["Soyad"].ToString();
                MskTel.Text = read["Telefon"].ToString();
                RchAdres.Text = read["Adres"].ToString();
            }
            bgl.baglanti().Close();
        }

        bool durum;
        void barkodkontrol()
        {
            durum = true;
            SqlCommand komut = new SqlCommand("Select * from SEPET", bgl.baglanti());
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (TxtBarkod.Text == read["Barkod"].ToString())
                {
                    durum = false;
                }
            }
        }

        bool durumv,durums;
        void stokdurum()
        {
            durumv = true;
            durums = true;
            SqlCommand komut0 = new SqlCommand("Select * from STOK", bgl.baglanti());
            SqlDataReader read = komut0.ExecuteReader();
            while (read.Read())
            {
                if (TxtBarkod.Text == read["Barkod"].ToString())
                {
                    durumv = false;
                }
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (TxtBarkod.Text == gridView1.GetRowCellValue(i, "Barkod").ToString())
                    {
                        if (TxtBarkod.Text == read["Barkod"].ToString())
                        {
                            if (int.Parse(read["Adet"].ToString()) == int.Parse(gridView1.GetRowCellValue(i, "Adet").ToString()))
                            {
                                durums = false;
                            }
                            if (int.Parse(read["Adet"].ToString()) == 0){
                                durums = false;
                            }
                        }
                    }
                }

                if (TxtBarkod.Text == read["Barkod"].ToString())
                {
                    if (int.Parse(read["Adet"].ToString()) == 0)
                    {
                        durums = false;
                    }
                }

                }
        }
        
        private void BtnEkle_Click(object sender, EventArgs e)
        {
            barkodkontrol();
            stokdurum();
            if (durumv == false && durums == true)
            {
                if (durum == true)
                {
                    SqlCommand komut = new SqlCommand("insert into SEPET(Tarih,Barkod,UrunAd,Adet,SatisFiyati,ToplamFiyat,Kazanc,Kazancım) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", DateTime.Now.ToString("s"));
                    komut.Parameters.AddWithValue("@p2", TxtBarkod.Text);
                    komut.Parameters.AddWithValue("@p3", TxtAd.Text);
                    komut.Parameters.AddWithValue("@p4", int.Parse(TxtAdet.Text));
                    komut.Parameters.AddWithValue("@p5", decimal.Parse(LblFiyat.Text));
                    komut.Parameters.AddWithValue("@p6", decimal.Parse(LblFiyat.Text) * decimal.Parse(TxtAdet.Text));
                    komut.Parameters.AddWithValue("@p7", (decimal.Parse(lblKazanc.Text) * decimal.Parse(TxtAdet.Text)));
                    komut.Parameters.AddWithValue("@p8", (decimal.Parse(lblKazanc.Text) * decimal.Parse(TxtAdet.Text)));
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }
                else
                {
                    SqlCommand komut2 = new SqlCommand("update SEPET set Adet = (Adet +'" + int.Parse(TxtAdet.Text) + "') where Barkod='" + TxtBarkod.Text + "'", bgl.baglanti());
                    komut2.ExecuteNonQuery();
                    SqlCommand komut3 = new SqlCommand("update SEPET set ToplamFiyat = Adet * SatisFiyati where Barkod='" + TxtBarkod.Text + "'", bgl.baglanti());
                    komut3.ExecuteNonQuery();
                    SqlCommand komut4 = new SqlCommand("update SEPET set Kazancım = (Kazanc * Adet) where Barkod='" + TxtBarkod.Text + "'", bgl.baglanti());
                    komut4.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }
            }
            if (durumv == true)
            {
                MessageBox.Show("Stokta bu barkoda ait bir ürün bulunmuyor.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                
            }
            if (durums == false)
            {
                MessageBox.Show("Stokta bu barkoda ait ürün kalmadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            
            TxtAdet.Text = "1";
            hesapla();
            listele();
            temizle();
            
        }
        
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from SEPET where Barkod='" +gridView1.GetFocusedRowCellValue("Barkod").ToString()+ "'", bgl.baglanti());
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Sepetten Çıkarıldı","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            listele();
            temizle();
            hesapla();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from SEPET ", bgl.baglanti());
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Sepet Temizlendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
            temizle();
            hesapla();
        }

        private void FrmAnasayfa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                simpleButton3.PerformClick();
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < gridView1.RowCount; i++)
            {
                SqlCommand komut = new SqlCommand("insert into SATİSLİSTESİ(Tarih,Barkod,UrunAd,Adet,SatisFiyati,ToplamFiyat,MusteriID,Ad,Soyad,Telefon,Adres,Kazancım) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", DateTime.Now.ToString("s"));
                komut.Parameters.AddWithValue("@p2", gridView1.GetRowCellValue(i,"Barkod").ToString());
                komut.Parameters.AddWithValue("@p3", gridView1.GetRowCellValue(i, "UrunAd").ToString());
                komut.Parameters.AddWithValue("@p4", int.Parse(gridView1.GetRowCellValue(i, "Adet").ToString()));
                komut.Parameters.AddWithValue("@p5", decimal.Parse(gridView1.GetRowCellValue(i, "SatisFiyati").ToString()));
                komut.Parameters.AddWithValue("@p6", decimal.Parse(gridView1.GetRowCellValue(i, "ToplamFiyat").ToString()));
                komut.Parameters.AddWithValue("@p7", TxtID.Text);
                komut.Parameters.AddWithValue("@p8", TxtMAd.Text);
                komut.Parameters.AddWithValue("@p9", TxtSoyad.Text);
                komut.Parameters.AddWithValue("@p10", MskTel.Text);
                komut.Parameters.AddWithValue("@p11", RchAdres.Text);
                komut.Parameters.AddWithValue("@p12", decimal.Parse(gridView1.GetRowCellValue(i, "Kazancım").ToString()));
                komut.ExecuteNonQuery();
                SqlCommand komut2 = new SqlCommand("update stok set Adet=Adet-'" + gridView1.GetRowCellValue(i, "Adet").ToString() + "' where Barkod= '" + gridView1.GetRowCellValue(i, "Barkod").ToString() + "'", bgl.baglanti());
                komut2.ExecuteNonQuery();
                
            }
            SqlCommand komut3 = new SqlCommand("delete from SEPET ", bgl.baglanti());
            komut3.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Satış Gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            hesapla();
            listele();
            stoklistele();
            istatistik();
            temizle();
        }
    }
}
