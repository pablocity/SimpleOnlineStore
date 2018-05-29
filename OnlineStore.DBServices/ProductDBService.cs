using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Data;

namespace OnlineStore.DBServices
{
    public class ProductDBService : DBService
    {
        public ProductDBService()
        {
            //DB.Database.Initialize(true);
        }

        public Product GetProductById(long id)
        {
            return DB.Products.Where(x => x.Id == id).FirstOrDefault();
        }

        public ICollection<Product> GetProductCollection()
        {
            return DB.Products.ToList();
        }

        public bool UpdateProduct(Product updated)
        {
            try
            {
                Product old = GetProductById(updated.Id);

                old = updated;

                DB.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public void CreateProduct(Product product)
        {
            DB.Products.Add(product);

            DB.SaveChanges();
        }
    }
}
