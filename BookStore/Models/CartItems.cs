using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObject.Models;

namespace BookStore.Models
{
    [Serializable]
    public class CartItems
    {
        public string bookID { get; set; }
        public string BookName { get; set; }
        public decimal Price { get; set; }
        public string CategoryId { get; set; }
        public int quantity { get; set; }
    }
}
