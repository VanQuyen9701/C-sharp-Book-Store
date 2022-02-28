using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Models;

namespace DataAccess.Repository
{
    public interface IUserRepository
    {
        public List<TblUser> GetUserList();
        public TblUser GetUserByID(string userID);
        public void InsertUser(TblUser user);
        public void UpdateUser(TblUser user);
        public TblUser Login(string userID, string password);
    }
}
