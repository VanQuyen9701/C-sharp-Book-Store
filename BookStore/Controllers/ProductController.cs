using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObject.Models;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly MiniProjectContext clrContext;
        public ProductController(MiniProjectContext context)
        {
            clrContext = context;
        }
        public IBookRepository bookRepo = new BookRepository();
        // GET: ProductController
        public async Task<IActionResult>  Index()
        {
            var session = HttpContext.Session;
            if (session.GetString("USER") != null)
            {
                if (session.GetString("ROLEID") == "AD")
                {
                    return View(await clrContext.TblBooks.ToListAsync());
                }
                else
                {
                    return RedirectToAction("Login", "Login");
                }
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            if (HttpContext.Session.GetString("ROLEID") == "AD")
            {
                return View();
            }
            return RedirectToAction("Login", "Login");
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TblBook book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bookRepo.InsertBook(book);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(string id)
        {
            if (HttpContext.Session.GetString("ROLEID") == "US")
            {
                return RedirectToAction("Login", "Login");
            }
            var book = bookRepo.GetBookByID(id);
            if(book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TblBook book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bookRepo.UpdateBook(book);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(book);
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(string id)
        {
            var book = bookRepo.GetBookByID(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: ProductController/Delete/5
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
