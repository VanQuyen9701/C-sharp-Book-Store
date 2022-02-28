using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public TblOrder GetOrderByID(int id) => OrderDAO.Instance.GetOrderByID(id);

        public TblOrder GetOrderByUserID(string userID) => OrderDAO.Instance.GetOrderByUserID(userID);

        public List<TblOrder> GetOrderList() => OrderDAO.Instance.GetOrderList();

        public void InsertOrder(string UserID) => OrderDAO.Instance.InsertOrder(UserID);
    }
}
