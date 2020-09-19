using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SalonDeBelleza.GUI;

namespace SalonDeBelleza.DataAccess
{
    class CURD : ConnectionToSql
    {
        public string btnSave { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public int userId { get; set; }
        public object gridView { get; set; }
        public string btnUpdate { get; set; }

        

       // public  SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-H9C3U74;Initial Catalog=SalonDeBelleza;Integrated Security=True");
        
        public void save()
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                if (btnSave == "Save")
                {
                    SqlCommand sqlCmd = new SqlCommand("AddOrEdit", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@mode", "Add");
                    sqlCmd.Parameters.AddWithValue("@UserId", 0);
                    sqlCmd.Parameters.AddWithValue("@UserName", UserName);
                    sqlCmd.Parameters.AddWithValue("@Password", Password);
                    sqlCmd.Parameters.AddWithValue("@UserType", UserType);
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Saved successfully");
                }
                if (btnSave == "Update")
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

        public void update()
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                if (btnUpdate == "Update")
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
                SqlCommand sqlCmd = new SqlCommand("UserDelete", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserId", userId);
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Deleted successfully");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        public DataGridView datagrid { get; set; }
        
        public void FillDataGridView()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("ViewAndSearch", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@UserName", UserName);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            datagrid.DataSource = dtbl;
            datagrid.Columns[0].Visible = false;
            sqlCon.Close();
        }



        public object aaa { get; set; }
        
        public void showSomething()
        {
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("selec * from tbl_UserLogin", sqlCon);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            aaa = dtbl;
         }

    }
}
