using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using Microsoft.Extensions.Caching.Memory;
using System.Web;
using BusinessObject.Models;
using DataAccess.Repository;
using Newtonsoft.Json;
using DataAccess;

namespace BookStore.Controllers
{
    public class CartController : Controller
    {
        public Cart cart = new Cart();
        public BookRepository repo = new BookRepository();
        public OrderRepository order = new OrderRepository();
        public IOrderDetailRepository detail = new OrderDetailRepository();

        public IActionResult ViewCart()
        {
            if(HttpContext.Session.GetString("USER") == null)
            {
                return RedirectToAction("Login", "Login");
            }
            List<CartItems> list = new List<CartItems>();
            var cart = GetJSonCart();
            if(cart.getCart() == null)
            {
                string message = "Not Availale";
                HttpContext.Session.SetString("MESSAGECART", message);
                return View();
            }
            else
            {
                foreach (var item in cart.getCart())
                {
                    list.Add(item.Value);
                }
                return View(list);
            }
            
        }
        
        
        [HttpGet]
        public IActionResult AddToCart(string bookid, int quantity)
        {
            if (HttpContext.Session.GetString("USER") == null)
            {
                return RedirectToAction("Login", "Login");
            }
            if (quantity > 0)
            {
                cart = GetJSonCart();
                TblBook Checkbook = repo.GetBookByID(bookid);
                cart.AddToCart(new CartItems
                {
                    bookID = Checkbook.BookId,
                    BookName = Checkbook.BookName,
                    CategoryId = Checkbook.CategoryId,
                    Price = Checkbook.Price,
                    quantity = quantity
                });
                SaveCartSession(cart);
                string message = "add success "+quantity+" "+bookid+" to cart";
                HttpContext.Session.SetString("MESSAGEADD", message);
                return RedirectToAction("Shopping", "Shopping");
            }
            else
            {
                return RedirectToAction("Shopping", "Shopping");
            }
            
        }
        public ActionResult UpdateCart(string bookid, int quantity)
        {
            if (HttpContext.Session.GetString("USER") == null)
            {
                return RedirectToAction("Login", "Login");
            }

            var cart = GetJSonCart();
            cart.UpdateCart(bookid, quantity);
            SaveCartSession(cart);
            
            return RedirectToAction("ViewCart", "Cart");
        }
        public ActionResult RemoveCart(string id)
        {
            if (HttpContext.Session.GetString("USER") == null)
            {
                return RedirectToAction("Login", "Login");
            }

            var cart = GetJSonCart();
            cart.RemoveCart(id);
            SaveCartSession(cart);
            
            return RedirectToAction("ViewCart", "Cart");
        }

        public ActionResult ThanhToan()
        {
            string user = HttpContext.Session.GetString("USER");
            var cart = GetJSonCart();
            order.InsertOrder(user);
            bool check = false;
            if(cart.getCart() == null)
            {
                string message = "you must add product to cart before check out";
                HttpContext.Session.SetString("MESSAGEADD", message);
                return RedirectToAction("Shopping", "Shopping");
            }
            foreach (var item in cart.getCart())
            {
                foreach(var book in repo.GetBookList())
                {
                    if(item.Value.bookID == book.BookId)
                    {
                        if (book.Quantity >= item.Value.quantity){
                            
                            book.Quantity = book.Quantity - item.Value.quantity;
                            
                            var orderToDetail = order.GetOrderByUserID(user);
                            detail.InsertOrderDetail(book, orderToDetail, item.Value.quantity);
                            repo.UpdateBook(book);
                            check = true;
                        }
                        else
                        {
                            string message = "Quantity not available";
                            HttpContext.Session.SetString("MESSAGECART", message);
                            check = false;
                            break;
                        }
                    }
                }
            }
            if (check)
            {
                ClearCart();
                return RedirectToAction("Shopping", "Shopping");
            }
            return RedirectToAction("ViewCart", "Cart");

        }


        //CartJson
        public const string Cart = "CART";
        Cart GetJSonCart()
        {
            var session = HttpContext.Session;
            string jsoncart = session.GetString(Cart);
            if(jsoncart != null)
            {
                return JsonConvert.DeserializeObject<Cart>(jsoncart);
            }
            return new Cart();
        }
        void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove(Cart);
        }
        void SaveCartSession(Cart cart)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(cart);
            session.SetString(Cart, jsoncart);
        }
    }
}
