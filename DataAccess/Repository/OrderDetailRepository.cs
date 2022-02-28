﻿using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public void InsertOrderDetail(TblBook book, TblOrder order, int quantity) => OrderDetailDAO.Instance.InsertOrderDetail(book, order, quantity);
    }
}
