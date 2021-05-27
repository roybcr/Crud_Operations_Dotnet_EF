using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EX_8_Rest_ASP_NET.Models;
namespace EX_8_Rest_ASP_NET.Controllers
{
    public class ProductController : ApiController
    {

        // Should only be created one time instead of every time the controller is initialized
       private static ProductBL productBL = new ProductBL();


        // GET: api/Product
        public IEnumerable<products> Get()
        {
            return productBL.GetProducts();
        }

        // GET: api/Product/5
        public products Get(int id)
        {
            return productBL.GetProduct(id);
        }

        // POST: api/Product
        public void Post(products product)
        {
            var price = Convert.ToSingle(product.price);
            productBL.CreateProduct(product.color, price, product.name);
        }

        // PUT: api/Product/5
        public void PUT(int id, products product) 
        {
            var price = Convert.ToSingle(product.price);
            productBL.EditProduct(id, product.name, price, product.color);
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
            productBL.DeleteProduct(id);
        }
    }
}
