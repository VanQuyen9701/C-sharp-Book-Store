using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObject.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;

namespace BookStore.Controllers
{
    public class LoginController : Controller
    {
        private readonly MiniProjectContext clrContext;
        private IUserRepository UserRepository = new UserRepository();
        public LoginController(MiniProjectContext context)
        {
            clrContext = context;
        }

        public IActionResult Login()
        {
            HttpContext.Session.Clear();
            return View();
        }
         
        public IActionResult CheckLogin(string userID, string password)
        {
            TblUser Login = UserRepository.Login(userID, password);
            if(Login == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                if (Login.Status.Equals("OFF"))
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    if (Login.RoleId.Equals("AD"))
                    {
                        HttpContext.Session.SetString("ROLEID", "AD");
                        HttpContext.Session.SetString("USER", Login.UserId);
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        HttpContext.Session.SetString("ROLEID", "US");
                        HttpContext.Session.SetString("USER", Login.UserId);
                        return RedirectToAction("Shopping", "Shopping");
                    }
                }              
            }
        }
    }
}
