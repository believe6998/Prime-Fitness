using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrimeFitness.Areas.Admin.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Admin/Test/

        public ActionResult Index()
        {
            Session["Demo"] = "This is demos";
            return View();
        }

    }
}
