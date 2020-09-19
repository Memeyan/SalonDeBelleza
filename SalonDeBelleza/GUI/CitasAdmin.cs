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
using SalonDeBelleza.DataAccess;
namespace SalonDeBelleza.GUI
{
    public partial class CitasAdmin : Form
    {
        public CitasAdmin()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FillDataGridView();
        }
        curd_cita curdCita = new curd_cita();


        private void CitasAdmin_Load(object sender, EventArgs e)
        {
            FillDataGridView();
            curdCita.CitaId = 0;
        }

        void FillDataGridView()
        {
            //SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-H9C3U74;Initial Catalog=SalonDeBelleza;Integrated Security=True");
            if (curdCita.sqlCon.State == ConnectionState.Closed)
                curdCita.sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("SearchCita", curdCita.sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@ClientName", txtSearch.Text.Trim());
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            dataGridView1.Columns[0].Visible = false;
            curdCita.sqlCon.Close();
        }

        private void btnDelet_Click(object sender, EventArgs e)
        {

            curdCita.delete();
            FillDataGridView();
        }

        private void BtnSaveCita_Click(object sender, EventArgs e)
        {
            curdCita.ClientId = int.Parse(txtClientId.Text);
            curdCita.btnSave = BtnSaveCita.Text;
            curdCita.btnName = txtCliente.Text;
            curdCita.btnDay = txtDia.Text;
            curdCita.btnHour = txtHora.Text;
            curdCita.Precio = txtPrecio.Text;
            curdCita.ServiceName = txtServicio.Text;
            curdCita.Email = txtEmail.Text;
            curdCita.Numero = txtNumero.Text;
            curdCita.Asistencia = txtEstado_.Text;



            curdCita.save();
            FillDataGridView();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            curdCita.ClientId = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            txtClientId.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtCliente.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtDia.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtHora.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtPrecio.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtServicio.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtEmail.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtNumero.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txtEstado_.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();


            BtnSaveCita.Text = "Update";
            btnDelet.Enabled = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
