using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Data;

namespace OnlineStore.DBServices
{
    public class CustomerDBService : DBService
    {
        public Customer GetCustomerById(long id)
        {
            return DB.Customers.Where(x => x.Id == id).FirstOrDefault();
        }

        public Customer GetCutomerByUserGUID(string userGUID)
        {
            return DB.Customers.Where(x => x.UserId == userGUID).FirstOrDefault();
        }

        public void CreateCustomer(Customer customer)
        {
            DB.Customers.Add(customer);

            DB.SaveChanges();
        }

    }
}
