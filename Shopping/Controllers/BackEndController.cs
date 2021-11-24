using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopping.Models;
using System.IO;

using PagedList;
using PagedList.Mvc;
namespace Shopping.Controllers
{
    public class BackEndController : Controller
    {
        // GET: BackEnd
        public ActionResult Index(string search,int? page)
        {
            using(DBModel dbmodel=new DBModel())
            {
                return View(dbmodel.Products.Where(m => m.Name.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 8));
            }
        }
        

        // GET: BackEnd/Details/5
        public ActionResult Details(int id)
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.Products.Where(x=>x.Id==id).FirstOrDefault());
            }
        }

        // GET: BackEnd/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackEnd/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                string filename = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
                string extension = Path.GetExtension(product.ImageFile.FileName);
                Random random = new Random();
                int randomNumber = random.Next(0, 1000);
                filename = filename + randomNumber.ToString() + extension;
                product.ImagePath = "~/Image/" + filename;
                filename = Path.Combine(Server.MapPath("~/Image/"), filename);
                product.ImageFile.SaveAs(filename);


                using (DBModel dbmodel = new DBModel())
                {
                    dbmodel.Products.Add(product);
                    dbmodel.SaveChanges();
                }
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BackEnd/Edit/5
        public ActionResult Edit(int id)
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.Products.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: BackEnd/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,Product product)
        {
            try
            {
                using (DBModel dbmodel = new DBModel())
                {
                    dbmodel.Entry(product).State = System.Data.Entity.EntityState.Modified;
                    dbmodel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BackEnd/Delete/5
        public ActionResult Delete(int id)
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.Products.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: BackEnd/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (DBModel dbmodel = new DBModel())
                {
                    Product product = dbmodel.Products.Where(x => x.Id == id).FirstOrDefault();
                    dbmodel.Products.Remove(product);
                    dbmodel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
