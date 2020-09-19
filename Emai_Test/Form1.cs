using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
namespace Emai_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MailMessage mmsg = new MailMessage();
            mmsg.To.Add(txtPara.Text);
            mmsg.Subject = txtAsunto.Text;

            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;
            // mmsg.Bcc.Add(txtBcc.Text);
            mmsg.Bcc.Add("memeyan1999@outlook.com");

            mmsg.Body = txtContexto.Text;
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true;



            mmsg.From = new MailAddress("memeyan1999@outlook.com");
            SmtpClient cliente = new SmtpClient();
            cliente.Credentials = new NetworkCredential("memeyan1999@outlook.com","Zhuangzimo991218");


            cliente.Port = 587;
            cliente.EnableSsl = true;

            cliente.Host = "smtp-mail.outlook.com";

            try
            {
                cliente.Send(mmsg);
            }
            catch(Exception)
            {
                MessageBox.Show("Error al eviar");
            }
        }
    }
}
