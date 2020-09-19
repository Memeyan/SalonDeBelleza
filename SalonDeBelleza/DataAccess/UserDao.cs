using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SalonDeBelleza.Common;


namespace SalonDeBelleza.DataAccess
{
   public class UserDao :  ConnectionToSql
    {
        public bool Login(string user,string pass)
        {
            
            
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select *from tbl_UserLogin where UserName=@user and Password=@pass";
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@pass", pass);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UserLoginCache.UserId = reader.GetInt32(0);
                            UserLoginCache.UserName = reader.GetString(1);
                            UserLoginCache.Password= reader.GetString(2);
                            UserLoginCache.UserType = reader.GetString(3);
                        }
                        return true;
                    }
                    else
                        return false;

                }
            }
        }


      

        }
}
