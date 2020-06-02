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
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();

        void temizle()
        {
            TxtAd.Text = "";
            TxtAlis.Text = "";
            TxtBarkod.Text = "";
            TxtKdv.Text = "";
            TxtSatis.Text = "";
        }

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From URUNLER Order by URUNAD Asc", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            temizle();
            listele();

            
        }

        bool durum;
        void barkodkontrol()
        {
            durum = true;
            SqlCommand komut = new SqlCommand("Select * from URUNLER", bgl.baglanti());
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (TxtBarkod.Text == read["BARKOD"].ToString())
                {
                    durum = false;
                }
            }
        }
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            barkodkontrol();
            if (durum == true)
            {
                SqlCommand komut = new SqlCommand("insert into URUNLER(BARKOD,URUNAD,ALIŞFİYAT,SATIŞFİYAT,KDV,KAZANC) values (@p1,@p2,@p3,@p4,@p5,@P6)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtBarkod.Text);
                komut.Parameters.AddWithValue("@p2", TxtAd.Text);
                komut.Parameters.AddWithValue("@p3", decimal.Parse(TxtAlis.Text));
                komut.Parameters.AddWithValue("@p4", decimal.Parse(TxtSatis.Text));
                komut.Parameters.AddWithValue("@p5", decimal.Parse(TxtKdv.Text));
                komut.Parameters.AddWithValue("@p6", decimal.Parse(TxtSatis.Text)-decimal.Parse(TxtAlis.Text));
                komut.ExecuteNonQuery();
                SqlCommand komut2 = new SqlCommand("insert into STOK(Barkod,UrunAdı,Adet) values (@p1,@p2,@p3)", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", TxtBarkod.Text);
                komut2.Parameters.AddWithValue("@p2", TxtAd.Text);
                komut2.Parameters.AddWithValue("@p3", 0);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Ürün Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
                temizle();
            }
            else
            {
                MessageBox.Show("Bu barkoda ait ürün var.Güncelleme yapabilirsiniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete From URUNLER where BARKOD=@p1", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@p1", TxtBarkod.Text);
            
            SqlCommand komutsil1 = new SqlCommand("Delete From STOK where Barkod=@p1", bgl.baglanti());
            komutsil1.Parameters.AddWithValue("@p1", TxtBarkod.Text);
            komutsil.ExecuteNonQuery();
            komutsil1.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            temizle();
            listele();
            
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            TxtBarkod.Text = dr["BARKOD"].ToString();
            TxtAd.Text = dr["URUNAD"].ToString();
            TxtAlis.Text = dr["ALIŞFİYAT"].ToString();
            TxtSatis.Text = dr["SATIŞFİYAT"].ToString();
            TxtKdv.Text = dr["KDV"].ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update URUNLER set URUNAD=@p1, ALIŞFİYAT=@p2, SATIŞFİYAT=@p3, KDV=@p4, KAZANC=@p6 where BARKOD=@p5", bgl.baglanti());
            komut.Parameters.AddWithValue("@p5", TxtBarkod.Text);
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", decimal.Parse(TxtAlis.Text));
            komut.Parameters.AddWithValue("@p3", decimal.Parse(TxtSatis.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse(TxtKdv.Text));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(TxtSatis.Text)-decimal.Parse(TxtAlis.Text));
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            temizle();
            listele();
            
        }

        private void TxtBarkod_EditValueChanged(object sender, EventArgs e)
        {
            if (TxtBarkod.Text == "")
            {
                TxtAd.Text = "";
                TxtAlis.Text = "";
                TxtSatis.Text = "";
                TxtKdv.Text = "";
            }
            SqlCommand komut = new SqlCommand("select * From URUNLER where BARKOD like '" + TxtBarkod.Text + "'", bgl.baglanti());
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                TxtAd.Text = read["URUNAD"].ToString();
                TxtAlis.Text = read["ALIŞFİYAT"].ToString();
                TxtSatis.Text = read["SATIŞFİYAT"].ToString();
                TxtKdv.Text = read["KDV"].ToString();
            }
            bgl.baglanti().Close();
        }
    }
}
