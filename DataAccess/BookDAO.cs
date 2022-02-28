using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Models;

namespace DataAccess
{
    public class BookDAO
    {
        private static BookDAO instance = null;
        private static readonly object instanceLock = new object();
        private BookDAO() { }
        public static BookDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if(instance == null)
                    {
                        instance = new BookDAO();
                    }
                    return instance;
                }
            }
        }
        public List<TblBook> GetBookList()
        {
            var list = new List<TblBook>();
            using (var db = new MiniProjectContext())
            {
                list = db.TblBooks.ToList();
            }
            return list;
        }
        public TblBook GetBookByID(string BookID)
        {
            TblBook book = null;
            using(var db = new MiniProjectContext())
            {
                book = db.TblBooks.Find(BookID);
            }
            return book;
        }
        public void InsertProduct(TblBook book)
        {
            TblBook check = GetBookByID(book.BookId);
            if(check == null)
            {
                using (var db = new MiniProjectContext())
                {
                    db.TblBooks.Add(book);
                    db.SaveChanges();
                }
            }
            else
            {
                throw new Exception("Book exist!");
            }
        }
        public void UpdateProduct(TblBook book)
        {
            TblBook check = GetBookByID(book.BookId);
            if (check != null)
            {
                using (var db = new MiniProjectContext())
                {
                    db.TblBooks.Update(book);
                    db.SaveChanges();
                }
            }
            else
            {
                throw new Exception("Book not exist!");
            }
        }
    }
}
