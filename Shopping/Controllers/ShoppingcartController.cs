using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopping.Models;

namespace Shopping.Controllers
{
    public class ShoppingcartController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Buy(int? ID)
        {
            ShoppingcartModel productModel = new ShoppingcartModel();

            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Product = productModel.find(ID), Quantity = 1 });
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                int index = isExist(ID);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { Product = productModel.find(ID), Quantity = 1 });
                }
                Session["cart"] = cart;
            }
            return RedirectToAction("Index");
        }

       

        public ActionResult Remove(int? ID)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            int index = isExist(ID);
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return RedirectToAction("Index");
        }
        private int isExist(int? ID)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id == ID)
                    return i;
            }
            return -1;
            
        }
    }
}