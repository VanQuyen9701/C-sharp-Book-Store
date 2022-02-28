using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Models;

namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        public void InsertOrderDetail(TblBook book, TblOrder order, int quantity);
    }
}
