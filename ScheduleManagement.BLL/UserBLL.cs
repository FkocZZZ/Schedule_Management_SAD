using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleManagement.DAL;

namespace ScheduleManagement.BLL
{
    public class UserBLL
    {
        private readonly UserDAL _userDAL;
        public UserBLL()
        {
            _userDAL = new UserDAL();
        }
        public bool ValidateUser(string username, string password)
        {
            try
            {
                return _userDAL.CheckUserLogin(username, password);
            }
            catch
            {
                throw; // Bubble exception lên FormLogin để catch
            }
        }
        public bool IsUsernameExists(string username)
        {
            return _userDAL.CheckUsernameExists(username);
        }
        public bool RegisterUser(string username, string password)
        {
            return _userDAL.AddUser(username, password);
        }
    }
}
