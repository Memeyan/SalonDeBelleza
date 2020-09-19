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
using System.Data;

namespace Test
{
    public partial class Form1 : Form
    {
        public SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-H9C3U74;Initial Catalog=SalonDeBelleza;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        public void buscar()
        {
            SqlDataAdapter ad = new SqlDataAdapter("buscar", sqlCon);
            ad.SelectCommand.CommandType = CommandType.StoredProcedure;
            ad.SelectCommand.Parameters.Add("@fechaini", SqlDbType.DateTime).Value = dateTimePicker1.Text;
            ad.SelectCommand.Parameters.Add("@fechafinal", SqlDbType.DateTime).Value = dateTimePicker2.Text;
            DataTable dt = new DataTable();
            ad.Fill(dt);
            this.dataGridView1.DataSource = dt;


        }

        private void button1_Click(object sender, EventArgs e)
        {

            
                buscar();
            

        }
        private void button2_Click(object sender, EventArgs e)
        {
            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++ )
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);


            }
            textBox1.Text = sum.ToString();
        }
    }
}
