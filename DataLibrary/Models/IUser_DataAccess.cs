using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public interface IUser_DataAccess
    {
            bool CreateUser(UserDetails usr);
            List<UserDetails> GetUserDet();
            UserDetails GetUserDetByID(int Record_number);
            bool UpdateUser(UserDetails usr);
    }
}
