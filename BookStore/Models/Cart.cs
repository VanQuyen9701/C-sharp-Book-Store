using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    [Serializable]
    public class Cart
    {
        public Dictionary<string, CartItems> cart;

        public Cart() { }

        public Cart(Dictionary<string, CartItems> cart)
        {
            this.cart = cart;
        }
        public Dictionary<string, CartItems> getCart()
        {
            return cart;
        }
        public void setCart(Dictionary<string, CartItems> cart)
        {
            this.cart = cart;
        }
        public void AddToCart(CartItems item)
        {
            if (this.cart == null)
            {
                cart = new Dictionary<string, CartItems>();
            }
            if (cart.ContainsKey(item.bookID))
            {
                int currentQuantity;
                currentQuantity = cart.GetValueOrDefault(item.bookID).quantity;
                item.quantity = item.quantity+ currentQuantity;
                cart.Remove(item.bookID);
                cart.Add(item.bookID, item);
            }
            else
            {
                cart.Add(item.bookID, item);
            }

        }
        public void UpdateCart(string bookID, int quantity)
        {

            if (cart.ContainsKey(bookID))
            {
                cart.GetValueOrDefault(bookID).quantity = quantity;
            }
        }
        public void RemoveCart(string BookID)
        {
            if (this.cart == null)
            {
                return;
            }
            if (cart.ContainsKey(BookID))
            {
                cart.Remove(BookID);
            }
        }
    }
}
