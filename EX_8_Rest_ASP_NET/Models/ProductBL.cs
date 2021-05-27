using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EX_8_Rest_ASP_NET.Models
{
    public class ProductBL
    {


        ProductEntities db = new ProductEntities();


        // Get All Products
        public List<products> GetProducts()
        {
            return db.products.ToList<products>();
        }

        // Get One Product
        public products GetProduct(int id)
        {
            return db.products.SingleOrDefault(x => x.ID == id);
        }

        public void EditProduct(int id, string name = null, float price = -1, string color = null)
        {
            var newName = string.IsNullOrWhiteSpace(name) ? null : name;
            var newPrice = price == -1 ? -1 : price;
            var newColor = string.IsNullOrWhiteSpace(color) ? null : color;


            var productToUpdate = db.products.SingleOrDefault(x => x.ID == id);
            if(productToUpdate != null)
            {
                if (newName != null)
                {
                    productToUpdate.name = newName;
                }
                if(newPrice != -1)
                {
                    productToUpdate.price = newPrice;
                }
                if(newColor != null)
                {
                    productToUpdate.color = newColor;
                }
                db.SaveChanges();
            }
            
        }

        public void DeleteProduct(int id)
        {
            var productToDelete = db.products.Where(x => x.ID == id).First();
            db.products.Remove(productToDelete);
            db.SaveChanges();
        
        }

        public void CreateProduct(string color, float price, string name)
        {
            products product = new products { color = color, name = name, price = price };
            Console.WriteLine("New Product: " + " " + product);
            db.products.Add(product);
            db.SaveChanges();
        }




    }
}