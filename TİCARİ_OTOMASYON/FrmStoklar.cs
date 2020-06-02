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
    public partial class FrmStoklar : Form
    {
        public FrmStoklar()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();

        void temizle()
        {
            TxtAd.Text = "";
            TxtAdet.Text = "";
            TxtBarkod.Text = "";
        }

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From STOK", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void FrmStoklar_Load(object sender, EventArgs e)
        {
            listele();

            temizle();
        }

        private void TxtBarkod_EditValueChanged(object sender, EventArgs e)
        {
            if (TxtBarkod.Text == "")
            {
                TxtAd.Text = "";
                TxtAdet.Text = "";
            }
            SqlCommand komut = new SqlCommand("select * From URUNLER where BARKOD like '" + TxtBarkod.Text + "'", bgl.baglanti());
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                TxtAd.Text = read["URUNAD"].ToString();
            }
            bgl.baglanti().Close();
        }

        bool durum;
        void barkodkontrol()
        {
            durum = true;
            SqlCommand komut = new SqlCommand("Select * from STOK", bgl.baglanti());
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (TxtBarkod.Text == read["Barkod"].ToString())
                {
                    durum = false;
                }
            }
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            barkodkontrol();
            if (durum == true)
            {
                MessageBox.Show("Bu barkodlu ürün yok.Lütfen ürünler sayfasından kaydediniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            else
            {
                SqlCommand komut2 = new SqlCommand("update STOK set Adet = (Adet +'" + int.Parse(TxtAdet.Text) + "') where Barkod='" + TxtBarkod.Text + "'", bgl.baglanti());
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Stok Eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                temizle();
                listele();
            }
            
            
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            barkodkontrol();
            if (durum == true)
            {
                MessageBox.Show("Stokta bu barkodlu ürün yok.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlCommand komut2 = new SqlCommand("update STOK set Adet = (Adet -'" + int.Parse(TxtAdet.Text) + "') where Barkod='" + TxtBarkod.Text + "'", bgl.baglanti());
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Stok Silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            temizle();
            listele();
            
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            TxtBarkod.Text = dr["Barkod"].ToString();
            TxtAd.Text = dr["UrunAdı"].ToString();
            TxtAdet.Text = dr["Adet"].ToString();
        }
    }
}
