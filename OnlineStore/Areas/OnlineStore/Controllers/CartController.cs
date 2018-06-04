using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineStore.DBServices;
using OnlineStore.Data;
using OnlineStore.Areas.OnlineStore.Models;
using Microsoft.AspNet.Identity;

namespace OnlineStore.Areas.OnlineStore.Controllers
{
    public class CartController : Controller
    {
        readonly ProductDBService productService;
        readonly CustomerDBService customerService;
        readonly OrderDBService orderService;

        public CartController()
        {
            productService = new ProductDBService();
            customerService = new CustomerDBService();
            orderService = new OrderDBService();
        }

        // GET: OnlineStore/CartAll
        public ActionResult CartAll()
        {
            ICollection<Product> collection = ShoppingCart.GetCartItems(this.HttpContext);
            return View(collection);
        }

        public ActionResult AddProduct(string name, string amount)
        {
            Product product = productService.GetProductByName(name);
            if (product == null)
                throw new NotImplementedException();

            int.TryParse(amount, out int result);
            product.Quantity = result;

            ShoppingCart.AddToCart(product, this.HttpContext);

            //return RedirectToAction("CartAll", new { Area = "OnlineStore"});
            return RedirectToAction("Index", "Home", new { Area = String.Empty });
        }

        public ActionResult RemoveProduct(long id)
        {
            Product toRemove = ShoppingCart.GetCartItems(this.HttpContext).Where(x => x.Id == id).FirstOrDefault();

            if (toRemove != null)
                ShoppingCart.Remove(toRemove, this.HttpContext);

            return RedirectToAction("CartAll", "Cart", new { Area = "OnlineStore" });
        }

        public ActionResult RemoveAllProducts(long id)
        {
            Product toRemove = ShoppingCart.GetCartItems(this.HttpContext).Where(x => x.Id == id).FirstOrDefault();

            if (toRemove != null)
                ShoppingCart.RemoveAll(toRemove, this.HttpContext);

            return RedirectToAction("CartAll", "Cart", new { Area = "OnlineStore" });
        }

        [Authorize]
        public ActionResult PlaceOrder()
        {
            Customer customer = customerService.GetCutomerByUserGUID(this.User.Identity.GetUserId());
            ICollection<Product> products = ShoppingCart.GetCartItems(this.HttpContext);

            if (products == null || products.Count <= 0)
                return RedirectToAction("CartAll", "Cart", new { Area = "OnlineStore" });

            if (customer != null)
            {     
                Order result = orderService.CreateOrder(customer.Id, products);

                if (result == null)
                    return RedirectToAction("CartAll", "Cart", new { Area = "OnlineStore" });

                ShoppingCart.Empty(this.HttpContext);
                return RedirectToAction("Index", "Home", new { Area = String.Empty });
            }
            else
            {
                return RedirectToAction("CartAll", "Cart", new { Area = "OnlineStore" });
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult AddProductAjax(string name, string amount)
        {
            Product product = productService.GetProductByName(name);
            if (product == null)
                throw new NotImplementedException();

            int.TryParse(amount, out int result);
            product.Quantity = result;

            ShoppingCart.AddToCart(product, this.HttpContext);

            return new JsonResult();
        }

        // GET: OnlineStore/Cart/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OnlineStore/Cart/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: OnlineStore/Cart/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OnlineStore/Cart/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: OnlineStore/Cart/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OnlineStore/Cart/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
