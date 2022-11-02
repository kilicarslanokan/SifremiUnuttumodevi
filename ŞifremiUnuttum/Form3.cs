using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ŞifremiUnuttum
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SmtpClient sc = new SmtpClient();
            sc.Port = 587;
            sc.Host = "smtp.gmail.com";
            sc.EnableSsl = true;
            sc.Credentials = new NetworkCredential("okan.kilicarslan5@gmail.com", "*****");

            string konu = "ŞİFRE HATIRLATMA";
            string icerik = "Şifreniz: 123";

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("okan.kilicarslan5@gmail.com", "Okan KILIÇARSLAN");
            mail.To.Add(textBox1.Text);
            mail.Subject = konu;
            mail.Body = icerik;
            sc.Send(mail);
        }
    }
}
