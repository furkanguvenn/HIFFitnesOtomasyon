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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection bag = new SqlConnection("Data Source=DESKTOP-B861SKJ\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True");
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Bastir();
        }
        public void Bastir() {
            bag.Open();
            string listele = "select * from UYELER";


            SqlCommand komut = new SqlCommand(listele, bag);

            SqlDataAdapter da = new SqlDataAdapter(komut);
            ds = new DataSet();
            da.Fill(ds, "UYELER");
            dataGridView1.DataSource = ds.Tables["UYELER"];
            bag.Close();
            }
        private void button3_Click(object sender, EventArgs e)
        {
      
                    bag.Open();
            string sorgu =
       "Select * from UYELER where TC_NO Like '" + ara_txt.Text + "%' OR AD Like '" + ara_txt.Text + "%'";
           
            SqlCommand cmd = new SqlCommand(sorgu, bag);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    bag.Close();

                
            }
        DataSet ds;
       
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
            ad.Text = ds.Tables["UYELER"].Rows[e.RowIndex]["AD"].ToString();
            soyad.Text = ds.Tables["UYELER"].Rows[e.RowIndex]["SOYAD"].ToString();
            tcno.Text = ds.Tables["UYELER"].Rows[e.RowIndex]["TC_NO"].ToString();
            telefon.Text= ds.Tables["UYELER"].Rows[e.RowIndex]["TEL_NO"].ToString();
            mail.Text= ds.Tables["UYELER"].Rows[e.RowIndex]["E_MAIL"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bag.Open();
            string sorgu = "update UYELER set AD= '" + ad.Text + "', SOYAD = '" + soyad.Text + "', TC_NO = '" + tcno.Text + "', TEL_NO = '" + telefon.Text + "', E_MAIL = '" + mail.Text +  "' where ID = " + dataGridView1.CurrentRow.Cells[0].Value.ToString()  +"";
            
            SqlCommand cmd = new SqlCommand(sorgu, bag);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            
            bag.Close();
            Bastir();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
