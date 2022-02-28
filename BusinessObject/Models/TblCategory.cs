using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObject.Models
{
    public partial class TblCategory
    {
        public TblCategory()
        {
            TblBooks = new HashSet<TblBook>();
        }

        public string CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<TblBook> TblBooks { get; set; }
    }
}
