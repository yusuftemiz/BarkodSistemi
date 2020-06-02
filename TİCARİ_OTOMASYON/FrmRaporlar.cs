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
    public partial class FrmRaporlar : Form
    {
        public FrmRaporlar()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();

        void dun()
        {
            SqlCommand komut = new SqlCommand("select sum(Adet),sum(ToplamFiyat),sum(Kazancım) from SATİSLİSTESİ where Tarih<'"+ DateTime.Now.AddDays(-1).ToString("s") + "' and  Tarih>'" + DateTime.Now.AddDays(-3).ToString("s") + "'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                DunStok.Text = dr[0].ToString();
                DunTSatis.Text = dr[1].ToString();
                DunKazanc.Text = dr[2].ToString();
            }
            bgl.baglanti().Close();
        }

        void bugun()
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

        void ay()
        {
            SqlCommand komut = new SqlCommand("select sum(Adet),sum(ToplamFiyat),sum(Kazancım) from SATİSLİSTESİ where Tarih<'" + DateTime.Today.AddDays(-30).ToString("s") + "'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                BAyStok.Text = dr[0].ToString();
                BAyTSatis.Text = dr[1].ToString();
                BAyKazanc.Text = dr[2].ToString();
            }
            bgl.baglanti().Close();
        }

        private void FrmRaporlar_Load(object sender, EventArgs e)
        {
            
            dun();
            bugun();
            ay();
        }
    }
}
