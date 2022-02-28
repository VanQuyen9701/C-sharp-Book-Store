using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObject.Models
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblOrders = new HashSet<TblOrder>();
        }

        public string UserId { get; set; }
        public string Fullname { get; set; }
        public string RoleId { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }

        public virtual TblRole Role { get; set; }
        public virtual ICollection<TblOrder> TblOrders { get; set; }
    }
}
