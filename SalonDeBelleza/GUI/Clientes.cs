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
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        curd_cliente Curd = new curd_cliente();
        private void Clientes_Load(object sender, EventArgs e)
        {
            Curd.ClientID = 0;
            FillDataGridView_1();
        }
        

        void Reset()
        {
            txtApellido.Text = "";
            txtCliente.Text = "";
            txtEdad.Text = "";
            txtEmail.Text = "";
            txtNumero.Text = "";
            txtEstado_.Text = "";
            txtSearch.Text = "";

            btnSaveClient.Text = "Guardar";
            Curd.ClientID = 0;
            btnDelet.Enabled = false;
        }


        void FillDataGridView_1()
        {
            if (Curd.sqlCon.State == ConnectionState.Closed)
                Curd.sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("ViewClient", Curd.sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@ClientName", txtSearch.Text.Trim());
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            dataGridView1.Columns[0].Visible = false;
            Curd.sqlCon.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Curd.btnSave = btnSaveClient.Text;
            Curd.ClientName = txtCliente.Text.Trim();
            Curd.ClienteApellido = txtApellido.Text.Trim();
            Curd.Age = txtEdad.Text.Trim();
            Curd.Email = txtEmail.Text.Trim();
            Curd.Number = txtNumero.Text.Trim();
            Curd.Estado = txtEstado_.Text.Trim();

            Curd.saveAndEdit();
            FillDataGridView_1();
            Reset();
        }

        private void btnDelet_Click(object sender, EventArgs e)
        {
            Curd.delete();
            FillDataGridView_1();
            Reset();
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
                txtEstado_.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

                btnSaveClient.Text = "Update";
                btnDelet.Enabled = true;


            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                FillDataGridView_1();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }
    }
}
