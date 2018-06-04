using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Data;
using System.Data.Entity;

namespace OnlineStore.DBServices
{
    public class OrderDBService : DBService
    {
        public Order CreateOrder(long customerId, ICollection<Product> cart)
        {
            if (cart == null || cart.Count <= 0)
                return null;

            Order newOrder = new Order()
            {
                CustomerId = customerId,
                Products = cart
            };

            try
            {
                if (!CheckProductsAvailability(cart))
                    return null;

                DB.Orders.Add(newOrder);
                DepleteAmount(cart);
                DB.SaveChanges();

                return newOrder;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        public ICollection<Order> GetOrdersByCustomer(long customerId)
        {
            return DB.Orders.Include(x => x.Products).Where(x => x.CustomerId == customerId).ToList();

        }

        private bool CheckProductsAvailability(ICollection<Product> products)
        {
            foreach (var product in products)
            {
                Product fromDB = DB.Products.Where(x => x.Name == product.Name).FirstOrDefault();

                if (fromDB != null)
                {
                    if (fromDB.Quantity < product.Quantity)
                        return false;
                }
                else
                    return false;
            }

            return true;
        }

        private void DepleteAmount(ICollection<Product> products)
        {
            foreach (var product in products)
            {
                Product dbProduct = DB.Products.Where(x => x.Name == product.Name).FirstOrDefault();

                dbProduct.Quantity -= product.Quantity;
            }
        }
    }
}
