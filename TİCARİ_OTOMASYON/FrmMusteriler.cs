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
    public partial class FrmMusteriler : Form
    {
        public FrmMusteriler()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();

        void temizle()
        {
            TxtAd.Text = "";
            TxtID.Text = "";
            TxtSoyad.Text = "";
            MskTel.Text = "";
            RchAdres.Text = "";
        }

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From MUSTERİLER Order by Ad Asc", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void FrmMusteriler_Load(object sender, EventArgs e)
        {
            temizle();
            listele();
        }

        bool durum;
        void barkodkontrol()
        {
            durum = true;
            SqlCommand komut = new SqlCommand("Select * from MUSTERİLER", bgl.baglanti());
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (TxtAd.Text == read["Ad"].ToString())
                {
                    if (TxtSoyad.Text == read["Soyad"].ToString())
                    {
                        if (MskTel.Text == read["Telefon"].ToString())
                        {
                            if (RchAdres.Text == read["Adres"].ToString())
                            {
                                durum = false;
                            }
                        }
                    }
                }
            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            barkodkontrol();
            if (durum == true)
            {
                SqlCommand komut = new SqlCommand("insert into MUSTERİLER (Ad, Soyad, Telefon, Adres) values (@p1,@p2,@p3,@p4)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtAd.Text);
                komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
                komut.Parameters.AddWithValue("@p3", MskTel.Text);
                komut.Parameters.AddWithValue("@p4", RchAdres.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Müşteri Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                temizle();
                listele();
            }
            else
            {
                MessageBox.Show("Bu bilgilere ait müşteri var.Güncelleme yapabilirsiniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            
            
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                TxtID.Text = dr["ID"].ToString();
                TxtAd.Text = dr["Ad"].ToString();
                TxtSoyad.Text = dr["Soyad"].ToString();
                MskTel.Text = dr["Telefon"].ToString();
                RchAdres.Text = dr["Adres"].ToString();
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from MUSTERİLER where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri Silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            temizle();
            listele();
            
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update MUSTERİLER set Ad=@p1,Soyad=@p2,Telefon=@p3,Adres=@p4 where ID=@p5", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", MskTel.Text);
            komut.Parameters.AddWithValue("@p4", RchAdres.Text);
            komut.Parameters.AddWithValue("@p5", TxtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            temizle();
            listele();
            
        }

        private void TxtAd_EditValueChanged(object sender, EventArgs e)
        {
            if (TxtAd.Text == "")
            {
                TxtAd.Text = "";
                TxtID.Text = "";
                TxtSoyad.Text = "";
                MskTel.Text = "";
                RchAdres.Text = "";
            }
            SqlCommand komut = new SqlCommand("select * From MUSTERİLER where Ad like '" + TxtAd.Text + "'", bgl.baglanti());
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                TxtAd.Text = read["Ad"].ToString();
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

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmMusteriDetay fr = new FrmMusteriDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                fr.ID = dr["ID"].ToString();
            }
            fr.Show();
        }

        private void TxtID_EditValueChanged(object sender, EventArgs e)
        {
            if (TxtID.Text == "")
            {
                TxtAd.Text = "";
                TxtID.Text = "";
                TxtSoyad.Text = "";
                MskTel.Text = "";
                RchAdres.Text = "";
            }
            SqlCommand komut = new SqlCommand("select * From MUSTERİLER where Ad like '" + TxtAd.Text + "'", bgl.baglanti());
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                TxtAd.Text = read["Ad"].ToString();
                TxtID.Text = read["ID"].ToString();
                TxtSoyad.Text = read["Soyad"].ToString();
                MskTel.Text = read["Telefon"].ToString();
                RchAdres.Text = read["Adres"].ToString();
            }
            bgl.baglanti().Close();
        }
    }
}
