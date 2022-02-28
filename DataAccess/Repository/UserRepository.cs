using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        public TblUser GetUserByID(string userID) => UserDAO.Instance.GetUserByID(userID);

        public List<TblUser> GetUserList() => UserDAO.Instance.GetUsersList();

        public void InsertUser(TblUser user) => UserDAO.Instance.InsertUser(user);

        public TblUser Login(string userID, string password) => UserDAO.Instance.Login(userID, password);

        public void UpdateUser(TblUser user) => UserDAO.Instance.UpdateUser(user);
        
    }
}
