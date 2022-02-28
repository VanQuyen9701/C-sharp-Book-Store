using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Models;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        public void InsertOrder(string UserID);
        public TblOrder GetOrderByUserID(string userID);
        public List<TblOrder> GetOrderList();
        public TblOrder GetOrderByID(int id);
    }
}
