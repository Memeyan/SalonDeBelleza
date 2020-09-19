using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalonDeBelleza.GUI;
using SalonDeBelleza.Common;
using SalonDeBelleza.Domain;
using SalonDeBelleza.DataAccess;
using SalonDeBelleza;
using System.Runtime.InteropServices;
namespace SalonDeBelleza
{
    public partial class Form1 : Form
    {


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
         
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtuser_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserModel user = new UserModel();
            var validLogin = user.LoginUser(txtuser.Text, txtpass.Text);
            if (validLogin == true)
            {
                FormPrincipal mainMenu = new FormPrincipal();
                mainMenu.Show();
                //mainMenu.FormClosed += Logout;
                this.Hide();
            }
            else
            {
                // msgError("Incorrect username or password entered \n Please try again");
                txtpass.Clear();
                txtuser.Clear();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
