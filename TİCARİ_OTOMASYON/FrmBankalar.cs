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
    public partial class FrmBankalar : Form
    {
        public FrmBankalar()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();

        void temizle()
        {
            TxtAd.Text = "";
            TxtID.Text = "";
            TxtTutar.Text = "";
            MskAlim.Text = "";
            MskVerim.Text = "";
        }

        void listele()
        {
            DataTable dt= new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From BANKALAR Order by VerimTarihi Asc", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void FrmBankalar_Load(object sender, EventArgs e)
        {
            temizle();
            listele();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into BANKALAR (BankaAd,Tutar,AlimTarihi,VerimTarihi) values (@p1,@p2,@p3,@p4)",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", decimal.Parse(TxtTutar.Text));
            komut.Parameters.AddWithValue("@p3", DateTime.Parse(MskAlim.Text));
            komut.Parameters.AddWithValue("@p4", DateTime.Parse(MskVerim.Text));
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Banka Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            temizle();
            listele();
           
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                TxtID.Text = dr["ID"].ToString();
                TxtAd.Text = dr["BankaAd"].ToString();
                TxtTutar.Text = dr["Tutar"].ToString();
                MskAlim.Text = dr["AlimTarihi"].ToString();
                MskVerim.Text = dr["VerimTarihi"].ToString();
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from BANKALAR where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Banka Silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            temizle();
            listele();
            
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update BANKALAR set BankaAd=@p1, Tutar=@p2, AlimTarihi=@p3, VerimTarihi=@p4 where ID=@p5", bgl.baglanti());
            komut.Parameters.AddWithValue("@p5", TxtID.Text);
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", decimal.Parse(TxtTutar.Text));
            komut.Parameters.AddWithValue("@p3", DateTime.Parse(MskAlim.Text));
            komut.Parameters.AddWithValue("@p4", DateTime.Parse(MskVerim.Text));
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Banka Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            temizle();
            listele();
            
        }

        private void TxtID_EditValueChanged(object sender, EventArgs e)
        {
            if (TxtID.Text == "")
            {
                TxtAd.Text = "";
                TxtTutar.Text = "";
                MskAlim.Text = "";
                MskVerim.Text = "";
            }
            
        }
    }
}
