using PrimeFitness.Models.Entities;
using PrimeFitness.Models.Funtions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrimeFitness.Controllers
{
    public class PackageController : Controller
    {
        //
        // GET: /Package/
        private PrimeFitnessDbContext db = new PrimeFitnessDbContext();

        public ActionResult Index()
        {
            var model = new SanPhamF().DSSanPham.ToList();
            return View(model);
        }
        public ActionResult Category(string id)
        {
            //var category = new DanhMucF().FindEntity(id);
            //if (category == null)
            //{
            //    return View("Error");
            //}
            var model = new SanPhamF().DSSanPham.Where(s => s.MaDM == id).ToList(); //return list of projects in requested category

            return View("Index", model);
        }
        [ChildActionOnly]
        public ActionResult MenuCategory()
        {
            var model = new DanhMucF().DSDanhMuc.ToList();
            return PartialView(model);
        }
    }
}
