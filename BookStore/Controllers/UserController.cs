using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using DataAccess.Repository;

namespace BookStore.Controllers
{
    public class UserController : Controller
    {
        private readonly MiniProjectContext clrContext;
        [TempData]
        public string Message { get; set; }
        public UserController(MiniProjectContext context)
        {
            clrContext = context;
        }
        public IUserRepository userRepo = new UserRepository();
        // GET: UserController
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("USER") != null)
            {
                if(HttpContext.Session.GetString("ROLEID") == "AD")
                {
                    return View(await clrContext.TblUsers.ToListAsync());
                }
                else
                {
                    return RedirectToAction("Shopping", "Shopping");
                }
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
            
        }

        // GET: UserController/Details/5
        public ActionResult Details(string id)
        {
            id = HttpContext.Session.GetString("USER");
            var user = userRepo.GetUserByID(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TblUser user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    userRepo.InsertUser(user);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(string id)
        {
            if (HttpContext.Session.GetString("ROLEID") != "AD")
            {
                return RedirectToAction("Login", "Login");
            }
            var user = userRepo.GetUserByID(id);
            if(user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( TblUser user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    userRepo.UpdateUser(user);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(user);
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(string id)
        {
            var user = userRepo.GetUserByID(id);
            if(user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
