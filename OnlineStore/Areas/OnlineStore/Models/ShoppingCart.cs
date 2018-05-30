using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineStore.Data;
using OnlineStore.DBServices;

namespace OnlineStore.Areas.OnlineStore.Models
{
    public class ShoppingCart
    {
        public const string CartSessionKey = "CartId";

        public static void AddToCart(Product toAdd, HttpContextBase context)
        {
            ICollection<Product> cart;

            if (context.Session[CartSessionKey] is ICollection<Product>)
                cart = context.Session[CartSessionKey] as ICollection<Product>;
            else
                cart = new List<Product>();

            if (cart.Any(x => x.Name == toAdd.Name))
                cart.Where(x => x.Name == toAdd.Name).FirstOrDefault().Quantity += toAdd.Quantity;
            else
                cart.Add(toAdd);

            context.Session[CartSessionKey] = cart;
        }

        public static ICollection<Product> GetCartItems(HttpContextBase context)
        {
            ICollection<Product> cart = context.Session[CartSessionKey] as ICollection<Product>;

            return cart;
        }

    }
}