using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Models;

namespace DataAccess.Repository
{
    public interface IBookRepository
    {
        public List<TblBook> GetBookList();
        public TblBook GetBookByID(string bookID);
        public void InsertBook(TblBook book);
        public void UpdateBook(TblBook book);
    }
}
