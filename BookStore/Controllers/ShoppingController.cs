using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers
{
    public class ShoppingController : Controller
    {
        private readonly MiniProjectContext clrContext;
        public ShoppingController(MiniProjectContext context)
        {
            clrContext = context;
        }
        public async Task<IActionResult>  Shopping()
        {
            var list = clrContext.TblBooks.ToList();
            var shopping = new List<TblBook>();
            foreach(var item in list)
            {
                if (item.Status.Equals("ON"))
                {
                    shopping.Add(item);
                }
            }
            return View(shopping);
        }
    }
}
