using PrimeFitness.Models.Entities;
using PrimeFitness.Models.Funtions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrimeFitness.Controllers
{
    public class CategoryController : Controller
    {
        //
        // GET: /Category/

        public ActionResult Index()
        {
            var model = new DanhMucF().DSDanhMuc.ToList();
            return View(model);
        }




    }
}
