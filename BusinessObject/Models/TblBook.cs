using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObject.Models
{
    public partial class TblBook
    {
        public TblBook()
        {
            TblOrderDetails = new HashSet<TblOrderDetail>();
        }

        public string BookId { get; set; }
        public string BookName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string CategoryId { get; set; }
        public string Status { get; set; }

        public virtual TblCategory Category { get; set; }
        public virtual ICollection<TblOrderDetail> TblOrderDetails { get; set; }
    }
}
