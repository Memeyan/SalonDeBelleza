using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SalonDeBelleza.DataAccess;
using System.Windows.Forms;
namespace SalonDeBelleza.DataAccess
{
    class curd_cliente : ConnectionToSql
    {


        //public SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-H9C3U74;Initial Catalog=SalonDeBelleza;Integrated Security=True");
        
        public string btnSave { get; set; }
        public string ClientName { get; set; }
        public string ClienteApellido { get; set; }
        public string Age { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public string Estado { get; set; }
        public int ClientID { get; set; }
        //public string MyProperty { get; set; }

        public void save()
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                if (btnSave == "Guardar Cliente")
                {
                    SqlCommand sqlCmd = new SqlCommand("ClientAddAndEdit", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@mode", "Add");
                    sqlCmd.Parameters.AddWithValue("@ClientId", 0);
                    sqlCmd.Parameters.AddWithValue("@ClientName", ClientName);
                    sqlCmd.Parameters.AddWithValue("@ClientApellido", ClienteApellido);
                    sqlCmd.Parameters.AddWithValue("@Age", Age);
                    sqlCmd.Parameters.AddWithValue("@Email", Email);
                    sqlCmd.Parameters.AddWithValue("@Number", Number);
                    sqlCmd.Parameters.AddWithValue("@Estado", "Activado");
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Saved successfully");
                }
             /*   if (btnSave == "Update")
                {
                    SqlCommand sqlCmd = new SqlCommand("AddOrEdit", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@mode", "Edit");
                    sqlCmd.Parameters.AddWithValue("@UserId", userId);
                    sqlCmd.Parameters.AddWithValue("@UserName", UserName);
                    sqlCmd.Parameters.AddWithValue("@Password", Password);
                    sqlCmd.Parameters.AddWithValue("@UserType", UserType);
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Updated successfully");
                }*/
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



        public void saveAndEdit()
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                if (btnSave == "Guardar")
                {
                    SqlCommand sqlCmd = new SqlCommand("ClientAddAndEdit", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@mode", "Add");
                    sqlCmd.Parameters.AddWithValue("@ClientId", 0);
                    sqlCmd.Parameters.AddWithValue("@ClientName", ClientName);
                    sqlCmd.Parameters.AddWithValue("@ClientApellido", ClienteApellido);
                    sqlCmd.Parameters.AddWithValue("@Age", Age);
                    sqlCmd.Parameters.AddWithValue("@Email", Email);
                    sqlCmd.Parameters.AddWithValue("@Number", Number);
                    sqlCmd.Parameters.AddWithValue("@Estado", "Activado");
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Saved successfully");
                }
                if (btnSave == "Update")
                {
                    SqlCommand sqlCmd = new SqlCommand("ClientAddAndEdit", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@mode", "Edit");
                    sqlCmd.Parameters.AddWithValue("@ClientId", ClientID);
                    sqlCmd.Parameters.AddWithValue("@ClientName", ClientName);
                    sqlCmd.Parameters.AddWithValue("@ClientApellido", ClienteApellido);
                    sqlCmd.Parameters.AddWithValue("@Age", Age);
                    sqlCmd.Parameters.AddWithValue("@Email", Email);
                    sqlCmd.Parameters.AddWithValue("@Number", Number);
                    sqlCmd.Parameters.AddWithValue("@Estado", Estado);
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
                SqlCommand sqlCmd = new SqlCommand("ClientDelete", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ClientID", ClientID);
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
