using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalonDeBelleza.DataAccess;
using System.Data.SqlClient;
using SalonDeBelleza.Message;


namespace SalonDeBelleza.GUI
{
    public partial class Citas : Form
    {
        public Citas()
        {
            InitializeComponent();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Citas_Load(object sender, EventArgs e)
        {
            curdCita.CitaId = 0;
            Curd.ClientID = 0;
            FillDataGridView();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cbServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbServicio.Text == "PEDICURA CLÁSICA")
            {
                txtPrecio.Text = "200";
            }
            if (cbServicio.Text == "PEDICURA CLÁSICACUIDADOS DE LAS UÑAS")
            {
                txtPrecio.Text = "500";
            }
            if (cbServicio.Text == "REMOCIÓN DE SHELLAC")
            {
                txtPrecio.Text = "300";
            }
            if (cbServicio.Text == "CAMBIO DE ESMALTE")
            {
                txtPrecio.Text = "400";
            }
            if (cbServicio.Text == "CUIDADO DEL CABELLO")
            {
                txtPrecio.Text = "200";
            }
            if (cbServicio.Text == "CORTES DE PELO")
            {
                txtPrecio.Text = "150";
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }


        curd_cliente Curd = new curd_cliente();

        private void btnSaveClient_Click(object sender, EventArgs e)
        {
            
            Curd.btnSave = btnSaveClient.Text;
            Curd.ClientName = txtCliente.Text.Trim();
            Curd.ClienteApellido = txtApellido.Text.Trim();
            Curd.Age = txtEdad.Text.Trim();
            Curd.Email = txtEmail.Text.Trim();
            Curd.Number = txtNumero.Text.Trim();
          //  Curd.Estado = txt.Text.Trim();

            Curd.save();
            FillDataGridView();
            Reset();
        }
        void Reset()
        {
            txtApellido.Text = "";
            txtCliente.Text = "";
            txtEdad.Text = "";
            txtEmail.Text = "";
            txtNumero.Text = "";
            txtPrecio.Text = "";
            txtSearchClient.Text = "";
            
        }

        void FillDataGridView()
        {

            
           
            if (Curd.sqlCon.State == ConnectionState.Closed)
                Curd.sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("ViewClient", Curd.sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@ClientName", txtSearchClient.Text.Trim());
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            //dataGridView1.Columns[0].Visible = true;
            Curd.sqlCon.Close();
        }

        private void btnSearchC_Click(object sender, EventArgs e)
        {
            try
            {
                FillDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        private void txtSearchClient_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                Curd.ClientID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                txtCliente.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtApellido.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtEdad.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtEmail.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtNumero.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txtClientId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                // btnSave.Text = "Update";
                // btnDelet.Enabled = true;


            }
        }

        curd_cita curdCita = new curd_cita();

        private void BtnSaveCita_Click(object sender, EventArgs e)
        {
            curdCita.ClientId = int.Parse( txtClientId.Text);
            curdCita.btnSave = BtnSaveCita.Text;
            curdCita.btnName = txtApellido.Text;
            curdCita.btnDay = dateTimePicker1.Value.ToString();
            curdCita.btnHour = cbxHora.Text;
            curdCita.Precio = txtPrecio.Text;
            curdCita.ServiceName = cbServicio.Text;
            curdCita.Email = txtEmail.Text;
            curdCita.Numero = txtNumero.Text;



            curdCita.save();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtClientId_TextChanged(object sender, EventArgs e)
        {

        }

        void Disponibilidad()
        {

            if (Curd.sqlCon.State == ConnectionState.Closed)
                Curd.sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("Disponibilidad", Curd.sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@FechaDia", dateTimePicker1.Text);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            dataGridView2.DataSource = dtbl;
            //dataGridView1.Columns[0].Visible = true;
            Curd.sqlCon.Close();
        }

        private void btnSearchCita_Click(object sender, EventArgs e)
        {
            Disponibilidad();
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            curdCita.ClientId = int.Parse(txtClientId.Text);
            curdCita.btnSave = BtnSaveCita.Text;
            curdCita.btnName = txtCliente.Text;
            curdCita.btnDay = dateTimePicker1.Value.ToString();
            curdCita.btnHour = cbxHora.Text;
            curdCita.Precio = txtPrecio.Text;
            curdCita.ServiceName = cbServicio.Text;
            curdCita.Email = txtEmail.Text;
            curdCita.Numero = txtNumero.Text;



            curdCita.save();

            Emal Email = new Emal();

            Email.clientEmail = txtEmail.Text;
            Email.clientName = txtCliente.Text;
            Email.hora = cbxHora.Text;
            Email.servicio = cbServicio.Text;
            Email.fecha = dateTimePicker1.Text;
            Email.SendEmail();
           
        }
    }
}
