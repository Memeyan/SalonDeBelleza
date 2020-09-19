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
namespace SalonDeBelleza.GUI
{
    public partial class Ganancias : Form
    {
        public SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-TCRD6H0;Initial Catalog=SalonDeBelleza;Integrated Security=True");

        public Ganancias()
        {
            InitializeComponent();
        }

        private void Ganancias_Load(object sender, EventArgs e)
        {

        }

        public void buscar() 
        {

            SqlDataAdapter ad = new SqlDataAdapter("buscar", sqlCon);
            ad.SelectCommand.CommandType = CommandType.StoredProcedure;
            ad.SelectCommand.Parameters.Add("@fechaini", SqlDbType.DateTime).Value = dateStart.Text;
            ad.SelectCommand.Parameters.Add("@fechafinal", SqlDbType.DateTime).Value = dateEnd.Text;
            DataTable dt = new DataTable();
            ad.Fill(dt);
            this.dataGridView1.DataSource = dt;
        }
        private void ganancia_Click(object sender, EventArgs e)
        {
            buscar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);


            }
            textBox1.Text = sum.ToString();
        }

        private void dateEnd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            buscar();
        }
    }
}
