using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Models;

namespace DataAccess
{
    public class OrderDetailDAO
    {
        private static OrderDetailDAO instance = null;
        private static readonly object instanceLock = new object();
        public OrderDetailDAO() { }
        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                    return instance;
                }
            }
        }
        public void InsertOrderDetail(TblBook book,TblOrder order,int quantity)
        {
            TblOrderDetail detail = new TblOrderDetail()
            {
                OrderId = order.OrderId,
                BookId = book.BookId,
                Price = book.Price,
                Quantity = quantity,
                Total = book.Price * quantity
            };
            try
            {
                using (var db = new MiniProjectContext())
                {
                    db.TblOrderDetails.Add(detail);
                    db.SaveChanges();
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static List<TblOrderDetail> GetOrderDetailByOrderID(TblOrder order)
        {
            List<TblOrderDetail> list = new List<TblOrderDetail>();
            try
            {
                using (var db = new MiniProjectContext())
                {
                    list = db.TblOrderDetails
                        .Where(detail => detail.OrderId == order.OrderId)
                        .ToList();
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
    }
}
