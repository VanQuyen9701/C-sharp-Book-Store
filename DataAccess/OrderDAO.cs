using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Models;

namespace DataAccess
{
    public class OrderDAO
    {
        private static OrderDAO instance = null;
        private static readonly object instanceLock = new object();
        public OrderDAO() { }
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }
        public  void InsertOrder(string userID)
        {
            try
            {
                using (var db = new MiniProjectContext())
                {
                    db.TblOrders.Add(new TblOrder
                    {
                        UserId = userID,
                        StatusId = "DONE"
                    });
                    db.SaveChanges();
                }
            }
            catch( Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public TblOrder GetOrderByUserID(string userID)
        {
            TblOrder order = null;
            using(var db = new MiniProjectContext())
            {
                order = db.TblOrders.Where(o => o.UserId.Equals(userID)).First();
            }
            return order;
        }
        public List<TblOrder> GetOrderList()
        {
            var list = new List<TblOrder>();
            using(var db = new MiniProjectContext())
            {
                list = db.TblOrders.ToList();
            }
            return list;
        }
        public TblOrder GetOrderByID(int id)
        {
            TblOrder order = null;
            using(var db = new MiniProjectContext())
            {
                order = db.TblOrders.Find(id);
            }
            return order;
        }
        public void UpdateOrderCheckOut(string userID)
        {
            TblOrder check = GetOrderByUserID(userID);
            if (check != null)
            {
                using (var db = new MiniProjectContext())
                {
                    
                }
            }
        }
    }
}
