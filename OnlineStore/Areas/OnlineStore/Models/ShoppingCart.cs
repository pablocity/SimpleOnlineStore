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
            ICollection<Product> cart = GetCartItems(context);

            if (cart != null)
                cart = context.Session[CartSessionKey] as ICollection<Product>;
            else
                cart = new List<Product>();

            if (cart.Any(x => x.Name == toAdd.Name))
                cart.Where(x => x.Name == toAdd.Name).FirstOrDefault().Quantity += toAdd.Quantity;
            else
                cart.Add(toAdd);

            context.Session[CartSessionKey] = cart;
        }

        public static void Remove(Product toRemove, HttpContextBase context)
        {
            ICollection<Product> cart = GetCartItems(context);

            if (cart != null)
            {
                if (toRemove.Quantity > 1)
                {
                    toRemove.Quantity--;

                    cart.Where(x => x.Name == toRemove.Name).FirstOrDefault().Quantity = toRemove.Quantity;
                }
                else
                {
                    cart = cart.Where(x => x.Name == toRemove.Name).ToList();
                }

                context.Session[CartSessionKey] = cart;
            }

            return;
        }

        public static void RemoveAll(Product toRemove, HttpContextBase context)
        {

        }

        public static ICollection<Product> GetCartItems(HttpContextBase context)
        {
            ICollection<Product> cart = context.Session[CartSessionKey] as ICollection<Product>;

            return cart;
        }

    }
}