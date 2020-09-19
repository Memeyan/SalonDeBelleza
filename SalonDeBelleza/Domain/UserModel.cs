using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalonDeBelleza.Common;
using SalonDeBelleza.DataAccess;
namespace SalonDeBelleza.Domain
{
    class UserModel
    {

        UserDao userDao = new UserDao();
        public bool LoginUser(string user, string pass)
        {
            return userDao.Login(user, pass);
        }

    }
}
