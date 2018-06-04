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
            if (toAdd.Quantity <= 0)
                return;

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
            IList<Product> cart = GetCartItems(context).ToList();

            if (cart != null)
            {
                if (toRemove.Quantity > 1)
                {
                    toRemove.Quantity--;

                    cart.Where(x => x.Name == toRemove.Name).FirstOrDefault().Quantity = toRemove.Quantity;
                }
                else
                {
                    for (int i = 0; i < cart.Count; i++)
                    {
                        if (cart[i].Name == toRemove.Name)
                            cart.RemoveAt(i);
                    }
                }

                context.Session[CartSessionKey] = cart;
            }

        }

        public static void RemoveAll(Product toRemove, HttpContextBase context)
        {
            List<Product> cart = GetCartItems(context).ToList();

            if (cart != null && cart.Any(x => x.Name == toRemove.Name))
            {
                cart.RemoveAll(x => x.Name == toRemove.Name);

                context.Session[CartSessionKey] = cart;
            }

        }

        public static void Empty(HttpContextBase context)
        {
            context.Session[CartSessionKey] = null;
        }

        public static ICollection<Product> GetCartItems(HttpContextBase context)
        {
            ICollection<Product> cart = context.Session[CartSessionKey] as ICollection<Product>;

            return cart;
        }

    }
}