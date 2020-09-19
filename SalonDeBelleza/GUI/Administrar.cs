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
    public partial class Administrar : Form
    {
        public Administrar()
        {
            InitializeComponent();
        }
        CURD curd = new CURD();
        
       
        private void Administrar_Load(object sender, EventArgs e)
        {
            
            FillDataGridView();
            curd.userId = 0;

           // curd.FillDataGridView();
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            curd.btnSave = btnSave.Text;
            curd.Password = txtPass.Text.Trim();
            curd.UserName = txtUser.Text.Trim();
            curd.UserType = txtType_.Text.Trim();
            curd.save();
            FillDataGridView();
            Reset();
        }



        void FillDataGridView()
        {
            //SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-H9C3U74;Initial Catalog=SalonDeBelleza;Integrated Security=True");
            if (curd.sqlCon.State == ConnectionState.Closed)
                curd.sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("ViewAndSearch", curd.sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@UserName", txtSearch.Text.Trim());
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            dataGridView1.Columns[0].Visible = false;
            curd.sqlCon.Close();
        }

        void Reset()
        {
            txtPass.Text = txtType_.Text = txtUser.Text = "";
            btnSave.Text = "Save";
            curd.userId = 0;
            btnDelet.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
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

        private void btnDelet_Click(object sender, EventArgs e)
        {
            curd.delete();
            FillDataGridView();
            Reset();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentRow.Index != -1)
            {
                curd.userId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                txtUser.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtPass.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtType_.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                btnSave.Text = "Update";
                btnDelet.Enabled = true;

            
            }

        }       
    }
}
