using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
namespace SalonDeBelleza.Message
{
    class Emal
    {

        public string clientEmail { get; set; }
        public string clientName { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public string servicio { get; set; }

    public void SendEmail()
        {
            MailMessage mmsg = new MailMessage();
            mmsg.To.Add(clientEmail);
            mmsg.Subject = $"Hola {clientName}! Aqui esta tu cita!";//title

            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;
            // mmsg.Bcc.Add(txtBcc.Text);
            mmsg.Bcc.Add("memeyan1999@outlook.com");//the email that will send message

            mmsg.Body = $"El horario de tu servicio : ({servicio}) es en el dia : {fecha} y hora : {hora},nos vemos pronto!!";//contex
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true;



            mmsg.From = new MailAddress("memeyan1999@outlook.com");
            SmtpClient cliente = new SmtpClient();
            cliente.Credentials = new NetworkCredential("memeyan1999@outlook.com", "Zhuangzimo991218");


            cliente.Port = 587;
            cliente.EnableSsl = true;

            cliente.Host = "smtp-mail.outlook.com";

            try
            {
                cliente.Send(mmsg);
            }
            catch (Exception)
            {
                MessageBox.Show("Error al eviar");
            }
        }

    }
}


