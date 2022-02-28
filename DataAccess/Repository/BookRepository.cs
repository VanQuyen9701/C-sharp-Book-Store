using BusinessObject.Models;
using System.Collections.Generic;

namespace DataAccess.Repository
{
    public class BookRepository : IBookRepository
    {
        public TblBook GetBookByID(string bookID) => BookDAO.Instance.GetBookByID(bookID);

        public List<TblBook> GetBookList() => BookDAO.Instance.GetBookList();

        public void InsertBook(TblBook book) => BookDAO.Instance.InsertProduct(book);

        public void UpdateBook(TblBook book) => BookDAO.Instance.UpdateProduct(book);

    }
}
