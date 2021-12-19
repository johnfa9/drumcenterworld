using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace drumcenterworld.Models
{
    public class CartItemList
    {
        public List<CartItem> cartItems;

        public CartItemList()
        {
            cartItems = new List<CartItem>();
        }

        public int Count
        {
            get { return cartItems.Count; }
        }

        public CartItem this[int index]
        {
            get { return cartItems[index]; }
        }

        public CartItem this[string id]
        {
            get
            {
                foreach (CartItem c in cartItems)
                    if (c.Product.ProductID == id) return c;
                return null;
            }
        }

        public static CartItemList GetCart()
        {
            CartItemList cart = (CartItemList)System.Web.HttpContext.Current.Session["Cart"];
            if (cart == null)
                System.Web.HttpContext.Current.Session["Cart"] = new CartItemList();
            return (CartItemList)System.Web.HttpContext.Current.Session["Cart"];
        }

        public void AddItem(Product product, int quantity)
        {
            CartItem c = new CartItem(product, quantity);
            cartItems.Add(c);
        }

        public void RemoveAt(int index)
        {
            cartItems.RemoveAt(index);
        }

        public void Clear()
        {
            cartItems.Clear();
        }
    }
}
