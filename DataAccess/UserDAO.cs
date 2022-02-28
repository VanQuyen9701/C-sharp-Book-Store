using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Models;

namespace DataAccess
{
    public class UserDAO
    {
        private static UserDAO instance = null;
        private static readonly object instanceLock = new object();
        public UserDAO() { }
        public static UserDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if(instance == null)
                    {
                        instance = new UserDAO();
                    }
                    return instance;
                }
            }
        }
        public List<TblUser> GetUsersList()
        {
            var list = new List<TblUser>();
            using (var db = new MiniProjectContext())
            {
                list = db.TblUsers.ToList();
            }
            return list;
        }
        public TblUser GetUserByID(string userID)
        {
            TblUser user = null;
            using (var db = new MiniProjectContext())
            {
                user = db.TblUsers.Find(userID);
            }
            return user;
        }
        public void InsertUser(TblUser user)
        {
            TblUser check = GetUserByID(user.UserId);
            if(check == null)
            {
                using(var db = new MiniProjectContext())
                {
                    db.TblUsers.Add(new TblUser
                    {
                        UserId = user.UserId,
                        Fullname = user.Fullname,
                        Password = user.Password,
                        RoleId = "US",
                        Status = "ON"
                    });
                    db.SaveChanges();
                }
            }
            else
            {
                throw new Exception("User exist!");
            }
        }
        public void UpdateUser(TblUser user)
        {
            TblUser check = GetUserByID(user.UserId);
            if (check != null)
            {
                using (var db = new MiniProjectContext())
                {
                    check = db.TblUsers.Where(u => u.UserId.Equals(user.UserId)).First();
                    check.Fullname = user.Fullname;
                    check.Password = user.Password;
                    check.RoleId = user.RoleId;
                    check.Status = user.Status;
                    db.SaveChanges();
                }
            }
            else
            {
                throw new Exception("User not exist!");
            }
        }
        public TblUser Login(string userID,string password)
        {
            TblUser Login = null;
            using (var db = new MiniProjectContext())
            {
                Login = db.TblUsers.Where(user => user.UserId == userID && user.Password == password).SingleOrDefault();
            }
            return Login;
        }
    }
}
