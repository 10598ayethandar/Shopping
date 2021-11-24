using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopping.Models;
using PagedList;
using PagedList.Mvc;

namespace Shopping.Controllers
{
    public class FrantEndController : Controller
    {
        // GET: FrantEnd
        public ActionResult Index(string search, int? page)
        {

            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.Products.Where(m => m.Name.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 10));
            }
        }
    }
}