using Microsoft.Owin;
using Owin;
using OnlineStore.DBServices;
using OnlineStore.Data;

[assembly: OwinStartupAttribute(typeof(OnlineStore.Startup))]
namespace OnlineStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            //Product product = new Product()
            //{
            //    Name = "T-Shirt Golden Schule",
            //    Price = 39.99M,
            //    Quantity = 15
            //};

            //Product product1 = new Product()
            //{
            //    Name = "Shorty Am Besten Perspective",
            //    Price = 45.99M,
            //    Quantity = 10
            //};

            //Product product2 = new Product()
            //{
            //    Name = "Leginsy Perspective Schild",
            //    Price = 40M,
            //    Quantity = 20
            //};

            //Product product3 = new Product()
            //{
            //    Name = "Medal Golden Klasse",
            //    Price = 89.99M,
            //    Quantity = 8
            //};

            ProductDBService service = new ProductDBService();

            //service.CreateProduct(product);
            //service.CreateProduct(product1);
            //service.CreateProduct(product2);
            //service.CreateProduct(product3);

            

        }
    }
}
