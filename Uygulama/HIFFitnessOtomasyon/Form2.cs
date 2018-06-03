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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection bag = new SqlConnection("Data Source=DESKTOP-B861SKJ\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True");
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label8.Text = DateTime.Now.ToLongDateString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kayit = "insert into UYELER(AD,SOYAD,TC_NO,TEL_NO,E_MAIL,D_TARIHI,KAN_GRUBU,KAYIT_TARIHI,GUNCEL_TARIH) VALUES (@ad,@soyad,@tc,@tel,@mail,@dtarih,@kan,@kayit,@guncel)";
           
            SqlCommand komut = new SqlCommand(kayit, bag);
            bag.Open();

           
            komut.Parameters.AddWithValue("@ad", ad.Text);
            komut.Parameters.AddWithValue("@soyad", soyad.Text);
            komut.Parameters.AddWithValue("@tc", tcno.Text);
            komut.Parameters.AddWithValue("@tel", telefon.Text);
            komut.Parameters.AddWithValue("@mail", email.Text);
            komut.Parameters.AddWithValue("@dtarih",this.dateTimePicker1.Text);
            komut.Parameters.AddWithValue("@kan", cmb_Kan.SelectedItem);
            komut.Parameters.AddWithValue("@kayit", this.dateTimePicker2.Text);
            komut.Parameters.AddWithValue("@guncel", this.dateTimePicker2.Text);


            komut.ExecuteNonQuery();

            bag.Close();
            MessageBox.Show("kayıt başarılı");
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ad.Clear();
            soyad.Clear();
            tcno.Clear();
            telefon.Clear();
            email.Clear();
            
        }
    }
}
