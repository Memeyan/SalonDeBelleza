using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
namespace SalonDeBelleza.DataAccess
{
    class curd_cita : ConnectionToSql
    {

        public string btnSave { get; set; }
        public string btnName { get; set; }
        public string btnDay { get; set; }
        public string btnHour { get; set; }
        public int CitaId { get; set; }
        public int ClientId { get; set; }

        public string Precio { get; set; }
        public string ServiceName { get; set; }
        public string Email { get; set; }
        public string Numero { get; set; }
        public string Asistencia { get; set; }



        public void save()
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                if (btnSave == "Guardar Cita")
                {
                    SqlCommand sqlCmd = new SqlCommand("AddOrEditCita", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@mode", "Add");
                    sqlCmd.Parameters.AddWithValue("@ClientId", ClientId);
                    sqlCmd.Parameters.AddWithValue("@CitaId", 0);
                    sqlCmd.Parameters.AddWithValue("@ClientName", btnName);
                    sqlCmd.Parameters.AddWithValue("@FechaDia", btnDay);
                    sqlCmd.Parameters.AddWithValue("@FechaHora", btnHour);
                    sqlCmd.Parameters.AddWithValue("@Precio", Precio);
                    sqlCmd.Parameters.AddWithValue("@ServiceName", ServiceName);
                    sqlCmd.Parameters.AddWithValue("@Email", Email);
                    sqlCmd.Parameters.AddWithValue("@Numero", Numero);
                    sqlCmd.Parameters.AddWithValue("@Asistencia", "Todavia");




                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Saved successfully");
                }
                if (btnSave == "Update")
                {
                    SqlCommand sqlCmd = new SqlCommand("AddOrEditCita", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@mode", "Edit");
                    sqlCmd.Parameters.AddWithValue("@CitaId", CitaId);
                    sqlCmd.Parameters.AddWithValue("@ClientId", ClientId);
                    sqlCmd.Parameters.AddWithValue("@ClientName", btnName);
                    sqlCmd.Parameters.AddWithValue("@FechaDia", btnDay);
                    sqlCmd.Parameters.AddWithValue("@FechaHora", btnHour);
                    sqlCmd.Parameters.AddWithValue("@Precio", Precio);
                    sqlCmd.Parameters.AddWithValue("@ServiceName", ServiceName);
                    sqlCmd.Parameters.AddWithValue("@Email", Email);
                    sqlCmd.Parameters.AddWithValue("@Numero", Numero);
                    sqlCmd.Parameters.AddWithValue("@Asistencia", Asistencia);
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Updated successfully");
                }
                //Reset();
                // FillDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
            finally
            {
                sqlCon.Close();
            }
        }


        public void delete()
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("DeleteCita", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CitaId", CitaId);
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Deleted successfully");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }



    }
}
