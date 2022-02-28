using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObject.Models
{
    public partial class TblOrderDetail
    {
        public int DetailId { get; set; }
        public int? OrderId { get; set; }
        public string BookId { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public decimal? Total { get; set; }

        public virtual TblBook Book { get; set; }
        public virtual TblOrder Order { get; set; }
    }
}
