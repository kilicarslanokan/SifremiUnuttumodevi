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
using System.Net.Mail;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net;

namespace ŞifremiUnuttum
{
    public partial class Form1 : Form
    {
        SqlConnection connect=new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=WindowsFormSifremiUnuttum;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string KullaniciAd = textBox1.Text;
            string Sifre = textBox2.Text;
            bool kayitliMi = false;

            connect.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Bilgi ", connect);
            SqlDataReader oku = komut.ExecuteReader();
            
            while (oku.Read())
            {
                if (KullaniciAd == oku["KullaniciAdi"].ToString() && Sifre == oku["Sifre"].ToString())
                {
                    kayitliMi=true;
                }
                else kayitliMi=false;
            } connect.Close();

            if(kayitliMi==true)
            {
                Form2 form2 = new Form2();
                form2.ShowDialog();
                this.Hide();
            }
            else MessageBox.Show("HATALI GİRİŞ YAPTINIZ!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
            this.Hide();
        }
    }
}
