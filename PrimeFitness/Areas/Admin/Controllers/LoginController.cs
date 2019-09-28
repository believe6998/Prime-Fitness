using PrimeFitness.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrimeFitness.Models.Funtions;


namespace PrimeFitness.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Admin/Login/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Account model, string ReturnUrl)
        {
            if (String.IsNullOrEmpty(model.UserName))
            {
                return View("Index", model);
            }
            if (String.IsNullOrEmpty(model.Password))
            {
                return View("Index", model);
            }


            var acc = new NguoiDungF().Login(model.UserName, model.Password);


            if (acc == null)
            {
                ModelState.AddModelError("", "Người dùng không tồn tại");
                return View("Index", model);
            }
            else
            {
                Session["Login"] = acc;
                if (string.IsNullOrEmpty(ReturnUrl))
                {

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return Redirect(ReturnUrl);
                }
            }


        }
    }
}
