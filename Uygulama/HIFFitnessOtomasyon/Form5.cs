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
namespace HIFFitnessOtomasyon
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        SqlConnection bag = new SqlConnection("Data Source=DESKTOP-B861SKJ\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True");
        private void Form5_Load(object sender, EventArgs e)
        {
            bag.Open();
            string sorgu = " select * from DondurulanUye";

            SqlCommand cmd = new SqlCommand(sorgu, bag);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bag.Close();
        }
        public void Kayit()
        {
            bag.Open();
            string dondurkayit = "insert into dbo.UYELER(AD,SOYAD,TC_NO,TEL_NO,E_MAIL,D_TARIHI,KAN_GRUBU,KAYIT_TARIHI,GUNCEL_TARIH) values (@ad,@soyad,@tc,@tel,@mail,@dtarih,@kan,@kayit,@guncel)";

            SqlCommand cmd = new SqlCommand(dondurkayit, bag);

            cmd.Parameters.AddWithValue("@ad", dataGridView1.CurrentRow.Cells[1].Value.ToString());
            cmd.Parameters.AddWithValue("@soyad", dataGridView1.CurrentRow.Cells[2].Value.ToString());
            cmd.Parameters.AddWithValue("@tc", dataGridView1.CurrentRow.Cells[3].Value);
            cmd.Parameters.AddWithValue("@tel", dataGridView1.CurrentRow.Cells[4].Value.ToString());
            cmd.Parameters.AddWithValue("@mail", dataGridView1.CurrentRow.Cells[5].Value);
            cmd.Parameters.AddWithValue("@dtarih", dataGridView1.CurrentRow.Cells[6].Value);
            cmd.Parameters.AddWithValue("@kan", dataGridView1.CurrentRow.Cells[7].Value);
            cmd.Parameters.AddWithValue("@kayit", dataGridView1.CurrentRow.Cells[8].Value);
            cmd.Parameters.AddWithValue("@guncel", dataGridView1.CurrentRow.Cells[9].Value);
            cmd.ExecuteNonQuery();
            bag.Close();


        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Seçilen üyenin kaydı geri gelecektir!. Devam Edilsin mi?", "UYARI", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    Kayit();
                    bag.Open();
                    string sil = "DELETE from DondurulanUye where ID='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                    SqlCommand komut = new SqlCommand(sil, bag);
                    komut.ExecuteNonQuery();
                    bag.Close();
                    MessageBox.Show("Geri alma işlemi Başarılı!");
                }
                else
                {
                    MessageBox.Show("Please select one row");
                }
            }
        }
    }
}
