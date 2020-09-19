using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace SalonDeBelleza.DataAccess
{
   public  class ConnectionToSql
    {
        

       public SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-H9C3U74;Initial Catalog=SalonDeBelleza;Integrated Security=True");





        public readonly string connectionString;


        public ConnectionToSql()
        {
            connectionString = "Data Source=DESKTOP-H9C3U74;Initial Catalog=SalonDeBelleza;Integrated Security=True";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }



        

    }
}
