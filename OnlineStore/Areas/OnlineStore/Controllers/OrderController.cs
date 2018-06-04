using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineStore.DBServices;
using OnlineStore.Data;

namespace OnlineStore.Areas.OnlineStore.Controllers
{
    public class OrderController : Controller
    {
        readonly OrderDBService orderService;
        readonly CustomerDBService customerService;

        public OrderController()
        {
            orderService = new OrderDBService();
            customerService = new CustomerDBService();
        }

        // GET: OnlineStore/Order
        public ActionResult OrdersAll(string id)
        {
            Customer customer = customerService.GetCutomerByUserGUID(id);

            ICollection<Order> orders = orderService.GetOrdersByCustomer(customer.Id);

            return View(orders);
        }

        
    }
}
