using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineStore.Data;
using OnlineStore.DBServices;

namespace OnlineStore.Areas.OnlineStore.Models
{
    public class CartViewModel
    {
        public List<Product> Products { get; set; }

        public CartViewModel()
        {
            Products = new List<Product>();
        }
    }
}