using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.DBServices;

namespace OnlineStore.BusinessServices
{
    public class ProductService
    {
        private readonly ProductDBService dbService;

        public ProductService()
        {
            dbService = new ProductDBService();
        }

    }
}
