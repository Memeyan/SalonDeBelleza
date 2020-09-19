using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalonDeBelleza.Common;
using SalonDeBelleza.GUI;
using System.Runtime.InteropServices;

namespace SalonDeBelleza
{
    public partial class FormPrincipal : Form
    {

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public FormPrincipal()
        {
            InitializeComponent();
        }
        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = panelMostrar.Controls.OfType<MiForm>().FirstOrDefault();//Busca en la colecion el formulario
                                                                                     //si el formulario/instancia no existe
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelMostrar.Controls.Add(formulario);
                panelMostrar.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
            }
            //si el formulario/instancia existe
            else
            {
                formulario.BringToFront();
            }
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            if(Common.UserLoginCache.UserType == Common.Position.Empleado)
            {
                bunifuFlatButton4.Enabled = false;
            }
        }

        private void btnadmin_Click(object sender, EventArgs e)
        {
            /*Administrar admin = new Administrar();
            admin.Show();*/
            AbrirFormulario<GUI.Administrar>();
        }

        private void btncitas_Click(object sender, EventArgs e)
        {
            /*Citas citas = new Citas();
            citas.Show();*/
            AbrirFormulario<GUI.Citas>();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to log out?", "Warning",
          MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                this.Close();
                Form1 main = new Form1();
                main.Show();
            }

                
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnganancia_Click(object sender, EventArgs e)
        {
            AbrirFormulario<GUI.Ganancias>();
        }

        private void Cliente_Click(object sender, EventArgs e)
        {
            AbrirFormulario<GUI.Clientes>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormulario<GUI.CitasAdmin>();
        }

        private void panelMostrar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure to log out?", "Warning",
          MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
                Form1 main = new Form1();
                main.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AbrirFormulario<GUI.Ganancias>();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrirFormulario<GUI.Administrar>();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario<GUI.Citas>();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario<GUI.CitasAdmin>();

        }

        private void btnadmin_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario<GUI.Clientes>();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            Restaurar.Visible = false;
            Maximizar.Visible = true;

        }

        private void Maximizar_Click(object sender, EventArgs e)
        {
            
            WindowState = FormWindowState.Maximized;
            Maximizar.Visible = false;
            Restaurar.Visible = true;

        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            AbrirFormulario<GUI.Citas>();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            AbrirFormulario<GUI.CitasAdmin>();

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            AbrirFormulario<GUI.Clientes>();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            AbrirFormulario<GUI.Administrar>();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            AbrirFormulario<GUI.Ganancias>();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to log out?", "Warning",
          MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
                Form1 main = new Form1();
                main.Show();
            }
        }

        private void bunifuFlatButton4_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario<GUI.Administrar>();
        }

        private void bunifuFlatButton3_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario<GUI.Clientes>();
        }

        private void bunifuFlatButton5_Click_1(object sender, EventArgs e)
        {

            AbrirFormulario<GUI.Ganancias>();
        }

        private void bunifuFlatButton6_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to log out?", "Warning",
          MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
                Form1 main = new Form1();
                main.Show();
            }
        }

        private void panelMostrar_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panelMostrar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 250)
            {
                MenuVertical.Visible = false;
                MenuVertical.Width = 45;
                Linea.Width = 25;
                bunifuTransition1.Show(MenuVertical);
            }

            else
            {
                MenuVertical.Visible = false;
                MenuVertical.Width = 250;
                Linea.Width = 224;
                bunifuTransition2.Show(MenuVertical);
            }
        }
    }
}
