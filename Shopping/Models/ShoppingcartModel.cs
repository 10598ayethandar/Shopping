using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Collections.Generic;

namespace Shopping.Models
{
    public  class ShoppingcartModel 
    {
        private List<Product> products;
        public ShoppingcartModel()
        {
            DBModel dbmodel = new DBModel();
            this.products = dbmodel.Products.ToList();
        }
        public List<Product> findAll()
        {
            return this.products;
        }
        public Product find(int? ID)
        {
            return this.products.Single(p => p.Id == ID);
        }

        
    }
}
